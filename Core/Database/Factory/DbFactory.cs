namespace Core
{
    public class DbFactory : IDbFactory
    {
        private string _connectionString;

        public IAppContext CreateDb()
        {
            return new AppContext(_connectionString);
        }

        public void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

    }
}
