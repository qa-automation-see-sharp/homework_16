using OpenQA.Selenium;

namespace Test.Utils.PageObjects;

public class TextBoxPage
{
    private IWebDriver _driver;
    private By TextBoxTitle => By.XPath("//h1[contains(text(),\"Text Box\")]");
    private By TextBoxForm => By.Id("userForm");
    private By FullNameLable => By.Id("userName-label");
    private By EmailLable => By.Id("userEmail-label");
    private By CurrentAddressLable => By.Id("currentAddress-label");
    private By PermanentAddressLable => By.Id("permanentAddress-label");
    private By FullNameInput => By.Id("userName");
    private By EmailInput => By.CssSelector("input#userEmail");
    private By CurrentAddressInput => By.CssSelector("textarea#currentAddress");
    private By PermanentAddressInput => By.XPath("/html//textarea[@id='permanentAddress']");

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

    public string GetEmailLabelText()
    {
        return _driver.FindElement(EmailLable).Text;
    }
    
    public string GetCurrentAddressLabelText()
    {
        return _driver.FindElement(CurrentAddressLable).Text;
    }
    
    public string GetPermanentAddressLabelText()
    {
        return _driver.FindElement(PermanentAddressLable).Text;
    }
    public TextBoxPage EnterEmail(string email)
    {
        _driver.FindElement(EmailInput).SendKeys(email);
        return this;
    }

    public TextBoxPage EnterCurrentAddress(string currentAddress)
    {
        _driver.FindElement(CurrentAddressInput).SendKeys(currentAddress);
        return this;
    }

    public TextBoxPage EnterPermanentAddress(string permanentAddress)
    {
        _driver.FindElement(PermanentAddressInput).SendKeys(permanentAddress);
        return this;
    }
}
