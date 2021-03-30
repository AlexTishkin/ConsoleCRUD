using Core.Entity;
using Core.QueryObjects;
using System.Collections.Generic;

namespace Core.ResultObjects
{
    public class PagedResult<TEntity> where TEntity : DictionaryEntity
    {
        public IList<TEntity> Result { get; set; }

        public Pagination Pagination { get; set; }

    }
}
