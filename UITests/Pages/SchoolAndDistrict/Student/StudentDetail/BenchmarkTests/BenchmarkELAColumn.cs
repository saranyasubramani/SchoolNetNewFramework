using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;

namespace UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests
{
    /// <summary>
    /// represents the benchmark tab - ela grid column.
    /// </summary>
    public class BenchmarkELAColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public BenchmarkELAColumn(string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
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
                Name = BenchmarkELAColumnNames.TestName;
            }
            else if (content.Contains("Test Date"))
            {
                Name = BenchmarkELAColumnNames.TestDate;
            }
            else if (content.Contains("Test Score"))
            {
                Name = BenchmarkELAColumnNames.TestScore;
            }
            else if (content.Contains("Score Group"))
            {
                Name = BenchmarkELAColumnNames.ScoreGroup;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
