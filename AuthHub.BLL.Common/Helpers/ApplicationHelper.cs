using CommonCore.Interfaces.Helpers;
using System.Text;

namespace AuthHub.BLL.Common.Helpers
{
    public class ApplicationHelper : IApplicationHelper
    {
        public byte[] GetBytes(string str)
            => Encoding.UTF8.GetBytes(str);
        public string GetString(byte[] bytes)
            => Encoding.UTF8.GetString(bytes);
    }
}
