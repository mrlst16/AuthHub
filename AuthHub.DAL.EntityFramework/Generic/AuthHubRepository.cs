using Common.Models.Entities;
using Common.Repository;

namespace AuthHub.DAL.EntityFramework.Generic
{
    public class AuthHubRepository<T, TId> : EntityFrameworkSRDRepository<AuthHubContext, T, TId>
        where T : EntityBase<TId>
        where TId : IEquatable<TId>
    {
        public AuthHubRepository(AuthHubContext context) : base(context)
        {
        }
    }
}
