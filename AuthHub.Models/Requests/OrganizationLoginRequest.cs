using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Requests
{
    public class OrganizationLoginRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
