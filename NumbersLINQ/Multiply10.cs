using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwCreateGame.EasyLINQ
{
    public class Multiply10
    {
        private int[] numbers;

        public Multiply10(int[] numbers)
        {
            this.numbers = numbers;
        }

        public void Execute()
        {
            var result = numbers.Where(x => x > 10).Select(x => x * 10);
            Console.WriteLine("Числа больше 10, умноженные на 10:");
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
