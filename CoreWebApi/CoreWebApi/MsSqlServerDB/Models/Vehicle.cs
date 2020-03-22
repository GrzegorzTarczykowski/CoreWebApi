using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Order = new HashSet<Order>();
        }

        public int VehicleId { get; set; }
        public int EngineMileage { get; set; }
        public string RegistrationNumbers { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int VehicleEngineId { get; set; }
        public int VehicleFuelId { get; set; }
        public int VehicleModelId { get; set; }
        public int VehicleTypeId { get; set; }

        public virtual User User { get; set; }
        public virtual VehicleEngine VehicleEngine { get; set; }
        public virtual VehicleFuel VehicleFuel { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
