using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class Order
    {
        public Order()
        {
            Message = new HashSet<Message>();
            OrderService = new HashSet<OrderService>();
            OrderVehiclePart = new HashSet<OrderVehiclePart>();
            UserOrder = new HashSet<UserOrder>();
        }

        public int OrderId { get; set; }
        public decimal TotalCost { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? StartDateOfRepair { get; set; }
        public DateTime? EndDateOfRepair { get; set; }
        public int OrderStatusId { get; set; }
        public int VehicleId { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<OrderService> OrderService { get; set; }
        public virtual ICollection<OrderVehiclePart> OrderVehiclePart { get; set; }
        public virtual ICollection<UserOrder> UserOrder { get; set; }
    }
}
