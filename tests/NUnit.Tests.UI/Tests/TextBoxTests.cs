using Test.Utils.PageObjects;

namespace NUnit.Tests.UI.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        var mainPaige = new MainPaige().OpenInChrome();
        var title = mainPaige.GetPageTitle;
        var elementsPage = mainPaige.OpenElementsPage();
        var isAccordionElementPresent = elementsPage.CheckAccordion();

        var textBoxPage = elementsPage.OpenTextBoxPage();
        var textBoxFormIsPresent =  textBoxPage.CheckTextBoxForm();
        var textBoxTitle = textBoxPage.CheckTextBoxTitle();
        var textBoxLabelName = textBoxPage.GetFullNameLabelText();
            textBoxPage.EnterFullName("Anton Pavliuchyk");
        var textBoxLabelEmail = textBoxPage.GetEmailLabelText();
            textBoxPage.EnterEmail("testemail@mail.com");
        var textBoxLabelCurrentAddress = textBoxPage.GetCurrentAddressLabelText();
            textBoxPage.EnterCurrentAddress("Anderson st. 43");
        var textBoxLabelPermanentAddress = textBoxPage.GetPermanentAddressLabelText();
            textBoxPage.EnterPermanentAddress("Baker st. 11");
            textBoxPage.ClickSubmit();
        var outputFormIsPresent = textBoxPage.CheckOutputForm();
        var outputNameLabelText = textBoxPage.OutputNameText;
        


        Assert.Multiple(() =>
        {
            Assert.That<string>(title, Is.EqualTo("DEMOQA"));
            Assert.That(isAccordionElementPresent, Is.True);
            Assert.That(textBoxFormIsPresent, Is.True);
            Assert.That(textBoxTitle, Is.True);
            Assert.That(textBoxLabelName, Is.EqualTo("Full Name"));
            Assert.That(textBoxLabelEmail, Is.EqualTo("Email"));
            Assert.That(textBoxLabelCurrentAddress, Is.EqualTo("Current Address"));
            Assert.That(outputFormIsPresent, Is.True);
            
            Assert.That(outputNameLabelText, Is.EqualTo("Name:Anton Pavliuchyk"));

        });
    }
}