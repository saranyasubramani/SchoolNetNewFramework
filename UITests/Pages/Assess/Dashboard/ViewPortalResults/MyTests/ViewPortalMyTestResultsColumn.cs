using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Dashboard.ViewPortalResults.MyTests
{
    /// <summary>
    /// represents the View Portal My Test Results Grid Column
    /// </summary>
    public class ViewPortalMyTestResultsColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewPortalMyTestResultsColumn(string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
            : base(gridCssSelector, webElement, index, overrideControlPrefix)
        {
        }

        /// <summary>
        /// Sets the Column Name
        /// </summary>
        protected override void SetColumnName()
        {
            string content = Element.Text;
            Report.Write("Column text: " + content);

            if (content.Contains("Test Name"))
            {
                Name = ViewPortalMyTestResultsColumnNames.TestName;
            }
            else if (content.Contains("Subject"))
            {
                Name = ViewPortalMyTestResultsColumnNames.Subject;
            }
            else if (content.Contains("Grade Level"))
            {
                Name = ViewPortalMyTestResultsColumnNames.GradeLevel;
            }
            else if (content.Contains("Test Stage"))
            {
                Name = ViewPortalMyTestResultsColumnNames.TestStage;
            }
            else if (content.Contains("Modified Date"))
            {
                Name = ViewPortalMyTestResultsColumnNames.ModifiedDate;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
