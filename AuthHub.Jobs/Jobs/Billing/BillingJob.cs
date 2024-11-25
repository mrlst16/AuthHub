using AuthHub.DAL.EntityFramework;
using AuthHub.Interfaces.Jobs;
using Microsoft.Extensions.Configuration;

namespace AuthHub.Jobs.Jobs.Billing
{
    public class BillingJob : IJob
    {
        private readonly AuthHubContext _context;
        private readonly IConfiguration _configuration;
        private int DayOfTheMonth { get; set; }

        public BillingJob(
            AuthHubContext context,
            IConfiguration configuration,
            int dayOfTheMonth
            )
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task RunAsync()
        {
            var organizationIdsCreatedThisDayOfTheMonth
                = _context.Organizations
                    .Where(x => x.CreateDate.Value.Day == DayOfTheMonth)
                    .Select(x => x.Id)
                    .ToList();

            var organizationToUserCount = _context.Users
                .Where(
                    x => organizationIdsCreatedThisDayOfTheMonth.Contains(x.OrganizationId)
                        && x.DeletedUTC == null
                    )
                .GroupBy(x => x.OrganizationId)
                .ToDictionary(k => k.Key, v => v.Count());

            double pricePerUser = _configuration.GetValue<double>("AppSettings:PricePerUser");

            foreach (var orgAndUserCount in organizationToUserCount)
            {
                if (orgAndUserCount.Value == 0)
                    continue;

                //Calculate the amount
                double billingAmount = orgAndUserCount.Value * pricePerUser;

                //Create a draft invoice

                //Send the invoice

                //Record the invoice in our database

                //Send an email to the client with a link to the invoice to verify that they are aware of it

            }
        }

        private Invoice CreateInvoiceAsync(int organizationId, double amount)
        {
            Invoice invoice = new Invoice();
            invoice.Amount = new Amount()
            {

            };
            return invoice;
        }
    }
}
