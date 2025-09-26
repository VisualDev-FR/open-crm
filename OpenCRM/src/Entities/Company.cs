namespace OpenCRM.Entities;


public class Company
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public RelationType RelationshipType { get; set; } = RelationType.none;

    public string ERPCode { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string Comment { get; set; } = string.Empty;

    public BillingInfo? BillingInfo { get; set; } = null;
}