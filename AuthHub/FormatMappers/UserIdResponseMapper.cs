using AuthHub.Models.Entities.Users;
using AuthHub.Models.Responses.User;
using Common.Interfaces.Utilities;

namespace AuthHub.Api.FormatMappers
{
    public class UserIdResponseMapper : IMapper<User, UserIdResponse>
    {
        public UserIdResponse Map(User source)
            => new UserIdResponse()
            {
                UserId = source.Id
            };
    }
}
