using System;

namespace AuthHub.Models.Requests
{
    public class RequestPasswordResetRequest
    {
        public Guid UserId { get; set; }
    }
}
