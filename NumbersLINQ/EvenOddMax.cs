using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwCreateGame.EasyLINQ
{
    public class EvenOddMax
    {
        private int[] numbers;

        public EvenOddMax(int[] numbers)
        {
            this.numbers = numbers;
        }

        public void Execute()
        {
            var groupedNumbers = numbers.GroupBy(x => x % 2 == 0 ? "Even" : "Odd");

            foreach (var group in groupedNumbers)
            {
                var maxInGroup = group.Max();
                var groupName = group.Key;
                Console.WriteLine($"Максимальное число в группе {groupName}: {maxInGroup}");
                Console.WriteLine();
            }
        }
    }
}
