using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Dashboard.ViewPortalResults.RecommendedTests
{
    /// <summary>
    /// represents the View Portal Recommended Test Results Grid Row
    /// </summary>
    public class ViewPortalRecommendedTestResultsRow : SNGridRow
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="type">type of the Row</param>
        /// <param name="columns">the list of columns</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewPortalRecommendedTestResultsRow(string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base(gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
        }

        /// <summary>
        /// Initializes the Elements for this Class
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Row text: " + Element.Text);

            TestNameLink = new WebElementWrapper(ByTestNameLink);
            TestCategory = new WebElementWrapper(ByTestCategory);
            Subject = new WebElementWrapper(BySubject);
            GradeLevel = new WebElementWrapper(ByGradeLevel);
            StartDate = new WebElementWrapper(ByStartDate);
            EndDate = new WebElementWrapper(ByEndDate);
            ScoresDueDate = new WebElementWrapper(ByScoresDueDate);
            AssignmentStatusLink = new WebElementWrapper(ByAssignmentStatusLink);

            if (Driver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private By ByTestNameLink { get { return GetColumnLinkLocator(ViewPortalRecommendedTestResultsColumnNames.TestName); } }
        private WebElementWrapper TestNameLink { get; set; }

        private By ByTestCategory { get { return GetColumnLinkLocator(ViewPortalRecommendedTestResultsColumnNames.TestCategory); } }
        private WebElementWrapper TestCategory { get; set; }

        private By BySubject { get { return GetColumnLocator(ViewPortalRecommendedTestResultsColumnNames.Subject); } }
        private WebElementWrapper Subject { get; set; }

        private By ByGradeLevel { get { return GetColumnLocator(ViewPortalRecommendedTestResultsColumnNames.GradeLevel); } }
        private WebElementWrapper GradeLevel { get; set; }

        private By ByStartDate { get { return GetColumnLocator(ViewPortalRecommendedTestResultsColumnNames.StartDate); } }
        private WebElementWrapper StartDate { get; set; }

        private By ByEndDate { get { return GetColumnLocator(ViewPortalRecommendedTestResultsColumnNames.EndDate); } }
        private WebElementWrapper EndDate { get; set; }

        private By ByScoresDueDate { get { return GetColumnLocator(ViewPortalRecommendedTestResultsColumnNames.ScoresDueDate); } }
        private WebElementWrapper ScoresDueDate { get; set; }

        private By ByAssignmentStatusLink { get { return GetColumnLocator(ViewPortalRecommendedTestResultsColumnNames.AssignmentStatus); } }
        private WebElementWrapper AssignmentStatusLink { get; set; }

        /// <summary>
        /// Gets the Test Name
        /// </summary>
        /// <returns>text</returns>
        public string GetTestName()
        {
            TestNameLink.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                TestNameLink.Text = FakeText;
            }
            return TestNameLink.Text.Trim();
        }

        /// <summary>
        /// Gets the Test Category
        /// </summary>
        /// <returns>text</returns>
        public string GetTestCategory()
        {
            TestCategory.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                TestCategory.Text = FakeText;
            }
            return TestCategory.Text.Trim();
        }

        /// <summary>
        /// Gets the Test Subject
        /// </summary>
        /// <returns>text</returns>
        public string GetTestSubject()
        {
            Subject.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                Subject.Text = FakeText;
            }
            return Subject.Text.Trim();
        }

        /// <summary>
        /// Gets the Test Grade Level
        /// </summary>
        /// <returns>text</returns>
        public string GetTestGradeLevel()
        {
            GradeLevel.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                GradeLevel.Text = FakeText;
            }
            return GradeLevel.Text.Trim();
        }

        /// <summary>
        /// Gets the Start Date of the Test
        /// </summary>
        /// <returns></returns>
        public string GetTestStartDate()
        {
            StartDate.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                StartDate.Text = FakeText;
            }
            return StartDate.Text.Trim();
        }

        /// <summary>
        /// Gets the End Date of the Test
        /// </summary>
        /// <returns></returns>
        public string GetTestEndDate()
        {
            EndDate.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                EndDate.Text = FakeText;
            }
            return EndDate.Text.Trim();
        }

        /// <summary>
        /// Gets the Scores Due Date of the Test
        /// </summary>
        /// <returns></returns>
        public string GetTestScoresDueDate()
        {
            ScoresDueDate.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                ScoresDueDate.Text = FakeText;
            }
            return ScoresDueDate.Text.Trim();
        }

        /// <summary>
        /// Gets the Assignment Status of the Test
        /// </summary>
        /// <returns></returns>
        public string GetTestAssignmentStatus()
        {
            AssignmentStatusLink.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                AssignmentStatusLink.Text = FakeText;
            }
            return AssignmentStatusLink.Text.Trim();
        }

        /// <summary>
        /// Clicks on the Test Name Link for the Row
        /// </summary>
        public void TestName()
        {
            TestNameLink.Wait(2).Click();
        }

        /// <summary>
        /// Clicks on the Assignment Status Link for the Row
        /// </summary>
        public void SelectTestAssignmentStatus()
        {
            AssignmentStatusLink.Wait(2).Click();
        }
    }
}
