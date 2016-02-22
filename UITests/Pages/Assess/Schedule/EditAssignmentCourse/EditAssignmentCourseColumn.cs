using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;

namespace UITests.Pages.Assess.Schedule.EditAssignmentCourse
{
    /// <summary>
    /// represents the edit course assignment - search results grid row.
    /// </summary>
    public class EditAssignmentCourseColumn : SNGridColumn
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public EditAssignmentCourseColumn(string gridCssSelector, IWebElement webElement, int index, string overrideControlPrefix = null)
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
                Name = EditAssignmentCourseColumnNames.CheckBox;
            }
            else if (content.Contains("Course Name"))
            {
                Name = EditAssignmentCourseColumnNames.CourseName;
            }
            else if (content.Contains("Course ID"))
            {
                Name = EditAssignmentCourseColumnNames.CourseId;
            }
            else if (content.Contains("# of"))
            {
                Name = EditAssignmentCourseColumnNames.NumberOfCourse;
            }
            else
            {
                throw new Exception("The column was not found within the column content: '" + content + "'.");
            }
        }
    }
}
