using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace QuickOrder.WebMVC.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class serviceController : Controller
    {

        IUnitOfWork ctx;
        public serviceController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }
        // GET: AdminPanel/service
        public ActionResult Index()
        {

            return View(ctx.serviceBll.getAll()==null?new List<services>():ctx.serviceBll.getAll());
        }

        public ActionResult serviceAdd()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult serviceAdd(services srv, HttpPostedFileBase file)
        {
           
            if (ModelState.IsValid)
            {
                if (file!=null)
                {
                    srv.serviceIcon = pictureController.IconAddForService(file, HttpContext);
                }
         

                ctx.serviceBll.add(srv);
        
                return RedirectToAction("Index", "service", new { area = "AdminPanel" });
            }
            else
            {
                return View("serviceAdd");
            }
        }
        [HttpPost]
        public int serviceDelete(int id)
        {

            services service = ctx.serviceBll.getOne( id);

            if (service != null)
            {


                if (System.IO.File.Exists(Server.MapPath(service.serviceIcon)))
                {
                    System.IO.File.Delete(Server.MapPath(service.serviceIcon));

                }
                bool resultDelete = ctx.serviceBll.deleteById(service.id);

                
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

        public ActionResult serviceUpdate(int id)
        {
            services service = ctx.serviceBll.getOne(id);

            if (service != null)
            {

                return View(service);
            }
            else
            {
                TempData["serviceUpdateError"] = "The service is not found !";
                return RedirectToAction("Index", "service", new { area = "AdminPanel" });
            }


        }
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult serviceUpdate(services svr, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    services service = ctx.serviceBll.getOne(svr.id);
                    if (service != null)
                    {
                        if (file != null)
                        {
                            if (System.IO.File.Exists(Server.MapPath(service.serviceIcon)))
                            {
                                System.IO.File.Delete(Server.MapPath(service.serviceIcon));

                            }

                            service.serviceIcon = pictureController.IconAddForService(file, HttpContext);
                     
                        }

                        service.serviceName = svr.serviceName;
                        service.serviceInfo = svr.serviceInfo;

                        bool resultUpdate = ctx.serviceBll.add(service);
                    
                        
                        if (resultUpdate)
                        {
                            return RedirectToAction("Index", "service", new { area = "AdminPanel" });
                        }
                        else
                        {
                            TempData["serviceUpdateError"] = "The service is not updated. Please try again";

                            return View();
                        }

                    }
                    else
                    {
                        TempData["serviceUpdateError"] = "The service is not found!";

                        return View();
                    }

                }
                else
                {
                    TempData["serviceUpdateError"] = "Please fill with valid values !";

                    return View();
                }

            }
            catch (Exception e)
            {
                TempData["serviceUpdateError"] = e.Message;

                return View();
            }
        }
    }
}