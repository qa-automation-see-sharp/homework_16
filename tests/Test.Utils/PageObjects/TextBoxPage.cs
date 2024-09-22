using OpenQA.Selenium;

namespace Test.Utils.PageObjects;

public class TextBoxPage
{
    private IWebDriver _driver;
    private By TextBoxTitle => By.XPath("//h1[contains(text(),\"Text Box\")]");
    private By TextBoxForm => By.Id("userForm");
    private By FullNameLable => By.Id("userName-label");
    private By FullNameInput => By.Id("userName");
    private By EmailLable => By.Id("userEmail-label");
    private By CurrentAddressLable => By.Id("currentAddress-label");
    private By PermanentAddressLable => By.Id("permanentAddress-label");
    private By UserEmail => By.Id("userEmail");
    private By CurrentAddress => By.Id("currentAddress");
    private By PermanentAddress => By.Id("permanentAddress");
    private By SubmitButton => By.Id("submit");
    private By OutputField => By.Id("output");

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

    public TextBoxPage EnterEmail(string userEmail)
    {
        _driver.FindElement(UserEmail).SendKeys(userEmail);

        return this;
    }
    public TextBoxPage EnterCurrentAddress(string currentAddress)
    {
        _driver.FindElement(CurrentAddress).SendKeys(currentAddress);

        return this;
    }
    public TextBoxPage EnterPermanentAddress(string permanentAddress)
    {
        _driver.FindElement(PermanentAddress).SendKeys(permanentAddress);

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
    public void ClickSubmitButton()
    {
        _driver.FindElement(SubmitButton).Click();
    }
    public IWebElement GetOutputElement()
    {
        //to perform Scroll on application using Selenium
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript("window.scrollBy(0,350)", "");
        return _driver.FindElement(OutputField);
    }
}