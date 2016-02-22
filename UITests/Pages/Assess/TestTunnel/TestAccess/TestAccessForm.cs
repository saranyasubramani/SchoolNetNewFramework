using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestTunnel.TestAccess
{
    /// <summary>
    /// the test tunnel access form
    /// </summary>
    public class TestAccessForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        public TestAccessForm()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            StartYourTestButton = new WebElementWrapper( ByStartYourTestButton);
            WrongClassClickHereLink = new WebElementWrapper( ByWrongClassClickHereLink);
            ClassSectionSelect = new SelectElementWrapper(new WebElementWrapper( ByClassSectionSelect));
            WrongTestClickHereLink = new WebElementWrapper( ByWrongTestClickHereLink);
            PasscodeText = new WebElementWrapper( ByPasscodeText);
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

        public By ByStartYourTestButton { get { return By.Id("divStartButton"); } }
        private WebElementWrapper StartYourTestButton { get; set; }
        public By ByWrongClassClickHereLink { get { return By.CssSelector("a[onclick*='showSectionDLL']"); } }
        private WebElementWrapper WrongClassClickHereLink { get; set; }
        public By ByClassSectionSelect { get { return By.Id("DropDownListSections"); } }
        private SelectElementWrapper ClassSectionSelect { get; set; }
        public By ByWrongTestClickHereLink { get { return By.CssSelector("a[onclick*='toggleTestDisplay']"); } }
        private WebElementWrapper WrongTestClickHereLink { get; set; }
        public By ByPasscodeText { get { return By.Id("TextBoxTestCode"); } }
        private WebElementWrapper PasscodeText { get; set; }
        /// <summary>
        /// the submit by
        /// </summary>
        public override By BySubmit { get { return By.Id("ButtonGo"); } }

        /// <summary>
        /// start your test
        /// </summary>
        /// <returns>TestTunnelPage</returns>
        public DefaultPage StartYourTest()
        {
            StartYourTestButton.Wait(3).Click();
            return new DefaultPage();
        }
        /// <summary>
        /// click here wrong class
        /// </summary>
        public void ClickHereWrongClass()
        {
            WrongClassClickHereLink.Wait(3).Click();
            //wait a second for the page to render
            Thread.Sleep(TimeSpan.FromSeconds(2));
            this.Parent.InitElements();
        }
        /// <summary>
        /// class sections
        /// </summary>
        public void SelectClassSections()
        {
            ClassSectionSelect.Wait(3).SelectByText(Data.ClassSection);
        }
        /// <summary>
        /// click here wrong test
        /// </summary>
        public void ClickHereWrongTest()
        {
            WrongTestClickHereLink.Wait(3).Click();
            //wait a second for the page to render
            Thread.Sleep(TimeSpan.FromSeconds(2));
            this.Parent.InitElements();
        }
        /// <summary>
        /// type passcode
        /// </summary>
        public void Passcode()
        {
            PasscodeText.Wait(3).SendKeys(Data.Passcode);
        }

        //overridden methods

        public override void InputFormFields()
        {
            if (Data.Passcode != null)
            {
                PasscodeText.Wait(3).SendKeys(Data.Passcode);
            }
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return new TestAccessPage();
        }
    }
}
