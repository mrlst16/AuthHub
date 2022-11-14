using System;
using Common.Models.Entities;

namespace AuthHub.Models.Enums
{
    public class VerificationType : EntityBase<Guid>
    {
        public string Name { get; set; }
        public VerificationTypeEnum Value { get; set; }

        public VerificationType()
        {
        }

        public VerificationType(VerificationTypeEnum value)
            :this()
        {
            Value = value;
        }


        public static implicit operator VerificationTypeEnum(VerificationType source)
            => source.Value;

        public static implicit operator VerificationType(VerificationTypeEnum source)
            => new VerificationType(source);
    }
}
