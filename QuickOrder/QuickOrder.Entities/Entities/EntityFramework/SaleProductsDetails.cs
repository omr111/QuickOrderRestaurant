namespace QuickOrder.Entities.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SaleProductsDetails
    {
        public int id { get; set; }

        public int SaleID { get; set; }

        public int productID { get; set; }

        public int count { get; set; }

        public decimal productPrice { get; set; }

        public decimal tax { get; set; }

        public decimal amount { get; set; }

        public bool? status { get; set; }

        public virtual Products Products { get; set; }

        public virtual SaleProducts SaleProducts { get; set; }
    }
}
