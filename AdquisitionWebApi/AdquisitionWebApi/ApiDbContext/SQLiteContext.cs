using AdquisitionWebApi.Models;
using System.Data.Entity;

namespace AdquisitionWebApi.ApiDbContext
{
  public class SQLiteContext : DbContext
  {
    public SQLiteContext() : base("name=AdqDb") { }

    public DbSet<Analysis> Analyses { get; set; }
    public DbSet<Diagnostic> Diagnostics { get; set; }
  }
}