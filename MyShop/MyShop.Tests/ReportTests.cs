using Microsoft.Extensions.Options;
using MyShop.Core;
using MyShop.DB.Models;
using MyShop.DB.Storages;
using MyShop.Repository;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MyShop.Tests
{
    public class ReportTests
    {
        private IOptions<StorageOptions> _config;
        private ReportStorage RS;
        private ReportRepository RR;

        [OneTimeSetUp]
        public void GlobalPrepare()
        {
            _config = Options.Create(StorageOptionsStub.opt);
        }

        [SetUp]
        public void PerTestPrepare()
        {
            RS = new ReportStorage(_config);
            RR = new ReportRepository(RS);
        }

        [Test]
        public async ValueTask ShouldGetCategoryWithCount()
        {
            var actual = await RS.GetCategoryProductCount(5);
            Assert.IsNotNull(actual);
        }

        [Test]
        public async ValueTask ShouldGetProductsNeverOrdered()
        {
            var actual = await RS.GetProductsNeverOrdered();
            Assert.IsNotNull(actual);
        }

        [Test]
        public async ValueTask ShouldGetProductsOnlyInStorage()
        {
            var actual = await RS.GetProductsOnlyInStorage(1);
            Assert.IsNotNull(actual);
        }

        [Test]
        public async ValueTask ShouldGetProductsOutOfStock()
        {
            var actual = await RS.GetProductsOutOfStock();
            Assert.IsNotNull(actual);
        }

        [Test]
        public async ValueTask ShouldGetSalesCount()
        {
            var actual = await RS.GetSalesCount(1);
            Assert.IsNotNull(actual);
        }

        [Test]
        public async ValueTask ShouldGetCityTopProduct()
        {
            var actual = await RS.GetCityTopProduct();
            Assert.IsNotNull(actual);
        }

        [Test]
        public async ValueTask ShouldGetTotalMoneyInCity()
        {
            var actual = await RS.GetTotalMoneyInCity(1);
            Assert.IsNotNull(actual);
        }

        [Test]
        public async ValueTask ShouldGetOrdersInfo()
        {
           // DateTime start = new DateTime(2015, 7, 20);
           // DateTime end = new DateTime(2025, 7, 20);
           // var actual = await RS.GetOrdersInfo(start, end);
           // Assert.IsNotNull(actual);
        }
    }
}