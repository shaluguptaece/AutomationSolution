using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
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
using System.Data;
using System.Threading;
using Edwards.Scada.Test.Framework.Contract;

namespace Edwards.Scada.Test.Framework.TestCases
{
    [Binding]
    public sealed class DeviceExplorerTestsStepDefinition
    {

        string testFolderName = ElementExtensions.GetRandomString(4);
        string renameFolder = ElementExtensions.GetRandomString(4);
        LoginPage loginPage;
        HomePage homePage;
        DeviceExplorerNavigationPage deviceExplorerNavigationPage;
        UserPage userPage;
        private IWebDriver driver;

        public DeviceExplorerTestsStepDefinition(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        public void PageInitialization()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            deviceExplorerNavigationPage = new DeviceExplorerNavigationPage(driver);
            userPage = new UserPage(driver);
        }


        [Given(@"I opened ADCENTRA app url")]
        public void GivenIOpenedADCENTRAAppUrl()
        {
            PageInitialization();
            driver.Navigate().GoToUrl(TestSettingsReader.EnvUrl);

        }

        [When(@"I entered '(.*)' and '(.*)' and clicked login button")]
        public void WhenIEnteredAndAndClickedLoginButton(string username, string password)
        {
            Waits.Wait(driver, 1000);
            loginPage.SignIn(username, password);
        }

        [Then(@"I should be navigated to Home page")]
        public void ThenIShouldBeNavigatedToHomePage()
        {
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, homePage.LnkDeviceManager), "Verifying User should be navigated to Home page");
        }

        [When(@"I clicked Device Explorer link")]
        public void WhenIClickedDeviceExplorerLink()
        {
            homePage.ClickOnDeviceExplorer();
        }


        [Then(@"I should be navigated to Device Explorer page")]
        public void ThenIShouldBeNavigatedToDeviceExplorerPage()
        {
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.LnkAddFolder), "Verifying User should be navigated to Device Explorer page");
        }

        [When(@"I clicked on add folder/ system icon")]
        public void GivenIClickedOnAddFolderSystemIcon()
        {
            deviceExplorerNavigationPage.ClickOnPlusToAddFolder();
        }

        [When(@"I Entered folder name and Clicked on Add button")]
        public void WhenIEnteredFolderNameAndClickedOnAddButton()
        {
            deviceExplorerNavigationPage.EnterFolderName(testFolderName);
            deviceExplorerNavigationPage.ClickOnAddToCreateFolder();
        }

        [Then(@"I should be able to see Folder Added Successfully message")]
        public void ThenIShouldBeAbleToSeeFolderAddedSuccessfullyMessage()
        {
            Assert.IsTrue(ElementExtensions.isDisplayed(driver, deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder), "Verifying 'Folder Added Successfully' message");
        }

        [When(@"I clicked OK button")]
        public void WhenIClickOKButton()
        {
            Waits.Wait(driver, 5000);
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }

        [Then(@"I should be able to see newly added folder")]
        public void ThenIShouldBeAbleToSeeNewlyAddedFolder()
        {
            Assert.IsTrue(driver.PageSource.Contains(testFolderName), "Verifying added folder");
        }

        [When(@"I click on added folder and rename")]
        public void WhenIClickOnAddedFolderAndRename()
        {
            deviceExplorerNavigationPage.ClickOnFolderHeader(testFolderName);
            deviceExplorerNavigationPage.ClickRename(renameFolder);
            deviceExplorerNavigationPage.BtnApply.Click();
        }

        [Then(@"I should be able to see Folder Renamed Successfully message and after clicking on Ok button, renamed folder should be displayed")]
        public void ThenIShouldBeAbleToSeeFolderRenamedSuccessfullyMessageAndAfterClickingOnOkButtonRenamedFolderShouldBeDisplayed()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.FolderRenamedMsg), "Verifying Folder Renamed Successfully message");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
            Assert.IsTrue(driver.PageSource.Contains(renameFolder), "Verifying Renamed folder should be displayed");
            Assert.IsTrue(deviceExplorerNavigationPage.IsFolderHidden(testFolderName), "Verified renamed folder is hidden and ipdated with new name");
        }

        [When(@"I clicked Find Equipment")]
        public void WhenIClickedFindEquipment()
        {
            deviceExplorerNavigationPage.ClickFindEquipment(testFolderName);
        }


        [When(@"I entered Equipment name, selected equipment type, Cliked Find Equipment button, selected one equipment and clicked Add button")]
        public void WhenIEnteredEquipmentNameSelectedEquipmentTypeClikedFindEquipmentButtonSelectedOneEquipmentAndClickedAddButton()
        {
            deviceExplorerNavigationPage.AddEquipmentToSystem();
        }


        [Then(@"I should be able to see Equipment Added Successfully message and after clicking Ok button, added Equipment should be displayed")]
        public void ThenIShouldBeAbleToSeeEquipmentAddedSuccessfullyMessageAndAfterClickingOkButtonAddedEquipmentShouldBeDisplayed()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.EquipmentAddedMsg), "Verifying 'Equipment Added Successfully' message");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }

        [When(@"I selected Remove from Folder and clicked on OK button")]
        public void WhenISelectedRemoveFromFolderAndClickedOnOKButton()
        {
            Waits.WaitForElementVisible(driver, deviceExplorerNavigationPage.LinktTopLevel);
            deviceExplorerNavigationPage.RemoveEquipmentFromSystemWithConformDelete();
        }


        [Then(@"I should be able to see Equipment Removed Successfully message and Equipment should be removed from device")]
        public void ThenIShouldBeAbleToSeeEquipmentRemovedSuccessfullyMessageAndEquipmentShouldBeRemovedFromDevice()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.EquipmentRemovedMsg), "Verifying 'Equipment Removed Successfully' message");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }


        [When(@"I clicked header of added folder and clicked Delete option")]
        public void WhenIClickedHeaderOfAddedFolderAndClickedDeleteOption()
        {
            deviceExplorerNavigationPage.ClickOnFolderHeader(testFolderName);
            deviceExplorerNavigationPage.ClickDelete();
        }

        [Then(@"Delete Folder window should appear to confirm your action")]
        public void ThenDeleteFolderWindowShouldAppearToConfirmYourAction()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.WindowDelete.Displayed, "Verified Delete window");
        }

        [When(@"I clicked cancel button")]
        public void WhenIClickedCancelButton()
        {
            deviceExplorerNavigationPage.BtnCancelOnDeleteWindow.Click();
        }

        [Then(@"Delete Folder window closes and no action is taken")]
        public void ThenDeleteFolderWindowClosesAndNoActionIsTaken()
        {
            Assert.IsFalse(deviceExplorerNavigationPage.WindowDelete.Displayed, "Verified Delete window closed");
        }

        [When(@"I clicked the header of the folder again and choose Delete")]
        public void WhenIClickedTheHeaderOfTheFolderAgainAndChooseDelete()
        {
            deviceExplorerNavigationPage.ClickOnFolderHeader(testFolderName);
            deviceExplorerNavigationPage.ClickDelete();
        }

        [When(@"I clicked OK button in Delete window pop -up")]
        public void WhenIClickedOKButtonInDeleteWindowPop_Up()
        {
            deviceExplorerNavigationPage.BtnOK.Click();
        }

        [Then(@"Folder Deleted Successfully is displayed and deleted Folder should no longer be visible")]
        public void ThenFolderDeletedSuccessfullyIsDisplayedAndDeletedFolderShouldNoLongerBeVisible()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains("Folder Deleted Successfully"), "Verifying 'Folder Deleted Successfully ' message");
            Assert.IsTrue(deviceExplorerNavigationPage.IsFolderHidden(testFolderName), "Verified folder shouldn't be present after delete action");
        }


        [When(@"I Added user in group with details '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' and '(.*)' and group details '(.*)' and '(.*)'")]
        public void WhenIAddedUserInGroupWithDetailsAndAndGroupDetailsAnd(string userName, string pwd, string confirmPwd, string question, string ans, string firstName, string lastName, string email, string groupName, string groupDescripton)
        {
            homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
            userPage.LnkMaintainUser.Click();
            userPage.CreateNewUser(userName, pwd, confirmPwd,question, ans, firstName, lastName, email);
            userPage.ClickOnApplyChanges();
            userPage.LnkMaintainGroup.Click();
            userPage.CreateNewGroup(groupName, groupDescripton);
            userPage.AddUserInGroup(firstName, lastName, userName);
            userPage.ApplicationPermission();
        }

        [When(@"I clicked the header of the folder and this choose Share Folder")]
        public void WhenIClickedTheHeaderOfTheFolderAndThisChooseShareFolder()
        {
            deviceExplorerNavigationPage.ClickOnFolderHeader(testFolderName);
            deviceExplorerNavigationPage.LinkShareFolder.Click();
        }

        [Then(@"Share Folder Foldername pop-up should be displayed with available and granted list\.")]
        public void ThenShareFolderFoldernamePop_UpShouldBeDisplayedWithAvailableAndGrantedList_()
        {
            deviceExplorerNavigationPage.PopUpShareFolder.Text.Contains("Share Folder " + testFolderName);
        }


        [Then(@"I selected previously created Group \('(.*)'\) from available list and transfered it to granted list and pressed Apply\.")]
        public void ThenISelectedPreviouslyCreatedGroupFromAvailableListAndTransferedItToGrantedListAndPressedApply_(string grpName)
        {
            deviceExplorerNavigationPage.selectGroupToshareFolder(grpName);
        }

        [Then(@"I selected previously created Group '(.*)' '(.*)' and '(.*)' from available list and transfered it to granted list and pressed Apply\.")]
        public void ThenISelectedPreviouslyCreatedGroupAndFromAvailableListAndTransferedItToGrantedListAndPressedApply_(string firstName, string lastName, string userName)
        {
            deviceExplorerNavigationPage.selectUserToshareFolder(firstName, lastName, userName);
        }

        [Then(@"Changes should be saved\.")]
        public void ThenChangesShouldBeSaved_()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LblSuccessMessageAfterCreatingFolder.Text.Contains(GlobalConstants.ChangesApplied), "Verified changes saved message");
        }

        [Then(@"message pop- up should be closed")]
        public void ThenMessagePop_UpShouldBeClosed()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LinktTopLevel.Displayed, "Verified Top level link in Device explorer page");
        }

        [When(@"I clicked on Home Icon in top navigation menubar")]
        public void WhenIClickedOnHomeIconInTopNavigationMenubar()
        {
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LinkHomePage);
        }

        [When(@"I clicked on user and selected logout option")]
        public void WhenIClickedOnUserAndSelectedLogoutOption()
        {
            Thread.Sleep(2000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, homePage.LnkAdministrator);
            homePage.LnkAdministrator.Click();
            homePage.LinkLogout.Click();
        }

        [Then(@"I should be able to see Set Memorable Information window")]
        public void ThenIShouldBeAbleToSeeSetMemorableInformationWindow()
        {
            Assert.IsTrue(loginPage.LblsetMemorableInformation.Displayed, "Verified  Set Memorable Information label ");
        }

        [When(@"I entered memorable question '(.*)', memorable answer '(.*)' and reentered password '(.*)'")]
        public void WhenIEnteredMemorableQuestionMemorableAnswerAndReconfirmedPassword(string memorableQuestion, string memorableAnswer, string reEnterPwd)
        {
            loginPage.TxtMemorableQuestion.SendKeys(memorableQuestion);
            loginPage.TxtMemorableAnswer.SendKeys(memorableAnswer);
            loginPage.TxtReEnterPassword.SendKeys(reEnterPwd);
        }

        [When(@"clicked Apply button")]
        public void WhenClickedApplyButton()
        {
            Waits.Wait(driver, 1000);
            loginPage.BtnApply.Click();
        }

        [Then(@"Successful message '(.*)' should appear")]
        public void ThenSuccessfulMessageShouldAppear(string message)
        {
            Assert.IsTrue(loginPage.LblconfirmationMessage.Text.Contains(message), "Verifying 'Your Memorable Question has been updated' message");
        }

        [When(@"I clicked on OK button")]
        public void WhenIClickedOnOKButton()
        {
            loginPage.BtnOk.Click();
        }

        [When(@"I clicked on Home Icon in top navigation menubar on UserPage")]
        public void WhenIClickedOnHomeIconInTopNavigationMenubarOnUserPage()
        {
            JavaScriptExecutor.JavaScriptClick(driver, userPage.LinkHomePage);
        }


        [Then(@"I should be navigated to login page")]
        public void ThenIShouldBeNavigatedToLoginPage()
        {
            Assert.IsTrue(loginPage.TxtLoginUserName.Displayed, "Verified user is navigated tologin page");
        }

        [Then(@"I should be able to see added folder in previous steps")]
        public void ThenIShouldBeAbleToSeeAddedFolderInPreviousSteps()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.IsFolderPresent(testFolderName), "Verified added folder in previous steps");
        }

        [When(@"I add new User with details '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' and '(.*)'")]
        public void WhenIAddNewUserWithDetailsAnd(string userName, string pwd, string confirmPwd, string question, string ans, string firstName, string lastName, string email)
        {
            homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
            userPage.LnkMaintainUser.Click();
            userPage.CreateNewUser(userName, pwd, confirmPwd, question, ans, firstName, lastName, email);
            userPage.ClickOnApplyChanges();
            userPage.LnkPermission.Click();
            userPage.SelectAllCheckBox.Click();
            Thread.Sleep(2000);
            userPage.BtnApplyChange.Click();
            Thread.Sleep(2000);
            Assert.IsTrue(userPage.LblChangesApplied.Text.Contains(GlobalConstants.ChangesApplied), "Verified 'Changes have been applied' message");
        }

        [When(@"I clicked on added equipment")]
        public void WhenIClickedOnAddedEquipment()
        {
            deviceExplorerNavigationPage.TxtAreaEquipment.Click();
        }

        [Then(@"Status should be running and alarm should be enabled")]
        public void ThenStatusShouldBeRunningAndAlarmShouldBeEnabled()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LblStatus.Text.Equals("Running"), "Verified running status");
            Assert.IsTrue(deviceExplorerNavigationPage.IconAlarm.Enabled, "Verified Alarm should be enabled");
        }

        [Then(@"I should be navigated to SEV page")]
        public void ThenIShouldBeNavigatedToSEVPage()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.TabOverview.Displayed, "Verified Overview tab on SEV page");
        }

        [When(@"I selected one of the options '(.*)' from the serial number drop-down")]
        public void WhenISelectedOneOfTheOptionsFromTheSerialNumberDrop_Down(string option)
        {
            ElementExtensions.SelectByIndex(deviceExplorerNavigationPage.DrpdwnSerialNumber, 2);
        }



        [Then(@"The textbox next to the serial number drop-down should briefly say Retrieving then come back with the result\.")]
        public void ThenTheTextboxNextToTheSerialNumberDrop_DownShouldBrieflySayRetrievingThenComeBackWithTheResult_()
        {
            Assert.AreEqual("Retrieving...", deviceExplorerNavigationPage.TxtBoxSerialNumber.GetAttribute("value"), "Verified Retrieving text");
            Thread.Sleep(5000);
            Assert.AreEqual("Test:AIM Software0 151,11", deviceExplorerNavigationPage.TxtBoxSerialNumber.GetAttribute("value"), "Verifeed serial number text");
        }

        [When(@"I clicked Parameters tab")]
        public void WhenIClickedParametersTab()
        {
            deviceExplorerNavigationPage.LinkParameters.Click();
        }

        [Then(@"Parameters page should show with all of the parameters for the piece of equipment")]
        public void ThenParametersPageShouldShowWithAllOfTheParametersForThePieceOfEquipment()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LblTemperature.Displayed, "Verified Temperature field on Parameters tab");
            Assert.IsTrue(deviceExplorerNavigationPage.LblPressure.Displayed, "Verified Pressure field on Parameters tab");
            Assert.IsTrue(deviceExplorerNavigationPage.LblFlow.Displayed, "Verified Flow field on Parameters tab");
            Assert.IsTrue(deviceExplorerNavigationPage.LblCurrent.Displayed, "Verified Current field on Parameters tab");
            Assert.IsTrue(deviceExplorerNavigationPage.LblPower.Displayed, "Verified Power field on Parameters tab");
            Assert.IsTrue(deviceExplorerNavigationPage.LblRotationalSpeed.Displayed, "Verified Rotational Speed field on Parameters tab");
        }

        [When(@"I clicked the Guage tab")]
        public void WhenIClickedTheGuageTab()
        {
            Thread.Sleep(1000);
            deviceExplorerNavigationPage.LinkGuages.Click();
        }

        [Then(@"Gauges page should show with all of the gauged parameters for the piece of equipment")]
        public void ThenGaugesPageShouldShowWithAllOfTheGaugedParametersForThePieceOfEquipment()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LblBoxMBTempGuages.Displayed, "Verified Guage MB  temperature ");
        }

        [Then(@"should see a drop-down box with a list of parameters that you can add to the graph")]
        public void ThenShouldSeeADrop_DownBoxWithAListOfParametersThatYouCanAddToTheGraph()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.DrpDwnSelectParameters.Displayed, "Verified selection parameters dropdown");
        }

        [When(@"I clicked the Graph tab")]
        public void WhenIClickedTheGraphTab()
        {
            deviceExplorerNavigationPage.LnkGraph.Click();
        }

        [Then(@"I should be able to see Reset button")]
        public void ThenIShouldBeAbleToSeeResetButton()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.BtnResetGraph.Displayed, "Verified Reset button");
        }

        [When(@"I clicked Reset button")]
        public void WhenIClickedResetButton()
        {
            deviceExplorerNavigationPage.BtnResetGraph.Click();
        }

        [Then(@"The graph should be removed and you will be left with the ""(.*)"" drop-down and graph plaeholder image\.")]
        public void ThenTheGraphShouldBeRemovedAndYouWillBeLeftWithTheDrop_DownAndGraphPlaeholderImage_(string p0)
        {
            Assert.IsTrue(deviceExplorerNavigationPage.DrpDwnSelectParameters.Displayed, "Verified selection parameters dropdown");
            Assert.IsTrue(!deviceExplorerNavigationPage.BtnResetGraph.Displayed);
        }
        [Then(@"I selected MB Temp \(ºC\) clicked the Add button")]
        public void ThenISelectedMBTempºCClickedTheAddButton()
        {
            ElementExtensions.SelectByIndex(deviceExplorerNavigationPage.DrpDwnSelectParameters, 0);
            deviceExplorerNavigationPage.BtnAddGraph.Click();
        }


        [When(@"I clicked on Add button, selected create/commission and provided all required parameters '(.*)', '(.*)', ""(.*)"" and clicked on Add button")]
        public void WhenIClickedOnAddButtonSelectedCreateCommissionAndProvidedAllRequiredParametersAndClickedOnAddButton(string equipmentType, string iPAdress, string iPPortNumber)
        {
            Thread.Sleep(2000);
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.LnkAddDevice);
            deviceExplorerNavigationPage.LnkCreateCommission.Click();
            string equipmentName = ElementExtensions.GetRandomAlphabeticalString(6);
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
        }

        [Then(@"device should be commissioned and appropriate message should be displayed")]
        public void ThenDeviceShouldBeCommissionedAndAppropriateMessageShouldBeDisplayed()
        {
            Thread.Sleep(3000);
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }

        [When(@"I clicked the header of the folder selected decommission")]
        public void WhenIClickedTheHeaderOfTheFolderSelectedDecommission()
        {
            Thread.Sleep(2000);
            deviceExplorerNavigationPage.LblEquipment.Click();
            deviceExplorerNavigationPage.LnkDecommission.Click();
        }


        [Then(@"device should be decommissioned and appropriate message should be displayed")]
        public void ThenDeviceShouldBeDecommissionedCommissionedAndAppropriateMessageShouldBeDisplayed()
        {
            JavaScriptExecutor.JavaScriptClick(driver, deviceExplorerNavigationPage.BtnOkOnDecommissionPopUP);
            Assert.IsTrue(deviceExplorerNavigationPage.GetConformationMessage().Contains("The equipment has been decommissioned successfully."), "Verified 'The equipment has been decommissioned successfully.'");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }

        [When(@"I selected comissioned option and provided all required parameters '(.*)','(.*)', '(.*)', '(.*)' and clicked on Add button")]
        public void WhenISelectedComissionedOptionAndProvidedAllRequiredParametersAndClickedOnAddButton(string equipmentName, string equipmentType, string iPAdress, string iPPortNumber)
        {
            deviceExplorerNavigationPage.LnkAddDevice.Click();
            deviceExplorerNavigationPage.LnkCommission.Click();
            deviceExplorerNavigationPage.EnterCommissionedDetails(equipmentName, equipmentType, iPAdress, iPPortNumber);
        }

        [When(@"deleted all equipments")]
        public void WhenDeletedAllEquipments()
        {
            deviceExplorerNavigationPage.DeleteAllEquipments(driver);
        }


        [When(@"I set up user who has Device Explorer permission with details (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenISetUpUserWhoHasPermissionToDeviceExplorerViewAndMaintenancePermissionWithDetailsTestuserTestTestTestUserTestuserAtlascopco_ComDeviceExplorerViewCommission
            (string username, string password, string confirmPassword, string question, string ans, string firstName, string lastName, string email, string feature, string column1, string column2)
        {
            homePage.ClickOnConfiguration();
            homePage.ClickOnUserManager();
            userPage.LnkMaintainUser.Click();
            userPage.CreateNewUser(username, password, confirmPassword, question, ans, firstName, lastName, email);
            userPage.ClickOnApplyChanges();
            userPage.LnkPermission.Click();
            Thread.Sleep(2000);
            userPage.SelectPermissionCheckBoxes("user permission", feature, column1);
            Thread.Sleep(2000);
            userPage.BtnApplyChange.Click();
            Thread.Sleep(15000);
            userPage.SelectPermissionCheckBoxes("user permission",feature, column2);
            Thread.Sleep(1000);
            userPage.BtnApplyChange.Click();
            Thread.Sleep(2000);
            Assert.IsTrue(userPage.LblChangesApplied.Text.Contains(GlobalConstants.ChangesApplied), "Verified 'Changes have been applied' message");
        }

      
        [Then(@"I selected previously created user (.*), (.*) and (.*) from available list and transfered it to granted list and pressed Apply\.")]
        public void ThenISelectedPreviouslyCreatedUserTestUserAndTestuserFromAvailableListAndTransferedItToGrantedListAndPressedApply_(string firstName, string lastName, string userName)
        {
            deviceExplorerNavigationPage.selectUserToshareFolder(firstName, lastName, userName);
        }

        [When(@"entered (.*) and (.*) and clicked login button")]
        public void WhenEnteredTestuserAndTestAndClickedLoginButton(string username, string password)
        {
            loginPage.SignIn(username, password);
        }

        [When(@"I entered memorable question '(.*)', memorable answer '(.*)' and reenter password (.*)")]
        public void WhenIEnteredMemorableQuestionMemorableAnswerAndReenterPasswordTest(string memorableQuestion, string memorableAnswer, string reEnterPwd)
        {
            loginPage.TxtMemorableQuestion.SendKeys(memorableQuestion);
            loginPage.TxtMemorableAnswer.SendKeys(memorableAnswer);
            loginPage.TxtReEnterPassword.SendKeys(reEnterPwd);
        }

        [When(@"I clicked on Top Level link")]
        public void WhenIClickedOnTopLevelLink()
        {
            deviceExplorerNavigationPage.LinktTopLevel.Click();
        }

        [Then(@"A context menu opened with the option to Set Maintenance to ON")]
        public void ThenAContextMenuOpenedWithTheOptionToSetMaintenanceToON()
        {
            Thread.Sleep(1000);
            deviceExplorerNavigationPage.ClickOnEquipmentHeader();
            Assert.IsTrue(deviceExplorerNavigationPage.LnkSetMaintenanceOn.Displayed, "Verified context menu opened with the option to Set Maintenance to ON");
        }

        [When(@"Selected this option to turn Maintenance Mode on")]
        public void WhenSelectedThisOptionToTurnMaintenanceModeOn()
        {
            deviceExplorerNavigationPage.ClickLinkEquipmentMaintenanceOn("on");
        }

        [Then(@"A message saying that maintenance is set to on is displayed and the item updates to show the maintenance icon")]
        public void ThenAMessageSayingThatMaintenanceIsSetToOnIsDisplayedAndTheItemUpdatesToShowTheMaintenanceIcon()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.GetConformationMessage().Contains(GlobalConstants.TurnMaintenanceModeOn), "Verified Selected this option to turn Maintenance Mode on");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }

        [When(@"I clicked again Equipment header")]
        public void WhenIClickedAgainEquipmentHeader()
        {
            Thread.Sleep(2000);
            deviceExplorerNavigationPage.ClickOnEquipmentHeader();
        }

        [Then(@"A context menu opened with the option to Set Maintenance to OFF")]
        public void ThenAContextMenuOpenedWithTheOptionToSetMaintenanceToOFF()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.LnkSetMaintenanceOff.Displayed, "Verified context menu opened with the option to Set Maintenance to Off");
        }

        [When(@"I selected this option to turn Maintenance Mode off")]
        public void WhenISelectedThisOptionToTurnMaintenanceModeOff()
        {
            deviceExplorerNavigationPage.ClickLinkEquipmentMaintenanceOn("off");
        }

        [Then(@"A message saying that maintenance is set to off is displayed and the item updates to remove the maintenance icon\.")]
        public void ThenAMessageSayingThatMaintenanceIsSetToOffIsDisplayedAndTheItemUpdatesToRemoveTheMaintenanceIcon_()
        {
            Assert.IsTrue(deviceExplorerNavigationPage.GetConformationMessage().Contains(GlobalConstants.TurnMaintenanceModeOff), "Verified Selected this option to turn Maintenance Mode off");
            deviceExplorerNavigationPage.ClickOkAfterConformationMessage();
        }

        [Then(@"A context menu opened with the option to Delete")]
        public void ThenAContextMenuOpenedWithTheOptionToDelete()
        {
            Thread.Sleep(1000);
            deviceExplorerNavigationPage.ClickOnEquipmentHeader();
            Assert.IsTrue(deviceExplorerNavigationPage.LnkDelete.Displayed, "Verified context menu opened with the option to Delete");
        }

        [Then(@"I should get a context menu with Commission or Decommission options depending on the state of the system")]
        public void ThenIShouldGetAContextMenuWithCommissionOrDecommissionOptionsDependingOnTheStateOfTheSystem()
        {
            Thread.Sleep(2000);
            deviceExplorerNavigationPage.ClickOnEquipmentHeader();
            Assert.IsTrue(deviceExplorerNavigationPage.LnkCommission.Displayed || deviceExplorerNavigationPage.LnkDecommission.Displayed, "Verified context menu opened with the option to Delete");
        }

    }

}


