﻿using AuthHub.Models.Enums;

namespace AuthHub.Models.Responses.AuthSettings
{
    public class AuthSettingsResponse
    {
        public int SaltLength { get; set; }
        public int HashLength { get; set; }
        public int Iterations { get; set; }
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
