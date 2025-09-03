using Architecture.Data;
using Architecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Services
{
    public class MapService : IMapService
    {
        private readonly ApplicationDbContext _db;

        public MapService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<GameMap>> GetMapsAsync()
        {
            return await _db.Maps.ToListAsync();
        }

        public async Task AddMapAsync(string name)
        {
            _db.Maps.Add(new GameMap { Name = name });
            await _db.SaveChangesAsync();
        }
    }
}
