using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class VehicleModel
    {
        public VehicleModel()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int VehicleModelId { get; set; }
        public string Name { get; set; }
        public int VehicleBrandId { get; set; }

        public virtual VehicleBrand VehicleBrand { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
