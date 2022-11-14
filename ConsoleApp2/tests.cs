using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class tests
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver(@"C:\Users\dell\Desktop\Tal");
        }

        [Test]
        public void test()
        {
            driver.Url = "http://www.imdb.com";
            driver.Navigate().GoToUrl("http://www.imdb.co.il");

        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
