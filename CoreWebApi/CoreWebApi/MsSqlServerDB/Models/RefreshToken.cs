using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class RefreshToken
    {
        public string RefreshTokenId { get; set; }
        public string UserName { get; set; }
        public string ClientCode { get; set; }
        public DateTime IssuedTime { get; set; }
        public DateTime ExpiredTime { get; set; }
        public string ProtectedTicket { get; set; }
    }
}
