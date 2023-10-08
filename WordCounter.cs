public class WordCounter
{
    public Dictionary<string, int> CountWords(List<string> words)
    {
        var wordCounts = new Dictionary<string, int>();

        foreach (var word in words)
        {
            wordCounts[word] = wordCounts.ContainsKey(word) ? wordCounts[word] + 1 : 1;
        }

        return wordCounts;
    }
}
