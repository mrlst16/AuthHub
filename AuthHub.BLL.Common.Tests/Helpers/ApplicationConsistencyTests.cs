using AuthHub.BLL.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AuthHub.BLL.Common.Tests.Helpers
{
    public class ApplicationConsistencyTests
    {

        private readonly ApplicationConsistency _applicationConsistency;

        public ApplicationConsistencyTests()
        {
            _applicationConsistency = new ApplicationConsistency();
        }

        [Theory]
        [MemberData(nameof(BytesData))]
        public void SanityCheck_BytesEqual(
            byte[] one,
            byte[] two,
            bool expectedMatch
            )
        {
            var result = _applicationConsistency.BytesEqual(one, two);
            Assert.Equal(expectedMatch, result);
        }

        public static IEnumerable<object[]> BytesData()
        => new List<object[]>()
        {
            new object[]{ new byte[0], new byte[] { 1, 2,3}, false },
            new object[]{ new byte[] { 1,2,3}, new byte[] { 1, 2,3}, true },
        };
    }
}
