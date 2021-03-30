using Core.Entity;
using System;

namespace Core
{
    public class Genre : DictionaryEntity
    {
        public Genre() { }

        public Genre(Guid id, string name) : base(id, name) { }
    }
}
