using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class AppContext : DbContext, IAppContext
    {
        private readonly string _connectionString;

        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public AppContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbContext InnerContext => this;
    }
}
