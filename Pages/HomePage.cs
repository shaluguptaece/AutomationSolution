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

    public class HomePage : PageBase
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;

        }

        //objects for home page
        #region 
        [FindsBy(How = How.XPath, Using = ".//span[text()='Configure']")]
        private IWebElement lnkConfigure { get; set; }

        [FindsBy(How = How.XPath, Using = ".//span[text()='User Manager']")]
        private IWebElement lnkUserManager { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='footermenu']//a//span[text()='Logging']")]
        private IWebElement lnkLogging { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='footermenu']//a//span[text()='Dispatch Manager']")]
        private IWebElement lnkDispacthManager;

        [FindsBy(How=How.XPath, Using = ".//a//span[text()='Device Explorer']")]
        private IWebElement lnkDeviceManager { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_cphContent_rptModules_ctl00_rptComponents_ctl01_lblLinkText")]
        private IWebElement lnkLiveAlerts { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='leftmenu']//a[@class='bigicon']//span[text()='Reports']")]
        private IWebElement lnkReports { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='leftmenu']//a[@class='bigicon']//span[text()='Data Extraction Utility']")]
        private IWebElement lnkDataExtractionUtility { get; set; }

        [FindsBy(How = How.XPath, Using = "//a//span[text()='PTM']")]
        private IWebElement lnkPTM { get; set; }

        [FindsBy(How = How.XPath, Using = "//a//span[text()='Historian']")]
        private IWebElement lnkHistorian { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_lblUserName")]
        private IWebElement lnkAdministrator;

        [FindsBy(How =How.XPath, Using = "//a[contains(.,'Logout')]")]
        private IWebElement lnkLogOut;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Configuration Handler')]")]
        private IWebElement lnkConfiguarationHandler;

        #endregion

        //Properties
        #region
        public IWebElement LnkDeviceManager
        {
            get
            {
                return lnkDeviceManager;
            }
        }

        public IWebElement LnkConfiguarationHandler
        {
            get
            {
                return lnkConfiguarationHandler;
            }
        }

        public IWebElement LnkHistorian
        {
            get
            {
                return lnkHistorian;
            }
        }


        public IWebElement LnkAdministrator
        {
            get
            {
                return lnkAdministrator;
            }
        }

        public IWebElement LinkLogout
        {
            get
            {
                return lnkLogOut;
            }
        }

        public IWebElement LnkDispacthManager
        {
            get
            {
                return lnkDispacthManager;
            }
        }

        public IWebElement LnkUserManager
        {
            get
            {
                return lnkUserManager;
            }
        }

        public IWebElement LnkLogging
        {
            get
            {
                return lnkLogging;
            }
        }

        public IWebElement LnkReports
        {
            get
            {
                return lnkReports;
            }
        }

        public IWebElement LnkLiveAlerts
        {
            get
            {
                return lnkLiveAlerts;
            }
        }

 #endregion
        public CurrentUserPage NavigateToCurrentUserPage()
        {
            ClickOnConfiguration();
            ClickOnUserManager();
            return new CurrentUserPage(driver);
        }

        public DeviceExplorerNavigationPage NavigateToDeviceExplorerPage()
        {
            ClickOnDeviceExplorer();
            return new DeviceExplorerNavigationPage(driver);
        }
        public LiveAlertsListPage NavigateToLiveAlertPage()
        {
            ClickOnLiveAlertsList();
            return new LiveAlertsListPage(driver);
        }

        public ReportPage NavigateToReportPage()
        {
            ClickOnReports();
            return new ReportPage(driver);
        }

        public LoggingPage NavigateToLoggingPage()
        {
            ClickOnConfiguration();
            ClickOnLogging();
            return new LoggingPage(driver);
        }

        public DispatchManagerPage NavigateToDispatchManagerPage()
        {
            ClickOnConfiguration();
            ClickOnDispatchManager();
            return new DispatchManagerPage(driver);
        }
        public PTMPage NavigateToPTMPage()
        {
            ClickOnParameterThreasholdMonitoring();
            return new PTMPage(driver);
        }

        public DataExtractionPage NavigateToDataExtractionPage()
        {
            ClickOnDataExtractionUtility();
            return new DataExtractionPage(driver);
        }

        public HistorianPage NavigateToHistorianPage()
        {
            ElementExtensions.ClickOnLink(lnkHistorian);
            return new HistorianPage(driver);
        }

        public void ClickOnConfiguration()
        {
            lnkConfigure.Click();
        }

        public void ClickOnUserManager()
        {
            lnkUserManager.Click();
        }
        public  void ClickOnDeviceExplorer()
        {
            lnkDeviceManager.Click();
        }

        public void ClickOnLiveAlertsList()
        {
            lnkLiveAlerts.Click();
        }

        public void ClickOnReports()
        {
            lnkReports.Click();
        }

        public void ClickOnLogging()
        {
            lnkLogging.Click();
        }
        public void ClickOnParameterThreasholdMonitoring()
        {
            lnkPTM.Click();
        }
        public void ClickOnDataExtractionUtility()
        {
            lnkDataExtractionUtility.Click();
        }
        
        public void ClickOnDispatchManager()
        {
            lnkDispacthManager.Click();
        }
        
    }

    
}