using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwCreateGame.EasyLINQ
{
    public class MoreThanAv
    {
        private int[] numbers;

        public MoreThanAv(int[] numbers)
        {
            this.numbers = numbers;
        }

        public void Execute()
        {
            var average = numbers.Average();
            var result = numbers.Where(x => x > average);
            Console.WriteLine("Числа больше среднего значения:");
            PrintArray(result);
            Console.WriteLine();
        }

        private void PrintArray(IEnumerable<int> array)
        {
            foreach (var number in array)
            {
                Console.WriteLine(number);
            }
        }
    }
}
