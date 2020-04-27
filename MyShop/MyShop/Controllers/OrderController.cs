using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderController
    {
        [HttpPost]
        public ValueTask<ActionResult<OrderOutputModel>> CreateOrder(OrderInputModel model)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{orderId}")]
        public ValueTask<ActionResult<OrderOutputModel>> GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("by-customer/{customerId}")]
        public ValueTask<ActionResult<List<OrderOutputModel>>> GetOrdersByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}