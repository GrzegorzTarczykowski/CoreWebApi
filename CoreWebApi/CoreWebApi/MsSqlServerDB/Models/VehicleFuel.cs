using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class VehicleFuel
    {
        public VehicleFuel()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int VehicleFuelId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
