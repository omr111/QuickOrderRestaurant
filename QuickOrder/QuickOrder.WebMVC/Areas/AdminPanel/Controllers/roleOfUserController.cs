using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace QuickOrder.WebMVC.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class roleOfUserController : Controller
    {
        IUnitOfWork ctx;
        public roleOfUserController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }

        // GET: AdminPanel/roleOfUser
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult roleDismiss(int roleId,int userId)
        {
            try
            {
                roleOfUsers roleOfUser= ctx.roleOfUserBll.getOneByRoleIdAndUserId(roleId ,userId);
                
                if (roleOfUser!=null)
                {
                    bool result = ctx.roleOfUserBll.deleteById(roleOfUser.id);
                 
                    if (result)
                    {
                        roleOfUsers isHave = ctx.roleOfUserBll.getOneByUserId( userId);
                        if (isHave == null)
                        {
                            roleOfUsers roleOfUsr = new roleOfUsers();
                            roleOfUsr.roleID = 6;//customer
                            roleOfUsr.userID = userId;
                            ctx.roleOfUserBll.add(roleOfUsr);
                           
                        }
                        return Json(data: 1);
                    }
                    else
                    {
                        return Json(data: 0);
                    }
                }
                else
                {
                    return Json(data: 0);
                }
            }
            catch (Exception e)
            {
                return Json(data: 0);
            }

           
        }
        [HttpPost]
        public ActionResult giveRole(int userId, int roleId)
        {
            try
            {
                roleOfUsers role=new roleOfUsers();
                role.roleID = roleId;
                role.userID = userId;
                roleOfUsers isThere= ctx.roleOfUserBll.getOneByRoleIdAndUserId( roleId ,userId);
                if (isThere==null)
                {
                    bool result = ctx.roleOfUserBll.add(role);
                 
                    if (result)
                    {
                        return Json(data: 1);
                    }
                    else
                    {
                        return Json(data: 0); 
                    }
                }
                else
                {
                    return Json(data: 0);
                }
            }
            catch (Exception e)
            {
                return Json(data: 0);
            }

        }
    }
}