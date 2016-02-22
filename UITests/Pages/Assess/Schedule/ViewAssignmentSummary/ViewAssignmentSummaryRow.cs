using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.Assess.Schedule.ViewAssignmentSummary
{
    /// <summary>
    /// represents the view assignment summary - search results grid row.
    /// </summary>
    public class ViewAssignmentSummaryRow : SNGridRow
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="columns">the list of columns</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewAssignmentSummaryRow(  string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base( gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Row text: " + Element.Text);
            Course = new WebElementWrapper( ByCourse);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        protected override By GetColumnLocator(string columnName)
        {
            By by = null;
            foreach (var column in Columns)
            {
                if (column.Name.Equals(columnName))
                {
                    //("div.section_container > div:nth-of-type(3) > div:nth-of-type(2) > div:nth-of-type(1)");
                    by = By.CssSelector(gridCssSelector + " > div:nth-of-type(" + (Index + 1) + ") > div:nth-of-type(" + (column.Index + 1) + ")");
                    break;
                }
            }
            return by;
        }

        private By ByCourse { get { return GetColumnLocator(ViewAssignmentSummaryColumnNames.Courses); } }
        private WebElementWrapper Course { get; set; }

        /// <summary>
        /// get the course text
        /// </summary>
        /// <returns>text</returns>
        public string GetCourse()
        {
            Course.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                Course.Text = FakeText;
            }
            return Course.Text;
        }
    }
}
