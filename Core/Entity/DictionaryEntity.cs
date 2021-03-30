using System;

namespace Core.Entity
{
    public class DictionaryEntity : Entity
    {
        public string Name { get; set; }

        public DictionaryEntity() { }

        public DictionaryEntity(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}
