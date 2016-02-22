using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Dashboard.ViewPortalResults.ScheduledTests
{
    /// <summary>
    /// represents the View Portal Scheduled Test Results Grid Column
    /// </summary>
    public class ViewPortalScheduledTestResultsColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewPortalScheduledTestResultsColumn(string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
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
                Name = ViewPortalScheduledTestResultsColumnNames.TestName;
            }
            else if (content.Contains("Subject"))
            {
                Name = ViewPortalScheduledTestResultsColumnNames.Subject;
            }
            else if (content.Contains("Grade Level"))
            {
                Name = ViewPortalScheduledTestResultsColumnNames.GradeLevel;
            }
            else if (content.Contains("Test Stage"))
            {
                Name = ViewPortalScheduledTestResultsColumnNames.TestStage;
            }
            else if (content.Contains("Start Date"))
            {
                Name = ViewPortalScheduledTestResultsColumnNames.StartDate;
            }
            else if (content.Contains("End Date"))
            {
                Name = ViewPortalScheduledTestResultsColumnNames.EndDate;
            }
            else if (content.Contains("Scores Due Date"))
            {
                Name = ViewPortalScheduledTestResultsColumnNames.ScoresDueDate;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
