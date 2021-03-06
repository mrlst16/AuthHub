using System;
using System.Collections.Generic;

namespace AuthHub.Models.Organizations
{
    public class Organization
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<AuthSettings> Settings { get; set; } = new List<AuthSettings>();
    }
}
