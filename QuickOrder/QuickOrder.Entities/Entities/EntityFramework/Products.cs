namespace QuickOrder.Entities.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            SaleProductsDetails = new HashSet<SaleProductsDetails>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(150)]
        public string caption { get; set; }

        public string description { get; set; }

        [StringLength(150)]
        public string coverPicturePath { get; set; }

        [StringLength(50)]
        public string pictureAlt { get; set; }

        public int categoryID { get; set; }

        public int? pictureID { get; set; }

        public decimal? price { get; set; }

        public virtual Categories Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleProductsDetails> SaleProductsDetails { get; set; }
    }
}
