using Core.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Database
{
    public interface IBaseDictionaryCrudService<TEntity> where TEntity : DictionaryEntity
    {
        Task<IList<TEntity>> GetListAsync();

        Task<TEntity> GetByIdAsync(Guid id);

        Task<TEntity> SaveAsync(TEntity dto);

        Task DeleteAsync(Guid id);
    }
}
