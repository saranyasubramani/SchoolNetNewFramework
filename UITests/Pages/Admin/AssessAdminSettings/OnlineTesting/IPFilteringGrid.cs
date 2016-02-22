using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.Admin.AssessAdminSettings.OnlineTesting
{
    /// <summary>
    /// IPFiltering Grid on the Online Testing Page
    /// </summary>
    public class IPFilteringGrid : SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">initialize the grid?</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public IPFilteringGrid( string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
            : base( gridCssSelector, false, overrideControlPrefix)//override initializeGrid = false in base constructor, so I can call it later in this constructor
        {
            //override the column selector
            ByColumns = By.CssSelector(gridCssSelector + " thead > tr > td");
            ByHeaderRow = By.CssSelector(gridCssSelector + " thead > tr");
            ByRows = By.CssSelector(gridCssSelector + " tbody > tr");
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
                    dummy1.Text = "Name";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "Address";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "Enabled";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "Remove";
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
                    dummy1.Text = @"<td><strong><span>Name</span></strong></td>  
                        <td><strong><span>Address</span><span class='Required'>*</span></strong></td>                      
                        <td><strong><span>Enabled</span></strong></td>                            
                        <td><strong><span>Remove</span></strong></td>";
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
                    dummy1.FakeAttributeValue = "dd IP";
                    /*dummy1.Text = @"<td><input name='' value='dd IP' maxlength='255' id='' class='' onblur='' type='text'></td>
                                    <td><input type='text' id='' maxlength='20' value='172.24.166.148' name=''></td>";*/
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.FakeAttributeValue = "ab IP";
                    /*dummy2.Text = @"<td><input name='' value='ab IP' maxlength='255' id='' class='' onblur='' type='text'></td>
                                    <td><input type='text' id='' maxlength='20' value='172.24.166.154' name=''></td>";*/
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.FakeAttributeValue = "172.24.166.148";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.FakeAttributeValue = "172.24.166.154";
                    DummyElementDataRowList = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4 };
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
                var lineItem = new IPFilteringColumn( gridCssSelector, webElement, columnIndex, ControlPrefix);
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
                var lineItem = new IPFilteringRow( gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
                RowList.Add(lineItem);
                rowIndex++;
            }
        }


        /// <summary>
        /// gets the first row containing the text to find from the row list
        /// </summary>
        /// <param name="columnName">the column name</param>
        /// <param name="textToFind">the text to find</param>
        /// <returns>ConfigRow</returns>
        public IPFilteringRow GetsFirstRowContainingTextToFindFromList(string columnName, string textToFind)
        {
            List<IPFilteringRow> list = GetsRowsContainingTextToFindFromList(columnName, textToFind);
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
        /// <returns>list of ConfigRow</returns>
        public new List<IPFilteringRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No items were found in the grid column list.");
                return null;
            }
            else
            {
                List<IPFilteringRow> rowList = new List<IPFilteringRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    IPFilteringRow ipFilteringRow = (IPFilteringRow)row;
                    if (ipFilteringRow.Type != GridRowType.Header && ipFilteringRow.Type != GridRowType.Pagination)
                    {
                        //get the text by column name
                        if (columnName.Equals(IPFilteringColumnNames.Name))
                        {
                            text = ipFilteringRow.GetNameAttributeValue();
                        }
                        if (columnName.Equals(IPFilteringColumnNames.Address))
                        {
                            text = ipFilteringRow.GetAddressAttributeValue();
                        }

                        //if the text is not null
                        if (text != null)
                        {
                            //if the text contains the text to find
                            if (text.Contains(textToFind))
                            {
                                rowList.Add(ipFilteringRow);
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
