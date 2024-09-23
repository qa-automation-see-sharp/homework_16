using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Test.Utils.WebDriver;
using static Test.Utils.WebDriver.WebDriverFactory;

namespace Test.Utils.PageObjects;

public class MainPage
{
    private IWebDriver? _driver;
    private string Url = "https://demoqa.com/";
    private By Elements => By.XPath("//div[@class=\"card mt-4 top-card\"]/div/div/h5[contains(text(),\"Elements\")]");

    public string? GetPageTitle => _driver?.Title;

    public MainPage OpenInChrome()
    {
        _driver = CreateWebDriver(BrowserNames.Chrome, "--start-maximized");
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        _driver?.Navigate().GoToUrl(Url);

        return this;
    }

    public MainPage OpenInFireFox()
    {
        _driver = CreateWebDriver(BrowserNames.Firefox, "--start-maximized");
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        _driver?.Navigate().GoToUrl(Url);

        return this;
    }

    public MainPage OpenInEdge()
    {
        _driver = CreateWebDriver(BrowserNames.Edge, "--start-maximized");
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        _driver?.Navigate().GoToUrl(Url);

        return this;
    }

    public ElementsPage OpenElementsPage()
    {
        Actions actions = new Actions(_driver);
        actions.SendKeys(Keys.PageDown).Perform();
        _driver?.FindElement(Elements).Click();
        return new(_driver);
    }

    public void Close()
    {
        _driver?.Quit();
    }
}