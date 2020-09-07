using QuickOrder.Entities.Entities.EntityFramework;
using QuickOrder.WebMVC.App_Classes;
using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuickOrder.WebMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Database.SetInitializer<QuickOrderContext>(new DropCreateDatabaseIfModelChanges<QuickOrderContext>());
        }
        void Session_Start(object sender, EventArgs e)
        {
            ControllerBuilder.Current.SetControllerFactory(new ninjectControllerFactory());
            if (Application["visitor"] == null)
            {
                int online = 1;
                Application["visitor"] = online;
            }
            else
            {
                int online = (int)Application["visitor"];
                online++;

                Application["visitor"] = online;
            }

        }

        void Session_End(object sender, EventArgs e)
        {
            int online = (int)Application["visitor"];
            online--;
            Application["visitor"] = online;
        }
    }
}
