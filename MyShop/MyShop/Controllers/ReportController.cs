﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyShop.API.ModelsInput;
using MyShop.API.ModelsOutput;
using MyShop.Repository;

namespace MyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase, IReportController
    {

        //private readonly ReportRepository _repository;
        //private readonly ReportStorage _storage;

        public ReportController(IConfiguration configuration)
        {
            string dbCon = configuration.GetConnectionString("DefaultConnection");
            //_storage = new ReportStorage(dbCon);
            //_repository = new OrderRepository(_storage);
        }
        //вывести категории, в которых заведено n и более товаров
        [HttpGet("CategoriesWithMoreProductThan/{count}")]
        public ValueTask<ActionResult<CategoryWithCountOutputModel>> GetCategoriesWithCountProductMoreThan(int count)
        {
            throw new NotImplementedException();
        }


        [HttpGet("OrdersInfo")]
        public ValueTask<ActionResult<OrdersInfoOutputModel>> GetOrdersInfo(OrdersInfoInputModel model)
        {
            throw new NotImplementedException();
        }


        [HttpGet("TotalMoneyInCity/{cityId}")]
        public ValueTask<ActionResult<decimal>> GetTotalMoneyInCity(int cityId)
        {
            throw new NotImplementedException();
        }


        [HttpGet("TotalMoneyInStorage/{storageId}")]
        public ValueTask<ActionResult<decimal>> GetTotalMoneyInStorage(int storageId)
        {
            throw new NotImplementedException();
        }


        [HttpGet("ProductsNeverOrdered")]
        public ValueTask<ActionResult<List<ProductOutputModel>>> GetProductsNeverOrdered()
        {
            throw new NotImplementedException();
        }


        [HttpGet("ProductsOnlyInDtorage")]
        public ValueTask<ActionResult<List<ProductOutputModel>>> GetProductsOnlyInDtorage()
        {
            throw new NotImplementedException();
        }


        [HttpGet("ProductsOutOfStock")]
        public ValueTask<ActionResult<List<ProductOutputModel>>> GetProductsOutOfStock()
        {
            throw new NotImplementedException();
        }
    }
}