using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyShop.API.ModelsInput;
using MyShop.DB.Storages;
using MyShop.Repository;

namespace MyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderController
    {
        private readonly OrderRepository _repository;
        private readonly OrderStorage _storage;

        public OrderController(IConfiguration configuration)
        {
            string dbCon = configuration.GetConnectionString("DefaultConnection");
            _storage = new OrderStorage(dbCon);
            _repository = new OrderRepository(_storage);
        }

        [HttpPost]
        public async ValueTask<ActionResult<OrderOutputModel>> CreateOrder(OrderInputModel model)
        {
            string URI = "https://www.cbr-xml-daily.ru/daily_json.js";
            var result = SendRequest.SendingRequest(URI);
            //return JsonSerializer.Deserialize<List<TransactionEntityOutputModel>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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

        [HttpGet("test")]
        public Valute Valute()
        {
            string URI = "https://www.cbr-xml-daily.ru/daily_json.js";
            var result = SendRequest.SendingRequest(URI);
            var data = JsonSerializer.Deserialize<Valute>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = false });
            return data;

        }
    }
}