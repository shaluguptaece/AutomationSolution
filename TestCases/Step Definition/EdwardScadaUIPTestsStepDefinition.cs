using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases
{
    [Binding]
    public sealed class EdwardScadaUIPTestsStepDefinition 
    {
       private IWebDriver driver;

        public EdwardScadaUIPTestsStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        LoginPage loginPage;

       

        [Given(@"I opened ADCENTRA url")]
        public void GivenIOpenedADCENTRAUrl()
        {
            driver.Navigate().GoToUrl(TestSettingsReader.EnvUrl);
            loginPage = new LoginPage(driver);
        }

        [When(@"I entered wrong (.*) and (.*) and clicked login button")]
        public void WhenIEnteredWrongTestuser_AndTestAndClickedLoginButton(string username, string password)
        {
            loginPage.SignIn(username, password);
        }

        [Then(@"error message should display on login page\.")]
        public void ThenErrorMessageShouldDisplayOnLoginPage_()
        {
            loginPage.DisplayedInvalidCredentialsErrorMessage();
            Assert.AreEqual(loginPage.DisplayedInvalidCredentialsErrorMessage(), "Invalid login details entered");
        }

    }
}
