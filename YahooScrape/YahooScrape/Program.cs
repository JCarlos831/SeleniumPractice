using System;

namespace YahooScrape
{
    class Program
    {
        static void Main(string[] args)
        {
            Scraper scraper = new Scraper();
            
            scraper.ScrapeData();
        }
    }
}