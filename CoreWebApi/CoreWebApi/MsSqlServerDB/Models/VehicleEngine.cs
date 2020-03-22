using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class VehicleEngine
    {
        public VehicleEngine()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int VehicleEngineId { get; set; }
        public decimal PowerKw { get; set; }
        public decimal CapacityCcm { get; set; }
        public string EngineCode { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
