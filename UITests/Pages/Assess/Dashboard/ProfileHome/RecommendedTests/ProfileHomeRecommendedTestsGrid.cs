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

namespace UITests.Pages.Assess.Dashboard.ProfileHome.RecommendedTests
{
    /// <summary>
    /// Recommended Tests Results Grid on the Assess Dashboard Page - This Grid only shows up for School Admins.
    /// </summary>
    public class ProfileHomeRecommendedTestsGrid: SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="driver">IWebDriver</param>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">boolean flag indicating whether to initialize the grid while loading the page. Default is false - Not to Initialize Grid</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ProfileHomeRecommendedTestsGrid(string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
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
                    dummy4.Text = "Scores Due Date";
                    DummyWebElement dummy5 = new DummyWebElement();
                    dummy5.Text = "Assignment Status";

                    DummyElementColumnList = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4, dummy5 };
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
                    dummy1.Text = "<th>Test Name</th><th>Start Date</th><th>End Date</th><th>Scores Due Date</th><th>Assignment Status</th>";

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
                var lineItem = new ProfileHomeRecommendedTestsColumn(gridCssSelector, webElement, columnIndex, ControlPrefix);
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
                var lineItem = new ProfileHomeRecommendedTestsRow(gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
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
        /// <returns>ProfileHomeRecommendedTestsRow</returns>
        public ProfileHomeRecommendedTestsRow GetsFirstRowContainingTextToFindFromList(string columnName, string textToFind)
        {
            List<ProfileHomeRecommendedTestsRow> list = GetsRowsContainingTextToFindFromList(columnName, textToFind);
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
        /// <returns>list of ProfileHomeRecommendedTestsRow</returns>
        public new List<ProfileHomeRecommendedTestsRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No items were found in the search results column list.");
                return null;
            }

            else
            {
                List<ProfileHomeRecommendedTestsRow> assessDashboardRecommendedTestsRowList = new List<ProfileHomeRecommendedTestsRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    ProfileHomeRecommendedTestsRow assessDashboardRecommendedTestsRow = (ProfileHomeRecommendedTestsRow)row;

                    if (assessDashboardRecommendedTestsRow.Type != GridRowType.Header && assessDashboardRecommendedTestsRow.Type != GridRowType.Pagination)
                    {
                        //get the text by column name
                        if (columnName.Equals(ProfileHomeRecommendedTestsColumnNames.TestName))
                        {
                            text = assessDashboardRecommendedTestsRow.GetTestName();
                        }

                        if (columnName.Equals(ProfileHomeRecommendedTestsColumnNames.StartDate))
                        {
                            text = assessDashboardRecommendedTestsRow.GetTestStartDate();
                        }

                        if (columnName.Equals(ProfileHomeRecommendedTestsColumnNames.EndDate))
                        {
                            text = assessDashboardRecommendedTestsRow.GetTestEndDate();
                        }

                        if (columnName.Equals(ProfileHomeRecommendedTestsColumnNames.ScoresDueDate))
                        {
                            text = assessDashboardRecommendedTestsRow.GetTestScoresDueDate();
                        }

                        if (columnName.Equals(ProfileHomeRecommendedTestsColumnNames.AssignmentStatus))
                        {
                            text = assessDashboardRecommendedTestsRow.GetTestAssignmentStatus();
                        }

                        //if the text is not null
                        if (text != null)
                        {
                            //if the text contains the text to find
                            if (text.Contains(textToFind))
                            {
                                assessDashboardRecommendedTestsRowList.Add(assessDashboardRecommendedTestsRow);
                            }
                        }
                    }                   
                }

                //may return empty row list if text is not found
                return assessDashboardRecommendedTestsRowList;
            }
        }
    }
}
