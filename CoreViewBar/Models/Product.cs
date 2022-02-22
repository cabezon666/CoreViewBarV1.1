using CoreViewBar.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string ProductImageURL { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public ProductType ProductType { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
