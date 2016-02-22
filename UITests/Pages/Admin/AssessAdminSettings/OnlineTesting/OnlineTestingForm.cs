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
    /// Online Testing form
    /// </summary>
    public class OnlineTestingForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix">the override control prefix</param>
        public OnlineTestingForm( string overrideControlPrefix = null)
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
        /// verify message
        /// </summary>
        public void VerifyMessage()
        {
            Message.Wait(5);
            Message.Text = Data.Message;//dummy text
            string actual = Message.Text;
            Assert.IsTrue(actual.Contains(Data.Message), "Expected the message: '" + Data.Message + "'; but got the actual message: '" + actual + "'.");
        }
    }
}
