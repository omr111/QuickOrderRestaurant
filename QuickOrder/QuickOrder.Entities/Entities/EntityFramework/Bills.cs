namespace QuickOrder.Entities.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bills
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bills()
        {
            SaleProducts = new HashSet<SaleProducts>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string surname { get; set; }

        [StringLength(12)]
        public string phone { get; set; }

        public DateTime billDate { get; set; }

        public decimal totalPrice { get; set; }

        public bool? status { get; set; }

        [StringLength(50)]
        public string payType { get; set; }

        [StringLength(250)]
        public string description { get; set; }

        public DateTime? orderDate { get; set; }

        public Guid? orderCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleProducts> SaleProducts { get; set; }
    }
}
