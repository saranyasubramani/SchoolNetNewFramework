using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Dashboard.ProfileHome.RecommendedTests
{
    /// <summary>
    /// represents the Assess Dashboard Page - Recommended Tests Results Grid Column
    /// </summary>
    public class ProfileHomeRecommendedTestsColumn: SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ProfileHomeRecommendedTestsColumn(string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
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
                Name = ProfileHomeRecommendedTestsColumnNames.TestName;
            }
            else if (content.Contains("Start Date"))
            {
                Name = ProfileHomeRecommendedTestsColumnNames.StartDate;
            }
            else if (content.Contains("End Date"))
            {
                Name = ProfileHomeRecommendedTestsColumnNames.EndDate;
            }
            else if (content.Contains("Scores Due Date"))
            {
                Name = ProfileHomeRecommendedTestsColumnNames.ScoresDueDate;
            }
            else if (content.Contains("Assignment Status"))
            {
                Name = ProfileHomeRecommendedTestsColumnNames.AssignmentStatus;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
