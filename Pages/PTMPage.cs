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

    public class PTMPage:PageBase 
    {

        private IWebDriver driver;

        public PTMPage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;

        }

        //objects for PTMPage
        #region 
        [FindsBy(How = How.XPath, Using = "//div[@class='addbox selectedbox']//span[text()='Create Profile']")]
        private IWebElement lnkCreateProfile { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtProfileName')]")]
        private IWebElement txtProfileName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divLeftBox']//ul")]
        private IWebElement lstProfiles { get; set; }
        [FindsBy(How = How.XPath, Using = "//li[contains(@id,'liEdit')]//a/div/div/div[2]")]
        private IWebElement createdProfile { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnCreate')]")]
        private IWebElement btnCreateProfile { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlSystemType')]")]
        private IWebElement lstSystemDropdownList { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='settingstabs']//a[text()='Equipment']")]
        private IWebElement tabEquipment { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'btnGetSystems')]//input[contains(@id,'btnGetSystems')]")]
        private IWebElement btnFindEquipment { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnDelete')]")]
        private IWebElement btnDeleteProfile { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//input[contains(@id,'btnOKDelete')]")]
        private IWebElement btnOKDelete { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2//span[contains(@id,'lblTitle')]")]
        private IWebElement lblProfileTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divFoundsystems']//table/tbody[@class='clist']")]
        private IWebElement tblEquipmentListTable { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'gvLoggingParameters')]//tbody/tr[1]//a//img")]
        private IWebElement checkListLoggingParameter { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Predictive Maintenance']")]
        private IWebElement lnkPredictiveMaintenance { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='submenulink_left']//a[text()='Parameter Threshold Monitoring']")]
        private IWebElement lnkParameterThreasholdMonitoring { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='imgBtnWrapperStd']//input[contains(@id,'btnApply')]")]
        private IWebElement btnApplyChanges { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[contains(@id,'gvLoggingParameters')]//tbody//tr//a//img[contains(@src,'chk_on')]")]
        private IWebElement checkedParameter { get; set; }

        #endregion

        public void CreateProfile(string ProfileName)
        {
           
            if (IsPTMProfileExist(ProfileName))
            {
                DeletePTMProfile(ProfileName);                
            }

            ClickOnCreateProfileOption();
            EnterProfileName(ProfileName);
            SelectSystemDevice();
            ClickOnCreateButton();
            Thread.Sleep(3000);
        }
        public void DeletePTMProfile(string ProfileName)
        {
            if (IsPTMProfileExist(ProfileName))
            {
              
                SelectCreatedProfile(ProfileName);
                Thread.Sleep(2000);
                ClickOnDeleteButton();
                Thread.Sleep(2000);
                ClickOkDeleteButton();
                Thread.Sleep(1000);
            }
        }
        public string GetPTMProfileList()
        {
            IWebElement baseTable = lstProfiles;
            List<string> PTMProfileList = new List<string>();

            ICollection<IWebElement> list = baseTable.FindElements(By.TagName("li"));


            foreach (IWebElement listItem in list)
            {
                PTMProfileList.Add(listItem.Text);
            }
            return PTMProfileList.ToString();
        }

        public bool IsPTMProfileExist(string ProfileName)
        {
            IWebElement baseTable = lstProfiles;
            List<string> PTMProfileList = new List<string>();

            ICollection<IWebElement> list = baseTable.FindElements(By.TagName("li"));
            foreach (IWebElement listItem in list)
            {
                PTMProfileList.Add(listItem.Text);
            }
            if (PTMProfileList.Contains(ProfileName))
            {
                return true;
            }
            else
            {
                return false;
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
        public void SelectCreatedProfile(String ProfileName)
        {

            IWebElement baseTable = lstProfiles;            

            ICollection<IWebElement> list = baseTable.FindElements(By.TagName("li"));
            foreach (IWebElement listItem in list)
            {
                if (listItem.Text == ProfileName)
                {
                    listItem.Click();
                    break;
                }
                else
                {
                    continue;
                }
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

        public void ClickOnEquipmentTab()
        {
            tabEquipment.Click();
        }
        public void ClickOnFindEquipment()
        {
            btnFindEquipment.Click();
        }

        public void ClickOnCreateButton()
        {
            btnCreateProfile.Click();
        }
        public void ClickOnDeleteButton()
        {

            try
            {
                Thread.Sleep(2000);
                btnDeleteProfile.Click();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ClickOkDeleteButton()
        {
            Thread.Sleep(2000);
            btnOKDelete.Click();
        }
        public string GetPTMProfileTitle()
        {
            return lblProfileTitle.Text;
        }

        public void CheckedProfileParameter()
        {
            checkListLoggingParameter.Click();
        }

        public void ClickApplyChanges()
        {
            btnApplyChanges.Click();
        }
        public bool IsProfileParameterSelected()
        {
            return checkListLoggingParameter.Selected;
        }
        public bool IsProfileParameterOn()
        {
            return checkedParameter.Displayed;
        }
        public void ClickOnPredictiveMaintenanceLink()
        {
            lnkPredictiveMaintenance.Click();
        }
        public void ClickOnPTMLink()
        {
            lnkParameterThreasholdMonitoring.Click();
        }
    }
}
