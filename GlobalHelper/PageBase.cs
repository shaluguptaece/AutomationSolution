using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{
    using System.Threading;
    //Namespaces
    using Edwards.Scada.Test.Framework.Contract;

    public class PageBase
    {
        private IWebDriver driver;

        /// <summary>
        /// Ctor for Initializing the page
        /// </summary>
        /// <param name="driver"></param>
        protected PageBase(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
     
        /// <summary>
        /// Wait methods for webelements and pages
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        private static Func<IWebDriver, bool> WaitForWebElementFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return true;
                return false;
            });
        }

        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;
            });
        }
        ////MEthod to wait for webdrivers
        //public static WebDriverWait GetWebdriverWait(TimeSpan timeout)
        //{
        //    ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        //    WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout)
        //    {
        //        PollingInterval = TimeSpan.FromMilliseconds(500),
        //    };
        //    wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
        //    return wait;

        //}
        //method to check if element is present on webpage or not
        public static bool IsElemetPresent(IWebDriver driver, By locator)
        {
            try
            {
                driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
        public static IWebElement GetElement(IWebDriver driver, By locator)
        {
            if (IsElemetPresent(driver,locator))
                return driver.FindElement(locator);
            else
                throw new NoSuchElementException("Element Not Found : " + locator.ToString());
        }
        //public static bool WaitForWebElement(IWebDriver driver, By locator, TimeSpan timeout)
        //{
        //    ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        //    var wait = GetWebdriverWait(timeout);
        //    var flag = wait.Until(WaitForWebElementFunc(locator));
        //    ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        //    return flag;

        //}

        //public static IWebElement WaitForWebElementInPage(IWebDriver driver, By locator, TimeSpan timeout)
        //{

        //    driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(20);
        //    var wait = GetWebdriverWait(timeout);
        //    var flag = wait.Until(WaitForWebElementInPageFunc(locator));
        //    ObjectRepository.Driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(40);
        //    return flag;

        //}
        
        //public static void WaitForPageToLoad(IWebDriver driver)
        //{
        //    TimeSpan timeout = new TimeSpan(0, 2, 30);
        //    WebDriverWait wait = new WebDriverWait(driver, timeout);
        //    IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
        //    if (executor == null)
        //        throw new ArgumentException("driver", "Driver must support javascript execution");

        //    wait.Until((d) =>

        //    {
        //        try
        //        {
        //            string readyState = executor.ExecuteScript(
        //                "if(document.readyState) return document.readyState;").ToString();
        //            return readyState.ToLower() == "complete";
        //        }
        //        catch (InvalidOperationException ex)
        //        {
        //            return ex.Message.ToLower().Contains("unable to get browser");

        //        }
        //        catch (WebDriverException ex)
        //        {
        //            return ex.Message.ToLower().Contains("Unable to connect");
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //    });
        //}


        //public static void WaitUntilInvisible(IWebDriver driver, By element, int seconds = 120)
        //{
        //    var wait = new WebDriverWait( driver, new TimeSpan(0, 0, seconds));
        //    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(element));
        //}

        

       
    }
}
