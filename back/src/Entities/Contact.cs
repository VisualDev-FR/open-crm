namespace OpenCRM.Entities;

public class Contact
{
    public int Id { get; set; }

    public string Nom { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public Company? Company = null;
}
