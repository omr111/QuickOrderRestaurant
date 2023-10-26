using QuickOrder.WebMVC.Areas.Models;
using QuickOrder.Entities.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickOrder.UnitOfWork.Abstract;

namespace QuickOrder.WebMVC.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class productController : Controller
    {
        IUnitOfWork ctx;
        public productController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }
        // GET: AdminPanel/product
        public ActionResult Index()
        {
           
            return View(ctx.productBll.getAll());
        }

        public ActionResult productAdd()
        {
            ViewBag.category = ctx.categoryBll.getAll();
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult productAdd(Products product, HttpPostedFileBase file)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        product.coverPicturePath = pictureController.pictureAddForProduct(file, HttpContext);


                        if (file.FileName.Length > 50)
                        {
                            product.pictureAlt = file.FileName.Substring(0, 49);
                        }
                        else
                        {
                            product.pictureAlt = file.FileName;
                        }
                    }
                  
                    ctx.productBll.add(product);
                 
                    
                    return RedirectToAction("Index", "product", new { area = "AdminPanel" });
                }
                else
                {
                    ViewBag.category = ctx.categoryBll.getAll();
                    return View("productAdd");
                }
            }
            catch (Exception e)
            {
                ViewData["productAddingError"] = "Lütfen Tüm Alanları Doldurun";
                ViewBag.category = ctx.categoryBll.getAll();
                return View("productAdd");
            }
          
        }
        [HttpPost]
        public int productDelete(int id)
        {

            Products pro = ctx.productBll.getOne( id); 
                
            
            if (pro != null)
            {
               

                if (System.IO.File.Exists(Server.MapPath(pro.coverPicturePath)))
                {
                    System.IO.File.Delete(Server.MapPath(pro.coverPicturePath));

                }
                bool resultDelete = ctx.productBll.deleteById(pro.id);
            
                if (resultDelete)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
               
            }
            return 0;
        }

        public ActionResult productUpdate(int id)
        {
            Products product = ctx.productBll.getOne(id);
           
            if (product!=null   )
            {
                productUpdateModel pModel = new productUpdateModel();
                pModel.Product = product;
                pModel.Categories = ctx.categoryBll.getAll();
                return View(pModel);
            }
            else
            {
                TempData["productUpdateError"] = "Güncellemek İstediğiniz Ürün Bulunamadı !";
                return RedirectToAction("Index", "product", new {area = "AdminPanel"});
            }

           
        }
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult productUpdate(Products pro, HttpPostedFileBase file)
        {

            try
            {
             
                
                if (ModelState.IsValid)
                {
                    Products product = ctx.productBll.getOne(pro.id);
                    if (product != null)
                    {
                        if (file != null)
                        {
                            if (System.IO.File.Exists(Server.MapPath(product.coverPicturePath)))
                            {
                                System.IO.File.Delete(Server.MapPath(product.coverPicturePath));

                            }

                            product.coverPicturePath = pictureController.pictureAddForProduct(file, HttpContext);
                            product.pictureAlt = pro.pictureAlt;
                        }

                        product.name = pro.name;
                        product.categoryID = pro.categoryID;
                        product.caption = pro.caption;
                        product.description = pro.description;
                        product.price = pro.price;
                        bool resultUpdate = ctx.productBll.update(product);
                     
                        
                        if (resultUpdate)
                        {
                           
                            return RedirectToAction("Index","product",new{area="AdminPanel"});
                        }
                        else
                        {

                            productUpdateModel updateModel = new productUpdateModel();
                            updateModel.Categories = ctx.categoryBll.getAll();
                            updateModel.Product = pro;
                            TempData["productUpdateError"] = "Ürün Güncellenemedi Tekrar Deneyiniz !";
                            return View(updateModel);
                            
                            
                        }
                   
                    }
                    else
                    {

                        productUpdateModel updateModel = new productUpdateModel();
                        updateModel.Categories = ctx.categoryBll.getAll();
                        updateModel.Product = pro;
                        TempData["productUpdateError"] = "Ürün Bulunamadı!";

                        return View(updateModel);
                    }
                
                }
                else
                {

                    productUpdateModel updateModel = new productUpdateModel();
                    updateModel.Categories = ctx.categoryBll.getAll();
                    updateModel.Product = pro;
                    TempData["productUpdateError"] = "Geçersiz Değer!";

                    return View("productUpdate",updateModel);
                }
            
            }
            catch (Exception e)
            {

                productUpdateModel updateModel = new productUpdateModel();
                updateModel.Categories = ctx.categoryBll.getAll();
                updateModel.Product = pro;
                TempData["productUpdateError"] = e.Message;

                return View(updateModel);
            }
        }
     
    }
}