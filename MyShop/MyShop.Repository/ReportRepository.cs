using MyShop.DB.Models;
using MyShop.DB.Storages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Repository
{
    class ReportRepository
    {
        private readonly ReportStorage _storage;
        public ReportRepository(ReportStorage RS)
        {
            _storage = RS;
        }
        public async ValueTask<RequestResult<List<CategoryWithCount>>> GetCategoryProductCount(int count)
        {
            var result = new RequestResult<List<CategoryWithCount>>();
            try
            {
                result.RequestData = await _storage.GetCategoryProductCount(count);
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<Product>>> GetProductsNeverOrdered()
        {
            var result = new RequestResult<List<Product>>();
            try
            {
                result.RequestData = await _storage.GetProductsNeverOrdered();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<Product>>> GetProductsOnlyInStorage(int cityId)
        {
            var result = new RequestResult<List<Product>>();
            try
            {
                result.RequestData = await _storage.GetProductsOnlyInStorage(cityId);
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<Product>>> GetProductsOutOfStock()
        {
            var result = new RequestResult<List<Product>>();
            try
            {
                result.RequestData = await _storage.GetProductsOutOfStock();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<decimal>> GetSalesCount(int countryId)
        {
            var result = new RequestResult<decimal>();
            try
            {
                result.RequestData = await _storage.GetSalesCount(countryId);
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<CityTopProduct>>> GetCityTopProduct()
        {
            var result = new RequestResult<List<CityTopProduct>>();
            try
            {
                result.RequestData = await _storage.GetCityTopProduct();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }
        public async ValueTask<RequestResult<decimal>> GetTotalMoneyInCity(int cityId)
        {
            var result = new RequestResult<decimal>();
            try
            {
                result.RequestData = await _storage.GetTotalMoneyInCity(cityId);
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<OrdersInfo>>> GetOrdersInfo(DateTime startDate, DateTime endDate)
        {
            var result = new RequestResult<List<OrdersInfo>>();
            try
            {
                result.RequestData = await _storage.GetOrdersInfo(startDate, endDate);
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }
    }
}
