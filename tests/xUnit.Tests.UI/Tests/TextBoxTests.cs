using OpenQA.Selenium;
using Test.Utils.PageObjects;
using Xunit;

namespace xUnit.Tests.UI.Tests
{
    public class TextBoxTests : IDisposable
    {
        private readonly MainPaige mainPage;

        public TextBoxTests()
        {
            // Initialize the main page and open it in Chrome
            mainPage = new MainPaige().OpenInChrome();
        }

        [Fact]
        public void Test1()
        {
            // Get page title and navigate through the elements
            var title = mainPage.GetPageTitle;
            var elementsPage = mainPage.OpenElementsPage();
            var isAccordionElementPresent = elementsPage.CheckAccordion();

            var textBoxPage = elementsPage.OpenTextBoxPage();
            var textBoxFormIsPresent = textBoxPage.CheckTextBoxForm();
            var textBoxTitle = textBoxPage.CheckTextBoxTitle();
            var textBoxLabelName = textBoxPage.GetFullNameLabelText();

            // Entering data into the text boxes
            textBoxPage.EnterFullName("test user");
            var textBoxLabelEmail = textBoxPage.GetEmailLabelText();
            textBoxPage.EnterEmail("test@test.ua");

            var textBoxLabelCurrentAddress = textBoxPage.GetCurrentAddressLabelText();
            textBoxPage.EnterCurrentAddress("Test street1");

            var textBoxLabelPermanentAddress = textBoxPage.GetPermanentAddressLabelText();
            textBoxPage.EnterPermanentAddress("Test street2");

            // Click the submit button to display the output
            textBoxPage.ClickSubmitButton();

            // Retrieve the output elements and validate their text
            var outputElement = textBoxPage.GetOutputElement();
            var nameOutput = outputElement.FindElement(By.Id("name")).Text;
            var emailOutput = outputElement.FindElement(By.Id("email")).Text;
            var currentAddressOutput = outputElement.FindElement(By.Id("currentAddress")).Text;
            var permanentAddressOutput = outputElement.FindElement(By.Id("permanentAddress")).Text;

            // Assertions to validate the displayed output
            Assert.Equal("DEMOQA", title);
            Assert.True(isAccordionElementPresent);
            Assert.True(textBoxFormIsPresent);
            Assert.True(textBoxTitle);
            Assert.Equal("Full Name", textBoxLabelName);
            Assert.Equal("Email", textBoxLabelEmail);
            Assert.Equal("Current Address", textBoxLabelCurrentAddress);
            Assert.Equal("Permanent Address", textBoxLabelPermanentAddress);

            Assert.Equal("Name:test user", nameOutput);
            Assert.Equal("Email:test@test.ua", emailOutput);
            Assert.Equal("Current Address :Test street1", currentAddressOutput);
            Assert.Equal("Permananet Address :Test street2", permanentAddressOutput);
        }

        // Implement IDisposable to close the browser after each test
        public void Dispose()
        {
            mainPage.Close();
        }
    }
}
