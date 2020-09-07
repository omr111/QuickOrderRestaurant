using QuickOrder.Entities.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickOrder.WebMVC.Models
{
    public class homeModel
    {
        public List<Products> products { get; set; }
        public mainPageFoodMenuModel mainPageFood { get; set; }       
        public List<services> services { get; set; }
        public List<reviews> customerReviews { get; set; }
        public CompanyInformations about { get; set; }
        

    }
}