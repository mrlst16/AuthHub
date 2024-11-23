using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Responses.User
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
