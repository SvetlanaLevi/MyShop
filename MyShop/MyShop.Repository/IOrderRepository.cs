using MyShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Repository
{
    public interface IOrderRepository
    {
        ValueTask<RequestResult<OrderWithItems>> OrderGetById(int id);
        ValueTask<RequestResult<List<OrderWithItems>>> OrderGetByCustomerId(int id);
        ValueTask<RequestResult<OrderWithItems>> CreateOrder(OrderWithItems order);

    }
}
