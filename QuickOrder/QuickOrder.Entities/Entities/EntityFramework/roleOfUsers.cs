namespace QuickOrder.Entities.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class roleOfUsers
    {
        public int id { get; set; }

        public int userID { get; set; }

        public int roleID { get; set; }

        public virtual roles roles { get; set; }

        public virtual users users { get; set; }
    }
}
