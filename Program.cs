using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Введите два URL-адреса сайтов (через пробел):");
        string[] urls = Console.ReadLine().Split(' ');

        var siteWordCounter = new SiteWordCounter();
        await siteWordCounter.ProcessWebsitesAsync(urls);

        Console.WriteLine("\nКоличество уникальных слов для каждого сайта:");
        foreach (var kvp in siteWordCounter.SiteWordCounts)
        {
            Console.WriteLine($"{kvp.Key} - {kvp.Value}");
        }
    }
}
