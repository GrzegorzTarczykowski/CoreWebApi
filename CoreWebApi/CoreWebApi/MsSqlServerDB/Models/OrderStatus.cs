using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Order = new HashSet<Order>();
        }

        public int OrderStatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
