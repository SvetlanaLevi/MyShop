using MyShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Repository
{
    public interface IReportRepository
    {
        public ValueTask<RequestResult<List<CategoryWithCount>>> GetCategoryProductCount(int count);
        public ValueTask<RequestResult<List<Product>>> GetProductsNeverOrdered();
        public ValueTask<RequestResult<List<Product>>> GetProductsOnlyInStorage(int cityId);
        public ValueTask<RequestResult<List<Product>>> GetProductsOutOfStock();
        public ValueTask<RequestResult<decimal>> GetSalesCount(int countryId);
        public ValueTask<RequestResult<List<CityTopProduct>>> GetCityTopProduct();
        public ValueTask<RequestResult<decimal>> GetTotalMoneyInCity(int cityId);
        public ValueTask<RequestResult<List<OrdersInfo>>> GetOrdersInfo(OrdersInfo model);

    }
}
