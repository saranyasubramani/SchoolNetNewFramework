using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Dashboard.ProfileHome.Tabs
{
    /// <summary>
    /// represents the assess dashboard - search results grid row.
    /// </summary>
    public class ProfileHomeTabRow : SNGridRow
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="columns">the list of columns</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ProfileHomeTabRow(string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base(gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
        }

        public override void InitElements()
        {
            Report.Write("Row text: " + Element.Text);
            base.InitElements();
            //TestNameElement = new WebElementWrapper(ByTestNameElement);
            TestCategoryElement = new WebElementWrapper(ByTestCategoryElement);
            OnlinePasscodeElement = new WebElementWrapper(ByOnlinePasscodeElement);
            AssignedElement = new WebElementWrapper(ByAssignedElement);
            StageElement = new WebElementWrapper(ByStageElement);
            StartDateElement = new WebElementWrapper(ByStartDateElement);
            SubjectElement = new WebElementWrapper(BySubjectElement);
            GradeElement = new WebElementWrapper(ByGradeElement);
            CollectionStatusElement = new WebElementWrapper(ByCollectionStatusElement);
            CollectionStatusLink = new WebElementWrapper(ByCollectionStatusLink);
            GradebookUpdatedElement = new WebElementWrapper(ByGradebookUpdatedElement);
            GradebookUpdatedShareLink = new WebElementWrapper(ByGradebookUpdatedShareLink);
            GradebookUpdatedStopSharingLink = new WebElementWrapper(ByGradebookUpdatedStopSharingLink);
            StudentPerformanceElement = new WebElementWrapper(ByStudentPerformanceElement);
            //ActionsButton = new WebElementWrapper(ByActionsButton);
            ScoreLink = new WebElementWrapper(ByScoreLink);
            DownloadPDFLink = new WebElementWrapper(ByDownloadPDFLink);
            GenerateAnswerSheetsLink = new WebElementWrapper(ByGenerateAnswerSheetsLink);
            ViewUsernamesLink = new WebElementWrapper(ByViewUsernamesLink);
            TrackStudentAccommodationsLink = new WebElementWrapper(ByTrackStudentAccommodationsLink);
            ProctorDashboardLink = new WebElementWrapper(ByProctorDashboardLink);

            if (Driver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private By ByTestCategoryElement { get { return GetColumnLocator(ProfileHomeTabColumnNames.TestCategory); } }
        private WebElementWrapper TestCategoryElement { get; set; }
        private By ByOnlinePasscodeElement { get { return GetColumnLocator(ProfileHomeTabColumnNames.OnlinePasscode); } }
        private WebElementWrapper OnlinePasscodeElement { get; set; }
        private By ByAssignedElement { get { return GetColumnLinkLocator(ProfileHomeTabColumnNames.Assigned); } }
        private WebElementWrapper AssignedElement { get; set; }
        private By ByStageElement { get { return GetColumnLocator(ProfileHomeTabColumnNames.Stage); } }
        private WebElementWrapper StageElement { get; set; }
        private By ByStartDateElement { get { return GetColumnLocator(ProfileHomeTabColumnNames.StartDate); } }
        private WebElementWrapper StartDateElement { get; set; }
        private By BySubjectElement { get { return GetColumnLocator(ProfileHomeTabColumnNames.Subject); } }
        private WebElementWrapper SubjectElement { get; set; }
        private By ByGradeElement { get { return GetColumnLocator(ProfileHomeTabColumnNames.Grade); } }
        private WebElementWrapper GradeElement { get; set; }
        private By ByCollectionStatusElement { get { return GetColumnLocator(ProfileHomeTabColumnNames.CollectionStatus); } }
        private WebElementWrapper CollectionStatusElement { get; set; }
        private By ByCollectionStatusLink { get { return GetColumnLinkLocator(ProfileHomeTabColumnNames.CollectionStatus); } }
        private WebElementWrapper CollectionStatusLink { get; set; }
        private By ByGradebookUpdatedElement { get { return GetColumnLocator(ProfileHomeTabColumnNames.GradebookUpdated); } }
        private WebElementWrapper GradebookUpdatedElement { get; set; }
        private By ByGradebookUpdatedShareLink { get { return GetGradebookUpdatedShareLocator(ProfileHomeTabColumnNames.GradebookUpdated); } }
        private WebElementWrapper GradebookUpdatedShareLink { get; set; }
        private By ByGradebookUpdatedStopSharingLink { get { return GetGradebookUpdatedStopSharingLocator(ProfileHomeTabColumnNames.GradebookUpdated); } }
        private WebElementWrapper GradebookUpdatedStopSharingLink { get; set; }
        private By ByStudentPerformanceElement { get { return GetColumnLocator(ProfileHomeTabColumnNames.StudentPerformance); } }
        private WebElementWrapper StudentPerformanceElement { get; set; }
        private By ByScoreLink { get { return GetColumnLocator(ProfileHomeTabColumnNames.Actions); } }
        private WebElementWrapper ScoreLink { get; set; }
        private By ByDownloadPDFLink { get { return GetColumnLocator(ProfileHomeTabColumnNames.Actions); } }
        private WebElementWrapper DownloadPDFLink { get; set; }
        private By ByGenerateAnswerSheetsLink { get { return GetColumnLocator(ProfileHomeTabColumnNames.Actions); } }
        private WebElementWrapper GenerateAnswerSheetsLink { get; set; }
        private By ByViewUsernamesLink { get { return GetColumnLocator(ProfileHomeTabColumnNames.Actions); } }
        private WebElementWrapper ViewUsernamesLink { get; set; }
        private By ByTrackStudentAccommodationsLink { get { return GetColumnLocator(ProfileHomeTabColumnNames.Actions); } }
        private WebElementWrapper TrackStudentAccommodationsLink { get; set; }
        private By ByProctorDashboardLink { get { return GetColumnLocator(ProfileHomeTabColumnNames.Actions); } }
        private WebElementWrapper ProctorDashboardLink { get; set; }

        private By GetGradebookUpdatedShareLocator(string columnName)
        {
            By by = null;
            foreach (var column in Columns)
            {
                if (column.Name.Equals(columnName))
                {
                    string tag = "td";
                    if (Type.Equals(GridRowType.Header))
                    {
                        tag = "th";
                    }
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > " + tag + ":nth-of-type(" + (column.Index + 1) + ") a:nth-of-type(1)");
                    break;
                }
            }
            return by;
        }
        private By GetGradebookUpdatedStopSharingLocator(string columnName)
        {
            By by = null;
            foreach (var column in Columns)
            {
                if (column.Name.Equals(columnName))
                {
                    string tag = "td";
                    if (Type.Equals(GridRowType.Header))
                    {
                        tag = "th";
                    }
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > " + tag + ":nth-of-type(" + (column.Index + 1) + ") a:nth-of-type(2)");
                    break;
                }
            }
            return by;
        }

        /// <summary>
        /// select the Test Category
        /// </summary>
        public void SelectTestCategory()
        {
            TestCategoryElement.Wait(3).Click();
        }
        /// <summary>
        /// get the Test Category text
        /// </summary>
        /// <returns>text</returns>
        public string GetTestCategory()
        {
            TestCategoryElement.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                TestCategoryElement.Text = FakeText;
            }
            return TestCategoryElement.Text;
        }
        /// <summary>
        /// select the Online Passcode
        /// </summary>
        public void SelectOnlinePasscode()
        {
            OnlinePasscodeElement.Wait(3).Click();
        }
        /// <summary>
        /// get the Online Passcode text
        /// </summary>
        /// <returns>text</returns>
        public string GetOnlinePasscode()
        {
            OnlinePasscodeElement.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                OnlinePasscodeElement.Text = FakeText;
            }
            return OnlinePasscodeElement.Text;
        }
        /// <summary>
        /// select the assigned link
        /// </summary>
        public void SelectAssigned()
        {
            AssignedElement.Wait(3).Click();
        }
        /// <summary>
        /// get the assigned text
        /// </summary>
        /// <returns>text</returns>
        public string GetAssigned()
        {
            AssignedElement.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                AssignedElement.Text = FakeText;
            }
            return AssignedElement.Text;
        }
        /// <summary>
        /// select the stage link
        /// </summary>
        public void SelectStage()
        {
            StageElement.Wait(3).Click();
        }
        /// <summary>
        /// get the stage text
        /// </summary>
        /// <returns>text</returns>
        public string GetStage()
        {
            StageElement.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                StageElement.Text = FakeText;
            }
            return StageElement.Text;
        }
        /// <summary>
        /// select the Start Date link
        /// </summary>
        public void SelectStartDate()
        {
            StartDateElement.Wait(3).Click();
        }
        /// <summary>
        /// get the Start Date text
        /// </summary>
        /// <returns>text</returns>
        public string GetStartDate()
        {
            StartDateElement.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                StartDateElement.Text = FakeText;
            }
            return StartDateElement.Text;
        }
        /// <summary>
        /// select the Subject link
        /// </summary>
        public void SelectSubject()
        {
            SubjectElement.Wait(3).Click();
        }
        /// <summary>
        /// get the Subject text
        /// </summary>
        /// <returns>text</returns>
        public string GetSubject()
        {
            SubjectElement.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                SubjectElement.Text = FakeText;
            }
            return SubjectElement.Text;
        }
        /// <summary>
        /// select the Grade link
        /// </summary>
        public void SelectGrade()
        {
            GradeElement.Wait(3).Click();
        }
        /// <summary>
        /// get the Grade text
        /// </summary>
        /// <returns>text</returns>
        public string GetGrade()
        {
            GradeElement.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                GradeElement.Text = FakeText;
            }
            return GradeElement.Text;
        }
        /// <summary>
        /// select the Collection Status link
        /// </summary>
        public void SelectCollectionStatus()
        {
            CollectionStatusLink.Wait(3).Click();
        }
        /// <summary>
        /// get the Collection Status text
        /// </summary>
        /// <returns>text</returns>
        public string GetCollectionStatus()
        {
            CollectionStatusElement.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                CollectionStatusElement.Text = FakeText;
            }
            return CollectionStatusElement.Text;
        }
        /// <summary>
        /// select the Gradebook Updated link
        /// </summary>
        public void SelectGradebookUpdatedShare()
        {
            GradebookUpdatedShareLink.Wait(3).Click();
        }
        /// <summary>
        /// select the Gradebook Updated link
        /// </summary>
        public void SelectGradebookUpdatedStopSharing()
        {
            GradebookUpdatedStopSharingLink.Wait(3).Click();
        }
        /// <summary>
        /// get the Gradebook Updated text
        /// </summary>
        /// <returns>text</returns>
        public string GetGradebookUpdated()
        {
            GradebookUpdatedElement.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                GradebookUpdatedElement.Text = FakeText;
            }
            return GradebookUpdatedElement.Text;
        }
        /// <summary>
        /// select the Student Performance link
        /// </summary>
        public void SelectStudentPerformance()
        {
            StudentPerformanceElement.Wait(3).Click();
        }
        /// <summary>
        /// get the Student Performance text
        /// </summary>
        /// <returns>text</returns>
        public string GetStudentPerformance()
        {
            StudentPerformanceElement.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                StudentPerformanceElement.Text = FakeText;
            }
            return StudentPerformanceElement.Text;
        }

        /// <summary>
        /// select actions, then select score
        /// </summary>
        public void SelectScore()
        {
            SelectActions();
            ScoreLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
        }
        /// <summary>
        /// select actions, then select download PDF
        /// </summary>
        public void SelectDownloadPDF()
        {
            SelectActions();
            DownloadPDFLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
        }
        /// <summary>
        /// select actions, then select GenerateAnswerSheets
        /// </summary>
        public void SelectGenerateAnswerSheets()
        {
            SelectActions();
            GenerateAnswerSheetsLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
        }
        /// <summary>
        /// select actions, then select ViewUsernames
        /// </summary>
        public void SelectViewUsernames()
        {
            SelectActions();
            ViewUsernamesLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
        }
        /// <summary>
        /// select actions, then select TrackStudentAccommodations
        /// </summary>
        public void SelectTrackStudentAccommodations()
        {
            SelectActions();
            TrackStudentAccommodationsLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
        }
        /// <summary>
        /// select actions, then select ProctorDashboard
        /// </summary>
        public void SelectProctorDashboard()
        {
            SelectActions();
            ProctorDashboardLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
        }
    }
}
