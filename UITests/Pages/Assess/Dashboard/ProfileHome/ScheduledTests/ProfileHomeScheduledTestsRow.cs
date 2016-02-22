using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Dashboard.ProfileHome.ScheduledTests
{
    /// <summary>
    /// represents the Assess Dashboard - Scheduled Tests Results Grid Row
    /// </summary>
    public class ProfileHomeScheduledTestsRow: SNGridRow
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
        public ProfileHomeScheduledTestsRow(string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base(gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
        }

        public override void InitElements()
        {
            Report.Write("Row text: " + Element.Text);

            TestNameLink = new WebElementWrapper(ByTestNameLink);
            StartDate = new WebElementWrapper(ByStartDate);
            EndDate = new WebElementWrapper(ByEndDate);
            AnswerSheetsLink = new WebElementWrapper(ByAnswerSheetsLink);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private By ByTestNameLink { get { return GetColumnLinkLocator(ProfileHomeScheduledTestsColumnNames.TestName); } }
        private WebElementWrapper TestNameLink { get; set; }

        private By ByStartDate { get { return GetColumnLocator(ProfileHomeScheduledTestsColumnNames.StartDate); } }
        private WebElementWrapper StartDate { get; set; }

        private By ByEndDate { get { return GetColumnLocator(ProfileHomeScheduledTestsColumnNames.EndDate); } }
        private WebElementWrapper EndDate { get; set; }

        private By ByAnswerSheetsLink { get { return GetColumnLinkLocator(ProfileHomeScheduledTestsColumnNames.AnswerSheets); } }
        private WebElementWrapper AnswerSheetsLink { get; set; }

        /// <summary>
        /// Gets the Test Name
        /// </summary>
        /// <returns>text</returns>
        public string GetTestName()
        {
            TestNameLink.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                TestNameLink.Text = FakeText;
            }
            return TestNameLink.Text.Trim();
        }

        /// <summary>
        /// Gets the Test Start Date
        /// </summary>
        /// <returns>text</returns>
        public string GetTestStartDate()
        {
            StartDate.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                StartDate.Text = FakeText;
            }
            return StartDate.Text.Trim();
        }

        /// <summary>
        /// Gets the Test End Date
        /// </summary>
        /// <returns>text</returns>
        public string GetTestEndDate()
        {
            EndDate.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                EndDate.Text = FakeText;
            }
            return EndDate.Text.Trim();
        }

        /// <summary>
        /// Gets the Test Answer Sheets Link Text
        /// </summary>
        /// <returns>text</returns>
        public string GetTestAnswerSheetsLinkText()
        {
            AnswerSheetsLink.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                AnswerSheetsLink.Text = FakeText;
            }
            return AnswerSheetsLink.Text.Trim();
        }
    }
}
