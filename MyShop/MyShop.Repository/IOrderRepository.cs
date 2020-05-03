using MyShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Repository
{
    public interface IOrderRepository
    {
        ValueTask<RequestResult<Order>> OrderGetById(int id);
        ValueTask<RequestResult<List<Order>>> OrderGetByCustomerId(int id);
        ValueTask<RequestResult<Order>> CreateOrder(Order order);

    }
}
