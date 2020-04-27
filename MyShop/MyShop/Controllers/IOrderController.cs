using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.API.Controllers
{
    interface IOrderController
    {
        public ValueTask<ActionResult<OrderOutputModel>> CreateOrder(OrderInputModel model);
        public ValueTask<ActionResult<OrderOutputModel>> GetOrderById(int orderId);
        public ValueTask<ActionResult<List<OrderOutputModel>>> GetOrdersByCustomerId(int customerId);
    }
}
