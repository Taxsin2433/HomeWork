public interface IClientSettingsRepository : IRepository<ClientSettings>
{
}

public class ClientSettingsRepository : Repository<ClientSettings>, IClientSettingsRepository
{
    public ClientSettingsRepository(ApplicationDbContext context) : base(context)
    {
    }
}
