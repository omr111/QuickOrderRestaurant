using QuickOrder.Entities.Entities;
using QuickOrder.UnitOfWork.Abstract;
using QuickOrder.WebMVC.Areas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickOrder.WebMVC.Areas.AdminPanel.Controllers
{
    public class PromotionController : Controller
    {
 

        IUnitOfWork ctx;
        public PromotionController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }
        // GET: AdminPanel/product
        public ActionResult Index()
        {

            return View(ctx.promotionBll.getAll());
        }

        public ActionResult promotionAdd()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult promotionAdd(Promotion Promotion)
        {

            try
            {
                if (ModelState.IsValid)
                {
                  

                    ctx.promotionBll.add(Promotion);


                    return RedirectToAction("Index", "Promotion", new { area = "AdminPanel" });
                }
                else
                {
                   
                    return View("productAdd");
                }
            }
            catch (Exception e)
            {
                ViewData["productAddingError"] = "Lütfen Tüm Alanları Doldurun";
                ViewBag.category = ctx.categoryBll.getAll();
                return View("promotionAdd");
            }

        }
        [HttpPost]
        public int promotionDelete(int id)
        {

            Promotion pro = ctx.promotionBll.getOne(id);


            if (pro != null)
            {


              

                bool resultDelete = ctx.promotionBll.deleteById(pro.id);

                if (resultDelete)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            return 0;
        }
        public ActionResult promotionUpdate(int id)
        {
            Promotion pro = ctx.promotionBll.getOne(id);

            if (pro != null)
            {
             
                return View(pro);
            }
            else
            {
                TempData["productUpdateError"] = "Güncellemek İstediğiniz Promosyon Bulunamadı !";
                return RedirectToAction("Index", "Promotion", new { area = "AdminPanel" });
            }


        }

        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult promotionUpdate(Promotion pro)
        {

            try
            {


                if (ModelState.IsValid)
                {
                    Promotion promotion = ctx.promotionBll.getOne(pro.id);
                    if (promotion != null)
                    {


                        promotion.DiscountRate = pro.DiscountRate;
                        promotion.Endate = pro.Endate;
                        promotion.PromotionKey = pro.PromotionKey;
                      
                        bool resultUpdate = ctx.promotionBll.update(promotion);


                        if (resultUpdate)
                        {

                            return RedirectToAction("Index", "Promotion", new { area = "AdminPanel" });
                        }
                        else
                        {
                        
                            TempData["productUpdateError"] = "Promosyon Güncellenemedi Tekrar Deneyiniz !";
                            return View(pro);


                        }

                    }
                    else
                    {

                       TempData["productUpdateError"] = "Promosyon Güncellenemedi Tekrar Deneyiniz !";
                            return View(pro);
                    }

                }
                else
                {

                   
                    TempData["productUpdateError"] = "Geçersiz Değer!";

                    return View("productUpdate", pro);
                }

            }
            catch (Exception e)
            {

                TempData["productUpdateError"] = e.Message;

                return View(pro);
            }
        }
    }
}