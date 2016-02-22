using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.OnlineHelp;

namespace UITests.Pages.Assess.TestTunnel.TestAccess
{
    /// <summary>
    /// the test tunnel access header
    /// </summary>
    public class TestAccessHeader : SNHeader
    {
        /// <summary>
        /// constructor
        /// </summary>
        public TestAccessHeader()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            OnlineTestHelpButton = new WebElementWrapper( ByOnlineTestHelpButton);
            LogoutButton = new WebElementWrapper( ByLogoutButton);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new TestAccessData Data
        {
            get
            {
                return (TestAccessData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        public By ByOnlineTestHelpButton { get { return By.Id("tutorial"); } }
        private WebElementWrapper OnlineTestHelpButton { get; set; }
        public By ByLogoutButton { get { return By.Id("btnLogout"); } }
        private WebElementWrapper LogoutButton { get; set; }

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
             * https://team-automation-st.sndev.net/onlinetest/tutorial.html
             */
            string windowName = "SchoolNetHelp";
            DriverCommands.WaitToSwitchWindow(windowName, 30);
            return new SchoolnetOnlineHelpPage(windowName);
        }

        public LoginPage Logout()
        {
            LogoutButton.Wait(3).Click();
            return new LoginPage();
        }
    }
}
