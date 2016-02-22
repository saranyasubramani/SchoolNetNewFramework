using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Dashboard.ProfileHome.UpComingTestWindows
{
    /// <summary>
    /// represents the Assess Dashboard Page - UpComing Test Windows Results Grid Column
    /// </summary>
    public class ProfileHomeUpComingTestWindowsColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ProfileHomeUpComingTestWindowsColumn(string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
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

            if (content.Contains("Test Window Name"))
            {
                Name = ProfileHomeUpComingTestWindowsColumnNames.TestWindowName;
            }
            else if (content.Contains("Start Date"))
            {
                Name = ProfileHomeUpComingTestWindowsColumnNames.StartDate;
            }
            else if (content.Contains("End Date"))
            {
                Name = ProfileHomeUpComingTestWindowsColumnNames.EndDate;
            }           
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
