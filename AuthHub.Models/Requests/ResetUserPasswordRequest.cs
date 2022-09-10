using System;

namespace AuthHub.Models.Requests
{
    public class ResetUserPasswordRequest
    {
        public Guid UserId { get; set; }
    }
}
