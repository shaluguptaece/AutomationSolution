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

    public class LoginPage : PageBase
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;

        }
        //objects for login page
        #region 
        [FindsBy(How = How.Id, Using = "txtUsername")]
        private IWebElement txtLoginUserName;

        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "btnLogIn")]
        private IWebElement BtnLogin { get; set; }

        [FindsBy(How = How.LinkText, Using = "linktxt")]
        private IWebElement homePageLink { get; set; }

        [FindsBy(How=How.XPath, Using = ".//*[@id='ctl00_lblUserName']")]
        private IWebElement linkUserName { get; set; }

        [FindsBy(How = How.Id, Using = "InvalidCredentialsMessage")]
        private IWebElement loginErrMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='modalHeader security'][contains(.,'Set Memorable Information')]")]
        private IWebElement lblsetMemorableInformation;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'txtMemorableQuestion')]")]
        private IWebElement txtMemorableQuestion;

        [FindsBy(How= How.Id, Using = "lblMemorableQuestion_ForgotPassword")]
        private IWebElement lblMemorableQuestion;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'txtMemorableAnswer')]")]
        private IWebElement txtMemorableAnswer;

        [FindsBy(How =How.XPath, Using = "//input[contains(@name,'txtPassword_SetQuestion')]")]
        private IWebElement txtReEnterPassword;

        [FindsBy(How = How.XPath, Using = "//input[@value='Apply']")]
        private IWebElement btnApply;

        [FindsBy(How= How.XPath, Using = "//input[contains(@id,'btnApplySetQuestion')]")]
        private IWebElement btnApplySetMemorableInfoPopUp;

        [FindsBy(How = How.XPath, Using = "//input[@value='Ok']")]
        private IWebElement btnOK;

        [FindsBy(How=How.Id, Using = "lblConfirmationMessage")]
        private IWebElement lblconfirmationMessage;

        [FindsBy(How=How.Id, Using = "lnkForgotPassword")]
        private IWebElement lnkForgotPassword;

        [FindsBy(How= How.Id, Using = "lblConfirmationTitle")]
        private IWebElement lblConfirmationTitle;
        #endregion

        public IWebElement TxtLoginUserName
        {
            get
            {
                return txtLoginUserName;
            }
        }

        public IWebElement LblsetMemorableInformation
        {
            get
            {
                return lblsetMemorableInformation;
            }
        }

        public IWebElement TxtMemorableQuestion
        {
            get
            {
                return txtMemorableQuestion;
            }
        }

        public IWebElement TxtMemorableAnswer
        {
            get
            {
                return txtMemorableAnswer;
            }
        }

        public IWebElement LblMemorableQuestion
        {
            get
            {
                return lblMemorableQuestion;
            }
        }

        public IWebElement LinkForgotPassword
        {
            get
            {
                return lnkForgotPassword;
            }
        }

        public IWebElement TxtReEnterPassword
        {
            get
            {
                return txtReEnterPassword;
            }
        }
        
        public IWebElement LblConfirmationTitle
        {
            get
            {
                return lblConfirmationTitle;
            }
        }

        public IWebElement BtnApply
        {
            get
            {
                return btnApply;
            }
        }

        public IWebElement BtnOk
        {
            get
            {
                return btnOK;
            }
        }

        public IWebElement LblconfirmationMessage
        {
            get
            {
                return lblconfirmationMessage;
            }
        }

        public IWebElement BtnApplySetMemorableInfoPopUp
        {
            get
            {
                return btnApplySetMemorableInfoPopUp;
            }
        }

        public void SignIn(string username, string password)
        {
            EnterUSername(username);
            EnterPassword(password);
            ClickOnLoginButton();

           // return new HomePage(driver);
                   
        }
        //Enter username
        public void EnterUSername(string Username)
        {
            try
            {

                txtLoginUserName.SendKeys(Username);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Enter password
        public void EnterPassword(string Password)
        {
            txtPassword.SendKeys(Password);
        }

        //Click on login button
        public void ClickOnLoginButton()
        {
            BtnLogin.Click();
        }

        //Get logged in username
        public string DisplayedUser()
        {
            string LoggedInUser= linkUserName.Text;
            return LoggedInUser;
        }

        public string DisplayedInvalidCredentialsErrorMessage()
        {
            string errMsg = loginErrMsg.Text;
            return errMsg;
        }
    }
}
