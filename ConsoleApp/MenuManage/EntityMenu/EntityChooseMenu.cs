using Core;
using System;
using System.Threading.Tasks;

namespace ConsoleApp.MenuManage
{
    public class EntityChooseMenu : IMenu
    {
        private IMenuContext _menuManager;

        public EntityChooseMenu(IMenuContext menuManager)
        {
            _menuManager = menuManager;
        }

        public async Task Show()
        {
            Console.Clear();
            Console.WriteLine("Выберите сущность для работы");
            Console.WriteLine("1 - Жанр");
            Console.WriteLine("2 - Автор");
        }

        public async Task ExecuteCommand()
        {
            Console.Write("Выбранная сущность: ");
            string command = Console.ReadLine();

            if (command == "1" || command == "жанр") _menuManager.Menu = new EntityCrudMenu<Genre>(_menuManager);
            if (command == "2" || command == "автор") _menuManager.Menu = new EntityCrudMenu<Author>(_menuManager);
        }
    }
}
