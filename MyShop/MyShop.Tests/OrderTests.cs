using MyShop.DB.Models;
using MyShop.DB.Storages;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MyShop.Tests
{
    public class Tests
    {
        OrderStorage OS = new OrderStorage("Data Source = (local); Initial Catalog = ShopDB; Integrated Security=True;");

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
        public async ValueTask ShouldGetOrderTest()
        {
            var actualOrder = await OS.OrderGetById(1);
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
                Valute = new Valute { Id = "R01010" },
                LocalPrice = 10000
            };
            var actualOrder_Prod = await OS.OrderProductInsert(expectedOrder_Prod);
            Assert.IsTrue(actualOrder_Prod.Equals(expectedOrder_Prod));
        }

        [Test]
        public async ValueTask ShouldGetOrder_ProductTest()
        {
            var actualOrder = await OS.OrderProductGetById(1);
            Assert.IsNotNull(actualOrder);
        }
    }
}