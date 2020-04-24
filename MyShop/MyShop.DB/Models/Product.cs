using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.DB.Models
{
    class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int SubCategoryId { get; set; }
    }
}
