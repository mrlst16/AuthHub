using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Emails
{
    public interface IBillingEmailService
    {
        Task SendPaymentReadyEmail(string toEmail, string linkToInvoice);
    }
}
