using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickOrder.WebMVC.Controllers
{
    public class aboutController : Controller
    {
        IUnitOfWork ctx;
        public aboutController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }
        // GET: about
        public ActionResult Index()
        {
            return View(ctx.companyInformationBll.getOne(1)==null?new CompanyInformations(): ctx.companyInformationBll.getOne(1));
        }
   

    }
}