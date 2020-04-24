using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.DB.Models
{
    class Order_Product
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Value { get; set; }
        public Valute Valute { get; set; }
        public decimal LocalPrice { get; set; }
    }
}
