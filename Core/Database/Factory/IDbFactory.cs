namespace Core
{
    public interface IDbFactory
    {
        IAppContext CreateDb();
    }
}
