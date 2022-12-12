using AuthHub.Interfaces.Hashing;
using AuthHub.Interfaces.Passwords;
using Common.Interfaces.Helpers;

namespace AuthHub.BLL.Common.Passwords
{
    public class PasswordEvaluator : IPasswordEvaluator
    {
        private readonly IHasher _hasher;
        private readonly IApplicationConsistency _applicationConsistency;

        public PasswordEvaluator(
            IHasher hasher,
            IApplicationConsistency applicationConsistency
            )
        {
            _hasher = hasher;
            _applicationConsistency = applicationConsistency;
        }

        public bool EvaluateUsernameAndPasswordWithSalt(
            string username,
            string password,
            int length,
            int iterations,
            byte[] salt,
            byte[] storedHash)
        {
            var passwordBytes = _applicationConsistency.GetBytes(password);
            var hash = _hasher.HashUsernameAndPasswordWithSalt(passwordBytes, salt, length, iterations);

            return _applicationConsistency.BytesEqual(hash, storedHash);
        }
    }
}