using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickOrder.Entities.Entities.EntityFramework;
namespace QuickOrder.WebMVC.Models
{
    public class basketModel
    {
        public basketModel()
        {
            this.products = new Dictionary<int, int>();
        }
        public Dictionary<int,int> products { get; set; }

    }
}