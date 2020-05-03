using MyShop.DB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MyShop.DB.Storages
{
    public interface IOrderStorage
    {
        ValueTask<Order> OrderInsert(Order order);
        ValueTask<Order> OrderGetById(int orderId);
        ValueTask<Order_Product> OrderProductInsert(Order_Product order_Product);
        ValueTask<List<Order>> OrderGetByCustomerId(int customerId);
        ValueTask<List<Order_Product>> OrderProductsGetByOrderId(int customerId);
        ValueTask<Product> ProductsGetById(int? Id);
        void TransactionCommit();
        void TransactionStart();
        void TransactioRollBack();
    }
}
