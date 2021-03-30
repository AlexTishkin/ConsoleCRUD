using Autofac;

namespace ConsoleApp.MenuManage
{
    public class MenuContext : IMenuContext
    {
        public IMenu Menu { get; set; }

        public IContainer Container { get; set; }
    }
}
