using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject
{
    public class InitDriver
    {
        public WebDriver DriverFactory(string browserName)
        {
            WebDriver WebDriver = null;

            switch (browserName.ToUpper())
            {
                case "CHROME":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    var options = new ChromeOptions();
                    options.AddExcludedArgument("enable-automation");
                    options.AddArgument("--disable-blink-features=AutomationControlled");
                    options.AddAdditionalOption("useAutomationExtension", false);
                    options.AddArguments("--incognito");
                    WebDriver = new ChromeDriver(options);
                    break;

                case "FIREFOX":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    var foptions = new FirefoxOptions();
                    foptions.AddArguments("--incognito");
                    WebDriver = new FirefoxDriver(foptions);
                    break;

                case "IE":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    var eoptions = new EdgeOptions();
                    eoptions.AddExcludedArgument("enable-automation");
                    eoptions.AddArguments("--incognito");
                    WebDriver = new EdgeDriver(eoptions);
                    break;
            }

            return WebDriver;
        }
    }
}
