using MenuPermissions.FileReader.Interfaces;
using MenuPermissions.Utils;

namespace MenuPermissions.Users
{
    public class UserMapper : IUserMapper
    {
        private readonly IFileReaderStrategy _fileReaderStrategy;

        public UserMapper(IFileReaderStrategy fileReaderStrategy)
        {
            _fileReaderStrategy = fileReaderStrategy ?? throw new ArgumentNullException(nameof(fileReaderStrategy));
        }

        public async IAsyncEnumerable<UserResultModel> MapPermissionsToMenusAsync(string userFile, Dictionary<int, string> menus)
        {
            FileExistenceValidatorUtil.ValidateFileExists(userFile);

            var userLines = _fileReaderStrategy.ReadFileAsync(userFile);
            var userResults = new List<UserResultModel>();

            await foreach (var userLine in userLines)
            {
                var user = UserHelper.ParseUser(userLine);

                // Source for Linq logic: Copilot
                var menuItems = user.Permissions
                    .Select((permission, index) => (permission, index))
                    .Where(pair => pair.permission == 'Y' && menus.ContainsKey(pair.index + 1))
                    .Select(pair => menus[pair.index + 1])
                    .ToList();

                yield return new UserResultModel
                {
                    UserName = user.UserName,
                    MenuItems = menuItems
                };
            }
        }
    }
}
