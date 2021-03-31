using Autofac;
using ConsoleApp.MenuManage;
using Core;
using Infrastructure.Services;

namespace ConsoleApp
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Application>();
            builder.RegisterType<Configuration>();
            builder.RegisterType<DbInitializer>();

            builder.RegisterType<MenuContext>().As<IMenuContext>();

            builder.RegisterType<BaseDictionaryCrudService<Genre>>().As<IBaseDictionaryCrudService<Genre>>();
            builder.RegisterType<BaseDictionaryCrudService<Author>>().As<IBaseDictionaryCrudService<Author>>();

            builder.RegisterInstance(new DbFactory()).As<IDbFactory>();
        }
    }
}