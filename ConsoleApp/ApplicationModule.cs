using Autofac;
using ConsoleApp.MenuManage;
using Core;
using Core.Database;

namespace ConsoleApp
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Application>();
            builder.RegisterType<DbInitializer>();

            builder.RegisterType<MenuContext>().As<IMenuContext>();
            builder.RegisterType<DbFactory>().As<IDbFactory>();

            builder.RegisterType<BaseDictionaryCrudService<Genre>>().As<IBaseDictionaryCrudService<Genre>>();
            builder.RegisterType<BaseDictionaryCrudService<Author>>().As<IBaseDictionaryCrudService<Author>>();
        }
    }
}