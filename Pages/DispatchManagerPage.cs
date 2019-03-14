using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Edwards.Scada.Test.Framework.GlobalHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class DispatchManagerPage:PageBase 
    {
        IWebDriver driver;
        public DispatchManagerPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects for dispatch manager page
        #region 

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Page Destinations']")]
        private IWebElement lnkPageDestinations;

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Scheduler']")]
        private IWebElement lnkScheduler { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='New Page Destination']")]
        private IWebElement btnNewPageDestination { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='settingstabs']//li//a[text()='SMTP']")]
        private IWebElement tabSMTPSetting { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='settingstabs']//li//a[text()='SMTPAuth']")]
        private IWebElement tabSMTPAuthSetting { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtFrom_SMTP')]")]
        private IWebElement txtFromEmail_SMTP { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtSMTPServer_SMTP')]")]
        private IWebElement txtSMTPServer_SMTP { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtToAddress_SMTP')]")]
        private IWebElement txtToAddressEMail_SMTP { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtFrom_SMTPAuth')]")]
        private IWebElement txtFromEmail_SMTPAuth { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtSMTPServer_SMTPAuth')]")]
        private IWebElement txtSMTPServer_SMTPAuth { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtToAddress_SMTPAuth')]")]
        private IWebElement txtToAddressEMail_SMTPAuth { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnCreate')]")]
        private IWebElement btnCreateDestination { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='infomessage']")]
        private IWebElement lblMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnDelete')]")]
        private IWebElement btnDeleteDestination { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='boxlist']")]
        private IWebElement lstPageDestination { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnNew')]")]
        private IWebElement btnNewSchedule { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlPageDestination')]")]
        private IWebElement dropdownListPageDestination { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlAlternativeDestination')]")]
        private IWebElement dropdownListAlternativePageDestination { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'chkWeekDays_lnkCheckbox')]//img")]
        private IWebElement chkBoxWeekDay { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'chkAlarm_lnkCheckbox')]//img")]
        private IWebElement chkAlarm { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnAddEquipment')]")]
        private IWebElement btnAddEquipment { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnGetSystems')]")]
        private IWebElement btnFindEquipment { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divFoundsystems']//div/table/tbody[@class='clist']")]
        private IWebElement lstEquipmentListtable { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnEquipmentModalAdd')]")]
        private IWebElement btnAddSelectedEquipment { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnAddAlert')]")]
        private IWebElement btnAddAlert { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnGetAlerts')]")]
        private IWebElement btnSearchAlerts { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divFoundAlerts']//div[contains(@id,'clAlerts')]//table//tbody[@class='clist']")]
        private IWebElement lstAlerts { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_btnAlertsModalAdd']")]
        private IWebElement btnAddSelectedAlerts { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlHourFrom')]")]
        private IWebElement dropdownHourFrom { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlMinuteFrom')]")]
        private IWebElement dropdownMinuteFrom { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlHourTo')]")]
        private IWebElement dropdownHourTo { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlMinuteTo')]")]
        private IWebElement dropdownMinuteTo { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnApply')]")]
        private IWebElement btnApply { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'gvSchedules')]/tbody")]
        private IWebElement lstScheduler { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Delete')]")]
        private IWebElement btnDelete { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnOKDelete')]")]
        private IWebElement btnOkDeleteConformation { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtSiteName")]
        private IWebElement txtSiteName;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_chkIncludeAlertMessage_imgCheckBox')]")]
        private IWebElement chkBoxIncludeAlertMsg;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtMessageBody")]
        private IWebElement txtAreaMsgBodyPrefix;

        [FindsBy(How =How.XPath, Using = "//input[contains(@class,'imgBtnSmall')]")]
        private IWebElement btnServiceStatus;

        [FindsBy(How=How.XPath, Using = "//span[contains(@id,'lblServiceStatus')]")]
        private IWebElement lblServiceStatus;

        [FindsBy(How= How.Id, Using = "ctl00_ctl00_cphContent_cphContent_rdoSendBulk_imgRadioButton")]
        private IWebElement rdBtnSendBulkAlert;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_rdoSendIndividual_imgRadioButton")]
        private IWebElement rdBtnSendIndividualAlert;

        [FindsBy(How = How.ClassName, Using = "infomessage")]
        private IWebElement lblSuccessMessage;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtFrom_SMTP")]
        private IWebElement txtFrom;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtSMTPServer_SMTP")]
        private IWebElement txtSMTPServer;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtSMTPPort_SMTP")]
        private IWebElement txtSMTPPort;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtToAddress_SMTP")]
        private IWebElement txtToAddress;

        [FindsBy(How = How.XPath, Using = "//input[@value='Create']")]
        private IWebElement btnCreate;

        [FindsBy(How = How.XPath, Using = "//input[@value='Test']")]
        private IWebElement btnTest;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_UpdatePanel1")]
        private IWebElement panelSMTPPageDestination;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphSubMenuBar_lnkGeneral")]
        private IWebElement lnkGeneralSettings;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnManualPage")]
        private IWebElement btnManualPage;

        [FindsBy(How= How.XPath, Using = "//span[contains(.,'Send a Page Message')]")]
        private IWebElement popUpSendMsg;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtMessage")]
        private IWebElement txtAreaMsg;

        [FindsBy(How =How.XPath, Using = "//input[@value='Send']")]
        private IWebElement btnSend;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblManualPageFeedback')]")]
        private IWebElement lblSuccessMsgManualPage;
       
        #endregion
        //Properties
        #region

        public IWebElement PopUpSendMsg
        {
            get
            {
                return popUpSendMsg;
            }
            set
            {
                popUpSendMsg = value;
            }
        }

        public IWebElement TxtAreaMsg
        {
            get
            {
                return txtAreaMsg;
            }
            set
            {
                txtAreaMsg = value;
            }
        }

        public IWebElement BtnSend
        {
            get
            {
                return btnSend;
            }
            set
            {
                btnSend = value;
            }
        }

        public IWebElement TxtSiteName
        {
            get
            {
                return txtSiteName;
            }
            set
            {
                txtSiteName = value;
            }
        }

        public IWebElement ChkBoxIncludeAlertMsg
        {
            get
            {
                return chkBoxIncludeAlertMsg;
            }
            set
            {
                chkBoxIncludeAlertMsg = value;
            }
        }

        public IWebElement BtnServiceStatus
        {
            get
            {
                return btnServiceStatus;
            }
            set
            {
                btnServiceStatus = value;
            }
        }

        public IWebElement LblSuccessMsgManualPage
        {
            get
            {
                return lblSuccessMsgManualPage;
            }
            set
            {
                lblSuccessMsgManualPage = value;
            }
        }

        public IWebElement TxtAreaMsgBodyPrefix
        {
            get
            {
                return txtAreaMsgBodyPrefix;
            }
            set
            {
                txtAreaMsgBodyPrefix = value;
            }
        }

        public IWebElement LblServiceStatus
        {
            get
            {
                return lblServiceStatus;
            }
            set
            {
                lblServiceStatus = value;
            }
        }

        public IWebElement RdBtnSendBulkAlert
        {
            get
            {
                return rdBtnSendBulkAlert;
            }
            set
            {
                rdBtnSendBulkAlert = value;
            }
        }

        public IWebElement RdBtnSendIndividualAlert
        {
            get
            {
                return rdBtnSendIndividualAlert;
            }
            set
            {
                rdBtnSendIndividualAlert = value;
            }
        }

        public IWebElement LblSuccessMessage
        {
            get
            {
                return lblSuccessMessage;
            }
            set
            {
                lblSuccessMessage = value;
            }
        }

        public IWebElement LnkPageDestinations
        {
            get
            {
                return lnkPageDestinations;
            }
            set
            {
                lnkPageDestinations = value;
            }
        }

        public IWebElement TxtFrom
        {
            get
            {
                return txtFrom;
            }
            set
            {
                txtFrom = value;
            }
        }

        public IWebElement TxtSMTPServer
        {
            get
            {
                return txtSMTPServer;
            }
            set
            {
                txtSMTPServer = value;
            }
        }

        public IWebElement TxtSMTPPort
        {
            get
            {
                return txtSMTPPort;
            }
            set
            {
                txtSMTPPort = value;
            }
        }

        public IWebElement TxtToAddress
        {
            get
            {
                return txtToAddress;
            }
            set
            {
                txtToAddress = value;
            }
        }

        public IWebElement BtnCreate
        {
            get
            {
                return btnCreate;
            }
            set
            {
                btnCreate = value;
            }
        }

        public IWebElement BtnTest
        {
            get
            {
                return btnTest;
            }
            set
            {
                btnTest = value;
            }
        }

        public IWebElement PanelSMTPPageDestination
        {
            get
            {
                return panelSMTPPageDestination;
            }
            set
            {
                panelSMTPPageDestination = value;
            }
        }

        public IWebElement LnkGeneralSettings
        {
            get
            {
                return lnkGeneralSettings;
            }
            set
            {
                lnkGeneralSettings = value;
            }
        }

        public IWebElement BtnManualPage
        {
            get
            {
                return btnManualPage;
            }
            set
            {
                btnManualPage = value;
            }
        }
        #endregion
        //Methods
        #region

        public void CreateNewSchedule()
        {

            ClickOnNewSchedule();
            Thread.Sleep(2000);
            SelectPageDestination();
            Thread.Sleep(2000);
            SelectWeekDaysCheckBox();
            Thread.Sleep(2000);
            ClickApply();
            Thread.Sleep(2000);
        }

        public void ModifySchedule()
        {
            SelectAlarm();
            Thread.Sleep(2000);
            AddEquipments();
            Thread.Sleep(2000);
            AddAlerts();
            Thread.Sleep(3000);
            ClickApply();
            Thread.Sleep(2000);
            SelectAlternativePageDestination();
            SelectFromHour();
            SelectFromMinute();
            SelectToHour();
            SelectToMinute();
            Thread.Sleep(2000);
            ClickApply();
            Thread.Sleep(2000);
        }
        public void CreateNewSMTPDestination(string FromEmail_SMTP,string SMTP_Server, string ToAddressEmail_SMTP)
        {
            NavigateToPageDestinationLink();
            if (!IS_SMTP_PageDestination_Exist())
            {
                
                ClickOnNewPageDestinationButton();
                SwitchToSMTP_Tab();
                EnterFromEmail_SMTP(FromEmail_SMTP);
                EnterSMTPServer(SMTP_Server);
                EnterToAddress_SMTP(ToAddressEmail_SMTP);
                ClickOnCreateDestination();
            }
            

        }
        public void CreateNewSMTPAuthDestination(string FromEmail_SMTPAuth, string SMTPAuth_Server, string ToAddressEmail_SMTPAuth)
        {
            NavigateToPageDestinationLink();
            if (!IS_SMTPAuth_PageDestination_Exist())
            {

                ClickOnNewPageDestinationButton();
                SwitchToSMTPAuth_Tab();
                EnterFromEmail_SMTPAuth(FromEmail_SMTPAuth);
                EnterSMTPAuthServer(SMTPAuth_Server);
                EnterToAddress_SMTPAuth(ToAddressEmail_SMTPAuth);
                ClickOnCreateDestination();
            }


        }

        public void DeleteSchedule()
        {
            SelectCreatedSchedule();
            Thread.Sleep(1000);
            ElementExtensions.ClickOnButton(btnDelete);
            Thread.Sleep(2000);
            ElementExtensions.ClickOnButton(btnOkDeleteConformation);
            Thread.Sleep(1000);
        }
        public bool IS_SMTP_PageDestination_Exist()
        {
            IWebElement baseTable = lstPageDestination;           

            ICollection<IWebElement> list = baseTable.FindElements(By.TagName("li"));

            if (list.Count() > 0)
            {
                if (IsElemetPresent(driver, By.XPath("//img[@alt='SMTP']")))
                {
                    if (baseTable.FindElement(By.XPath("//img[@alt='SMTP']")).GetAttribute("alt") == "SMTP")
                    {
                        return true;
                    }
                    
                }
            }

            return false;

        }

        public bool IS_SMTPAuth_PageDestination_Exist()
        {
            IWebElement baseTable = lstPageDestination;

            ICollection<IWebElement> list = baseTable.FindElements(By.TagName("li"));

            if (list.Count() > 0)
            {
                if (IsElemetPresent(driver, By.XPath("//img[@alt='SMTPAUTH']")))
                {
                    if (baseTable.FindElement(By.XPath("//img[@alt='SMTPAUTH']")).GetAttribute("alt") == "SMTPAUTH")
                    {
                        return true;
                    }

                }
            }

            return false;

        }

        public void SelectEquipments()
        {
            try
            {
                var elemTable = lstEquipmentListtable;
                var rows = elemTable.FindElements(By.TagName("tr"));
                Actions builder = new Actions(driver);
                builder.Click(rows[1]).KeyDown(Keys.Shift).Click(rows[4]).KeyUp(Keys.Shift).Build().Perform();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SelectAlerts()
        {

            var elemTable = lstAlerts;
            var rows = elemTable.FindElements(By.TagName("tr"));
            Actions builder = new Actions(driver);
            builder.Click(rows[1]).KeyDown(Keys.Shift).Click(rows[4]).KeyUp(Keys.Shift).Build().Perform();


        }

        public void AddEquipments()
        {
            ElementExtensions.ClickOnButton(btnAddEquipment);
            Thread.Sleep(1000);
            ElementExtensions.ClickOnButton(btnFindEquipment);
            Thread.Sleep(3000);
            SelectEquipments();
            Thread.Sleep(2000);
            ElementExtensions.ClickOnButton(btnAddSelectedEquipment);
            Thread.Sleep(1000);
        }

        public void AddAlerts()
        {
            ElementExtensions.ClickOnButton(btnAddAlert);
            Thread.Sleep(1000);
            ElementExtensions.ClickOnButton(btnSearchAlerts);
            Thread.Sleep(2000);
            SelectAlerts();
            Thread.Sleep(1000);
            ElementExtensions.ClickOnButton(btnAddSelectedAlerts);
            Thread.Sleep(1000);

        }

        public void SelectCreatedSchedule()
        {
            IWebElement listTable = lstScheduler;
            List<string> schedulerlist = new List<string>();
            ICollection<IWebElement> list = listTable.FindElements(By.TagName("tr"));

           ElementExtensions.ClickOnLink(driver.FindElement(By.XPath("//table[contains(@id,'gvSchedules')]/tbody/tr[" + list.Count() + "]")));
        }

        public void NavigateToPageDestinationLink()
        {
            ElementExtensions.ClickOnLink(lnkPageDestinations);
        }

        public void ClickOnNewPageDestinationButton()
        {
            ElementExtensions.ClickOnButton(btnNewPageDestination);
        }

        public void SwitchToSMTP_Tab()
        {
            ElementExtensions.ClickOnLink(tabSMTPSetting);
        }
        public void EnterFromEmail_SMTP(String Email_SMTP)
        {
            ElementExtensions.ClearTextValue(txtFromEmail_SMTP);
            ElementExtensions.EnterTextValue(txtFromEmail_SMTP, Email_SMTP);
        }

        public void EnterSMTPServer(string SMTPServer)
        {
            ElementExtensions.ClearTextValue(txtSMTPServer_SMTP);
            ElementExtensions.EnterTextValue(txtSMTPServer_SMTP, SMTPServer);
        }

        public void EnterToAddress_SMTP(string ToAddressEmail_SMTP)
        {
            ElementExtensions.ClearTextValue(txtToAddressEMail_SMTP);
            ElementExtensions.EnterTextValue(txtToAddressEMail_SMTP, ToAddressEmail_SMTP);
        }

        public void ClickOnCreateDestination()
        {
            ElementExtensions.ClickOnButton(btnCreateDestination);
        }

        public string GetConformationMessage()
        {
            
            //WaitForPageToLoad(driver);
            return ElementExtensions.GetLabelTextValue(lblMessage);
        }

        public void SwitchToSMTPAuth_Tab()
        {
            ElementExtensions.ClickOnLink(tabSMTPAuthSetting);
        }
        public void EnterFromEmail_SMTPAuth(String Email_SMTPAuth)
        {
            ElementExtensions.ClearTextValue(txtFromEmail_SMTPAuth);
            ElementExtensions.EnterTextValue(txtFromEmail_SMTPAuth, Email_SMTPAuth);
        }

        public void EnterSMTPAuthServer(string SMTPAuthServer)
        {
            ElementExtensions.ClearTextValue(txtSMTPServer_SMTPAuth);
            ElementExtensions.EnterTextValue(txtSMTPServer_SMTPAuth, SMTPAuthServer);
        }

        public void EnterToAddress_SMTPAuth(string ToAddressEmail_SMTPAuth)
        {
            ElementExtensions.ClearTextValue(txtToAddressEMail_SMTPAuth);
            ElementExtensions.EnterTextValue(txtToAddressEMail_SMTPAuth, ToAddressEmail_SMTPAuth);
        }
        public void SwitchToSchedulerTab()
        {
            ElementExtensions.ClickOnLink(lnkScheduler);
        }

        public void ClickOnNewSchedule()
        {
            ElementExtensions.ClickOnButton(btnNewSchedule);
        }
        public void SelectPageDestination()
        {
            ElementExtensions.SelectByIndex(dropdownListPageDestination, 2);
        }

        public void SelectAlternativePageDestination()
        {
            ElementExtensions.SelectByIndex(dropdownListAlternativePageDestination, 1);
        }

        public void SelectWeekDaysCheckBox()
        {
            if (!IsElemetPresent(driver, By.XPath("//a[contains(@id,'chkWeekDays_lnkCheckbox')]//img[contains(@src,'chk_on')]")))
            {
                ElementExtensions.ClickOnLink(chkBoxWeekDay);
            }
        }
        
        public void SelectAlarm()
        {
            if (!IsElemetPresent(driver, By.XPath("//a[contains(@id,'chkAlarm_lnkCheckbox')]//img[contains(@src,'chk_on')]")))
            {
                ElementExtensions.ClickOnLink(chkAlarm);
            }
        }

        public void ClickApply()
        {
            ElementExtensions.ClickOnButton(btnApply);
        }

        public void SelectFromHour()
        {
            ElementExtensions.SelectByIndex(dropdownHourFrom, 1);
        }
        public void SelectFromMinute()
        {
            ElementExtensions.SelectByIndex(dropdownMinuteFrom, 1);
        }

        public void SelectToHour()
        {
            ElementExtensions.SelectByIndex(dropdownHourTo, 10);
        }
        public void SelectToMinute()
        {
            ElementExtensions.SelectByIndex(dropdownMinuteTo, 11);
        }

        /// <summary>
        /// Delete SMTP Page Destinnation if already created
        /// </summary>
        /// <param name="userName"></param>
        public void DeleteSMTPPageDestination_IfExists(string userName)
        {
            List<IWebElement> pageDestList = new List<IWebElement> (panelSMTPPageDestination.FindElements(By.TagName("li")));
            foreach(var pageDestEle in pageDestList)
            {
                pageDestEle.FindElement(By.TagName("div")).Text.ToLower().Contains(userName.ToLower());
                {
                    pageDestEle.Click();
                    Waits.Wait(driver, 2000);
                    btnDelete.Click();
                    btnOkDeleteConformation.Click();
                    Waits.Wait(driver, 5000);
                    break;
                }
            }
        }

        #endregion

    }
}
