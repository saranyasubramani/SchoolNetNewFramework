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

namespace UITests.Pages.Assess.TestTunnel.Login
{
    /// <summary>
    /// the test tunnel login header
    /// </summary>
    public class LoginHeader : SNHeader
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public LoginHeader()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            OnlineTestHelpButton = new WebElementWrapper(ByOnlineTestHelpButton);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new LoginData Data
        {
            get
            {
                return (LoginData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        public By ByOnlineTestHelpButton { get { return By.Id("tutorial"); } }
        private WebElementWrapper OnlineTestHelpButton { get; set; }

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
    }
}
