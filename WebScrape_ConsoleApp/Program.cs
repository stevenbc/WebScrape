using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebScrape;
using WebScrape.Contracts;
namespace WebScrape_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "c:\\Temp\\HTML";
            List<string> webPages = new List<string>();
            webPages.Add("https://www.c-sharpcorner.com/");
            webPages.Add("https://www.reddit.com/");
            webPages.Add("https://www.packtpub.com/");
            Console.WriteLine("Scraping the following webpages...");

            foreach (var webPage in webPages)
            {
                Console.WriteLine(webPage);
            }

            Console.WriteLine($"Does path exist {filePath}");
            if (!Directory.Exists(filePath))
            {
                Console.WriteLine($"Path does not exist {filePath} trying to create...");
                try
                {
                    Directory.CreateDirectory(filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating Path {filePath} Please create manually Error message {ex.Message}");
                    Console.ReadLine();
                    return;
                }
            }
            Scrape scrape = new Scrape();
            List < SiteData > webContents = scrape.GetSites(webPages);
            
            for (var i = 0; i < webPages.Count; i++)
            {

                var fileName = Path.Combine(filePath, $"HTML_{i}.html");
                if (File.Exists(fileName))
                    File.Delete(fileName);

                using (FileStream fileStream = new FileStream(fileName, FileMode.CreateNew))
                {
                    var line = Encoding.UTF8.GetBytes($"<!--{webContents[i].URL} -->");
                    fileStream.Write(line);
                    line = Encoding.UTF8.GetBytes(webContents[i].Body);
                    fileStream.Write(line);
                }
            }
            
            

        }
    }
}
