using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.TestWindow.ViewTestWindow
{
    /// <summary>
    /// represents the view test window - search results grid column.
    /// </summary>
    public class ViewTestWindowColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewTestWindowColumn(string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
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
                Name = ViewTestWindowColumnNames.Select;
            }
            else if (content.Contains("Test Name"))
            {
                Name = ViewTestWindowColumnNames.TestName;
            }
            else if (content.Contains("Grade Level"))
            {
                Name = ViewTestWindowColumnNames.Grade;
            }
            else if (content.Contains("Subject"))
            {
                Name = ViewTestWindowColumnNames.Subject;
            }
            else if (content.Contains("Test Stage"))
            {
                Name = ViewTestWindowColumnNames.TestStage;
            }
            else if (content.Contains("Start Date"))
            {
                Name = ViewTestWindowColumnNames.StartDate;
            }
            else if (content.Contains("End Date"))
            {
                Name = ViewTestWindowColumnNames.EndDate;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
