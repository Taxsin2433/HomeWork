using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwCreateGame.StringLINQ
{
    public class UniqueChar
    {
        private string[] words;

        public UniqueChar(string[] words)
        {
            this.words = words;
        }

        public void Execute()
        {
            var uniqueCharacters = words.SelectMany(word => word.ToLower()).Distinct();
            Console.WriteLine("Уникальные символы в заданных словах:");
            PrintArray(uniqueCharacters);
            Console.WriteLine();
        }

        private void PrintArray(IEnumerable<char> array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
