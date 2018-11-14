using System;

namespace NasdaqScrape
{
    class Program
    {
        static void Main(string[] args)
        {
            Scraper scraper = new Scraper();
            
            scraper.scrapeData();
        }
    }
}