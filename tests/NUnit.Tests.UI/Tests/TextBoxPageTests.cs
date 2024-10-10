using Test.Utils.PageObjects;

namespace NUnit.Tests.UI.Tests;

[TestFixture]
public class TextBoxPageTests
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _mainPaige = new MainPaige();
        _mainPaige.OpenInChrome();
        _textBoxPage = _mainPaige.OpenElementsPage().OpenTextBoxPage();
    }

    private MainPaige _mainPaige;
    private TextBoxPage _textBoxPage;
    private const string Name = "Anton Pavliuchyk";
    private const string OutputName = "Name:Anton Pavliuchyk";
    private const string Email = "testemail@mail.com";
    private const string OutputEmail = "Email:testemail@mail.com";
    private const string CurrentAddress = "Anderson st. 43";
    private const string OutputCurrentAddress = "Current Address :Anderson st. 43";
    private const string PermanentAddress = "Baker st. 11";
    private const string OutputPermanentAddress = "Permananet Address :Baker st. 11";

    [Test]
    public void CheckPageTitle()
    {
        var checkTextBoxTitle = _textBoxPage.CheckTextBoxTitle();
        var textBoxFormIsPresent = _textBoxPage.CheckTextBoxForm();

        Assert.Multiple(() =>
        {
            Assert.That(checkTextBoxTitle, Is.True);
            Assert.That(textBoxFormIsPresent, Is.True);
        });
    }

    [Test]
    public void CheckLabels()
    {
        var textBoxLabelName = _textBoxPage.GetFullNameLabelText();
        var textBoxLabelEmail = _textBoxPage.GetEmailLabelText();
        var textBoxLabelCurrentAddress = _textBoxPage.GetCurrentAddressLabelText();
        var textBoxLabelPermanentAddress = _textBoxPage.GetPermanentAddressLabelText();

        Assert.Multiple(() =>
        {
            Assert.That(textBoxLabelName, Is.EqualTo("Full Name"));
            Assert.That(textBoxLabelEmail, Is.EqualTo("Email"));
            Assert.That(textBoxLabelCurrentAddress, Is.EqualTo("Current Address"));
            Assert.That(textBoxLabelPermanentAddress, Is.EqualTo("Permanent Address"));
        });
    }

    [Test] //TODO: Finish this test
    public void CheckInputsGetCorrectValue()
    {
        _textBoxPage.EnterFullName(Name);
        _textBoxPage.EnterEmail(Email);
        _textBoxPage.EnterCurrentAddress(CurrentAddress);
        _textBoxPage.EnterPermanentAddress(PermanentAddress);
        _textBoxPage.ClickSubmit();
        var outputFormIsPresent = _textBoxPage.CheckOutputForm();
        var outputNameText = _textBoxPage.GetOutputNameText();
        var outputEmailText = _textBoxPage.GetOutputEmailText();
        var outputCurrentAddressText = _textBoxPage.GetOutputCurrentAddressText();
        var outputPermanentAddressText = _textBoxPage.GetOutputPermanentAddressText();


        Assert.Multiple(() =>
        {
            Assert.That(outputFormIsPresent, Is.True);
            Assert.That(outputNameText, Is.EqualTo(OutputName));
            Assert.That(outputEmailText, Is.EqualTo(OutputEmail));
            Assert.That(outputCurrentAddressText, Is.EqualTo(OutputCurrentAddress));
            Assert.That(outputPermanentAddressText, Is.EqualTo(OutputPermanentAddress));
        });
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _mainPaige.Close();
    }
}