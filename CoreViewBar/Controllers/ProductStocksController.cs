using CoreViewBar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Controllers
{
    public class ProductStocksController : Controller
    {
        private readonly AppDbContext _context;


        public ProductStocksController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Products.ToListAsync();
            return View();
        }
    }
}
