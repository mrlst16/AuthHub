using System;

namespace AuthHub.Models.Tokens
{
    public class Token
    {
        public string Value { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.MaxValue;
        public Guid EntityID { get; set; }

        public Token()
        {
        }

        public Token(
            string value,
            Guid entityId
            ) : this()
        {
            Value = value;
            EntityID = entityId;
        }

        public Token(
            string value,
            DateTime expiration,
            Guid entityId
            ) : this(value, entityId)
        {
            ExpirationDate = expiration;
        }

        public override string ToString()
            => Value;

        public static implicit operator string(Token token)
            => token.Value;
    }
}
