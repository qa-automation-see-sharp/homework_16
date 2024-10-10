using OpenQA.Selenium;
using Test.Utils.WebDriver;
using static Test.Utils.WebDriver.WebDriverFactory;

namespace Test.Utils.PageObjects;

public class MainPaige
{
    private IWebDriver? _driver;
    private readonly string Url = "https://demoqa.com/";
    private By Elemnts => By.XPath("//div[@class=\"card mt-4 top-card\"]/div/div/h5[contains(text(),\"Elements\")]");

    public string? GetPageTitle => _driver?.Title;

    public MainPaige OpenInChrome()
    {
        _driver = CreateWebDriver(BrowserNames.Chrome, "--start-maximized");
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        _driver?.Navigate().GoToUrl(Url);

        return this;
    }

    public MainPaige OpenInFireFox()
    {
        _driver = CreateWebDriver(BrowserNames.Firefox, "--start-maximized");
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        _driver?.Navigate().GoToUrl(Url);

        return this;
    }

    public MainPaige OpenInEdge()
    {
        _driver = CreateWebDriver(BrowserNames.Edge, "--start-maximized");
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        _driver?.Navigate().GoToUrl(Url);

        return this;
    }

    public ElementsPage OpenElementsPage()
    {
        _driver?.FindElement(Elemnts).Click();
        return new ElementsPage(_driver);
    }

    public void Close()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }
}