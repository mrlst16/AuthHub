using AuthHub.DAL.EntityFramework;
using AuthHub.Interfaces.Jobs;
using AuthHub.Jobs.Models.Billing.Paypal;
using AuthHub.Models.Entities.Billing;
using AuthHub.Models.Entities.Organizations;
using Common.Interfaces.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AuthHub.Jobs.Jobs.Billing
{
    public class BillingJob : IJob
    {
        private readonly AuthHubContext _context;
        private readonly IConfiguration _configuration;
        private readonly IDateProvider _dateProvider;
        private readonly IPaypalClient _paypalClient;

        private int DayOfTheMonth;
        private int LastDailyInvoiceNumber;
        private double PricePerUser;

        public BillingJob(
            AuthHubContext context,
            IConfiguration configuration,
            IDateProvider dateProvider,
            IPaypalClient paypalClient
            )
        {
            _context = context;
            _configuration = configuration;
            _dateProvider = dateProvider;
            _paypalClient = paypalClient;

            DayOfTheMonth = _dateProvider.UTCNow.Day;
            PricePerUser = _configuration.GetValue<double>("AppSettings:PricePerUser");

        }

        public async Task RunAsync()
        {
            GetLatestDailyInvoiceNumber();
            //Get the organizations whose bills are due on this day of the month
            var organizations
                = _context.Organizations
                    .Include(x=> x.Users)
                    .Where(x => 
                        x.CreateDate.Value.Day == DayOfTheMonth
                        && x.DeletedUTC == null
                        && x.Users.Any()
                        )
                    .ToList();

            foreach (var organization in organizations)
            {

                //Create a draft invoice
                var paypalInvoice = CreateInvoiceAsync(organization);
                CreateDraftResponse createDraftResponse = await _paypalClient.CreateDraftInvoiceAsync(paypalInvoice);
                //Send the invoice
                SendInvoiceResponse sendInvoiceResponse = await _paypalClient.SendInvoiceAsync(createDraftResponse.Id);
                //Record the invoice in our database
                Invoice invoiceEntity = new Invoice()
                {
                    OrganizationId = organization.Id,
                    ExternalInvoiceId = createDraftResponse.Id,
                    InvoiceDateUTC = DateOnly.FromDateTime(_dateProvider.UTCNow),
                    InvoiceNumber = paypalInvoice.Detail.InvoiceNumber,
                    ExternalInvoiceLink = sendInvoiceResponse.Href
                };
                _context.Invoices.Add(invoiceEntity);
                await _context.SaveChangesAsync();
                //Send an email to the client with a link to the invoice to verify that they are aware of it

                //Increment the invoice number
                LastDailyInvoiceNumber++;
            }
        }

        private PaypalInvoice CreateInvoiceAsync(Organization organization)
        {
            var numberOfUsers = organization.Users.Count();
            PaypalInvoice paypalInvoice = new PaypalInvoice()
            {
                Detail = new InvoiceDetail()
                {
                    CurrencyCode = "USD",
                    InvoiceDate = _dateProvider.UTCNow.Date.ToString("yyyy-MM-dd"),
                    InvoiceNumber = GenerateInvoiceNumber()
                },
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Description = $"Monthly charge for management of {numberOfUsers} Users",
                        Quantity = numberOfUsers,
                        UnitAmount = new UnitAmount()
                        {
                            CurrencyCode = "USD",
                            Value = numberOfUsers * PricePerUser
                        },
                        Name = "User Management",
                        UnitOfMeasure = "QUANTITY"
                    }
                },
                Invoicer = new Invoicer()
                {
                    Name = new Name()
                    {
                        GivenName = "Matthew",
                        Surname = "Lantz"
                    },
                    Address = new Address()
                    {
                        AddressLine1 = "1206 Tee Ct",
                        AdminArea1 = "Presto",
                        AdminArea2 = "PA",
                        PostalCode = "15142",
                        CountryCode = "US"
                    },
                    EmailAddress = "mrlst16-facilitator@mail.rmu.edu",
                    Website = "www.buzzauth.com",
                },
                PrimaryRecipients = new List<PrimaryRecipient>()
                {
                    new PrimaryRecipient()
                    {
                        BillingInfo = new BillingInfo()
                        {
                            EmailAddress = organization.Email
                        }
                    }
                }
            };
            return paypalInvoice;
        }

        private void GetLatestDailyInvoiceNumber()
        {
            var invoicesThisDay = _context.Invoices
                .Where(x => x.InvoiceDateUTC == DateOnly.FromDateTime(_dateProvider.UTCNow))
                .ToList();
            if (!invoicesThisDay.Any())
            {
                LastDailyInvoiceNumber = 0;
                return;
            }
            LastDailyInvoiceNumber =
                invoicesThisDay
                    .Select(x=> x.InvoiceNumber)
                    .Select(x => int.Parse(x.Substring(x.Length - 4)))
                    .OrderByDescending(x => x)
                    .First();
        }

        private string GenerateInvoiceNumber()
            => $"buzzauth{_dateProvider.UTCNow.ToString("MMddyyy")}{PadWithZerosInFront(LastDailyInvoiceNumber+1, 5)}";

        static string PadWithZerosInFront(int number, int totalSpaces)
        {
            string result = number.ToString();
            int padCount = totalSpaces - result.Length;
            for (int i = 0; i < padCount; i++)
                result = '0' + result;
            return result;
        }
    }
}
