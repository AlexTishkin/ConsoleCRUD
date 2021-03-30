using Core.Database;
using Core.Entity;
using System;
using System.Threading.Tasks;

namespace ConsoleApp.MenuManage.CrudMenu.Commands
{
    public class GetEntityCommand<TEntity> : ICommand where TEntity : DictionaryEntity, new()
    {
        private IBaseDictionaryCrudService<TEntity> _service;

        public GetEntityCommand(IBaseDictionaryCrudService<TEntity> service)
        {
            _service = service;
        }

        public async Task Execute()
        {
            Console.WriteLine("Получение сущности по Id");

            Console.Write("Id: ");
            var id = Guid.Parse(Console.ReadLine());

            var entity = await _service.GetByIdAsync(id);
            Console.WriteLine($"ID: {entity.Id}, Name: {entity.Name}");

            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
