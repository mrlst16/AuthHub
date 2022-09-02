using Common.Models.Entities;
using System;
using System.Collections.Generic;

namespace AuthHub.Models.Organizations
{
    public class Organization : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<AuthSettings> Settings { get; set; } = new List<AuthSettings>();
    }
}
