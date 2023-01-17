using AuthHub.Api.Responses;
using AuthHub.Models.Entities.Users;
using Common.Interfaces.Utilities;

namespace AuthHub.Api.FormatMappers
{
    public class UserResponseMapper : IMapper<User, UserResponse>
    {
        public UserResponse Map(User source)
            => new UserResponse()
            {
                UserId = source.Id
            };
    }
}
