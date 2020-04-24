using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.DB.Models
{
    class Order
    {
        public int Id { get; set; }
        public Representative Rep { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
