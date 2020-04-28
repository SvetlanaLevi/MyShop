using MyShop.DB.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Repository
{
    public class OrderRepository
    {
        private readonly OrderStorage _storage;
        public OrderRepository(OrderStorage orderStorage)
        {
            _storage = orderStorage;
        }
    }
}
