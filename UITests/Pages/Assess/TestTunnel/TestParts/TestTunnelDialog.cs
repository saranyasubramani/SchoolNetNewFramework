using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestTunnel.TestParts
{
    /// <summary>
    /// the test tunnel floating dialog
    /// </summary>
    public class TestTunnelDialog : SNDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TestTunnelDialog()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            LightBox = new WebElementWrapper( ByLightBox);
            MessageLabel = new WebElementWrapper( ByMessageLabel);
            ExitTestButton = new WebElementWrapper( ByExitTestButton);
            ReturnToTestButton = new WebElementWrapper( ByReturnToTestButton);
            YesButton = new WebElementWrapper( ByYesButton);
            NoButton = new WebElementWrapper( ByNoButton);
            CloseTestButton = new WebElementWrapper( ByCloseTestButton);
        }

        public By ByLightBox { get { return By.Id("lightBox"); } }
        private WebElementWrapper LightBox { get; set; }
        public By ByMessageLabel { get { return By.Id("divLightboxMessage"); } }
        private WebElementWrapper MessageLabel { get; set; }
        public By ByExitTestButton { get { return By.Id("btnPause"); } }
        private WebElementWrapper ExitTestButton { get; set; }
        public By ByReturnToTestButton { get { return By.Id("btnReturn"); } }
        private WebElementWrapper ReturnToTestButton { get; set; }
        public By ByYesButton { get { return By.Id("btnYes"); } }
        private WebElementWrapper YesButton { get; set; }
        public By ByNoButton { get { return By.Id("btnNo"); } }
        private WebElementWrapper NoButton { get; set; }
        public By ByCloseTestButton { get { return By.Id("btnClose"); } }
        private WebElementWrapper CloseTestButton { get; set; }

        /// <summary>
        /// select exit test
        /// </summary>
        public void SelectExitTest()
        {
            ExitTestButton.Wait(3).Click();
        }

        /// <summary>
        /// select return to test
        /// </summary>
        public void SelectReturnToTest()
        {
            ReturnToTestButton.Wait(3).Click();
        }

        /// <summary>
        /// select yes
        /// </summary>
        public void SelectYes()
        {
            YesButton.Wait(3).Click();
        }

        /// <summary>
        /// select no
        /// </summary>
        public void SelectNo()
        {
            NoButton.Wait(3).Click();
        }

        /// <summary>
        /// select close test
        /// </summary>
        public void SelectCloseTest()
        {
            CloseTestButton.Wait(3).Click();
        }
    }
}
