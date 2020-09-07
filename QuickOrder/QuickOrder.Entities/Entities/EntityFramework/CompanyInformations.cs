namespace QuickOrder.Entities.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CompanyInformations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyInformations()
        {
            Phones = new HashSet<Phones>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string companyName { get; set; }

        [StringLength(250)]
        public string companyCaption { get; set; }

        public string companyAbout { get; set; }

        [StringLength(150)]
        public string companyLogo { get; set; }

        [StringLength(70)]
        public string email { get; set; }

        [StringLength(250)]
        public string companyAddress { get; set; }

        [StringLength(150)]
        public string companyPicturePath { get; set; }

        [StringLength(250)]
        public string facebookUrl { get; set; }

        [StringLength(250)]
        public string youtubeUrl { get; set; }

        [StringLength(250)]
        public string InstagramUrl { get; set; }

        [StringLength(250)]
        public string twitterUrl { get; set; }

        [StringLength(50)]
        public string emailPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phones> Phones { get; set; }
    }
}
