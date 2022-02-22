using CoreViewBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Data.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetProductByIdAsync(int id);
    }
}
