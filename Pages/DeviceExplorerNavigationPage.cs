using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace Edwards.Scada.Test.Framework.Pages
{


    //namespaces
    using Edwards.Scada.Test.Framework.GlobalHelper;
    using OpenQA.Selenium.Support.UI;

    public class DeviceExplorerNavigationPage : PageBase
    {
        IWebDriver driver;
        public DeviceExplorerNavigationPage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;

        }

        //objects for DeviceExplorerpage
        #region 
        [FindsBy(How = How.XPath, Using = "//div[@class='fabbox additem']")]
        private IWebElement lnkAddFolder { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='txtAddFolderName']")]
        private IWebElement txtFolderName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id ='txtRename']")]
        private IWebElement txtRenameFolderName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'btnOKAdd')]//input[@class='imgBtnStd']")]
        private IWebElement btnAdd { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'btnCloseAdd')]//input[@class='imgBtnStd'][contains(@id,'btnCloseAdd')]")]
        private IWebElement btnCancel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modalBody']//span[contains(@id,'lblPopupMessage')]")]
        private IWebElement lblMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='OK']")]
        private IWebElement btnOk;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$btnOKDelete')]")]
        private IWebElement btnOkDelete;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_btnOKDelete")]
        private IWebElement btnOkOnDecommissionPopUP;

        [FindsBy(How = How.XPath, Using = "//span[@id='spnDeleteGroupMenuItem']//a[text()='Delete']")]
        private IWebElement popUpDeleteFolderOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='spnRenameGroupMenuItem']//a[text()='Rename']")]
        private IWebElement popUpRenameFolderOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//div[@class='imgBtnWrapperStd']//input[contains(@id,'btnOKDelete')]")]
        private IWebElement btnConformDelete { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//div[@class='imgBtnWrapperStd']//input[contains(@id,'btnCloseDelete')]")]
        private IWebElement btnCloseDelete { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divBox']")]
        private IWebElement lblCreatedFolderHeader1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divBox']//span//div[text()='TestFolder']")]
        private IWebElement lblCreatedFolderHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divBox']//span//div[text()='IXH_Device_Folder']")]
        private IWebElement lblCreatedFolderHeaderForGraph { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='divBoxHead'][text()='IXH_Device_Folder']//..//..//div[@class='fabbox_main']")]
        private IWebElement lblCreatedFolderMain { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='divBoxHead'][text()='TestFolder']//..//..//div[@class='fabbox_main']")]
        private IWebElement lblCreatedFolderMain1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divAddBox']")]
        private IWebElement lnkAddDevice { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='imgBtnWrapperBigger']//input[contains(@id,'btnGetSystem')]")]
        private IWebElement btnGetEquipment { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='ctl00_ctl00_cphContent_cphContent_ddlSystemTypeFilter']")]
        private IWebElement dropdownlistEquipmentType { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divFoundsystems']//div/table")]
        private IWebElement lstEquipmentListtable { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divBox']//span[@class='popupMenuSpan']//div")]
        private IWebElement equipmentList { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='modalButtons']//div[@class='imgBtnWrapperStd']//input[contains(@id,'btnOKAdd')]")]
        private IWebElement btnAddEquipment { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divBox'][1]//div[@id='divBoxHead']")]
        private IWebElement lblEquipment;

        [FindsBy(How = How.XPath, Using = "//div[@class='modalBody']//span[@id='spnDeleteMessage']")]
        private IWebElement deleteEquipmentMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='popupMenuSystem']//span[@id='spnRemoveSystemMenuItem']//a[1]")]
        private IWebElement popUpRemoveFromFolder { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Top Level']")]
        private IWebElement LnkTopLevelNavigation { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='logo']//a//img")]
        private IWebElement lnkHomePage { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lblPopupMessage")]
        private IWebElement lblSuccessMessageAfterCreatingFolder;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'hypRenameGroup')]")]
        private IWebElement linkRenameFolder { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'ctl00_ctl00_cphContent_cphContent_hypDeleteGroup')]")]
        private IWebElement linkDeleteFolder { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id ='btnOKRename']")]
        private IWebElement btnApply;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Top Level')]")]
        private IWebElement linktTopLevel;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ctl00_ctl00_cphContent_cphContent_btnCloseDelete')]")]
        private IWebElement btnCancelOnDeleteWindow;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'spnDeleteHeader')]")]
        private IWebElement windowDelete;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Ok')]")]
        private IWebElement btnOK;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'lblLinkText')][contains(.,'Home')]")]
        private IWebElement linkHomePage;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Share Folder')]")]
        private IWebElement linkShareFolder;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'ctl00_ctl00_cphContent_cphContent_lblSharing')]")]
        private IWebElement popUpShareFolder;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnMoveTo')]")]
        private IWebElement btnMoveTo;

        [FindsBy(How = How.XPath, Using = ".//input[contains(@id,'btnApply')]")]
        private IWebElement btnApplyChange;

        [FindsBy(How =How.XPath, Using = ".//input[contains(@value,'Apply')]")]
        private IWebElement btnApplyShare;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_clstSystems_td0")]
        private IWebElement drpdownItemSelectEquipment;

        [FindsBy(How = How.XPath, Using = "//div[@title='Alarms']")]
        private IWebElement iconAlarm;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'fabbox_main system')]")]
        private IWebElement txtAreaEquipment;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Overview')]")]
        private IWebElement tabOverview;

        [FindsBy(How = How.XPath, Using = "//span[@id='spnStatus']")]
        private IWebElement lblstatus;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ddlSerial')]")]
        private IWebElement drpDownserialNumber;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Parameters')]")]
        private IWebElement lnkParameters;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'lnkGauges')]")]
        private IWebElement lnkGuages;

        [FindsBy(How = How.XPath, Using = "//select[@name='ctl00$ctl00$cphContent$cphContent$SEV1$ddlSerial']")]
        private IWebElement drpdwnSerialNumber;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'ctl00$ctl00$cphContent$cphContent$SEV1$txtSerial')]")]
        private IWebElement txtBoxSerialNumber;

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Temperature')]")]
        private IWebElement lblTemperature;

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Pressure')]")]
        private IWebElement lblPressure;

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Flow')]")]
        private IWebElement lblFlow;

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Power')]")]
        private IWebElement lblPower;

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Current')]")]
        private IWebElement lblCurrent;

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Rotational Speed')]")]
        private IWebElement lblRotationalSpeed;

        [FindsBy(How = How.XPath, Using = "(//span[contains(@class,'sev_status_value')])[1]")]
        private IWebElement txtBoxMBTempParameters;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'MB Temp')]")]
        private IWebElement lblBoxMBTempGuages;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Graph')]")]
        private IWebElement lnkGraph;

        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement btnAddGraph;

        [FindsBy(How = How.XPath, Using = "//tspan[contains(.,':MB Temp (ºC) (54)')]")]
        private IWebElement lblMBTempGraph;

        [FindsBy(How = How.XPath, Using = "//input[@value='Reset Graph']")]
        private IWebElement btnResetGraph;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ctl00_ctl00_cphContent_cphContent_SEV1_ddlParameters')]")]
        private IWebElement drpDwnSelectParameters;

        [FindsBy(How = How.XPath, Using = "//a[contains(@action,'decommission')]")]
        private IWebElement lnkDecommission;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Commission')]")]
        private IWebElement lnkCommission;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Add Equipment')]")]
        private IWebElement lnkAddEquipment;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Create/Commission')]")]
        private IWebElement lnkCreateCommission;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'ctl00_ctl00_cphContent_cphContent_ddlSystemType_Commission')]")]
        private IWebElement drpDownSelectEquipmentType;

        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$ctl00$cphContent$cphContent$txtSystemName_Commission'][contains(@id,'Commission')]")]
        private IWebElement txtBoxEquipmentName;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_ctl00_cphContent_cphContent_txtIPAddress_Commission']")]
        private IWebElement txtBoxIPAddress;

        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$ctl00$cphContent$cphContent$txtIPPort_Commission'][contains(@id,'Commission')]")]
        private IWebElement txtBoxIPPortNumber;

        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement btnAddOnCommissionPopUp;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Uncomissioned')]")]
        private IWebElement lblUncommissioned;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Manage Equipment')]")]
        private IWebElement lnkManageEquipment;

        [FindsBy(How = How.XPath, Using = "//input[@value='Find Equipment']")]
        private IWebElement btnFindEquipment;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'No Equipment Found')]")]
        private IWebElement msgNoEquipmentFound;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Navigate')]")]
        private IWebElement lnkNavigate;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id, 'ctl00_ctl00_cphContent_cphContent_clstSystems_divListControl')]/table/tbody")]
        private IWebElement tblEquipment;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'btnDelete')]")]
        private IWebElement btnDelete;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkMaintenanceOn")]
        private IWebElement lnkSetMaintenanceOn;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_lnkMaintenanceOff")]
        private IWebElement lnkSetMaintenanceOff;

        [FindsBy(How = How.Id, Using = "//a[@action='deletesystem']")]
        private IWebElement lnkDelete;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_cphContent_cphContent_clItemsShared_divListControl']")]
        private IWebElement listBoxGrantedList;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_cphContent_cphContent_clItemsShared_divListControl")]
        private IWebElement lstGranted;
        #endregion

        public IWebElement LblEquipment
        {
            get
            {
                return lblEquipment;
            }
            set
            {
                lblEquipment = value;
            }
        }

        public IWebElement BtnDelete
        {
            get
            {
                return btnDelete;
            }
            set
            {
                btnDelete = value;
            }
        }

        public IWebElement MsgNoEquipmentFound
        {
            get
            {
                return msgNoEquipmentFound;
            }
            set
            {
                msgNoEquipmentFound = value;
            }
        }

        public IWebElement TblEquipment
        {
            get
            {
                return tblEquipment;
            }
            set
            {
                tblEquipment = value;
            }
        }

        public IWebElement LnkNavigate
        {
            get
            {
                return lnkNavigate;
            }
            set
            {
                lnkNavigate = value;
            }
        }

        public IWebElement BtnApply
        {
            get
            {
                return btnApply;
            }
            set
            {
                btnApply = value;
            }
        }

        public IWebElement BtnAddOnCommissionPopUp
        {
            get
            {
                return btnAddOnCommissionPopUp;
            }
            set
            {
                btnAddOnCommissionPopUp = value;
            }
        }

        public IWebElement LstGranted
        {
            get
            {
                return lstGranted;
            }
            set
            {
                lstGranted = value;
            }
        }

        public IWebElement ListBoxGrantedList
        {
            get
            {
                return listBoxGrantedList;
            }
            set
            {
                listBoxGrantedList = value;
            }
        }

        public IWebElement LinktTopLevel
        {
            get
            {
                return linktTopLevel;
            }
            set
            {
                linktTopLevel = value;
            }
        }
        public IWebElement LblSuccessMessageAfterCreatingFolder
        {
            get
            {
                return lblSuccessMessageAfterCreatingFolder;
            }
            set
            {
                lblSuccessMessageAfterCreatingFolder = value;
            }
        }

        public IWebElement LnkAddFolder
        {
            get
            {
                return lnkAddFolder;
            }
            set
            {
                lnkAddFolder = value;
            }
        }

        public IWebElement BtnCancelOnDeleteWindow
        {
            get
            {
                return btnCancelOnDeleteWindow;
            }
            set
            {
                btnCancelOnDeleteWindow = value;
            }
        }

        public IWebElement WindowDelete
        {
            get
            {
                return windowDelete;
            }
            set
            {
                windowDelete = value;
            }
        }

        public IWebElement BtnOK
        {
            get
            {
                return btnOK;
            }
            set
            {
                btnOK = value;
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

        public IWebElement LinkShareFolder
        {
            get
            {
                return linkShareFolder;
            }
            set
            {
                linkShareFolder = value;
            }
        }

        public IWebElement PopUpShareFolder
        {
            get
            {
                return popUpShareFolder;
            }
            set
            {
                popUpShareFolder = value;
            }
        }

        public IWebElement TxtAreaEquipment
        {
            get
            {
                return txtAreaEquipment;
            }
            set
            {
                txtAreaEquipment = value;
            }
        }

        public IWebElement TabOverview
        {
            get
            {
                return tabOverview;
            }
            set
            {
                tabOverview = value;
            }
        }

        public IWebElement LblStatus
        {
            get
            {
                return lblstatus;
            }
        }

        public IWebElement IconAlarm
        {
            get
            {
                return iconAlarm;
            }
            set
            {
                iconAlarm = value;
            }
        }

        public IWebElement DrpDownserialNumber
        {
            get
            {
                return drpDownserialNumber;
            }
            set
            {
                drpDownserialNumber = value;
            }
        }

        public IWebElement LinkParameters
        {
            get
            {
                return lnkParameters;
            }
            set
            {
                lnkParameters = value;
            }
        }

        public IWebElement LinkGuages
        {
            get
            {
                return lnkGuages;
            }
            set
            {
                lnkGuages = value;
            }
        }

        public IWebElement DrpdwnSerialNumber
        {
            get
            {
                return drpdwnSerialNumber;
            }
            set
            {
                drpdwnSerialNumber = value;
            }
        }

        public IWebElement TxtBoxSerialNumber
        {
            get
            {
                return txtBoxSerialNumber;
            }
            set
            {
                txtBoxSerialNumber = value;
            }
        }

        public IWebElement LblTemperature
        {
            get
            {
                return lblTemperature;
            }
            set
            {
                lblTemperature = value;
            }
        }

        public IWebElement LblPressure
        {
            get
            {
                return lblPressure;
            }
            set
            {
                lblPressure = value;
            }
        }

        public IWebElement LblFlow
        {
            get
            {
                return lblFlow;
            }
            set
            {
                lblFlow = value;
            }
        }

        public IWebElement LblPower
        {
            get
            {
                return lblPower;
            }
        }

        public IWebElement LblCurrent
        {
            get
            {
                return lblCurrent;
            }
            set
            {
                lblCurrent = value;
            }
        }

        public IWebElement LblRotationalSpeed
        {
            get
            {
                return lblRotationalSpeed;
            }
            set
            {
                lblRotationalSpeed = value;
            }
        }

        public IWebElement TxtBoxMBTempParameters
        {
            get
            {
                return txtBoxMBTempParameters;
            }
            set
            {
                txtBoxMBTempParameters = value;
            }
        }

        public IWebElement LblBoxMBTempGuages
        {
            get
            {
                return lblBoxMBTempGuages;
            }
            set
            {
                lblBoxMBTempGuages = value;
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

        public IWebElement LnkGraph
        {
            get
            {
                return lnkGraph;
            }
            set
            {
                lnkGraph = value;
            }
        }

        public IWebElement BtnAddGraph
        {
            get
            {
                return btnAddGraph;
            }
            set
            {
                btnAddGraph = value;
            }
        }

        public IWebElement LblMBTempGraph
        {
            get
            {
                return lblMBTempGraph;
            }
            set
            {
                lblMBTempGraph = value;
            }
        }

        public IWebElement BtnResetGraph
        {
            get
            {
                return btnResetGraph;
            }
            set
            {
                btnResetGraph = value;
            }
        }

        public IWebElement DrpDwnSelectParameters
        {
            get
            {
                return drpDwnSelectParameters;
            }
            set
            {
                drpDwnSelectParameters = value;
            }
        }

        public IWebElement LnkDecommission
        {
            get
            {
                return lnkDecommission;
            }
            set
            {
                lnkDecommission = value;
            }
        }

        public IWebElement BtnOkOnDecommissionPopUP
        {
            get
            {
                return btnOkOnDecommissionPopUP;
            }
            set
            {
                btnOkOnDecommissionPopUP = value;
            }
        }

        public IWebElement LblUncommissioned
        {
            get
            {
                return lblUncommissioned;
            }
            set
            {
                lblUncommissioned = value;
            }
        }

        public IWebElement LnkCommission
        {
            get
            {
                return lnkCommission;
            }
            set
            {
                lnkCommission = value;
            }
        }

        public IWebElement LnkAddDevice
        {
            get
            {
                return lnkAddDevice;
            }
            set
            {
                lnkAddDevice = value;
            }
        }

        public IWebElement LnkCreateCommission
        {
            get
            {
                return lnkCreateCommission;
            }
            set
            {
                lnkCreateCommission = value;
            }
        }

        public IWebElement LnkSetMaintenanceOn
        {
            get
            {
                return lnkSetMaintenanceOn;
            }
            set
            {
                lnkSetMaintenanceOn = value;
            }
        }

        public IWebElement LnkSetMaintenanceOff
        {
            get
            {
                return lnkSetMaintenanceOff;
            }
            set
            {
                lnkSetMaintenanceOff = value;
            }
        }

        public IWebElement LnkDelete
        {
            get
            {
                return lnkDelete;
            }
            set
            {
                lnkDelete = value;
            }
        }

        public string CreateFolder(string FolderName)
        {

            if (IsFolderExist(FolderName))
            {
                DeleteCreatedFolder(FolderName);
            }
            ClickOnPlusToAddFolder();
            EnterFolderName(FolderName);
            ClickOnAddToCreateFolder();
            ClickOkAfterConformationMessage();
            Thread.Sleep(2000);
            return FolderName;
        }
        public string CreateFolderForGraph(string FolderName)
        {

            if (IsFolderExistForEquipmentData(FolderName))
            {
                DeleteCreatedFolderForGraph(FolderName);
            }
            ClickOnPlusToAddFolder();
            EnterFolderName(FolderName);
            ClickOnAddToCreateFolder();
            ClickOkAfterConformationMessage();
            Thread.Sleep(2000);
            return FolderName;
        }


        public void DeleteCreatedFolder(string FolderName)
        {

            if (IsFolderExist(FolderName))
            {

                NavigateToTopLevel();
                Thread.Sleep(3000);
                ClickOnCreatedFolderNameHeader(FolderName);
                Thread.Sleep(2000);
                ClickOnDeleteFolderOption();
                Thread.Sleep(2000);
                ClickOnConformDelete();
                Thread.Sleep(2000);
                ClickOkAfterConformationMessage();
            }
        }
        public void DeleteCreatedFolderForGraph(string FolderName)
        {

            if (IsFolderExistForEquipmentData(FolderName))
            {

                NavigateToTopLevel();
                Thread.Sleep(3000);
                ClickOnCreatedFolderNameHeaderForGraph(FolderName);
                Thread.Sleep(2000);
                ClickOnDeleteFolderOption();
                Thread.Sleep(2000);
                ClickOnConformDelete();
                Thread.Sleep(2000);
                ClickOkAfterConformationMessage();
                Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// Selects user to share folder
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="userName"></param>
        public void selectUserToshareFolder(string firstName, string lastName, string userName)
        {
            IWebElement user = driver.FindElement(By.XPath("//td[contains(@title,'" + lastName + ", " + firstName + " (" + userName + ")')]"));
            user.Click();
            btnMoveTo.Click();
            for (int i = 0; i <= 20; i++)
            {
                bool flag = isUserAddedInGrantedList(firstName, lastName, userName);
                if (flag == false)
                {
                    Waits.Wait(driver, 1000);
                }
                else if(flag ==true)
                {
                    break;
                }
            }
            btnApplyShare.Click();
        }

        /// <summary>
        /// Checks if user added in Granted list
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool isUserAddedInGrantedList(string firstName, string lastName, string userName)
        {
            bool flag = false;
            try
            {
                string user = lastName + ", " + firstName + " (" + userName + ")";
                string title = lstGranted.FindElement(By.XPath("table//tbody//tr//td[2]")).GetAttribute("title");
                if (user.ToLower().Equals(title.ToLower()))
                {
                    flag = true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception caught" + ex.Message);
            }
            return flag;
        }

        /// <summary>
        /// Selects Group to share folder
        /// </summary>
        /// <param name="grpName"></param>
        public void selectGroupToshareFolder(string grpName)
        {
            JavaScriptExecutor.JavaScriptClick(driver, driver.FindElement(By.XPath("//td[contains(@title,'" + grpName + "')]")));
            btnMoveTo.Click();
            for (int i = 0; i <= 20; i++)
            {
                bool flag = isUserAddedInGrantedList(grpName);
                if (flag == false)
                {
                    Waits.Wait(driver, 1000);
                }
                else if (flag == true)
                {
                    break;
                }
            }
            btnApplyShare.Click();
        }


        /// <summary>
        /// Checks if group added in Granted list
        /// </summary>
        /// <param name="grpName"></param>
        /// <returns></returns>
        public bool isUserAddedInGrantedList(string grpName)
        {
            bool flag = false;
            try
            {
                string title = lstGranted.FindElement(By.XPath("table//tbody//tr//td[2]")).GetAttribute("title");
                if (grpName.ToLower().Equals(title.ToLower()))
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught" + ex.Message);
            }
            return flag;
        }

        /// <summary>
        /// Add equipment to system
        /// </summary>
        public void AddEquipmentToSystem()
        {
            ClickOnAddDevice();
            SelectSystemEquipmentType();
            ClickOnGetEquipment();
            SelectEquipment();
            btnAddEquipment.Click();
        }

        /// <summary>
        /// Selects system to equipment type
        /// </summary>
        public void SelectSystemEquipmentType()
        {
            Waits.Wait(driver, 3000);
            SelectElement element = new SelectElement(dropdownlistEquipmentType);
            element.SelectByText("All");
        }

        /// <summary>
        /// Remove equipment from system
        /// </summary>
        public void RemoveEquipmentFromSystemWithConformDelete()
        {
            Thread.Sleep(1000);
            ClickOnEquipmentHeader();
            ClickOnPopupRemoveFromFolder();
            ClickOnConformDelete();
        }

        /// <summary>
        /// Remove equipment from system 
        /// </summary>
        /// <returns></returns>
        public string RemoveEquipmentFromSystemWithCancelDelete()
        {
            ClickOnEquipmentHeader();
            ClickOnPopupRemoveFromFolder();
            return GetDeleteEquipmentMessage();
        }

        /// <summary>
        /// Select Folder Main
        /// </summary>
        /// <param name="FolderName"></param>
        public void SelectFolderMain(String FolderName)
        {
            try
            {
                if (FolderName == "IXH_Device_Folder")
                {

                    lblCreatedFolderMain.Click();
                }
                else if (FolderName == "TestFolder")
                {
                    lblCreatedFolderMain1.Click();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Is Folder exist
        /// </summary>
        /// <param name="FolderName"></param>
        /// <returns></returns>
        public bool IsFolderExist(String FolderName)
        {
            if (IsElemetPresent(driver, By.XPath("//div[@id='divBox']//span//div[text()='TestFolder']")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Is Folder Exisr For Equipment Data
        /// </summary>
        /// <param name="FolderName"></param>
        /// <returns></returns>
        public bool IsFolderExistForEquipmentData(String FolderName)
        {
            if (IsElemetPresent(driver, By.XPath("//div[@id='divBox']//span//div[text()='IXH_Device_Folder']")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Click on created Folder Header Name Header
        /// </summary>
        /// <param name="FolderName"></param>
        public void ClickOnCreatedFolderNameHeader(String FolderName)
        {
            lblCreatedFolderHeader.Click();
        }
        
        /// <summary>
        /// Click on created Folder Name Header for graph
        /// </summary>
        /// <param name="FolderName"></param>
        public void ClickOnCreatedFolderNameHeaderForGraph(String FolderName)
        {
            lblCreatedFolderHeaderForGraph.Click();
        }

        /// <summary>
        /// Select Equipment
        /// </summary>
        /// <param name="equipmentTitle"></param>
        public void SelectEquipment(string equipmentTitle= "NEW0001PM1")
        {
            Waits.Wait(driver, 4000);
            driver.FindElement(By.XPath("//td[contains(@title,'"+ equipmentTitle +"')]")).Click();
            //ElementExtensions.MouseHover(driver, ele);
            //ele.Click();

            //drpdownItemSelectEquipment.Click();
        }

        /// <summary>
        /// Read all added equipments
        /// </summary>
        /// <returns></returns>
        public string ReadAllAddedEquipment()
        {
            var elemTable = equipmentList;
            var rows = elemTable.FindElements(By.XPath("//img"));
            List<String> NewList = new List<String>();
            foreach (var item in rows)
            {
                NewList.Add(item.Text);
            }
            return NewList.ToString();
        }

        /// <summary>
        /// Click on Plus to add folder
        /// </summary>
        public void ClickOnPlusToAddFolder()
        {
            lnkAddFolder.Click();
        }

        /// <summary>
        /// Enter folder name
        /// </summary>
        /// <param name="FolderName"></param>
        public void EnterFolderName(string FolderName)
        {
            Waits.Wait(driver, 3000);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, txtFolderName);
            Waits.WaitTillElementIsClickable(driver, txtFolderName);
            txtFolderName.SendKeys(FolderName);
        }

        /// <summary>
        /// Click on Add to create folder
        /// </summary>
        public void ClickOnAddToCreateFolder()
        {
            btnAdd.Click();
        }

        /// <summary>
        /// Get confirmation message
        /// </summary>
        /// <returns></returns>
        public string GetConformationMessage()
        {

            return lblMessage.Text;
        }

        /// <summary>
        /// Click on after confirmation message
        /// </summary>
        public void ClickOkAfterConformationMessage()
        {
            Waits.Wait(driver, 2000);
            btnOk.Click();
        }

        /// <summary>
        /// Click on Delete folder option
        /// </summary>
        public void ClickOnDeleteFolderOption()
        {
            popUpDeleteFolderOption.Click();
        }

        /// <summary>
        /// Click on  confirm Delete
        /// </summary>
        public void ClickOnConformDelete()
        {
            Waits.Wait(driver, 3000);
            btnConformDelete.Click();
        }

        /// <summary>
        /// Click on Add device
        /// </summary>
        public void ClickOnAddDevice()
        {
            lnkAddDevice.Click();

        }

        /// <summary>
        /// Click on Get Equipment
        /// </summary>
        public void ClickOnGetEquipment()
        {
            btnGetEquipment.Click();
        }

        /// <summary>
        /// Click on Equipment Header
        /// </summary>
        public void ClickOnEquipmentHeader()
        {
            lblEquipment.Click();
        }

        /// <summary>
        /// Get Equipment title
        /// </summary>
        /// <returns></returns>
        public string GetEquipmentTitle()
        {
            return lblEquipment.Text;
        }

        /// <summary>
        /// Get Delete Equipment message
        /// </summary>
        /// <returns></returns>
        public string GetDeleteEquipmentMessage()
        {
            return deleteEquipmentMessage.Text;
        }

        /// <summary>
        /// Click on pop up Remove from folder
        /// </summary>
        public void ClickOnPopupRemoveFromFolder()
        {
            popUpRemoveFromFolder.Click();
        }

        /// <summary>
        /// Click on cancel confirmation
        /// </summary>
        public void ClickOnCancelConformation()
        {

            btnCloseDelete.Click();
        }

        /// <summary>
        /// Navigate to Top Level
        /// </summary>
        public void NavigateToTopLevel()

        {
            LnkTopLevelNavigation.Click();
        }

        /// <summary>
        /// Navigate to home page
        /// </summary>
        public void NavigateToHomePage()
        {
            ElementExtensions.ClickOnLink(lnkHomePage);
        }

        /// <summary>
        /// Click on Folder header
        /// </summary>
        /// <param name="folderName"></param>
        public void ClickOnFolderHeader(string folderName)
        {

            folderName = folderName.Trim('"');
            driver.Navigate().Refresh();
            IWebElement element = driver.FindElement(By.XPath("//div[@id='divBoxHead'][contains(.,'" + folderName + "')]"));
            JavaScriptExecutor.JavaScriptScrollToElement(driver, element);
            element.Click();
        }

        /// <summary>
        /// Click Rename
        /// </summary>
        /// <param name="newFolderName"></param>
        public void ClickRename(string newFolderName)
        {
            linkRenameFolder.Click();
            txtRenameFolderName.SendKeys(newFolderName);
        }

        /// <summary>
        /// Click Find Equipment
        /// </summary>
        /// <param name="folderName"></param>
        public void ClickFindEquipment(string folderName)
        {
            driver.Navigate().Refresh();
            folderName = folderName.Trim('"');
            IWebElement element = driver.FindElement(By.XPath("//div[@id='divBoxHead'][contains(.,'" + folderName + "')]"));
            string id = driver.FindElement(By.XPath("//span[@title = '" + folderName + "']")).GetAttribute("id");
            id = id.Remove(id.Length - 8);
            JavaScriptExecutor.JavaScriptScrollToElement(driver, element);
            string equipmentId = id + "hypNavigate";
            Thread.Sleep(8000);
            driver.FindElement(By.Id(equipmentId)).Click();
        }

        /// <summary>
        /// Clicks delete button
        /// </summary>
        public void ClickDelete()
        {
            JavaScriptExecutor.JavaScriptClick(driver, linkDeleteFolder);
        }

        /// <summary>
        /// Is folder hidden
        /// </summary>
        /// <param name="newFolderName"></param>
        /// <returns></returns>
        public bool IsFolderHidden(string newFolderName)
        {
            bool flag;
            String type = driver.FindElement(By.XPath("//input[@value='" + newFolderName + "']")).GetAttribute("type");
            flag = type.Contains("hidden");
            return flag;
        }

        /// <summary>
        /// Is folder present
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public bool IsFolderPresent(string folderName)
        {
            bool flag;
            folderName = folderName.Trim('"');
            driver.Navigate().Refresh();
            IWebElement element = driver.FindElement(By.XPath("//div[@id='divBoxHead'][contains(.,'" + folderName + "')]"));
            JavaScriptExecutor.JavaScriptScrollToElement(driver, element);
            flag = element.Displayed;
            return flag;
        }

        /// <summary>
        /// Clecked Decommission
        /// </summary>
        /// <param name="equipmentName"></param>
        /// <param name="equipmentType"></param>
        /// <param name="iPAdress"></param>
        /// <param name="iPPortNumber"></param>
        public void ClickDecommision(string equipmentName, string equipmentType, string iPAdress, string iPPortNumber)
        {
            try
            {
                lnkDecommission.Click();
            }
            catch (System.Reflection.TargetInvocationException)
            {
                lnkCommission.Click();
                lnkAddEquipment.Click();
                lnkCreateCommission.Click();
                Thread.Sleep(1000);
                txtBoxEquipmentName.SendKeys(equipmentName);
                ElementExtensions.SelectByText(drpDownSelectEquipmentType, equipmentType);
                txtBoxIPAddress.SendKeys(iPAdress);
                txtBoxIPPortNumber.Clear();
                txtBoxIPPortNumber.SendKeys(iPPortNumber);
                btnAddOnCommissionPopUp.Click();
                GetConformationMessage().Contains("Equipment Added Successfully");
                btnOk.Click();
                lblEquipment.Click();
                lnkDecommission.Click();
            }
        }

        /// <summary>
        /// Enter commission details
        /// </summary>
        /// <param name="equipmentName"></param>
        /// <param name="equipmentType"></param>
        /// <param name="iPAdress"></param>
        /// <param name="iPPortNumber"></param>
        public void EnterCommissionedDetails(string equipmentName, string equipmentType, string iPAdress, string iPPortNumber)
        {
            Thread.Sleep(1000);
            txtBoxEquipmentName.SendKeys(equipmentName);
            ElementExtensions.SelectByText(drpDownSelectEquipmentType, equipmentType);
            Thread.Sleep(2000);
            txtBoxIPAddress.SendKeys(iPAdress);
            Thread.Sleep(2000);
            txtBoxIPPortNumber.Clear();
            txtBoxIPPortNumber.SendKeys(iPPortNumber);
            btnAddOnCommissionPopUp.Click();
        }

        /// <summary>
        /// Delete all equipments
        /// </summary>
        /// <param name="driver"></param>
        public void DeleteAllEquipments(IWebDriver driver)
        {
            bool flag = false;
            Actions ac = new Actions(driver);
            try
            {
                lnkManageEquipment.Click();
                btnFindEquipment.Click();
                flag = msgNoEquipmentFound.Displayed;
            }
            catch (NoSuchElementException)
            {
                List<IWebElement> lstEquipment = new List<IWebElement>(tblEquipment.FindElements(By.TagName("tr")));

                if (lstEquipment.Count > 0)
                {
                    lstEquipment[0].Click();
                    ac.SendKeys(Keys.Shift).Perform();
                    lstEquipment.Last().Click();
                    JavaScriptExecutor.JavaScriptClick(driver, btnDelete);
                    JavaScriptExecutor.JavaScriptClick(driver, btnOkDelete);
                    GetConformationMessage().Contains("Equipment Deleted Successfully");
                    Thread.Sleep(2000);
                    JavaScriptExecutor.JavaScriptClick(driver, btnOk);
                    Thread.Sleep(2000);
                    flag = msgNoEquipmentFound.Displayed;
                }
            }
            finally
            {
                if (flag)
                    ac.Click(lnkNavigate).Build().Perform();

            }
        }

        /// <summary>
        /// Click link Equipment Maintenance On
        /// </summary>
        /// <param name="operation"></param>
        public void ClickLinkEquipmentMaintenanceOn(string operation)
        {
            if (operation.ToLower().Contains("on"))
                lnkSetMaintenanceOn.Click();
            else if (operation.ToLower().Contains("off"))
                lnkSetMaintenanceOff.Click();
        }
    }
}




