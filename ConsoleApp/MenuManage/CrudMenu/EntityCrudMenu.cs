using ConsoleApp.MenuManage.CrudMenu;
using Core.Entity;
using System;
using System.Threading.Tasks;

namespace ConsoleApp.MenuManage
{
    public class EntityCrudMenu<TEntity> : IMenu where TEntity : DictionaryEntity, new()
    {
        private IMenuContext _menuContext;
        private CommandServiceInvoker<TEntity> _serviceInvoker;

        public EntityCrudMenu(IMenuContext menuContext)
        {
            _menuContext = menuContext;
            _serviceInvoker = new CommandServiceInvoker<TEntity>(_menuContext);
        }

        public async Task Show()
        {
            Console.Clear();

            Console.WriteLine($"Список сущностей заданного типа");
            await _serviceInvoker.ShowEntitiesAsync();

            Console.WriteLine("\nCRUD меню для работы с сущностями");
            Console.WriteLine($"1 - Создать сущность");
            Console.WriteLine($"2 - Редактировать сущность");
            Console.WriteLine($"3 - Удалить сущность");
            Console.WriteLine($"4 - Получить сущность по ID");
            Console.WriteLine($"5 - Вернуться к выбору сущностей");
        }

        public async Task ExecuteCommand()
        {
            Console.Write("Операция: ");
            string commandNum = Console.ReadLine();

            try
            {
                var command = _serviceInvoker.CreateCommand(commandNum);
                await _serviceInvoker.ExecuteCommand(command);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Некорректная команда");
            }
        }
    }
}
