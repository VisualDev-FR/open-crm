namespace OpenCRM.Entities;


public class BillingInfo
{
    public long Id { get; set; }

    public string BillingName { get; set; } = string.Empty;

    public string BillingAddress { get; set; } = string.Empty;

    public string BillingPostalCode { get; set; } = string.Empty;

    public string BillingCity { get; set; } = string.Empty;

    public string BillingCountry { get; set; } = string.Empty;

    public string VATNumber { get; set; } = string.Empty;
}