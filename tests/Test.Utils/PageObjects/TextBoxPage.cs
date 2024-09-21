using OpenQA.Selenium;

namespace Test.Utils.PageObjects;

public class TextBoxPage
{
    private IWebDriver _driver;
    private By TextBoxTitle => By.XPath("//h1[contains(text(),\"Text Box\")]");
    private By TextBoxForm => By.Id("userForm");
    private By FullNameLable => By.Id("userName-label");
    private By FullNameInput => By.Id("userName");

    public TextBoxPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public bool CheckTextBoxTitle()
    {
        var element = _driver.FindElement(TextBoxTitle);
        return element.Displayed && element.Enabled;
    }

    public bool CheckTextBoxForm()
    {
        var element = _driver.FindElement(TextBoxForm);
        return element.Displayed && element.Enabled;
    }

    public TextBoxPage EnterFullName(string fullName)
    {
        _driver.FindElement(FullNameInput).SendKeys(fullName);

        return this;
    }

    public string GetFullNameLabelText()
    {
        return _driver.FindElement(FullNameLable).Text;
    }
}