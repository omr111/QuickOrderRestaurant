using QuickOrder.Entities.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickOrder.WebMVC.Models
{
    public class mainPageFoodMenuModel
    {
        public List<Products> products { get; set; }
        public List<Categories> categories { get; set; }
    }
}