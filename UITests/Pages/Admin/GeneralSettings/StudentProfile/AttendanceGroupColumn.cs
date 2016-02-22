using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.Admin.GeneralSettings.StudentProfile
{
    /// <summary>
    /// represents the AttendanceGroup Grid Column on the Student Profile Page
    /// </summary>
    public class AttendanceGroupColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public AttendanceGroupColumn( string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
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

            if (content.Contains("Attendance Group Name"))
            {
                Name = AttendanceGroupColumnNames.AttendanceGroupName;
            }
            else if (content.Contains("Color"))
            {
                Name = AttendanceGroupColumnNames.Color;
            }
            else if (content.Equals("Range"))
            {
                Name = AttendanceGroupColumnNames.Range;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
