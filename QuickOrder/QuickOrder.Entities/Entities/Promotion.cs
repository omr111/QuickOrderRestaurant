using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickOrder.Entities.Entities
{
    public partial class Promotion
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string PromotionKey { get; set; }
        public DateTime Endate { get; set; }
        public double DiscountRate { get; set; }
    }
}
