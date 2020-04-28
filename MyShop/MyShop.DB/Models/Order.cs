using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.DB.Models
{
    public class Order
    {
        public int? Id { get; set; }
        public Representative Rep { get; set; }
        public DateTime? OrderDate { get; set; }
        public int CustomerId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                Id == order.Id &&
                Rep.Id == order.Rep.Id &&
                CustomerId == order.CustomerId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Rep.Id, CustomerId);
        }

    }
}
