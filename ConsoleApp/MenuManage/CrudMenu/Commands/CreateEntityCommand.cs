using Core.Database;
using Core.Entity;
using System;
using System.Threading.Tasks;

namespace ConsoleApp.MenuManage.CrudMenu.Commands
{
    public class CreateEntityCommand<TEntity> : ICommand where TEntity : DictionaryEntity, new()
    {
        private IBaseDictionaryCrudService<TEntity> _service;

        public CreateEntityCommand(IBaseDictionaryCrudService<TEntity> service)
        {
            _service = service;
        }

        public async Task Execute()
        {
            Console.WriteLine("Создание сущности");

            Console.Write("Имя: ");
            string name = Console.ReadLine();

            await _service.SaveAsync(new TEntity { Name = name });
        }
    }
}
