using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NasdaqScrape
{
    public class Scraper
    {
        public void scrapeData()
        {
            IWebDriver driver = new ChromeDriver();
            
            driver.Navigate().GoToUrl("https://www.nasdaq.com");
            
            // Go to major indices
            driver.FindElement(By.XPath("//*[@id=\"left-column-div\"]/div[2]/div[1]/div[4]/a")).Click();
            
            // Find table
            var table = driver.FindElement(By.ClassName("USMN_MarketIndices"));

            // Find all table rows in the table
            List<IWebElement> tableRows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
            
            // Create and Instantiate a list for the data
            List<string> majorIndicesData = new List<string>();

            // Go through each table row
            foreach (var tableRow in tableRows)
            {
                
                // Find all the columns in the row
                List<IWebElement> tableColumns = new List<IWebElement>(tableRow.FindElements(By.TagName("td")));

                foreach (var tableColumn in tableColumns)
                {
                    majorIndicesData.Add(tableColumn.Text);
                }

                foreach (var item in majorIndicesData)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("");
                majorIndicesData.Clear();
            }
            
            driver.Quit();
        }
    }
}