using Core;
using Core.Entity;
using Core.QueryObjects;
using Core.ResultObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BaseDictionaryCrudService<TEntity> : IBaseDictionaryCrudService<TEntity> where TEntity : DictionaryEntity
    {
        private IDbFactory _dbFactory;

        public BaseDictionaryCrudService(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<IList<TEntity>> GetListAsync()
        {
            using var db = _dbFactory.CreateDb();
            var entities = await db.Set<TEntity>().ToListAsync();
            return entities;
        }

        public async Task<PagedResult<TEntity>> GetListAsync(Query<DictionaryFilter> query)
        {
            using var db = _dbFactory.CreateDb();

            // Сортировка
            var q = db.Set<TEntity>()
                .OrderBy(x => x.Name)
                .AsQueryable();

            // Фильтр
            if (query.Filter?.Name != null)
                q = q.Where(x => x.Name.Contains(query.Filter.Name));

            var count = await q.CountAsync().ConfigureAwait(false);

            // Пагинация
            var entities = await q
                .Skip(query.Pagination.Skip)
                .Take(query.Pagination.Take)
                .ToListAsync();

            var result = new PagedResult<TEntity>
            {
                Result = entities,
                Pagination = query.Pagination,
                Total = count
            };
            return result;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            using (var db = _dbFactory.CreateDb())
            {
                var entity = await db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                    throw new ArgumentException($"Сущность с id={id} отсутствует в базе данных");
                return entity;
            }
        }

        public async Task<TEntity> SaveAsync(TEntity dto)
        {
            var isNew = dto.Id == Guid.Empty;

            using (var db = _dbFactory.CreateDb())
            {
                if (isNew)
                {
                    dto.Id = Guid.NewGuid();
                    db.Set<TEntity>().Add(dto);
                    await db.SaveChangesAsync();
                    return dto;
                }

                var entity = await db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == dto.Id);
                if (entity == null)
                    throw new ArgumentException($"Сущность с id={dto.Id} отсутствует в базе данных");
                entity.Name = dto.Name;
                await db.SaveChangesAsync();
                return dto;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using (var db = _dbFactory.CreateDb())
            {
                var entity = await db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                    throw new ArgumentException($"Сущность с id={id} отсутствует в базе данных");
                db.Set<TEntity>().Remove(entity);
                await db.SaveChangesAsync();
            }
        }
    }
}
