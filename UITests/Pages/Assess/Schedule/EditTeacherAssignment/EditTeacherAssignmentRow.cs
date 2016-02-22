using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.Assess.Schedule.EditTeacherAssignment
{
    /// <summary>
    /// represents the edit teacher assignment - search results grid row.
    /// </summary>
    public class EditTeacherAssignmentRow : SNGridRow
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="columns">the list of columns</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public EditTeacherAssignmentRow(string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base( gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
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
            CheckBox = new WebElementWrapper( ByCheckBox);
            SectionElement = new WebElementWrapper( BySectionElement);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private By ByCheckBox { get { return GetColumnCheckBoxLocator(EditTeacherAssignmentColumnNames.CheckBox); } }
        private WebElementWrapper CheckBox { get; set; }

        private By BySectionElement { get { return GetColumnLocator(EditTeacherAssignmentColumnNames.Section); } }
        private WebElementWrapper SectionElement { get; set; }

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
        /// get the section text
        /// </summary>
        /// <returns>text</returns>
        public string GetSection()
        {
            SectionElement.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                SectionElement.Text = FakeText;
            }
            return SectionElement.Text;
        }
    }
}
