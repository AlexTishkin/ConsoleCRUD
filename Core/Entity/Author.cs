using Core.Entity;
using System;

namespace Core
{
    public class Author : DictionaryEntity
    {
        public Author() { }

        public Author(Guid id, string name) : base(id, name) { }
    }
}
