using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Controls
{
    /// <summary>
    /// previous page link at the bottom of the page
    /// </summary>
    public class PreviousPageBottomLink : SNComponent
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="overrideControlPrefix"></param>
        public PreviousPageBottomLink(PageNames pageName, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            switch (pageName)
            {
                case PageNames.AnswerSheetSearch:
                    //ctl00_MainContent_BackToPreviousPageControl_HyperLinkBackText
                    _controlPrefix2 = ControlPrefix + "BackToPreviousPageControl_HyperLinkBackText";
                    break;
                case PageNames.TrackTestStatus:
                    //ctl00_MainContent_BackToPreviousPageControl_HyperLinkBackText
                    _controlPrefix2 = ControlPrefix + "BackToPreviousPageControl_HyperLinkBackText";
                    break;
                case PageNames.PassageDetail:
                    //ctl00_MainContent_BackToPreviousPageControl_HyperLinkBackText
                    _controlPrefix2 = ControlPrefix + "BackToPreviousPageControl_HyperLinkBackText";
                    break;
                case PageNames.ViewTestDetails:
                    //ctl00_MainContent_BackToPreviousPageControl_HyperLinkBackText
                    _controlPrefix2 = ControlPrefix + "BackToPreviousPageControl_HyperLinkBackText";
                    break;
                case PageNames.TestWindowPlanHome:
                    //ctl00_MainContent_BackToPreviousPageControl_HyperLinkBack
                    _controlPrefix2 = ControlPrefix + "BackToPreviousPageControl_HyperLinkBack";
                    break;
                case PageNames.ScoreSearch:
                    //ctl00_MainContent_BackToPreviousPageControl_HyperLinkBack
                    _controlPrefix2 = ControlPrefix + "BackToPreviousPageControl_HyperLinkBack";
                    break;
                case PageNames.EditScores:
                    //ctl00_MainContent_BackToPreviousPageControl_HyperLinkBackText
                    _controlPrefix2 = ControlPrefix + "BackToPreviousPageControl_HyperLinkBackText";
                    break;
                case PageNames.ViewItemStatistics:
                    //ctl00_AppTitle_BackToPreviousPageControl_HyperLinkBackText
                    _controlPrefix2 = "ctl00_AppTitle_BackToPreviousPageControl_HyperLinkBackText";
                    break;
            }
            _previousPageLink = By.Id(_controlPrefix2);
            Control = new WebElementWrapper(ByPreviousPageLink);
        }

        //public By ByPreviousPageLink { get { return By.Id(_controlPrefix2 + "HyperLinkBackText"); }
        public By ByPreviousPageLink
        {
            get { return _previousPageLink; }
            set { _previousPageLink = value; }
        }
        /// <summary>
        /// previous page link
        /// </summary>
        public WebElementWrapper Control { get; private set; }

        private string _controlPrefix2 = "";
        private By _previousPageLink;
    }
}
