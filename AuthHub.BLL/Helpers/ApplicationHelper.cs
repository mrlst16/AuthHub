using CommonCore.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.BLL.Helpers
{
    public class ApplicationHelper : IApplicationHelper
    {
        public byte[] GetBytes(string str)
            => Encoding.UTF8.GetBytes(str);
        public string GetString(byte[] bytes)
        => Encoding.UTF8.GetString(bytes);

    }
}
