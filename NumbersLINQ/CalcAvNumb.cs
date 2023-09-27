using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwCreateGame.EasyLINQ
{
    public class CalcAvNumb
    {
        private int[] numbers;

        public CalcAvNumb(int[] numbers)
        {
            this.numbers = numbers;
        }

        public void Execute()
        {
            var average = numbers.Average();
            Console.WriteLine($"Среднее значение всех чисел: {average}");
            Console.WriteLine();
        }
    }

}
