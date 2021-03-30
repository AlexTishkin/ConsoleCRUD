using System.Threading.Tasks;

namespace ConsoleApp.MenuManage.CrudMenu.Commands
{
    public class ReturnCommand : ICommand
    {
        private IMenuContext _context;

        public ReturnCommand(IMenuContext context)
        {
            _context = context;
        }

        public async Task Execute()
        {
            _context.Menu = new EntityChooseMenu(_context);
        }
    }
}
