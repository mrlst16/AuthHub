using System.Text;

namespace AuthHub.Tests.MockData
{
    public static class MockPasswordData
    {
        public static byte[] Salt1234 = new byte[4] { 1, 2, 3, 4 };
        public static string UserName = "Username";
        public static string Password = "Password";
        public static byte[] UserNameBytes => Encoding.UTF8.GetBytes(UserName);
        public static byte[] PasswordBytes => Encoding.UTF8.GetBytes(Password);
    }
}
