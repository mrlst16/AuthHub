using AuthHub.BLL.Common.Hashing;
using AuthHub.BLL.Common.Helpers;
using AuthHub.BLL.Common.Passwords;
using AuthHub.Interfaces.Hashing;
using AuthHub.Tests.MockData;
using Common.Interfaces.Helpers;
using System.Threading.Tasks;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace AuthHub.BLL.Common.Tests.Passwords
{
    public class PasswordEvaluatorTests
    {
        private readonly PasswordEvaluator _passwordEvaluator;
        private readonly IHasher _hasher;
        private readonly IApplicationConsistency _applicationConsistency;

        public PasswordEvaluatorTests()
        {
            _hasher = new Rfc2898DeriveBytesHasher();
            _applicationConsistency = new ApplicationConsistency();
            _passwordEvaluator = new PasswordEvaluator(
                _hasher,
                _applicationConsistency
            );
        }

        [Fact]
        public async Task EvaluateUsernameAndPasswordWithSalt_Matches()
        {
            var storedHash = _hasher.HashUsernameAndPasswordWithSalt(
                MockPasswordData.PasswordBytes,
                MockPasswordData.Salt1234,
                10,
                10
            );

            var result = _passwordEvaluator.EvaluateUsernameAndPasswordWithSalt(
                MockPasswordData.UserName,
                MockPasswordData.Password,
                10,
                10,
                MockPasswordData.Salt1234,
                storedHash
            );

            Assert.True(result);
        }
    }
}
