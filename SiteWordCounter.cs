public class SiteWordCounter
{
    public Dictionary<string, int> SiteWordCounts { get; } = new Dictionary<string, int>();

    public async Task ProcessWebsitesAsync(string[] urls)
    {
        var websiteDownloader = new WebsiteDownloader();
        var fileReader = new FileReader();
        var wordProcessor = new WordProcessor();
        var wordCounter = new WordCounter();

        foreach (var url in urls)
        {
            var normalizedUrl = NormalizeUrl(url);
            var html = await websiteDownloader.DownloadWebsiteAsync(normalizedUrl);
            if (!string.IsNullOrEmpty(html))
            {
                var words = wordProcessor.ExtractWords(html);
                var uniqueWords = words.Distinct().ToList();
                SiteWordCounts[normalizedUrl] = uniqueWords.Count;

                Console.WriteLine($"{normalizedUrl} - {uniqueWords.Count}");
                var wordCounts = wordCounter.CountWords(words);
                var sortedWords = uniqueWords.OrderByDescending(word => wordCounts[word]).ToList();
                Console.WriteLine(string.Join("\n", sortedWords.Select(word => $"{word} - {wordCounts[word]}")));
                Console.WriteLine(new string('-', 28)); // Пустая строка между списками слов
            }
        }
    }

    private string NormalizeUrl(string url)
    {
        if (!url.StartsWith("http") && !url.StartsWith("www."))
        {
            url = "http://www." + url; // Добавляем "http://" и "www." при необходимости
        }
        else if (!url.StartsWith("http"))
        {
            url = "http://" + url; // Добавляем "http://" при необходимости
        }

        return url;
    }
}
