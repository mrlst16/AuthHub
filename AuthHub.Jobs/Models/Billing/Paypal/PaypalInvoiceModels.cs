public class Invoice
{
    public InvoiceDetail Detail { get; set; }
    public Invoicer Invoicer { get; set; }
    public List<PrimaryRecipient> PrimaryRecipients { get; set; }
    public List<Item> Items { get; set; }
    public Amount Amount { get; set; }
}

public class InvoiceDetail
{
    public string InvoiceNumber { get; set; }
    public string Reference { get; set; }
    public string InvoiceDate { get; set; }
    public string CurrencyCode { get; set; }
    public string Note { get; set; }
    public string Term { get; set; }
    public string Memo { get; set; }
    public PaymentTerm PaymentTerm { get; set; }
}

public class PaymentTerm
{
    public string TermType { get; set; }
    public string DueDate { get; set; }
}

public class Invoicer
{
    public Name Name { get; set; }
    public Address Address { get; set; }
    public string EmailAddress { get; set; }
    public List<Phone> Phones { get; set; }
    public string Website { get; set; }
    public string TaxId { get; set; }
    public string LogoUrl { get; set; }
    public string AdditionalNotes { get; set; }
}

public class Name
{
    public string GivenName { get; set; }
    public string Surname { get; set; }
}

public class Address
{
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string AdminArea2 { get; set; }
    public string AdminArea1 { get; set; }
    public string PostalCode { get; set; }
    public string CountryCode { get; set; }
}

public class Phone
{
    public string CountryCode { get; set; }
    public string NationalNumber { get; set; }
    public string PhoneType { get; set; }
}

public class PrimaryRecipient
{
    public BillingInfo BillingInfo { get; set; }
    public ShippingInfo ShippingInfo { get; set; }
}

public class BillingInfo
{
    public Name Name { get; set; }
    public Address Address { get; set; }
    public string EmailAddress { get; set; }
    public List<Phone> Phones { get; set; }
    public string AdditionalInfoValue { get; set; }
}

public class ShippingInfo
{
    public Name Name { get; set; }
    public Address Address { get; set; }
}

public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Quantity { get; set; }
    public UnitAmount UnitAmount { get; set; }
    public Tax Tax { get; set; }
    public Discount Discount { get; set; }
    public string UnitOfMeasure { get; set; }
}

public class UnitAmount
{
    public string CurrencyCode { get; set; }
    public string Value { get; set; }
}

public class Tax
{
    public string Name { get; set; }
    public string Percent { get; set; }
    public string TaxNote { get; set; }
}

public class Discount
{
    public string Percent { get; set; }
    public Amount Amount { get; set; }
}

public class Amount
{
    public Breakdown Breakdown { get; set; }
}

public class Breakdown
{
    public Custom Custom { get; set; }
    public Shipping Shipping { get; set; }
    public Discount InvoiceDiscount { get; set; }
}

public class Custom
{
    public string Label { get; set; }
    public Amount Amount { get; set; }
}

public class Shipping
{
    public Amount Amount { get; set; }
    public Tax Tax { get; set; }
}
