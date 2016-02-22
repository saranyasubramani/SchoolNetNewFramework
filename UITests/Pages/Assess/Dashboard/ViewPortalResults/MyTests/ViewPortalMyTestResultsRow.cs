using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Dashboard.ViewPortalResults.MyTests
{
    /// <summary>
    /// represents the View Portal My Test Results Grid Row
    /// </summary>
    public class ViewPortalMyTestResultsRow : SNGridRow
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
        public ViewPortalMyTestResultsRow(string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
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
            ModifiedDate = new WebElementWrapper(ByModifiedDate);

            if (Driver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private By ByTestNameLink { get { return GetColumnLinkLocator(ViewPortalMyTestResultsColumnNames.TestName); } }
        private WebElementWrapper TestNameLink { get; set; }

        private By BySubject { get { return GetColumnLocator(ViewPortalMyTestResultsColumnNames.Subject); } }
        private WebElementWrapper Subject { get; set; }

        private By ByGradeLevel { get { return GetColumnLocator(ViewPortalMyTestResultsColumnNames.GradeLevel); } }
        private WebElementWrapper GradeLevel { get; set; }

        private By ByTestStage { get { return GetColumnLocator(ViewPortalMyTestResultsColumnNames.TestStage); } }
        private WebElementWrapper TestStage { get; set; }

        private By ByModifiedDate { get { return GetColumnLocator(ViewPortalMyTestResultsColumnNames.ModifiedDate); } }
        private WebElementWrapper ModifiedDate { get; set; }

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
        /// Gets the Last Modified Date of the Test
        /// </summary>
        /// <returns></returns>
        public string GetLastModifiedDateOfTest()
        {
            ModifiedDate.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                ModifiedDate.Text = FakeText;
            }
            return ModifiedDate.Text.Trim();
        }

        /// <summary>
        /// Clicks on the Test Name Link for the Row
        /// </summary>
        public void TestName()
        {
            TestNameLink.Wait(2).Click();
        }
    }
}
