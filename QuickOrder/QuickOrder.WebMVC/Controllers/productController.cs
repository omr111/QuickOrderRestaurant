using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.WebMVC.Models;
using PagedList;

using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;
using QuickOrder.UnitOfWork.Abstract;

namespace QuickOrder.WebMVC.Controllers
{
    public class productController : Controller
    {
        IUnitOfWork ctx;
        public productController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }
        // GET: product
        public ActionResult Index(int page = 1)
        {

            productModel pModel = new productModel();
            pModel.products = ctx.productBll.getAll().ToPagedList(page, 12);
            pModel.categories = ctx.categoryBll.getAll();
            return View(pModel);
        }
        public ActionResult filterProduct(productModel model)
        {
            int pageIndex = model.page ?? 1;

            productModel pModel = new productModel();
            pModel.name = model.name;
            pModel.products = ctx.productBll.getAll().Where(x => x.name.Contains(model.name)).ToList().ToPagedList(pageIndex, 12);
            pModel.categories = ctx.categoryBll.getAll();
            return View(pModel);

        }
        public ActionResult productDetail(int id)
        {
            Products pro = ctx.productBll.getOne( id);
            if (pro != null)
            {
                productDetail detail = new productDetail
                {
                    relatedProducts = ctx.productBll.getAll().Where(x => x.categoryID == pro.categoryID).Take(20).ToList(),
                    singleProduct = pro,
                };
                return View(detail);
            }
            else
            {
                return PartialView("_error", "The Product is not Found");
            }

        }
        public ActionResult searchProduct(string search)
        {
            List<Products> relatedProducts = ctx.productBll.getAll().Where(x => x.name.Contains(search)).ToList();

            return RedirectToAction("Index", "product", relatedProducts);


        }
    }
}