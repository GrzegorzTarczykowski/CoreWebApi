using System;
using System.Collections.Generic;

namespace CoreWebApi.MsSqlServerDB.Models
{
    public partial class Client
    {
        public int ClientId { get; set; }
        public string ClientIdCode { get; set; }
        public string ClientSecret { get; set; }
        public string ClientName { get; set; }
        public bool Active { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        public string AllowedOrigin { get; set; }
    }
}
