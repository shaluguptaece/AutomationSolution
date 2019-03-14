using Edwards.Scada.Test.Framework.GlobalHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class ConfiguarationHandlerPage : PageBase
    {
        private IWebDriver driver;

        /// <summary>
        /// Initializing page
        /// </summary>
        /// <param name="driver"></param>
        public ConfiguarationHandlerPage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;

        }

        //objects for userpage
        #region
        [FindsBy(How = How.XPath, Using = " //div[@class='treeTitle'][contains(.,'Equipment Types & Configurations')]")]
        private IWebElement lblEquipmentTypesAndConfiguarations;

        #endregion

        //Properties
        #region
        public IWebElement LblEquipmentTypesAndConfiguarations
        {
            get
            {
                return lblEquipmentTypesAndConfiguarations;
            }
            set
            {
                lblEquipmentTypesAndConfiguarations = value;
            }
        }
        #endregion
    }
}

     


