using Microsoft.EntityFrameworkCore;
using WinFormsApp5.Tables;

namespace WinFormsApp5
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Game> Games => Set<Game>();
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=database.db");
        }

    }
}
