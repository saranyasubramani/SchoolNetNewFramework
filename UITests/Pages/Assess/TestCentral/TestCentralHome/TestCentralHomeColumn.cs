using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;

namespace UITests.Pages.Assess.TestCentral.TestCentralHome
{
    /// <summary>
    /// represents the test central home - search results grid column.
    /// </summary>
    public class TestCentralHomeColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public TestCentralHomeColumn(  string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
            : base( gridCssSelector, webElement, index, overrideControlPrefix)
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
                Name = TestCentralHomeColumnNames.TestName;
            }
            else if (content.Contains("Test Category"))
            {
                Name = TestCentralHomeColumnNames.TestCategory;
            }
            else if (content.Contains("Subject"))
            {
                Name = TestCentralHomeColumnNames.Subject;
            }
            else if (content.Contains("Grade Level"))
            {
                Name = TestCentralHomeColumnNames.GradeLevel;
            }
            else if (content.Contains("Test Stage"))
            {
                Name = TestCentralHomeColumnNames.TestStage;
            }
            else if (content.Contains("Start Date"))
            {
                Name = TestCentralHomeColumnNames.StartDate;
            }
            else if (content.Contains("End Date"))
            {
                Name = TestCentralHomeColumnNames.EndDate;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
