using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class Timetable
    {
        public Timetable()
        {
            UserTimetable = new HashSet<UserTimetable>();
        }

        public int TimetableId { get; set; }
        public DateTime DateTime { get; set; }
        public int NumberOfEmployeesForCustomer { get; set; }
        public int NumberOfEmployeesReservedForCustomer { get; set; }
        public int NumberOfEmployeesForManager { get; set; }
        public int NumberOfEmployeesReservedForManager { get; set; }

        public virtual ICollection<UserTimetable> UserTimetable { get; set; }
    }
}
