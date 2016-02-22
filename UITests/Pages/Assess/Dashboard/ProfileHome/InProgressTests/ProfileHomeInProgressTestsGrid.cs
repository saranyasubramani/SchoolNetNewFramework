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

namespace UITests.Pages.Assess.Dashboard.ProfileHome.InProgressTests
{
    /// <summary>
    /// In Progress Tests Results Grid on the Assess Dashboard Page
    /// </summary>
    public class ProfileHomeInProgressTestsGrid: SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">boolean flag indicating whether to initialize the grid while loading the page. Default is false - Not to Initialize Grid</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ProfileHomeInProgressTestsGrid(string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
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
                    dummy2.Text = "End Date";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "Scores Due Date";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "Collection Status";

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
                    dummy1.Text = "<th>Test Name</th><th>End Date</th><th>Scores Due Date</th><th>Collection Status</th>";

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
                var lineItem = new ProfileHomeInProgressTestsColumn(gridCssSelector, webElement, columnIndex, ControlPrefix);
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
                var lineItem = new ProfileHomeInProgressTestsRow(gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
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
        /// <returns>AssessDashboardInProgressTestsRow</returns>
        public ProfileHomeInProgressTestsRow GetsFirstRowContainingTextToFindFromList(string columnName, string textToFind)
        {
            List<ProfileHomeInProgressTestsRow> list = GetsRowsContainingTextToFindFromList(columnName, textToFind);
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
        /// <returns>list of AssessDashboardInProgressTestsRow</returns>
        public new List<ProfileHomeInProgressTestsRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No items were found in the search results column list.");
                return null;
            }

            else
            {
                List<ProfileHomeInProgressTestsRow> assessDashboardInProgressTestsRowList = new List<ProfileHomeInProgressTestsRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    ProfileHomeInProgressTestsRow assessDashboardInProgressTestsRow = (ProfileHomeInProgressTestsRow)row;

                    if (assessDashboardInProgressTestsRow.Type != GridRowType.Header && assessDashboardInProgressTestsRow.Type != GridRowType.Pagination)
                    {
                        //get the text by column name
                        if (columnName.Equals(ProfileHomeInProgressTestsColumnNames.TestName))
                        {
                            text = assessDashboardInProgressTestsRow.GetTestName();
                        }

                        if (columnName.Equals(ProfileHomeInProgressTestsColumnNames.EndDate))
                        {
                            text = assessDashboardInProgressTestsRow.GetTestEndDate();
                        }

                        if (columnName.Equals(ProfileHomeInProgressTestsColumnNames.ScoresDueDate))
                        {
                            text = assessDashboardInProgressTestsRow.GetTestScoresDueDate();
                        }

                        if (columnName.Equals(ProfileHomeInProgressTestsColumnNames.CollectionStatus))
                        {
                            text = assessDashboardInProgressTestsRow.GetTestCollectionStatus();
                        }

                        //if the text is not null
                        if (text != null)
                        {
                            //if the text contains the text to find
                            if (text.Contains(textToFind))
                            {
                                assessDashboardInProgressTestsRowList.Add(assessDashboardInProgressTestsRow);
                            }
                        }
                    }                   
                }

                //may return empty row list if text is not found
                return assessDashboardInProgressTestsRowList;
            }
        }
    }
}
