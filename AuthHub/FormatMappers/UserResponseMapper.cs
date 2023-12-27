using AuthHub.Api.Responses;
using AuthHub.Models.Entities.Users;
using AuthHub.Models.Responses;
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
