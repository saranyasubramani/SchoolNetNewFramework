using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;

namespace UITests.Pages.Assess.Schedule.ViewAssignmentSummary
{
    /// <summary>
    /// represents the view assignment summary - search results grid column.
    /// </summary>
    public class ViewAssignmentSummaryColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewAssignmentSummaryColumn( string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
            : base( gridCssSelector, webElement, index, overrideControlPrefix)
        {
        }

        /// <summary>
        /// Sets the Column Name
        /// </summary>
        protected override void SetColumnName()
        {
            string content = Element.Text;
            Report.Write("Column text: " + content);

            if (content.Contains("Courses") || content.Contains("Schools"))
            {
                Name = ViewAssignmentSummaryColumnNames.Courses;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
