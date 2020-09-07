namespace QuickOrder.Entities.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class reviews
    {
        public int id { get; set; }

        [Required]
        public string comment { get; set; }

        public int? userID { get; set; }

        [StringLength(50)]
        public string visitorName { get; set; }

        [StringLength(50)]
        public string visitorSurname { get; set; }

        [Required]
        [StringLength(70)]
        public string email { get; set; }

        [Required]
        [StringLength(100)]
        public string subject { get; set; }

        public virtual users users { get; set; }
    }
}
