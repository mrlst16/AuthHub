using AuthHub.Models.Passwords;
using CommonCore.Repo.Entities;
using System;

namespace AuthHub.Models.Users
{
    public class User : EntityBase
    {
        public Guid UsersOrganizationId { get; set; }

        private bool? _isOrganization;
        public bool? IsOrganization
        {
            get => _isOrganization ??= (UsersOrganizationId != Guid.Empty);
            set => _isOrganization = value;
        }

        public Guid OrganizationId { get; set; }
        public Guid AuthSettingsId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Password Password { get; set; }
    }
}
