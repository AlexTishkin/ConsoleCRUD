namespace Core.QueryObjects
{
    public class Query<TFilter>
    {
        public Pagination Pagination { get; set; }
        public TFilter Filter { get; set; }
    }
}
