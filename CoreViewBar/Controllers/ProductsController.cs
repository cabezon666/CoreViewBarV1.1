using CoreViewBar.Data;
using CoreViewBar.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;


        public ProductsController(IProductsService service)
        {
            _service = service; 

        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }
        
        //Get: Products/Create

        public IActionResult Create()
        {
            return View();
        
        }
    }
}
