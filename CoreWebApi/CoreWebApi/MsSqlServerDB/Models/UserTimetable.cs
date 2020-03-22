using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class UserTimetable
    {
        public int UserId { get; set; }
        public int TimetableId { get; set; }

        public virtual Timetable Timetable { get; set; }
        public virtual User User { get; set; }
    }
}
