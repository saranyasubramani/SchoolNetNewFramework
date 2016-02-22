using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.Assess.Schedule.ViewAssignmentSummary
{
    /// <summary>
    /// the view assignment summary grid
    /// </summary>
    public class ViewAssignmentSummaryGrid : SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">initialize the grid?</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewAssignmentSummaryGrid(  string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
            : base( gridCssSelector, initializeGrid)
        {
            //gridCssSelector  ="div.section_container > div:nth-of-type(3)";
            ByGridIdentifier = By.CssSelector(gridCssSelector);
            // div.section_container > div:nth-of-type(3) div.row .section_title
            ByColumns = By.CssSelector(gridCssSelector + " div.row .section_title");
            // "div.section_container > div:nth-of-type(3) > div:nth-of-type(1)"
            ByHeaderRow = By.CssSelector(gridCssSelector + " > div:nth-of-type(1)");
            //("div.section_container > div:nth-of-type(3) > div.row:not(.space3)");
            ByRows = By.CssSelector(gridCssSelector + " div.row:not(.space3)");

            // Doesn't exist
            //ByPaginationRows = By.CssSelector(gridCssSelector + " tr.DataGridPager");
            //ByPaginationLinks = By.CssSelector(gridCssSelector + " tr:first-of-type table tr > td");
            InitializeGrid = true;
            InitElements();
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
                    //DummyWebElement dummy1 = new DummyWebElement();
                    ////dummy1.Text = "<input type='checkbox' onclick='handleSelectAllAvailableSection();' title='Select/Deselect All' id='chkSelectAllAvailableSection'>";
                    //dummy1.Text = "";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "Courses";
                    DummyElementColumnList = new List<IWebElement> { dummy2 };
                    //DummyElementColumnList = new List<IWebElement> { dummy1, dummy2 };
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
                    dummy1.Text = "Courses";
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
                    dummy1.Text = "ACTING 1";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "ACTING 2";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "AMERICAN LIT & COMP 11";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "AP ENGLISH LANGUAGE & COMPOSITION";
                    DummyWebElement dummy5 = new DummyWebElement();
                    dummy5.Text = "AP ENGLISH LITERATURE & COMPOSITION";
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
                Report.Write("GridColumn by index: " + columnIndex);
                var lineItem = new ViewAssignmentSummaryColumn( gridCssSelector, webElement, columnIndex, ControlPrefix);
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
                var lineItem = new ViewAssignmentSummaryRow( gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
                RowList.Add(lineItem);
                rowIndex++;
            }
        }

        /// <summary>
        /// gets a list of rows containing the text to find from the row list
        /// </summary>
        /// <param name="columnName">the column name</param>
        /// <param name="textToFind">the text to find</param>
        /// <returns>list of GridRow</returns>
        public new List<ViewAssignmentSummaryRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No items were found in the search results column list.");
                return null;
            }
            else
            {
                List<ViewAssignmentSummaryRow> rowList = new List<ViewAssignmentSummaryRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    ViewAssignmentSummaryRow ViewAssignmentSummaryRow = (ViewAssignmentSummaryRow)row;
                    //get the text by column name
                    if (columnName.Equals(ViewAssignmentSummaryColumnNames.Courses))
                    {
                        text = ViewAssignmentSummaryRow.GetCourse();
                        //Debug.WriteLine("martin actual text: " + text);
                        //Debug.WriteLine("martin expected text to find: " + textToFind);
                    }
                    //if the text is not null
                    if (text != null)
                    {
                        //if the text contains the text to find
                        if (text.Contains(textToFind))
                        {
                            rowList.Add(ViewAssignmentSummaryRow);
                        }
                    }
                }
                //may return empty row list if text is not found
                return rowList;
            }
        }
    }
}
