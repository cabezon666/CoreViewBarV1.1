using CoreViewBar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Data.Cart
{
    public class ShopBagMethods
    {
        public AppDbContext _context { get; set; }
        public string ShopBagID { get; set; }
        public decimal Discount { get; set; }
        public List<ShopBag> ShopBags { get; set; }
        public List<ShopBag> ShopBagsItems { get; set; }
        public ShopBagMethods(AppDbContext context)
        {
            _context = context;
        }

        //Method from insert the ShopBag into the OrdersController for the S.B. Session.
        public static ShopBagMethods GetShopBag(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string bagId = session.GetString("BagID") ?? Guid.NewGuid().ToString();
            session.SetString("BagID", bagId);           

            return new ShopBagMethods(context) { ShopBagID = bagId};
        }
        //--->
        public void AddProductToShopBag(Product product)
        {
            var shopBagItem = _context.ShopBags.FirstOrDefault(n => n.Product.ID == product.ID
            && n.ShopBagID == ShopBagID);

            if (shopBagItem == null)
            {
                shopBagItem = new ShopBag()
                {
                    ShopBagID = ShopBagID,
                    Product = product,
                    Amount = 1
                };
                _context.ShopBags.Add(shopBagItem);
            }
            else
            {
                shopBagItem.Amount = shopBagItem.Amount +1;            
            }
            _context.SaveChanges();
        }

        public void RemoveProductToShopBag(Product product)
        {
            var shopBagItem = _context.ShopBags.FirstOrDefault(n => n.Product.ID == product.ID
            && n.ShopBagID == ShopBagID);
            if (shopBagItem != null)
            {
                if (shopBagItem.Amount > 1)
                {
                    shopBagItem.Amount = shopBagItem.Amount - 1;
                }
                else {
                    _context.ShopBags.Remove(shopBagItem);//<---OCCHIO!           
                }
            }
            _context.SaveChanges();            
        }

        public List<ShopBag> GetShopBagsItems()
        {
            var items = _context.ShopBags.Where(n => n.ShopBagID == ShopBagID).Include(n => n.Product).ToList();
            return items;
        }

        public decimal GetShopBagsTotal()
        {
            var total = _context.ShopBags.Where(n => n.ShopBagID == ShopBagID).Select(n => n.Product.ProductPrice * n.Amount).Sum();
            return total;
        }

        public async Task ClearShopBagAsync()
        {
            var items = await _context.ShopBags.Where(n => n.ShopBagID == ShopBagID).ToListAsync();
            _context.ShopBags.RemoveRange(items);
            await _context.SaveChangesAsync();
        }

        public async Task GetAllCoupons(string item)
        {
            var couponID = await _context.Coupon4Discounts.Where(c => c.Code == item).Select(c => c.ID).FirstOrDefaultAsync();
            var ShopBagIDFK = await _context.ShopBags.Where(n => n.ShopBagID == ShopBagID).Select(n => n.ID).FirstOrDefaultAsync();
            if (couponID != 0)            {
                var DiscountSB = new DiscountShopBag()
                {
                    ShopBagID = ShopBagIDFK,
                    ShopBagGUID = ShopBagID,
                    Coupon4DiscountID = couponID,
                    isDiscountApplied = true
                };
                _context.DiscountShopBags.Add(DiscountSB);
            }
            _context.SaveChanges();
        }

        public decimal GetDiscountValue()
        {
            var Discount = Convert.ToDecimal(
                _context.DiscountShopBags.Where(c => c.ShopBagGUID == ShopBagID).Select(c => c.Coupon4Discount.Discount).FirstOrDefault());
            return Discount;
        }        
    }


}
