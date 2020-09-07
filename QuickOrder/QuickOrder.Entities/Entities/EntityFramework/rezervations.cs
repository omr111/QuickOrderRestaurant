namespace QuickOrder.Entities.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rezervations
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        [StringLength(11)]
        public string phoneNo { get; set; }

        public DateTime rezerveDate { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        public int personCount { get; set; }

        public bool? showed { get; set; }
    }
}
