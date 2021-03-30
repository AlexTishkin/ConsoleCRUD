using System.Threading.Tasks;

namespace ConsoleApp.MenuManage
{
    public interface IMenu
    {
        Task Show();
        Task ExecuteCommand();
    }
}
