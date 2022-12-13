
using AuthHub.Interfaces.Hashing;
using System.Security.Cryptography;

namespace AuthHub.BLL.Common.Hashing
{
    public class Rfc2898DeriveBytesHasher : IHasher
    {
        public byte[] HashUsernameAndPasswordWithSalt(byte[] password, byte[] salt, int length, int iterations = 100)
        {
            byte[] result = new byte[length];

            using var derivedBytes = new Rfc2898DeriveBytes(password, salt, iterations);
            result = derivedBytes.GetBytes(length);

            return result;
        }
    }
}
