using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.DB.Models
{
    public class OrderWithItems
    {
        public int? Id { get; set; }
        public int RepId { get; set; }
        public string RepName { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public List<Order_Product> OrderItems { get; set; }
        public Valute Valute { get; set; }
        //public decimal Amount { get; set; }


        public override bool Equals(object obj)
        {
            return obj is Order order &&
                Id == order.Id &&
                //Rep.Id == order.Rep.Id &&
                CustomerId == order.CustomerId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CustomerId);
        }
    }
}
