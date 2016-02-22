using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.Admin.GeneralSettings.Config
{
    /// <summary>
    /// Config Grid on the Config Page
    /// </summary>
    public class ConfigGrid : SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">initialize the grid?</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ConfigGrid( string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
            : base( gridCssSelector, false, overrideControlPrefix)//override initializeGrid = false in base constructor, so I can call it later in this constructor
        {
            //override the column selector
            ByColumns = By.CssSelector(gridCssSelector + " tr.DataGridHeader > td");
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
                    dummy1.Text = "";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "Name";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "Value";
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
                    dummy1.Text = "<td class='TableHead'><a href='javascript:__doPostBack('ctl00$MainContent$ctl00$AdminControl$SnDataGridConfig$ctl01$Linkbutton1','')' class='CommandButton' id='ctl00_MainContent_ctl00_AdminControl_SnDataGridConfig_ctl01_Linkbutton1'><img alt='Add new element' src='/images/icon_add.gif'></a></td><td class='TableHead'>Name</td><td class='TableHead'>Value</td>";
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
                    dummy1.Text = "<td><span id='ctl00_MainContent_ctl00_AdminControl_SnDataGridConfig_ctl02_LabelName'>AdvancedItemStatistics</span></td><td> 				True 			</td>";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "<td><span id='ctl00_MainContent_ctl00_AdminControl_SnDataGridConfig_ctl03_LabelName'>AnswerKeyOnlyInTestTunnelEnabled</span></td><td> 				True 			</td>";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "<td><span id='ctl00_MainContent_ctl00_AdminControl_SnDataGridConfig_ctl27_LabelName'>TestEngineEnabled</span></td><td> 				True 			</td>";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "<td><span id='ctl00_MainContent_ctl00_AdminControl_SnDataGridConfig_ctl28_LabelName'>TestEngineEnabled</span></td><td> 				true 			</td>";
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
                var lineItem = new ConfigColumn( gridCssSelector, webElement, columnIndex, ControlPrefix);
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
                var lineItem = new ConfigRow( gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
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
        public ConfigRow GetsFirstRowContainingTextToFindFromList(string columnName, string textToFind)
        {
            List<ConfigRow> list = GetsRowsContainingTextToFindFromList(columnName, textToFind);
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
        public new List<ConfigRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No items were found in the grid column list.");
                return null;
            }
            else
            {
                List<ConfigRow> rowList = new List<ConfigRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    ConfigRow configRow = (ConfigRow)row;
                    if (configRow.Type != GridRowType.Header && configRow.Type != GridRowType.Pagination)
                    {
                        //get the text by column name
                        if (columnName.Equals(ConfigColumnnNames.Name))
                        {
                            text = configRow.GetName();
                        }
                        if (columnName.Equals(ConfigColumnnNames.Value))
                        {
                            text = configRow.GetValue();
                        }

                        //if the text is not null
                        if (text != null)
                        {
                            //if the text contains the text to find
                            if (text.Contains(textToFind))
                            {
                                rowList.Add(configRow);
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
