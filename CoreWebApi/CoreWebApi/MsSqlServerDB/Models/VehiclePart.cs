using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class VehiclePart
    {
        public VehiclePart()
        {
            OrderVehiclePart = new HashSet<OrderVehiclePart>();
        }

        public int VehiclePartId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderVehiclePart> OrderVehiclePart { get; set; }
    }
}
