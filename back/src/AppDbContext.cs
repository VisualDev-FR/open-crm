using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenCRM.Entities;

namespace OpenCRM;

public class AppDbContext : IdentityDbContext<OpenCrmUser, OpenCrmRole, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<BillingInfo> BillingInfos { get; set; }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Contact> Contacts { get; set; }
}