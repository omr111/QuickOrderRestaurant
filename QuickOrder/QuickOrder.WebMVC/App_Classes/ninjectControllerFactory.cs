using Ninject;
using QuickOrder.UnitOfWork.Abstract;
using QuickOrder.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuickOrder.WebMVC.App_Classes
{
    public class ninjectControllerFactory:DefaultControllerFactory
    {
        readonly IKernel kernel;
        public ninjectControllerFactory()
        {
            kernel = new StandardKernel();
            addBindUnitOfWork();
        }

        private void addBindUnitOfWork()
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork.Concrete.UnitOfWork>();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }
    }
}