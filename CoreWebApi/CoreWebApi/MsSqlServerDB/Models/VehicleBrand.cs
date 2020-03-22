using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class VehicleBrand
    {
        public VehicleBrand()
        {
            VehicleModel = new HashSet<VehicleModel>();
        }

        public int VehicleBrandId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VehicleModel> VehicleModel { get; set; }
    }
}
