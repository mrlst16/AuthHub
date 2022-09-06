using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Requests
{
    public class ResetUserPasswordRequest
    {
        public Guid UserId { get; set; }
    }
}
