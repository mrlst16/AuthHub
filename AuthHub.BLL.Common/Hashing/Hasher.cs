
using AuthHub.Interfaces.Hashing;
using System.Security.Cryptography;
using Common.Interfaces.Helpers;

namespace AuthHub.BLL.Common.Hashing
{
    public class Hasher : IHasher
    {
        public byte[] HashPasswordWithSalt(byte[] password, byte[] salt, int length, int iterations = 100)
        {
            using var derivedBytes = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA3_512);
            return derivedBytes.GetBytes(length);
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

            using var derivedBytes = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);

            return (derivedBytes.GetBytes(length), salt);
        }
    }
}
