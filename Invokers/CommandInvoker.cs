using MenuPermissions.Interfaces;
using System.Threading.Tasks;

namespace MenuPermissions.Invokers
{
    public class CommandInvoker
    {
        private readonly List<ICommand> _commands = new();

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public async Task ExecuteAllAsync()
        {
            foreach (var command in _commands)
            {
                await command.ExecuteAsync();
            }
        }
    }

}
