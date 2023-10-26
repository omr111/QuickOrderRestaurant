using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.UnitOfWork.Abstract;
using QuickOrder.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickOrder.WebMVC.Controllers
{
    public class contactController : Controller
    {
        IUnitOfWork ctx;
        public contactController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }
        // GET: contact
        public ActionResult Index()
        {
            contactModel contact = new contactModel();
            contact.compInfo = ctx.companyInformationBll.getOne(1)== null?  new CompanyInformations():ctx.companyInformationBll.getOne(1);
            contact.reviews = new reviews();
            return View(contact);
        }
      
        [HttpPost]
        public ActionResult Index(reviews reviews)
        {
            if (ModelState.IsValid)
            {
                ctx.reviewBll.add(reviews);
              
                return Json(new { err = 0 });
            }
            else {
                
                return Json(new {err=1,modelState=ModelState.Values.SelectMany(x=>x.Errors).Select(y=>y.ErrorMessage).ToList() });
            }
        } 
       
    }
}