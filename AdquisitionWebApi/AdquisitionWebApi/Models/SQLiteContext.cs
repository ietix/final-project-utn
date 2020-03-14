using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AdquisitionWebApi.Models
{
  public class SQLiteContext : DbContext
  {
    #region Private Fields

    private static SQLiteContext _context;

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

    #region Public Methods

    public static SQLiteContext GetInstance()
    {
      if (_context == null)
      {
        _context = new SQLiteContext();
      }

      return _context;
    }

    #endregion

    #region Constructors

    public SQLiteContext() : base("AdqDb")
    {
      Database.SetInitializer<SQLiteContext>(null);
    }

    #endregion

    #region Private Methods

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }

    #endregion
  }
}