using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace YahooScrape
{
    public class Scraper
    {
        public void ScrapeData()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");
            IWebDriver chromeDriver = new ChromeDriver(options);
            
            // Go to Yahoo finance site
            chromeDriver.Navigate().GoToUrl("https://finance.yahoo.com/portfolios?bypass=true");
            
            // set wait
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
            // Click sign in button
            chromeDriver.FindElement(By.XPath("//*[@id=\"pf-splash\"]/section/a")).Click();
            
            // Input username
            chromeDriver.FindElement(By.Name("username")).SendKeys("TestFinance@yahoo.com" + Keys.Enter);
            
            // Input password
            chromeDriver.FindElement(By.Name("password")).SendKeys("3eggWhites6Almonds" + Keys.Enter);
            
            // Get rid of pop up
            chromeDriver.FindElement(By.XPath("//*[@id=\"fin-tradeit\"]/div[2]/div/div/div[2]/button[2]")).Click();
               
            // Click on MyWatchlist portfolio
            chromeDriver.FindElement(By.XPath("//*[@id=\"main\"]/section/section/div[2]/table/tbody/tr/td[1]/a")).Click();

            // Find Stock Table
            var table = chromeDriver.FindElement(By.XPath("//*[@id=\"main\"]/section/section[2]/div[2]/table"));

            List<string> stockData = new List<string>();
            
            // Get table rows
            List<IWebElement> tableRows = new List<IWebElement>(table.FindElements(By.TagName("tr")));

            foreach (var tableRow in tableRows)
            {
                List<IWebElement> tableColumns = new List<IWebElement>(tableRow.FindElements(By.TagName("td")));
                foreach (var tableColumn in tableColumns)
                {
                    stockData.Add(tableColumn.Text);
                }
                
                foreach (var item in stockData)
                {
                    Console.WriteLine(item);
                }
                
                stockData.Clear();
                Console.WriteLine("");
            }

            chromeDriver.Quit();
            
        }
    }
}