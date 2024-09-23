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
}