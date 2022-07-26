using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProjectApi.Models
{
    public class OrderItem
    {
        public int  OrderId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        public int Mode { get; set; }
        public string Color { get; set; }
        public string ItemCategory { get; set; }
    }
}
