using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Edwards.Scada.Test.Framework.Pages
{
    //namespaces
    using Edwards.Scada.Test.Framework.GlobalHelper;
    using OpenQA.Selenium.Interactions;
    using System.Threading;

    public class LiveAlertsListPage:PageBase 
    {
        private IWebDriver driver;

        public LiveAlertsListPage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;

        }

        //objects for Alertpage
        #region 
        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'UpdatePanelAlerts')]//table//tbody//tr[2]")]
        private IWebElement alertItem { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modalTabs']//a[text()='Alert History']")]
        private IWebElement alertHistoryTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='historyScrollBox']//table[@class='alertHistory']/tbody")]
        private IWebElement tblHistory { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'btnCloseDetails')]//input[@class='imgBtnStd']")]
        private IWebElement btnCloseAlertHistory { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='lnkErrorCount']")]
        private IWebElement lnkError { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='lnkWarningCount']")]
        private IWebElement lnkWarning { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='lnkInfoCount']")]
        private IWebElement lnkInfo_Advisory { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divErrorCount']")]
        private IWebElement tooltipError { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divWarningCount']")]
        private IWebElement tooltipWarning { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divInfoCount']")]
        private IWebElement tooltipInfoAdvisory { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ctl00_cphContent_cphContent_gvAlerts']/tbody")]
        private IWebElement lstAlarm { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ctl00_cphContent_cphContent_gvAlerts']/tbody")]
        private IWebElement lstWarning { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ctl00_cphContent_cphContent_gvAlerts']/tbody")]
        private IWebElement lstInfoAdvisory { get; set; }

        [FindsBy(How =How.XPath, Using = "//b[contains(.,'Active:')]")]
        private IWebElement lblActive;

        [FindsBy(How =How.Id, Using ="ctl00_ctl00_cphContent_cphContent_Image1")]
        private IWebElement imgLoadingIndicator;

        [FindsBy(How =How.Id, Using = "ctl00_ctl00_cphContent_cphContent_gvAlerts")]
        private IWebElement tableAlarm;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnApplyFilter")]
        private IWebElement btnApplyFilter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnShowFilter")]
        private IWebElement btnShowFilter;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterALAdvisory_imgCheckBox")]
        private IWebElement chkBoxAdvisory;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterALMinorWarning_imgCheckBox")]
        private IWebElement chkBoxMinorWarning;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterALMajorWarning_imgCheckBox")]
        private IWebElement chkboxMajorWarning;

        [FindsBy(How =How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterALMinorAlarm_imgCheckBox")]
        private IWebElement chkBoxMinorAlarm;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkFilterALMajorAlarm_imgCheckBox")]
        private IWebElement chkBoxMajorAlarm;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_lblSeverity")]
        private IWebElement lblSeverityValue;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_lblParameter")]
        private IWebElement lblParameterValue;

        [FindsBy(How =How.Id, Using = "ctl00_ctl00_cphContent_cphContent_AlertDetails_btnCloseDetails")]
        private IWebElement btnClose;
        #endregion

        //Properties
        #region

        public IWebElement ImgLoadingIndicator
        {
            get
            {
                return imgLoadingIndicator;
            }
        }

        public IWebElement LblActive
        {
            get
            {
                return lblActive;
            }
        }

        public IWebElement ChkBoxAdvisory
        {
            get
            {
                return chkBoxAdvisory;
            }
        }

        public IWebElement ChkBoxMinorWarning
        {
            get
            {
                return chkBoxMinorWarning;
            }
        }

        public IWebElement ChkboxMajorWarning
        {
            get
            {
                return chkboxMajorWarning;
            }
        }

        public IWebElement ChkBoxMinorAlarm
        {
            get
            {
                return chkBoxMinorAlarm;
            }
        }

        public IWebElement ChkBoxMajorAlarm
        {
            get
            {
                return chkBoxMajorAlarm;
            }
        }

        public IWebElement BtnApplyFilter
        {
            get
            {
                return btnApplyFilter;
            }
        }

        public IWebElement BtnShowFilter
        {
            get
            {
                return btnShowFilter;
            }
        }
        #endregion

        /// <summary>
        /// Wait till loading indicator displayed
        /// </summary>
        public void WaitTillLoadingIndicatorDisplayed()
        {
            for (int i = 1; i <= 20; i++)
            {
                if (Waits.WaitForElementVisible(driver, imgLoadingIndicator))
                {
                    Waits.Wait(driver, 1000);
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Raised All Alerts
        /// </summary>
        /// <param name="advisoryParameter"></param>
        /// <param name="majorAlarmParameter"></param>
        /// <param name="minorAlarmParameter"></param>
        /// <param name="majorWarningParameter"></param>
        /// <param name="minorWarningParameter"></param>
        /// <param name="equipmentName"></param>
        /// <returns></returns>
        public bool IsAllAlertsRaised(string advisoryParameter, string majorAlarmParameter,  string minorAlarmParameter, string majorWarningParameter, string minorWarningParameter, string equipmentName)
        {
            bool flag = false;
            try
            {
                for (int i = 1; i <= 5; i++)
                {
                    List<IWebElement> lstAlarmRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                    lstAlarmRows[i].Click();
                    Waits.Wait(driver, 10000);
                    Waits.WaitForElementVisible(driver, lblSeverityValue);
                    if (lblParameterValue.Text.Equals(majorAlarmParameter))
                    {
                        lblSeverityValue.Text.ToLower().Contains("major alarm");
                    }
                    else if (lblParameterValue.Text.Equals(minorAlarmParameter))
                    {
                        lblSeverityValue.Text.ToLower().Contains("minor alarm");
                    }
                    else if (lblParameterValue.Text.Equals(minorWarningParameter))
                    {
                        lblSeverityValue.Text.ToLower().Contains("minor warning");
                    }
                    else if (lblParameterValue.Text.Equals(majorWarningParameter))
                    {
                        lblSeverityValue.Text.ToLower().Contains("major warning");
                    }
                    else if (lblParameterValue.Text.Equals(advisoryParameter))
                    {
                        lblSeverityValue.Text.ToLower().Contains("advisory");
                    }
                    btnClose.Click();
                    Waits.Wait(driver, 8000);
                }
            }
            catch (StaleElementReferenceException)
            {
                driver.Navigate().Refresh();
                WaitTillLoadingIndicatorDisplayed();
            }
            return flag;
        }

        /// <summary>
        /// Checks All Alerts Except Advisory Raised
        /// </summary>
        /// <param name="majorAlarmParameter"></param>
        /// <param name="minorAlarmParameter"></param>
        /// <param name="majorWarningParameter"></param>
        /// <param name="minorWarningParameter"></param>
        /// <param name="equipmentName"></param>
        /// <returns></returns>
        public bool IsAllAlertsExceptAdvisoryRaised(string majorAlarmParameter, string minorAlarmParameter, string majorWarningParameter, string minorWarningParameter, string equipmentName)
        {
            bool flag = false;
            try
            {
                for (int i = 1; i <= 5; i++)
                {
                    List<IWebElement> lstAlarmRows = new List<IWebElement>(tableAlarm.FindElements(By.TagName("tr")));
                    lstAlarmRows[i].Click();
                    Waits.Wait(driver, 10000);
                    Waits.WaitForElementVisible(driver, lblSeverityValue);
                    if (lblParameterValue.Text.Equals(majorAlarmParameter))
                    {
                        lblSeverityValue.Text.ToLower().Contains("major alarm");
                    }
                    else if (lblParameterValue.Text.Equals(minorAlarmParameter))
                    {
                        lblSeverityValue.Text.ToLower().Contains("minor alarm");
                    }
                    else if (lblParameterValue.Text.Equals(minorWarningParameter))
                    {
                        lblSeverityValue.Text.ToLower().Contains("minor warning");
                    }
                    else if (lblParameterValue.Text.Equals(majorWarningParameter))
                    {
                        lblSeverityValue.Text.ToLower().Contains("major warning");
                    }
                    btnClose.Click();
                    Waits.Wait(driver, 8000);
                }
            }
            catch (StaleElementReferenceException)
            {
                driver.Navigate().Refresh();
                WaitTillLoadingIndicatorDisplayed();
            }
            return flag;
        }
        
        public void GoToAlertHistoryDetailTab()
        {
            ClickOnAlertItem();
            ClickOnAlertHistoryTab();
        }

        public void ClickOnAlertItem()
        {
            alertItem.Click();
        }

        public void ClickOnAlertHistoryTab()
        {
            alertHistoryTab.Click();
        }

        public void ClickOnCloseButton()
        {
            btnCloseAlertHistory.Click();
        }

        public string GetAlertHistoryData()
        {
            
            List<string> Cellvalue = new List<string>();
            try
            {
                IWebElement baseTable = tblHistory;
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

        public bool IsAlertHistoryDataPresent()
        {
            IWebElement baseTable = tblHistory;
            // gets all table rows
            ICollection<IWebElement> rows = baseTable.FindElements(By.TagName("tr"));
            if(rows.Count()>0)
            {
                return true;
                
            }
            else
            {
                return false;
            }
        }
        
        public void CloseAlertHistory()
        {
            ClickOnCloseButton();
        }
               
        public bool IsErrorPresent()
        {
            
            if(lnkError.GetAttribute("href").Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsWarningPresent()
        {

            if (lnkWarning.GetAttribute("href").Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsInfo_AdvisoryPresent()
        {

            if (lnkInfo_Advisory.GetAttribute("href").Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetErrorTooltipText()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(lnkError).Build().Perform();            
            // Get the Tool Tip Text
            String toolTipTxt = tooltipError.GetAttribute("title");
            System.Text.RegularExpressions.Regex nonnumeric = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string totalError =nonnumeric.Replace(toolTipTxt, String.Empty).Remove(0,1);
            

            return Convert.ToInt32(totalError);
        }

        public int GetWarningTooltipText()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(lnkWarning).Build().Perform();
            // Get the Tool Tip Text
            String toolTipTxt = tooltipWarning.GetAttribute("title");

            System.Text.RegularExpressions.Regex nonnumeric = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string totalWarning = nonnumeric.Replace(toolTipTxt, String.Empty).Remove(0,1);


            return Convert.ToInt32(totalWarning);
        }

        public int GetInfoAdvisoryTooltipText()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(lnkInfo_Advisory).Build().Perform();
            // Get the Tool Tip Text
            string toolTipTxt = tooltipInfoAdvisory.GetAttribute("title");
            System.Text.RegularExpressions.Regex nonnumeric = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string totalInfoAdvisory = nonnumeric.Replace(toolTipTxt, String.Empty).Remove(0,1);


            return Convert.ToInt32(totalInfoAdvisory);
        }

        public int ActiveErrorDisplayed()
        {
            int totalActiveAlarm = 0;
            if (IsErrorPresent())
            {
                ElementExtensions.ClickOnLink(lnkError);
                IWebElement BaseElement = lstAlarm;

                ICollection<IWebElement> ActiveAlert = BaseElement.FindElements(By.TagName("tr"));
                
                if (IsElemetPresent(driver,By.XPath("//table[@id='ctl00_ctl00_cphContent_cphContent_gvAlerts']/tbody")))
                {
                     totalActiveAlarm= ActiveAlert.Count()-1;
                }
                else
                {
                    throw new Exception("No alert are present");
                }                
            }
            
            return totalActiveAlarm;
        }

        public int ActiveWarningDisplayed()
        {
            int totalActiveWarning = 0;
            if (IsWarningPresent())
            {
                ElementExtensions.ClickOnLink(lnkWarning);
                IWebElement BaseElement = lstWarning;

                ICollection<IWebElement> ActiveWarning = BaseElement.FindElements(By.TagName("tr"));

                if (IsElemetPresent(driver, By.XPath("//table[@id='ctl00_ctl00_cphContent_cphContent_gvAlerts']/tbody")))
                {
                    totalActiveWarning = ActiveWarning.Count() - 1;
                }
                else
                {
                    throw new Exception("No warning are present");
                }
            }

            return totalActiveWarning;
        }

        public int ActiveINfoAdvisoryDisplayed()
        {
            int totalActiveInfoAdvisory = 0;
            if (IsInfo_AdvisoryPresent())
            {
                ElementExtensions.ClickOnLink(lnkInfo_Advisory);
                IWebElement BaseElement = lstInfoAdvisory;

                ICollection<IWebElement> ActiveInfoAdvisory = BaseElement.FindElements(By.TagName("tr"));

                if (IsElemetPresent(driver, By.XPath("//table[@id='ctl00_ctl00_cphContent_cphContent_gvAlerts']/tbody")))
                {
                    totalActiveInfoAdvisory = ActiveInfoAdvisory.Count() - 1;
                }
                else
                {
                    throw new Exception("No alert are present");
                }
            }

            return totalActiveInfoAdvisory;
        }
    }
}
