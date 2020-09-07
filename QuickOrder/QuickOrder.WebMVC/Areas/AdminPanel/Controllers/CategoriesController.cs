using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.UnitOfWork.Abstract;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace QuickOrder.WebMVC.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class CategoriesController : Controller
    {

        IUnitOfWork ctx;
        public CategoriesController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }

        // GET: AdminPanel/Categories
        public ActionResult Index()
        {
            List<Categories> cat = ctx.categoryBll.getAll();


            return View(cat);
        }
        [HttpPost]
        public ActionResult categoryAdd(string categoryName)
        {
            if (!string.IsNullOrEmpty(categoryName)||categoryName!="")
            {
                Categories cat;
                cat = ctx.categoryBll.getOneByName(categoryName);
                if (cat!=null)
                {
                    cat= new Categories();
                    cat.categoryName = categoryName;
                    ctx.categoryBll.add(cat);
                   
                    
                }
                
            }
           
            return RedirectToAction("Index", "Categories", new {area = "AdminPanel"});
        }
        [HttpPost]
        public ActionResult categoryDelete(int id)
        {
            
            Categories cat = ctx.categoryBll.getOne( id);
            if (cat!=null)
            {
                cat.status = false;
                ctx.categoryBll.add(cat);
             
            
                return RedirectToAction("Index","Categories",new {area="AdminPanel"});
            }
            else
            {
                return Json(new {code=1, message="The Category is not found !"});
            }

        }
    }
}