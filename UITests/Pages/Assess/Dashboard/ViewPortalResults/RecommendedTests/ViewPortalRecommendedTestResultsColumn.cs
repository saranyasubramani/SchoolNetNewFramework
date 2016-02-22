using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Dashboard.ViewPortalResults.RecommendedTests
{
    /// <summary>
    /// represents the View Portal Recommended Test Results Grid Column
    /// </summary>
    public class ViewPortalRecommendedTestResultsColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewPortalRecommendedTestResultsColumn(string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
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
                Name = ViewPortalRecommendedTestResultsColumnNames.TestName;
            }
            else if (content.Contains("Test Category"))
            {
                Name = ViewPortalRecommendedTestResultsColumnNames.TestCategory;
            }
            else if (content.Contains("Subject"))
            {
                Name = ViewPortalRecommendedTestResultsColumnNames.Subject;
            }
            else if (content.Contains("Grade Level"))
            {
                Name = ViewPortalRecommendedTestResultsColumnNames.GradeLevel;
            }
            else if (content.Contains("Start Date"))
            {
                Name = ViewPortalRecommendedTestResultsColumnNames.StartDate;
            }
            else if (content.Contains("End Date"))
            {
                Name = ViewPortalRecommendedTestResultsColumnNames.EndDate;
            }
            else if (content.Contains("Scores Due Date"))
            {
                Name = ViewPortalRecommendedTestResultsColumnNames.ScoresDueDate;
            }
            else if (content.Contains("Assignment Status"))
            {
                Name = ViewPortalRecommendedTestResultsColumnNames.AssignmentStatus;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
