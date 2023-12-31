using AuthHub.Models.Entities.Users;
using AuthHub.Models.Responses;
using Common.Interfaces.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.BLL.Common.Mappers
{
    public class UserResponseMapper: IMapper<User, UserResponse>
    {
        public UserResponse Map(User source)
            => new UserResponse()
            {
                Id = source.Id,
                Email = source.Email,
                FirstName = source.FirstName,
                LastName = source.LastName,
                UserName = source.UserName
            };
    }
}
