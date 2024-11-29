using System;
using System.Collections.Generic;
using AuthHub.Models.Entities.Organizations;
using Common.Models.Entities;

namespace AuthHub.Models.Entities.Billing
{
    public class Invoice : EntityBase<int>
    {
        public int OrganizationId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateOnly InvoiceDateUTC { get; set; }
        public string ExternalInvoiceId { get; set; }
        public string ExternalInvoiceLink { get; set; }

        public Organization Organization { get; set; }
        public List<InvoicePayment> Payments { get; set; }
    }
}