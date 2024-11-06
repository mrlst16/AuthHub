using Common.Models.Entities;

namespace AuthHub.Models.Entities.Claims
{
    public class ClaimsKey : EntityBase<int>
    {
        public int? ClaimsTemplateId { get; set; }
        public ClaimsTemplate ClaimsTemplate { get; set; }
        public string Name { get; set; }
        public string DefaultValue { get; set; }

        public ClaimsKey()
        {
        }
    }
}
