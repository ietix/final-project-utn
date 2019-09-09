using AdquisitionWebApi.Models;
using System.Data.Entity;

namespace AdquisitionWebApi.ApiDbContext
{
  public class SQLiteContext : DbContext
  {
    public SQLiteContext() : base("name=AdqDb") { }

    public DbSet<Analysis> Analyses { get; set; }
    public DbSet<Diagnostic> Diagnostics { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarPerCustomer> CarsPerCustomers { get; set; }
    public DbSet<Customer> Customers { get; set; }

  }
}