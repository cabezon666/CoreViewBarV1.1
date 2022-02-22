using CoreViewBar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Data.Services
{
    public class OrdersServices : IOrdersServices
    {
        private readonly AppDbContext _context;

        public OrdersServices(AppDbContext context)
        {
            _context = context;
        }

        //Services to fullfill the data of the orders.
        public async Task StoreOrdersAsync(List<ShopBag> items, string ShopBagID, DateTimeOffset DateTimeOrder, decimal Discount)
        {
            var order = new Order()
            {
                ShopBagID = ShopBagID,
                DateTimeOrder = DateTimeOrder
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var _price = item.Product.ProductPrice;
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ProductID = item.Product.ID,
                    Price = _price,
                    OrderID = order.ID,
                    DiscountApplied = Discount,
                    FinalPrice = _price * (1 - Discount)

                };
                await _context.OrderItems.AddAsync(orderItem);            
            }
            await _context.SaveChangesAsync();
        }
    }
}
