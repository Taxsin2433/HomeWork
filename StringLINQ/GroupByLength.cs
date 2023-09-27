using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwCreateGame.StringLINQ
{
    public class GroupByLength
    {
        private string[] words;

        public GroupByLength(string[] words)
        {
            this.words = words;
        }

        public void Execute()
        {
            var groupedWords = words.GroupBy(word => word.Length);

            foreach (var group in groupedWords)
            {
                Console.WriteLine($"Слова длиной {group.Key} символов:");
                PrintArray(group);
             
            }
        }

        private void PrintArray(IEnumerable<string> array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }
    }
}
