using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyShop.API.ModelsInput;
using MyShop.API.ModelsOutput;
using MyShop.DB.Models;
using MyShop.Repository;

namespace MyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase, IReportController
    {

        private readonly IReportRepository _repository;
        private readonly IMapper _mapper;

        public ReportController(IReportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //вывести категории, в которых заведено n и более товаров
        [HttpGet("Category/HasMoreProductsThan/{count}")]
        public async ValueTask<ActionResult<List<CategoryWithCountOutputModel>>> GetCategoriesWithCountProductMoreThan(int count)
        {
            if (count < 0) return BadRequest("Count shuld be positive");
            var result = await _repository.GetCategoryProductCount(count);            
            if (result.IsOkay)
            {
                if (result.RequestData == null) return NotFound($"Categories not found");
                return Ok(_mapper.Map<List<CategoryWithCountOutputModel>>(result.RequestData));
            }
            return Problem($"Request failed {result.ExMessage}", statusCode: 520);
        }

        //вывести информацию о заказах
        [HttpGet("OrdersInfo")]
        public async ValueTask<ActionResult<List<OrdersInfoOutputModel>>> GetOrdersInfo(OrdersInfoInputModel model)
        {
            if (model.StartDate==null& model.EndDate == null) { return BadRequest("Wrong time format"); }
            var result = await _repository.GetOrdersInfo(_mapper.Map<OrdersInfo>(model));
            if (result.IsOkay)
            {
                if (result.RequestData == null) return NotFound($"Orders not found");
                return Ok(_mapper.Map<List<OrdersInfoOutputModel>>(result.RequestData));
            }
            return Problem($"Request failed {result.ExMessage}", statusCode: 520);
        }


        [HttpGet("Money/AmountInCity/{cityId}")]
        public async ValueTask<ActionResult<decimal>> GetTotalMoneyInCity(int cityId)
        {
            var result = await _repository.GetTotalMoneyInCity(cityId);
            if (result.IsOkay)
            {
                return Ok($"Amount: {result.RequestData}");
            }
            return Problem($"Request failed {result.ExMessage}", statusCode: 520);
        }


        [HttpGet("Product/NeverOrdered")]
        public async ValueTask<ActionResult<List<ProductOutputModel>>> GetProductsNeverOrdered()
        {
            var result = await _repository.GetProductsNeverOrdered();
            if (result.IsOkay)
            {
                if (result.RequestData == null) return NotFound($"Products not found");
                return Ok(_mapper.Map<List<ProductOutputModel>>(result.RequestData));
            }
            return Problem($"Request failed {result.ExMessage}", statusCode: 520);
        }


        //товары есть на Складе, но при этом отсутствуют в городе.
        [HttpGet("Product/OnlyInStorage")]
        public async ValueTask<ActionResult<List<ProductOutputModel>>> GetProductsOnlyInStorage(int cityId)
        {
            var result = await _repository.GetProductsOnlyInStorage(cityId);
            if (result.IsOkay)
            {
                if (result.RequestData == null) return NotFound($"Products not found");
                return Ok(_mapper.Map<List<ProductOutputModel>>(result.RequestData));
            }
            return Problem($"Request failed {result.ExMessage}", statusCode: 520);
        }


        //товары, по которым были продажи, но которых нет ни в представительствах, ни на Складе
        [HttpGet("Product/OutOfStock")]
        public async ValueTask<ActionResult<List<ProductOutputModel>>> GetProductsOutOfStock()
        {
            var result = await _repository.GetProductsOutOfStock();
            if (result.IsOkay)
            {
                if (result.RequestData == null) return NotFound($"Products not found");
                return Ok(_mapper.Map<List<ProductOutputModel>>(result.RequestData));
            }
            return Problem($"Request failed {result.ExMessage}", statusCode: 520);
        }
    }
}