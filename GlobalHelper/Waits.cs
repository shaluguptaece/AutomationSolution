using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{
    public class Waits
    {
        /// <summary>
        /// Implicit Wait
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="time"></param>
        public static void ImplicitWait(IWebDriver driver, double time)
        {
             driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(time);
        }

        /// <summary>
        /// Make webdriver to wait
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="miliseconds"></param>
        /// <param name="maxTimeOutSeconds"></param>
        public static void Wait(IWebDriver driver, int miliseconds, int maxTimeOutSeconds = 90)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 1, maxTimeOutSeconds));
            var delay = new TimeSpan(0, 0, 0, 0, miliseconds);
            var timestamp = DateTime.Now;
            wait.Until(webDriver => (DateTime.Now - timestamp) > delay);
        }

        /// <summary>
        /// wait Till Element is Displayed
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static void WaitTillElementisclicked(IWebDriver driver, IWebElement element)
        {
            int timeoutInSeconds = 90;
            for (int i = 0; i < timeoutInSeconds; i++)
            {
                try
                {
                    if (timeoutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                        wait.Until(drv => element);

                        if (element.Displayed)
                        {
                            element.Click();
                            Wait(driver, 1000);
                            if(element.Selected)
                            {
                                break;
                            }
                            continue;
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught" + ex.Message);

                }
            }
        }

        /// <summary>
        /// Wait Until Page Loaded
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="time"></param>
        public static void WaitUntilPageLoaded(IWebDriver driver, int time)
        {
            driver.Manage().Timeouts().PageLoad= TimeSpan.FromMinutes(time);
        }

        /// <summary>
        /// Wait untill element is visible
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool WaitForElementVisible(IWebDriver driver, IWebElement element)
        {
            bool flag = false;
            int timeoutInSeconds = 90;
            for (int i = 0; i < timeoutInSeconds; i++)
            {
                try
                {
                    if (timeoutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                        wait.Until(drv => element);

                        if (element.Displayed)
                        {
                            flag = true;
                            break;
                        }
                        continue;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught" + ex.Message);
                    
                }
            }
            return flag;
        }


        /// <summary>
        /// wait Till Element is Displayed
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static void WaitUntillImageIsSelected(IWebDriver driver, IWebElement element)
        {
            int timeoutInSeconds = 90;
            for (int i = 0; i < timeoutInSeconds; i++)
            {
                try
                {
                    if (timeoutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                        wait.Until(drv => element);

                        if (element.Displayed)
                        {
                            element.Click();
                            Wait(driver, 1000);
                            if (element.GetAttribute("src").Contains("on"))
                            {
                                break;
                            }
                            continue;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught" + ex.Message);

                }
            }
        }


        /// <summary>
        /// wait Till Element is clickable
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static void WaitTillElementIsClickable(IWebDriver driver, IWebElement element)
        {
            int timeoutInSeconds = 90;
            for (int i = 0; i < timeoutInSeconds; i++)
            {
                try
                {
                    if (timeoutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                        wait.Until(drv => element);

                        if (element.Displayed)
                        {
                            element.Click();
                            break;
                        }
                            continue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught" + ex.Message);

                }
            }
        }
    }
}
