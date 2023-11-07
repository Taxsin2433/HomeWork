using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientSettings> ClientSettings { get; set; }
    public DbSet<Pet> Pets { get; set; }
}