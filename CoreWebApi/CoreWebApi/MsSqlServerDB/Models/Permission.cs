using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class Permission
    {
        public Permission()
        {
            User = new HashSet<User>();
        }

        public int PermissiondId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
