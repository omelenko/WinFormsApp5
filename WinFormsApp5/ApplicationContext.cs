using Microsoft.EntityFrameworkCore;

namespace WinFormsApp5
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Team> Teams => Set<Team>();
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=database.db");
        }

    }
}
