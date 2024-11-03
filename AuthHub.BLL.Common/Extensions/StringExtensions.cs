using System.Text;

namespace AuthHub.BLL.Common.Extensions
{
    public static class StringExtensions
    {
        public static byte[] GetBytes(this string str)
            => Encoding.UTF8.GetBytes(str);
    }
}
