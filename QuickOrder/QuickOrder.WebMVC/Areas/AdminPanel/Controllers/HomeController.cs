using System.Linq;
using System.Web.Mvc;
using QuickOrder.WebMVC.Areas.Models;
using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.UnitOfWork.Abstract;

namespace QuickOrder.WebMVC.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class HomeController : Controller
    {
        IUnitOfWork ctx;
        public HomeController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }
        // GET: AdminPanel/Home
        public ActionResult Index()
        {
            AdminIndex adminIndex=new AdminIndex();
            adminIndex.Products = ctx.productBll.getAll();
            
            adminIndex.newReservationCount = ctx.rezervationBll.getAll().Count;
            adminIndex.defaultReservations = ctx.rezervationBll.getAll();
            adminIndex.Users = ctx.userBll.getAll();
            adminIndex.managementTeam = ctx.userBll.getAll().Where(x => x.roleOfUsers.Any(y => y.roles.roleName != "customer")).ToList();
            ViewBag.OnlineVisitor = HttpContext.Application["visitor"];
            return View(adminIndex);
        }
        public PartialViewResult favicon()
        {
            return PartialView(ctx.companyInformationBll.getOne(2));
        }
    }
}