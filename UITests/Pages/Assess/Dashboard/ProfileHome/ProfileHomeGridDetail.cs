using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using UITests.Pages.Assess.Dashboard.ProfileHome.MyTests;
using UITests.Pages.Assess.Dashboard.ProfileHome.InProgressTests;
using UITests.Pages.Assess.Dashboard.ProfileHome.RecommendedTests;
using UITests.Pages.Assess.Dashboard.ProfileHome.ScheduledTests;
using UITests.Pages.Assess.Dashboard.ProfileHome.UpComingTestWindows;

namespace UITests.Pages.Assess.Dashboard.ProfileHome
{
    public class ProfileHomeGridDetail : SNDetail
    {
        /// <summary>
        /// Assess Dashboard Grid Detail Class - For all Grids displayed on the Assess Dashboard Page
        /// </summary>
        /// <param name="gridName">Name of the Grid - from the AssessDashboardGridNames enum</param>
        /// <param name="overrideControlPrefix">string to Override the Default Control Prefix</param>
        public ProfileHomeGridDetail(ProfileHomeGridNames gridName, string overrideControlPrefix = null)
            : base()
        {
            GridName = gridName;

            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }

        public override void InitElements()
        {
            MyTestsGridExpandIcon = new WebElementWrapper(ByMyTestsGridExpandIcon);
            MyTestsGridCollapseIcon = new WebElementWrapper(ByMyTestsGridCollapseIcon);
            UpcomingTestWindowsGridExpandIcon = new WebElementWrapper(ByUpcomingTestWindowsGridExpandIcon);
            UpcomingTestWindowsGridCollapseIcon = new WebElementWrapper(ByUpcomingTestWindowsGridCollapseIcon);
            InProgressTestsGridExpandIcon = new WebElementWrapper(ByInProgressTestsGridExpandIcon);
            InProgressTestsGridCollapseIcon = new WebElementWrapper(ByInProgressTestsGridCollapseIcon);
            ScheduledTestsGridExpandIcon = new WebElementWrapper(ByScheduledTestsGridExpandIcon);
            ScheduledTestsGridCollapseIcon = new WebElementWrapper(ByScheduledTestsGridCollapseIcon);
            RecommendedTestsGridExpandIcon = new WebElementWrapper(ByRecommendedTestsGridExpandIcon);
            RecommendedTestsGridCollapseIcon = new WebElementWrapper(ByRecommendedTestsGridCollapseIcon);

            MyTestsViewAllLink = new WebElementWrapper(ByMyTestsViewAllLink);
            UpcomingTestWindowsViewAllLink = new WebElementWrapper(ByUpcomingTestWindowsViewAllLink);
            InProgressTestsViewAllLink = new WebElementWrapper(ByInProgressTestsViewAllLink);
            ScheduledTestsViewAllLink = new WebElementWrapper(ByScheduledTestsViewAllLink);
            RecommendedTestsViewAllLink = new WebElementWrapper(ByRecommendedTestsViewAllLink);

            MyTestsGrid = new ProfileHomeMyTestsGrid(MyTestsGridSelector, false, ControlPrefix);
            UpcomingTestWindowsGrid = new ProfileHomeUpComingTestWindowsGrid(UpcomingTestWindowsGridSelector, false, ControlPrefix);
            InProgressTestsGrid = new ProfileHomeInProgressTestsGrid(InProgressTestsGridSelector, false, ControlPrefix);
            ScheduledTestsGrid = new ProfileHomeScheduledTestsGrid(ScheduledTestsGridSelector, false, ControlPrefix);
            RecommendedTestsGrid = new ProfileHomeRecommendedTestsGrid(RecommendedTestsGridSelector, false, ControlPrefix);
        }

        public ProfileHomeGridNames GridName { get; set; }

        private By ByMyTestsGridExpandIcon { get { return By.CssSelector("img[id='imageMyTests'][alt='Click to expand']"); } }
        private WebElementWrapper MyTestsGridExpandIcon { get; set; }
        private By ByMyTestsGridCollapseIcon { get { return By.CssSelector("img[id='imageMyTests'][alt='Click to collapse']"); } }
        private WebElementWrapper MyTestsGridCollapseIcon { get; set; }

        private By ByUpcomingTestWindowsGridExpandIcon { get { return By.CssSelector("img[id='imageTestWindowEvents'][alt='Click to expand']"); } }
        private WebElementWrapper UpcomingTestWindowsGridExpandIcon { get; set; }
        private By ByUpcomingTestWindowsGridCollapseIcon { get { return By.CssSelector("img[id='imageTestWindowEvents'][alt='Click to collapse']"); } }
        private WebElementWrapper UpcomingTestWindowsGridCollapseIcon { get; set; }

        private By ByInProgressTestsGridExpandIcon { get { return By.CssSelector("img[id='imageInProgressTests'][alt='Click to expand']"); } }
        private WebElementWrapper InProgressTestsGridExpandIcon { get; set; }
        private By ByInProgressTestsGridCollapseIcon { get { return By.CssSelector("img[id='imageInProgressTests'][alt='Click to collapse']"); } }
        private WebElementWrapper InProgressTestsGridCollapseIcon { get; set; }

        private By ByScheduledTestsGridExpandIcon { get { return By.CssSelector("img[id='imageScheduledTests'][alt='Click to expand']"); } }
        private WebElementWrapper ScheduledTestsGridExpandIcon { get; set; }
        private By ByScheduledTestsGridCollapseIcon { get { return By.CssSelector("img[id='imageScheduledTests'][alt='Click to collapse']"); } }
        private WebElementWrapper ScheduledTestsGridCollapseIcon { get; set; }

        private By ByRecommendedTestsGridExpandIcon { get { return By.CssSelector("img[id='imageDistrictRecommendedTests'][alt='Click to expand']"); } }
        private WebElementWrapper RecommendedTestsGridExpandIcon { get; set; }
        private By ByRecommendedTestsGridCollapseIcon { get { return By.CssSelector("img[id='imageDistrictRecommendedTests'][alt='Click to collapse']"); } }
        private WebElementWrapper RecommendedTestsGridCollapseIcon { get; set; }
        
        private string MyTestsViewAllLinkIdentifier { get { return ControlPrefix + "ProfileControl_MyTestResults_ButtonViewAll"; } }
        private By ByMyTestsViewAllLink { get { return By.Id(MyTestsViewAllLinkIdentifier); } }
        private WebElementWrapper MyTestsViewAllLink { get; set; }

        private string UpcomingTestWindowsViewAllLinkIdentifier { get { return ControlPrefix + "ProfileControl_TestWindowResults_ButtonViewAll"; } }
        private By ByUpcomingTestWindowsViewAllLink { get { return By.Id(UpcomingTestWindowsViewAllLinkIdentifier); } }
        private WebElementWrapper UpcomingTestWindowsViewAllLink { get; set; }

        private string InProgressTestsViewAllLinkIdentifier { get { return ControlPrefix + "ProfileControl_InProgressTestResults_ButtonViewAll"; } }
        private By ByInProgressTestsViewAllLink { get { return By.Id(InProgressTestsViewAllLinkIdentifier); } }
        private WebElementWrapper InProgressTestsViewAllLink { get; set; }

        private string ScheduledTestsViewAllLinkIdentifier { get { return ControlPrefix + "ProfileControl_ScheduledTestResults_ButtonViewAll"; } }
        private By ByScheduledTestsViewAllLink { get { return By.Id(ScheduledTestsViewAllLinkIdentifier); } }
        private WebElementWrapper ScheduledTestsViewAllLink { get; set; }

        private string RecommendedTestsViewAllLinkIdentifier { get { return ControlPrefix + "ProfileControl_RecommendedTestResults_ButtonViewAll"; } }
        private By ByRecommendedTestsViewAllLink { get { return By.Id(RecommendedTestsViewAllLinkIdentifier); } }
        private WebElementWrapper RecommendedTestsViewAllLink { get; set; }

        private string MyTestsGridSelector { get { return "#" + ControlPrefix + "ProfileControl_MyTestResults_ctl00_gridResults"; } }
        public ProfileHomeMyTestsGrid MyTestsGrid { get; set; }

        private string UpcomingTestWindowsGridSelector { get { return "#" + ControlPrefix + "ProfileControl_TestWindowResults_ctl00_gridResults"; } }
        public ProfileHomeUpComingTestWindowsGrid UpcomingTestWindowsGrid { get; set; }
        
        private string InProgressTestsGridSelector { get { return "#" + ControlPrefix + "ProfileControl_InProgressTestResults_ctl00_gridResults"; } }
        public ProfileHomeInProgressTestsGrid InProgressTestsGrid { get; set; }
        
        private string ScheduledTestsGridSelector { get { return "#" + ControlPrefix + "ProfileControl_ScheduledTestResults_ctl00_gridResults"; } }
        public ProfileHomeScheduledTestsGrid ScheduledTestsGrid { get; set; }
        
        private string RecommendedTestsGridSelector { get { return "#" + ControlPrefix + "ProfileControl_RecommendedTestResults_ctl00_gridResults"; } }
        public ProfileHomeRecommendedTestsGrid RecommendedTestsGrid { get; set; }


        /// <summary>
        /// Expand the required Grid on the Assess Dashboard Page
        /// </summary>                
        public void ExpandGrid()
        {
            switch (GridName)
            {
                case ProfileHomeGridNames.MyTests:
                    MyTestsGridExpandIcon.Wait(2).Click();
                    MyTestsGrid.SetGridLists();
                    break;
                case ProfileHomeGridNames.UpcomingTestWindows:
                    UpcomingTestWindowsGridExpandIcon.Wait(2).Click();
                    UpcomingTestWindowsGrid.SetGridLists();
                    break;
                case ProfileHomeGridNames.InProgressTests:
                    InProgressTestsGridExpandIcon.Wait(2).Click();
                    InProgressTestsGrid.SetGridLists();
                    break;
                case ProfileHomeGridNames.ScheduledTests:
                    ScheduledTestsGridExpandIcon.Wait(2).Click();
                    ScheduledTestsGrid.SetGridLists();
                    break;
                case ProfileHomeGridNames.RecommendedTests:
                    RecommendedTestsGridExpandIcon.Wait(2).Click();
                    RecommendedTestsGrid.SetGridLists();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Collapse the required Grid on the Assess Dashboard Page
        /// </summary>        
        public void CollapseGrid()
        {
            switch (GridName)
            {
                case ProfileHomeGridNames.MyTests:
                    MyTestsGridCollapseIcon.Wait(2).Click();
                    break;
                case ProfileHomeGridNames.UpcomingTestWindows:
                    UpcomingTestWindowsGridCollapseIcon.Wait(2).Click();
                    break;
                case ProfileHomeGridNames.InProgressTests:
                    InProgressTestsGridCollapseIcon.Wait(2).Click();
                    break;
                case ProfileHomeGridNames.ScheduledTests:
                    ScheduledTestsGridCollapseIcon.Wait(2).Click();
                    break;
                case ProfileHomeGridNames.RecommendedTests:
                    RecommendedTestsGridCollapseIcon.Wait(2).Click();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// To View All the Results for the specified Grid
        /// </summary>        
        public void ViewAllResults()
        {
            switch (GridName)
            {
                case ProfileHomeGridNames.MyTests:
                    MyTestsViewAllLink.Wait(2).Click();
                    break;
                case ProfileHomeGridNames.UpcomingTestWindows:
                    UpcomingTestWindowsViewAllLink.Wait(2).Click();
                    break;
                case ProfileHomeGridNames.InProgressTests:
                    InProgressTestsViewAllLink.Wait(2).Click();
                    break;
                case ProfileHomeGridNames.ScheduledTests:
                    ScheduledTestsViewAllLink.Wait(2).Click();
                    break;
                case ProfileHomeGridNames.RecommendedTests:
                    RecommendedTestsViewAllLink.Wait(2).Click();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
