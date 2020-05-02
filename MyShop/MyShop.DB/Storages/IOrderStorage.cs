using MyShop.DB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MyShop.DB.Storages
{
    public interface IOrderStorage
    {
        ValueTask<OrderWithItems> OrderInsert(OrderWithItems order);
        ValueTask<OrderWithItems> OrderGetById(int orderId);
        ValueTask<Order_Product> OrderProductInsert(Order_Product order_Product);
        ValueTask<List<OrderWithItems>> OrderGetByCustomerId(int customerId);
        ValueTask<List<Order_Product>> OrderProductsGetByOrderId(int customerId);
        ValueTask<Product> ProductsGetById(int? Id);
        void TransactionCommit();
        void TransactionStart();
        void TransactioRollBack();
    }
}
