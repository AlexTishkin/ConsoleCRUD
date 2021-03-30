using Autofac;
using ConsoleApp.MenuManage;
using Core;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Application
    {
        private IContainer _container;
        private Configuration _configuration;

        public async Task RunAsync()
        {
            Configure();
            var menuContext = _container.Resolve<IMenuContext>();
            menuContext.Menu = new EntityChooseMenu(menuContext);
            menuContext.Container = _container;

            while (true)
            {
                await menuContext.Menu.Show();
                await menuContext.Menu.ExecuteCommand();
            }
        }

        private void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ApplicationModule>();
            _container = builder.Build();

            var configJson = File.ReadAllText(Resources.Resources.Configuration_File_Path);
            _configuration = JsonConvert.DeserializeObject<Configuration>(configJson);
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            var dbFactory = _container.Resolve<IDbFactory>();
            dbFactory.SetConnectionString(_configuration.ConnectionString);

            var initializer = _container.Resolve<DbInitializer>();
            initializer.Initialize();
        }
    }
}