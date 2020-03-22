using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? SentDate { get; set; }
        public int OrderId { get; set; }
        public int UserSenderId { get; set; }
        public int UserReceiverId { get; set; }

        public virtual Order Order { get; set; }
        public virtual User UserReceiver { get; set; }
        public virtual User UserSender { get; set; }
    }
}
