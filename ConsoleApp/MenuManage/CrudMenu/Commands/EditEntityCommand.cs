using Core.Entity;
using Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace ConsoleApp.MenuManage.CrudMenu.Commands
{
    public class EditEntityCommand<TEntity> : ICommand where TEntity : DictionaryEntity, new()
    {
        private IBaseDictionaryCrudService<TEntity> _service;

        public EditEntityCommand(IBaseDictionaryCrudService<TEntity> service)
        {
            _service = service;
        }

        public async Task Execute()
        {
            Console.WriteLine("Редактирование сущности");

            Console.Write("Id: ");
            var id = Guid.Parse(Console.ReadLine());

            Console.Write("Имя: ");
            string name = Console.ReadLine();

            await _service.SaveAsync(new TEntity { Id = id, Name = name });
        }
    }
}
