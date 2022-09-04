using Common.Models.Entities;
using Common.Repository;

namespace AuthHub.DAL.EntityFramework.Generic
{
    public class AuthHubRepository<T> : EntityFrameworkSRDRepository<AuthHubContext, T, Guid>
    where T : EntityBase<Guid>
    {
        public AuthHubRepository(AuthHubContext context) : base(context)
        {
        }
    }
}
