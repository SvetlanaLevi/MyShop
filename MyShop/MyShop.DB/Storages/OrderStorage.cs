using MyShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DB.Storages
{
    class OrderStorage : IOrderStorage
    {
        private IDbConnection connection;
        private IDbTransaction transaction;

        public OrderStorage()
        {

        }

        public ValueTask<Order> AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public ValueTask<List<Order>> GetOrderByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Order> GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public void TransactionStart()
        {
            connection.Open();
            transaction = this.connection.BeginTransaction();
        }

        public void TransactionCommit()
        {
            this.transaction?.Commit();
            connection.Close();
        }

        public void TransactioRollBack()
        {
            this.transaction?.Rollback();
            connection.Close();
        }
    }
}
