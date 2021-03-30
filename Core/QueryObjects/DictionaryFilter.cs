namespace Core.QueryObjects
{
    public class DictionaryFilter
    {
        public string Name { get; set; }

        public DictionaryFilter() { }
        public DictionaryFilter(string name)
        {
            Name = name;
        }
    }
}
