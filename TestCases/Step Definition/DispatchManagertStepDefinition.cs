using Edwards.Scada.Test.Framework.Contract;
using Edwards.Scada.Test.Framework.GlobalHelper;
using Edwards.Scada.Test.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Edwards.Scada.Test.Framework.TestCases.Step_Definition
{
    [Binding]
    public sealed class DispatchManagertStepDefinition
    {
        string testFolderName = ElementExtensions.GetRandomString(4);
        string renameFolder = ElementExtensions.GetRandomString(4);
        LoginPage loginPage;
        HomePage homePage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        UserPage userPage;
        DispatchManagerPage dispatchManagerPage;
        ConfiguarationHandlerPage configuarationHandlerPage;
        HistorianPage historianPage;
        ReportPage reportPage;
        LiveAlertsListPage liveAlertsListPage;
        private IWebDriver driver;

        public DispatchManagertStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            userPage = new UserPage(driver);
            dispatchManagerPage = new DispatchManagerPage(driver);
            configuarationHandlerPage = new ConfiguarationHandlerPage(driver);
            historianPage = new HistorianPage(driver);
            reportPage = new ReportPage(driver);
            liveAlertsListPage = new LiveAlertsListPage(driver);
        }


        [Given(@"opened ADCENTRA url in browser")]
        public void GivenOpenedADCENTRAUrlInBrowser()
        {
            PageInitialization();
            driver.Navigate().GoToUrl(TestSettingsReader.EnvUrl);
        }

        [When(@"entered Username as '(.*)' and Password  as'(.*)' and I clicked login button")]
        public void WhenEnteredUsernameAsAndPasswordAsAndIClickedLoginButton(string username, string password)
        {
            loginPage.SignIn(username, password);
        }

        [Then(@"should be navigated to home page")]
        public void ThenShouldBeNavigatedToHomePage()
        {
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, homePage.LnkDeviceManager), "Verifying User should be navigated to Home page");
        }

        [When(@"selected dispatch manager option under Configure drop down")]
        public void WhenSelectedDispatchManagerOptionUnderConfigureDropDown()
        {
            Waits.Wait(driver, 2000);
            homePage.ClickOnConfiguration();
            homePage.LnkDispacthManager.Click();
            Waits.WaitForElementVisible(driver, dispatchManagerPage.TxtSiteName);
        }

        [When(@"Configure the options on the Dispatch Manager General Settings screen '(.*)'")]
        public void WhenConfigureTheOptionsOnTheDispatchManagerGeneralSettingsScreen(string siteName)
        {
            dispatchManagerPage.BtnServiceStatus.Click();
            dispatchManagerPage.TxtSiteName.Clear();
            dispatchManagerPage.TxtSiteName.SendKeys(siteName);
            Waits.Wait(driver, 15000);
            if(dispatchManagerPage.RdBtnSendBulkAlert.GetAttribute("src").Contains("off"))
            {
               JavaScriptExecutor.JavaScriptClick(driver, dispatchManagerPage.RdBtnSendBulkAlert);
                dispatchManagerPage.RdBtnSendBulkAlert.GetAttribute("src").Contains("on");
            }
            else
            {
                JavaScriptExecutor.JavaScriptClick(driver, dispatchManagerPage.RdBtnSendIndividualAlert);
                dispatchManagerPage.RdBtnSendIndividualAlert.GetAttribute("src").Contains("on");
            }
            Waits.Wait(driver, 25000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, dispatchManagerPage.ChkBoxIncludeAlertMsg);
            string isSelected = dispatchManagerPage.ChkBoxIncludeAlertMsg.GetAttribute("src");
            if (isSelected.Contains("_on_"))
            {
                JavaScriptExecutor.JavaScriptClick(driver, dispatchManagerPage.ChkBoxIncludeAlertMsg);
                dispatchManagerPage.ChkBoxIncludeAlertMsg.GetAttribute("src").Contains("off");
            }
            else
            {
                JavaScriptExecutor.JavaScriptClick(driver, dispatchManagerPage.ChkBoxIncludeAlertMsg);
                dispatchManagerPage.ChkBoxIncludeAlertMsg.GetAttribute("src").Contains("on");
            }
        }

        [When(@"Apply is used")]
        public void WhenApplyIsUsed()
        {
            dispatchManagerPage.ClickApply();
        }

        [Then(@"the settings should be saved")]
        public void ThenTheSettingsShouldBeSaved()
        {
            Waits.Wait(driver, 5000);
            Assert.IsTrue(dispatchManagerPage.LblSuccessMessage.Text.Contains("Changes have been applied"), "Changes haven't been saved");
        }

        [When(@"navigated to SMTP tab under Page Settings tab")]
        public void WhenNavigatedToSMTPTabinderPageSettingsTab()
        {
            dispatchManagerPage.LnkPageDestinations.Click();
        }
   
        [When(@"login user '(.*)' created new SMTP page From as '(.*)' destination with SMTP IP of '(.*)', port number as '(.*)' and To address as '(.*)'")]
        public void WhenCreatedNewSMTPPageFromAsDestinationWithSMTPIPOfPortNumberAsAndToAddressAs(string userName, string from, string smtpServer, string smtpPort, string toAddress)
        {
            Waits.Wait(driver, 2000);
            dispatchManagerPage.DeleteSMTPPageDestination_IfExists(userName);
            dispatchManagerPage.TxtFrom.Clear();
            dispatchManagerPage.TxtFrom.SendKeys(from);
            dispatchManagerPage.TxtSMTPServer.Clear();
            dispatchManagerPage.TxtSMTPServer.SendKeys(smtpServer);
            dispatchManagerPage.TxtSMTPPort.Clear();
            dispatchManagerPage.TxtSMTPPort.SendKeys(smtpPort);
            dispatchManagerPage.TxtToAddress.Clear();
            dispatchManagerPage.TxtToAddress.SendKeys(toAddress);
            dispatchManagerPage.BtnCreate.Click();
            Waits.Wait(driver, 2000);
            Assert.IsTrue(dispatchManagerPage.LblSuccessMessage.Text.Contains(GlobalConstants.PageDestinationCreated), "Page Destination Created message not appeared on clicking create button");
        }

        [When(@"Clicked Test button")]
        public void WhenClickedTestButton()
        {
            Waits.Wait(driver, 2000);
            dispatchManagerPage.BtnTest.Click();
        }

        [Then(@"A message '(.*)' should be displayed\.")]
        public void ThenAMessageShouldBeDisplayed_(string message)
        {
            Waits.Wait(driver, 5000);
            Assert.IsTrue(dispatchManagerPage.LblSuccessMessage.Text.Contains(message), "Success message not appeared on clicking Test button");
        }

        [When(@"navigated to General Settings page")]
        public void WhenNavigatedToGeneralSettingsPage()
        {
            dispatchManagerPage.LnkGeneralSettings.Click();
            Assert.IsTrue(driver.Url.Contains("DispatchManager/General.aspx"), "not navigated to General settings oage on clicking link");
        }

        [Then(@"General settings page should display")]
        public void ThenGeneralSettingsPageShouldDisplay()
        {
            Waits.Wait(driver, 2000);
            Assert.IsTrue(dispatchManagerPage.BtnServiceStatus.Displayed, "Service Status button is not displayed");
            Assert.IsTrue(dispatchManagerPage.TxtSiteName.Displayed, "Site Name text box is not displayed");
        }

        [When(@"Clicked on manual page")]
        public void WhenClickedOnManualPage()
        {
            dispatchManagerPage.BtnManualPage.Click();
        }

        [Then(@"'(.*)' pop-up will appear")]
        public void ThenPop_UpWillAppear(string msg)
        {
            Waits.Wait(driver, 2000);
            ElementExtensions.MouseHover(driver, dispatchManagerPage.PopUpSendMsg);
            Assert.IsTrue(dispatchManagerPage.PopUpSendMsg.Text.Contains(msg), "Send A message pop -up not opened");
        }

        [When(@"Typed in Message '(.*)' and clicked Send button")]
        public void WhenTypedInMessageAndClickedSendButton(string msg)
        {
            Waits.Wait(driver, 2000);
            JavaScriptExecutor.JavaScriptClick(driver, dispatchManagerPage.TxtAreaMsg);
            dispatchManagerPage.TxtAreaMsg.SendKeys(msg);
            dispatchManagerPage.BtnSend.Click();
        }

        [Then(@"'(.*)' message should be displayed")]
        public void ThenMessageShouldBeDisplayed(string msg)
        {
            Waits.Wait(driver, 4000);
            Assert.IsTrue(dispatchManagerPage.LblSuccessMsgManualPage.Text.Contains(msg), "Success message 'Page has been submitted' not displayed after clicking Send button");
        }

        [When(@"Press the Service status button")]
        public void WhenPressTheServiceStatusButton()
        {
            string title = dispatchManagerPage.BtnServiceStatus.GetAttribute("title");
            if (title.Equals("Pause the Paging Service"))
            {
                dispatchManagerPage.BtnServiceStatus.Click();
                Waits.Wait(driver, 8000);
            }
            else if (title.Equals("Start the Paging Service"))
            {
                dispatchManagerPage.BtnServiceStatus.Click();
                Waits.Wait(driver, 8000);
            }
        }

        [Then(@"The service status should display accordingly action taken")]
        public void ThenTheServiceStatusShouldDisplayAccordinglyActionTaken()
        {
            string title = dispatchManagerPage.BtnServiceStatus.GetAttribute("title");
            if (title.Equals("Pause the Paging Service"))
            {
                dispatchManagerPage.LblServiceStatus.Text.Contains("Running");
            }
            else if(title.Equals("Start the Paging Service"))
            {
                dispatchManagerPage.LblServiceStatus.Text.Contains("Paused");
            }
        }


     

    }
}
