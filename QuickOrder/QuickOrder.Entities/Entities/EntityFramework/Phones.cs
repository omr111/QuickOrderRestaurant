namespace QuickOrder.Entities.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Phones
    {
        public int id { get; set; }

        public int CompanyID { get; set; }

        [Required]
        [StringLength(15)]
        public string phoneNumber { get; set; }

        public virtual CompanyInformations CompanyInformations { get; set; }
    }
}
