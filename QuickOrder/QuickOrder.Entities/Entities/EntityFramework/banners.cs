namespace QuickOrder.Entities.Entities.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class banners
    {
        public int id { get; set; }

        [Required]
        [StringLength(150)]
        public string bannerPath { get; set; }

        [Required]
        [StringLength(50)]
        public string altName { get; set; }

        [StringLength(200)]
        public string text { get; set; }
    }
}
