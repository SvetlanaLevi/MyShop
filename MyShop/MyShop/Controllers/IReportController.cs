using Microsoft.AspNetCore.Mvc;
using MyShop.API.ModelsInput;
using MyShop.API.ModelsOutput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.API.Controllers
{
    public interface IReportController
    {
        public ValueTask<ActionResult<CategoryWithCountOutputModel>> GetCategoriesWithCountProductMoreThan(int count);
        public ValueTask<ActionResult<OrdersInfoOutputModel>> GetOrdersInfo(OrdersInfoInputModel model);
        public ValueTask<ActionResult<List<ProductOutputModel>>> GetProductsNeverOrdered();
        public ValueTask<ActionResult<List<ProductOutputModel>>> GetProductsOnlyInDtorage();
        public ValueTask<ActionResult<List<ProductOutputModel>>> GetProductsOutOfStock();
        public ValueTask<ActionResult<decimal>> GetTotalMoneyInCity(int cityId);
        public ValueTask<ActionResult<decimal>> GetTotalMoneyInStorage(int storageId);

    }
}
