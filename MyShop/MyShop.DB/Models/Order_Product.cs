using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.DB.Models
{
    public class Order_Product
    {
        public int? Id { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Value { get; set; }
        public Valute Valute { get; set; }
        public decimal LocalPrice { get; set; }
        public override bool Equals(object obj)
        {
            return obj is Order_Product orderProduct &&
                Id == orderProduct.Id &&
                Product.Id == orderProduct.Product.Id &&
                Order.Id == orderProduct.Order.Id &&
                Value == orderProduct.Value &&
                Valute.Id == orderProduct.Valute.Id &&
                LocalPrice == orderProduct.LocalPrice;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Product.Id, Order.Id, Value, Valute.Id, LocalPrice);
        }

    }

}
