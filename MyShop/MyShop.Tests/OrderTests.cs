using MyShop.DB.Models;
using MyShop.DB.Storages;
using MyShop.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyShop.Tests
{
    public class Tests
    {
        OrderStorage OS = new OrderStorage("Data Source = (local); Initial Catalog = ShopDB; Integrated Security=True;");
        OrderRepository OR = new OrderRepository(new OrderStorage("Data Source = (local); Initial Catalog = ShopDB; Integrated Security=True;"));

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async ValueTask ShouldInsertOrderTest()
        {
            Order expectedOrder = new Order
            {
                Rep = new Representative { Id = 2 },
                CustomerId = 1
            };
            var actualOrder = await OS.OrderInsert(expectedOrder);
            Assert.IsTrue(actualOrder.Equals(expectedOrder));
        }

        [Test]
        public async ValueTask ShouldGetOrderByIdTest()
        {
            var actualOrder = await OS.OrderGetById(1);
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
                Product = new Product { Id = 1},
                Order = new Order { Id = 1},
                Value = 1,
                Valute = new Valute { Id = "RUB" },
                LocalPrice = 10000
            };
            var actualOrder_Prod = await OS.OrderProductInsert(expectedOrder_Prod);
            expectedOrder_Prod.Id = actualOrder_Prod.Id;
            Assert.IsTrue(actualOrder_Prod.Equals(expectedOrder_Prod));
        }

        [Test]
        public async ValueTask ShouldGetOrder_ProductByIdTest()
        {
            var actualOrder = await OS.OrderProductGetById(1);
            Assert.IsNotNull(actualOrder);
        }

        [Test]
        public async ValueTask ShouldGetOrderProsuctByOrderIdTest()
        {
            var actualOrders = await OS.OrderProductsGetByOrderId(1);
            Assert.IsNotNull(actualOrders);
        }

        [Test]
        public async ValueTask ShouldCreateOrderIdTest()
        {
            var input = new List<Order_Product>()
            {
                new Order_Product()
                {
                    Product = new Product{ Id = 3 },
                    Order = new Order{ Rep = new Representative{ Id = 1}, CustomerId = 1 },
                    Value = 1,
                    Valute = new Valute{ Id = "BYN", Value = 30.2402M},
                },
                new Order_Product()
                {
                    Product = new Product{ Id = 4 },
                    Order = new Order{ Rep = new Representative{ Id = 1}, CustomerId = 1 },
                    Value = 1,
                    Valute = new Valute{ Id = "BYN", Value = 30.2402M},
                }
            };

            var actualRequestResult = await OR.CreateOrder(input);
            Assert.IsTrue(actualRequestResult.IsOkay);
        }
    }
}