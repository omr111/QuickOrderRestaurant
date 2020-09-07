using QuickOrder.WebMVC.Models;
using QuickOrder.Entities.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickOrder.WebMVC.App_Classes;
using static QuickOrder.WebMVC.App_Classes.card;
using System.Data.Entity.Migrations;
using QuickOrder.UnitOfWork.Abstract;

namespace QuickOrder.WebMVC.Controllers
{
    public class basketController : Controller
    {
        IUnitOfWork ctx;
        public basketController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }
        // GET: basket
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult basket()
        {            
            if (HttpContext.Session["activeBasket"] != null)
            {
                return PartialView((card)HttpContext.Session["activeBasket"]);
            }
            return PartialView();
        }
        public void addBasket(int id)
        {            
            var pro = ctx.productBll.getOne(id);
            if (pro != null)
            {
                card card = new card();
                basketItem item = new basketItem();
                item.products = pro;
                item.count = 1;
                item.discount = 0;
                card.addBasket(item);
            }
        }
        public void deleteBasket(int id)
        {
            if (Session["activeBasket"] != null)
            {

                card basketDetailList = (card)Session["activeBasket"];
                if (basketDetailList.BasketItems.Any(x => x.products.id == id))
                {
                    if (basketDetailList.BasketItems.FirstOrDefault(x => x.products.id == id).count >= 2)
                    {
                        basketDetailList.BasketItems.FirstOrDefault(x => x.products.id == id).count--;
                    }
                    else
                        basketDetailList.BasketItems.Remove(basketDetailList.BasketItems.FirstOrDefault(x => x.products.id == id));
                }


            }

        }
        public ActionResult basketDetail()
        {
            
            if (HttpContext.Session["activeBasket"] != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_basketDetail", (card)HttpContext.Session["activeBasket"]);
                }
                return View((card)HttpContext.Session["activeBasket"]);
            }
            return View(HttpContext.Session["activeBasket"] = new card());
        }
        [HttpGet]
        public void countIncrease(int id)
        {
            if (HttpContext.Session["activeBasket"] != null)
            {
                card basketDetailList = (card)Session["activeBasket"];

                if (basketDetailList.BasketItems.Any(x => x.products.id == id))
                {
                    basketDetailList.BasketItems.FirstOrDefault(x => x.products.id == id).count++;
                }
            }

        }
        public void countDecrease(int id)
        {
            if (HttpContext.Session["activeBasket"] != null)
            {
                card basketDetailList = (card)Session["activeBasket"];

                if (basketDetailList.BasketItems.Any(x => x.products.id == id))
                {
                    if (basketDetailList.BasketItems.FirstOrDefault(x => x.products.id == id).count >= 2)
                    {
                        basketDetailList.BasketItems.FirstOrDefault(x => x.products.id == id).count--;
                    }

                }

            }
        }

        public ActionResult deleteFromDetail(int id)
        {
            if (HttpContext.Session["activeBasket"] != null)
            {
                card basketDetailList = (card)Session["activeBasket"];

                if (basketDetailList.BasketItems.Any(x => x.products.id == id))
                {
                    basketDetailList.BasketItems.Remove(basketDetailList.BasketItems.FirstOrDefault(x => x.products.id == id));
                  
                        return PartialView("_basketDetail", (card)HttpContext.Session["activeBasket"]);
                   
                }
               
                    return PartialView("_basketDetail", (card)HttpContext.Session["activeBasket"]);
            }
            return RedirectToAction("index", "home");
        }
        public ActionResult checkout()
        {
            if (HttpContext.Session["activeBasket"] != null)
            {
                return View((card)HttpContext.Session["activeBasket"]);
            }
            return View(HttpContext.Session["activeBasket"] = new card());
        }
        [Authorize]
        [HttpPost]
        public ActionResult checkout(Bills bill)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Request.IsAuthenticated)
                    {
                        Guid orderCode =Guid.NewGuid();
                      
                        card card = (card)HttpContext.Session["activeBasket"];
                        if (card != null)
                        {
                           
                            bill.orderCode = orderCode;
                           
                            bill.billDate = DateTime.Now;
                        
                            bill.totalPrice = card.cardTotalPrice;
                            bill.status = true;
                            ctx.billBll.add(bill);
                            SaleProducts sale = new SaleProducts
                            {
                                customerID = ctx.userBll.getOneByEmail(User.Identity.Name).id,
                                date = DateTime.Now,
                                totalAmount = card.cardTotalPrice,
                                payType = bill.payType,
                                billID = bill.id,
                                status = true,
                                orderCode=orderCode,
                                description= bill.description,
                                orderDate=bill.orderDate

                            };

                            ctx.saleProductBll.add(sale);
                          

                            foreach (var item in card.BasketItems)
                            {
                                SaleProductsDetails details = new SaleProductsDetails
                                {
                                    productID = item.products.id,
                                    count = item.count,
                                    productPrice = (decimal)item.products.price,
                                    amount = item.totalPrice,
                                    SaleID = sale.id,
                                    tax = card.tax
                                };
                                ctx.saleProductsDetailBll.add(details);
                                
                            }
                   

                            HttpContext.Session["activeBasket"] = null;

                        }
                        return RedirectToAction("success","basket",new { orderCode=orderCode });
                    }
                    else return RedirectToAction("login", "users");
                   
                }
                else return View();
            }
            catch (Exception e)
            {

                return RedirectToAction("_error",e.Message);
            }



        }
        public ActionResult success(Guid orderCode)
        {
            return View(orderCode);
        }
    }
}