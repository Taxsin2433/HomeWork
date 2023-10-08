using System.Net.Http;
using System.Threading.Tasks;

public class WebsiteDownloader
{
    public async Task<string> DownloadWebsiteAsync(string url)
    {
        if (!url.StartsWith("http"))
        {
            url = "http://" + url; // Добавляем префикс "http://", если его нет
        }

        using (var client = new HttpClient())
        {
            try
            {
                return await client.GetStringAsync(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке сайта {url}: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
