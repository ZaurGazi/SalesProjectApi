﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SalesProjectApi
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserMail { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}