using AuthHub.Models.Enums;
using CommonCore.Repo.Entities;
using System;

namespace AuthHub.Models.Organizations
{
    public class OrganizationSettings : EntityBase
    {
        public string Name { get; set; }
        public Guid OrganizationID { get; set; }
        public TokenTypeEnum TokenType { get; set; }
        public int SaltLength { get; set; }
        public int HashLength { get; set; }
        public int Iterations { get; set; }
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ExpirationMinutes { get; set; } = 30;
    }
}
