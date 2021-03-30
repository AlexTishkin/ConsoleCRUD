using Autofac;
using ConsoleApp.MenuManage.CrudMenu.Commands;
using Core.Database;
using Core.Entity;
using System;
using System.Threading.Tasks;

namespace ConsoleApp.MenuManage.CrudMenu
{
    /// <summary>
    /// Прослойка для работы с сервисом
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class CommandServiceInvoker<TEntity> where TEntity : DictionaryEntity, new()
    {
        private IBaseDictionaryCrudService<TEntity> _service;
        private IMenuContext _menuContext;

        public CommandServiceInvoker(IMenuContext menuContext)
        {
            _service = menuContext.Container.Resolve<IBaseDictionaryCrudService<TEntity>>();
            _menuContext = menuContext;
        }

        public async Task ShowEntitiesAsync()
        {
            var entities = await _service.GetListAsync().ConfigureAwait(false);
            foreach (var entity in entities)
                Console.WriteLine($"{entity.Id}: {entity.Name}");
        }

        public ICommand CreateCommand(string num)
        {
            if (num == "1") return new CreateEntityCommand<TEntity>(_service);
            if (num == "2") return new EditEntityCommand<TEntity>(_service);
            if (num == "3") return new DeleteEntityCommand<TEntity>(_service);
            if (num == "4") return new GetEntityCommand<TEntity>(_service);
            if (num == "5") return new ReturnCommand(_menuContext);
            throw new ArgumentException("Некорректный номер num");
        }

        public async Task ExecuteCommand(ICommand operationCommand) => await operationCommand.Execute();

    }
}
