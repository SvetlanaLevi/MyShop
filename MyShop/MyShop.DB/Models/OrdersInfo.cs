using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.DB.Models
{
    public class OrdersInfo
    {
        public string City { get; set; }
        public string Product { get; set; }
        public int Value { get; set; }
        public decimal Price { get; set; }
    }
}
