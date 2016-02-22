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
    /// the attach open response answer pop-up
    /// </summary>
    public class AttachOpenResponseAnswerForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public AttachOpenResponseAnswerForm()
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
            BrowseButton = new WebElementWrapper(ByBrowseButton);
        }

        private By ByDialog { get { return By.CssSelector(".modal.hide.in"); } }
        private WebElementWrapper Dialog { get; set; }
        private By ByBrowseButton { get { return By.Id("browseButton"); } }
        private WebElementWrapper BrowseButton { get; set; }
        /// <summary>
        /// the cancel by
        /// </summary>
        public override By ByCancel { get { return By.CssSelector(".btn.CancelButton"); } }
        /// <summary>
        /// the submit by
        /// </summary>
        public override By BySubmit { get { return By.Id("btn_snfileuploadattach"); } }
    }
}
