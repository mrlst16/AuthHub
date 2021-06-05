using AuthHub.Models.Users;
using CommonCore.Repo.Entities;
using System;
using System.Collections.Generic;

namespace AuthHub.Models.Organizations
{
    public class Organization
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public OrganizationSettings Settings { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
