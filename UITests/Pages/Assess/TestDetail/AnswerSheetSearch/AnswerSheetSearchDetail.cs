using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Controls;
using UITests.Pages.Assess.TestDetail.Components;

namespace UITests.Pages.Assess.TestDetail.AnswerSheetSearch
{
    /// <summary>
    /// answer key generation page, the detail
    /// </summary>
    public class AnswerSheetSearchDetail : SNDetail
    {
        /// <summary>
        /// the answer sheet search detail constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public AnswerSheetSearchDetail(  string overrideControlPrefix = null)
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
            SectionTabLink = new WebElementWrapper( BySectionTabLink);
            SchoolTabLink = new WebElementWrapper( BySchoolTabLink);
            ViewDetailsLink = new ViewDetailsLink( PageNames.AnswerSheetSearch, this.ControlPrefix);
            PreviousPageBottomLink = new PreviousPageBottomLink( PageNames.AnswerSheetSearch, this.ControlPrefix);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new AnswerSheetSearchData Data
        {
            get
            {
                return (AnswerSheetSearchData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private string ControlPrefix2 = "ProfileTabControl1_RepeaterTabs_ctl";
        //ctl00_MainContent_ProfileTabControl1_RepeaterTabs_ctl00_LinkButtonTab
        private By BySectionTabLink { get { return By.Id(ControlPrefix + ControlPrefix2 + "00" + "_LinkButtonTab"); } }
        private WebElementWrapper SectionTabLink { get; set; }
        //ctl00_MainContent_ProfileTabControl1_RepeaterTabs_ctl01_LinkButtonTab
        private By BySchoolTabLink { get { return By.Id(ControlPrefix + ControlPrefix2 + "01" + "_LinkButtonTab"); } }
        private WebElementWrapper SchoolTabLink { get; set; }
        private ViewDetailsLink ViewDetailsLink { get; set; }
        private PreviousPageBottomLink PreviousPageBottomLink { get; set; }

        /// <summary>
        /// click on view details link
        /// </summary>
        /// <returns></returns>
        public ViewTestDetailsPage ClickViewDetailsLink()
        {
            ViewDetailsLink.Control.Wait(3).Click();
            return new ViewTestDetailsPage();
        }

        /// <summary>
        /// click on previous page link at the bottom of the page
        /// </summary>
        /// <returns></returns>
        public void ClickPreviousPageBottomLink()
        {
            PreviousPageBottomLink.Control.Wait(3).Click();
        }

        /// <summary>
        /// click on section tab
        /// </summary>
        public void ClickSectionTab()
        {
            SectionTabLink.Wait(3).Click();
        }

        /// <summary>
        /// click on school/grade tab
        /// </summary>
        public void ClickSchoolTab()
        {
            SchoolTabLink.Wait(3).Click();
        }
    }
}
