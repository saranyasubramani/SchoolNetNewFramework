using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.TestWindow.PlanHome
{
    /// <summary>
    /// represents the plan home - search results grid column.
    /// </summary>
    public class PlanHomeColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public PlanHomeColumn(string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
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
            if (content.Trim().Equals(""))
            {
                Name = PlanHomeColumnNames.IconDisplay;
            }
            else if (content.Contains("Test Window Name") || content.Contains("Test Name"))
            {
                Name = PlanHomeColumnNames.TestWindowName;
            }
            else if (content.Contains("Grade Level"))
            {
                Name = PlanHomeColumnNames.Grade;
            }
            else if (content.Contains("Subject"))
            {
                Name = PlanHomeColumnNames.Subject;
            }
            else if (content.Contains("Test Stage"))
            {
                Name = PlanHomeColumnNames.TestStage;
            }
            else if (content.Contains("Start Date"))
            {
                Name = PlanHomeColumnNames.StartDate;
            }
            else if (content.Contains("End Date"))
            {
                Name = PlanHomeColumnNames.EndDate;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
