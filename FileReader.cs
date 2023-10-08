using System.IO;
using System.Threading.Tasks;

public class FileReader
{
    public async Task<string> ReadFileAsync(string fileName)
    {
        try
        {
            return await File.ReadAllTextAsync(fileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла {fileName}: {ex.Message}");
            return string.Empty;
        }
    }
}
