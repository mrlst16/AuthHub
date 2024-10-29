
using AuthHub.Interfaces.Hashing;
using System.Security.Cryptography;

namespace AuthHub.BLL.Common.Hashing
{
    public class Rfc2898DeriveBytesHasher : IHasher
    {
        public byte[] HashPasswordWithSalt(byte[] password, byte[] salt, int length, int iterations = 100)
        {
            byte[] result = new byte[length];

            using var derivedBytes = new Rfc2898DeriveBytes(password, salt, iterations);
            result = derivedBytes.GetBytes(length);

            return result;
        }


        public (byte[], byte[]) HashPasswordWithSalt(byte[] password, int length, int saltLength = 10, int iterations = 100)
        {
            var salt = RandomNumberGenerator.GetBytes(saltLength);

            using var derivedBytes = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA3_512);

            return (derivedBytes.GetBytes(length), salt);
        }

        public (byte[], byte[]) HashPasswordWithSalt(string password, int length, int saltLength = 10, int iterations = 100)
        {
            var salt = RandomNumberGenerator.GetBytes(saltLength);

            using var derivedBytes = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA3_512);

            return (derivedBytes.GetBytes(length), salt);
        }
    }
}
