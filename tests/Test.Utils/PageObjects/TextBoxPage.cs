using OpenQA.Selenium;

namespace Test.Utils.PageObjects;

public class TextBoxPage
{
    private IWebDriver _driver;
    private By TextBoxTitle => By.XPath("//h1[contains(text(),\"Text Box\")]");
    private By TextBoxForm => By.Id("userForm");
    private By FullNameLabel => By.Id("userName-label");
    private By EmailLabel => By.Id("userEmail-label");
    private By CurrentAddressLabel => By.Id("currentAddress-label");
    private By PermanentAddressLabel => By.Id("permanentAddress-label");
    private By FullNameInput => By.Id("userName");
    private By EmailInput => By.Id("userEmail");
    private By CurrentAddressInput => By.Id("currentAddress");
    private By PermanentAddressInput => By.Id("permanentAddress");
    private By SubmitButton => By.Id("submit");
    private By Output => By.Id("output");

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
    public TextBoxPage Submit()
    {
        var submitButton = _driver.FindElement(SubmitButton);

        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitButton);

        submitButton.Click();

        return this;
    }

    public string GetFullNameLabelText()
    {
        return _driver.FindElement(FullNameLabel).Text;
    }

    public string GetEmailLabelText()
    {
        return _driver.FindElement(EmailLabel).Text;
    }

    public string GetCurrentAddressLabelText()
    {
        return _driver.FindElement(CurrentAddressLabel).Text;
    }

    public string GetPermanentAddressLabelText()
    {
        return _driver.FindElement(PermanentAddressLabel).Text;
    }

    public string GetOutputText()
    {
        return _driver.FindElement(Output).Text;
    }

}