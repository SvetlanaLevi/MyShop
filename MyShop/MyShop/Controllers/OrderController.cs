using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyShop.API.Models;
using MyShop.API.ModelsInput;
using MyShop.API.ModelsOutput;
using MyShop.Repository;

namespace MyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderController
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async ValueTask<ActionResult<OrderOutputModel>> CreateOrder(OrderInputModel model)
        {
            if (model.ValuteId!="RUB" & model.ValuteId!="UAH" & model.ValuteId != "BYN")
                return BadRequest ("This valute is not supported by our servise");
            var order = OrderMapper.ToDataModel(model);
            order.Valute = ValuteRequest.GetValute(model.ValuteId);
            var result = await _repository.CreateOrder(order);
            if (result.IsOkay)
            {
                return Ok(OrderMapper.ToOutputModel(result.RequestData));
            }
            return Problem($"Request failed {result.ExMessage}", statusCode: 520);
        }


        [HttpGet("{orderId}")]
        public async ValueTask<ActionResult<OrderOutputModel>> GetOrderById(int orderId)
        {
            if (orderId <= 0) return BadRequest("Order id should be more than 0");
            var result = await _repository.OrderGetById(orderId);
            if (result.IsOkay)
            {
                if (result.RequestData == null) return NotFound($"Order not found");
                return Ok(OrderMapper.ToOutputModel(result.RequestData));
            }
            return Problem($"Request failed {result.ExMessage}", statusCode: 520);
        }

        [HttpGet("by-customer/{customerId}")]
        public async ValueTask<ActionResult<List<OrderOutputModel>>> GetOrdersByCustomerId(int customerId)
        {
            if (customerId <= 0) return BadRequest("Customer id should be more than 0");
            var result = await _repository.OrderGetByCustomerId(customerId);
            if (result.IsOkay)
            {
                if (result.RequestData == null) return NotFound($"Orders not found");
                return Ok(OrderMapper.ToOutputModels(result.RequestData));
            }
            return Problem($"Request failed {result.ExMessage}", statusCode: 520);
        }

    }
}