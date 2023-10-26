using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.UnitOfWork.Abstract;
using QuickOrder.WebMVC.App_Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuickOrder.WebMVC.Controllers
{
    public class usersController : Controller
    {
        IUnitOfWork ctx;
        public usersController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }
        // GET: users
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(users usr)
        {
            users user = ctx.userBll.getOneByEmailAndPassword( usr.email ,usr.password);
            if (user != null)
            {

                FormsAuthentication.SetAuthCookie(usr.email, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["logInError"] = "Şifre ya da Kullanıcı Adı Hatalı !";
                return RedirectToAction("login", "users");
            }

        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "users");
        }

        [HttpPost]       
        public ActionResult register(users usr, HttpPostedFileBase file)
        {
            try
            {
               
                    users checkNick = ctx.userBll.getOneByEmail(usr.email);
                    if (checkNick == null)
                    {
                        if (file != null)
                        {

                            int iconWidth = settings.userPicture.Width;
                            int iconHeight = settings.userPicture.Height;
                            
                            string newName = Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName);
                            Image orjResim = Image.FromStream(file.InputStream);
                            Bitmap iconDraw = new Bitmap(orjResim, iconWidth, iconHeight);
                          
                            iconDraw.Save(Server.MapPath("~/content/img/userPictures/" + newName));

                            string saveDBPath = "/content/img/userPictures/" + newName;
                            usr.userPicturePath = saveDBPath;
                        }


                        bool result = ctx.userBll.add(usr);
                        if (result)
                        {
                            
                            roleOfUsers giveRoleOfUser = new roleOfUsers();
                            giveRoleOfUser.roleID = 6;//customer
                            giveRoleOfUser.userID = usr.id;
                            ctx.roleOfUserBll.add(giveRoleOfUser);
                       
                         

                        }
                        else
                        {
                            ViewData["userError"] = "Bir Hata Oluştu.Lütfen Tekrar Deneyin!";

                            return RedirectToAction("login", "users");
                        }

                    }
                    else
                    {
                        ViewData["userError"] = "Bu Email Adresi Zaten Kullanımda!";

                        return RedirectToAction("login", "users");
                    }
            

                return RedirectToAction("login", "users");

            }
            catch (Exception e)
            {

                ViewData["userError"] = e.Message.ToString();

                return View("login");
            }
        }
    }
}