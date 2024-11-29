namespace AuthHub.Interfaces.Billing
{
    public interface IBillingContext
    {
        Task RecordInvoicePayment(string eternalInvoiceId, double amount);
    }
}
