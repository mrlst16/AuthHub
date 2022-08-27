using AuthHub.Models.Enums;
using CommonCore.Models.Repo.Entities;

namespace AuthHub.DAL.EntityFramework.Models
{
    public class AuthScheme: EntityBase
    {
        public string Name { get; set; }
        public AuthSchemeEnum Value { get; set; }

    }
}
