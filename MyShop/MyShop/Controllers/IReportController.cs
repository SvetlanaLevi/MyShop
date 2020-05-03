using Microsoft.AspNetCore.Mvc;
using MyShop.API.ModelsInput;
using MyShop.API.ModelsOutput;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyShop.API.Controllers
{
    public interface IReportController
    {
        public ValueTask<ActionResult<List<CategoryWithCountOutputModel>>> GetCategoriesWithCountProductMoreThan(int count);
        public ValueTask<ActionResult<List<OrdersInfoOutputModel>>> GetOrdersInfo(OrdersInfoInputModel model);
        public ValueTask<ActionResult<List<ProductOutputModel>>> GetProductsNeverOrdered();
        public ValueTask<ActionResult<List<ProductOutputModel>>> GetProductsOnlyInStorage(int cityId);
        public ValueTask<ActionResult<List<ProductOutputModel>>> GetProductsOutOfStock();
        public ValueTask<ActionResult<decimal>> GetTotalMoneyInCity(int cityId);
    }
}
