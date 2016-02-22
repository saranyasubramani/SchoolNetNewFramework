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

namespace UITests.Pages.Assess.TestWindow.PlanHome
{
    /// <summary>
    /// the plan home grid
    /// </summary>
    public class PlanHomeGrid : SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">initialize the grid?</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public PlanHomeGrid(string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
            : base(gridCssSelector, initializeGrid)
        {
            //ctl00_MainContent_TestWindowSearchResults1_TestWindowFinderResults1_gridResults
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
                var lineItem = new PlanHomeColumn(gridCssSelector, webElement, columnIndex, ControlPrefix);
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
                var lineItem = new PlanHomeRow(gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
                RowList.Add(lineItem);
                rowIndex++;
            }
        }

        /// <summary>
        /// gets the first row containing the text to find from the row list
        /// </summary>
        /// <param name="columnName">the column name</param>
        /// <param name="textToFind">the text to find</param>
        /// <returns>PlanHomeRow</returns>
        public PlanHomeRow GetsFirstRowContainingTextToFindFromList(string columnName, string textToFind)
        {
            List<PlanHomeRow> list = GetsRowsContainingTextToFindFromList(columnName, textToFind);
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
        public new List<PlanHomeRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {//changed to debug for test cases where we want to assert that no search results were found
                Report.Write("No items were found in the search results column list.");
                return null;
            }
            else
            {
                List<PlanHomeRow> rowList = new List<PlanHomeRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    if (row.Type == GridRowType.Data)
                    {
                        PlanHomeRow PlanHomeRow = (PlanHomeRow)row;

                        if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                        {
                            PlanHomeRow.FakeText = textToFind;
                        }

                        //get the text by column name
                        if (columnName.Equals(PlanHomeColumnNames.TestWindowName))
                        {
                            text = PlanHomeRow.GetTestWindowName();
                            //Debug.WriteLine("martin actual text: " + text);
                            //Debug.WriteLine("martin expected text to find: " + textToFind);
                        }
                        if (columnName.Equals(PlanHomeColumnNames.Subject))
                        {
                            text = PlanHomeRow.GetSubject();
                            //Debug.WriteLine("martin actual text: " + text);
                            //Debug.WriteLine("martin expected text to find: " + textToFind);
                        }
                        if (columnName.Equals(PlanHomeColumnNames.Grade))
                        {
                            text = PlanHomeRow.GetGrade();
                            //Debug.WriteLine("martin actual text: " + text);
                            //Debug.WriteLine("martin expected text to find: " + textToFind);
                        }
                        if (columnName.Equals(PlanHomeColumnNames.TestStage))
                        {
                            text = PlanHomeRow.GetGrade();
                            //Debug.WriteLine("martin actual text: " + text);
                            //Debug.WriteLine("martin expected text to find: " + textToFind);
                        }
                        if (columnName.Equals(PlanHomeColumnNames.StartDate))
                        {
                            text = PlanHomeRow.GetStartDate();
                            //Debug.WriteLine("martin actual text: " + text);
                            //Debug.WriteLine("martin expected text to find: " + textToFind);
                        }
                        if (columnName.Equals(PlanHomeColumnNames.EndDate))
                        {
                            text = PlanHomeRow.GetEndDate();
                            //Debug.WriteLine("martin actual text: " + text);
                            //Debug.WriteLine("martin expected text to find: " + textToFind);
                        }
                        //if the text is not null
                        if (text != null)
                        {
                            //if the text contains the text to find
                            if (text.Contains(textToFind))
                            {
                                rowList.Add(PlanHomeRow);
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
