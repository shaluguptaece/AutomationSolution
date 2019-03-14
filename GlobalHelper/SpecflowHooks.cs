using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{
    [Binding]
    public class SpecflowHooks 
    {
        #region Fields
        /// <summary>
        /// private webBrowser object that may need to be used by the class that inheriting from this base. 
        /// </summary>
        public IWebDriver driver { get; set; }
        private readonly IObjectContainer _objectContainer;
        public static ExtentTest featureName;
        public static ExtentTest scenario;
        public static ExtentReports extent;
        public static ExtentTest test;
        #endregion

        //Active browse
        string browserName = TestSettingsReader.Browser;

        public SpecflowHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        /// <summary>
        /// Get Assembly directory path
        /// </summary>
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
        
        [BeforeTestRun]
        public static void InitializeReport()
        {
            string reportpath = Path.Combine(path, @"Report\ExecutionReport_" + DateTime.Now.ToString("yyyy - MM - dd h: mm:ss tt"));
            var htmlReporter = new ExtentHtmlReporter(reportpath + ".html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Build Version", "4.7.0.14");
            extent.AddSystemInfo("User Name", "Administrator");
        }

        [BeforeFeature()]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
             scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
             InitializeBrowser();
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterStep]
        public static void InsertReportingSteps(IWebDriver driver)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(ScenarioContext.Current, null);

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass("Passed");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass("Passed");
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Pass("Passed");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass("Passed");
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message)
                      .Fail("<img src=" + "" + CaptureScreenShot(driver) + "width= 200 height =200" + ">" + "<a href =" + "" + CaptureScreenShot(driver) + ">" + "Click here to open screenshot " + "</a>")
                      .Fail("Failed");

                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message)
                        .Fail("<img src=" + "" + CaptureScreenShot(driver) + "width= 200 height =200" + ">" + "<a href =" + "" + CaptureScreenShot(driver) + ">" + "Click here to open screenshot " + "</a>")
                          .Fail("Failed");
                else if (stepType == "Then")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message)
                        .Fail("<img src=" + "" + CaptureScreenShot(driver) + "width= 200 height =200" + ">" + "<a href =" + "" + CaptureScreenShot(driver) + ">" + "Click here to open screenshot " + "</a>")
                         .Fail("Failed");
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message)
                       .Fail("<img src=" + "" + CaptureScreenShot(driver) + ">" + "<a href =" + "" + CaptureScreenShot(driver) + ">" + "Click here to open screenshot " + "</a>")
                       .Fail("Failed");
            }

            ////Pending step
            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            }
        }

        [AfterScenario]
        public void AfterScenarioCleanUp(IWebDriver driver)
        {
            CleanUp();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
        }
       
        public static string CaptureScreenShot(IWebDriver driver)
        {
            String filename = string.Format("error_{0}_{1}_{2}",
                                                    FeatureContext.Current.FeatureInfo.Title.ToIdentifier(),
                                                    ScenarioContext.Current.ScenarioInfo.Title.ToIdentifier(),
                                                    DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            Screenshot screen = ((ITakesScreenshot)driver).GetScreenshot();
            String screenshotFolderPath = Path.Combine(Path.Combine(path, @"Report\Screenshots\" +filename));
            screen.SaveAsFile(screenshotFolderPath, ScreenshotImageFormat.Png);
            return screenshotFolderPath;
        }

        public static string path = Path.GetFullPath(Path.Combine(AssemblyDirectory, @"..\..\"));
        /// <summary>
        /// method to initialize the browser and define the service and arguments
        /// </summary>
        protected void InitializeBrowser()
        {
            if (browserName.Equals("IExplorer"))
            {
                InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                ieOptions.RequireWindowFocus = true;
                driver = new InternetExplorerDriver(ieOptions);
            }
            else if (browserName.Equals("Chrome"))
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                //chromeOptions.AddArguments("--start-maximized");
                chromeOptions.AddArguments("--disable-extensions");
                chromeOptions.AddArguments("--allow-running-insecure-content");
                String chromeDriverPath = Path.Combine(path, @"Drivers\chromedriver.exe");
                var chromeService = ChromeDriverService.CreateDefaultService("webdriver.chrome.driver", chromeDriverPath);
                driver = new ChromeDriver(chromeService, chromeOptions);
                scenario.Log(Status.Info, "Browser initiated");
            }
            else if (browserName.Equals("Firefox"))
            {
                String geckoDriverPath = Path.Combine(path, @"Drivers\geckodriver.exe");
                var firefoxdriverservice = FirefoxDriverService.CreateDefaultService("webdriver.gecko.drive", geckoDriverPath);
                //firefoxdriverservice.HideCommandPromptWindow = true;
                //firefoxdriverservice.SuppressInitialDiagnosticInformation = true;
                driver = new FirefoxDriver();
            }

          //  driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            Waits.Wait(driver, 100);
        }

        protected void CleanUp()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
              
            }
        }

    }

}

