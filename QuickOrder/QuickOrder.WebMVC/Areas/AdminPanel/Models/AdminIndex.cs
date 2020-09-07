using QuickOrder.Entities.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace QuickOrder.WebMVC.Areas.Models
{
    public class AdminIndex
    {
        public List<users> Users { get; set; }
        public List<users> managementTeam { get; set; }
        public List<Products> Products { get; set; }
    
        public List<rezervations> defaultReservations { get; set; }
        public int newReservationCount { get; set; }
        
    }
}