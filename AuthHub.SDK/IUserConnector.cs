using AuthHub.Models.Users;
using CommonCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public interface IUserConnector : ISR<UserViewModel>
    {
    }
}
