using AuthHub.Interfaces.Billing;
using AuthHub.Models.Entities.Billing;
using Microsoft.EntityFrameworkCore;

namespace AuthHub.DAL.EntityFramework.Billing
{
    public class BillingContext : IBillingContext
    {
        private readonly AuthHubContext _context;

        public BillingContext(
            AuthHubContext context
            )
        {
            _context = context;
        }

        public async Task RecordInvoicePayment(string eternalInvoiceId, double amount)
        {
            var invoice = await _context.Invoices
                .Include(x=> x.Payments)
                .FirstOrDefaultAsync(x => x.ExternalInvoiceId == eternalInvoiceId);
            
            if (invoice == null) throw new Exception("Invoice was not found");

            invoice.Payments.Add(new InvoicePayment()
            {
                Amount = amount
            });
            await _context.SaveChangesAsync();
        }
    }
}