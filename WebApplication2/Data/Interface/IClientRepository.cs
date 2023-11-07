public interface IClientRepository : IRepository<Client>
{
}

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(ApplicationDbContext context) : base(context)
    {
    }
}