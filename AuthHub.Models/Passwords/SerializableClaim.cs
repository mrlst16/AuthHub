using System.Security.Claims;

namespace AuthHub.Models.Passwords
{
    public class SerializableClaim
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public SerializableClaim()
        {
        }

        public SerializableClaim(string key, string value)
            : this()
        {
            Key = key;
            Value = value;
        }

        public static implicit operator Claim(SerializableClaim serializableClaim)
            => new Claim(serializableClaim.Key, serializableClaim.Value);
    }

}