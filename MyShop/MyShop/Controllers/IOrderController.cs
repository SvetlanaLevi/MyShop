using Microsoft.AspNetCore.Mvc;
using MyShop.API.ModelsInput;
using MyShop.API.ModelsOutput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.API.Controllers
{
    interface IOrderController
    {
        public ValueTask<ActionResult<OrderWithItemsOutputModel>> CreateOrder(OrderInputModel model);
        public ValueTask<ActionResult<OrderWithItemsOutputModel>> GetOrderById(int orderId);
        public ValueTask<ActionResult<List<OrderOutputModel>>> GetOrdersByCustomerId(int customerId);
    }
}
