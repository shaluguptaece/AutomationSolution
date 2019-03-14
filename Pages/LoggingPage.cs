using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Edwards.Scada.Test.Framework.Pages
{

    //namespaces
    using Edwards.Scada.Test.Framework.GlobalHelper;
    using OpenQA.Selenium.Interactions;

    public class LoggingPage:PageBase 
    {

        private IWebDriver driver;

        public LoggingPage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;

        }

        //objects for LoggingPage
        #region 
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblNew")]
        private IWebElement lnkCreateProfile { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtProfileName')]")]
        private IWebElement txtProfileName { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlSystemType')]")]
        private IWebElement lstSystemDropdownList { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnCreate')]")]
        private IWebElement btnCreateProfile { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2//span[contains(@id,'lblTitle')]")]
        private IWebElement lblProfileTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divLeftBox']")]
        private IWebElement lstProfiles { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[contains(@id,'liEdit')]//a/div/div/div[2]")]
        private IWebElement createdProfile { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnDelete')]")]
        private IWebElement btnDeleteProfile { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//input[contains(@id,'btnOKDelete')]")]
        private IWebElement btnOKDelete { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='settingstabs']//a[text()='Equipment']")]
        private IWebElement tabEquipment { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'btnGetSystems')]//input[contains(@id,'btnGetSystems')]")]
        private IWebElement btnFindEquipment { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divAddSystemMessage']/span")]
        private IWebElement lblSystemMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divFoundsystems']//table/tbody[@class='clist']")]
        private IWebElement tblEquipmentListTable { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'gvLoggingParameters')]//tbody/tr[20]//a//img")]
        private IWebElement checkListLoggingParameter { get; set; }               

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'gvLoggingParameters')]//tbody/tr[20]//select[contains(@id,'ddlNormal')]")]
        private IWebElement dropdownlistNormal { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'gvLoggingParameters')]//tbody/tr[20]//select[contains(@id,'ddlAlert')]")]
        private IWebElement dropdownlistAlert { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='imgBtnWrapperStd']//input[contains(@id,'btnApply')]")]
        private IWebElement btnApplyChanges { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='lblFeedback']")]
        private IWebElement lblMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'gvLoggingParameters')]//tbody//tr//a//img[contains(@src,'chk_on')]")]
        private IWebElement checkedParameter { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Logging']")]
        private IWebElement lnkLogging { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Predictive Maintenance']")]
        private IWebElement lnkPredictiveMaintenance { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='logo']//a//img")]
        private IWebElement lnkHomePage { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_btnMoveSystemsTo']")]
        private IWebElement btnMoveSystemTo { get; set; }

        #endregion


        public void CreateProfile(string ProfileName)
        {
            if (IsProfileExist(ProfileName))
            {
                DeleteProfile(ProfileName);
            }
            Thread.Sleep(2000);
            ClickOnCreateProfileOption();
            Thread.Sleep(2000);
            EnterProfileName(ProfileName);
            Thread.Sleep(2000);
            SelectSystemDevice();
            Thread.Sleep(2000);
            ClickOnCreateButton();
            Thread.Sleep(2000);
        }
        public bool IsProfileExist(string ProfileName)
        {
            IWebElement baseTable = lstProfiles;
            List<string> LoggingProfileList = new List<string>();
            
            ICollection<IWebElement> list = baseTable.FindElements(By.TagName("li"));
            if(list.Count()>0)
            foreach (IWebElement listItem in list)
            {
                LoggingProfileList.Add(listItem.Text);
            }
            if (LoggingProfileList.Contains(ProfileName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ClickOnCreateProfileOption()
        {

            lnkCreateProfile.Click();
        }
        public void EnterProfileName(string ProfileName)
        {
            txtProfileName.SendKeys(ProfileName);
        }

        public void SelectSystemDevice()
        {
            SelectElement element = new SelectElement(lstSystemDropdownList);
            
            element.SelectByValue("25");           

        }

        public void NavigateToEquipmentTab()
        {
            ClickOnEquipmentTab();
        }
        public void FindEquipmentSystems()
        {
            ClickOnFindEquipment();
        }
        public string GetEquipmentListTableData()
        {

            List<string> Cellvalue = new List<string>();
            try
            {
                IWebElement baseTable = tblEquipmentListTable;
                // gets all table rows
                ICollection<IWebElement> rows = baseTable.FindElements(By.TagName("tr"));
                // for every row
                foreach (IWebElement row in rows)
                {
                    if (row.FindElement(By.XPath("td")).Displayed)
                    {
                        ICollection<IWebElement> cols = baseTable.FindElements(By.TagName("td"));
                        foreach (var entry in cols)
                        {

                            Cellvalue.Add(entry.Text);
                        }
                    }
                }
                return Cellvalue.ToString();
            }

            catch (Exception ex)
            {
                return string.Empty;
                throw new Exception(ex.Message);

            }
        }

        public bool IsEquipmentPresent()
        {
            IWebElement baseTable = tblEquipmentListTable;
            // gets all table rows
            ICollection<IWebElement> rows = baseTable.FindElements(By.TagName("tr"));
            if (rows.Count() > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public void SelectEquipmentToAssign()
        {
            IWebElement baseTable = tblEquipmentListTable;
            var rows = baseTable.FindElements(By.TagName("tr"));
            Actions builder = new Actions(driver);
            builder.Click(rows[1]).KeyDown(Keys.Shift).Click(rows[4]).KeyUp(Keys.Shift).Build().Perform();
        }
        public void DeleteProfile(string ProfileName)
        {
            if (IsProfileExist(ProfileName))
            {
                SelectCreatedProfile(ProfileName);
                ClickOnDeleteButton();
                Thread.Sleep(4000);
                ClickOkDeleteButton();
                
            }
            Thread.Sleep(3000);
        }

        

        public string GetProfileList()
        {
            IWebElement baseTable = lstProfiles;
            List<string> ProfileList = new List<string>();
            
            ICollection<IWebElement> list = baseTable.FindElements(By.TagName("li"));

            
            foreach (IWebElement listItem in list)
            {
                ProfileList.Add(listItem.Text);
            }
            return ProfileList.ToString();
        }

        public void SelectCreatedProfile(String ProfileName)
        {

            IWebElement baseTable = lstProfiles;
            List<string> ProfileList = new List<string>();

            ICollection<IWebElement> list = baseTable.FindElements(By.TagName("li"));
            foreach (IWebElement listItem in list)
            {
                if (listItem.Text == ProfileName)
                {
                    listItem.Click();
                }
                else
                {
                    continue;
                }
            }


        }

        public void SelectEquipmentAndMoveToAssign()
        {
            FindEquipmentSystems();
            Thread.Sleep(3000);
            SelectEquipmentToAssign();
            Thread.Sleep(2000);
            MoveSelectedSystemToAssign();
            Thread.Sleep(2000);
            ClickApplyChanges();
        }
        public void ClickOnCreateButton()
        {

            IWebElement webElement = btnCreateProfile;
            JavaScriptExecutor.JavaScriptClick(driver, webElement);
            //btnCreateProfile.Click();
        }

        public string GetProfileTitle()
        {
            return lblProfileTitle.Text;
        }
        public void ClickOnDeleteButton()
        {

            try
            {
                btnDeleteProfile.Click();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ClickOkDeleteButton()
        {
            IWebElement webElement = btnOKDelete;
            JavaScriptExecutor.JavaScriptClick(driver, webElement);
            
        }

        public void ClickOnEquipmentTab()
        {
            IWebElement webElement = tabEquipment;
            JavaScriptExecutor.JavaScriptClick(driver, webElement);
            //tabEquipment.Click();
        }
        public void ClickOnFindEquipment()
        {
            btnFindEquipment.Click();
        }

        public string GetNoEquipmentFoundMessage()

        {
            return lblSystemMessage.Text;
        }

        public void CheckedProfileParameter()
        {
            IWebElement webElement = checkListLoggingParameter;
            JavaScriptExecutor.JavaScriptClick(driver, webElement);
            //checkListLoggingParameter.Click();
        }

        
        public void SelectTimeINterval_Normal()
        {
            ElementExtensions.SelectByIndex(dropdownlistNormal, 1);
        }
        public void SelectTimeINterval_Alert()
        {
            ElementExtensions.SelectByIndex(dropdownlistAlert, 1);
        }
        public void ClickApplyChanges()
        {
            IWebElement webElement = btnApplyChanges;
            JavaScriptExecutor.JavaScriptClick(driver, webElement);
            //btnApplyChanges.Click();
        }
        public bool IsProfileParameterSelected()
        {
            return checkListLoggingParameter.Selected;
        }
        public bool IsProfileParameterOn()
        {
            return checkedParameter.Displayed;
        }

        public void ClickOnLoggingLink()
        {
            lnkLogging.Click();
        }
        public void ClickOnPredictiveMaintenanceLink()
        {
            lnkPredictiveMaintenance.Click();
        }

        public void NavigateToHomePage()
        {

            ElementExtensions.ClickOnLink(lnkHomePage);
            
        }

        public void MoveSelectedSystemToAssign()
        {
            
            ElementExtensions.ClickOnButton(btnMoveSystemTo);
        }
    }
}
