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

namespace UITests.Pages.Assess.Dashboard.ProfileHome.UpComingTestWindows
{
    /// <summary>
    /// represents the Assess Dashboard - UpComing Test Windows Results Grid Row
    /// </summary>
    public class ProfileHomeUpComingTestWindowsRow: SNGridRow
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
        public ProfileHomeUpComingTestWindowsRow(string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base(gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
        }

        public override void InitElements()
        {
            Report.Write("Row text: " + Element.Text);

            TestWindowNameLink = new WebElementWrapper(ByTestWindowNameLink);
            StartDate = new WebElementWrapper(ByStartDate);
            EndDate = new WebElementWrapper(ByEndDate);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private By ByTestWindowNameLink { get { return GetColumnLinkLocator(ProfileHomeUpComingTestWindowsColumnNames.TestWindowName); } }
        private WebElementWrapper TestWindowNameLink { get; set; }

        private By ByStartDate { get { return GetColumnLocator(ProfileHomeUpComingTestWindowsColumnNames.StartDate); } }
        private WebElementWrapper StartDate { get; set; }

        private By ByEndDate { get { return GetColumnLocator(ProfileHomeUpComingTestWindowsColumnNames.StartDate); } }
        private WebElementWrapper EndDate { get; set; }

        /// <summary>
        /// Gets the Test Window Name
        /// </summary>
        /// <returns>text</returns>
        public string GetTestWindowName()
        {
            TestWindowNameLink.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                TestWindowNameLink.Text = FakeText;
            }
            return TestWindowNameLink.Text.Trim();
        }

        /// <summary>
        /// Gets the Test Window Start Date
        /// </summary>
        /// <returns>text</returns>
        public string GetTestWindowStartDate()
        {
            StartDate.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                StartDate.Text = FakeText;
            }
            return StartDate.Text.Trim();
        }

        /// <summary>
        /// Gets the Test Window End Date
        /// </summary>
        /// <returns>text</returns>
        public string GetTestWindowEndDate()
        {
            EndDate.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                EndDate.Text = FakeText;
            }
            return EndDate.Text.Trim();
        }

        /// <summary>
        /// Selects the Test Window Link for the Row
        /// </summary>
        /// <returns></returns>
        public void SelectTestWindowName()
        {
            TestWindowNameLink.Wait(2).Click();
        }
    }
}
