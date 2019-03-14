using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Edwards.Scada.Test.Framework.Pages
{
    using Edwards.Scada.Test.Framework.Contract;
    //namespaces
    using Edwards.Scada.Test.Framework.GlobalHelper;

    public class ReportPage:PageBase 
    {

        private IWebDriver driver;

        public ReportPage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;

        }

        //objects for reportpage
        #region 
        [FindsBy(How = How.XPath, Using = "//div[@class='content']//a[text()='Consumption Report']")]
        private IWebElement lnkConsumptionReport { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='treeView']//table[1]//tbody/tr/td[3]")]
        private IWebElement lstDevice { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='ConsumptionSummary']")]
        private IWebElement lblConsumptionReportSummary { get; set; }

        [FindsBy(How = How.XPath, Using = "//iframe[@id='iframeReport']")]
        private IWebElement iFrameReport { get; set; }

        [FindsBy(How =How.XPath, Using = "//a[contains(.,'Alert Report')]")]
        private IWebElement lblAlertReport;
        #endregion

        //Properties
        #region

        public IWebElement LblAlertReport
        {
            get
            {
                return lblAlertReport;
            }
        }
        #endregion
        public void SelectConsumptionReportForSummary()
        {
            ClickOnConsumptionReport();
            ClickOnDeviceToSelect();
        }
        public void ClickOnConsumptionReport()
        {
            lnkConsumptionReport.Click();
        }

        public void ClickOnDeviceToSelect()
        {


            if (lstDevice.Displayed)
            {
                lstDevice.Click();
            }
            else
            {
                throw new Exception("No device is present");
            }
        }


        public void SwitchToReportFrame()
        {
            
            IWebElement parentFrame = driver.FindElement(By.TagName("iframe"));
            
            driver.SwitchTo().Frame(parentFrame);
        }
        public bool IsConsumptionSummaryPresent()
        {
            SwitchToReportFrame();
            //WaitForPageToLoad(driver);
            return lblConsumptionReportSummary.Displayed;
        }

        
    }
}
