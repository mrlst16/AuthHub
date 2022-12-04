using Common.Interfaces.Helpers;
using System.Text;

namespace AuthHub.BLL.Common.Helpers
{
    public class ApplicationConsistency : IApplicationConsistency
    {
        public bool BytesEqual(byte[] one, byte[] two)
            => one.SequenceEqual(two);
        public byte[] GetBytes(string str)
            => Encoding.UTF8.GetBytes(str);
        public static byte[] GetBytesFromString(string str)
            => Encoding.UTF8.GetBytes(str);
        public string GetString(byte[] bytes)
            => Encoding.UTF8.GetString(bytes);
    }
}
