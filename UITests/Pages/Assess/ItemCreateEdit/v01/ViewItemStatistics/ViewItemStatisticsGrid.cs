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

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ViewItemStatistics
{
    /// <summary>
    /// IPFiltering Grid on the Online Testing Page
    /// </summary>
    public class ViewItemStatisticsGrid : SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">initialize the grid?</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewItemStatisticsGrid(string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
            : base(gridCssSelector, false, overrideControlPrefix)//override initializeGrid = false in base constructor, so I can call it later in this constructor
        {
            //override the column selector
            ByColumns = By.CssSelector(gridCssSelector + " tr.DataGridAltRow > td, " + gridCssSelector + " tr.DataGridRow > td");
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
                    dummy1.Text = "Items";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "";
                    DummyElementColumnList = new List<IWebElement> { dummy1, dummy2 };
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
                    dummy1.Text = @"
			            <div style='padding-bottom:5px; display:block'>&nbsp;</div>
			            <div id='divPassageContent_0' class='ItemPassageControl_Maximized' style='overflow:hidden;'>
				            <div style='padding-bottom:5px'>
				                <b><a id='ctl00_MainContent_ItemPassageControl_gridPassages_ctl02_LinkButtonPassageTitle' passage_id='55464' href='javascript:__doPostBack('ctl00$MainContent$ItemPassageControl$gridPassages$ctl02$LinkButtonPassageTitle','')'>Web Test Passage: 25376</a></b>
				            </div>
				            <div style='padding-bottom:5px' class='ie_image_fix line-height-normal'>
				                <p>The FIFA World Cup (also called the Football World Cup, the Soccer World Cup, or simply the World Cup) is an international association football competition contested by the senior men's national teams of the members of Federation International de Football Association (FIFA), the sport's global governing body. The championship has been awarded every four years since the inaugural tournament in 1930, except in 1942 and 1946 when it was not held because of the Second World War. The current champions are Spain, who won the 2010 tournament. The current format of the tournament involves 32 teams competing for the title at venues within the host nation(s) over a period of about a month - this phase is often called the World Cup Finals. A qualification phase, which currently takes place over the preceding three years, is used to determine which teams qualify for the tournament together with the host nation(s).The 19 World Cup tournaments have been won by eight different national teams. Brazil have won five times, and they are the only team to have played in every tournament. The other World Cup winners are Italy, with four titles; Germany, with three titles; Argentina and inaugural winners Uruguay, with two titles each; and England, France, and Spain, with one title each. The World Cup is the world's most widely viewed sporting event; an estimated 715.1 million people watched the final match of the 2006 FIFA World Cup held in Germany. The next three World Cups will be hosted by Brazil in 2014, Russia in 2018, and Qatar in 2022</p>
				            </div>
			            </div>
			        ";
                    DummyElementDataRowList = new List<IWebElement> { dummy1 };
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
                var lineItem = new ViewItemStatisticsColumn(gridCssSelector, webElement, columnIndex, ControlPrefix);
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
                Report.Write("GridRow by index: " +  rowIndex);
                GridRowType rowType = GetGridRowType(rowIndex);
                Report.Write("GridRowType: " + rowType);
                var lineItem = new ViewItemStatisticsRow(gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
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
        public ViewItemStatisticsRow GetsFirstRowContainingTextToFindFromList(string columnName, string textToFind)
        {
            List<ViewItemStatisticsRow> list = GetsRowsContainingTextToFindFromList(columnName, textToFind);
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
        public new List<ViewItemStatisticsRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No items were found in the grid column list.");
                return null;
            }
            else
            {
                List<ViewItemStatisticsRow> rowList = new List<ViewItemStatisticsRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    ViewItemStatisticsRow viewItemStatisticsRow = (ViewItemStatisticsRow)row;
                    if (viewItemStatisticsRow.Type != GridRowType.Header && viewItemStatisticsRow.Type != GridRowType.Pagination)
                    {
                        //get the text by column name
                        if (columnName.Equals(ViewItemStatisticsColumnNames.Items))
                        {
                            text = viewItemStatisticsRow.GetItems();
                        }
                        if (columnName.Equals(ViewItemStatisticsColumnNames.Content))
                        {
                            text = viewItemStatisticsRow.GetContent();
                        }

                        //if the text is not null
                        if (text != null)
                        {
                            //if the text contains the text to find
                            if (text.Contains(textToFind))
                            {
                                rowList.Add(viewItemStatisticsRow);
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
