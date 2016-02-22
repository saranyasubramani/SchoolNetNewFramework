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
    /// the attach recording pop-up
    /// </summary>
    public class AttachRecordingForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="driver">IWebDriver</param>
        public AttachRecordingForm()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Dialog = new WebElementWrapper(ByDialog);
        }

        private By ByDialog { get { return By.CssSelector(".modal.hide.in"); } }
        private WebElementWrapper Dialog { get; set; }
        /// <summary>
        /// the cancel by
        /// </summary>
        public override By ByCancel { get { return By.CssSelector(".btn.CancelButton"); } }
        /// <summary>
        /// the submit by
        /// </summary>
        public override By BySubmit { get { return By.CssSelector(".btn.InsertButton"); } }
    }
}
