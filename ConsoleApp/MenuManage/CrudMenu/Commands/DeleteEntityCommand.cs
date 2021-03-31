using Core.Entity;
using Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace ConsoleApp.MenuManage.CrudMenu.Commands
{
    public class DeleteEntityCommand<TEntity> : ICommand where TEntity : DictionaryEntity, new()
    {
        private IBaseDictionaryCrudService<TEntity> _service;

        public DeleteEntityCommand(IBaseDictionaryCrudService<TEntity> service)
        {
            _service = service;
        }

        public async Task Execute()
        {
            Console.WriteLine("Удаление сущности");

            Console.Write("Id: ");
            var id = Guid.Parse(Console.ReadLine());

            await _service.DeleteAsync(id);
        }
    }
}
