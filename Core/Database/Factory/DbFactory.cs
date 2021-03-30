namespace Core
{
    public class DbFactory : IDbFactory
    {
        public IAppContext CreateDb()
        {
            return new AppContext();
        }
    }
}
