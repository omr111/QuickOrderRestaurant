using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.IO;
using QuickOrder.Entities.Entities.EntityFramework;
using System.Linq;
using QuickOrder.WebMVC.App_Classes;
using System.Data.Entity.Migrations;
using QuickOrder.UnitOfWork.Abstract;

namespace QuickOrder.WebMVC.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class bannerController : Controller
    {
        IUnitOfWork ctx;
        public bannerController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }
        // GET: AdminPanel/banner
        public ActionResult Index()
        {
            List<banners> banners = ctx.bannerBll.getAll();
            if (banners!=null)
            {
                return View(banners);
            }
            return View();
        }
        [HttpPost]
        public ActionResult bannerAdd(string text, HttpPostedFileBase companyPicturePath)
        {

            try
            {
                if (ModelState.IsValid &&!string.IsNullOrEmpty(text)&& companyPicturePath!=null)
                {
                    int picWidth = settings.bannerPicture.Width;
                    int pichHeight = settings.bannerPicture.Height;
                    string newName = Path.GetFileNameWithoutExtension(companyPicturePath.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(companyPicturePath.FileName);
                    Image orjResim = Image.FromStream(companyPicturePath.InputStream);
                    Bitmap pictureDraw = new Bitmap(orjResim, picWidth, pichHeight);
                    if (Directory.Exists(Server.MapPath("/content/img/bannerPicture")))
                    {
                        pictureDraw.Save(Server.MapPath("/content/img/bannerPicture/" + newName));
                    }

                    banners bnr = new banners();
                    bnr.text = text;
                    bnr.bannerPath = "/content/img/bannerPicture/" + newName;
                    //resmin alt'ı olarak kullanacağım filename'i
                    bnr.altName = companyPicturePath.FileName;
                    bool result=ctx.bannerBll.add(bnr);
                     
                    Session["bannerAlert"] = "";
                    if (result)
                    {
                        Session["bannerAlert"] = "Banner Added Succesfully";
                        return RedirectToAction("Index", "banner", new { area = "AdminPanel" });
                    }
                    else
                    {
                        Session["bannerAlert"] = "An error occurred while adding a banner!";

                        return RedirectToAction("Index", "banner", new { area = "AdminPanel" });
                    }
                }
               
                else
                {
                    Session["bannerAlert"] = "Please Fill in the Related Fields.";
                    return RedirectToAction("Index", "banner", new { area = "AdminPanel" });
                }
            }
            catch (Exception e)
            {
                Session["bannerAlert"] = e.Message;
                return RedirectToAction("Index", "banner", new {area = "AdminPanel"});
            }



            
        }

        [HttpPost]
        public ActionResult bannerDelete(int id)
        {
            try
            {
                banners bnr=ctx.bannerBll.getOne( id);

                if (bnr!=null)
                {
                    if (System.IO.File.Exists(Server.MapPath(bnr.bannerPath)))
                    {
                        System.IO.File.Delete(Server.MapPath(bnr.bannerPath));

                    }

                    bool resultDeleteBanner = ctx.bannerBll.deleteById(bnr.id);
              
                    if (resultDeleteBanner)
                    {
                        return Json(new { id = 1, message = "Banner is removed." });
                    }
                    else
                    {
                        return Json(new { id = 0, message = "An error occurred while removing a banner !" });
                    }

                }
                else
                {
                    return Json(new { id = 0, message = "The Banner is not found!" });
                }
               
                
            }
            catch (Exception e)
            {
                return Json(new { id = 0, message =e.Message });
            }
        }
    }
}