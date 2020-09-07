using QuickOrder.Entities.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickOrder.WebMVC.Models
{
    public class contactModel
    {
        public CompanyInformations compInfo { get; set; }
        public reviews reviews { get; set; }


    }
}