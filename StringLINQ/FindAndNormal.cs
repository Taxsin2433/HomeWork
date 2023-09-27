namespace HwCreateGame.StringLINQ
{
    public class FindAndNormal
    {
        private string[] words;
        private string targetSubstring;

        public FindAndNormal(string[] words, string targetSubstring)
        {
            this.words = words;
            this.targetSubstring = targetSubstring;
        }

        public void Execute()
        {
            var filteredAndNormalizedWords = words
                .Where(word => word.Contains(targetSubstring))
                .GroupBy(word => word.Length)
                .Select(group => group.Select(word => NormalizeString(word)));

            Console.WriteLine($"Слова, содержащие подстроку '{targetSubstring}' и нормализованные:");
            foreach (var group in filteredAndNormalizedWords)
            {
                PrintArray(group);
                Console.WriteLine();
            }
        }

        private string NormalizeString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        private void PrintArray(IEnumerable<string> array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }

}
