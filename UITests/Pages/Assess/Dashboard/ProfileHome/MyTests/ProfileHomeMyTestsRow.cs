using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.Assess.Dashboard.ProfileHome.MyTests
{
    /// <summary>
    /// represents the Assess Dashboard - My Tests Results Grid Row
    /// </summary>
    public class ProfileHomeMyTestsRow: SNGridRow
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
        public ProfileHomeMyTestsRow(string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
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
            NumberOfItems = new WebElementWrapper(ByNumberOfItems);
            TestStage = new WebElementWrapper(ByTestStage);
            ModifiedDate = new WebElementWrapper(ByModifiedDate);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private By ByTestNameLink { get { return GetColumnLinkLocator(ProfileHomeMyTestsColumnNames.TestName); } }
        private WebElementWrapper TestNameLink { get; set; }

        private By ByNumberOfItems { get { return GetColumnLocator(ProfileHomeMyTestsColumnNames.NumberOfItems); } }
        private WebElementWrapper NumberOfItems { get; set; }

        private By ByTestStage { get { return GetColumnLocator(ProfileHomeMyTestsColumnNames.TestStage); } }
        private WebElementWrapper TestStage { get; set; }

        private By ByModifiedDate { get { return GetColumnLocator(ProfileHomeMyTestsColumnNames.NumberOfItems); } }
        private WebElementWrapper ModifiedDate { get; set; }

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
        /// Gets the Number of Items on the Test
        /// </summary>
        /// <returns></returns>
        public string GetNumberOfItemsOnTest()
        {
            NumberOfItems.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                NumberOfItems.Text = FakeText;
            }
            return NumberOfItems.Text.Trim();
        }

        /// <summary>
        /// Gets the Test Stage of the Test
        /// </summary>
        /// <returns></returns>
        public string GetTestStage()
        {
            TestStage.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
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
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                ModifiedDate.Text = FakeText;
            }
            return ModifiedDate.Text.Trim();
        }
    }
}
