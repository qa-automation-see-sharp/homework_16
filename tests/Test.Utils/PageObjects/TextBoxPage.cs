using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Test.Utils.PageObjects;

public class TextBoxPage
{
    private IWebDriver _driver;
    private By TextBoxTitle => By.XPath("//h1[contains(text(),\"Text Box\")]");
    private By TextBoxForm => By.Id("userForm");
    private By FullNameLable => By.Id("userName-label");
    private By FullNameInput => By.Id("userName");
    private By EmailLable => By.Id("userEmail-label");
    private By EmailInput => By.Id("userEmail");
    private By CurrentAddressLable => By.Id("currentAddress-label");
    private By CurrentAddressInput => By.Id("currentAddress");
    private By PermanentAddressLable => By.Id("permanentAddress-label");
    private By PermanentAddressInput => By.Id("permanentAddress");
    private By SubmitButton => By.Id("submit");
    private By OutPutName => By.Id("name");
    private By OutPutEmail => By.Id("email");
    private By OutPutCurrentAddress => By.CssSelector("p#currentAddress");
    private By OutPutPrermanentAddress => By.CssSelector("p#permanentAddress");

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

    #region Enter text to fields
    public TextBoxPage EnterCurrentAddress(string currentAddress)
    {
        _driver.FindElement(CurrentAddressInput).SendKeys(currentAddress);

        return this;
    }

    public TextBoxPage EnterEmail(string email)
    {
        _driver.FindElement(EmailInput).SendKeys(email);

        return this;
    }

    public TextBoxPage EnterFullName(string fullName)
    {
        _driver.FindElement(FullNameInput).SendKeys(fullName);

        return this;
    }

    public TextBoxPage EnterPermanentAddress(string permanentAddress)
    {
        _driver.FindElement(PermanentAddressInput).SendKeys(permanentAddress);

        return this;
    }
    #endregion
    #region Get Lables and OutPut
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

     public string GetOutPutName()
    {
        return _driver.FindElement(OutPutName).Text;
    }

    public string GetOutPutEmail()
    {
        return _driver.FindElement(OutPutEmail).Text;
    }

    public string GetOutPutCurrentAddress()
    {
        return _driver.FindElement(OutPutCurrentAddress).Text;
    }

    public string GetOutPutPermanentAddress()
    {
        return _driver.FindElement(OutPutPrermanentAddress).Text;
    }
    #endregion

    public TextBoxPage SubmitClick()
    {
        var submit = _driver.FindElement(SubmitButton);
        int deltaY = submit.Location.Y;
        new Actions(_driver)
            .ScrollByAmount(0, deltaY)
            .Perform();
        submit.Click();
        return this;
    }

    public void BrowserQuit()
    {
        _driver.Close();
        _driver.Quit();
    }
}