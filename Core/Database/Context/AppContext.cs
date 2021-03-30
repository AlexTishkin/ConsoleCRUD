using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class AppContext : DbContext, IAppContext
    {
        private readonly string _connectionString;

        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public AppContext()
        {
            _connectionString = "Data Source=DESKTOP-PS8UI7T;Initial Catalog=book_database;Integrated Security=True";
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbContext InnerContext => this;
    }
}
