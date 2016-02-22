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

namespace UITests.Pages.Assess.Dashboard.ProfileHome.ScheduledTests
{
    /// <summary>
    /// Scheduled Tests Results Grid on the Assess Dashboard Page
    /// </summary>
    public class ProfileHomeScheduledTestsGrid: SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">boolean flag indicating whether to initialize the grid while loading the page. Default is false - Not to Initialize Grid</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ProfileHomeScheduledTestsGrid(string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
            : base(gridCssSelector, initializeGrid)
        {
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
                    dummy2.Text = "Start Date";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "End Date";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "";

                    DummyElementColumnList = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4 };
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
                    dummy1.Text = "<th>Test Name</th><th>Start Date</th><th>End Date</th><th></th>";

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
                    dummy1.Text = "Automated Test 1";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "Automated Test 2";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "Automated Test 3";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "Automated Test 4";
                    DummyWebElement dummy5 = new DummyWebElement();
                    dummy5.Text = "Automated Test 5";

                    DummyElementDataRowList = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4, dummy5 };
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
                var lineItem = new ProfileHomeScheduledTestsColumn(gridCssSelector, webElement, columnIndex, ControlPrefix);
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
                var lineItem = new ProfileHomeScheduledTestsRow(gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
                RowList.Add(lineItem);
                rowIndex++;
            }
        }

        /// <summary>
        /// Gets the Row type of the Specified Row.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
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
        /// gets the first row containing the text to find from the row list
        /// </summary>
        /// <param name="columnName">the column name</param>
        /// <param name="textToFind">the text to find</param>
        /// <returns>ProfileHomeScheduledTestsRow</returns>
        public ProfileHomeScheduledTestsRow GetsFirstRowContainingTextToFindFromList(string columnName, string textToFind)
        {
            List<ProfileHomeScheduledTestsRow> list = GetsRowsContainingTextToFindFromList(columnName, textToFind);
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
        /// <returns>list of ProfileHomeScheduledTestsRow</returns>
        public new List<ProfileHomeScheduledTestsRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No items were found in the search results column list.");
                return null;
            }

            else
            {
                List<ProfileHomeScheduledTestsRow> assessDashboardScheduledTestsRowList = new List<ProfileHomeScheduledTestsRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    ProfileHomeScheduledTestsRow assessDashboardScheduledTestsRow = (ProfileHomeScheduledTestsRow)row;

                    if (assessDashboardScheduledTestsRow.Type != GridRowType.Header && assessDashboardScheduledTestsRow.Type != GridRowType.Pagination)
                    {
                        //get the text by column name
                        if (columnName.Equals(ProfileHomeScheduledTestsColumnNames.TestName))
                        {
                            text = assessDashboardScheduledTestsRow.GetTestName();
                        }

                        if (columnName.Equals(ProfileHomeScheduledTestsColumnNames.StartDate))
                        {
                            text = assessDashboardScheduledTestsRow.GetTestStartDate();
                        }

                        if (columnName.Equals(ProfileHomeScheduledTestsColumnNames.EndDate))
                        {
                            text = assessDashboardScheduledTestsRow.GetTestEndDate();
                        }

                        if (columnName.Equals(ProfileHomeScheduledTestsColumnNames.AnswerSheets))
                        {
                            text = assessDashboardScheduledTestsRow.GetTestAnswerSheetsLinkText();
                        }

                        //if the text is not null
                        if (text != null)
                        {
                            //if the text contains the text to find
                            if (text.Contains(textToFind))
                            {
                                assessDashboardScheduledTestsRowList.Add(assessDashboardScheduledTestsRow);
                            }
                        }
                    }                   
                }

                //may return empty row list if text is not found
                return assessDashboardScheduledTestsRowList;
            }
        }
    }
}
