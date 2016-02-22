using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Dashboard.ProfileHome.InProgressTests
{
    /// <summary>
    /// represents the Assess Dashboard - In Progress Tests Results Grid Row
    /// </summary>
    public class ProfileHomeInProgressTestsRow: SNGridRow
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
        public ProfileHomeInProgressTestsRow(string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base(gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Row text: " + Element.Text);

            TestNameLink = new WebElementWrapper(ByTestNameLink);
            EndDate = new WebElementWrapper(ByEndDate);
            ScoresDueDate = new WebElementWrapper(ByScoresDueDate);
            CollectionStatus = new WebElementWrapper(ByCollectionStatus);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private By ByTestNameLink { get { return GetColumnLinkLocator(ProfileHomeInProgressTestsColumnNames.TestName); } }
        private WebElementWrapper TestNameLink { get; set; }

        private By ByEndDate { get { return GetColumnLocator(ProfileHomeInProgressTestsColumnNames.EndDate); } }
        private WebElementWrapper EndDate { get; set; }

        private By ByScoresDueDate { get { return GetColumnLocator(ProfileHomeInProgressTestsColumnNames.ScoresDueDate); } }
        private WebElementWrapper ScoresDueDate { get; set; }

        private By ByCollectionStatus { get { return GetColumnLinkLocator(ProfileHomeInProgressTestsColumnNames.CollectionStatus); } }
        private WebElementWrapper CollectionStatus { get; set; }

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
        /// Gets the Test Scores Due Date
        /// </summary>
        /// <returns>text</returns>
        public string GetTestScoresDueDate()
        {
            ScoresDueDate.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                ScoresDueDate.Text = FakeText;
            }
            return ScoresDueDate.Text.Trim();
        }

        /// <summary>
        /// Gets the Test Collection Status
        /// </summary>
        /// <returns>text</returns>
        public string GetTestCollectionStatus()
        {
            CollectionStatus.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                CollectionStatus.Text = FakeText;
            }
            return CollectionStatus.Text.Trim();
        }

        /// <summary>
        /// Clicks on the Collection Status Link for the Row
        /// </summary>
        public void SelectCollectionStatus()
        {
            CollectionStatus.Wait(2).Click();
        }
    }
}
