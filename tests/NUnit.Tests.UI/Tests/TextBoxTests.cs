using Bogus;
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
        // var faker = new Faker();
        // var fullName = faker.Name.FirstName();
        // var email = faker.Internet.Email();
        // var currentAddress = faker.Address.StreetName();
        // var permanentAddress = faker.Address.StreetName();
        var fullName = "Full Name";
        var email = "email@mail.com";
        var currentAddress = "Current Address";
        var permanentAddress = "Permanent Address";

        //Act
        textBoxPage.EnterFullName(fullName);
        textBoxPage.EnterEmail(email);
        textBoxPage.EnterCurrentAddress(currentAddress);
        textBoxPage.EnterPermanentAddress(permanentAddress);

        textBoxPage.ClickSumbit();

        var assertedFullName = textBoxPage.GetDisplayedFullName().Contains(fullName);
        var assertedEmail = textBoxPage.GetDisplayedEmail().Contains(email);
        var assertedCurrentAddress = textBoxPage.GetDisplayedCurrentAddress().Contains(currentAddress);
        var assertedPermanentAddress = textBoxPage.GetDisplayedPermanentAddress().Contains(permanentAddress); 

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