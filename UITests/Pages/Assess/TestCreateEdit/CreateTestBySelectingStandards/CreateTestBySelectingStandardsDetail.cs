using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestCreateEdit.CreateTestBySelectingStandards
{
    /// <summary>
    /// the create test by selecting standards detail
    /// </summary>
    public class CreateTestBySelectingStandardsDetail : SNDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public CreateTestBySelectingStandardsDetail(string overrideControlPrefix = null)
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
            BackToPreviousPageTopLink = new WebElementWrapper(ByBackToPreviousPageTopLink);
            BackToPreviousPageBottomLink = new WebElementWrapper(ByBackToPreviousPageBottomLink);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new CreateTestBySelectingStandardsData Data
        {
            get
            {
                return (CreateTestBySelectingStandardsData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private By ByBackToPreviousPageTopLink { get { return By.Id(ControlPrefix + "BackToPreviousPageControl1_HyperLinkBack"); } }
        private WebElementWrapper BackToPreviousPageTopLink { get; set; }
        private By ByBackToPreviousPageBottomLink { get { return By.Id(ControlPrefix + "BackToPreviousPageControl_HyperLinkBack"); } }
        private WebElementWrapper BackToPreviousPageBottomLink { get; set; }

        /// <summary>
        /// back to previous page
        /// </summary>
        public void BackToPreviousPage()
        {
            BackToPreviousPageTopLink.Click();
        }
    }
}
