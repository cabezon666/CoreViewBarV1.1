using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Models
{
    public class DiscountShopBag
    {
        [Key]
        public int ID { get; set; }
        public int ShopBagID { get; set; }[ForeignKey("ShopBagID")]
        public ShopBag ShopBag { get; set; }
        public int Coupon4DiscountID { get; set; }
        public Coupon4Discount Coupon4Discount { get; set; }
        public string ShopBagGUID { get; set; }
        public bool isDiscountApplied { get; set; } = false;

    }
}
