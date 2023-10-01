using System;
using HwCreateGame;

namespace HwCreateGame
{
    public class Fibonacci
    {
        static int F(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            else
            {
                return F(n - 1) + F(n - 2);
            }
        }

        public static void Calc()
        {
            int count = 20;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(F(i));
            }
        }
    }
}
