using Architecture.Domain;

namespace Architecture.Services
{
    public interface IMapService
    {
        Task<List<GameMap>> GetMapsAsync();
        Task AddMapAsync(string name);
    }
}
