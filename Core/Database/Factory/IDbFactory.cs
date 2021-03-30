namespace Core
{
    public interface IDbFactory
    {
        IAppContext CreateDb();

        void SetConnectionString(string connectionString);
    }
}
