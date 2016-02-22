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

namespace UITests.Pages.Assess.TestWindow.ViewTestWindow
{
    /// <summary>
    /// the view test window grid
    /// </summary>
    public class ViewTestWindowGrid : SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">initialize the grid?</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewTestWindowGrid(string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
            : base(gridCssSelector, initializeGrid)
        {
            //ctl00_MainContent_TestSearchResults1_TestFinderResults1_gridResults
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
                    dummy1.Text = "Test Name";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "Subject";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "Start Date";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "End Date";
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
                    dummy1.Text = "Test Name";
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
                    dummy1.Text = "OriginalAutomationTestTestWindow English Language and Literature";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "OriginalAutomationTestTestWindow Mathematics";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "OriginalAutomationTestTestWindow Fine and Performing Arts ";
                    DummyElementDataRowList = new List<IWebElement> { dummy1, dummy2, dummy3 };
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
                Report.Write("GridColumn by index: " + columnIndex);
                var lineItem = new ViewTestWindowColumn(gridCssSelector, webElement, columnIndex, ControlPrefix);
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
                var lineItem = new ViewTestWindowRow(gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
                RowList.Add(lineItem);
                rowIndex++;
            }
        }

        /// <summary>
        /// gets the first row containing the text to find from the row list
        /// </summary>
        /// <param name="columnName">the column name</param>
        /// <param name="textToFind">the text to find</param>
        /// <returns>ViewTestWindowRow</returns>
        public ViewTestWindowRow GetsFirstRowContainingTextToFindFromList(string columnName, string textToFind)
        {
            List<ViewTestWindowRow> list = GetsRowsContainingTextToFindFromList(columnName, textToFind);
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
        /// <returns>list of GridRow</returns>
        public new List<ViewTestWindowRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {//changed to debug for test cases where we want to assert that no search results were found
                Report.Write("No items were found in the search results column list.");
                return null;
            }
            else
            {
                List<ViewTestWindowRow> rowList = new List<ViewTestWindowRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    if (row.Type == GridRowType.Data)
                    {
                        ViewTestWindowRow ViewTestWindowRow = (ViewTestWindowRow)row;

                        if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                        {
                            ViewTestWindowRow.FakeText = textToFind;
                        }

                        //get the text by column name
                        if (columnName.Equals(ViewTestWindowColumnNames.TestName))
                        {
                            text = ViewTestWindowRow.GetTestWindowName();
                            //Debug.WriteLine("martin actual text: " + text);
                            //Debug.WriteLine("martin expected text to find: " + textToFind);
                        }
                        if (columnName.Equals(ViewTestWindowColumnNames.Subject))
                        {
                            text = ViewTestWindowRow.GetSubject();
                            //Debug.WriteLine("martin actual text: " + text);
                            //Debug.WriteLine("martin expected text to find: " + textToFind);
                        }
                        if (columnName.Equals(ViewTestWindowColumnNames.Grade))
                        {
                            text = ViewTestWindowRow.GetGrade();
                            //Debug.WriteLine("martin actual text: " + text);
                            //Debug.WriteLine("martin expected text to find: " + textToFind);
                        }
                        if (columnName.Equals(ViewTestWindowColumnNames.TestStage))
                        {
                            text = ViewTestWindowRow.GetGrade();
                            //Debug.WriteLine("martin actual text: " + text);
                            //Debug.WriteLine("martin expected text to find: " + textToFind);
                        }
                        if (columnName.Equals(ViewTestWindowColumnNames.StartDate))
                        {
                            text = ViewTestWindowRow.GetStartDate();
                            //Debug.WriteLine("martin actual text: " + text);
                            //Debug.WriteLine("martin expected text to find: " + textToFind);
                        }
                        if (columnName.Equals(ViewTestWindowColumnNames.EndDate))
                        {
                            text = ViewTestWindowRow.GetEndDate();
                            //Debug.WriteLine("martin actual text: " + text);
                            //Debug.WriteLine("martin expected text to find: " + textToFind);
                        }
                        //if the text is not null
                        if (text != null)
                        {
                            //if the text contains the text to find
                            if (text.Contains(textToFind))
                            {
                                rowList.Add(ViewTestWindowRow);
                            }
                        }
                    }
                }
                //may return empty row list if text is not found
                return rowList;
            }
        }

        /// <summary>
        /// gets data row with the specified index. Note: data row are NOT pagination
        /// or header row. Data row is a row with actual data value. For example, 
        /// "Mathematics,  Gr 1 - Gr 2, Completed, 01/01/2012". 
        ///        
        /// </summary>
        /// <param name="index">Index start 1, 2, 3... Index 1 is the first data row user wants</param>
        /// <returns>list of GridRow</returns>
        public ViewTestWindowRow GetDataRow(int index)
        {
            //find where data row start. Usually first 2 rows are pagination and header. 
            int firstDataRow = 0;
            for (int i = 0; i < 3; i++)
            {
                if (RowList[i].Type == GridRowType.Data)
                {
                    firstDataRow = i;
                }
            }

            ViewTestWindowRow rowFound = (ViewTestWindowRow)RowList[firstDataRow + index - 1];
            return rowFound;
        }
    }
}
