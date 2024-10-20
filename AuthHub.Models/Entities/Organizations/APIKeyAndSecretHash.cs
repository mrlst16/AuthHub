using Common.Models.Entities;
using System;

namespace AuthHub.Models.Entities.Organizations
{
    public class APIKeyAndSecretHash : EntityBase<int>
    {
        public int OrganizationId { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
        public int Length { get; set; }
        public int Iterations { get; set; }
    }
}