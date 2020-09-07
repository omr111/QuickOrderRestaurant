namespace QuickOrder.Entities.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class services
    {
        public int id { get; set; }

        [StringLength(150)]
        public string serviceIcon { get; set; }

        [Required]
        [StringLength(100)]
        public string serviceName { get; set; }

        [Required]
        [StringLength(250)]
        public string serviceInfo { get; set; }
    }
}
