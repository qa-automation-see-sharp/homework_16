using Test.Utils.PageObjects;

namespace NUnit.Tests.UI.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        var mainPaige = new MainPaige().OpenInFireFox();
        var title = mainPaige.GetPageTitle;
        var elementsPage = mainPaige.OpenElementsPage();
        var isAccordionElementPresent = elementsPage.CheckAccordion();

        var textBoxPage = elementsPage.OpenTextBoxPage();
        var textBoxForIsPresent =  textBoxPage.CheckTextBoxForm();
        var textBoxTitle = textBoxPage.CheckTextBoxTitle();
        var textBoxLabelName = textBoxPage.GetFullNameLabelText();
            textBoxPage.EnterFullName("Oleh Kutafin");

        Assert.Multiple(() =>
        {
            Assert.That(title, Is.EqualTo("DEMOQA"));
            Assert.That(isAccordionElementPresent, Is.True);
            Assert.That(textBoxForIsPresent, Is.True);
            Assert.That(textBoxTitle, Is.True);
            Assert.That(textBoxLabelName, Is.EqualTo("Full Name"));
        });
    }

    [Test]
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
                    Assert.That(title, Is.EqualTo("DEMOQA"));
                    Assert.That(isAccordionElementPresent, Is.True);
                    Assert.That(textBoxForIsPresent, Is.True);
                    Assert.That(textBoxTitle, Is.True);
                    Assert.That(textBoxLabelName, Is.EqualTo("Full Name"));
                    Assert.That(textBoxLabelEmail, Is.EqualTo("Email"));
                    Assert.That(textBoxLableCurrentAddress, Is.EqualTo("Current Address"));
                    Assert.That(textBoxLablePermanentAddress, Is.EqualTo("Permanent Address"));
                    Assert.IsTrue(outEmail.Contains(email));
                    Assert.IsTrue(outFullName.Contains(name));
                    Assert.IsTrue(outCurrentAddress.Contains(current));
                    Assert.IsTrue(outPermanentAddress.Contains(permanentAddress));
                });

        textBoxPage.BrowserQuit();
    }
}