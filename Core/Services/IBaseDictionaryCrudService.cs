using Core.Entity;
using Core.QueryObjects;
using Core.ResultObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Database
{
    public interface IBaseDictionaryCrudService<TEntity> where TEntity : DictionaryEntity
    {
        Task<IList<TEntity>> GetListAsync();

        Task<PagedResult<TEntity>> GetListAsync(Query<DictionaryFilter> query);

        Task<TEntity> GetByIdAsync(Guid id);

        Task<TEntity> SaveAsync(TEntity dto);

        Task DeleteAsync(Guid id);
    }
}
