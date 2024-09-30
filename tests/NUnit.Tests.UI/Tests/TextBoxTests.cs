using OpenQA.Selenium;
using Test.Utils.PageObjects;

namespace NUnit.Tests.UI.Tests;

[TestFixture] // [Parallelizable(ParallelScope.All)] won't work with the current implementation 
public class TextBoxTests
{
    protected MainPage _mainPage;
    protected ElementsPage _elementsPage;
    protected TextBoxPage _textBoxPage;
    private IWebDriver? _driver;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _mainPage = new MainPage(_driver);
        _mainPage.OpenInChrome();
        _elementsPage = _mainPage.OpenElementsPage();
        _textBoxPage = _elementsPage.OpenTextBoxPage();
    }

    [Test]
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
            Assert.AreEqual(true, pageTitle);
            Assert.AreEqual(true, textBoxForm);

            Assert.AreEqual("Full Name", fullNameLabel);
            Assert.AreEqual("Email", emailLabel);
            Assert.AreEqual("Current Address", currentAddressLabel);
            Assert.AreEqual("Permanent Address", permanentAddressLabel);
        });
    }

    [Test]
    public void NavigateToTextBox_WhenAllFieldsAreSubmitted_ShouldReturnBriefDescription()
    {
        var enterFullName = _textBoxPage.EnterFullName("Zaremba Olesia");
        var enterEmail = _textBoxPage.EnterEmail("zaremba.olesia@gmail.com");
        var enterCurrentAddress = _textBoxPage.EnterCurrentAddress("Khreshchatyk street, 45, Kyiv, Ukraine");
        var enterPermanentAddress = _textBoxPage.EnterPermanentAddress("Khreshchatyk street, 45, Kyiv, Ukraine");

        _textBoxPage.Submit();

        var output = _textBoxPage.GetOutputText();

        var textCheck = "Name:Zaremba Olesia\nEmail:zaremba.olesia@gmail.com\nCurrent Address :Khreshchatyk street, 45, Kyiv, Ukraine\nPermananet Address :Khreshchatyk street, 45, Kyiv, Ukraine";
        Assert.Multiple(() =>
        {
            Assert.AreEqual(textCheck, output);
            //Use That this is recommended by NUnit
            Assert.That(output, Is.EqualTo(textCheck));
        });
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _mainPage.Close();
    }
}