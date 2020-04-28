using Dapper;
using MyShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.DB.Storages
{
    public class ReportStorage : IReportStorage
    {
        private IDbConnection _connection;

        internal static class SpName
        {
            public const string GetCategoryProductCount = "CategoryProductCount";
            public const string GetProductsNeverOrdered = "ProductsNeverOrdered";
            public const string GetProductsOnlyInStorage = "ProductsOnlyInStorage";
            public const string GetProductsOutOfStock = "ProductsOutOfStock";
            public const string GetSalesCount = "SalesCount";
            public const string GetCityTopProduct = "TopProductInCity";
            public const string GetTotalMoneyInCity = "TotalMoneyInCity";
            public const string GetOrdersInfo = "OrdersInfo";
        }

        public ReportStorage(string DBConnectionString)
        {
            _connection = new SqlConnection(DBConnectionString);
        }

        public async ValueTask<List<CategoryWithCount>> GetCategoryProductCount(int count)
        {
            try
            {
                var result = await _connection.QueryAsync<CategoryWithCount, int, CategoryWithCount>(
                   SpName.GetCategoryProductCount,
                   (categoryWithCount, count) =>
                   {
                       categoryWithCount.Count = count;
                       return categoryWithCount;
                   },
                   param: new { count },
                   commandType: CommandType.StoredProcedure,
                        splitOn: "Count"
                   );
                return result.ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<Product>> GetProductsNeverOrdered()
        {
            try
            {
                var result = await _connection.QueryAsync<Product>(
                   SpName.GetProductsNeverOrdered,
                   commandType: CommandType.StoredProcedure
                   );
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<Product>> GetProductsOnlyInStorage(int cityId)
        {
            try
            {
                var result = await _connection.QueryAsync<Product>(
                   SpName.GetProductsOnlyInStorage,
                   commandType: CommandType.StoredProcedure,
                   param: new { cityId }
                   );
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<Product>> GetProductsOutOfStock()
        {
            try
            {
                var result = await _connection.QueryAsync<Product>(
                   SpName.GetProductsOutOfStock,
                   commandType: CommandType.StoredProcedure
                   );
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async ValueTask<decimal> GetSalesCount(int countryId)
        {
            try
            {
                var result = await _connection.QueryAsync<decimal>(
                   SpName.GetSalesCount,
                   commandType: CommandType.StoredProcedure,
                   param: new { countryId }
                   );
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<CityTopProduct>> GetCityTopProduct()
        {
            try
            {
                var result = await _connection.QueryAsync<CityTopProduct>(
                   SpName.GetCityTopProduct,
                   commandType: CommandType.StoredProcedure
                   );
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async ValueTask<decimal> GetTotalMoneyInCity(int cityId)
        {
            try
            {
                var result = await _connection.QueryAsync<decimal>(
                   SpName.GetTotalMoneyInCity,
                   commandType: CommandType.StoredProcedure,
                   param: new { cityId }
                   );
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<OrdersInfo>> GetOrdersInfo(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _connection.QueryAsync<OrdersInfo>(
                   SpName.GetOrdersInfo,
                   commandType: CommandType.StoredProcedure,
                   param: new { startDate, endDate }
                   );
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
