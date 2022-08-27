using AuthHub.Models.Passwords;
using AuthHub.Models.Requests;
using System.Collections;
using System.Collections.Generic;

namespace AuthHub.Tests.MockData
{
    public static class MockPasswords
    {

        public static Password TestOrg1_AudderOrgLogin =>
            new Password()
            {

            };

        public static LoginChallengeResponse TestOrg1_LoginChallengeResponse
            => new LoginChallengeResponse()
            {
                Iterations = 10,
                Length = 8,
                Salt = SharedMocks.Salt,
                StoredPasswordHash = PasswordHash_Matty33EP_L8_I10
            };

        public static byte[] PasswordHashMatty33ExclaimationPoint => new byte[] { 9, 240, 14, 19, 84, 137, 15, 11 };

        public static byte[] PasswordHash_Matty33EP_L10_I8
            => new byte[] { 237, 141, 111, 209, 105, 225, 152, 46, 181, 59 };

        public static byte[] PasswordHash_Matty33EP_L8_I10
            => new byte[] { 37, 239, 223, 71, 21, 30, 59, 90 };

        public static byte[] PasswordHash_Matty33EP_L64_I100
            => new byte[] { 112, 92, 157, 187, 201, 159, 182, 233, 152, 0, 5, 172, 231, 68, 122, 185, 14, 202, 208, 252, 36, 233, 243, 148, 159, 224, 0, 102, 244, 146, 68, 206, 71, 205, 37, 155, 117, 101, 136, 39, 231, 92, 195, 149, 215, 127, 255, 96, 118, 100, 249, 46, 76, 214, 201, 236, 134, 64, 116, 224, 73, 233, 213, 139 };

        public static byte[] PasswordHashTwo =>
            new byte[] {
                4,
                4,
                35,
                93,
                100,
                136,
                78,
                33,
                33,
                49,
                213
            };

        public class MatchingPasswordTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    MockPasswords.PasswordHashMatty33ExclaimationPoint,
                    "Matty31!",
                    SharedMocks.Salt,
                    8,
                    10
                };
            }


            IEnumerator IEnumerable.GetEnumerator()
                => GetEnumerator();
        }
    }
}
