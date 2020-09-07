using QuickOrder.Entities.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace QuickOrder.WebMVC.Areas.Models
{
    public class usersAndRoles
    {
        public List<users> Users { get; set; }
        public List<roles> Roles { get; set; }
    }
}