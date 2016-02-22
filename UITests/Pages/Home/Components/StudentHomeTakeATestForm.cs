using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages;
using UITests.Pages.Home;
using UITests.Pages.Assess.TestTunnel;

namespace UITests.Pages.Home.Components
{
    /// <summary>
    /// student home page, take a test widget
    /// </summary>
    public class StudentHomeTakeATestForm : SNForm
    {
        /// <summary>
        /// the constructor, for take a test widget
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public StudentHomeTakeATestForm(string overrideControlPrefix = null)
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
            PasscodeText = new WebElementWrapper(ByPasscodeText);
            StartTestButton = new WebElementWrapper(ByStartTestButton);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new StudentHomeData Data
        {
            get
            {
                return (StudentHomeData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        //private string ControlPrefix = "ctl00MainContent";
        //private string ControlPrefix2 = "ctl00ctl00WebPartManager1wp8047903wp2012912313_";
        //ctl00MainContentctl00ctl00WebPartManager1wp8047903wp2012912313_TextBoxTestCode
        private By ByPasscodeText { get { return By.CssSelector("input[id$='_TextBoxTestCode']"); } }
        private WebElementWrapper PasscodeText { get; set; }
        //ctl00MainContentctl00ctl00WebPartManager1wp8047903wp2012912313_ButtonGo
        public override By BySubmit { get { return By.CssSelector("input[id$='_ButtonGo']"); } }

        //ctl00MainContentctl00ctl00WebPartManager1wp8047903wp2012912313_ButtonStartTest
        private By ByStartTestButton { get { return By.CssSelector("input[id$='_ButtonStartTest']"); } }
        private WebElementWrapper StartTestButton { get; set; }
        //ctl00MainContentctl00ctl00WebPartManager1wp8047903wp2012912313_ButtonCancel
        public override By ByCancel { get { return By.CssSelector("input[id$='_ButtonCancel']"); } }

        /// <summary>
        /// click on the start the test button
        /// </summary>
        /// <returns>TestTunnelPage</returns>
        public DefaultPage ClickStartTestButton()
        {
            StartTestButton.Wait(3).Click();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();
            return new DefaultPage();
        }

        //implement methods
        public override void InputFormFields()
        {
            PasscodeText.SendKeys(Data.Passcode);
        }

        /// <summary>
        /// return student home page
        /// </summary>
        /// <returns>StudentHomePage</returns>
        public override IBaseScreenView ReturnSubmitPage()
        {
            //pause the script for a second to let the web part display
            System.Threading.Thread.Sleep(1000);
            return new StudentHomePage();
        }
        public override IBaseScreenView ReturnCancelPage()
        {
            return null;
        }
    }
}
