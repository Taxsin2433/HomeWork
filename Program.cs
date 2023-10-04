public class Program
{
    public static async Task<string> HelloAsync()
    {
        string filePath = "Hello.txt";
        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = File.CreateText(filePath)) 
            {
                await writer.WriteLineAsync("Hello");
            }
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            return await reader.ReadToEndAsync();
        }
    }

    public static async Task<string> WorldAsync()
    {
        string filePath = "World.txt";
        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = File.CreateText(filePath))
            {
                await writer.WriteLineAsync("World");
            }
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            return await reader.ReadToEndAsync();
        }
    }

    public static async Task<string> TextAsync()
    {
        Task<string> helloTask = HelloAsync();
        Task<string> worldTask = WorldAsync();

        await Task.WhenAll(helloTask, worldTask);

        string helloText = await helloTask;
        string worldText = await worldTask;

        return helloText + worldText;
    }

    public static async Task Main()
    {
        string result = await TextAsync();
        Console.WriteLine(result);
    }
}
