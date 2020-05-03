using MyShop.DB.Models;
using MyShop.DB.Storages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderStorage _storage;
        public OrderRepository(IOrderStorage storage)
        {
            _storage = storage;
        }


        public async ValueTask<RequestResult<Order>> OrderGetById(int id)
        {
            var result = new RequestResult<Order>();
            try
            {
                result.RequestData = await _storage.OrderGetById(id);
                result.RequestData.OrderItems = await _storage.OrderProductsGetByOrderId((int)result.RequestData.Id);
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
                foreach (var order in result.RequestData)
                {
                    order.OrderItems = await _storage.OrderProductsGetByOrderId((int)order.Id);
                }
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<Order>> CreateOrder(Order order)
        {
            var result = new RequestResult<Order>();

            try
            {
                _storage.TransactionStart();
                result.RequestData = (await _storage.OrderInsert(order));
                result.RequestData.OrderItems = new List<Order_Product>();

                foreach (var item in order.OrderItems)
                {
                    item.OrderId = result.RequestData.Id;
                    var productPrice = (await _storage.ProductsGetById(item.Product.Id)).Price;
                    item.LocalPrice = productPrice * item.Value * order.Valute.Nominal / order.Valute.Value;
                    result.RequestData.OrderItems.Add(await _storage.OrderProductInsert(item));
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
