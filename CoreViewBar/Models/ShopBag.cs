using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Models
{
    public class ShopBag
    {
        [Key]
        public int ID { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Amount { get; set; }
        public string ShopBagID { get; set; }
        public DiscountShopBag DiscountShopBags { get; set; }

    }
}
