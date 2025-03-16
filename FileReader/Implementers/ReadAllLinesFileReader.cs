// Concrete Strategy for Reading All Lines at Once
using MenuPermissions.FileReader.Interfaces;

public class ReadAllLinesFileReader : IFileReaderStrategy
{
    public async IAsyncEnumerable<string> ReadFileAsync(string filePath)
    {
        var lines = await File.ReadAllLinesAsync(filePath);
        foreach (var line in lines)
        {
            yield return line;
        }
    }
}
