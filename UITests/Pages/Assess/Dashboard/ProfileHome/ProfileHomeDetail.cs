using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Assess.ItemCentral;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestCentral;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.Dashboard.ProfileHome.MyTests;
using UITests.Pages.Assess.Dashboard.ProfileHome.InProgressTests;
using UITests.Pages.Assess.Dashboard.ProfileHome.RecommendedTests;
using UITests.Pages.Assess.Dashboard.ProfileHome.ScheduledTests;
using UITests.Pages.Assess.Dashboard.ProfileHome.UpComingTestWindows;
using UITests.Pages.Assess.TestCreateEdit;

namespace UITests.Pages.Assess.Dashboard.ProfileHome
{
    /// <summary>
    /// assess dashboard detail
    /// </summary>
    public class ProfileHomeDetail : SNDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public ProfileHomeDetail() : base()
        {
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            FindTest = new WebElementWrapper(ByFindTest);
            FindItem = new WebElementWrapper(ByFindItem);
            CreateTest = new WebElementWrapper(ByCreateTest);
            CreateItem = new WebElementWrapper(ByCreateItem);
            HeaderTitleLabel = new WebElementWrapper(ByHeaderTitleLabel);
            RecommendedTestsImage = new WebElementWrapper(ByRecommendedTestsImage);

            //Enable the grids after writing integrations tests and have verified that the Test Code Works
            MyTestsGridDetail = new ProfileHomeGridDetail(ProfileHomeGridNames.MyTests);
            UpcomingTestWindowsGridDetail = new ProfileHomeGridDetail(ProfileHomeGridNames.UpcomingTestWindows);
            InProgressTestsGridDetail = new ProfileHomeGridDetail(ProfileHomeGridNames.InProgressTests);
            ScheduledTestsGridDetail = new ProfileHomeGridDetail(ProfileHomeGridNames.ScheduledTests);
            RecommendedTestsGridDetail = new ProfileHomeGridDetail(ProfileHomeGridNames.RecommendedTests);
        }
        /// <summary>
        /// the data
        /// </summary>
        public new ProfileHomeData Data
        {
            get
            {
                return (ProfileHomeData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        protected By ByFindTest { get { return By.Id(ControlPrefix + "ProfileControl_TestFinderSearchCompressed1_LinkAdvancedSearch"); } }
        protected WebElementWrapper FindTest { get; set; }
        protected By ByFindItem { get { return By.Id(ControlPrefix + "ProfileControl_ButtonItemSearch"); } }
        protected WebElementWrapper FindItem { get; set; }
        protected By ByCreateTest { get { return By.Id(ControlPrefix + "ProfileControl_ButtonCreateTest"); } }
        protected WebElementWrapper CreateTest { get; set; }
        protected By ByCreateItem { get { return By.Id(ControlPrefix + "ProfileControl_ButtonCreateItem"); } }
        protected WebElementWrapper CreateItem { get; set; }
        protected By ByHeaderTitleLabel { get { return By.Id("ctl00_AppTitle_HeaderTitle"); } }
        protected WebElementWrapper HeaderTitleLabel { get; set; }
        protected By ByRecommendedTestsImage { get { return By.Id("imageDistrictRecommendedTests"); } }
        protected WebElementWrapper RecommendedTestsImage { get; set; }

        /// <summary>
        /// find a test
        /// </summary>
        /// <returns>TestCentralHomePage</returns>
        public TestCentralHomePage FindATest()
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            FindTest.Click();
            return new TestCentralHomePage();
        }
        /// <summary>
        /// find an item
        /// </summary>
        /// <returns>ItemCentralHomePage</returns>
        public ItemCentralHomePage FindAnItem()
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            FindItem.Click();
            return new ItemCentralHomePage();
        }
        /// <summary>
        /// create a test
        /// </summary>
        /// <returns>CreateTestPortalPage</returns>
        public CreateTestPortalPage CreateATest()
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            CreateTest.Click();
            return new CreateTestPortalPage();
        }
        /// <summary>
        /// create an item
        /// </summary>
        /// <returns>EditTestItemChooseNewItemPage</returns>
        public EditTestItemChooseNewItemPage CreateAnItem()
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            CreateItem.Click();
            return new EditTestItemChooseNewItemPage();
        }
        /// <summary>
        /// my tests grid detail
        /// </summary>
        public ProfileHomeGridDetail MyTestsGridDetail { get; set; }
        /// <summary>
        /// upcoming test windows grid detail
        /// </summary>
        public ProfileHomeGridDetail UpcomingTestWindowsGridDetail { get; set; }
        /// <summary>
        /// in progress tests grid detail
        /// </summary>
        public ProfileHomeGridDetail InProgressTestsGridDetail { get; set; }
        /// <summary>
        /// scheduled test grid detail
        /// </summary>
        public ProfileHomeGridDetail ScheduledTestsGridDetail { get; set; }
        /// <summary>
        /// recommended tests grid detail
        /// </summary>
        public ProfileHomeGridDetail RecommendedTestsGridDetail { get; set; }


        #region My Tests Grid Functions

        /// <summary>
        /// Initializes the My Tests Grid on the Assess Dashboard Page.
        /// </summary>
        public void InitializeMyTestsGrid()
        {
            MyTestsGridDetail.MyTestsGrid.SetGridLists();
        }

        /// <summary>
        /// Expands the My Tests Grid on the Assess Dashboard Page.
        /// </summary>
        public void ExpandMyTests()
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            MyTestsGridDetail.ExpandGrid();
        }

        /// <summary>
        /// Collapses the My Tests Grid on the Assess Dashboard Page.
        /// </summary>
        public void CollapseMyTests()
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            MyTestsGridDetail.CollapseGrid();
        }

        /// <summary>
        /// Takes you to a page which lists all the My Tests for the Logged In user.
        /// </summary>
        public void ViewAllMyTests()
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            MyTestsGridDetail.ViewAllResults();
        }

        /// <summary>
        /// Gets the Test Name for the row concerned from the My Tests Grid on the Assess Dashboard Page.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        /// <returns>Name of the Test for the Row Concerned</returns>
        public string GetMyTestName(int rowIndex)
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            var myTestsGridRow = (ProfileHomeMyTestsRow)MyTestsGridDetail.MyTestsGrid.GetRowFromList(rowIndex);
            return myTestsGridRow.GetTestName();
        }

        /// <summary>
        /// Clicks on the Test Name Link in the Row concerned from the My Tests Grid on the Assess Dashboard Page.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        public void SelectMyTestName(int rowIndex)
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            var myTestsGridRow = (ProfileHomeMyTestsRow)MyTestsGridDetail.MyTestsGrid.GetRowFromList(rowIndex);
            myTestsGridRow.SelectTestName();
        }

        /// <summary>
        /// Finds the Row containing the testName from the My Tests Grid on the Assess Dashboard Page
        /// </summary>
        /// <param name="testName"></param>
        public ProfileHomeMyTestsRow FindMyTestRow(string testName)
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            var myTestsGridRow = MyTestsGridDetail.MyTestsGrid.GetsFirstRowContainingTextToFindFromList("Test Name", testName);
            return myTestsGridRow;
        }

        /// <summary>
        /// Finds the Row containing the testName from the My Tests Grid on the Assess Dashboard Page and Clicks on the Test Name Link for that Row.
        /// </summary>
        /// <param name="testName">Test Name to be Found in the Grid</param>
        public void FindMyTestAndSelectTestName(string testName)
        {
            var myTestsGridRow = FindMyTestRow(testName);
            myTestsGridRow.SelectTestName();
        }

        #endregion

        #region Recommended Tests Grid Functions

        /// <summary>
        /// Initializes the Recommended Tests Grid on the Assess Dashboard Page.
        /// </summary>
        public void InitializeRecommendedTestsGrid()
        {
            RecommendedTestsGridDetail.RecommendedTestsGrid.SetGridLists();
        }

        /// <summary>
        /// Expands the Recommended Tests Grid on the Assess Dashboard Page.
        /// </summary>
        public void ExpandRecommendedTests()
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            RecommendedTestsGridDetail.ExpandGrid();
        }

        /// <summary>
        /// Collapses the Recommended Tests Grid on the Assess Dashboard Page.
        /// </summary>
        public void CollapseRecommendedTests()
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            RecommendedTestsGridDetail.CollapseGrid();
        }

        /// <summary>
        /// Takes you to a page which lists all the Recommended Tests for the Logged In user.
        /// </summary>
        public void ViewAllRecommendedTests()
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            RecommendedTestsGridDetail.ViewAllResults();
        }

        /// <summary>
        /// Gets the Test Name for the row concerned from the Recommended Tests Grid on the Assess Dashboard Page.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        /// <returns>Name of the Test for the Row Concerned</returns>
        public string GetRecommendedTestName(int rowIndex)
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            var recommendedTestsGridRow = (ProfileHomeRecommendedTestsRow)RecommendedTestsGridDetail.RecommendedTestsGrid.GetRowFromList(rowIndex);
            return recommendedTestsGridRow.GetTestName();
        }

        /// <summary>
        /// Clicks on the Assigmnment Status Link in the Row concerned from the Recommended Tests Grid on the Assess Dashboard Page.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        public void SelectRecommendedTestAssignmentStatus(int rowIndex)
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            var recommendedTestsGridRow = (ProfileHomeRecommendedTestsRow)RecommendedTestsGridDetail.RecommendedTestsGrid.GetRowFromList(rowIndex);
            recommendedTestsGridRow.SelectAssignmentStatus();
        }

        /// <summary>
        /// Clicks on the Test Name Link in the Row concerned from the Recommended Tests Grid on the Assess Dashboard Page.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        public void SelectRecommendedTestName(int rowIndex)
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            var recommendedTestsGridRow = (ProfileHomeRecommendedTestsRow)RecommendedTestsGridDetail.RecommendedTestsGrid.GetRowFromList(rowIndex);
            recommendedTestsGridRow.SelectTestName();
        }

        /// <summary>
        /// Finds the Row containing the testName from the Recommended Tests Grid on the Assess Dashboard Page
        /// </summary>
        /// <param name="testName"></param>
        public ProfileHomeRecommendedTestsRow FindRecommendedTestRow(string testName)
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            var recommendedTestsGridRow = RecommendedTestsGridDetail.RecommendedTestsGrid.GetsFirstRowContainingTextToFindFromList("Test Name", testName);
            return recommendedTestsGridRow;
        }

        /// <summary>
        /// Finds the Row containing the testName from the Recommended Tests Grid on the Assess Dashboard Page and Clicks on the Assignment Status Link for that Row.
        /// </summary>
        /// <param name="testName">Test Name to be Found in the Grid</param>
        public void FindRecommendedTestAndSelectAssignmentStatus(string testName)
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            var recommendedTestsGridRow = FindRecommendedTestRow(testName);
            recommendedTestsGridRow.SelectAssignmentStatus();
        }

        /// <summary>
        /// Finds the Row containing the testName from the Recommended Tests Grid on the Assess Dashboard Page and Clicks on the Test Name Link for that Row.
        /// </summary>
        /// <param name="testName">Test Name to be Found in the Grid</param>
        public void FindRecommendedTestAndSelectTestName(string testName)
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            var recommendedTestsGridRow = FindRecommendedTestRow(testName);
            recommendedTestsGridRow.SelectTestName();
        }

        #endregion

        #region In Progress Tests Grid Functions

        /// <summary>
        /// Initializes the In Progress Tests Grid on the Assess Dashboard Page.
        /// </summary>
        public void InitializeInProgressTestsGrid()
        {
            InProgressTestsGridDetail.InProgressTestsGrid.SetGridLists();
        }

        /// <summary>
        /// Expands the In Progress Tests Grid on the Assess Dashboard Page.
        /// </summary>
        public void ExpandInProgressTests()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            InProgressTestsGridDetail.ExpandGrid();
        }

        /// <summary>
        /// Collapses the In Progress Tests Grid on the Assess Dashboard Page.
        /// </summary>
        public void CollapseInProgressTests()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            InProgressTestsGridDetail.CollapseGrid();
        }

        /// <summary>
        /// Takes you to a page which lists all the InProgress Tests for the Logged In user.
        /// </summary>
        public void ViewAllInProgressTests()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            InProgressTestsGridDetail.ViewAllResults();
        }

        /// <summary>
        /// Gets the Test Name for the row concerned from the InProgress Tests Grid on the Assess Dashboard Page.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        /// <returns>Name of the Test for the Row Concerned</returns>
        public string GetInProgressTestName(int rowIndex)
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            var inProgressTestsGridRow = (ProfileHomeInProgressTestsRow)InProgressTestsGridDetail.InProgressTestsGrid.GetRowFromList(rowIndex);
            return inProgressTestsGridRow.GetTestName();
        }

        /// <summary>
        /// Clicks on the Test Name Link in the Row concerned from the InProgress Tests Grid on the Assess Dashboard Page.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        public void SelectInProgressTestName(int rowIndex)
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            var inProgressTestsGridRow = (ProfileHomeInProgressTestsRow)InProgressTestsGridDetail.InProgressTestsGrid.GetRowFromList(rowIndex);
            inProgressTestsGridRow.SelectTestName();
        }

        /// <summary>
        /// Finds the Row containing the testName from the In Progress Tests Grid on the Assess Dashboard Page
        /// </summary>
        /// <param name="testName"></param>
        public ProfileHomeInProgressTestsRow FindInProgressTestRow(string testName)
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            var inProgressTestsGridRow = InProgressTestsGridDetail.InProgressTestsGrid.GetsFirstRowContainingTextToFindFromList("Test Name", testName);
            return inProgressTestsGridRow;
        }

        /// <summary>
        /// Finds the Row containing the testName from the InProgress Tests Grid on the Assess Dashboard Page and Clicks on the Test Name Link for that Row.
        /// </summary>
        /// <param name="testName">Test Name to be Found in the Grid</param>
        public void FindInProgressTestAndSelectTestName(string testName)
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            var inProgressTestsGridRow = FindInProgressTestRow(testName);
            inProgressTestsGridRow.SelectTestName();
        }

        #endregion

        #region Scheduled Tests Grid Functions

        /// <summary>
        /// Initializes the Scheduled Tests Grid on the Assess Dashboard Page.
        /// </summary>
        public void InitializeScheduledTestsGrid()
        {
            ScheduledTestsGridDetail.ScheduledTestsGrid.SetGridLists();
        }

        /// <summary>
        /// Expands the Scheduled Tests Grid on the Assess Dashboard Page.
        /// </summary>
        public void ExpandScheduledTests()
        {
            this.Utilities.FocusOnMainContentArea();
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            ScheduledTestsGridDetail.ExpandGrid();
        }

        /// <summary>
        /// Collapses the Scheduled Tests Grid on the Assess Dashboard Page.
        /// </summary>
        public void CollapseScheduledTests()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            ScheduledTestsGridDetail.CollapseGrid();
        }

        /// <summary>
        /// Takes you to a page which lists all the Scheduled Tests for the Logged In user.
        /// </summary>
        public void ViewAllScheduledTests()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            ScheduledTestsGridDetail.ViewAllResults();
        }

        /// <summary>
        /// Gets the Test Name for the row concerned from the Scheduled Tests Grid on the Assess Dashboard Page.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        /// <returns>Name of the Test for the Row Concerned</returns>
        public string GetScheduledTestName(int rowIndex)
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            var scheduledTestsGridRow = (ProfileHomeScheduledTestsRow)ScheduledTestsGridDetail.ScheduledTestsGrid.GetRowFromList(rowIndex);
            return scheduledTestsGridRow.GetTestName();
        }

        /// <summary>
        /// Clicks on the Test Name Link in the Row concerned from the Scheduled Tests Grid on the Assess Dashboard Page.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        public void SelectScheduledTestName(int rowIndex)
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            var scheduledTestsGridRow = (ProfileHomeScheduledTestsRow)ScheduledTestsGridDetail.ScheduledTestsGrid.GetRowFromList(rowIndex);
            scheduledTestsGridRow.SelectTestName();
        }

        /// <summary>
        /// Finds the Row containing the testName from the Scheduled Tests Grid on the Assess Dashboard Page
        /// </summary>
        /// <param name="testName"></param>
        public ProfileHomeScheduledTestsRow FindScheduledTestRow(string testName)
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            var scheduledTestsGridRow = ScheduledTestsGridDetail.ScheduledTestsGrid.GetsFirstRowContainingTextToFindFromList("Test Name", testName);
            return scheduledTestsGridRow;
        }

        /// <summary>
        /// Finds the Row containing the testName from the Scheduled Tests Grid on the Assess Dashboard Page and Clicks on the Test Name Link for that Row.
        /// </summary>
        /// <param name="testName">Test Name to be Found in the Grid</param>
        public void FindScheduledTestAndSelectTestName(string testName)
        {
            var scheduledTestsGridRow = FindScheduledTestRow(testName);
            scheduledTestsGridRow.SelectTestName();
        }

        #endregion

        #region UpComing Test Windows Grid Functions

        /// <summary>
        /// Initializes the UpComing Test Windows Grid on the Assess Dashboard Page.
        /// </summary>
        public void InitializeUpComingTestWindowsGrid()
        {
            UpcomingTestWindowsGridDetail.UpcomingTestWindowsGrid.SetGridLists();
        }

        /// <summary>
        /// Expands the UpComing Test Windows Grid on the Assess Dashboard Page.
        /// </summary>
        public void ExpandUpComingTestWindows()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            UpcomingTestWindowsGridDetail.ExpandGrid();
        }

        /// <summary>
        /// Collapses the UpComing Test Windows Grid on the Assess Dashboard Page.
        /// </summary>
        public void CollapseUpComingTestWindows()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            UpcomingTestWindowsGridDetail.CollapseGrid();
        }

        /// <summary>
        /// Takes you to a page which lists all the UpComing Test Windows for the Logged In user.
        /// </summary>
        public void ViewAllUpComingTestWindows()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            UpcomingTestWindowsGridDetail.ViewAllResults();
        }

        /// <summary>
        /// Gets the Test Window Name for the row concerned from the UpComing Test Windows Grid on the Assess Dashboard Page.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        /// <returns>Name of the Test Window for the Row Concerned</returns>
        public string GetUpComingTestWindowName(int rowIndex)
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            var upComingTestWindowsGridRow = (ProfileHomeUpComingTestWindowsRow)UpcomingTestWindowsGridDetail.UpcomingTestWindowsGrid.GetRowFromList(rowIndex);
            return upComingTestWindowsGridRow.GetTestWindowName();
        }

        /// <summary>
        /// Clicks on the Test Window Name Link in the Row concerned from the UpComing Test Windows Grid on the Assess Dashboard Page.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        public void SelectUpComingTestWindowName(int rowIndex)
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            var upComingTestWindowsGridRow = (ProfileHomeUpComingTestWindowsRow)UpcomingTestWindowsGridDetail.UpcomingTestWindowsGrid.GetRowFromList(rowIndex);
            upComingTestWindowsGridRow.SelectTestWindowName();
        }

        /// <summary>
        /// Finds the Row containing the Test Window Name from the UpComing Test Windows Grid on the Assess Dashboard Page
        /// </summary>
        /// <param name="testWindowName">Test Window Name to be found</param>
        public ProfileHomeUpComingTestWindowsRow FindUpComingTestWindowRow(string testWindowName)
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            var upComingTestWindowsGridRow = UpcomingTestWindowsGridDetail.UpcomingTestWindowsGrid.GetsFirstRowContainingTextToFindFromList("Test Window Name", testWindowName);
            return upComingTestWindowsGridRow;
        }

        /// <summary>
        /// Finds the Row containing the Test Window Name from the UpComing Test Windows Grid on the Assess Dashboard Page and Clicks on the Test Window Name Link for that Row.
        /// </summary>
        /// <param name="testWindowName">Test Window Name to be found</param>
        public void FindUpComingTestWindowAndSelectTestName(string testWindowName)
        {
            var upComingTestWindowsGridRow = FindUpComingTestWindowRow(testWindowName);
            upComingTestWindowsGridRow.SelectTestWindowName();
        }

        #endregion
    }
}
