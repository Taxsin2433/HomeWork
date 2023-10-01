using System;
using HwCreateGame.Fact;
namespace HwCreateGame.Fact;
class Factorial
{
    static int Fact(int n)
    {
        if (n == 0)
        {
            return 1;
        }
        else
        {
            return n * Fact(n - 1);
        }
    }

   public static void FactCalc()
    {
        int number = 5; 

        int result = Fact(number);

        Console.WriteLine("Факториал числа {0} равен {1}", number, result);
    }
}