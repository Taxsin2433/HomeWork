// File: Starter.cs
using HwCreateGame.Logger;
public static class Starter
{
    public static void Run(int n)
    {
        for (int i = 0; i < n; i++)
        {
            int action = Actions.random.Next(1, 4);
            switch (action)
            {
                case 1:
                    Actions.InfoAction();
                    break;
                case 2:
                    Actions.WarningAction();
                    break;
                case 3:
                    Actions.ErrorAction();
                    break;
            }
        }
    }
}