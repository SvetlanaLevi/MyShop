using System;

namespace MyShop.DB.Models
{
    public class OrdersInfo
    {
        public string City { get; set; }
        public string Model { get; set; }
        public int Value { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
