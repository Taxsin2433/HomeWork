using HwCreateGame;

public class ConsoleManager : IConsoleManager
{
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}