using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int VehicleTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
