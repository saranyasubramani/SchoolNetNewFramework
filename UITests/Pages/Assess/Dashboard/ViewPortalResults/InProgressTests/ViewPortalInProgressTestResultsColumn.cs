using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Dashboard.ViewPortalResults.InProgressTests
{
    /// <summary>
    /// represents the View Portal InProgress Test Results Grid Column
    /// </summary>
    public class ViewPortalInProgressTestResultsColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewPortalInProgressTestResultsColumn(string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
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
                Name = ViewPortalInProgressTestResultsColumnNames.TestName;
            }
            else if (content.Contains("Subject"))
            {
                Name = ViewPortalInProgressTestResultsColumnNames.Subject;
            }
            else if (content.Contains("Grade Level"))
            {
                Name = ViewPortalInProgressTestResultsColumnNames.GradeLevel;
            }
            else if (content.Contains("Test Stage"))
            {
                Name = ViewPortalInProgressTestResultsColumnNames.TestStage;
            }
            else if (content.Contains("End Date"))
            {
                Name = ViewPortalInProgressTestResultsColumnNames.EndDate;
            }
            else if (content.Contains("Scores Due Date"))
            {
                Name = ViewPortalInProgressTestResultsColumnNames.ScoresDueDate;
            }
            else if (content.Contains("Collection Status"))
            {
                Name = ViewPortalInProgressTestResultsColumnNames.CollectionStatus;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
