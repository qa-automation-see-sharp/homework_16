using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Test.Utils.PageObjects;

public class TextBoxPage
{
    private IWebDriver _driver;
    private By TextBoxTitle => By.XPath("//h1[contains(text(),\"Text Box\")]");
    private By TextBoxForm => By.Id("userForm");
    private By FullNameLable => By.Id("userName-label");
    private By FullNameInput => By.Id("userName");
    private By EmailLabel => By.Id("userEmail-label");
    private By EmailInput => By.Id("userEmail");
    private By CurrentAddressLabel => By.Id("currentAddress-label");
    private By CurrentAddressInput => By.Id("currentAddress");
    private By PermanentAddressLabel => By.Id("permanentAddress-label");
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

    public bool CheckFullName()
    {
        var inputElement = _driver.FindElement(FullNameInput); 
        var labelElement = _driver.FindElement(FullNameLable); 

        bool areBothDisplayed = inputElement.Displayed && inputElement.Enabled &&
                                labelElement.Displayed && labelElement.Enabled;

        return areBothDisplayed;
    }
    public bool CheckEmail()
    {
        var inputElement = _driver.FindElement(EmailInput); 
        var labelElement = _driver.FindElement(EmailLabel); 

        bool areBothDisplayed = inputElement.Displayed && inputElement.Enabled &&
                                labelElement.Displayed && labelElement.Enabled;

        return areBothDisplayed;
    }
    public bool CheckCurrentAddress()
    {
        var inputElement = _driver.FindElement(CurrentAddressInput); 
        var labelElement = _driver.FindElement(CurrentAddressLabel); 

        bool areBothDisplayed = inputElement.Displayed && inputElement.Enabled &&
                                labelElement.Displayed && labelElement.Enabled;

        return areBothDisplayed;
    }
    public bool CheckPermanentAddress()
    {
        var inputElement = _driver.FindElement(PermanentAddressInput); 
        var labelElement = _driver.FindElement(PermanentAddressLabel); 

        bool areBothDisplayed = inputElement.Displayed && inputElement.Enabled &&
                                labelElement.Displayed && labelElement.Enabled;

        return areBothDisplayed;
    }
    public bool CheckSubmitButton()
    {
        var element = _driver.FindElement(SubmitButton);
        return element.Displayed && element.Enabled;
    }

    public string GetTextBoxTitle()
    {
        return _driver.FindElement(TextBoxTitle).Text;
    }
    public string GetFullNameLabelText()
    {
        return _driver.FindElement(FullNameLable).Text;
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
    public string GetSubmitButtonText()
    {
        return _driver.FindElement(SubmitButton).Text;
    }

    public bool CheckFullNameInput()
    {
        var element = _driver.FindElement(FullNameInput);
        return element.Displayed && element.Enabled;
    }
    public bool CheckEmailInput()
    {
        var element = _driver.FindElement(EmailInput);
        return element.Displayed && element.Enabled;
    }
    public bool CheckCurrentAddressInput()
    {
        var element = _driver.FindElement(CurrentAddressInput);
        return element.Displayed && element.Enabled;
    }
    public bool CheckPermanentAddressInput()
    {
        var element = _driver.FindElement(PermanentAddressInput);
        return element.Displayed && element.Enabled;
    }

    public bool CheckIfFullNamePlaceholderIsPresent()
    {
        var element = _driver.FindElement(FullNameInput);
        return element.GetAttribute("placeholder") != null;
    }
    public bool CheckIfEmailPlaceholderIsPresent()
    {
        var element = _driver.FindElement(EmailInput);
        return element.GetAttribute("placeholder") != null;
    }
    public bool CheckIfCurrentAddressPlaceholderIsPresent()
    {
        var element = _driver.FindElement(CurrentAddressInput);
        return element.GetAttribute("placeholder") != null;
    }
    public bool CheckIfPermanentAddressPlaceholderIsPresent()
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("permanentAddress")));
        var placeholder = element.GetAttribute("placeholder");

        // Перевірка наявності атрибута та його непорожності
        return !string.IsNullOrEmpty(placeholder);
    }

    public string GetFullNamePlaceholderText()
    {
        return _driver.FindElement(FullNameInput).GetAttribute("placeholder");
    }
    public string GetEmailPlaceholderText()
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("userEmail")));
        return _driver.FindElement(EmailInput).GetAttribute("placeholder");
    }
    public string GetCurrentAddressPlaceholderText()
    {
        return _driver.FindElement(CurrentAddressInput).GetAttribute("placeholder");
    }
    public string GetPermanentAddressPlaceholderText()
    {
        return _driver.FindElement(PermanentAddressInput).GetAttribute("placeholder");
    }

    public string EnterFullName(string fullName)
    {
        var element = _driver.FindElement(By.Id("userName"));
        element.Clear();
        element.SendKeys(fullName);
        return $"Name:{fullName}";
    }
    public string EnterEmail(string email)
    {
       var element = _driver.FindElement(EmailInput);
        element.Clear();
        element.SendKeys(email);
        return $"Email:{email}";
    }

    public string EnterCurrentAddress(string currentAddress)
    {
        var element = _driver.FindElement(CurrentAddressInput);
        element.Clear();
        element.SendKeys(currentAddress);
        return $"Current Address :{currentAddress}";
    }

    public string EnterPermanentAddress(string permanentAddress)
    {
       var element = _driver.FindElement(PermanentAddressInput);
        element.Clear();
        element.SendKeys(permanentAddress);
        return $"Permananet Address :{permanentAddress}";
        //The return shhould be "Permanent Address :{permanentAddress}" but there is a typo in the DOM. Just for good picture I will leave it as it is.
    }

    public TextBoxPage SubmitForm()
    {
        IWebElement element = _driver.FindElement(SubmitButton);
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        element.Click();
        return this;
    }

    //Get outputs
    public string GetFullNameOutput()
    {
        var element = _driver.FindElement(Output);
        var fullNameOutput = element.FindElement(By.Id("name")).Text;
        return fullNameOutput;
    }
    public string GetEmailOutput()
    {
        var element = _driver.FindElement(Output);
        var emailOutput = element.FindElement(By.Id("email")).Text;
        return emailOutput;
    }

    public string GetCurrentAddressOutput()
    {
        var element = _driver.FindElement(Output);
        var currentAddressOutput = element.FindElement(By.Id("currentAddress")).Text;
        return currentAddressOutput;
    }

    public string GetPermanentAddressOutput()
    {
        var element = _driver.FindElement(Output);
        var permanentAddressOutput = element.FindElement(By.Id("permanentAddress")).Text;
        return permanentAddressOutput;
    }
   
    public void Close()
    {
        _driver?.Quit();
    }
}