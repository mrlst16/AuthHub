using AuthHub.Models.Passwords;
using System.Collections;
using System.Collections.Generic;

namespace AuthHub.Tests.MockData
{
    public static class MockPasswords
    {

        public static Password Instance
        {
            get => new Password()
            {

            };
        }

        public static LoginChallengeResponse TestOrg1_LoginChallengeResponse
            => new LoginChallengeResponse()
            {
                Iterations = 10,
                Length = 8,
                Salt = CommonSalt,
                StoredPasswordHash = PasswordHash_Matty33EP_L10_I8
            };

        public static byte[] CommonSalt
        {
            get => new byte[] {
                0,
                255,
                25,
                230,
                50,
                180,
                75,
                155
            };
        }

        public static byte[] PasswordHashMatty33ExclaimationPoint
        {
            get => new byte[] { 9, 240, 14, 19, 84, 137, 15, 11 };
        }

        public static byte[] PasswordHash_Matty33EP_L10_I8
            => new byte[] { 237, 141, 111, 209, 105, 225, 152, 46, 181, 59 };


        public static byte[] PasswordHashTwo
        {
            get => new byte[] {
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
        }

        public class MatchingPasswordTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    MockPasswords.PasswordHashMatty33ExclaimationPoint,
                    "Matty31!",
                    MockPasswords.CommonSalt,
                    8,
                    10
                };
            }


            IEnumerator IEnumerable.GetEnumerator()
                => GetEnumerator();
        }
    }
}
