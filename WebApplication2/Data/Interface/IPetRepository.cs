public interface IPetRepository : IRepository<Pet>
{
}

public class PetRepository : Repository<Pet>, IPetRepository
{
    public PetRepository(ApplicationDbContext context) : base(context)
    {
    }
}