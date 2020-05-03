using Microsoft.AspNetCore.Mvc;
using MyShop.API.ModelsInput;
using MyShop.API.ModelsOutput;
using System.Collections.Generic;
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
