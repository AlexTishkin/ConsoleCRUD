using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Database
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
