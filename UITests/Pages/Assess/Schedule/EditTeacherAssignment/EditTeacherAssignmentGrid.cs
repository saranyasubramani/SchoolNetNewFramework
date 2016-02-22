using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.Assess.Schedule.EditTeacherAssignment
{
    /// <summary>
    /// the edit teacher assignment grid
    /// </summary>
    public class EditTeacherAssignmentGrid : SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">initialize the grid?</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public EditTeacherAssignmentGrid(  string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
            : base( gridCssSelector, initializeGrid)
        {
            //Assign to sections 
            //ctl00_MainContent_GridAvailableSections
            //Assign to individual students
            //ctl00_MainContent_GridAvailableStudents
        }

        /// <summary>
        /// Gets the Dummy Column List
        /// </summary>
        /// <returns></returns>
        public override List<IWebElement> GetDummyElementsColumns()
        {
            if (Driver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementColumnList == null)
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    //dummy1.Text = "<input type='checkbox' onclick='handleSelectAllAvailableSection();' title='Select/Deselect All' id='chkSelectAllAvailableSection'>";
                    dummy1.Text = "";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "Section";
                    DummyElementColumnList = new List<IWebElement> { dummy1, dummy2 };
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
            if (Driver.GetType() == typeof(DummyDriver))
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
            if (Driver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementDataRowList == null)
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    dummy1.Text = "ACTING 1   Sec 01 Per 1";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "ACTING 1   Sec 02 Per 3";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "ACTING 1   Sec 03 Per 5";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "ACTING 2   Sec 01 Per 6";
                    DummyWebElement dummy5 = new DummyWebElement();
                    dummy5.Text = "PLAY PRODUCT TECH THEATRE   Sec 01 Per 7";
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
        /// Sets the Columns List
        /// </summary>
        public override void SetColumnLists()
        {
            base.SetColumnLists();
            int columnIndex = 0;
            foreach (var webElement in WebElementColumns)
            {
                var lineItem = new EditTeacherAssignmentColumn( gridCssSelector, webElement, columnIndex, ControlPrefix);
                ColumnList.Add(lineItem);
                columnIndex++;
            }
        }

        /// <summary>
        /// Sets the Rows List
        /// </summary>
        public override void SetRowLists()
        {
            base.SetRowLists();
            int rowIndex = 0;
            foreach (var webElement in WebElementRows)
            {
                GridRowType rowType = GetGridRowType(rowIndex);
                var lineItem = new EditTeacherAssignmentRow( gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
                RowList.Add(lineItem);
                rowIndex++;
            }
        }

        /// <summary>
        /// get grid row type
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns>GridRowType</returns>
        public override GridRowType GetGridRowType(int rowIndex)
        {
            GridRowType rowType = GridRowType.Data;
            //if 1st row
            if (rowIndex == 0)
            {   //if has header
                if (HasHeaderRow == true)
                {   //then header row
                    rowType = GridRowType.Header;
                }//or else NO header
                else
                {   //then data row
                    rowType = GridRowType.Data;
                }
            }
            return rowType;
        }

        /// <summary>
        /// gets a list of rows containing the text to find from the row list
        /// </summary>
        /// <param name="columnName">the column name</param>
        /// <param name="textToFind">the text to find</param>
        /// <returns>list of GridRow</returns>
        public new List<EditTeacherAssignmentRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No items were found in the search results column list.");
                return null;
            }
            else
            {
                List<EditTeacherAssignmentRow> rowList = new List<EditTeacherAssignmentRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    EditTeacherAssignmentRow editTeacherAssignmentRow = (EditTeacherAssignmentRow)row;
                    //get the text by column name
                    if (columnName.Equals(EditTeacherAssignmentColumnNames.Section))
                    {
                        text = editTeacherAssignmentRow.GetSection();
                        //Debug.WriteLine("martin actual text: " + text);
                        //Debug.WriteLine("martin expected text to find: " + textToFind);
                    }
                    //if the text is not null
                    if (text != null)
                    {
                        //if the text contains the text to find
                        if (text.Contains(textToFind))
                        {
                            rowList.Add(editTeacherAssignmentRow);
                        }
                    }
                }
                //may return empty row list if text is not found
                return rowList;
            }
        }
    }
}
