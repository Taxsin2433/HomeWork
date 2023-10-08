using System.Text.RegularExpressions;

public class WordProcessor
{
    public List<string> ExtractWords(string text)
    {
        return Regex.Matches(text, @"\b\w+\b")
                    .Cast<Match>()
                    .Select(match => match.Value)
                    .Where(word => !string.IsNullOrWhiteSpace(word) && word.Length >= 6 && !ContainsDigits(word))
                    .ToList();
    }

    private bool ContainsDigits(string word)
    {
        return word.Any(char.IsDigit);
    }
}
