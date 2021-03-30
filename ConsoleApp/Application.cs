using Autofac;
using ConsoleApp.MenuManage;
using Core;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Application
    {
        private IContainer _container;

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
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            var initializer = _container.Resolve<DbInitializer>();
            initializer.Initialize();
        }
    }
}