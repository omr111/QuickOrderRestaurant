namespace QuickOrder.Entities.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SaleProducts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SaleProducts()
        {
            SaleProductsDetails = new HashSet<SaleProductsDetails>();
        }

        public int id { get; set; }

        public int customerID { get; set; }

        public decimal totalAmount { get; set; }

        public DateTime date { get; set; }

        public bool? status { get; set; }

        public int? billID { get; set; }

        [StringLength(50)]
        public string payType { get; set; }

        public DateTime? orderDate { get; set; }

        [StringLength(250)]
        public string description { get; set; }

        public Guid? orderCode { get; set; }

        public virtual Bills Bills { get; set; }

        public virtual users users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleProductsDetails> SaleProductsDetails { get; set; }
    }
}
