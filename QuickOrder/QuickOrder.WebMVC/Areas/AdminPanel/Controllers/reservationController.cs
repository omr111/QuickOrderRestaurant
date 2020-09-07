using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.UnitOfWork.Abstract;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace QuickOrder.WebMVC.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class reservationController : Controller
    {
        IUnitOfWork ctx;
        public reservationController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }
        // GET: AdminPanel/reservation
        public ActionResult Index()
        {
            
            ViewBag.reservation = ctx.rezervationBll.getAll().OrderBy(x=>x.showed).ToList();
            return View();
        }

        [HttpPost]
        public int deleteReservation(int id)
        {

           rezervations rezervations= ctx.rezervationBll.getOne( id);
            bool result = ctx.rezervationBll.deleteById(rezervations.id);
      
               if (result)
               {
                   return 1;
               } return 0;
            
        }

        [HttpPost]
        public int reservationShowed(int id)
        {
            rezervations rez = ctx.rezervationBll.getOne(id);
            if (ModelState.IsValid)
            {
                rez.showed = true;
                bool result = ctx.rezervationBll.add(rez);
                
                
                if (result)
                {
                    return 1;
                }

                return 0;
            }
            return 0;
           
        }
    }
}