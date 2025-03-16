using MenuPermissions.FileReader.Interfaces;

// Concrete Strategy for Line-by-Line Reading
namespace MenuPermissions.FileReader.Implementers
{
    internal class LineByLineFileReader : IFileReaderStrategy
    {
        public async IAsyncEnumerable<string> ReadFileAsync(string filePath)
        {
            using var reader = new StreamReader(filePath);
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                yield return line;
            }
        }
    }
}
