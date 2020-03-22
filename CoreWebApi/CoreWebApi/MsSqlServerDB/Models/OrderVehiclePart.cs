using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class OrderVehiclePart
    {
        public int OrderId { get; set; }
        public int VehiclePartId { get; set; }

        public virtual Order Order { get; set; }
        public virtual VehiclePart VehiclePart { get; set; }
    }
}
