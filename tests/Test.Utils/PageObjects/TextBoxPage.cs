using OpenQA.Selenium;

namespace Test.Utils.PageObjects;

public class TextBoxPage
{
    private IWebDriver _driver;
    private IJavaScriptExecutor js => (IJavaScriptExecutor)_driver;
    private By TextBoxTitle => By.XPath("//h1[contains(text(),\"Text Box\")]");
    private By TextBoxForm => By.Id("userForm");
    private By FullNameLable => By.Id("userName-label");
    private By FullNameInput => By.Id("userName");
    private By emailInput => By.Id("userEmail");
    private By currentAddressInput => By.Id("currentAddress");
    private By permanentAdressInput => By.Id("permanentAddress");
    public By submitBtn => By.XPath("//*[@id='submit']"); 
    private By output => By.Id("output");


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

    public TextBoxPage EnterEmail(string email)
    {
        _driver.FindElement(emailInput).SendKeys(email);

        return this;
    }

    public TextBoxPage EnterCurrentAddress(string currentAddress)
    {
        _driver.FindElement(currentAddressInput).SendKeys(currentAddress);

        return this;
    }

    public TextBoxPage EnterPermanentAddress(string permanentAddress)
    {
        _driver.FindElement(permanentAdressInput).SendKeys(permanentAddress);

        return this;
    }

    public void ScrollToSubmitBtn()
    {
        var button =_driver.FindElement(submitBtn);
        js.ExecuteScript("arguments[0].scrollIntoView(true);", button); 
    }

    public void ClickSumbit()
    {
        _driver.FindElement(submitBtn).Click();
    }

    public string GetOutput()
    {
        return _driver.FindElement(output).Text;
    }
}