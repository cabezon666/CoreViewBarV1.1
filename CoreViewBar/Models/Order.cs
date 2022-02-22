using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreViewBar.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public string ShopBagID { get; set; }
        public DateTimeOffset DateTimeOrder { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
