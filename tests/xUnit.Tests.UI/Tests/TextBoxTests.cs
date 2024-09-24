using OpenQA.Selenium;
using Test.Utils.PageObjects;

namespace xUnit.Tests.UI.Tests;
public class TextBoxTests: IAsyncLifetime
{
    protected MainPage _mainPage;
    protected ElementsPage _elementsPage;
    protected TextBoxPage _textBoxPage;
    private IWebDriver? _driver;

    public async Task InitializeAsync()
    {
        _mainPage = new MainPage(_driver);
        _mainPage.OpenInChrome();
        _elementsPage = _mainPage.OpenElementsPage();
        _textBoxPage = _elementsPage.OpenTextBoxPage();
    }

    [Fact]
    public void NavigateToTextBox_AllFieldsLabelsShouldBeDisplayed()
    {
        var pageTitle = _textBoxPage.CheckTextBoxTitle();
        var textBoxForm = _textBoxPage.CheckTextBoxForm();

        var fullNameLabel = _textBoxPage.GetFullNameLabelText();
        var emailLabel = _textBoxPage.GetEmailLabelText();
        var currentAddressLabel = _textBoxPage.GetCurrentAddressLabelText();
        var permanentAddressLabel = _textBoxPage.GetPermanentAddressLabelText();

        Assert.Multiple(() =>
        {
            Assert.Equal(true, pageTitle);
            Assert.Equal(true, textBoxForm);

            Assert.Equal("Full Name", fullNameLabel);
            Assert.Equal("Email", emailLabel);
            Assert.Equal("Current Address", currentAddressLabel);
            Assert.Equal("Permanent Address", permanentAddressLabel);
        });
    }

    [Fact]
    public void NavigateToTextBox_WhenAllFieldsAreSubmitted_ShouldRetuntBriefDescription()
    {
        var enterFullName = _textBoxPage.EnterFullName("Zaremba Olesia");
        var enterEmail = _textBoxPage.EnterEmail("zaremba.olesia@gmail.com");
        var enterCurrentAdress = _textBoxPage.EnterCurrentAddress("Khreshchatyk street, 45, Kyiv, Ukraine");
        var enterPermanentAdress = _textBoxPage.EnterPermanentAddress("Khreshchatyk street, 45, Kyiv, Ukraine");

        _textBoxPage.Submit();

        var output = _textBoxPage.GetOutputText();

        var textCheck = "Name:Zaremba Olesia\r\nEmail:zaremba.olesia@gmail.com\r\nCurrent Address :Khreshchatyk street, 45, Kyiv, Ukraine\r\nPermananet Address :Khreshchatyk street, 45, Kyiv, Ukraine";
        Assert.Multiple(() =>
        {
            Assert.Equal(textCheck, output);
        });
    }

    public async Task DisposeAsync()
    {
        _mainPage.Close();
    }
}