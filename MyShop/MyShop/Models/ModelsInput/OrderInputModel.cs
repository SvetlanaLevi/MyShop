using MyShop.DB.Models;
using System.Collections.Generic;

namespace MyShop.API.ModelsInput

{
    public class OrderInputModel
    {
        public int RepId { get; set; }
        public int CustomerId { get; set; }
        public OrderItem[] OrderItems { get; set; }
        public string ValuteId { get; set; }

    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public int Value { get; set; }
    }
}