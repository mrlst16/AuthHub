using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Responses.Verification
{
    public class VerificationCodeResponse
    {
        public string Code { get; set; }
        public DateTime ExpirationDateUTC { get; set; }
    }
}
