using CoreViewBar.Data.Cart;
using CoreViewBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Data.ViewModels
{
    public class ShopBagVM
    {
        public ShopBagMethods ShopBagMethods { get; set; }
        public decimal ShopBagTotal { get; set; }
        public decimal Discount { get; set; }
        public bool isDiscountApplied { get; set; }
    }
}
