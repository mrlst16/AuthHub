using AuthHub.Models.Entities.Enums;
using AuthHub.Models.Entities.Users;
using Common.Models.Entities;
using System;

namespace AuthHub.Models.Entities.Verification
{
    public class VerificationCode : EntityBase<Guid>
    {
        public User User { get; set; }
        public string Code { get; set; }
        public VerificationType Type { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? VerificationDate { get; set; } = null;

        public static implicit operator string(VerificationCode code)
            => code.Code;
    }
}
