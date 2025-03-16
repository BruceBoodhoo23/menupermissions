namespace MenuPermissions.Utils
{
    public static class FileExistenceValidatorUtil
    {
        public static void ValidateFileExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file {filePath} was not found.");
            }
        }
    }
}
