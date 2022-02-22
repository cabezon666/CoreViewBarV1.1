using CoreViewBar.Data;
using CoreViewBar.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Migrations
{

    //For seed the DB if the tables are empty.
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                        {

                        new Product()
                        {
                            ProductName = "American Cofee",
                            ProductDescription = "The true american coffee!",
                            ProductImageURL = "img/americanCoffee.jpg",
                            ProductPrice = Convert.ToDecimal(1.5),
                            ProductType = Data.Enum.ProductType.Coffe
                        },
                        new Product()
                        {
                            ProductName = "Italian Cofee",
                            ProductDescription = "Il vero cafè italiano!",
                            ProductImageURL = "img/italianCoffee.jpg",
                            ProductPrice = Convert.ToDecimal(1.2),
                            ProductType = Data.Enum.ProductType.Coffe
                        },
                        new Product()
                        {
                            ProductName = "Chocolate",
                            ProductDescription = "Hot Chocolate drink for warm your life!",
                            ProductImageURL = "img/cioccolatta.jpg",
                            ProductPrice = Convert.ToDecimal(1.0),
                            ProductType = Data.Enum.ProductType.Chocolate
                        },
                        new Product()
                        {
                            ProductName = "Tea",
                            ProductDescription = "Tea 100% green herbs",
                            ProductImageURL = "img/tea.jpg",
                            ProductPrice = Convert.ToDecimal(1.1),
                            ProductType = Data.Enum.ProductType.Tea
                        },
                    });
                    context.SaveChanges();
                }

                if (!context.Coupon4Discounts.Any())
                {
                    context.Coupon4Discounts.AddRange(new List<Coupon4Discount>()
                    {
                        new Coupon4Discount()
                        {
                            Code = "veintecinco",
                            Discount = 0.25,
                            Description = "25%"
                        },
                        new Coupon4Discount()
                        {
                           Code = "cincuenta",
                            Discount = 0.50,
                            Description = "50%"
                        },
                        new Coupon4Discount()
                        {
                            Code = "setentaycinco",
                            Discount = 0.75,
                            Description = "75%"
                        },                       
                    });
                    context.SaveChanges();
                }
            }         
        
        }
    }
}
