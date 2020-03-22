using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class Service
    {
        public Service()
        {
            OrderService = new HashSet<OrderService>();
        }

        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ExecutionTimeInMinutes { get; set; }

        public virtual ICollection<OrderService> OrderService { get; set; }
    }
}
