
using Microsoft.EntityFrameworkCore;
using SQL.Models;

namespace EFCore1.Models;

public class EFCoreContext : DbContext
{
    public DbSet<Owner> Owners { get; private set; }

    public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

}
