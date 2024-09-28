using Test.Utils.PageObjects;

namespace NUnit.Tests.UI.Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        //Arrange
        var mainPaige = new MainPaige().OpenInChrome();
        var elementsPage = mainPaige.OpenElementsPage();      
        var textBoxPage = elementsPage.OpenTextBoxPage();        
        var fullName = "Full Name";
        var email = "email@mail.com";
        var currentAddress = "Current Address";
        var permanentAddress = "Permanent Address";

        //Act
        textBoxPage.EnterFullName(fullName);
        textBoxPage.EnterEmail(email);
        textBoxPage.EnterCurrentAddress(currentAddress);
        textBoxPage.EnterPermanentAddress(permanentAddress);

        textBoxPage.ScrollToSubmitBtn();
        textBoxPage.ClickSumbit();

        var assertedFullName = textBoxPage.GetOutput().Contains(fullName);
        var assertedEmail = textBoxPage.GetOutput().Contains(email);
        var assertedCurrentAddress = textBoxPage.GetOutput().Contains(currentAddress);
        var assertedPermanentAddress = textBoxPage.GetOutput().Contains(permanentAddress);

        mainPaige.Close();

        //Assert
        Assert.Multiple(() =>
        {
            Assert.True(assertedFullName);
            Assert.True(assertedEmail);
            Assert.True(assertedPermanentAddress);
            Assert.True(assertedCurrentAddress);
        });
    }
}