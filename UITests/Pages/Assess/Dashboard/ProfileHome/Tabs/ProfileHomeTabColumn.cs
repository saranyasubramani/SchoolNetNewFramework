using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Dashboard.ProfileHome.Tabs
{
    /// <summary>
    /// represents the assess dashboard - search results grid column.
    /// </summary>
    public class ProfileHomeTabColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ProfileHomeTabColumn(string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
            : base(gridCssSelector, webElement, index, overrideControlPrefix)
        {
        }

        protected override void SetColumnName()
        {
            string content = Element.Text;
            if (content.Contains("Test Name"))
            {
                Name = ProfileHomeTabColumnNames.TestName;
            }
            else if (content.Contains("Test Category"))
            {
                Name = ProfileHomeTabColumnNames.TestCategory;
            }
            else if (content.Contains("Online Passcode"))
            {
                Name = ProfileHomeTabColumnNames.OnlinePasscode;
            }
            else if (content.Contains("Assigned"))
            {
                Name = ProfileHomeTabColumnNames.Assigned;
            }
            else if (content.Contains("Stage"))
            {
                Name = ProfileHomeTabColumnNames.Stage;
            }
            else if (content.Contains("Start Date"))
            {
                Name = ProfileHomeTabColumnNames.StartDate;
            }
            else if (content.Contains("Subject"))
            {
                Name = ProfileHomeTabColumnNames.Subject;
            }
            else if (content.Contains("Grade"))
            {
                Name = ProfileHomeTabColumnNames.Grade;
            }
            else if (content.Contains("Collection Status"))
            {
                Name = ProfileHomeTabColumnNames.CollectionStatus;
            }
            else if (content.Contains("Gradebook Updated"))
            {
                Name = ProfileHomeTabColumnNames.GradebookUpdated;
            }
            else if (content.Contains("Student Performance"))
            {
                Name = ProfileHomeTabColumnNames.StudentPerformance;
            }
            else if (content.Contains("Actions"))
            {
                Name = ProfileHomeTabColumnNames.Actions;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
