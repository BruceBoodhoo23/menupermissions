namespace MenuPermissions._OriginalCode
{
    static class MenuLogic
    {
        public static async Task<Dictionary<int, string>> ReadMenuFileAsync(string menuFile)
        {
            if (!File.Exists(menuFile))
                throw new FileNotFoundException($"The file {menuFile} was not found.");

            var menus = new Dictionary<int, string>();
            var lines = await File.ReadAllLinesAsync(menuFile);

            foreach (var line in lines)
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