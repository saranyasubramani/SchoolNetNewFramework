using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Rubric.RubricDetail
{
    /// <summary>
    /// rubric detail content
    /// </summary>
    public class RubricDetailDetail : SNDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="RubricDetailType">item central type</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public RubricDetailDetail(string overrideControlPrefix = null)
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
            BackToPreviousPageLink = new WebElementWrapper(ByBackToPreviousPageLink);
            CopyLink = new WebElementWrapper(ByCopyLink);
            EditLink = new WebElementWrapper(ByEditLink);
            DeleteLink = new WebElementWrapper(ByDeleteLink);
            Language = new WebElementWrapper(ByLanguage);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new RubricDetailData Data
        {
            get
            {
                return (RubricDetailData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// fake text
        /// </summary>
        public string FakeText { get; set; }
        private By ByBackToPreviousPageLink { get { return By.Id("ctl00_AppTitle_BackToPreviousPageControl_HyperLinkBack"); } }
        private WebElementWrapper BackToPreviousPageLink { get; set; }
        private By ByCopyLink { get { return By.LinkText("Copy"); } }
        private WebElementWrapper CopyLink { get; set; }
        private By ByEditLink { get { return By.LinkText("Edit"); } }
        private WebElementWrapper EditLink { get; set; }
        private By ByDeleteLink { get { return By.LinkText("Delete"); } }
        private WebElementWrapper DeleteLink { get; set; }
        private By ByLanguage { get { return By.CssSelector("#rubricDetails > .row > .span5 > div.row:nth-of-type(4)"); } }
        private WebElementWrapper Language { get; set; }

        /// <summary>
        /// back to previous page
        /// </summary>
        public void BackToPreviousPage()
        {
            BackToPreviousPageLink.Click();
        }
        /// <summary>
        /// copy
        /// </summary>
        public void SelectCopy()
        {
            CopyLink.Click();
        }
        /// <summary>
        /// edit
        /// </summary>
        public void SelectEdit()
        {
            EditLink.Click();
        }
        /// <summary>
        /// delete
        /// </summary>
        public void SelectDelete()
        {
            string currentWindow = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + currentWindow + "'.");
            DeleteLink.Click();

            AlertHandler alert = new AlertHandler();
            alert.VerifyText("Are you sure you want to delete this rubric? All associations to this rubric will be permanently deleted.");
            alert.Accept();

            //switch to window
            DriverCommands.WaitToSwitchWindow(currentWindow, 5);
        }
        /// <summary>
        /// get the text is recommended/assigned to schools
        /// </summary>
        /// <returns>text</returns>
        public string GetLanguageText()
        {
            Language.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                Language.Text = FakeText;
            }
            return Language.Text;
        }
    }
}
