using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace QuickOrder.WebMVC.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Moderator")]

    public class reviewController : Controller
    {
        IUnitOfWork ctx;
        public reviewController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }

        // GET: AdminPanel/review
        public ActionResult Index()
        {
            ViewBag.reviews = ctx.reviewBll.getAll();
            return View();
        }
        [HttpPost]
        public int reviewDelete(int id)
        {
            reviews review = ctx.reviewBll.getOne(id);
            bool resultDelete = ctx.reviewBll.deleteById(review.id);
      
            if (resultDelete)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }


    }
}