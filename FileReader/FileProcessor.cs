using MenuPermissions.FileReader.Interfaces;

public class FileProcessor
{
    private readonly IFileReaderStrategy _fileReaderStrategy;

    public FileProcessor(IFileReaderStrategy fileReaderStrategy)
    {
        _fileReaderStrategy = fileReaderStrategy ?? throw new ArgumentNullException(nameof(fileReaderStrategy));
    }

    public IAsyncEnumerable<string> ProcessFileAsync(string filePath)
    {
        return _fileReaderStrategy.ReadFileAsync(filePath);
    }
}