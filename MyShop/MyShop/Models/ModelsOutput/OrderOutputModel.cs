using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.API.ModelsOutput
{
    public class OrderOutputModel
    {
        public int? Id { get; set; }
        public string RepName { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
        public int CustomerId { get; set; }
    }
}
