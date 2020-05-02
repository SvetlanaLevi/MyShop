using MyShop.API.ModelsOutput;
using System;
using System.Collections.Generic;

namespace MyShop.API.ModelsOutput
{
    public class OrderWithItemsOutputModel
    {
        public string RepName { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
        public decimal LocalAmount { get; set; }
        public string ValuteId { get; set; }
        public List<OrderItemOutputModel> orderItemOutput { get; set; }

    }

    public class OrderItemOutputModel
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public decimal LocalPrice { get; set; }
        public int Value { get; set; }

    }
}