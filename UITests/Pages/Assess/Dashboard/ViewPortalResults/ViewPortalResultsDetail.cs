using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages;
using Core.Views.Grids;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Assess.Dashboard.ViewPortalResults.InProgressTests;
using UITests.Pages.Assess.Dashboard.ViewPortalResults.MyTests;
using UITests.Pages.Assess.Dashboard.ViewPortalResults.RecommendedTests;
using UITests.Pages.Assess.Dashboard.ViewPortalResults.ScheduledTests;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestCreateEdit;

namespace UITests.Pages.Assess.Dashboard.ViewPortalResults
{
    /// <summary>
    /// view portal results detail
    /// </summary>
    public class ViewPortalResultsDetail : SNDetail
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="gridName">grid name</param>
        /// <param name="overrideControlPrefix">override Control Prefix</param>
        public ViewPortalResultsDetail(ViewPortalResultsGridNames gridName, string overrideControlPrefix = null)
            : base()
        {
            GridName = gridName;
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
            CreateTestButton = new WebElementWrapper(ByCreateTestButton);
            BackToPreviousPageLink = new WebElementWrapper(ByBackToPreviousPageLink);
            InitializeViewPortalResultsGrid();
        }

        /// <summary>
        /// the data
        /// </summary>
        public new ViewPortalResultsData Data
        {
            get
            {
                return (ViewPortalResultsData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// View Portal Results Grid Name
        /// </summary>
        public ViewPortalResultsGridNames GridName { get; set; }

        protected By ByCreateTestButton { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_ButtonCreateTest"); } }
        protected WebElementWrapper CreateTestButton { get; set; }

        protected By ByBackToPreviousPageLink { get { return By.Id(ControlPrefix + "BackToPreviousPageControl_HyperLinkBack"); } }
        protected WebElementWrapper BackToPreviousPageLink { get; set; }

        private string ViewPortalMyTestResultsGridSelector { get { return "#" + ControlPrefix + "TestSearchResults1_TestFinderResults1_gridResults"; } }
        public ViewPortalMyTestResultsGrid ViewPortalMyTestResultsGrid { get; set; }

        private string ViewPortalScheduledTestResultsGridSelector { get { return "#" + ControlPrefix + "TestSearchResults1_TestFinderResults1_gridResults"; } }
        public ViewPortalScheduledTestResultsGrid ViewPortalScheduledTestResultsGrid { get; set; }

        private string ViewPortalInProgressTestResultsGridSelector { get { return "#" + ControlPrefix + "TestSearchResults1_TestFinderResults1_gridResults"; } }
        public ViewPortalInProgressTestResultsGrid ViewPortalInProgressTestResultsGrid { get; set; }

        private string ViewPortalRecommendedTestResultsGridSelector { get { return "#" + ControlPrefix + "TestSearchResults1_TestFinderResults1_gridResults"; } }
        public ViewPortalRecommendedTestResultsGrid ViewPortalRecommendedTestResultsGrid { get; set; }

        /// <summary>
        /// Clicks Create Test Button
        /// </summary>
        /// <returns></returns>
        public CreateTestPortalPage CreateATest()
        {
            //SiteTitleLabel.Wait(3).Click();//stop hover over menu
            CreateTestButton.Click();
            return new CreateTestPortalPage();
        }

        /// <summary>
        /// Clicks the Back to Previous Page link
        /// </summary>
        public void BackToPreviousPage()
        {
            BackToPreviousPageLink.Click();
        }

        #region Generic View Portal Grid Functions

        /// <summary>
        /// Initializes the View Portal Results Grid based on the GridName (ViewPortalResultsGridName)
        /// </summary>
        public void InitializeViewPortalResultsGrid()
        {
            switch (GridName)
            {
                case ViewPortalResultsGridNames.MyTests:
                    ViewPortalMyTestResultsGrid = new ViewPortalMyTestResultsGrid(ViewPortalMyTestResultsGridSelector, true, ControlPrefix);
                    break;
                case ViewPortalResultsGridNames.InProgressTests:
                    ViewPortalInProgressTestResultsGrid = new ViewPortalInProgressTestResultsGrid(ViewPortalInProgressTestResultsGridSelector, true, ControlPrefix);
                    break;
                case ViewPortalResultsGridNames.ScheduledTests:
                    ViewPortalScheduledTestResultsGrid = new ViewPortalScheduledTestResultsGrid(ViewPortalScheduledTestResultsGridSelector, true, ControlPrefix);
                    break;
                case ViewPortalResultsGridNames.RecommendedTests:
                    ViewPortalRecommendedTestResultsGrid = new ViewPortalRecommendedTestResultsGrid(ViewPortalRecommendedTestResultsGridSelector, true, ControlPrefix);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Sorts Results in the Ascending Order based on the Column Name specified
        /// </summary>
        /// <param name="columnName">Column Name Used for Sorting the Results</param>
        /// <remarks>Row Index = 1 specifies the Header Row for this Grid</remarks>
        public void SortResultsInAscendingOrderByColumnName(string columnName)
        {
            switch (GridName)
            {
                case ViewPortalResultsGridNames.MyTests:
                    ViewPortalMyTestResultsGrid.SortAscending(columnName);
                    break;
                case ViewPortalResultsGridNames.InProgressTests:
                    ViewPortalInProgressTestResultsGrid.SortAscending(columnName);
                    break;
                case ViewPortalResultsGridNames.ScheduledTests:
                    ViewPortalScheduledTestResultsGrid.SortAscending(columnName);
                    break;
                case ViewPortalResultsGridNames.RecommendedTests:
                    ViewPortalRecommendedTestResultsGrid.SortAscending(columnName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Sorts Results in the Ascending Order based on the Column Name specified
        /// </summary>
        /// <param name="columnName">Column Name Used for Sorting the Results</param>
        /// <remarks>Row Index = 1 specifies the Header Row for this Grid</remarks>
        public void SortResultsInDescendingOrderByColumnName(string columnName)
        {
            switch (GridName)
            {
                case ViewPortalResultsGridNames.MyTests:
                    ViewPortalMyTestResultsGrid.SortDescending(columnName);
                    break;
                case ViewPortalResultsGridNames.InProgressTests:
                    ViewPortalInProgressTestResultsGrid.SortDescending(columnName);
                    break;
                case ViewPortalResultsGridNames.ScheduledTests:
                    ViewPortalScheduledTestResultsGrid.SortDescending(columnName);
                    break;
                case ViewPortalResultsGridNames.RecommendedTests:
                    ViewPortalRecommendedTestResultsGrid.SortDescending(columnName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Gets the Page Results Count - Need to change return type to string after building all the View Poartal Grids
        /// </summary>
        /// <returns>string value indicating the Page Results Text</returns>
        public string GetPageResults()
        {
            switch (GridName)
            {
                case ViewPortalResultsGridNames.MyTests:
                    return ViewPortalMyTestResultsGrid.GetPageResults();
                    break;
                case ViewPortalResultsGridNames.InProgressTests:
                    return ViewPortalInProgressTestResultsGrid.GetPageResults();
                    break;
                case ViewPortalResultsGridNames.ScheduledTests:
                    return ViewPortalScheduledTestResultsGrid.GetPageResults();
                    break;
                case ViewPortalResultsGridNames.RecommendedTests:
                    return ViewPortalRecommendedTestResultsGrid.GetPageResults();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Selects the desired numbers of Results to be displayed on the Page
        /// </summary>
        /// <param name="resultsPerPage">Desired numbers of Results to be displayed</param>
        public void SelectResultsPerPage(string resultsPerPage)
        {
            switch (GridName)
            {
                case ViewPortalResultsGridNames.MyTests:
                    ViewPortalMyTestResultsGrid.SelectResultsPerPage(resultsPerPage);
                    break;
                case ViewPortalResultsGridNames.InProgressTests:
                    ViewPortalInProgressTestResultsGrid.SelectResultsPerPage(resultsPerPage);
                    break;
                case ViewPortalResultsGridNames.ScheduledTests:
                    ViewPortalScheduledTestResultsGrid.SelectResultsPerPage(resultsPerPage);
                    break;
                case ViewPortalResultsGridNames.RecommendedTests:
                    ViewPortalRecommendedTestResultsGrid.SelectResultsPerPage(resultsPerPage);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Selects the First Page Results for the Grid
        /// </summary>        
        public void SelectFirstPageResults()
        {
            switch (GridName)
            {
                case ViewPortalResultsGridNames.MyTests:
                    ViewPortalMyTestResultsGrid.ClickFirstPage();
                    break;
                case ViewPortalResultsGridNames.InProgressTests:
                    ViewPortalInProgressTestResultsGrid.ClickFirstPage();
                    break;
                case ViewPortalResultsGridNames.ScheduledTests:
                    ViewPortalScheduledTestResultsGrid.ClickFirstPage();
                    break;
                case ViewPortalResultsGridNames.RecommendedTests:
                    ViewPortalRecommendedTestResultsGrid.ClickFirstPage();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Selects the Last Page Results for the Grid
        /// </summary>        
        public void SelectLastPageResults()
        {
            switch (GridName)
            {
                case ViewPortalResultsGridNames.MyTests:
                    ViewPortalMyTestResultsGrid.ClickLastPage();
                    break;
                case ViewPortalResultsGridNames.InProgressTests:
                    ViewPortalInProgressTestResultsGrid.ClickLastPage();
                    break;
                case ViewPortalResultsGridNames.ScheduledTests:
                    ViewPortalScheduledTestResultsGrid.ClickLastPage();
                    break;
                case ViewPortalResultsGridNames.RecommendedTests:
                    ViewPortalRecommendedTestResultsGrid.ClickLastPage();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Selects the Next Page Results for the Grid
        /// </summary>        
        public void SelectNextPageResults()
        {
            switch (GridName)
            {
                case ViewPortalResultsGridNames.MyTests:
                    ViewPortalMyTestResultsGrid.ClickNextPage();
                    break;
                case ViewPortalResultsGridNames.InProgressTests:
                    ViewPortalInProgressTestResultsGrid.ClickNextPage();
                    break;
                case ViewPortalResultsGridNames.ScheduledTests:
                    ViewPortalScheduledTestResultsGrid.ClickNextPage();
                    break;
                case ViewPortalResultsGridNames.RecommendedTests:
                    ViewPortalRecommendedTestResultsGrid.ClickNextPage();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Selects the Previous Page Results for the Grid
        /// </summary>        
        public void SelectPreviousPageResults()
        {
            switch (GridName)
            {
                case ViewPortalResultsGridNames.MyTests:
                    ViewPortalMyTestResultsGrid.ClickPreviousPage();
                    break;
                case ViewPortalResultsGridNames.InProgressTests:
                    ViewPortalInProgressTestResultsGrid.ClickPreviousPage();
                    break;
                case ViewPortalResultsGridNames.ScheduledTests:
                    ViewPortalScheduledTestResultsGrid.ClickPreviousPage();
                    break;
                case ViewPortalResultsGridNames.RecommendedTests:
                    ViewPortalRecommendedTestResultsGrid.ClickPreviousPage();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Verifies if the Next Page Link is enabled or not
        /// </summary>
        /// <returns>a boolean value</returns>
        public bool IsNextPageLinkEnabled()
        {
            switch (GridName)
            {
                case ViewPortalResultsGridNames.MyTests:
                    return ViewPortalMyTestResultsGrid.IsNextPageEnabled;
                    break;
                case ViewPortalResultsGridNames.InProgressTests:
                    return ViewPortalInProgressTestResultsGrid.IsNextPageEnabled;
                    break;
                case ViewPortalResultsGridNames.ScheduledTests:
                    return ViewPortalScheduledTestResultsGrid.IsNextPageEnabled;
                    break;
                case ViewPortalResultsGridNames.RecommendedTests:
                    return ViewPortalRecommendedTestResultsGrid.IsNextPageEnabled;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Verifies if the Previous Page Link is enabled or not
        /// </summary>
        /// <returns>a boolean value</returns>
        public bool IsPreviousPageLinkEnabled()
        {
            switch (GridName)
            {
                case ViewPortalResultsGridNames.MyTests:
                    return ViewPortalMyTestResultsGrid.IsPreviousPageEnabled;
                    break;
                case ViewPortalResultsGridNames.InProgressTests:
                    return ViewPortalInProgressTestResultsGrid.IsPreviousPageEnabled;
                    break;
                case ViewPortalResultsGridNames.ScheduledTests:
                    return ViewPortalScheduledTestResultsGrid.IsPreviousPageEnabled;
                    break;
                case ViewPortalResultsGridNames.RecommendedTests:
                    return ViewPortalRecommendedTestResultsGrid.IsPreviousPageEnabled;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Verifies if the First Page Link is enabled or not
        /// </summary>
        /// <returns>a boolean value</returns>
        public bool IsFirstPageLinkEnabled()
        {
            switch (GridName)
            {
                case ViewPortalResultsGridNames.MyTests:
                    return ViewPortalMyTestResultsGrid.IsFirstPageEnabled;
                    break;
                case ViewPortalResultsGridNames.InProgressTests:
                    return ViewPortalInProgressTestResultsGrid.IsFirstPageEnabled;
                    break;
                case ViewPortalResultsGridNames.ScheduledTests:
                    return ViewPortalScheduledTestResultsGrid.IsFirstPageEnabled;
                    break;
                case ViewPortalResultsGridNames.RecommendedTests:
                    return ViewPortalRecommendedTestResultsGrid.IsFirstPageEnabled;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Verifies if the Last Page Link is enabled or not
        /// </summary>
        /// <returns>a boolean value</returns>
        public bool IsLastPageLinkEnabled()
        {
            switch (GridName)
            {
                case ViewPortalResultsGridNames.MyTests:
                    return ViewPortalMyTestResultsGrid.IsLastPageEnabled;
                    break;
                case ViewPortalResultsGridNames.InProgressTests:
                    return ViewPortalInProgressTestResultsGrid.IsLastPageEnabled;
                    break;
                case ViewPortalResultsGridNames.ScheduledTests:
                    return ViewPortalScheduledTestResultsGrid.IsLastPageEnabled;
                    break;
                case ViewPortalResultsGridNames.RecommendedTests:
                    return ViewPortalRecommendedTestResultsGrid.IsLastPageEnabled;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion

        #region View Portal My Test Results Grid Functions

        /// <summary>
        /// Gets the Test Name for the row concerned from the View Portal My Tests Results Grid.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        /// <returns>Name of the Test for the Row Concerned</returns>
        public string GetMyTestName(int rowIndex)
        {
            var viewPortalMyTestResultsRow = (ViewPortalMyTestResultsRow)ViewPortalMyTestResultsGrid.GetRowFromList(rowIndex);
            return viewPortalMyTestResultsRow.GetTestName();
        }

        /// <summary>
        /// Clicks on the Test Name Link in the Row concerned from the View Portal My Tests Results Grid.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        public void SelectMyTestName(int rowIndex)
        {
            var viewPortalMyTestResultsRow = (ViewPortalMyTestResultsRow)ViewPortalMyTestResultsGrid.GetRowFromList(rowIndex);
            viewPortalMyTestResultsRow.SelectTestName();
        }

        /// <summary>
        /// Finds the Row containing the testName from the View Portal My Tests Results Grid.
        /// </summary>
        /// <param name="testName">Test Name of the test to be found</param>
        public ViewPortalMyTestResultsRow FindMyTestRowUsingTestNameColumn(string testName)
        {
            var viewPortalMyTestResultsRow = ViewPortalMyTestResultsGrid.GetsFirstRowContainingTextToFindFromList("Test Name", testName);
            return viewPortalMyTestResultsRow;
        }

        /// <summary>
        /// Finds the Row containing the Subject from the View Portal My Tests Results Grid.
        /// </summary>
        /// <param name="subject">Subject of the test to be found</param>
        public ViewPortalMyTestResultsRow FindMyTestRowUsingSubjectColumn(string subject)
        {
            var viewPortalMyTestResultsRow = ViewPortalMyTestResultsGrid.GetsFirstRowContainingTextToFindFromList("Subject", subject);
            return viewPortalMyTestResultsRow;
        }

        /// <summary>
        /// Finds the Row containing the Grade Level from the View Portal My Tests Results Grid.
        /// </summary>
        /// <param name="gradeLevelRange">Grade Level range of the test to be found.</param>
        public ViewPortalMyTestResultsRow FindMyTestRowUsingGradeLevelColumn(string gradeLevelRange)
        {
            var viewPortalMyTestResultsRow = ViewPortalMyTestResultsGrid.GetsFirstRowContainingTextToFindFromList("Grade Level", gradeLevelRange);
            return viewPortalMyTestResultsRow;
        }

        /// <summary>
        /// Finds the Row containing the Modified Date from the View Portal My Tests Results Grid.
        /// </summary>
        /// <param name="modifiedDate">Last Modified date of the test to be found.</param>
        public ViewPortalMyTestResultsRow FindMyTestRowUsingModifiedDateColumn(string modifiedDate)
        {
            var viewPortalMyTestResultsRow = ViewPortalMyTestResultsGrid.GetsFirstRowContainingTextToFindFromList("Modified Date", modifiedDate);
            return viewPortalMyTestResultsRow;
        }

        /// <summary>
        /// Finds the Row containing the testName from the View Portal My Tests Results Grid. and Clicks on the Test Name Link for that Row.
        /// </summary>
        /// <param name="testName">Test Name to be Found in the Grid</param>
        public void FindMyTestAndSelectTestName(string testName)
        {
            var viewPortalMyTestResultsRow = FindMyTestRowUsingTestNameColumn(testName);
            //viewPortalMyTestResultsRow.SelectTestName();
            viewPortalMyTestResultsRow.TestName();
        }

        #endregion

        #region View Portal InProgress Test Results Grid Functions

        /// <summary>
        /// Gets the Test Name for the row concerned from the View Portal InProgress Tests Results Grid.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        /// <returns>Name of the Test for the Row Concerned</returns>
        public string GetInProgressTestName(int rowIndex)
        {
            var viewPortalInProgressTestResultsRow = (ViewPortalInProgressTestResultsRow)ViewPortalInProgressTestResultsGrid.GetRowFromList(rowIndex);
            return viewPortalInProgressTestResultsRow.GetTestName();
        }

        /// <summary>
        /// Gets the number of data rows from the View Portal InProgress Tests Results Grid. This does 
        /// not include header row and pagination row.
        /// </summary>        
        /// <returns>Total number of data rows on the grid</returns>
        public int GetInProgressTotalRowCount()
        {
            int allRowsCount = ViewPortalInProgressTestResultsGrid.GetRowList().Count;
            int dataRowCount = 0;
            SNGridRow row;
            for (int i = 0; i < allRowsCount; i++)
            {
                row = ViewPortalInProgressTestResultsGrid.GetRowFromList(i);
                if (row.Type == GridRowType.Data) dataRowCount++;
            }
            return dataRowCount;
        }

        /// <summary>
        /// Clicks on the Test Name Link in the Row concerned from the View Portal InProgress Tests Results Grid.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        public void SelectInProgressTestName(int rowIndex)
        {
            var viewPortalInProgressTestResultsRow = (ViewPortalInProgressTestResultsRow)ViewPortalInProgressTestResultsGrid.GetRowFromList(rowIndex);
            viewPortalInProgressTestResultsRow.SelectTestName();
        }

        /// <summary>
        /// Finds the Row containing the testName from the View Portal InProgress Tests Results Grid.
        /// </summary>
        /// <param name="testName">test name of the test to be found</param>
        public ViewPortalInProgressTestResultsRow FindInProgressTestRowUsingTestNameColumn(string testName)
        {
            var viewPortalInProgressTestResultsRow = ViewPortalInProgressTestResultsGrid.GetsFirstRowContainingTextToFindFromList("Test Name", testName);
            return viewPortalInProgressTestResultsRow;
        }

        /// <summary>
        /// Finds the Row containing the Subject from the View Portal InProgress Tests Results Grid.
        /// </summary>
        /// <param name="subject">subject of the test to be found</param>
        public ViewPortalInProgressTestResultsRow FindInProgressTestRowUsingSubjectColumn(string subject)
        {
            var viewPortalInProgressTestResultsRow = ViewPortalInProgressTestResultsGrid.GetsFirstRowContainingTextToFindFromList("Subject", subject);
            return viewPortalInProgressTestResultsRow;
        }

        /// <summary>
        /// Finds the Row containing the Grade Level from the View Portal InProgress Tests Results Grid.
        /// </summary>
        /// <param name="gradeLevelRange">grade level range of the test to be found</param>
        public ViewPortalInProgressTestResultsRow FindInProgressTestRowUsingGradeLevelColumn(string gradeLevelRange)
        {
            var viewPortalInProgressTestResultsRow = ViewPortalInProgressTestResultsGrid.GetsFirstRowContainingTextToFindFromList("Grade Level", gradeLevelRange);
            return viewPortalInProgressTestResultsRow;
        }

        /// <summary>
        /// Finds the Row containing the Collection Status from the View Portal InProgress Tests Results Grid.
        /// </summary>
        /// <param name="collectionStatus">collection status of the test to be found</param>
        public ViewPortalInProgressTestResultsRow FindInProgressTestRowUsingCollectionStatusColumn(string collectionStatus)
        {
            var viewPortalInProgressTestResultsRow = ViewPortalInProgressTestResultsGrid.GetsFirstRowContainingTextToFindFromList("Collection Status", collectionStatus);
            return viewPortalInProgressTestResultsRow;
        }

        /// <summary>
        /// Finds the Row containing the End Date from the View Portal InProgress Tests Results Grid.
        /// </summary>
        /// <param name="endDate">end date of the test to be found</param>
        public ViewPortalInProgressTestResultsRow FindInProgressTestRowUsingEndDateColumn(string endDate)
        {
            var viewPortalInProgressTestResultsRow = ViewPortalInProgressTestResultsGrid.GetsFirstRowContainingTextToFindFromList("End Date", endDate);
            return viewPortalInProgressTestResultsRow;
        }

        /// <summary>
        /// Finds the Row containing the testName from the View Portal InProgress Tests Results Grid. and Clicks on the Test Name Link for that Row.
        /// </summary>
        /// <param name="testName">Test Name to be Found in the Grid</param>
        public void FindInProgressTestAndSelectTestName(string testName)
        {
            var viewPortalInProgressTestResultsRow = FindInProgressTestRowUsingTestNameColumn(testName);
            //viewPortalInProgressTestResultsRow.SelectTestName();
            viewPortalInProgressTestResultsRow.TestName();
        }

        #endregion

        #region View Portal Scheduled Test Results Grid Functions

        /// <summary>
        /// Gets the Test Name for the row concerned from the View Portal Scheduled Tests Results Grid.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        /// <returns>Name of the Test for the Row Concerned</returns>
        public string GetScheduledTestName(int rowIndex)
        {
            var viewPortalScheduledTestResultsRow = (ViewPortalScheduledTestResultsRow)ViewPortalScheduledTestResultsGrid.GetRowFromList(rowIndex);
            return viewPortalScheduledTestResultsRow.GetTestName();
        }

        /// <summary>
        /// Clicks on the Test Name Link in the Row concerned from the View Portal Scheduled Tests Results Grid.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        public void SelectScheduledTestName(int rowIndex)
        {
            var viewPortalScheduledTestResultsRow = (ViewPortalScheduledTestResultsRow)ViewPortalScheduledTestResultsGrid.GetRowFromList(rowIndex);
            viewPortalScheduledTestResultsRow.SelectTestName();
        }

        /// <summary>
        /// Finds the Row containing the testName from the View Portal Scheduled Tests Results Grid.
        /// </summary>
        /// <param name="testName">test name of the test to be found</param>
        public ViewPortalScheduledTestResultsRow FindScheduledTestRowUsingTestNameColumn(string testName)
        {
            var viewPortalScheduledTestResultsRow = ViewPortalScheduledTestResultsGrid.GetsFirstRowContainingTextToFindFromList("Test Name", testName);
            return viewPortalScheduledTestResultsRow;
        }

        /// <summary>
        /// Finds the Row containing the subject from the View Portal Scheduled Tests Results Grid.
        /// </summary>
        /// <param name="subject">subject of the test to be found</param>
        public ViewPortalScheduledTestResultsRow FindScheduledTestRowUsingSubjectColumn(string subject)
        {
            var viewPortalScheduledTestResultsRow = ViewPortalScheduledTestResultsGrid.GetsFirstRowContainingTextToFindFromList("Subject", subject);
            return viewPortalScheduledTestResultsRow;
        }

        /// <summary>
        /// Finds the Row containing the grade level range from the View Portal Scheduled Tests Results Grid.
        /// </summary>
        /// <param name="gradeLevelRange">grade level range of the test to be found</param>
        public ViewPortalScheduledTestResultsRow FindScheduledTestRowUsingGradeLevelColumn(string gradeLevelRange)
        {
            var viewPortalScheduledTestResultsRow = ViewPortalScheduledTestResultsGrid.GetsFirstRowContainingTextToFindFromList("Grade Level", gradeLevelRange);
            return viewPortalScheduledTestResultsRow;
        }

        /// <summary>
        /// Finds the Row containing the testName from the View Portal Scheduled Tests Results Grid. and Clicks on the Test Name Link for that Row.
        /// </summary>
        /// <param name="testName">Test Name to be Found in the Grid</param>
        public void FindScheduledTestAndSelectTestName(string testName)
        {
            var viewPortalScheduledTestResultsRow = FindScheduledTestRowUsingTestNameColumn(testName);
            //viewPortalScheduledTestResultsRow.SelectTestName();
            viewPortalScheduledTestResultsRow.TestName();
        }

        #endregion

        #region View Portal Recommended Test Results Grid Functions

        /// <summary>
        /// Gets the Test Name for the row concerned from the View Portal Recommended Tests Results Grid.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        /// <returns>Name of the Test for the Row Concerned</returns>
        public string GetRecommendedTestName(int rowIndex)
        {
            var viewPortalRecommendedTestResultsRow = (ViewPortalRecommendedTestResultsRow)ViewPortalRecommendedTestResultsGrid.GetRowFromList(rowIndex);
            return viewPortalRecommendedTestResultsRow.GetTestName();
        }

        /// <summary>
        /// Clicks on the Test Name Link in the Row concerned from the View Portal Recommended Tests Results Grid.
        /// </summary>
        /// <param name="rowIndex">Index of the Row concerned</param>
        public void SelectRecommendedTestName(int rowIndex)
        {
            var viewPortalRecommendedTestResultsRow = (ViewPortalRecommendedTestResultsRow)ViewPortalRecommendedTestResultsGrid.GetRowFromList(rowIndex);
            viewPortalRecommendedTestResultsRow.SelectTestName();
        }

        /// <summary>
        /// Finds the Row containing the testName from the View Portal Recommended Tests Results Grid.
        /// </summary>
        /// <param name="testName">test name of the test to be found</param>
        public ViewPortalRecommendedTestResultsRow FindRecommendedTestRowUsingTestNameColumn(string testName)
        {
            if (Driver.GetType() == typeof(DummyDriver))
            {
                ViewPortalRecommendedTestResultsGrid.GetRowFromList(3).FakeText = testName;
            }
            var viewPortalRecommendedTestResultsRow = ViewPortalRecommendedTestResultsGrid.GetsFirstRowContainingTextToFindFromList("Test Name", testName);
            return viewPortalRecommendedTestResultsRow;
        }

        /// <summary>
        /// Finds the Row containing the subject from the View Portal Recommended Tests Results Grid.
        /// </summary>
        /// <param name="subject">subject of the test to be found</param>
        public ViewPortalRecommendedTestResultsRow FindRecommendedTestRowUsingSubjectColumn(string subject)
        {
            var viewPortalRecommendedTestResultsRow = ViewPortalRecommendedTestResultsGrid.GetsFirstRowContainingTextToFindFromList("Subject", subject);
            return viewPortalRecommendedTestResultsRow;
        }

        /// <summary>
        /// Finds the Row containing the grade level range from the View Portal Recommended Tests Results Grid.
        /// </summary>
        /// <param name="gradeLevelRange">grade level range of the test to be found</param>
        public ViewPortalRecommendedTestResultsRow FindRecommendedTestRowUsingGradeLevelColumn(string gradeLevelRange)
        {
            var viewPortalRecommendedTestResultsRow = ViewPortalRecommendedTestResultsGrid.GetsFirstRowContainingTextToFindFromList("Grade Level", gradeLevelRange);
            return viewPortalRecommendedTestResultsRow;
        }

        /// <summary>
        /// Finds the Row containing the testName from the View Portal Recommended Tests Results Grid and Clicks on the Test Name Link for that Row.
        /// </summary>
        /// <param name="testName">Test Name to be Found in the Grid</param>
        public void FindRecommendedTestAndSelectTestName(string testName)
        {
            var viewPortalRecommendedTestResultsRow = FindRecommendedTestRowUsingTestNameColumn(testName);
            //viewPortalRecommendedTestResultsRow.SelectTestName();
            viewPortalRecommendedTestResultsRow.TestName();
        }

        /// <summary>
        /// Gets the List of Rows having the 'Assigned' Status from the View Portal Recommended Tests Results Grid (in displayed results only).
        /// </summary>        
        public List<ViewPortalRecommendedTestResultsRow> FindRecommendedTestRowsWithAssignedStatus()
        {
            var viewPortalRecommendedTestResultsRowList = ViewPortalRecommendedTestResultsGrid.GetsRowsContainingTextToFindFromList("Assignment Status", "Assigned");
            return viewPortalRecommendedTestResultsRowList;
        }

        /// <summary>
        /// Gets the List of Rows having the 'Not Assigned' Status from the View Portal Recommended Tests Results Grid (in displayed results only).
        /// </summary>        
        public List<ViewPortalRecommendedTestResultsRow> FindRecommendedTestRowsWithNotAssignedStatus()
        {
            var viewPortalRecommendedTestResultsRowList = ViewPortalRecommendedTestResultsGrid.GetsRowsContainingTextToFindFromList("Assignment Status", "Not Assigned");
            return viewPortalRecommendedTestResultsRowList;
        }

        /// <summary>
        /// Finds the Row containing the 'testName' and also having the 'Assigned' Status from the View Portal Recommended Tests Results Grid.
        /// </summary>
        /// <param name="testName"></param>
        public ViewPortalRecommendedTestResultsRow FindRecommendedTestRowWithAssignedStatus(string testName)
        {
            var viewPortalRecommendedTestResultsRowList = FindRecommendedTestRowsWithAssignedStatus();

            return viewPortalRecommendedTestResultsRowList.FirstOrDefault(viewPortalRecommendedTestResultsRow => viewPortalRecommendedTestResultsRow.GetTestName() == testName);
        }

        /// <summary>
        /// Finds the Row containing the 'testName' and also having the 'Not Assigned' Status from the View Portal Recommended Tests Results Grid.
        /// </summary>
        /// <param name="testName"></param>
        public ViewPortalRecommendedTestResultsRow FindRecommendedTestRowWithNotAssignedStatus(string testName)
        {
            var viewPortalRecommendedTestResultsRowList = FindRecommendedTestRowsWithNotAssignedStatus();

            return viewPortalRecommendedTestResultsRowList.FirstOrDefault(viewPortalRecommendedTestResultsRow => viewPortalRecommendedTestResultsRow.GetTestName() == testName);
        }

        /// <summary>
        /// Finds the Row containing the 'testName' and also having the 'Assigned' Status from the View Portal Recommended Tests Results Grid and Clicks on the 'Assigned' Link for that Row.
        /// </summary>
        /// <param name="testName"></param>
        public void FindRecommendedTestRowWithAssignedStatusAndSelectAssignedLink(string testName)
        {
            var viewPortalRecommendedTestResultsRow = FindRecommendedTestRowWithAssignedStatus(testName);
            viewPortalRecommendedTestResultsRow.SelectTestAssignmentStatus();
        }

        /// <summary>
        /// Finds the Row containing the 'testName' and also having the 'Not Assigned' Status from the View Portal Recommended Tests Results Grid and Clicks on the 'Not Assigned' Link for that Row.
        /// </summary>
        /// <param name="testName"></param>
        public void FindRecommendedTestRowWithNotAssignedStatusAndSelectNotAssignedLink(string testName)
        {
            var viewPortalRecommendedTestResultsRow = FindRecommendedTestRowWithNotAssignedStatus(testName);
            viewPortalRecommendedTestResultsRow.SelectTestAssignmentStatus();
        }

        #endregion
    }
}
