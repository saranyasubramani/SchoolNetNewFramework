using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.OnlineHelp;
using UITests.Pages.Assess.TestTunnel.TestForms;
using UITests.Pages.Assess.TestTunnel.TestParts;

namespace UITests.Pages.Assess.TestTunnel.Default
{
    /// <summary>
    /// the test tunnel default header
    /// </summary>
    public class DefaultHeader : SNHeader
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public DefaultHeader()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            StudentNameLabel = new WebElementWrapper( ByStudentNameLabel);
            TestNameLabel = new WebElementWrapper( ByTestNameLabel);
            OnlineTestHelpButton = new WebElementWrapper( ByOnlineTestHelpButton);
            AccessibilityOptionsButton = new WebElementWrapper( ByAccessibilityOptionsButton);
            ReverseContrastLink = new WebElementWrapper( ByReverseContrastLink);
            Clock = new WebElementWrapper( ByClock);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new DefaultData Data
        {
            get
            {
                return (DefaultData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// list of test form types
        /// </summary>
        public List<TestTypeForm> TestList { get; set; }
        /// <summary>
        /// get the item's list of IDs and indexes
        /// </summary>
        public ReadOnlyCollection<object> ItemIdToIndexList { get; set; }
        public By ByStudentNameLabel { get { return By.Id("studentName"); } }
        private WebElementWrapper StudentNameLabel { get; set; }
        public By ByTestNameLabel { get { return By.Id("testName"); } }
        private WebElementWrapper TestNameLabel { get; set; }
        public By ByOnlineTestHelpButton { get { return By.Id("tutorial"); } }
        private WebElementWrapper OnlineTestHelpButton { get; set; }
        public By ByAccessibilityOptionsButton { get { return By.Id("btnApip"); } }
        private WebElementWrapper AccessibilityOptionsButton { get; set; }
        public By ByReverseContrastLink { get { return By.CssSelector("#ulApip .ReverseContrast > a"); } }
        private WebElementWrapper ReverseContrastLink { get; set; }
        public By ByClock { get { return By.Id("clock"); } }
        private WebElementWrapper Clock { get; set; }


        /// <summary>
        /// verify the test name
        /// </summary>
        public void VerifyTestName()
        {
            TestNameLabel.Wait(2);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                TestNameLabel.Text = Data.TestName;
            }

            Assert.IsTrue(TestNameLabel.Text.Contains(Data.TestName),
                string.Format("Test Tunnel header does not contain Test Name: '{0}'", Data.TestName));
        }

        /// <summary>
        /// verify the tester's first name
        /// </summary>
        public void VerifyTestersFirstName()
        {
            StudentNameLabel.Wait(2);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                StudentNameLabel.Text = Data.TestersFirstName;
            }

            Assert.IsTrue(StudentNameLabel.Text.Contains(Data.TestersFirstName),
                string.Format("Test Tunnel header does not contain Tester's First Name: '{0}'", Data.TestersFirstName));
        }

        /// <summary>
        /// verify the tester's last name
        /// </summary>
        public void VerifyTestersLastName()
        {
            StudentNameLabel.Wait(2);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                StudentNameLabel.Text = Data.TestersLastName;
            }

            Assert.IsTrue(StudentNameLabel.Text.Contains(Data.TestersLastName),
                string.Format("Test Tunnel header does not contain Tester's Last Name: '{0}'", Data.TestersLastName));
        }

        /// <summary>
        /// return the clock time
        /// </summary>
        public string GetClockTime()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                Clock.Text = Data.ExpectedResult;
            }
            return Clock.Text;
        }

        /// <summary>
        /// select Online Test Help
        /// </summary>
        /// <returns>SchoolnetOnlineHelpPage</returns>
        public SchoolnetOnlineHelpPage SelectOnlineTestHelp()
        {
            OnlineTestHelpButton.Wait(3).Click();
            //pause the script for a second to let the pop-up display
            System.Threading.Thread.Sleep(1000);
            /*
             * https://team-automation-st.sndev.net/OnlineTest/onlinetest.js
             * function openTutorial() calls openHelpWindow()
             * https://team-automation-st.sndev.net/OnlineTest/onlinetest.SNInclude.js
             * var openHelpWindow = my.openHelpWindow = function
             * var title = 'SchoolNetHelp'
             * snHelpTopicWindow = window.open(url, title, 
             */
            string windowName = "SchoolNetHelp";
            DriverCommands.WaitToSwitchWindow(windowName, 30);
            return new SchoolnetOnlineHelpPage(windowName);
        }

        /// <summary>
        /// select Accessibility Options
        /// </summary>
        public void SelectAccessibilityOptions()
        {
            AccessibilityOptionsButton.Wait(3).Click();
            //pause the script for a second to let the pop-up display
            System.Threading.Thread.Sleep(1000);
        }

        /// <summary>
        /// select Accessibility Options, then select Reverse Contrast
        /// </summary>
        public void SelectAccessibilityOptionsReverseContrast()
        {
            SelectAccessibilityOptions();
            ReverseContrastLink.Wait(3).Click();
            //pause the script for a second to start the page post-back
            System.Threading.Thread.Sleep(2000);
            this.DriverCommands.WaitAndMeasurePageLoadTime();
        }
    }
}
