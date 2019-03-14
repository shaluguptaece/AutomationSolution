using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edwards.Scada.Test.Framework.GlobalHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class HistorianPage:PageBase
    {

        private IWebDriver driver;
        public HistorianPage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;

        }

        //objects for Historian page
        #region 
        [FindsBy(How = How.XPath, Using = "//div[@class='treeView']/table//tbody")]
        private IWebElement lstFolder { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divParameters']")]
        private IWebElement lstParaMeters { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_btnLockParameters']")]
        private IWebElement btnLockParaMeters { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_btnUnlockParameters']")]
        private IWebElement btnUnLockParaMeters { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='chart_container']//*[name()='svg']//*[name()='g'][@class='highcharts-legend']//*[name()='text']//*[name()='tspan']")]
        private IWebElement lblGraphParaMeter { get; set; }

        [FindsBy(How=How.Id, Using ="ctl00_ctl00_cphContent_cphContent_lnkEditParameters")]
        private IWebElement lnkEditParaMeters { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_rptAxis_ctl00_txtMin")]
        private IWebElement txtLowerLimit { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_rptAxis_ctl00_txtMax")]
        private IWebElement txtUpperLimit { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnApplyParameters")]
        private IWebElement btnApplyParaMeters { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkClearAll")]
        private IWebElement btnClear { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnAddParameter")]
        private IWebElement btnAddParaMeter { get; set; }

        [FindsBy(How=How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkShowParameterData_lblText")]
        private IWebElement lblParameterData;
        #endregion

        //Properties
        #region
        public IWebElement LblParameterData
        {
            get
            {
                return lblParameterData;
            }
        }

        #endregion

        public void SelectSystemFolder(String FolderName)
        {
            IWebElement baseTable = lstFolder;
            IList<string> folderList = new List<string>();

            
            ICollection<IWebElement> list = baseTable.FindElements(By.XPath("//tr//span"));

            foreach (IWebElement listitem in list)
            {
                if(listitem.Text==FolderName)
                {
                    listitem.Click();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        public void SelectFirstEquipmentsFromSelectedFolder()
        {
            IWebElement baseTable = lstFolder;
            IList<string> folderList = new List<string>();

            if (IsElemetPresent(driver,By.XPath("//ancestor::table//following-sibling::div")))
            {

                
                IWebElement childItemlist = baseTable.FindElement(By.XPath("//ancestor::table//following-sibling::div//table[1]//tbody//tr//a//span"));
                
                    childItemlist.Click();            
                                 
            }
        }


        public void SelectSecondEquipmentsFromSelectedFolder()
        {
            IWebElement baseTable = lstFolder;
            IList<string> folderList = new List<string>();

            if (IsElemetPresent(driver, By.XPath("//ancestor::table//following-sibling::div")))
            {


                IWebElement childItemlist = baseTable.FindElement(By.XPath("//ancestor::table//following-sibling::div//table[2]//tbody//tr//a//span"));

                childItemlist.Click();

            }
        }

        public void  SelectParaMeter()
        {
            IWebElement baseTable = lstParaMeters;
            IList<string> folderList = new List<string>();


            ICollection<IWebElement> list = baseTable.FindElements(By.XPath("//tr//td[contains(@id,'clParameters')]"));

            foreach (IWebElement listitem in list)
            {
                if (listitem.GetAttribute("title") == "Dry Pump Power (4)")
                {
                    listitem.Click();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        public void SelectParaMeter_EquipmentStatus()
        {
            IWebElement baseTable = lstParaMeters;
            IList<string> folderList = new List<string>();


            ICollection<IWebElement> list = baseTable.FindElements(By.XPath("//tr//td[contains(@id,'clParameters')]"));

            foreach (IWebElement listitem in list)
            {
                if (listitem.GetAttribute("title") == "Equipment Status")
                {
                    listitem.Click();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        public void LockParaMeters()
        {
            ElementExtensions.ClickOnButton(btnLockParaMeters);
        }

        public void ClearGraph()
        {
            ElementExtensions.ClickOnButton(btnClear);
        }
        public void Add_EquipmentStatus_ParaMeter()
        {
            ElementExtensions.ClickOnButton(btnAddParaMeter);
        }
        public void UnLockParaMeters()
        {
            ElementExtensions.ClickOnButton(btnUnLockParaMeters);
        }

        public bool ISGraphDisplayedParameter()
        {

            if (lblGraphParaMeter.Text.Contains("ETX0002PM4:Dry Pump Power (4)"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ISRefreshHappned()
        {
            if (lblGraphParaMeter.Text.Contains("ETX0002PM4:Dry Pump Power (4)"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ModifyParaMeters()
        {
            ElementExtensions.ClickOnLink(lnkEditParaMeters);
            ElementExtensions.ClearTextValue(txtLowerLimit);
            ElementExtensions.EnterTextValue(txtLowerLimit, "2");
            ElementExtensions.ClearTextValue(txtUpperLimit);
            ElementExtensions.EnterTextValue(txtUpperLimit, "2");
            ElementExtensions.ClickOnButton(btnApplyParaMeters);
        }

    }
    
}
