using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Dashboard.ViewPortalResults.InProgressTests
{
    /// <summary>
    /// represents the View Portal InProgress Test Results Grid Row
    /// </summary>
    public class ViewPortalInProgressTestResultsRow : SNGridRow
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
        public ViewPortalInProgressTestResultsRow(string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
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
            Subject = new WebElementWrapper(BySubject);
            GradeLevel = new WebElementWrapper(ByGradeLevel);
            TestStage = new WebElementWrapper(ByTestStage);
            EndDate = new WebElementWrapper(ByEndDate);
            ScoresDueDate = new WebElementWrapper(ByScoresDueDate);
            CollectionStatus = new WebElementWrapper(ByCollectionStatus);

            if (Driver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private By ByTestNameLink { get { return GetColumnLinkLocator(ViewPortalInProgressTestResultsColumnNames.TestName); } }
        private WebElementWrapper TestNameLink { get; set; }

        private By BySubject { get { return GetColumnLocator(ViewPortalInProgressTestResultsColumnNames.Subject); } }
        private WebElementWrapper Subject { get; set; }

        private By ByGradeLevel { get { return GetColumnLocator(ViewPortalInProgressTestResultsColumnNames.GradeLevel); } }
        private WebElementWrapper GradeLevel { get; set; }

        private By ByTestStage { get { return GetColumnLocator(ViewPortalInProgressTestResultsColumnNames.TestStage); } }
        private WebElementWrapper TestStage { get; set; }

        private By ByEndDate { get { return GetColumnLocator(ViewPortalInProgressTestResultsColumnNames.EndDate); } }
        private WebElementWrapper EndDate { get; set; }

        private By ByScoresDueDate { get { return GetColumnLocator(ViewPortalInProgressTestResultsColumnNames.ScoresDueDate); } }
        private WebElementWrapper ScoresDueDate { get; set; }

        //private By ByCollectionStatus { get { return GetColumnLinkLocator(ViewPortalInProgressTestResultsColumnNames.CollectionStatus); } }
        //private WebElementWrapper CollectionStatus { get; set; }

        private By ByCollectionStatus { get { return GetColumnLocator(ViewPortalInProgressTestResultsColumnNames.CollectionStatus); } }
        private WebElementWrapper CollectionStatus { get; set; }

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
        /// Gets the Test Stage of the Test
        /// </summary>
        /// <returns></returns>
        public string GetTestStage()
        {
            TestStage.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                TestStage.Text = FakeText;
            }
            return TestStage.Text.Trim();
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
        /// Gets the Collection Status of the Test
        /// </summary>
        /// <returns></returns>
        public string GetTestCollectionStatus()
        {
            CollectionStatus.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                CollectionStatus.Text = FakeText;
            }
            return CollectionStatus.Text.Trim();
        }

        /// <summary>
        /// Clicks on the Test Name Link for the Row
        /// </summary>
        public void TestName()
        {
            TestNameLink.Wait(2).Click();
        }

        /// <summary>
        /// Clicks on the Collection Status Link for the Row. 
        /// This is a very specific scenario for Collection Status Column.
        /// </summary>
        public void SelectCollectionStatus()
        {
            //CollectionStatus.Wait(2).Click();
            CollectionStatus.Wait(2).FindElement(By.TagName("a")).Click();
        }
    }
}
