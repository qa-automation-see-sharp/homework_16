using OpenQA.Selenium;

namespace Test.Utils.PageObjects;

public class ElementsPage
{
    private IWebDriver _driver;
    protected string Url => "https://demoqa.com/text-box";
    protected string Title => _driver.Title;

    private By Accordion => By.XPath("//div[@class=\"accordion\"]");
    private By TextBox => By.XPath("//span[contains(text(),\"Text Box\")]");
    private By FullName => By.Id("userName");
    
    public ElementsPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    public bool CheckAccordion()
    {
        return _driver.FindElement(Accordion).Displayed;
    }

    public TextBoxPage OpenTextBoxPage()
    {
        _driver.FindElement(TextBox).Click();
        return new TextBoxPage(_driver);
    }
    
}