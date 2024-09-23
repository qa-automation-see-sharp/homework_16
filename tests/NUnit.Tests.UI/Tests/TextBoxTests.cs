using Test.Utils.PageObjects;

namespace NUnit.Tests.UI.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        var mainPage = new MainPage().OpenInChrome();
        var title = mainPage.GetPageTitle;
        var elementsPage = mainPage.OpenElementsPage();
        var isAccordionElementPresent = elementsPage.CheckAccordion();

        var textBoxPage = elementsPage.OpenTextBoxPage();
        var textBoxFormIsPresent =  textBoxPage.CheckTextBoxForm();
        var textBoxTitle = textBoxPage.CheckTextBoxTitle();
        var textBoxLabelName = textBoxPage.GetFullNameLabelText();
        var textBoxLabelEmail = textBoxPage.GetEmailLabelText();
        var textBoxLabelCurrentAddress = textBoxPage.GetCurrentAddressLabelText();
        var textBoxLabelPermanentAddress = textBoxPage.GetPermanentAddressLabelText();
            textBoxPage.EnterFullName("Liudmyla Savinska");
            textBoxPage.EnterEmail("liudatest@test.com");
            textBoxPage.EnterCurrentAddress("200 Crescent Ave, Covington, KY 41011, United States");
            textBoxPage.EnterPermanentAddress("6834 Hollywood Blvd\nLos Angeles, California 90028-6116");
        

        Assert.Multiple(() =>
        {
            Assert.That(title, Is.EqualTo("DEMOQA"));
            Assert.That(isAccordionElementPresent, Is.True);
            Assert.That(textBoxFormIsPresent, Is.True);
            Assert.That(textBoxTitle, Is.True);
            Assert.That(textBoxLabelName, Is.EqualTo("Full Name"));
            Assert.That(textBoxLabelEmail, Is.EqualTo("Email"));
            Assert.That(textBoxLabelCurrentAddress, Is.EqualTo("Current Address"));
            Assert.That(textBoxLabelPermanentAddress, Is.EqualTo("Permanent Address"));
        });
    }
}