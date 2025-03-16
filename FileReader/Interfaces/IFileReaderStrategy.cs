namespace MenuPermissions.FileReader.Interfaces
{
    public interface IFileReaderStrategy
    {
        IAsyncEnumerable<string> ReadFileAsync(string filePath);
    }
}
