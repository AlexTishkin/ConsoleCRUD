using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core
{
    public interface IAppContext : IDisposable
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Genre> Genres { get; set; }

        DbContext InnerContext { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
