using OpenQA.Selenium;
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
        var textBoxForIsPresent =  textBoxPage.CheckTextBoxForm();
        var textBoxTitle = textBoxPage.CheckTextBoxTitle();
        var textBoxLabelName = textBoxPage.GetFullNameLabelText();

            textBoxPage.EnterFullName("test user");

        var textBoxLabelEmail = textBoxPage.GetEmailLabelText();
            textBoxPage.EnterEmail("test@test.ua");

        var textBoxLabelCurrentAddress = textBoxPage.GetCurrentAddressLabelText();
            textBoxPage.EnterCurrentAddress("Test street1");

        var textBoxLabelPermanentAddress = textBoxPage.GetPermanentAddressLabelText();
        textBoxPage.EnterPermanentAddress("Test street2");

        textBoxPage.ClickSubmitButton();

        // output field
        var outputElement = textBoxPage.GetOutputElement();
        var nameOutput = outputElement.FindElement(By.Id("name")).Text;
        var emailOutput = outputElement.FindElement(By.Id("email")).Text;
        var currentAddressOutput = outputElement.FindElement(By.Id("currentAddress")).Text;
        var permanentAddressOutput = outputElement.FindElement(By.Id("permanentAddress")).Text;
        
        Assert.Multiple(() =>
        {
            Assert.That(title, Is.EqualTo("DEMOQA"));
            Assert.That(isAccordionElementPresent, Is.True);
            Assert.That(textBoxForIsPresent, Is.True);
            Assert.That(textBoxTitle, Is.True);
            Assert.That(textBoxLabelName, Is.EqualTo("Full Name"));
            Assert.That(textBoxLabelEmail, Is.EqualTo("Email"));
            Assert.That(textBoxLabelCurrentAddress, Is.EqualTo("Current Address"));
            Assert.That(textBoxLabelPermanentAddress, Is.EqualTo("Permanent Address"));

            Assert.That(nameOutput, Is.EqualTo("Name:test user"));
            Assert.That(emailOutput, Is.EqualTo("Email:test@test.ua"));
            Assert.That(currentAddressOutput, Is.EqualTo("Current Address :Test street1"));
            Assert.That(permanentAddressOutput, Is.EqualTo("Permananet Address :Test street2"));
        });
        mainPaige.Close();
    }
}