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
    public class OrderStorage : IOrderStorage
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        internal static class SpName
        {
            public const string OrderInsert = "Order_Insert";
            public const string Order_ProductInsert = "Order_Product_Insert";
            public const string OrderGetById = "Order_SelectById";
            public const string OrderGetByCustomerId = "Order_SelectByCustomerId";
            public const string Order_ProductGetById = "Order_Product_SelectById";
            public const string Order_ProductGetByOrderId = "Order_Product_SelectByOrderId";
            public const string ProductGetById = "Product_SelectById";
        }

        public OrderStorage(string DBConnectionString)
        {
            _connection = new SqlConnection(DBConnectionString);
        }

        public async ValueTask<Order> OrderInsert(Order order)
        {
            try
            {
                Order outputOrder;
                var result = await _connection.QueryAsync<int>(
                    SpName.OrderInsert,
                    new
                    {
                        RepId = order.Rep.Id,
                        order.CustomerId
                    },
                    transaction: _transaction,
                    commandType: CommandType.StoredProcedure);
                order.Id = result.FirstOrDefault();
                outputOrder = await OrderGetById((int)order.Id);
                return outputOrder;
            }

            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async ValueTask<Order> OrderGetById(int id)
        {
            try
            {
                var result = await _connection.QueryAsync<Order, Representative, Order>(
                   SpName.OrderGetById,
                   (order, representative) =>
                   {
                       order.Rep = representative;
                       return order;
                   },
                   transaction: _transaction,
                   splitOn: "Id",
                   param: new { id },
                   commandType: CommandType.StoredProcedure
                   );
                return result.FirstOrDefault();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<Order>> OrderGetByCustomerId(int customerId)
        {
            try
            {
                var result = await _connection.QueryAsync<Order, Representative, Order>(
                    SpName.OrderGetByCustomerId,
                    (order, representative) =>
                    {
                        order.Rep = representative;
                        return order;
                    },
                    new { customerId },
                    transaction: _transaction,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id");
                return result.ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async ValueTask<Order_Product> OrderProductInsert(Order_Product order_Product)
        {
            try
            {
                Order_Product output;
                var result = await _connection.QueryAsync<int>(
                    SpName.Order_ProductInsert,
                    param: new
                    {
                         ProductId = order_Product.Product.Id,
                         OrderId = order_Product.Order.Id,
                         ValuteId = order_Product.Valute.Id,
                         order_Product.Value,
                         order_Product.LocalPrice
                    },
                    transaction: _transaction,
                    commandType: CommandType.StoredProcedure);
                var Id = result.FirstOrDefault();
                output = await OrderProductGetById(Id);
                return output;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public async ValueTask<Order_Product> OrderProductGetById(int id)
        {
            try
            {
                var result = await _connection.QueryAsync<Order_Product, Order, Representative, Product, Valute, Order_Product>(
                    SpName.Order_ProductGetById,
                    (order_Product,  order, rep, product, valute) =>
                    {
                        order_Product.Order = order;
                        order_Product.Order.CustomerId = order.CustomerId;
                        order_Product.Order.OrderDate = order.OrderDate;
                        order_Product.Order.Rep = rep;
                        order_Product.Order.Rep.Name = rep.Name;
                        order_Product.Product = product;
                        order_Product.Product.Model = product.Model;
                        order_Product.Product.Brand = product.Brand;
                        order_Product.Valute = valute;
                        return order_Product;
                    },
                    new { id },
                    transaction: _transaction,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                    );
                return result.FirstOrDefault();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<Order_Product>> OrderProductsGetByOrderId(int orderId)
        {
            try
            {
                var result = await _connection.QueryAsync<Order_Product, Product, Order, Valute, Order_Product>(
                    SpName.Order_ProductGetByOrderId,
                    (order_Product, product, order, valute) =>
                    {
                        order_Product.Product = product;
                        order_Product.Order = order;
                        order_Product.Valute = valute;
                        return order_Product;
                    },
                    new { orderId },
                    transaction: _transaction,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                    );
                return result.ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async ValueTask<Product> ProductsGetById(int? Id)
        {
            try
            {
                var result = await _connection.QueryAsync<Product>(
                    SpName.ProductGetById,
                    new { Id },
                    transaction: _transaction,
                    commandType: CommandType.StoredProcedure
                    );
                return result.FirstOrDefault();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TransactionStart()
        {
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public void TransactionCommit()
        {
            _transaction?.Commit();
            _connection.Close();
        }

        public void TransactioRollBack()
        {
            _transaction?.Rollback();
            _connection.Close();
        }


    }
}
