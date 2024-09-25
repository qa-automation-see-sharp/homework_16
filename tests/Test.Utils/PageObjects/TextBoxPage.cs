using OpenQA.Selenium;

namespace Test.Utils.PageObjects;

public class TextBoxPage
{
    private IWebDriver _driver;
    private By TextBoxTitle => By.XPath("//h1[contains(text(),\"Text Box\")]");
    private By TextBoxForm => By.Id("userForm");
    private By FullNameLable => By.Id("userName-label");
    private By FullNameInput => By.Id("userName");
    private By emailInput => By.Id("userEmail");
    private By currentAddressInput => By.Id("currentAddress");
    private By permanentAdressInput => By.Id("permanentAddress");
    private By submitBtn => By.Id("submit");
    private By displayedFullName => By.Id("name");
    private By displayedEmail => By.Id("email");
    private By displayedCurrentAddress => By.Id("currentAddress");
    private By displayedPermanentAddress => By.Id("permanentAddress");


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

    public void ClickSumbit()
    {
        _driver.FindElement(submitBtn).Click();
    }

    public string GetDisplayedFullName()
    {
        return _driver.FindElement(displayedFullName).Text;
    }

    public string GetDisplayedEmail()
    {
        return _driver.FindElement(displayedEmail).Text;
    }

    public string GetDisplayedCurrentAddress()
    {
        return _driver.FindElement(displayedCurrentAddress).Text;
    }

    public string GetDisplayedPermanentAddress()
    {
        return _driver.FindElement(displayedPermanentAddress).Text;
    }
}