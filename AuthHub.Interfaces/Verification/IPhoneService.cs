using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Verification
{
    public interface IPhoneService
    {
        Task SendSMSMessage(string phoneNumber, string message);
    }
}
