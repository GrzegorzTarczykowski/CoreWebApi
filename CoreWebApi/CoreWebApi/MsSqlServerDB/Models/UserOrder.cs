using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class UserOrder
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
