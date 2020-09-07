using QuickOrder.WebMVC.App_Classes;
using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickOrder.UnitOfWork.Abstract;

namespace QuickOrder.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork ctx;
        public HomeController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }
        // GET: Home
        public ActionResult Index()
        {
            List<Products> products = ctx.productBll.getAll();
           
            mainPageFoodMenuModel main = new mainPageFoodMenuModel()
            {
                products = products.Take(12).ToList(),
                categories = ctx.categoryBll.getAll(),
            };
            homeModel home = new homeModel()
            {

                customerReviews = ctx.reviewBll.getAll().Count() > 0 ? ctx.reviewBll.getAll() : new List<reviews>(),
                products = products,
                services = ctx.serviceBll.getAll(),
                about = ctx.companyInformationBll.getOne(2),
                mainPageFood = main

            };
            return View(home);
        }
        public PartialViewResult banner()
        {
            return PartialView(ctx.bannerBll.getAll());
        }
        public PartialViewResult footer()
        {
            return PartialView(ctx.companyInformationBll.getOne(2));
        }
        public PartialViewResult bookTable()
        {
            
            return PartialView();
        }
        [HttpPost]
        public ActionResult bookTable(rezervations res)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ctx.rezervationBll.add(res);
                    return Json(new { error = 1 });
                }
                else
                {
                    List<string> errorList = new List<string>();
                    foreach (var modelError in ModelState.Values.SelectMany(x => x.Errors))
                    {
                        errorList.Add(modelError.ErrorMessage);

                    }

                    return Json(new { error = 0, list = errorList });
                }
            }
            catch (Exception e)
            {

                return PartialView("_error", e.Message);
            }



        }
       
        public PartialViewResult header()
        {
            List<Products> daily = ctx.productBll.getAll().OrderByDescending(x => x.id).ToList();
            if (daily.Count() > 2)
            {
                daily.Take(2).ToList();
            } else
                daily.ToList();
            headerModel hModel = new headerModel()
            {
                Categories = ctx.categoryBll.getAll().ToList(),
                dailyFoods = daily,
                company= ctx.companyInformationBll.getOne(2)
            };
            return PartialView(hModel);
        }

    }


}