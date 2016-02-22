using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Dashboard.ProfileHome.ScheduledTests
{
    /// <summary>
    /// represents the Assess Dashboard Page - Scheduled Tests Results Grid Column
    /// </summary>
    public class ProfileHomeScheduledTestsColumn: SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ProfileHomeScheduledTestsColumn(string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
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
                Name = ProfileHomeScheduledTestsColumnNames.TestName;
            }
            else if (content.Contains("Start Date"))
            {
                Name = ProfileHomeScheduledTestsColumnNames.StartDate;
            }
            else if (content.Contains("End Date"))
            {
                Name = ProfileHomeScheduledTestsColumnNames.EndDate;
            }
            //else if (content.Contains(""))
            else if (content.Equals(""))
            {
                Name = ProfileHomeScheduledTestsColumnNames.AnswerSheets;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
