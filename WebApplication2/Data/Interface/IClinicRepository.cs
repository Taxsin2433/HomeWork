public interface IClinicRepository : IRepository<Clinic>
{
}

public class ClinicRepository : Repository<Clinic>, IClinicRepository
{
    public ClinicRepository(ApplicationDbContext context) : base(context)
    {
    }
}