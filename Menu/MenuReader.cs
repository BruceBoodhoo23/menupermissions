using MenuPermissions.FileReader.Interfaces;
using MenuPermissions.Utils;

namespace MenuPermissions.Menu
{
    public class MenuReader : IMenuReader
    {
        private readonly IFileReaderStrategy _fileReaderStrategy;

        public MenuReader(IFileReaderStrategy fileReaderStrategy)
        {
            _fileReaderStrategy = fileReaderStrategy ?? throw new ArgumentNullException(nameof(fileReaderStrategy));
        }

        public async Task<Dictionary<int, string>> ParseMenuAsync(string filePath)
        {
            FileExistenceValidatorUtil.ValidateFileExists(filePath);

            var menus = new Dictionary<int, string>();
            await foreach (var line in _fileReaderStrategy.ReadFileAsync(filePath))
            {
                var parts = line.Split(", ");
                int menuId = int.Parse(parts[0]);
                string menuName = parts[1].Trim();
                menus[menuId] = menuName;
            }

            return menus;
        }
    }

}
