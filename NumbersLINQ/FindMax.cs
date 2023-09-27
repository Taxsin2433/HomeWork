using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwCreateGame.EasyLINQ
{
    public class FindMax
    {
        private int[] numbers;

        public FindMax(int[] numbers)
        {
            this.numbers = numbers;
        }

        public void Execute()
        {
            var maxNumber = numbers.Max();
            Console.WriteLine($"Максимальное число: {maxNumber}");
            Console.WriteLine();
        }
    }
}
