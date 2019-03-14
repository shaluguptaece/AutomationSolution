using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Edwards.Scada.Test.Framework.Contract;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{

    public static class JavaScriptExecutor
    {

        public static object ExecuteScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            return executor.ExecuteScript(script);
        }
        public static void ScrollToAndClick(IWebElement element)
        {
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(30);
            element.Click();
        }

        public static void ScrollToAndClick(IWebDriver driver, By locator)
        {
            IWebElement element = PageBase.GetElement(driver, locator);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(30);
            element.Click();
        }
        public static void JavaScriptClick(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public static void JavaScriptScrollToElement(IWebDriver driver, IWebElement element)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView();", element);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught " + ex.Message);
            }
        }
    }
}
