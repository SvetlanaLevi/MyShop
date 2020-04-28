using MyShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DB.Storages
{
    public interface IReportStorage
    {
        public ValueTask<List<CategoryWithCount>> GetCategoryProductCount(int count);

        public ValueTask<List<Product>> GetProductsNeverOrdered();

        public ValueTask<List<Product>> GetProductsOnlyInStorage(int cityId);

        public ValueTask<List<Product>> GetProductsOutOfStock();

        public ValueTask<decimal> GetSalesCount(int countryId);

        public ValueTask<List<CityTopProduct>> GetCityTopProduct();

        public ValueTask<decimal> GetTotalMoneyInCity(int cityId);

        public ValueTask<List<OrdersInfo>> GetOrdersInfo(DateTime startDate, DateTime endDate);

    }
}
