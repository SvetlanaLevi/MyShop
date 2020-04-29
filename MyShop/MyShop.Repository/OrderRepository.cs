using MyShop.DB.Models;
using MyShop.DB.Storages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Repository
{
    public class OrderRepository
    {
        private readonly OrderStorage _storage;
        public OrderRepository(OrderStorage orderStorage)
        {
            _storage = orderStorage;
        }


        public async ValueTask<RequestResult<Order>> OrderGetById(int id)
        {
            var result = new RequestResult<Order>();
            try
            {
                result.RequestData = await _storage.OrderGetById(id);
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<Order>>> OrderGetByCustomerId(int id)
        {
            var result = new RequestResult<List<Order>>();
            try
            {
                result.RequestData = await _storage.OrderGetByCustomerId(id);
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<Order_Product>>> CreateOrder(List<Order_Product> order_ProductModels)
        {
            var result = new RequestResult<List<Order_Product>>() { RequestData = new List<Order_Product>()};
            try
            {
                _storage.TransactionStart();
                var order = await _storage.OrderInsert(order_ProductModels[0].Order);
                foreach (var item in order_ProductModels)
                {
                    item.Order = order;
                    item.LocalPrice = (await _storage.ProductsGetById(item.Product.Id)).Price * item.Value / item.Valute.Value;
                    result.RequestData.Add(await _storage.OrderProductInsert(item));
                }
                _storage.TransactionCommit();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                _storage.TransactioRollBack();
                result.ExMessage = ex.Message;
            }
            return result;
        }

    }
}
