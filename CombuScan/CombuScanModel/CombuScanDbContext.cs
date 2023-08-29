using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CombuScanModel
{
  public class CombuScanDbContext : DbContext
  {
    #region Private Fields
    protected readonly IConfiguration config;
    #endregion

    #region Public Properties

    public DbSet<Analysis> Analyses { get; set; }
    public DbSet<Diagnostic> Diagnostics { get; set; }
    public DbSet<DiagnosticType> DiagnosticTypes { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<FailureType> FailureTypes { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarPerCustomer> CarsPerCustomers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactType> ContactTypes { get; set; }
    public DbSet<User> Users { get; set; }

    #endregion

    #region Constructors
    public CombuScanDbContext(IConfiguration configuration)
    {
      config = configuration;
    }
    #endregion

    #region Private Methods

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite(config.GetConnectionString("CombuScan") ?? "DataSource=..\\DB\\AdqDb.db", null);
    }

    #endregion
  }
}