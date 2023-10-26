
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using QuickOrder.WebMVC.App_Classes;
using System.Drawing.Drawing2D;

namespace QuickOrder.WebMVC.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class pictureController : Controller
    {
        // GET: AdminPanel/picture
        public ActionResult Index()
        {
            return View();
        }

        public static string IconAddForService(HttpPostedFileBase file, HttpContextBase context)
        {

            int iconWidth = settings.serviceIconSize.Width;
            int iconHeight = settings.serviceIconSize.Height;
            string newName = "";
            if (file.FileName.Length > 10)
            {

                newName = Path.GetFileNameWithoutExtension(file.FileName.Substring(0, 10)) + Guid.NewGuid() + Path.GetExtension(file.FileName);
            }
            else
            {
                newName = Path.GetFileNameWithoutExtension(file.FileName) + Guid.NewGuid() + Path.GetExtension(file.FileName);
            }

            Image orjResim = Image.FromStream(file.InputStream);
            Bitmap iconDraw = new Bitmap(orjResim, iconWidth, iconHeight);

            iconDraw.Save(context.Server.MapPath("~/content/img/serviceIcon/" + newName));

            string saveDBPath = "/content/img/serviceIcon/" + newName;
            return saveDBPath;


        }
 
        public static string pictureAddForProduct(HttpPostedFileBase file, HttpContextBase context)
        {

            int picSmallWidth = settings.productPictureSize.Width;
            int picSmallHeight = settings.productPictureSize.Height;

            string newName = "";
            if (file.FileName.Length > 10)
            {

                newName = Path.GetFileNameWithoutExtension(file.FileName.Substring(0, 10)) + Guid.NewGuid() + Path.GetExtension(file.FileName);
            }
            else
            {
                newName = Path.GetFileNameWithoutExtension(file.FileName) + Guid.NewGuid() + Path.GetExtension(file.FileName);
            }

            Image orjResim = Image.FromStream(file.InputStream);
            Bitmap pictureSmallDraw = new Bitmap(orjResim, picSmallWidth, picSmallHeight);

            pictureSmallDraw.Save(context.Server.MapPath("~/content/img/productPicture/menuPicture/" + newName));

            string saveDBPath = "/content/img/productPicture/menuPicture/" + newName;
            return saveDBPath;




        }
        public static string pictureAddForBranch(HttpPostedFileBase file, HttpContextBase context)
        {
           
            int picSmallWidth = settings.BranchSmallSize.Width;
            int picSmallHeight = settings.BranchSmallSize.Height;

            string newName = "";
            if (file.FileName.Length > 10)
            {

                newName = Path.GetFileNameWithoutExtension(file.FileName.Substring(0, 10)) + Guid.NewGuid() + Path.GetExtension(file.FileName);
            }
            else
            {
                newName = Path.GetFileNameWithoutExtension(file.FileName) + Guid.NewGuid() + Path.GetExtension(file.FileName);
            }

            Image orjResim = Image.FromStream(file.InputStream);
            Bitmap pictureSmallDraw = new Bitmap(orjResim, picSmallWidth, picSmallHeight);
           
            pictureSmallDraw.Save(context.Server.MapPath("~/content/img/branchPicture/" + newName));
           
            string saveDBPath = "/content/img/branchPicture/" + newName;
            return saveDBPath;


        }
    }
}