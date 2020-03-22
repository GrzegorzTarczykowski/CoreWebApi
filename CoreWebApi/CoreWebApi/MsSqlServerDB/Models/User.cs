using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class User
    {
        public User()
        {
            MessageUserReceiver = new HashSet<Message>();
            MessageUserSender = new HashSet<Message>();
            UserOrder = new HashSet<UserOrder>();
            UserTimetable = new HashSet<UserTimetable>();
            Vehicle = new HashSet<Vehicle>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] Salt { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public int PermissionId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual ICollection<Message> MessageUserReceiver { get; set; }
        public virtual ICollection<Message> MessageUserSender { get; set; }
        public virtual ICollection<UserOrder> UserOrder { get; set; }
        public virtual ICollection<UserTimetable> UserTimetable { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
