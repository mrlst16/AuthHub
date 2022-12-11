﻿using System;
using Common.Models.Entities;

namespace AuthHub.Models.Organizations
{
    public class APIKeyAndSecretHash : EntityBase<Guid>
    {
        public Guid OrganizationId { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
        public int Length { get; set; }
        public int Iterations { get; set; }
    }
}