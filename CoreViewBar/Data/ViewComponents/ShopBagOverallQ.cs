using CoreViewBar.Data.Cart;
using CoreViewBar.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Data.ViewComponents
{
    public class ShopBagOverallQ : ViewComponent
    {
        private readonly ShopBagMethods _shopBag;

        public ShopBagOverallQ(ShopBagMethods shopBag)
        {
            _shopBag = shopBag;
        }

        //This VC is for return the number of single products on the bag 
        public IViewComponentResult Invoke()
        {
            var QonShopBag = _shopBag.GetShopBagsItems();            
            return View(QonShopBag.Count);
        }

    }
}
