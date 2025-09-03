using Architecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<GameMap> Maps { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
