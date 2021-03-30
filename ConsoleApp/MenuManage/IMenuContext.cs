using Autofac;

namespace ConsoleApp.MenuManage
{
    public interface IMenuContext
    {
        IMenu Menu { get; set; }

        IContainer Container { get; set; }
    }
}
