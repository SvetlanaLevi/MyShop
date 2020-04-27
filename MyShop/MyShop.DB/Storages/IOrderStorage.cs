using MyShop.DB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MyShop.DB.Storages
{
    public interface IOrderStorage
    {
        ValueTask<Order> AddOrder(Order order);
        ValueTask<Order> GetOrderById(int orderId);
        ValueTask<List<Order>> GetOrderByCustomerId(int customerId);
        void TransactionCommit();
        void TransactionStart();
        void TransactioRollBack();
    }
}
