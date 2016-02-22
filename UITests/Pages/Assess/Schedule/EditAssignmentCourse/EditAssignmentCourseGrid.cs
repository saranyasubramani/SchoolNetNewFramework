using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.Assess.Schedule.EditAssignmentCourse
{
    /// <summary>
    /// the edit course assignment grid
    /// </summary>
    public class EditAssignmentCourseGrid : SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">initialize the grid?</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public EditAssignmentCourseGrid(string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
            : base(gridCssSelector, initializeGrid)
        {
            //Choose course
            //ctl00_MainContent_GridAvailableCourses
            //Selected course
            //ctl00_MainContent_GridAssignedCourses
        }

        /// <summary>
        /// Gets the Dummy Column List
        /// </summary>
        /// <returns></returns>
        public override List<IWebElement> GetDummyElementsColumns()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementColumnList == null)
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    //dummy1.Text = "<input type='checkbox' onclick='handleSelectAllAvailableSection();' title='Select/Deselect All' id='chkSelectAllAvailableSection'>";
                    dummy1.Text = "";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "Course Name";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "Course ID";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "# of";
                    DummyElementColumnList = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4 };
                }
            }
            return DummyElementColumnList;
        }

        /// <summary>
        /// Gets the Header Rows - Containing all the column names of the grid
        /// </summary>
        /// <returns></returns>
        public override List<IWebElement> GetDummyElementsHeaderRows()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementHeaderRowList == null)
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    dummy1.Text = "Section";
                    DummyElementHeaderRowList = new List<IWebElement> { dummy1 };
                }
            }
            return DummyElementHeaderRowList;
        }

        /// <summary>
        /// Gets the Dummy Data Row List
        /// </summary>
        /// <returns></returns>
        public override List<IWebElement> GetDummyElementsDataRows()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementDataRowList == null)
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    dummy1.Text = "ACTING 1 63-2010-229100	3";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "ACTING 1 29-2010-229100  3";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "ACTING 1 11-2010-229100  4";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "ACTING 1 47-2010-229100  2";
                    DummyWebElement dummy5 = new DummyWebElement();
                    dummy5.Text = "ACTING 1 42-2010-229100  3";
                    DummyElementDataRowList = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4, dummy5 };
                }
            }
            return DummyElementDataRowList;
        }

        /// <summary>
        /// Gets the List of Dummy Pagination Rows if any.
        /// </summary>
        /// <returns></returns>
        public override List<IWebElement> GetDummyElementsPaginationRows()
        {
            return DummyElementPaginationRowList;
        }

        /// <summary>
        /// Gets the Dummy Data Row List
        /// </summary>
        /// <returns></returns>
        public override void SetColumnLists()
        {
            base.SetColumnLists();
            int columnIndex = 0;
            foreach (var webElement in WebElementColumns)
            {
                Report.Write("GridColumn by index: " + columnIndex);
                var lineItem = new EditAssignmentCourseColumn(gridCssSelector, webElement, columnIndex, ControlPrefix);
                ColumnList.Add(lineItem);
                columnIndex++;
            }
        }

        /// <summary>
        /// Sets the Columns List
        /// </summary>
        public override void SetRowLists()
        {
            base.SetRowLists();
            int rowIndex = 0;
            foreach (var webElement in WebElementRows)
            {
                Report.Write("GridRow by index: " + rowIndex);
                GridRowType rowType = GetGridRowType(rowIndex);
                Report.Write("GridRowType: " + rowType);
                var lineItem = new EditAssignmentCourseRow(gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
                RowList.Add(lineItem);
                rowIndex++;
            }
        }

        /// <summary>
        /// gets a list of rows containing the text to find from the row list
        /// </summary>
        /// <param name="columnName">the column name</param>
        /// <param name="textToFind">the text to find</param>
        /// <returns>list of GridRow</returns>
        public new List<EditAssignmentCourseRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No items were found in the search results column list.");
                return null;
            }
            else
            {
                List<EditAssignmentCourseRow> rowList = new List<EditAssignmentCourseRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    if (row.Type == GridRowType.Data)
                    {
                        EditAssignmentCourseRow EditAssignmentCourseRow = (EditAssignmentCourseRow)row;
                        //get the text by column name
                        if (columnName.Equals(EditAssignmentCourseColumnNames.CourseName))
                        {
                            text = EditAssignmentCourseRow.GetCourseName();
                            //Debug.WriteLine("martin actual text: " + text);
                            //Debug.WriteLine("martin expected text to find: " + textToFind);
                        }
                        if (columnName.Equals(EditAssignmentCourseColumnNames.CourseId))
                        {
                            text = EditAssignmentCourseRow.GetCourseId();
                            //Debug.WriteLine("martin actual text: " + text);
                            //Debug.WriteLine("martin expected text to find: " + textToFind);
                        }
                        if (columnName.Equals(EditAssignmentCourseColumnNames.NumberOfCourse))
                        {
                            text = EditAssignmentCourseRow.GetNumberOfCourse();
                            //Debug.WriteLine("martin actual text: " + text);
                            //Debug.WriteLine("martin expected text to find: " + textToFind);
                        }
                        //if the text is not null
                        if (text != null)
                        {
                            //if the text contains the text to find
                            if (text.Contains(textToFind))
                            {
                                rowList.Add(EditAssignmentCourseRow);
                            }
                        }
                    }
                }
                //may return empty row list if text is not found
                return rowList;
            }
        }
    }
}
