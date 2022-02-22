using CoreViewBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Data.Services
{
    //OrderServices interfaces 
    public interface IOrdersServices
    {
        Task StoreOrdersAsync(List<ShopBag> items, string ShopBagID, DateTimeOffset DateTimeOrder, decimal Discount);        
    }
}
