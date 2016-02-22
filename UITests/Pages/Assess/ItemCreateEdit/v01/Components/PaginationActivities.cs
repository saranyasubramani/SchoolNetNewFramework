using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Framework;
using Core.Views;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.Components
{
    /// <summary>
    /// pagination activities component
    /// </summary>
    public class PaginationActivities : SNComponent
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public PaginationActivities(string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            PreviousSetLink = new WebElementWrapper(ByPreviousSetLink);
            PreviousLink = new WebElementWrapper(ByPreviousLink);
            QuestionPageLink = new WebElementWrapper(ByQuestionPageLink);
            NextLink = new WebElementWrapper(ByNextLink);
            NextSetLink = new WebElementWrapper(ByNextSetLink);
        }

        private By ByPreviousSetLink { get { return By.Id(ControlPrefix + "ActivityPager_rptQuestionsPager_ctl00_linkPrevSet"); } }
        private WebElementWrapper PreviousSetLink { get; set; }
        private By ByPreviousLink { get { return By.Id(ControlPrefix + "ActivityPager_rptQuestionsPager_ctl00_linkPrev"); } }
        private WebElementWrapper PreviousLink { get; set; }
        private By ByQuestionPageLink { get { return By.Id(ControlPrefix + "ActivityPager_rptQuestionsPager_ctl01_linkQuestionPage"); } }
        private WebElementWrapper QuestionPageLink { get; set; }
        private By ByNextLink { get { return By.Id(ControlPrefix + "ActivityPager_rptQuestionsPager_ctl02_linkNext"); } }
        private WebElementWrapper NextLink { get; set; }
        private By ByNextSetLink { get { return By.Id(ControlPrefix + "ActivityPager_rptQuestionsPager_ctl02_linkNextSet"); } }
        private WebElementWrapper NextSetLink { get; set; }

        /// <summary>
        /// select previous set
        /// </summary>
        public void SelectPreviousSet()
        {
            PreviousSetLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime();
        }
        /// <summary>
        /// select previous
        /// </summary>
        public void SelectPrevious()
        {
            PreviousLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime();
        }
        /// <summary>
        /// select question page
        /// </summary>
        public void SelectQuestionPage()
        {
            QuestionPageLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime();
        }
        /// <summary>
        /// select next
        /// </summary>
        public void SelectNext()
        {
            NextLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime();
        }
        /// <summary>
        /// select next set
        /// </summary>
        public void SelectNextSet()
        {
            NextSetLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime();
        }
    }
}
