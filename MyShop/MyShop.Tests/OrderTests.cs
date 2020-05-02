using Microsoft.Extensions.Options;
using MyShop.Core;
using MyShop.DB.Models;
using MyShop.DB.Storages;
using MyShop.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyShop.Tests
{
    public class OrderTests
    {
        private IOptions<StorageOptions> _config;
        private OrderStorage OS;
        private OrderRepository OR;

        [OneTimeSetUp]
        public void GlobalPrepare()
        {
            _config = Options.Create(StorageOptionsStub.opt);
        }

        [SetUp]
        public void PerTestPrepare()
        {
            OS = new OrderStorage(_config);
            OR = new OrderRepository(OS);
        }

        [Test]
        public async ValueTask ShouldInsertOrderTest()
        {
            OrderWithItems expectedOrder = new OrderWithItems
            {
                RepId = 2,
                CustomerId = 1,
                Valute = new Valute { Id = "BYN" }
            };
            var actualOrder = await OS.OrderInsert(expectedOrder);
            Assert.IsNotNull(actualOrder);
        }

        [Test]
        public async ValueTask ShouldGetOrderByIdTest()
        {
            var actualOrder = await OS.OrderGetById(4);
            Assert.IsNotNull(actualOrder);
        }

        [Test]
        public async ValueTask ShouldGetOrderByCustomerIdTest()
        {
            var actualOrder = await OS.OrderGetByCustomerId(1);
            Assert.IsNotNull(actualOrder);
        }

        [Test]
        public async ValueTask ShouldInsertOrderProductTest()
        {
            Order_Product expectedOrder_Prod = new Order_Product
            {
                Product = new Product { Id = 6 },
                OrderId = 5,
                Value = 1,
                LocalPrice = 10000
            };
            var actualOrder_Prod = await OS.OrderProductInsert(expectedOrder_Prod);
            expectedOrder_Prod.Id = actualOrder_Prod.Id;
            Assert.IsTrue(actualOrder_Prod.Equals(expectedOrder_Prod));
        }

        [Test]
        public async ValueTask ShouldGetOrderProductByIdTest()
        {
            var actualOrder = await OS.OrderProductGetById(1);
            Assert.IsNotNull(actualOrder);
        }

        [Test]
        public async ValueTask ShouldGetOrderProductByOrderIdTest()
        {
            var actualOrders = await OS.OrderProductsGetByOrderId(5);
            Assert.IsNotNull(actualOrders);
        }

        [Test]
        public async ValueTask ShouldCreateOrderTest()
        {
            var input = new OrderWithItems()
            {
                CustomerId = 1,
                RepId = 3,
                Valute = new Valute { Id = "BYN", Value = 30.2402M, Nominal = 1 },
                OrderItems = new List<Order_Product>
                {
                    new Order_Product()
                    {
                        Product = new Product{ Id = 3 },
                        Value = 1,
                    },
                    new Order_Product()
                    {
                        Product = new Product{ Id = 4 },
                        Value = 1,                      
                    }
                    
                }
            };

            var actualRequestResult = await OR.CreateOrder(input);
            Assert.IsTrue(actualRequestResult.IsOkay);
        }
    }
}