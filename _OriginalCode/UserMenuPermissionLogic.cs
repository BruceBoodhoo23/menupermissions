using MenuPermissions.Users;

namespace MenuPermissions._OriginalCode
{
    static class UserMenuPermissionLogic
    {
        public static async IAsyncEnumerable<UserResult> ReadUserFileAsync(string userFile, Dictionary<int, string> menus)
        {
            if (!File.Exists(userFile))
                throw new FileNotFoundException($"The file {userFile} was not found.");

            // Process the user file line by line (streaming)
            await foreach (var userLine in ReadFileLineByLineAsync(userFile))
            {
                var user = UserHelper.ParseUser(userLine);

                // Map permissions to menus
                var menuItems = user.Permissions
                                    .Select((permission, index) => (permission, index))
                                    .Where(pair => pair.permission == 'Y' && menus.ContainsKey(pair.index + 1))
                                    .Select(pair => menus[pair.index + 1])
                                    .ToList();

                yield return new UserResult
                {
                    UserName = user.UserName,
                    MenuItems = menuItems
                };
            }
        }

        private static async IAsyncEnumerable<string> ReadFileLineByLineAsync(string filePath)
        {
            using var reader = new StreamReader(filePath);
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                yield return line;
            }
        }
    }

    class UserResult
    {
        public string UserName { get; set; } = string.Empty;
        public List<string> MenuItems { get; set; } = [];
    }

    class Result
    {
        public List<UserResult> Users { get; set; } = []; // Initialize with an empty list
    }
}
