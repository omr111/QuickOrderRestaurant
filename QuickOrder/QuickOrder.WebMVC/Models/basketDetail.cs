using QuickOrder.Entities.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickOrder.WebMVC.Models
{
    public class basketDetail
    {
        public Products product { get; set; }
        public int count { get; set; }
    

    }
}