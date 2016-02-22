using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Admin.AssessAdminSettings.TestProperties
{
    /// <summary>
    /// TestProperties form
    /// </summary>
    public class TestPropertiesForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix">the override control prefix</param>
        public TestPropertiesForm( string overrideControlPrefix = null)
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
            PersonalTestsOnRadio = new WebElementWrapper( ByPersonalTestsOnRadio);
            PersonalTestsOffRadio = new WebElementWrapper( ByPersonalTestsOffRadio);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new TestPropertiesData Data
        {
            get
            {
                return (TestPropertiesData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ctl00_AdminControl_ButtonSaveSelections"); } }
        public By ByMessage { get { return By.CssSelector(".alert.alert-success"); } }
        public WebElementWrapper Message { get; private set; }
        public By ByPersonalTestsOnRadio { get { return By.Id(ControlPrefix + "ctl00_AdminControl_RepeaterTestCategoryTypes_ctl04_RadioButtonListEnablePersonalTest_0"); } }
        public WebElementWrapper PersonalTestsOnRadio { get; private set; }
        public By ByPersonalTestsOffRadio { get { return By.Id(ControlPrefix + "ctl00_AdminControl_RepeaterTestCategoryTypes_ctl04_RadioButtonListEnablePersonalTest_1"); } }
        public WebElementWrapper PersonalTestsOffRadio { get; private set; }

        /// <summary>
        /// personal tests on
        /// </summary>
        public void SelectPersonalTestsOn()
        {
            PersonalTestsOnRadio.Wait(3).Click();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            this.Parent.InitElements();
        }
        /// <summary>
        /// personal tests off
        /// </summary>
        public void SelectPersonalTestsOff()
        {
            PersonalTestsOffRadio.Wait(3).Click();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            this.Parent.InitElements();
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
