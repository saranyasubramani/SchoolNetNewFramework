using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;

namespace UITests.Pages.Assess.Dashboard.ProfileHome.MyTests
{
    /// <summary>
    /// represents the Assess Dashboard Page - My Tests Results Grid Column
    /// </summary>
    public class ProfileHomeMyTestsColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ProfileHomeMyTestsColumn(string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
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
                Name = ProfileHomeMyTestsColumnNames.TestName;
            }
            else if (content.Contains("# of Items"))
            {
                Name = ProfileHomeMyTestsColumnNames.NumberOfItems;
            }
            else if (content.Contains("Test Stage"))
            {
                Name = ProfileHomeMyTestsColumnNames.TestStage;
            }
            else if (content.Contains("Modified Date"))
            {
                Name = ProfileHomeMyTestsColumnNames.ModifiedDate;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
