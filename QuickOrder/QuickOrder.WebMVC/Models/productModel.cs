using QuickOrder.Entities.Entities.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickOrder.WebMVC.Models
{
    public class productModel
    {
        public IPagedList<Products> products { get; set; }
        public List<Categories> categories { get; set; }
    
        public string name { get; set; }
        public int? page { get; set; }


    }
}