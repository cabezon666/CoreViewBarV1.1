using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreViewBar.Models
{
    public class OrderItem
    {        
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public int ProductID { get; set; }[ForeignKey("ProductID")]
        public Product Product { get; set; }
        public int OrderID { get; set; }[ForeignKey("OrderID")]
        public Order Order { get; set; }
        public decimal DiscountApplied { get; set; }
        public decimal FinalPrice { get; set; }

    }

    
}