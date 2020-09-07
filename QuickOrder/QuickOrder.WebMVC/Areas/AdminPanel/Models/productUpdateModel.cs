using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickOrder.Entities.Entities.EntityFramework;


namespace QuickOrder.WebMVC.Areas.Models
{
    public class productUpdateModel
    {
        public Products Product { get; set; }
        public List<Categories> Categories { get; set; }
    }
}