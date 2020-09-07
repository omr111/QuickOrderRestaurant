using System.Collections.Generic;
using System.Linq;
using QuickOrder.Entities.Entities.EntityFramework;

namespace QuickOrder.WebMVC.Models
{
    public class headerModel
    {
        public List<Categories> Categories { get; set; }
        public List<Products> dailyFoods { get;  set; }
        public CompanyInformations company { get;  set; }
    }
}