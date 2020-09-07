using System;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.IO;
using Image = System.Drawing.Image;
using QuickOrder.Entities.Entities.EntityFramework;
using System.Linq;
using QuickOrder.WebMVC.App_Classes;
using System.Data.Entity.Migrations;
using QuickOrder.UnitOfWork.Abstract;

namespace QuickOrder.WebMVC.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class CompanyController : Controller
    {
        IUnitOfWork ctx;
        public CompanyController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }

        // GET: AdminPanel/Company
        public ActionResult Index()
        {
            CompanyInformations company = ctx.companyInformationBll.getOne(2);


            return View(company);
        }
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult companyEdit(CompanyInformations comInfo, HttpPostedFileBase companyLogo, HttpPostedFileBase companyPicturePath)
        {
            CompanyInformations company = ctx.companyInformationBll.getOne(2);


            try
            {
                if (ModelState.IsValid)
                {
                    if (companyPicturePath != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(company.companyPicturePath)))
                        {
                            FileStream fs = new FileStream(Server.MapPath(company.companyPicturePath), FileMode.OpenOrCreate);

                            fs.Flush();
                            fs.Close();

                            System.IO.File.Delete(Server.MapPath(company.companyPicturePath));

                        }

                        int companyPictureWidth = settings.companyPicture.Width;
                        int companyPictureHeight = settings.companyPicture.Height;
                        string newName = Path.GetFileNameWithoutExtension(companyPicturePath.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(companyPicturePath.FileName);

                        Image orjCompany = Image.FromStream(companyPicturePath.InputStream);
                        Bitmap companyPicturDraw = new Bitmap(orjCompany, companyPictureHeight, companyPictureWidth);
                        companyPicturDraw.Save(Server.MapPath("~/content/img/companyPicture/" + newName));

                        company.companyPicturePath = "/content/img/companyPicture/" + newName;

                    }

                    if (companyLogo != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(company.companyLogo)))
                        {

                            System.IO.File.Delete(Server.MapPath(company.companyLogo));

                        }

                        int companyLogoWidth = settings.companyLogo.Width;
                        int companyLogoHeight = settings.companyLogo.Height;
                        string newName = Path.GetFileNameWithoutExtension(companyLogo.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(companyLogo.FileName);
                        Image orjResim = Image.FromStream(companyLogo.InputStream);
                        Bitmap companyLogoDraw = new Bitmap(orjResim, companyLogoWidth, companyLogoHeight);
                        companyLogoDraw.Save(Server.MapPath("~/content/img/logo/" + newName));

                        company.companyLogo = "/content/img/logo/" + newName;
                    }
                    company.companyAbout = comInfo.companyAbout;
                    company.companyCaption = comInfo.companyCaption;
                    company.companyAddress = comInfo.companyAddress;
                    company.companyName = comInfo.companyName;
                    company.email = comInfo.email;
                   
                    company.InstagramUrl = comInfo.InstagramUrl;
                    company.facebookUrl = comInfo.facebookUrl;
                    company.youtubeUrl = comInfo.youtubeUrl;
                    company.twitterUrl = comInfo.twitterUrl;
                    if (comInfo.emailPassword != "")
                    {
                        company.emailPassword = comInfo.emailPassword;
                    }



                    bool result = ctx.companyInformationBll.add(company);
            
                   
                    if (result )
                    {
                        return RedirectToAction("Index", "Company", new { area = "AdminPanel" });
                    }
                    return RedirectToAction("Index", "Company", new { area = "AdminPanel" });
                }
                else
                {
                    return View("Index", company);
                }


            }
            catch (Exception e)
            {

                return View("Index");
            }


        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public string phoneAdd(int companyId, string selectedPhone)
        {

            Phones phone;
            phone = ctx.phoneBll.getOneByNumberAndCompanyId(selectedPhone, companyId);

            if (phone == null && selectedPhone.Trim() != "")
            {
                phone = new Phones();
                phone.CompanyID = companyId;
                phone.phoneNumber = selectedPhone;
                bool result = ctx.phoneBll.add(phone);
   
                if (result )
                {
                    return selectedPhone;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }

        }

        [HttpPost]
        public JsonResult phoneDelete(int companyId, string selectedPhone)
        {
            Phones phone = ctx.phoneBll.getOneByNumberAndCompanyId(selectedPhone, companyId);
            if (phone != null && selectedPhone.Trim() != "")
            {
                bool resultDelete = ctx.phoneBll.deleteById(phone.id);
             
                if (resultDelete)
                {

                    return Json(data: 1);
                }
                else
                {
                    return Json(data: 0);
                }
            }
            return Json(data: 0);
        }
    }
}