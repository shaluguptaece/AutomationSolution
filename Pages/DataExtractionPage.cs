using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Edwards.Scada.Test.Framework.Pages
{
    using System.Threading;
    using Edwards.Scada.Test.Framework.Contract;

    //namespaces
    using Edwards.Scada.Test.Framework.GlobalHelper;
    using OpenQA.Selenium.Support.UI;

    public class DataExtractionPage:PageBase
    {

        private IWebDriver driver;

        public DataExtractionPage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;

        }

        //objects for DataExtractionPage
        #region 
        [FindsBy(How = How.XPath, Using = "//div[@id='divHistoricExtractions']//div[contains(@id,'btnCreateExtraction')]//input[@type='button']")]
        private IWebElement btnDataExtract { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='rawDataContainer']//div//a[contains(@id,'chkStatus')]")]
        private IWebElement chkboxStatus_RowData { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtDescription')]")]
        private IWebElement txtDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtDateSelectionFrom')]")]
        private IWebElement txtStartDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtDateSelectionTo')]")]
        private IWebElement txtEndDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnChangeGroups')]")]
        private IWebElement btnChangesSelectionGroups { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnChangeSystems')]")]
        private IWebElement btnChangesSelectionSystems { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'DataExtractionGroups_treeUserFolders')]//table[1]/tbody/tr/td/input[contains(@id,'treeUserFoldersn0CheckBox')]")]
        private IWebElement checkboxUserFolder { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'treeEquipmentTypes')]//table[1]/tbody/tr/td/input[contains(@id,'treeEquipmentTypesn0CheckBox')]")]
        private IWebElement checkboxEquipmentType { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='dataExtractionButtons']//input[contains(@id,'btnApply')]")]
        private IWebElement btnApply { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='optionButton']//input[@value='Search']")]
        private IWebElement btnSearchSystem { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='section unassignedSystemsSection']//select[@class='systemsList']")]
        private IWebElement lstSystems { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='systemListActions']//input[contains(@id,'btnMoveAllSystemsTo')]")]
        private IWebElement btnMoveAllSystems { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='dataExtractionButtons']//input[@value='Extract']")]
        private IWebElement btnExtract { get; set; }


        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cphContent_cphContent_lblExtractionInProgressMessage']")]
        private IWebElement lblMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divScrollContainer']//table[@class='mGrid']//tbody/tr[1]/td/span")]
        private IWebElement lblFileDetails { get; set; }

        #endregion
        
        public void ExtractSystemData(string Description, string StartDate, string EndDate)
        {
            
            ClickOnDataExtraction();
            SelectStatusFromDataRow();
            EnterDescriptionValue(Description);
            SelectStartDate(StartDate);
            SelectEndDate(EndDate);
            ClickOnChangeSelection_SelectedGroups();
            SelectUserFolder();
            SelectEquipmentType();
            ClickOnApply();
            ClickOnChangeSelection_SelectedSystems();
            ClickOnSearchSystem();
            Thread.Sleep(2000);
            MoveSystems();
            ClickOnApply();
            Thread.Sleep(2000);
            ClickOnExtractData();

           
        }
        public void WaitForCompleteting_DataExtraction()


        {

            By lblMessage = By.XPath(".//*[@id='ctl00_ctl00_cphContent_cphContent_lblExtractionInProgressMessage']");
          //  PageBase.WaitUntilInvisible(driver, lblMessage);
        }
        
        public bool IsSystemItemPresent()
        {            
                       
                IWebElement baseSystemList = lstSystems;
                
                SelectElement selectList = new SelectElement(baseSystemList);
                IList<IWebElement> options = selectList.Options;
            if (options.Count()> 0)
            {


                return true;

            }
            else
            {
                return false;
            }
            
        }

        public void MoveSystems()
        {
            if(IsSystemItemPresent())
            {

                ClickOnMoveAllSystem();
            }
            
        }
        public void ClickOnDataExtraction()
        {
           
            btnDataExtract.Click();
        }


       
      
        public void SelectStatusFromDataRow()
        {
            try
            {
                if(chkboxStatus_RowData.Enabled)
                {                   
                
                chkboxStatus_RowData.Click();
                }
                
                
            }

            catch(Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public void EnterDescriptionValue(String Description)
        {
            txtDescription.Clear();
            txtDescription.SendKeys(Description);
           


        }

        public void SelectStartDate(string StartDate)
        {
            txtStartDate.Clear();
            txtStartDate.SendKeys(StartDate);

           
        }
        public void SelectEndDate(string EndDate)
        {
            txtEndDate.Clear();
            txtEndDate.SendKeys(EndDate);
        }

        public void ClickOnChangeSelection_SelectedGroups()
        {
            IWebElement webElement = btnChangesSelectionGroups;
            JavaScriptExecutor.JavaScriptClick(driver,webElement);
            
            
        }
        public void ClickOnChangeSelection_SelectedSystems()
        {
            IWebElement webElement = btnChangesSelectionSystems;            
            JavaScriptExecutor.JavaScriptClick(driver, webElement);
            
        }

        public void SelectUserFolder()
        {
            try

            {
                IWebElement webElement = checkboxUserFolder;
                JavaScriptExecutor.JavaScriptClick(driver, webElement);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        public void SelectEquipmentType()
        {
            IWebElement webElement = checkboxEquipmentType;
            JavaScriptExecutor.JavaScriptClick(driver, webElement);

        }

        public void ClickOnApply()
        {
            IWebElement webElement = btnApply;
            JavaScriptExecutor.JavaScriptClick(driver, webElement);
        }

        public void ClickOnSearchSystem()
        {

            IWebElement webElement = btnSearchSystem;
            JavaScriptExecutor.JavaScriptClick(driver, webElement);

        }

        public void ClickOnMoveAllSystem()
        {
            IWebElement webElement = btnMoveAllSystems;
            JavaScriptExecutor.JavaScriptClick(driver, webElement);

        }

        public void ClickOnExtractData()
        {
            IWebElement webElement = btnExtract;
            JavaScriptExecutor.JavaScriptClick(driver, webElement);
        }

        public string IsDownloadingInProgress()
        {
            
            return lblMessage.Text;
        }

        public string FileDownloadedPath()
        {
            string s = lblFileDetails.Text;
            return s;
        }
    }
}
