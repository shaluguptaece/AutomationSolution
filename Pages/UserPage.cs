using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Edwards.Scada.Test.Framework.GlobalHelper;
using System.Collections.Generic;

namespace Edwards.Scada.Test.Framework.Pages
{
    public class UserPage : PageBase
    {

        private IWebDriver driver;

        /// <summary>
        /// Initializing page
        /// </summary>
        /// <param name="driver"></param>
        public UserPage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;
        }

        //objects for userpage
        #region
        [FindsBy(How = How.XPath, Using = "//span[text()='Create User']")]
        private IWebElement pageTitleCreateUser { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[contains(@id,'txtUserName')]")]
        private IWebElement txtUserName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[contains(@id,'txtPassword')]")]
        private IWebElement txtPassword { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[contains(@id,'txtConfirmPassword')]")]
        private IWebElement txtConformPassword { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[contains(@id,'txtFirstName')]")]
        private IWebElement txtFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[contains(@id,'txtLastName')]")]
        private IWebElement txtLastName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[contains(@id,'txtEmail')]")]
        private IWebElement txtEmail { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[contains(@id,'btnCreate')]")]
        private IWebElement btnCreateUser { get; set; }

        [FindsBy(How = How.XPath, Using = ".//span[contains(@id,'lblFeedback')]")]
        private IWebElement lblConformationMessage { get; set; }

        [FindsBy(How =How.XPath, Using = "//input[@value='Cancel']")]
        private IWebElement btnCancel { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[contains(@id,'btnDelete')]")]
        private IWebElement btnDeleteUser { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[contains(@id,'btnApply')]")]
        private IWebElement btnApplyChange;

        [FindsBy(How = How.XPath, Using = ".//*[@id='divLeftBox']")]
        private IWebElement lstUsername { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='modalButtons']//div[@class='imgBtnWrapperStd']//input[contains(@id,'btnOKDelete')]")]
        private IWebElement btnConformDelete { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Maintain Users')]")]
        private IWebElement lnkMaintainUser;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Maintain Groups')]")]
        private IWebElement lnkMaintainGroup;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'txtGroupName')]")]
        private IWebElement txtGroupName;

        [FindsBy(How = How.XPath, Using = "//textarea[contains(@name,'txtDescription')]")]
        private IWebElement txtGroupDescription;

        [FindsBy(How = How.XPath, Using = "//input[@value='Create']")]
        private IWebElement btnCreate;

        [FindsBy(How = How.XPath, Using = "//a[@id='ctl00_ctl00_cphContent_cphContent_lnkUsers']")]
        private IWebElement lnkUsers;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnMoveTo')]")]
        private IWebElement btnMoveTo;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Perms')]")]
        private IWebElement lnkPermission;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_chkAll_imgCheckBox')]")]
        private IWebElement selectAllCheckBox;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Changes have been applied')]")]
        private IWebElement lblChangesApplied;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblLinkText')][contains(.,'Home')]")]
        private IWebElement linkHomePage;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_cphContent_cphContent_updPerms']/table/tbody")]
        private IWebElement tblUserPermission;

        [FindsBy(How =How.Id, Using ="ctl00_ctl00_cphContent_cphContent_pnlSettings")]
        private IWebElement tblGrpPermission;

        [FindsBy(How = How.XPath, Using = "//img[@alt='add']")]
        private IWebElement lnkCreateUser;

        [FindsBy(How =How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblNew")]
        private IWebElement lnkCreateGroup;

        [FindsBy(How=How.XPath, Using = "//span[@id='ctl00_ctl00_cphContent_cphContent_lblUserName']")]
        private IWebElement lblCreateUser;

        [FindsBy(How =How.XPath, Using = "//span[contains(@id,'rfvUsername')]")]
        private IWebElement msgUserNameRequiredField;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'ctl00_ctl00_cphContent_cphContent_rfvGroupName')]")]
        private IWebElement msgGroupNameRequiredField;

        [FindsBy(How =How.XPath, Using = "//span[contains(@id,'rfvPassword')]")]
        private IWebElement msgPasswordRequiredField;

        [FindsBy(How =How.XPath, Using = "//span[contains(@id,'rfvConfirmPassword')]")]
        private IWebElement msgCfmPasswordRequiredField;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_cvConfirmPassword")]
        private IWebElement msgPasswordDoNotMatch;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'rfvFirstName')]")]
        private IWebElement msgFirstNameRequiredField;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'rfvLastName')]")]
        private IWebElement msgLastNameRequiredField;

        [FindsBy(How =How.XPath, Using = "//span[contains(@id,'rfvEmail')]")]
        private IWebElement msgEmailRequiredField;

        [FindsBy(How= How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkDetails")]
        private IWebElement tabUSerDetails;

        [FindsBy(How=How.XPath, Using = "//a[contains(.,'Current User')]")]
        private IWebElement lnkCurrentUser;

        [FindsBy(How =How.XPath, Using = "//span[contains(@id,'lblUsername')]")]
        private IWebElement lblUserNameCurrentUserTab;

        [FindsBy(How= How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblUserName")]
        private IWebElement lblUserNameMaintainUserTab;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtLastName")]
        private IWebElement txtLastNameMaintainUserTab;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtEmail")]
        private IWebElement txtEmailMaintainUserTab;

        [FindsBy(How=How.XPath, Using = "//input[contains(@name,'txtLastName')]")]
        private IWebElement txtLastNameCurrentUserTab;

        [FindsBy(How =How.XPath, Using = "//input[contains(@name,'txtEmail')]")]
        private IWebElement txtEmailIdCurrentUserTab;

        [FindsBy(How= How.XPath, Using = "//span[contains(.,'Set Memorable Information')]")]
        private IWebElement lnkSetMemorableInformation;

        [FindsBy(How =How.XPath, Using = "//input[@value='Ok']")]
        private IWebElement btnOk;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'txtMemorableQuestion')]")]
        private IWebElement txtMemorableQuestion;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'txtMemorableAnswer')]")]
        private IWebElement txtMemorableAnswer;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'txtPassword_SetQuestion')]")]
        private IWebElement txtReEnterPassword;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblConfirmationMessage")]
        private IWebElement lblconfirmationMessage;

        [FindsBy(How =How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblChangePassword")]
        private IWebElement lnkChangePassword;

        [FindsBy(How =How.XPath, Using = "//span[contains(.,'Change password.')]")]
        private IWebElement lblChangePassword;

        [FindsBy(How =How.Id, Using = "txtOldPassword")]
        private IWebElement txtCurrentPassword;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtNewPassword1")]
        private IWebElement txtNewPassword;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_txtNewPassword2")]
        private IWebElement txtConfirmNewPassword;

        [FindsBy(How =How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnApplyChangePW")]
        private IWebElement btnApplyOnChangePwdPopUp;

        [FindsBy(How =How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblFeedback")]
        private IWebElement lblconfimationMessage;

        [FindsBy(How = How.Id, Using = "spnDeleteMessage")]
        private IWebElement lblDeleteConfirmationMsg;

        [FindsBy(How = How.XPath, Using = "//img[contains(@id,'ctl00_ctl00_cphContent_cphContent_rdoAutoAlertYes_imgRadioButton')]")]
        private IWebElement radioBtnAutoAlerts;

        [FindsBy(How =How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkAlerts")]
        private IWebElement lnkAlerts;

        [FindsBy(How =How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkGroups")]
        private IWebElement lnkGroup;

        [FindsBy(How =How.Id, Using = "ctl00_ctl00_cphContent_cphContent_clGroupsAssigned_divListControl")]
        private IWebElement lstGrpAssigned;

        [FindsBy(How= How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkViewAlertsAdvisory_imgCheckBox")]
        private IWebElement chkBoxAdvisory;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkViewAlertsMinorWarning_imgCheckBox")]
        private IWebElement chkBoxMinorWarning;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkViewAlertsMajorWarning_imgCheckBox")]
        private IWebElement chkBoxMajorWarning;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkViewAlertsMinorAlarm_imgCheckBox")]
        private IWebElement chkBoxMinorAlarm;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_chkViewAlertsMajorAlarm_imgCheckBox")]
        private IWebElement chkBoxMajorAlarm;

        [FindsBy(How =How.Id, Using = "ctl00_ctl00_cphContent_cphContent_rdoViewAlertsUseGroup_imgRadioButton")]
        private IWebElement radioButtonUseGroup;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_rdoViewAlertsNo_imgRadioButton")]
        private IWebElement radioButtonViewAlerts_No;
        #endregion

        //Properties
        #region
        public IWebElement TxtEmail
        {
            get { return txtEmail; }
            set { txtEmail = value; }
        }
         
        public IWebElement RadioButtonViewAlerts_No
        {
            get
            {
                return radioButtonViewAlerts_No;
            }
            set
            {
                radioButtonViewAlerts_No = value;
            }
        }

        public IWebElement BtnCancel
        {
            get
            {
                return btnCancel;
            }
            set
            {
                btnCancel = value;
            }
        }

        public IWebElement TxtPassword
        {
            get
            {
                return txtPassword;
            }
            set
            {
                txtPassword = value;
            }
        }

        public IWebElement LnkAlerts
        {
            get
            {
                return lnkAlerts;
            }
            set
            {
                lnkAlerts = value;
            }
        }

        public IWebElement LblUserNameMaintainUserTab
        {
            get
            {
                return lblUserNameMaintainUserTab;
            }
            set
            {
                lblUserNameMaintainUserTab = value;
            }
        }

        public IWebElement TxtLastNameMaintainUserTab
        {
            get
            {
                return txtLastNameMaintainUserTab;
            }
            set
            {
                txtLastNameMaintainUserTab = value;
            }
        }

        public IWebElement RadioButtonUseGroupViewAlerts
        {
            get
            {
                return radioButtonUseGroup;
            }
            set
            {
                radioButtonUseGroup = value;
            }
        }

        public IWebElement TxtEmailMaintainUserTab
        {
            get
            {
                return txtEmailMaintainUserTab;
            }
            set
            {
                txtEmailMaintainUserTab = value;
            }
        }

        public IWebElement RadioBtnAutoAlerts
        {
            get
            {
                return radioBtnAutoAlerts;
            }
            set
            {
                radioBtnAutoAlerts = value;
            }
        }

        public IWebElement LnkGroup
        {
            get
            {
                return lnkGroup;
            }
            set
            {
                lnkGroup = value;
            }
        }

        public IWebElement TxtFirstName
        {
            get { return txtFirstName; }
            set { txtFirstName = value; }
        }

        public IWebElement TxtUserName
        {
            get { return txtUserName; }
            set { txtUserName = value; }
        }

        public IWebElement TxtLastName
        {
            get { return txtLastName; }
            set { txtLastName = value; }
        }

        public IWebElement TxtCurrentPassword
        {
            get
            {
                return txtCurrentPassword;
            }
            set
            {
                txtCurrentPassword = value;
            }
        }

        public IWebElement BtnApplyOnChangePwdPopUp
        {
            get
            {
                return btnApplyOnChangePwdPopUp;
            }
            set
            {
                btnApplyOnChangePwdPopUp = value;
            }
        }

        public IWebElement TxtNewPassword
        {
            get
            {
                return txtNewPassword;
            }
            set
            {
                txtNewPassword = value;
            }
        }

        public IWebElement LblconfimationMessage
        {
            get
            {
                return lblconfimationMessage;
            }
            set
            {
                lblconfimationMessage = value;
            }
        }
        public IWebElement TxtConfirmNewPassword
        {
            get
            {
                return txtConfirmNewPassword;
            }
            set
            {
                txtConfirmNewPassword = value;
            }
        }

        public IWebElement LblconfirmationMessage
        {
            get
            {
                return lblconfirmationMessage;
            }
            set
            {
                lblconfirmationMessage = value;
            }
        }

        public IWebElement MsgUserNameRequiredField
        {
            get
            {
                return msgUserNameRequiredField;
            }
            set
            {
                msgUserNameRequiredField = value;
            }
        }

        public IWebElement MsgGroupNameRequiredField
        {
            get
            {
                return msgGroupNameRequiredField;
            }
            set
            {
                msgGroupNameRequiredField = value;
            }
        }

        public IWebElement MsgPasswordRequiredField
        {
            get
            {
                return msgPasswordRequiredField;
            }
            set
            {
                msgPasswordRequiredField = value;
            }
        }

        public IWebElement MsgCfmPasswordRequiredField
        {
            get
            {
                return msgCfmPasswordRequiredField;
            }
            set
            {
                msgCfmPasswordRequiredField = value;
            }
        }
        
        public IWebElement MsgLastNameRequiredField
        {
            get
            {
                return msgLastNameRequiredField;
            }
            set
            {
                msgLastNameRequiredField = value;
            }
        }

        public IWebElement MsgEmailRequiredField
        {
            get
            {
                return msgEmailRequiredField;
            }
            set
            {
                msgEmailRequiredField = value;
            }
        }

        public IWebElement MsgFirstNameRequiredField
        {
            get
            {
                return msgFirstNameRequiredField;
            }
            set
            {
                msgFirstNameRequiredField = value;
            }
        }

        public IWebElement LnkMaintainUser
        {
            get
            {
                return lnkMaintainUser;
            }
            set
            {
                lnkMaintainUser = value;
            }
        }

        public IWebElement LnkCurrentUser
        {
            get
            {
                return lnkCurrentUser;
            }
            set
            {
                lnkCurrentUser = value;
            }
        }

        public IWebElement TxtLastNameCurrentUserTab
        {
            get
            {
                return txtLastNameCurrentUserTab;
            }
            set
            {
                txtLastNameCurrentUserTab = value;
            }
        }

        public IWebElement LnkMaintainGroup
        {
            get
            {
                return lnkMaintainGroup;
            }
            set
            {
                lnkMaintainGroup = value;
            }
        }

        public IWebElement LblUserNameCurrentUserTab
        {
            get
            {
                return lblUserNameCurrentUserTab;
            }
            set
            {
                lblUserNameCurrentUserTab = value;
            }
        }

        public IWebElement TxtEmailIdCurrentUserTab
        {
            get
            {
                return txtEmailIdCurrentUserTab;
            }
            set
            {
                txtEmailIdCurrentUserTab = value;
            }
        }

        public IWebElement LnkChangePassword
        {
            get
            {
                return lnkChangePassword;
            }
            set
            {
                lnkChangePassword = value;
            }
        }

        public IWebElement LblChangePassword
        {
            get
            {
                return lblChangePassword;
            }
            set
            {
                lblChangePassword = value;
            }
        }

        public IWebElement LnkPermission
        {
            get
            {
                return lnkPermission;
            }
            set
            {
                lnkPermission = value;
            }
        }

        public IWebElement SelectAllCheckBox
        {
            get
            {
                return selectAllCheckBox;
            }
            set
            {
                selectAllCheckBox = value;
            }
        }

        public IWebElement BtnApplyChange
        {
            get
            {
                return btnApplyChange;
            }
            set
            {
                btnApplyChange = value;
            }
        }

        public IWebElement LblChangesApplied
        {
            get
            {
                return lblChangesApplied;
            }
            set
            {
                lblChangesApplied = value;
            }
        }

        public IWebElement LinkHomePage
        {
            get
            {
                return linkHomePage;
            }
            set
            {
                linkHomePage = value;
            }
        }

        public IWebElement LinkCreateUser
        {
            get
            {
                return lnkCreateUser;
            }
            set
            {
                lnkCreateUser = value;
            }
        }

        public IWebElement LinkCreateGroup
        {
            get
            {
                return lnkCreateGroup;
            }
            set
            {
                lnkCreateGroup = value;
            }
        }

        public IWebElement LblCreateUser
        {
            get
            {
                return lblCreateUser;
            }
            set
            {
                lblCreateUser = value;
            }
        }

        public IWebElement BtnCreateUser
        {
            get
            {
                return btnCreateUser;
            }
            set
            {
                btnCreateUser = value;
            }
        }

        public IWebElement TabUSerDetails
        {
            get
            {
                return tabUSerDetails;
            }
            set
            {
                tabUSerDetails = value;
            }
        }

        public IWebElement MsgPasswordDoNotMatch
        {
            get
            {
                return msgPasswordDoNotMatch;
            }
            set
            {
                msgPasswordDoNotMatch = value;
            }
        }

        public IWebElement LnkSetMemorableInformation
        {
            get
            {
                return lnkSetMemorableInformation;
            }
            set
            {
                lnkSetMemorableInformation = value;
            }
        }

        public IWebElement LnkUsers
        {
            get
            {
                return lnkUsers;
            }
            set
            {
                lnkUsers = value;
            }
        }

        public IWebElement BtnOk
        {
            get
            {
                return btnOk;
            }
            set
            {
                btnOk = value;
            }
        }

        public IWebElement TxtGroupName
        {
            get
            {
                return txtGroupName;
            }
            set
            {
                txtGroupName = value;
            }
        }

        public IWebElement TxtGroupDescription
        {
            get
            {
                return txtGroupDescription;
            }
            set
            {
                txtGroupDescription = value;
            }
        }

        public IWebElement TxtMemorableQuestion
        {
            get
            {
                return txtMemorableQuestion;
            }
            set
            {
                txtMemorableQuestion = value;
            }
        }

        public IWebElement TxtMemorableAnswer
        {
            get
            {
                return txtMemorableAnswer;
            }
            set
            {
                txtMemorableAnswer = value;
            }
        }

        public IWebElement TxtReEnterPassword
        {
            get
            {
                return txtReEnterPassword;
            }
            set
            {
                txtReEnterPassword = value;
            }
        }

        public IWebElement BtnDeleteGroup
        {
            get
            {
                return btnDeleteUser;
            }
            set
            {
                btnDeleteUser = value;
            }
        }

        public IWebElement LblDeleteConfirmationMsg
        {
            get
            {
                return lblDeleteConfirmationMsg;
            }
            set
            {
                lblDeleteConfirmationMsg = value;
            }
        }

        public IWebElement ChkBoxAdvisory
        {
            get
            {
                return chkBoxAdvisory;
            }
            set
            {
                chkBoxAdvisory = value;
            }
        }

        public IWebElement ChkBoxMajorAlarm
        {
            get
            {
                return chkBoxMajorAlarm;
            }
            set
            {
                chkBoxMajorAlarm = value;
            }
        }

        public IWebElement ChkBoxMinorAlarm
        {
            get
            {
                return chkBoxMinorAlarm;
            }
            set
            {
                chkBoxMinorAlarm = value;
            }
        }

        public IWebElement ChkBoxMinorWarning
        {
            get
            {
                return chkBoxMinorWarning;
            }
            set
            {
                chkBoxMinorWarning = value;
            }
        }

        public IWebElement ChkBoxMajorWarning
        {
            get
            {
                return chkBoxMajorWarning;
            }
            set
            {
                chkBoxMajorWarning = value;
            }
        }

        #endregion

        //Methods
        #region
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Password"></param>
        /// <param name="ConformPassword"></param>
        /// <param name="question"></param>
        /// <param name="ans"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="Email"></param>
        public void CreateNewUser(string userName, string Password, string ConformPassword, string question, string ans, string firstName, string lastName, string Email)
        {
            if (IsUserExist(firstName, lastName, userName))
            {
                DeleteIfExist(userName, firstName, lastName);
                Waits.Wait(driver, 2000);
            }
            Waits.Wait(driver, 2000);
            EnterUserName(userName);
            Waits.Wait(driver, 2000);
            EnterPassword(Password);
            Waits.Wait(driver, 2000);
            EnterConformPassword(ConformPassword);
            Waits.Wait(driver, 2000);
            txtMemorableQuestion.SendKeys(question);
            Waits.Wait(driver, 1000);
            txtMemorableAnswer.SendKeys(ans);
            Waits.Wait(driver, 1000);
            EnterFirstName(firstName);
            Waits.Wait(driver, 2000);
            EnterLastName(lastName);
            Waits.Wait(driver, 2000);
            EnterEmail(Email);
            Waits.Wait(driver, 1000);
            btnCreateUser.Click();
            Waits.Wait(driver, 1000);
        }
        
        /// <summary>
        /// Edit User details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        public void EditUSerDetails(string userName, string firstName, string lastName, string email)
        {
            SelectCreatedUser(userName, firstName, lastName);
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterEmail(email);

            ClickOnApplyChanges();

        }

        /// <summary>
        /// Deleted user if exists
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public void DeleteIfExist(string userName, string firstName, string lastName)
        {
            SelectCreatedUser(userName, firstName, lastName);
            ClickOnDeleteUser();
            ConformDeleteUser();
        }

        /// <summary>
        /// Selected Created User
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        public void SelectCreatedUser(string UserName, string FirstName, string LastName)
        {

            IWebElement baseUserlist = lstUsername;
            ICollection<IWebElement> list = baseUserlist.FindElements(By.TagName("li"));
            foreach (IWebElement listItem in list)
            {
                if (listItem.Text.ToLower().Equals(LastName.ToLower() + ", " + FirstName.ToLower() + " (" + UserName.ToLower() + ")"))
                {
                    listItem.Click();
                    Waits.Wait(driver, 1000);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// Deleted Group if exists
        /// </summary>
        /// <param name="grpName"></param>
        public void DeleteGroupIfExist(string grpName)
        {
            if (SelectCreatedGroup(grpName))
            {
                ClickOnDeleteUser();
                ConformDeleteUser();
            }
        }

        /// <summary>
        /// Select created group
        /// </summary>
        /// <param name="grpName"></param>
        public bool SelectCreatedGroup(string grpName)
        {
            bool flag = false;
            IWebElement baseUserlist = lstUsername;
            ICollection<IWebElement> list = baseUserlist.FindElements(By.TagName("li"));
            foreach (IWebElement listItem in list)
            {
                if (listItem.Text.ToLower().Contains(grpName.ToLower()))
                {
                    listItem.Click();
                    Waits.Wait(driver, 1000);
                    flag = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return flag;
        }

        /// <summary>
        /// Create new group
        /// </summary>
        /// <param name="grpName"></param>
        /// <param name="grpDescription"></param>
        public void CreateNewGroup(string grpName, string grpDescription)
        {
            if (IsGroupExist(grpName))
            {
                DeleteGroupIfExist(grpName);
            }
            txtGroupName.SendKeys(grpName);
            txtGroupName.SendKeys(Keys.Tab);
            txtGroupDescription.SendKeys(grpDescription);
            btnCreate.Click();
        }

        /// <summary>
        /// Adds User in Group
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="username"></param>
        public void AddUserInGroup(string firstName, string lastName, string username)
        {
            Waits.Wait(driver, 2000);
            lnkUsers.Click();
            Waits.Wait(driver, 2000);
            IWebElement user = driver.FindElement(By.XPath("//td[contains(@title,'" + lastName + ", " + firstName + " (" + username + ")')]"));
            user.Click();
            Waits.Wait(driver, 1000);
            btnMoveTo.Click();
            Waits.Wait(driver, 8000);
            btnApplyChange.Click();
            Waits.Wait(driver, 2000);
        }

        /// <summary>
        /// Checks Group added
        /// </summary>
        /// <param name="grpName"></param>
        /// <returns></returns>
        public bool isGroupAddded(string grpName)
        {
            Waits.Wait(driver, 2000);
            bool flag = false;
            string grpTitle = lstGrpAssigned.FindElement(By.XPath("table//tbody//tr//td[2]")).GetAttribute("title");
            if(grpName.ToLower().Equals(grpTitle.ToLower()))
            {
                flag =true;
            }

            return flag;
        }

        /// <summary>
        /// Provides all permission
        /// </summary>
        public void ApplicationPermission()
        {
            lnkPermission.Click();
            Waits.Wait(driver, 2000);
            selectAllCheckBox.Click();
            Waits.Wait(driver, 2000);
            btnApplyChange.Click();
        }

        /// <summary>
        /// Checks group already exists
        /// </summary>
        /// <param name="grpName"></param>
        /// <returns></returns>
        public bool IsGroupExist(string grpName)
        {
            IWebElement baseTable = lstUsername;
            bool flag = false;
            ICollection<IWebElement> list = baseTable.FindElements(By.TagName("li"));
            foreach (IWebElement listItem in list)
            {
                if (listItem.Text.ToLower().Contains(grpName.ToLower()))
                {
                    flag = true;
                    Waits.Wait(driver, 2000);
                    break;
                }
                else
                {
                    flag = false;
                }
            }
            return flag;
        }

        /// <summary>
        /// Checks  user already exists
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool IsUserExist(string firstName, string lastName, string userName)
        {
            IWebElement baseTable = lstUsername;
            List<string> UserList = new List<string>();
            bool flag = false;
            ICollection<IWebElement> list = baseTable.FindElements(By.TagName("li"));
            foreach (IWebElement listItem in list)
            {
                if (listItem.Text.ToLower().Contains(lastName.ToLower() + ", " + firstName.ToLower() + " (" + userName.ToLower() + ")"))
                {
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                }
            }
            return flag;
        }

        /// <summary>
        /// Enter text in User Name textbox
        /// </summary>
        /// <param name="UserName"></param>
        public void EnterUserName(string UserName)
        {
            txtUserName.Clear();
            txtUserName.SendKeys(UserName);
            txtUserName.SendKeys(Keys.Tab);
        }

        /// <summary>
        /// Enter text in Password textbox
        /// </summary>
        /// <param name="Password"></param>
        public void EnterPassword(string Password)
        {
            txtPassword.Clear();
            txtPassword.SendKeys(Password);
            txtUserName.SendKeys(Keys.Tab);
        }

        /// <summary>
        /// Enter text in Confirm Password textbox
        /// </summary>
        /// <param name="ReEnterPAssword"></param>
        public void EnterConformPassword(string ReEnterPAssword)
        {
            txtConformPassword.SendKeys(ReEnterPAssword);
            txtUserName.SendKeys(Keys.Tab);
        }

        /// <summary>
        /// Enter text in First Name textbox
        /// </summary>
        /// <param name="FirstName"></param>
        public void EnterFirstName(string FirstName)
        {
            txtFirstName.Clear();
            txtFirstName.SendKeys(FirstName);
        }

        /// <summary>
        /// Enter text in Last Name textbox
        /// </summary>
        /// <param name="LastName"></param>
        public void EnterLastName(string LastName)
        {
            txtLastName.Clear();
            txtLastName.SendKeys(LastName);;
        }

        /// <summary>
        /// Enter text in email textbox
        /// </summary>
        /// <param name="Email"></param>
        public void EnterEmail(string Email)
        {
            txtEmail.Clear();
            txtEmail.SendKeys(Email);
        }

        /// <summary>
        /// Returns Conformation Message text
        /// </summary>
        /// <returns></returns>
        public string ConformationMessage()
        {
            return lblConformationMessage.Text;
        }

        /// <summary>
        /// Click On Delete User
        /// </summary>
        public void ClickOnDeleteUser()
        {
            Waits.Wait(driver, 2000);
            btnDeleteUser.Click();
        }

        /// <summary>
        /// Click Confirm Delete User
        /// </summary>
        public void ConformDeleteUser()
        {
            btnConformDelete.Click();
        }

        /// <summary>
        /// Click On Apply Changes button
        /// </summary>
        public void ClickOnApplyChanges()
        {
            btnApplyChange.Click();
        }

        /// <summary>
        /// Select Permission CheckBoxes
        /// </summary>
        /// <param name="tablePermission"></param>
        /// <param name="feature"></param>
        /// <param name="checkbox"></param>
        public void SelectPermissionCheckBoxes(string tablePermission, string feature, string checkbox)
        {
            bool flag = false;
            List<IWebElement> lstEle = new List<IWebElement>();

            if (tablePermission.ToLower() == "user permission")
                 lstEle = new List<IWebElement>(tblUserPermission.FindElements(By.TagName("tr")));
            else if(tablePermission.ToLower() == "group permission")
                lstEle = new List<IWebElement>(tblGrpPermission.FindElements(By.TagName("tr")));

            if (lstEle.Count > 0)
                {
                    foreach (var ele in lstEle)
                    {
                        if(flag)
                        {
                            break;
                        }
                        if (ele.Text.Contains(feature) && ele.Text.Contains(checkbox))
                        {
                            List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.TagName("td")));
                            if (lstCol.Count > 0)
                            {
                                foreach (var col in lstCol)
                                {
                                    if (col.Text.Contains(checkbox))
                                    {
                                        col.Click();
                                        flag = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

            }

        /// <summary>
        /// Check given checkboxe inside Permission table is selected
        /// </summary>
        /// <param name="tablePermission"></param>
        /// <param name="feature"></param>
        /// <param name="checkbox"></param>
        /// <returns></returns>
        public bool IsPermissionCheckBoxesSelected(string tablePermission, string feature, string checkbox)
        {
            bool flag = false;
            List<IWebElement> lstEle = new List<IWebElement>();

            if (tablePermission.ToLower() == "user permission")
                lstEle = new List<IWebElement>(tblUserPermission.FindElements(By.TagName("tr")));
            else if (tablePermission.ToLower() == "group permission")
                lstEle = new List<IWebElement>(tblGrpPermission.FindElements(By.TagName("tr")));

            if (lstEle.Count > 0)
            {
                foreach (var ele in lstEle)
                {
                 
                    if (ele.Text.Contains(feature) && ele.Text.Contains(checkbox))
                    {
                        List<IWebElement> lstCol = new List<IWebElement>(ele.FindElements(By.TagName("td")));
                        if (lstCol.Count > 0)
                        {
                            foreach (var col in lstCol)
                            {
                                if (col.Text.Contains(checkbox))
                                {
                                    flag =col.Selected;
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return flag;
        }


        #endregion
    }


}

