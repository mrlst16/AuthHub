using Common.Models.Entities;

namespace AuthHub.Models.Entities.Billing
{
    public class InvoicePayment: EntityBase<int>
    {
        public int InvoiceId { get; set; }
        public double Amount { get; set; }

        public Invoice Invoice { get; set; }
    }
}
