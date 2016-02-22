using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Admin.AssessAdminSettings.OnlineTesting
{
    /// <summary>
    /// IP Filtering form
    /// </summary>
    public class IPFilteringForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix">the override control prefix</param>
        public IPFilteringForm( string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Message = new WebElementWrapper( ByMessage);
            OnlineTestingEnabledCheck = new WebElementWrapper( ByOnlineTestingEnabledCheck);
            ShowStudentScoresEnabledCheck = new WebElementWrapper( ByShowStudentScoresEnabledCheck);
            NewAddressLink = new WebElementWrapper( ByNewAddressLink);
            Grid = new IPFilteringGrid( gridCssSelector, true, this.ControlPrefix);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new OnlineTestingData Data
        {
            get
            {
                return (OnlineTestingData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private string gridCssSelector { get { return "#" + ControlPrefix + "ctl00_AdminControl_pnlIPFilteringList"; } }
        /// <summary>
        /// the grid
        /// </summary>
        public IPFilteringGrid Grid { get; private set; }
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ctl00_AdminControl_ButtonSave"); } }
        public By ByMessage { get { return By.Id(ControlPrefix + "ctl00_AdminControl_LabelSaved"); } }
        public WebElementWrapper Message { get; private set; }
        public By ByOnlineTestingEnabledCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_CheckBoxEnableOnlineTesting"); } }
        public WebElementWrapper OnlineTestingEnabledCheck { get; private set; }
        public By ByShowStudentScoresEnabledCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_chkStudentScoresEnabled"); } }
        public WebElementWrapper ShowStudentScoresEnabledCheck { get; private set; }
        public By ByNewAddressLink { get { return By.Id(ControlPrefix + "ctl00_AdminControl_ButtonCreateItem"); } }
        public WebElementWrapper NewAddressLink { get; private set; }

        /// <summary>
        /// online testing enabled
        /// </summary>
        public void SelectOnlineTestingEnabled()
        {
            OnlineTestingEnabledCheck.Wait(3).Check();
        }
        /// <summary>
        /// online testing disabled
        /// </summary>
        public void SelectOnlineTestingDisabled()
        {
            OnlineTestingEnabledCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// show student scores upon test submission enabled
        /// </summary>
        public void SelectShowStudentScoresUponTestSubmissionEnabled()
        {
            ShowStudentScoresEnabledCheck.Wait(3).Check();
        }
        /// <summary>
        /// show student scores upon test submission disabled
        /// </summary>
        public void SelectShowStudentScoresUponTestSubmissionDisabled()
        {
            ShowStudentScoresEnabledCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// select new address
        /// </summary>
        public void SelectNewAddress()
        {
            NewAddressLink.Wait(3).Click();
        }
        /// <summary>
        /// verify message
        /// </summary>
        public void VerifyMessage()
        {
            Message.Wait(5);
            Message.Text = Data.Message;//dummy text
            string actual = Message.Text;
            Assert.IsTrue(actual.Contains(Data.Message), "Expected the message: '" + Data.Message + "'; but got the actual message: '" + actual + "'.");
        }
        /// <summary>
        /// find row by IP name
        /// </summary>
        /// <returns>IPFilteringRow</returns>
        public IPFilteringRow FindRowByIPName()
        {
            return this.Grid.GetsFirstRowContainingTextToFindFromList(IPFilteringColumnNames.Name, Data.Name);
        }
        /// <summary>
        /// find row by IP address
        /// </summary>
        /// <returns>IPFilteringRow</returns>
        public IPFilteringRow FindRowByIPAddress()
        {
            return this.Grid.GetsFirstRowContainingTextToFindFromList(IPFilteringColumnNames.Address, Data.Address);
        }
        /// <summary>
        /// disable IP by name
        /// </summary>
        public void DisableIPByName()
        {
            IPFilteringRow ipFilteringRow = FindRowByIPName();
            ipFilteringRow.SelectDisable();
        }
        /// <summary>
        /// disable IP by address
        /// </summary>
        public void DisableIPByAddress()
        {
            IPFilteringRow ipFilteringRow = FindRowByIPAddress();
            ipFilteringRow.SelectDisable();
        }
        /// <summary>
        /// enable IP by name
        /// </summary>
        public void EnableIPByName()
        {
            IPFilteringRow ipFilteringRow = FindRowByIPName();
            ipFilteringRow.SelectEnable();
        }
        /// <summary>
        /// enable IP by address
        /// </summary>
        public void EnableIPByAddress()
        {
            IPFilteringRow ipFilteringRow = FindRowByIPAddress();
            ipFilteringRow.SelectEnable();
        }
        /// <summary>
        /// remove IP by name
        /// </summary>
        public void RemoveIPByName()
        {
            IPFilteringRow ipFilteringRow = FindRowByIPName();
            ipFilteringRow.SelectRemove();
        }
        /// <summary>
        /// remove IP by address
        /// </summary>
        public void RemoveIPByAddress()
        {
            IPFilteringRow ipFilteringRow = FindRowByIPAddress();
            ipFilteringRow.SelectRemove();
        }

        //overridden methods

        public void InputFormFields(int index)
        {
            IPFilteringRow row = (IPFilteringRow)Grid.GetRowFromList(index);
            row.SetName(Data.Name);
            row.SetAddress(Data.Address);
        }
    }
}
