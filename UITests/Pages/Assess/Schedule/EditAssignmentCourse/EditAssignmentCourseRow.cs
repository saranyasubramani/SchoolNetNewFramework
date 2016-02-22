using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.Assess.Schedule.EditAssignmentCourse
{
    /// <summary>
    /// represents the edit assignment course - search results grid row.
    /// </summary>
    public class EditAssignmentCourseRow : SNGridRow
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="columns">the list of columns</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public EditAssignmentCourseRow(string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base(gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
            //Assign to sections 
            //ctl00_MainContent_GridAvailableSections
            //Assign to individual students
            //ctl00_MainContent_GridAvailableStudents
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Row text: " + Element.Text);
            CheckBox = new WebElementWrapper(ByCheckBox);
            CourseName = new WebElementWrapper(ByCourseName);
            CourseId = new WebElementWrapper(ByCourseId);
            NumberOfCourse = new WebElementWrapper(ByNumberOfCourse);

            if (Driver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private By ByCheckBox { get { return GetColumnCheckBoxLocator(EditAssignmentCourseColumnNames.CheckBox); } }
        private WebElementWrapper CheckBox { get; set; }

        private By ByCourseName { get { return GetColumnLocator(EditAssignmentCourseColumnNames.CourseName); } }
        private WebElementWrapper CourseName { get; set; }

        private By ByCourseId { get { return GetColumnLocator(EditAssignmentCourseColumnNames.CourseId); } }
        private WebElementWrapper CourseId { get; set; }

        private By ByNumberOfCourse { get { return GetColumnLocator(EditAssignmentCourseColumnNames.NumberOfCourse); } }
        private WebElementWrapper NumberOfCourse { get; set; }

        /// <summary>
        /// check the box
        /// </summary>
        public void Check()
        {
            CheckBox.Wait(3).Check();
        }
        /// <summary>
        /// uncheck the box
        /// </summary>
        public void UnCheck()
        {
            CheckBox.Wait(3).UnCheck();
        }
        /// <summary>
        /// get the course name text
        /// </summary>
        /// <returns>text</returns>
        public string GetCourseName()
        {
            CourseName.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                CourseName.Text = FakeText;
            }
            return CourseName.Text;
        }
        /// <summary>
        /// get the course id text
        /// </summary>
        /// <returns>text</returns>
        public string GetCourseId()
        {
            CourseId.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                CourseId.Text = FakeText;
            }
            return CourseId.Text;
        }
        /// <summary>
        /// get the number of course text
        /// </summary>
        /// <returns>text</returns>
        public string GetNumberOfCourse()
        {
            NumberOfCourse.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                NumberOfCourse.Text = FakeText;
            }
            return NumberOfCourse.Text;
        }
    }
}
