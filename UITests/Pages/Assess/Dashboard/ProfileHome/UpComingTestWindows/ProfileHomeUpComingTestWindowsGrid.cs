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

namespace UITests.Pages.Assess.Dashboard.ProfileHome.UpComingTestWindows
{
    /// <summary>
    /// Upcoming Test Windows Results Grid on the Assess Dashboard Page
    /// </summary>
    public class ProfileHomeUpComingTestWindowsGrid: SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">boolean flag indicating whether to initialize the grid while loading the page. Default is false - Not to Initialize Grid</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ProfileHomeUpComingTestWindowsGrid(string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
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
                    dummy1.Text = "Test Window Name";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "Start Date";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "End Date";                    

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
                    dummy1.Text = "<th>Test Window Name</th><th>Start Date</th><th>End Date</th>";

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
                    dummy1.Text = "Automated Test Window 1";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "Automated Test Window 2";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "Automated Test Window 3";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "Automated Test Window 4";
                    DummyWebElement dummy5 = new DummyWebElement();
                    dummy5.Text = "Automated Test Window 5";

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
                var lineItem = new ProfileHomeUpComingTestWindowsColumn(gridCssSelector, webElement, columnIndex, ControlPrefix);
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
                var lineItem = new ProfileHomeUpComingTestWindowsRow(gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
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
        /// <returns>AssessDashboardUpComingTestWindowsRow</returns>
        public ProfileHomeUpComingTestWindowsRow GetsFirstRowContainingTextToFindFromList(string columnName, string textToFind)
        {
            List<ProfileHomeUpComingTestWindowsRow> list = GetsRowsContainingTextToFindFromList(columnName, textToFind);
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
        /// <returns>list of AssessDashboardUpComingTestWindowsRow</returns>
        public new List<ProfileHomeUpComingTestWindowsRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No items were found in the search results column list.");
                return null;
            }

            else
            {
                List<ProfileHomeUpComingTestWindowsRow> assessDashboardUpComingTestWindowsRowList = new List<ProfileHomeUpComingTestWindowsRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    ProfileHomeUpComingTestWindowsRow assessDashboardUpComingTestWindowsRow = (ProfileHomeUpComingTestWindowsRow)row;

                    if (assessDashboardUpComingTestWindowsRow.Type != GridRowType.Header && assessDashboardUpComingTestWindowsRow.Type != GridRowType.Pagination)
                    {
                        //get the text by column name
                        if (columnName.Equals(ProfileHomeUpComingTestWindowsColumnNames.TestWindowName))
                        {
                            text = assessDashboardUpComingTestWindowsRow.GetTestWindowName();
                        }

                        if (columnName.Equals(ProfileHomeUpComingTestWindowsColumnNames.StartDate))
                        {
                            text = assessDashboardUpComingTestWindowsRow.GetTestWindowStartDate();
                        }

                        if (columnName.Equals(ProfileHomeUpComingTestWindowsColumnNames.EndDate))
                        {
                            text = assessDashboardUpComingTestWindowsRow.GetTestWindowEndDate();
                        }

                        //if the text is not null
                        if (text != null)
                        {
                            //if the text contains the text to find
                            if (text.Contains(textToFind))
                            {
                                assessDashboardUpComingTestWindowsRowList.Add(assessDashboardUpComingTestWindowsRow);
                            }
                        }
                    }                    
                }

                //may return empty row list if text is not found
                return assessDashboardUpComingTestWindowsRowList;
            }
        }
    }
}
