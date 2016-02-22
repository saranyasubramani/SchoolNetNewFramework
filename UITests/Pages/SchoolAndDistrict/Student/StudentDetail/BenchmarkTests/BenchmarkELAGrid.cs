using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests
{
    /// <summary>
    /// the benchmark ela grid
    /// </summary>
    public class BenchmarkELAGrid : SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">initialize the grid?</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public BenchmarkELAGrid(string gridCssSelector, int gridIndex, bool initializeGrid = false, string overrideControlPrefix = null)
            : base(gridCssSelector, initializeGrid)
        {
            //#SubjectGroup0 or #SubjectGroup1 or ... depend on number of subject students had. 

            //gridCssSelector  ="SubjectGroup0";
            ByGridIdentifier = By.CssSelector(gridCssSelector);
            ByColumns = By.CssSelector(gridCssSelector + " thead > tr > th");
            ByHeaderRow = By.CssSelector(gridCssSelector + " thead");
            ByRows = By.CssSelector(gridCssSelector + " tbody > tr");
            _gridIndex = gridIndex;
            InitElements();
        }

        private int _gridIndex;

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
                    dummy2.Text = "Test Date";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "Test Score";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "Score Group";
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
                    dummy1.Text = "Test Window Name";
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
                var lineItem = new BenchmarkELAColumn(gridCssSelector, webElement, columnIndex, ControlPrefix);
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
            //last row is not part of the grid. so use count - 1 to disclude it. 
            for (int i = 0; i < WebElementRows.Count - 1; i++)
            {
                Report.Write("GridRow by index: " + rowIndex);
                GridRowType rowType = GetGridRowType(rowIndex);
                Report.Write("GridRowType: " + rowType);
                var lineItem = new BenchmarkELARow(gridCssSelector, WebElementRows[i], _gridIndex, rowIndex, rowType, ColumnList, ControlPrefix);
                RowList.Add(lineItem);
                rowIndex++;
            }
        }

        /// <summary>
        /// gets the first row containing the text to find from the row list
        /// </summary>
        /// <param name="columnName">the column name</param>
        /// <param name="textToFind">the text to find</param>
        /// <returns>BenchmarkELARow</returns>
        public BenchmarkELARow GetsFirstRowContainingTextToFindFromList(string columnName, string textToFind)
        {
            List<BenchmarkELARow> list = GetsRowsContainingTextToFindFromList(columnName, textToFind);
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
        public new List<BenchmarkELARow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {//changed to debug for test cases where we want to assert that no search results were found
                Report.Write("No items were found in the search results column list.");
                return null;
            }
            else
            {
                List<BenchmarkELARow> rowList = new List<BenchmarkELARow>();
                string text = null;
                int index = 0;
                //last row is not part of the grid. so use count - 1 to disclude it. 
                for (int i = 0; i < RowList.Count - 1; i++)
                {
                    if (RowList[i].Type == GridRowType.Data)
                    {
                        BenchmarkELARow BenchmarkELARow = (BenchmarkELARow)RowList[i];

                        if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                        {
                            BenchmarkELARow.FakeText = textToFind;
                        }

                        //get the text by column name
                        if (columnName.Equals(BenchmarkELAColumnNames.TestName))
                        {
                            text = BenchmarkELARow.GetTestName();
                            //Debug.WriteLine("actual text: " + text);
                            //Debug.WriteLine("expected text to find: " + textToFind);
                        }
                        //if the text is not null
                        if (text != null)
                        {
                            //if the text contains the text to find
                            if (text.Contains(textToFind))
                            {
                                rowList.Add(BenchmarkELARow);
                            }
                        }
                    }
                }
                //may return empty row list if text is not found
                return rowList;
            }
        }

        /// <summary>
        /// gets the Nth row
        /// </summary>
        /// <param name="index">Nth row</param>
        /// <returns>row</returns>
        public BenchmarkELARow GetsRow(int index)
        {
            if (RowList.Count == 0)
            {//changed to debug for test cases where we want to assert that no search results were found
                Report.Write("No items were found in the search results column list.");
                return null;
            }
            return (BenchmarkELARow)RowList[index];
        }
    }
}
