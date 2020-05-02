using MyShop.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Tests
{
    public static class StorageOptionsStub
    {
        public static StorageOptions opt = new StorageOptions()
        {
            DBConnectionString = "Data Source = (local); Initial Catalog = ShopDB; Integrated Security = True;"
        };
    }

}
