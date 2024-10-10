using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Test.Utils.WebDriver;

public static class WebDriverFactory
{
    public static IWebDriver? CreateWebDriver(BrowserNames browser, params string[] args)
    {
        IWebDriver? driver = null;
        switch (browser)
        {
            case BrowserNames.Chrome:
                var chromeOptions = new ChromeOptions();
                foreach (var arg in args) chromeOptions.AddArgument(arg);

                driver = new ChromeDriver(chromeOptions);
                break;
            case BrowserNames.Firefox:
                var firefoxOptions = new FirefoxOptions();
                foreach (var arg in args) firefoxOptions.AddArgument(arg);

                driver = new FirefoxDriver(firefoxOptions);
                break;
            case BrowserNames.Edge:
                var edgeOptions = new EdgeOptions();
                foreach (var arg in args) edgeOptions.AddArgument(arg);

                driver = new EdgeDriver(edgeOptions);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
        }

        return driver;
    }
}