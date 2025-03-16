using MenuPermissions.Interfaces;
using MenuPermissions.Menu;

namespace MenuPermissions.Commands
{
    public class ReadMenuCommand : ICommand
    {
        private readonly IMenuReader _menuReader;
        private readonly string _menuFilePath;
        private Dictionary<int, string> _parsedMenus;

        public ReadMenuCommand(IMenuReader menuReader, string menuFilePath)
        {
            _menuReader = menuReader ?? throw new ArgumentNullException(nameof(menuReader));
            _menuFilePath = menuFilePath ?? throw new ArgumentNullException(nameof(menuFilePath));
        }

        public Dictionary<int, string> GetParsedMenus() => _parsedMenus;

        public async Task ExecuteAsync()
        {
            _parsedMenus = await _menuReader.ParseMenuAsync(_menuFilePath);
        }
    }
}
