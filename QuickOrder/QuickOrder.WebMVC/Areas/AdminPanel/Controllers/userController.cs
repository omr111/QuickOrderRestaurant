using System.Web.Mvc;
using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.WebMVC.Areas.Models;
using System.Linq;
using System.Data.Entity.Migrations;
using QuickOrder.UnitOfWork.Abstract;

namespace QuickOrder.WebMVC.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class userController : Controller
    {
        IUnitOfWork ctx;
        public userController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }
        // GET: AdminPanel/user
        public ActionResult Index()
        {
            usersAndRoles usersAndRoles =new usersAndRoles();
            usersAndRoles.Users = ctx.userBll.getAllJustCustomer();
            
            usersAndRoles.Roles =ctx.roleBll.getAll();
            return View(usersAndRoles);
        }

        public ActionResult managementTeam()
        {
            return View(ctx.userBll.getAllWithoutCustomer());
        }

        public ActionResult userBlock(int id)
        {

            users usr = ctx.userBll.getOne( id);

             if (usr.isBlock)
            {
                usr.isBlock = false;
            }
            else
            {
                usr.isBlock = true;
            }
            ctx.userBll.add(usr);
        
            return RedirectToAction("Index", "user",new {area="AdminPanel"});
        }
        public ActionResult managerBlock(int id)
        {

            users usr = ctx.userBll.getOne(id);

            if (usr.isBlock)
            {
                usr.isBlock = false;
            }
            else
            {
                usr.isBlock = true;
            }

            ctx.userBll.add(usr);

            return RedirectToAction("managementTeam", "user", new { area = "AdminPanel" });
        }
    }
}