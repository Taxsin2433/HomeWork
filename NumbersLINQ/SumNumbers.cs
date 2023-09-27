using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwCreateGame.EasyLINQ
{
    public class SumNumbers
    {
        private int[] numbers;

        public SumNumbers(int[] numbers)
        {
            this.numbers = numbers;
        }

        public void Execute()
        {
            var sum = numbers.Sum();
            Console.WriteLine($"Сумма всех чисел: {sum}");
            Console.WriteLine();
        }
    }

}
