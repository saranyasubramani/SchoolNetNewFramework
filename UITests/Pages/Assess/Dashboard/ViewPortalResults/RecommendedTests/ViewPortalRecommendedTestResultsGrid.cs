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

namespace UITests.Pages.Assess.Dashboard.ViewPortalResults.RecommendedTests
{
    /// <summary>
    /// View Portal Recommended Tests Results Grid
    /// </summary>
    public class ViewPortalRecommendedTestResultsGrid : SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">boolean flag indicating whether to initialize the grid while loading the page. Default is false - Not to Initialize Grid</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewPortalRecommendedTestResultsGrid(string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
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
                    dummy1.FakeAttributeClass = "sortable";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "Test Category";
                    dummy2.FakeAttributeClass = "sortable";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "Subject";
                    dummy3.FakeAttributeClass = "sortable";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "Grade Level";
                    dummy4.FakeAttributeClass = "sortable";
                    DummyWebElement dummy5 = new DummyWebElement();
                    dummy5.Text = "Start Date";
                    dummy5.FakeAttributeClass = "sortable ascending";
                    DummyWebElement dummy6 = new DummyWebElement();
                    dummy6.Text = "End Date";
                    dummy6.FakeAttributeClass = "sortable";
                    DummyWebElement dummy7 = new DummyWebElement();
                    dummy7.Text = "Scores Due Date";
                    dummy7.FakeAttributeClass = "sortable";
                    DummyWebElement dummy8 = new DummyWebElement();
                    dummy8.Text = "Assignment Status";

                    DummyElementColumnList = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4, dummy5, dummy6, dummy7, dummy8 };
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
                    dummy1.Text = "<th>Test Name</th><th>Test Category</th><th>Subject</th><th>Grade Level</th><th>Start Date</th><th>End Date</th><th>Scores Due Date</th><th>Assignment Status</th>";

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
                var lineItem = new ViewPortalRecommendedTestResultsColumn(gridCssSelector, webElement, columnIndex, ControlPrefix);
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
                var lineItem = new ViewPortalRecommendedTestResultsRow(gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
                RowList.Add(lineItem);
                rowIndex++;
            }
        }

        /// <summary>
        /// gets the first row containing the text to find from the row list
        /// </summary>
        /// <param name="columnName">the column name</param>
        /// <param name="textToFind">the text to find</param>
        /// <returns>ViewPortalRecommendedTestResultsRow</returns>
        public ViewPortalRecommendedTestResultsRow GetsFirstRowContainingTextToFindFromList(string columnName, string textToFind)
        {
            List<ViewPortalRecommendedTestResultsRow> list = GetsRowsContainingTextToFindFromList(columnName, textToFind);
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
        /// <returns>list of ViewPortalRecommendedTestResultsRow</returns>
        public new List<ViewPortalRecommendedTestResultsRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No items were found in the search results column list.");
                return null;
            }

            else
            {
                List<ViewPortalRecommendedTestResultsRow> viewPortalRecommendedTestResultsRowList = new List<ViewPortalRecommendedTestResultsRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    ViewPortalRecommendedTestResultsRow viewPortalRecommendedTestResultsRow = (ViewPortalRecommendedTestResultsRow)row;

                    if (viewPortalRecommendedTestResultsRow.Type != GridRowType.Header && viewPortalRecommendedTestResultsRow.Type != GridRowType.Pagination)
                    {
                        //get the text by column name
                        if (columnName.Equals(ViewPortalRecommendedTestResultsColumnNames.TestName))
                        {
                            text = viewPortalRecommendedTestResultsRow.GetTestName();
                        }

                        if (columnName.Equals(ViewPortalRecommendedTestResultsColumnNames.TestCategory))
                        {
                            text = viewPortalRecommendedTestResultsRow.GetTestCategory();
                        }

                        if (columnName.Equals(ViewPortalRecommendedTestResultsColumnNames.Subject))
                        {
                            text = viewPortalRecommendedTestResultsRow.GetTestSubject();
                        }

                        if (columnName.Equals(ViewPortalRecommendedTestResultsColumnNames.GradeLevel))
                        {
                            text = viewPortalRecommendedTestResultsRow.GetTestGradeLevel();
                        }

                        if (columnName.Equals(ViewPortalRecommendedTestResultsColumnNames.StartDate))
                        {
                            text = viewPortalRecommendedTestResultsRow.GetTestStartDate();
                        }

                        if (columnName.Equals(ViewPortalRecommendedTestResultsColumnNames.EndDate))
                        {
                            text = viewPortalRecommendedTestResultsRow.GetTestEndDate();
                        }

                        if (columnName.Equals(ViewPortalRecommendedTestResultsColumnNames.ScoresDueDate))
                        {
                            text = viewPortalRecommendedTestResultsRow.GetTestScoresDueDate();
                        }

                        if (columnName.Equals(ViewPortalRecommendedTestResultsColumnNames.AssignmentStatus))
                        {
                            text = viewPortalRecommendedTestResultsRow.GetTestAssignmentStatus();
                        }

                        //if the text is not null
                        if (text != null)
                        {
                            //if the text contains the text to find
                            if (text.Contains(textToFind))
                            {
                                viewPortalRecommendedTestResultsRowList.Add(viewPortalRecommendedTestResultsRow);
                            }
                        }
                    }
                }

                //may return empty row list if text is not found
                return viewPortalRecommendedTestResultsRowList;
            }
        }
    }
}
