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
    /// Config Grid on the AttendanceGroup Page on the Student Profile Page
    /// </summary>
    public class AttendanceGroupGrid : SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">initialize the grid?</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public AttendanceGroupGrid( string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
            : base( gridCssSelector, false, overrideControlPrefix)//override initializeGrid = false in base constructor, so I can call it later in this constructor
        {
            //override the column selector
            ByColumns = By.CssSelector(gridCssSelector + " tr.DataGridHeader > td");
            InitializeGrid = initializeGrid;
            InitElements();
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
                    dummy1.Text = "Attendance Group Name";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "Color";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "Range";
                    DummyElementColumnList = new List<IWebElement> { dummy1, dummy2, dummy3 };
                }
            }
            return DummyElementColumnList;
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
                    dummy1.Text = @"<td>Attendance Group Name</td>
                                    <td>Color</td>
                                    <td class='last-child'><div class='span2'>Range <i data-original-title='' id='iconInfo' class='icon-info-sign pointer'></i></div></td>";
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
                    dummy1.FakeAttributeValue = "Needs Improvement";
                    dummy1.FakeAttributeName = "60";
                    dummy1.Text = @"<td><input type='text' value='Needs Improvement'></td>
                                    <td></td>
                                    <td><span class='smallBox span1'>0</span> <span>%</span><span>up to </span> <input type='text' value='60'> <span> %</span></td>";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.FakeAttributeValue = "Satisfactory";
                    dummy2.FakeAttributeName = "75";
                    dummy2.Text = @"<td><input type='text' value='Satisfactory'></td>
                                    <td></td>
                                    <td><span class='smallBox span1'>60</span> <span>%</span><span>up to </span> <input type='text' value='75'> <span> %</span></td>";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.FakeAttributeValue = "Excellent";
                    dummy3.FakeAttributeName = "";
                    dummy3.Text = @"<td><input type='text' value='Excellent'></td>
                                    <td></td>
                                    <td><span class='smallBox span1'>75</span> <span>%</span><span>up to </span> <span>100</span> <span> %</span></td>";
                    DummyElementDataRowList = new List<IWebElement> { dummy1, dummy2, dummy3 };
                }
            }
            return DummyElementDataRowList;
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
                Report.Write("GridColumn by index: " + columnIndex);
                var lineItem = new AttendanceGroupColumn( gridCssSelector, webElement, columnIndex, ControlPrefix);
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
                Report.Write("GridRow by index: " + rowIndex);
                GridRowType rowType = GetGridRowType(rowIndex);
                Report.Write("GridRowType: " + rowType);
                var lineItem = new AttendanceGroupRow( gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
                RowList.Add(lineItem);
                rowIndex++;
            }
        }

        /// <summary>
        /// gets the first row containing the text to find from the row list
        /// </summary>
        /// <param name="columnName">the column name</param>
        /// <param name="textToFind">the text to find</param>
        /// <returns>AttendanceGroupRow</returns>
        public AttendanceGroupRow GetsFirstRowContainingTextToFindFromList(string columnName, string textToFind)
        {
            List<AttendanceGroupRow> list = GetsRowsContainingTextToFindFromList(columnName, textToFind);
            if (list.Count == 0)
            {
                Assert.Fail("No items were found in the list containing: '" + textToFind + "'.");
                return null;
            }
            else
            {
                return list[0];
            }
        }

        /// <summary>
        /// gets a list of rows containing the text to find from the row list
        /// </summary>
        /// <param name="columnName">the column name</param>
        /// <param name="textToFind">the text to find</param>
        /// <returns>list of AttendanceGroupRow</returns>
        public new List<AttendanceGroupRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No items were found in the grid column list.");
                return null;
            }
            else
            {
                List<AttendanceGroupRow> rowList = new List<AttendanceGroupRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    AttendanceGroupRow attendanceGroupRow = (AttendanceGroupRow)row;
                    if (attendanceGroupRow.Type != GridRowType.Header && attendanceGroupRow.Type != GridRowType.Pagination)
                    {
                        //get the text by column name
                        if (columnName.Equals(AttendanceGroupColumnNames.AttendanceGroupName))
                        {
                            text = attendanceGroupRow.GetAttendanceGroupName();
                        }
                        if (columnName.Equals(AttendanceGroupColumnNames.Color))
                        {
                            text = attendanceGroupRow.GetColor();
                        }
                        if (columnName.Equals(AttendanceGroupColumnNames.Range))
                        {
                            text = attendanceGroupRow.GetRange();
                        }

                        //if the text is not null
                        if (text != null)
                        {
                            //if the text contains the text to find
                            if (text.Contains(textToFind))
                            {
                                rowList.Add(attendanceGroupRow);
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
