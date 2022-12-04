using System.Threading.Tasks;
using AuthHub.BLL.Common.Hashing;
using AuthHub.Tests.MockData;
using Xunit;

namespace AuthHub.BLL.Common.Tests.Hashing
{
    public class Rfc2898DeriveBytesHasherHasherTests
    {
        private readonly Rfc2898DeriveBytesHasher _hasher;
        
        public Rfc2898DeriveBytesHasherHasherTests()
        {
            _hasher = new Rfc2898DeriveBytesHasher();
        }

        [Fact]
        public async Task HashUsernameAndPasswordWithSalt_NotEmpty()
        {
            var result = _hasher.HashUsernameAndPasswordWithSalt(
                MockPasswordData.UserNameBytes,
                MockPasswordData.PasswordBytes,
                MockPasswordData.Salt1234,
                10,
                10
            );

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task HashUsernameAndPasswordWithSalt_TwoCallsSameArguments_Match()
        {
            var result1 = _hasher.HashUsernameAndPasswordWithSalt(
                MockPasswordData.UserNameBytes,
                MockPasswordData.PasswordBytes,
                MockPasswordData.Salt1234,
                10,
                10
            );

            var result2 = _hasher.HashUsernameAndPasswordWithSalt(
                MockPasswordData.UserNameBytes,
                MockPasswordData.PasswordBytes,
                MockPasswordData.Salt1234,
                10,
                10
            );

            Assert.Equal(result2, result1);
        }
    }
}
