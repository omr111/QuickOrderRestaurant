using QuickOrder.Entities.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickOrder.WebMVC.Models
{
    public class productDetail
    {
        public Products singleProduct { get; set; }
        public List<Products> relatedProducts { get; set; }

    }
}