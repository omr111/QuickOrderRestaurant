
using System.Web.Mvc;

namespace QuickOrder.WebMVC.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class RoleController : Controller
    {
       
        // GET: AdminPanel/Role
        public ActionResult Index()
        {
            return View();
        }

        
       
    }
}