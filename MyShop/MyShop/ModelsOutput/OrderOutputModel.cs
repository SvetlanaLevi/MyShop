using MyShop.API.ModelsOutput;
using System;

namespace MyShop.API.ModelsOutput
{
    public class OrderOutputModel
    {
        public int OrderId { get; set; }
        public string RepName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentValute { get; set; }
        public OrderItemOutputModel[] orderItemOutput { get; set; }

    }

    public class OrderItemOutputModel
    {
        public ProductOutputModel[] Products { get; set; }
        public int Value { get; set; }

    }
}