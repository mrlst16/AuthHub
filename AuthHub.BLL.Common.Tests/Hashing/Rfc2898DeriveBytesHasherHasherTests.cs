using AuthHub.BLL.Common.Hashing;
using AuthHub.BLL.Common.Helpers;
using AuthHub.Tests.MockData;
using System.Text;
using System.Threading.Tasks;
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

        [Fact]
        public async Task HashUsernameAndPasswordWithSalt_Harness()
        {
            var applicationConsistency = new ApplicationConsistency();
            var userNameBytes = applicationConsistency.GetBytes("Pawnder");
            var passwordBytes = applicationConsistency.GetBytes("Pawnder22!");

            var salt = new byte[] { 142, 34, 0, 28 };

            var result = _hasher.HashUsernameAndPasswordWithSalt(
                userNameBytes,
                passwordBytes,
                salt,
                10,
                10
            );

            StringBuilder sb = new StringBuilder();
            sb.Append("new byte[]{");
            foreach (var b in result)
            {
                sb.Append(b.ToString());
                sb.Append(",");
            }
            sb.Append("}");

            var useThis = sb.ToString();
        }
    }
}
