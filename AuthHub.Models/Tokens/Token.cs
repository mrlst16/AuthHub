using System;

namespace AuthHub.Models.Tokens
{
    public class Token
    {
        public string Value { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.MaxValue;

        public Token()
        {
        }
    }
}
