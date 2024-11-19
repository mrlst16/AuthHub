using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Responses.Tokens
{
    public class TokenResponse
    {
        public int UserId { get; set; }
        public string Value { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.MaxValue;
    }
}
