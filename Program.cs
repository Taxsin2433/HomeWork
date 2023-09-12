using HwCreateGame.HwCreateGame.Logger;
using HwCreateGame.Logger;
public class Program
{
    public static void Main(string[] args)
    {
        Logger.Instance.SetLogLevel(LogLevel.Info);
        Starter.Run(100);
    }
}
