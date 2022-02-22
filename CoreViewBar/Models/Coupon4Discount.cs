using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Models
{
    public class Coupon4Discount
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public double Discount { get; set; }
        public string Description { get; set; }

    }
}
