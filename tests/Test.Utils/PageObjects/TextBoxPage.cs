using OpenQA.Selenium;

namespace Test.Utils.PageObjects;

public class TextBoxPage
{
    private readonly IWebDriver _driver;


    public TextBoxPage(IWebDriver driver)
    {
        _driver = driver;
    }

    private By TextBoxTitle => By.XPath("//h1[contains(text(),\"Text Box\")]");
    private By TextBoxForm => By.Id("userForm");
    private By OutputForm => By.Id("output");
    private By FullNameLable => By.Id("userName-label");
    private By EmailLabel => By.Id("userEmail-label");
    private By CurrentAddressLabel => By.Id("currentAddress-label");
    private By PermanentAddressLabel => By.Id("permanentAddress-label");
    private By FullNameInput => By.Id("userName");
    private By EmailInput => By.Id("userEmail");
    private By CurrentAddressInput => By.Id("currentAddress");
    private By PermanentAddressInput => By.Id("permanentAddress");
    private By SubmitButton => By.Id("submit");
    private By OutputNameLabelXpath => By.XPath("//div[@id='output']//p[@id='name']");
    private By OutputEmailLabelXpath => By.XPath("//div[@id='output']//p[@id='email']");
    private By OutputCurrentAddressLabelXpath => By.XPath("//div[@id='output']//p[@id='currentAddress']");
    private By OutputPermanentAddressLabelXpath => By.XPath("//div[@id='output']//p[@id='permanentAddress']");


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

    public bool CheckOutputForm()
    {
        var element = _driver.FindElement(OutputForm);
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

    public TextBoxPage EnterEmail(string email)
    {
        _driver.FindElement(EmailInput).SendKeys(email);

        return this;
    }

    public string GetEmailLabelText()
    {
        return _driver.FindElement(EmailLabel).Text;
    }

    public TextBoxPage EnterCurrentAddress(string currentaddress)
    {
        _driver.FindElement(CurrentAddressInput).SendKeys(currentaddress);

        return this;
    }

    public string GetCurrentAddressLabelText()
    {
        return _driver.FindElement(CurrentAddressLabel).Text;
    }

    public TextBoxPage EnterPermanentAddress(string permanentaddress)
    {
        _driver.FindElement(PermanentAddressInput).SendKeys(permanentaddress);

        return this;
    }

    public string GetPermanentAddressLabelText()
    {
        return _driver.FindElement(PermanentAddressLabel).Text;
    }

    public TextBoxPage ClickSubmit()
    {
        _driver.FindElement(SubmitButton).Click();
        return new TextBoxPage(_driver);
    }

    public string GetOutputNameText()
    {
        return _driver.FindElement(OutputNameLabelXpath).Text;
    }
    public string GetOutputEmailText()
    { 
        return _driver.FindElement(OutputEmailLabelXpath).Text;
    }
    public string GetOutputCurrentAddressText()
    {
        return _driver.FindElement(OutputCurrentAddressLabelXpath).Text;
    }
    public string GetOutputPermanentAddressText()
    {
        return _driver.FindElement(OutputPermanentAddressLabelXpath).Text;
    }
}