using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthHub.Models.Responses.Verification;
using Common.Models.Responses;

namespace AuthHub.SDK.Interfaces
{
    public interface IVerificationConnector
    {
        Task<ApiResponse<VerificationCodeResponse>> RequestPhoneLoginCode(string  phoneNumber);
    }
}
