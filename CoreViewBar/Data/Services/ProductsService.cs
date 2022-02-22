using CoreViewBar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Data.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AppDbContext _context;

        public ProductsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var result = await _context.Products.ToListAsync();
            return result;            
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products
                //.Include(pn => pn.ProductName)
                //.Include(pp => pp.ProductPrice)                
                .FirstOrDefaultAsync(n => n.ID == id);
            return productDetails;
        }
    }
}
