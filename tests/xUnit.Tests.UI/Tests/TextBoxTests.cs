using Test.Utils.PageObjects;

namespace xUnit.Tests.UI.Tests;

public class TextBoxTests
{
    [Fact]
    public void TextBoxFieldsEntered()
    {
        var name = "Andre Pinch";
        var email = "andre.pich@google.com";
        var current = "Current adderess";
        var permanentAddress = "Address";

        var mainPaige = new MainPaige().OpenInFireFox();
        var title = mainPaige.GetPageTitle;
        var elementsPage = mainPaige.OpenElementsPage();
        var isAccordionElementPresent = elementsPage.CheckAccordion();

        var textBoxPage = elementsPage.OpenTextBoxPage();
        var textBoxForIsPresent =  textBoxPage.CheckTextBoxForm();
        var textBoxTitle = textBoxPage.CheckTextBoxTitle();
        var textBoxLabelName = textBoxPage.GetFullNameLabelText();
        var textBoxLabelEmail = textBoxPage.GetEmailLabelText();
        var textBoxLableCurrentAddress = textBoxPage.GetCurrentAddressLabelText();
        var textBoxLablePermanentAddress = textBoxPage.GetPermanentAddressLabelText();

            textBoxPage.EnterFullName(name);
            textBoxPage.EnterEmail(email);
            textBoxPage.EnterCurrentAddress(current);
            textBoxPage.EnterPermanentAddress(permanentAddress);
            textBoxPage.SubmitClick();
        var outEmail = textBoxPage.GetOutPutEmail();
        var outFullName = textBoxPage.GetOutPutName();
        var outCurrentAddress = textBoxPage.GetOutPutCurrentAddress();
        var outPermanentAddress = textBoxPage.GetOutPutPermanentAddress();
        
        Assert.Multiple(() =>
                {
                    Assert.Equal("DEMOQA", title);
                    Assert.True(isAccordionElementPresent);
                    Assert.True(textBoxForIsPresent);
                    Assert.True(textBoxTitle);
                    Assert.Equal("Full Name", textBoxLabelName);
                    Assert.Equal("Email", textBoxLabelEmail);
                    Assert.Equal("Current Address", textBoxLableCurrentAddress);
                    Assert.Equal("Permanent Address", textBoxLablePermanentAddress);
                    Assert.Contains(email, outEmail);
                    Assert.Contains(name, outFullName);
                    Assert.Contains(current, outCurrentAddress);
                    Assert.Contains(permanentAddress, outPermanentAddress);
                });

        textBoxPage.BrowserQuit();
    }
}