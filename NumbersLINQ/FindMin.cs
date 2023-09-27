using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwCreateGame.EasyLINQ
{
    public class FindMin
    {
        private int[] numbers;

        public FindMin(int[] numbers)
        {
            this.numbers = numbers;
        }

        public void Execute()
        {
            var minNumber = numbers.Min();
            Console.WriteLine($"Минимальное число: {minNumber}");
            Console.WriteLine();
        }
    }
}
