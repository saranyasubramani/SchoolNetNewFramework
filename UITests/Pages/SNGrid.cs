using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Core.Views.Grids;
using Core.Framework;
using Core.Tools.WebDriver;

namespace UITests.Pages
{
    /// <summary>
    /// The grid component
    /// </summary>
    public class SNGrid : Grid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="driver">IWebDriver</param>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public SNGrid(string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null)
            : base()
        {
            DriverCommands = new SNDriverCommands();
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitializeGrid = initializeGrid;
            this.gridCssSelector = gridCssSelector;
            ByGridIdentifier = By.CssSelector(gridCssSelector);
            ByColumns = By.CssSelector(gridCssSelector + " tr.DataGridHeader > th");
            ByHeaderRow = By.CssSelector(gridCssSelector + " tr.DataGridHeader");
            ByRows = By.CssSelector(gridCssSelector + " tr.DataGridAltRow, " + gridCssSelector + " tr.DataGridRow");
            ByPaginationRows = By.CssSelector(gridCssSelector + " tr.DataGridPager");
            ByPaginationLinks = By.CssSelector(gridCssSelector + " tr:first-of-type table tr > td");
            InitElements();
        }

        public override void InitElements()
        {
            GridIdentifier = new WebElementWrapper(ByGridIdentifier);
            Columns = new WebElementWrapper(ByColumns);
            HeaderRow = new WebElementWrapper(ByHeaderRow);
            Rows = new WebElementWrapper(ByRows);
            PaginationRows = new WebElementWrapper(ByPaginationRows);
            PaginationLinks = new WebElementWrapper(ByPaginationLinks);
            if (InitializeGrid)
            {
                SetGridLists();
            }
            ResultsLabel = new WebElementWrapper(ByResultsLabel);
            ResultsPerPageSelect = new SelectElementWrapper(new WebElementWrapper(ByResultsPerPageSelect));
            FirstTopLink = new WebElementWrapper(ByFirstTopLink);
            PreviousTopLink = new WebElementWrapper(ByPreviousTopLink);
            NextTopLink = new WebElementWrapper(ByNextTopLink);
            LastTopLink = new WebElementWrapper(ByLastTopLink);
            FirstBottomLink = new WebElementWrapper(ByFirstBottomLink);
            PreviousBottomLink = new WebElementWrapper(ByPreviousBottomLink);
            NextBottomLink = new WebElementWrapper(ByNextBottomLink);
            LastBottomLink = new WebElementWrapper(ByLastBottomLink);
        }

        protected SNDriverCommands DriverCommands { get; set; }

        public bool InitializeGrid { get; set; }
        protected string gridCssSelector { get; set; }
        protected By ByGridIdentifier { get; set; }
        protected WebElementWrapper GridIdentifier { get; set; }
        protected By ByColumns { get; set; }
        protected WebElementWrapper Columns { get; set; }
        protected By ByHeaderRow { get; set; }
        protected WebElementWrapper HeaderRow { get; set; }
        protected By ByRows { get; set; }
        protected WebElementWrapper Rows { get; set; }
        protected By ByPaginationRows { get; set; }
        protected WebElementWrapper PaginationRows { get; set; }
        public By ByPaginationLinks { get; set; }
        protected WebElementWrapper PaginationLinks { get; set; }
        protected ReadOnlyCollection<IWebElement> WebElementPaginationLinks { get; set; }
        protected ReadOnlyCollection<IWebElement> WebElementColumns { get; set; }
        protected List<SNGridColumn> ColumnList { get; set; }
        public List<IWebElement> DummyElementColumnList { get; set; }
        protected ReadOnlyCollection<IWebElement> WebElementHeaderRows { get; set; }
        protected ReadOnlyCollection<IWebElement> WebElementDataRows { get; set; }
        protected ReadOnlyCollection<IWebElement> WebElementPaginationRows { get; set; }
        protected ReadOnlyCollection<IWebElement> WebElementRows { get; set; }
        protected List<SNGridRow> RowList { get; set; }
        public List<IWebElement> DummyElementHeaderRowList { get; set; }
        public List<IWebElement> DummyElementDataRowList { get; set; }
        public List<IWebElement> DummyElementPaginationRowList { get; set; }
        public bool HasPaginationRows { get; private set; }
        public bool HasHeaderRow { get; private set; }
        public int PaginationLinkCount { get; private set; }
        /// <summary>
        /// fake text
        /// </summary>
        public string FakeText { get; set; }

        public void SetDummyElementsColumns(List<IWebElement> list)
        {
            DummyElementColumnList = list;
        }
        public virtual List<IWebElement> GetDummyElementsColumns()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementColumnList == null)
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    dummy1.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$TestName')'>Test Name</a>";
                    dummy1.FakeAttributeClass = "sortable";
                    DummyWebElement dummy2 = new DummyWebElement();
                    //dummy2.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$TestCategory')'>Test Category</a>";
                    dummy2.Text = "Actions";
                    dummy2.FakeAttributeClass = "sortable last-child";
                    /*
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$OnlinePasscode')'>Online Passcode</a>";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$Assigned')'>Assigned</a>";
                    DummyWebElement dummy5 = new DummyWebElement();
                    dummy5.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$Stage')'>Stage</a>";
                    DummyWebElement dummy6 = new DummyWebElement();
                    dummy6.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$StartDate')'>Start Date</a>";
                    DummyWebElement dummy7 = new DummyWebElement();
                    dummy7.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$SubjectName')'>Subject</a>";
                    DummyWebElement dummy8 = new DummyWebElement();
                    dummy8.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$LoGrade')'>Grade</a>";
                    DummyWebElement dummy9 = new DummyWebElement();
                    dummy9.Text = "Collection Status";
                    DummyWebElement dummy10 = new DummyWebElement();
                    dummy10.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$GradebookStatus')'>Gradebook Updated</a>";
                    DummyWebElement dummy11 = new DummyWebElement();
                    dummy11.Text = "Student Performance";
                    DummyWebElement dummy12 = new DummyWebElement();
                    dummy12.Text = "Actions";
                    */
                    DummyElementColumnList = new List<IWebElement> { dummy1, dummy2 };//, dummy3, dummy4, dummy5, dummy6, dummy7, dummy8, dummy9, dummy10, dummy11, dummy12 };
                }
            }
            return DummyElementColumnList;
        }
        public void SetDummyElementsHeaderRows(List<IWebElement> list)
        {
            DummyElementHeaderRowList = list;
        }
        public virtual List<IWebElement> GetDummyElementsHeaderRows()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementHeaderRowList == null)
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    dummy1.Text = "<th>column 1</th><th>column 2</th><th>column 3</th>";

                    DummyElementHeaderRowList = new List<IWebElement> { dummy1 };
                }
            }
            return DummyElementHeaderRowList;
        }
        public void SetDummyElementsDataRows(List<IWebElement> list)
        {
            DummyElementDataRowList = list;
        }
        public virtual List<IWebElement> GetDummyElementsDataRows()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementDataRowList == null)
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    dummy1.Text = "<div><a href='h ttps://team-automation-st.sndev.net/Assess/ViewTestDetails.aspx?testid=42567'>!AutomationTest24160</a></div>";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "<div><a href='h ttps://team-automation-st.sndev.net/Assess/ViewTestDetails.aspx?testid=42568'>!AutomationTest24160</a></div>";
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "<div><a href='h ttps://team-automation-st.sndev.net/Assess/ViewTestDetails.aspx?testid=42569'>!AutomationTest24160</a></div>";
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "<div><a href='h ttps://team-automation-st.sndev.net/Assess/ViewTestDetails.aspx?testid=42570'>!AutomationTest24160</a></div>";

                    DummyElementDataRowList = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4 };
                }
            }
            return DummyElementDataRowList;
        }
        public void SetDummyElementsPaginationRows(List<IWebElement> list)
        {
            DummyElementPaginationRowList = list;
        }
        public virtual List<IWebElement> GetDummyElementsPaginationRows()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementPaginationRowList == null)
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    dummy1.Text = @"
                    <div style='float:right;'>
                      <table>
                        <tbody>
                          <tr>
                            <td><a class='aspNetDisabled'><img src='/images/first.gif'>First</a></td>
                            <td><a class='aspNetDisabled'><img src='/images/previous.gif'>Prev</a></td>
                            <td><a href="">Next 25 <img src='/images/next.gif'></a></td>
                            <td><a href="">Last <img src='/images/last.gif'></a></td>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                    <div style='float:left;padding:3px;'>
                      <strong>Results</strong> 1 - 25 of 1,000
                    </div>
                    ";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = @"
                    <div style='float:right;'>
                      <table>
                        <tbody>
                          <tr>
                            <td><a class='aspNetDisabled'><img src='/images/first.gif'>First</a></td>
                            <td><a class='aspNetDisabled'><img src='/images/previous.gif'>Prev</a></td>
                            <td><a href="">Next 25 <img src='/images/next.gif'></a></td>
                            <td><a href="">Last <img src='/images/last.gif'></a></td>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                    <div style='float:left;padding:3px;'>
                      <select id=''><option value='10'>10</option></select>
                    </div>
                    ";
                    DummyElementPaginationRowList = new List<IWebElement> { dummy1, dummy2 };
                }
            }
            return DummyElementPaginationRowList;
        }

        public virtual void SetGridLists()
        {
            GridIdentifier.Wait(3);
            SetColumnLists();
            SetRowLists();
        }
        public void DebugSetGridLists()
        {
            int columnIndex = 0;
            foreach (var webElement in WebElementColumns)
            {
                //Debug.WriteLine("GridColumn by index: '{0}'.", columnIndex);
                var lineItem = new SNGridColumn(gridCssSelector, webElement, columnIndex, ControlPrefix);
                ColumnList.Add(lineItem);
                columnIndex++;
            }

            int rowIndex = 0;
            foreach (var webElement in WebElementRows)
            {
                //Debug.WriteLine("GridRow by index: '{0}'.", rowIndex);
                GridRowType rowType = GetGridRowType(rowIndex);
                //Debug.WriteLine("GridRowType: '{0}'.", rowType);
                var lineItem = new SNGridRow(gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
                RowList.Add(lineItem);
                rowIndex++;
            }
        }
        public virtual void SetColumnLists()
        {
            ColumnList = new List<SNGridColumn>();

            WebElementColumns = Columns.WaitForElements(5);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementColumnList == null)
                {
                    DummyElementColumnList = GetDummyElementsColumns();
                }
                WebElementColumns = new ReadOnlyCollection<IWebElement>(DummyElementColumnList);
            }
            /* EXTEND GridColumn WITH YOUR OWN CLASS,
             * THEN CALL THIS BASE METHOD FIRST,
             * THEN OVERRIDE THIS METHOD IN YOUR OWN CODE
            base.SetColumnLists();
            int columnIndex = 0;
            foreach (var webElement in WebElementColumns)
            {
                var lineItem = new GridColumn(Driver, gridCssSelector, webElement, columnIndex, ControlPrefix);
                ColumnList.Add(lineItem);
                columnIndex++;
            }
            */
        }
        public virtual void SetRowLists()
        {
            RowList = new List<SNGridRow>();

            List<IWebElement> rows = new List<IWebElement>();

            //get pagination rows
            try
            {
                WebElementPaginationRows = PaginationRows.WaitForElements(5);
                if (WebElementPaginationRows != null)
                {
                    HasPaginationRows = true;
                    //get the pagination links
                    WebElementPaginationLinks = PaginationLinks.WaitForElements(5);
                }
                else
                {
                    HasPaginationRows = false;
                }
                if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                {
                    if (DummyElementPaginationRowList == null)
                    {
                        DummyElementPaginationRowList = GetDummyElementsPaginationRows();
                    }
                    WebElementPaginationRows = new ReadOnlyCollection<IWebElement>(DummyElementPaginationRowList);
                }
                //set the top pagination row as the 1st row
                rows.Add(WebElementPaginationRows[0]);
            }
            catch (Exception e)
            {
                //or else the pagination rows do not exist, so do nothing
                HasPaginationRows = false;
            }

            //get the header row
            try
            {
                WebElementHeaderRows = HeaderRow.WaitForElements(5);
                if (WebElementHeaderRows != null)
                {
                    HasHeaderRow = true;
                }
                else
                {
                    HasHeaderRow = false;
                }
                if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                {
                    if (DummyElementHeaderRowList == null)
                    {
                        DummyElementHeaderRowList = GetDummyElementsHeaderRows();
                    }
                    WebElementHeaderRows = new ReadOnlyCollection<IWebElement>(DummyElementHeaderRowList);
                }
                //add the header row
                rows.AddRange(WebElementHeaderRows);
            }
            catch (Exception e)
            {
                //or else the header row does not exist, so do nothing
                HasHeaderRow = false;
            }

            //get the data rows
            WebElementDataRows = Rows.WaitForElements(5);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementDataRowList == null)
                {
                    DummyElementDataRowList = GetDummyElementsDataRows();
                }
                WebElementDataRows = new ReadOnlyCollection<IWebElement>(DummyElementDataRowList);
            }
            //add the data rows
            rows.AddRange(WebElementDataRows);

            //if the pagination rows exist
            if (WebElementPaginationRows != null)
            {
                //if there are a top and bottom pagination rows
                if (WebElementPaginationRows.Count == 2)
                {
                    //set the bottom pagination row as the last row
                    rows.Add(WebElementPaginationRows[1]);
                }
            }
            //if the pagination links exist
            if (WebElementPaginationLinks != null)
            {
                //get the pagination link count
                PaginationLinkCount = WebElementPaginationLinks.Count;
            }
            else
            {
                PaginationLinkCount = 0;
            }
            Report.Write("Grid Pagination link count: " + PaginationLinkCount);

            //create the IWebElement row collection
            WebElementRows = new ReadOnlyCollection<IWebElement>(rows);

            /* EXTEND GridRow WITH YOUR OWN CLASS,
             * THEN CALL THIS BASE METHOD FIRST,
             * THEN OVERRIDE THIS METHOD IN YOUR OWN CODE
            base.SetRowLists();
            int rowIndex = 0;
            foreach (var webElement in WebElementRows)
            {
                GridRowType rowType = GetGridRowType(rowIndex);
                var lineItem = new GridRow(Driver, gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
                RowList.Add(lineItem);
                rowIndex++;
            }
            */
        }

        public virtual GridRowType GetGridRowType(int rowIndex)
        {
            GridRowType rowType = GridRowType.Data;
            //if 1st row
            if (rowIndex == 0)
            {   //if has pagination
                if (HasPaginationRows == true)
                {   //then pagination row
                    rowType = GridRowType.Pagination;
                }//or else NO pagination
                else
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
            }//if 2nd row
            if (rowIndex == 1)
            {   //if has pagination
                if (HasPaginationRows == true)
                {   //if has header
                    if (HasHeaderRow == true)
                    {   //then header row
                        rowType = GridRowType.Header;
                    }//or else NO header
                    else
                    {   //then data row
                        rowType = GridRowType.Data;
                    }
                }//or else NO pagination
                else
                {   //then data row, not header row
                    rowType = GridRowType.Data;
                }
            }//if last row
            if (rowIndex == (WebElementRows.Count - 1))
            {   //if has pagination
                if (HasPaginationRows == true)
                {   //then pagination row
                    rowType = GridRowType.Pagination;
                }//or else NO pagination
                else
                {   //then data row
                    rowType = GridRowType.Data;
                }
            }
            return rowType;
        }

        /// <summary>
        /// get the column list
        /// </summary>
        /// <returns>List of GridColumn</returns>
        public List<SNGridColumn> GetColumnList()
        {
            return ColumnList;
        }

        /// <summary>
        /// gets a column from the column list
        /// </summary>
        /// <param name="index">the index of the row</param>
        /// <returns>GridColumn</returns>
        public SNGridColumn GetColumnFromList(int index)
        {
            if (ColumnList.Count == 0)
            {
                Assert.Fail("No columns were found in the column list.");
                return null;
            }
            else
            {
                return ColumnList[index];
            }
        }

        /// <summary>
        /// get the row list
        /// </summary>
        /// <returns>List of GridRow</returns>
        public List<SNGridRow> GetRowList()
        {
            return RowList;
        }

        /// <summary>
        /// gets a row from the row list
        /// </summary>
        /// <param name="index">the index of the row</param>
        /// <returns>GridRow</returns>
        public SNGridRow GetRowFromList(int index)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No rows were found in the row list.");
                return null;
            }
            else
            {
                return RowList[index];
            }
        }

        /// <summary>
        /// gets a list of rows containing the text to find from the row list
        /// </summary>
        /// <param name="columnName">the column name</param>
        /// <param name="textToFind">the text to find</param>
        /// <returns>list of GridRow</returns>
        public virtual List<SNGridRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No rows were found in the row list.");
                return null;
            }
            else
            {
                List<SNGridRow> rowList = new List<SNGridRow>();
                string text = null;
                foreach (var row in RowList)
                {
                    //get the text by column name
                    if (columnName.Equals(SNGridColumnNames.TestName))
                    {
                        text = row.GetTestName();
                    }
                    else if (columnName.Equals(SNGridColumnNames.Actions))
                    {
                        text = row.GetActions();
                    }
                    //if the text is not null
                    if (text != null)
                    {
                        //if the text contains the text to find
                        if (text.Contains(textToFind))
                        {
                            rowList.Add(row);
                        }
                    }
                }
                //may return empty row list if text is not found
                return rowList;
            }
        }

        protected void SortOrder(string columnName, GridColumnSortType fromSortType, GridColumnSortType toSortType)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No rows were found in the row list.");
            }
            else
            {
                //click to sort
                foreach (var row in RowList)
                {
                    if (row.Type.Equals(GridRowType.Header))
                    {
                        foreach (var column in row.Columns)
                        {
                            if (column.Name.Equals(columnName))
                            {
                                //if the type is sortable
                                if ((column.SortType == GridColumnSortType.Sortable)
                                    || (column.SortType == fromSortType))
                                {
                                    //then sort the column
                                    Report.Write("Clicking to sort the column.");
                                    row.SelectColumn(columnName);
                                    InitializeGrid = true;
                                    InitElements();
                                    //return;
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
                //check the sort type
                foreach (var row in RowList)
                {
                    if (row.Type.Equals(GridRowType.Header))
                    {
                        foreach (var column in row.Columns)
                        {
                            if (column.Name.Equals(columnName))
                            {
                                //if the type is NOT sorted correctly
                                if (column.SortType != toSortType)
                                {
                                    //then sort the column again
                                    Report.Write("Clicking to re-sort the column again.");
                                    row.SelectColumn(columnName);
                                    InitializeGrid = true;
                                    InitElements();
                                    //return;
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
        public void SortAscending(string columnName)
        {
            SortOrder(columnName, GridColumnSortType.Descending, GridColumnSortType.Ascending);
        }
        public void SortDescending(string columnName)
        {
            SortOrder(columnName, GridColumnSortType.Ascending, GridColumnSortType.Descending);
        }

        public By ByResultsLabel { get { return By.CssSelector(gridCssSelector + " > tbody > tr:first-of-type"); } }
        protected WebElementWrapper ResultsLabel { get; set; }
        public By ByResultsPerPageSelect { get { return By.CssSelector(gridCssSelector + " .DataGridResultsPerPage > select"); } }
        protected SelectElementWrapper ResultsPerPageSelect { get; set; }

        public By ByFirstTopLink { get { return By.CssSelector(gridCssSelector + " tr:first-of-type table tr > td:first-of-type > a"); } }
        protected WebElementWrapper FirstTopLink { get; set; }
        public By ByPreviousTopLink { get { return By.CssSelector(gridCssSelector + " tr:first-of-type table tr > td:nth-of-type(2) > a"); } }
        protected WebElementWrapper PreviousTopLink { get; set; }
        public By ByNextTopLink { get { return By.CssSelector(gridCssSelector + " tr:first-of-type table tr > td:nth-of-type(3) > a"); } }
        protected WebElementWrapper NextTopLink { get; set; }
        public By ByLastTopLink { get { return By.CssSelector(gridCssSelector + " tr:first-of-type table tr > td:last-of-type > a"); } }
        protected WebElementWrapper LastTopLink { get; set; }

        public By ByFirstBottomLink { get { return By.CssSelector(gridCssSelector + " tr:last-of-type table tr > td:first-of-type > a"); } }
        protected WebElementWrapper FirstBottomLink { get; set; }
        public By ByPreviousBottomLink { get { return By.CssSelector(gridCssSelector + " tr:last-of-type table tr > td:nth-of-type(2) > a"); } }
        protected WebElementWrapper PreviousBottomLink { get; set; }
        public By ByNextBottomLink { get { return By.CssSelector(gridCssSelector + " tr:last-of-type table tr > td:nth-of-type(3) > a"); } }
        protected WebElementWrapper NextBottomLink { get; set; }
        public By ByLastBottomLink { get { return By.CssSelector(gridCssSelector + " tr:last-of-type table tr > td:last-of-type > a"); } }
        protected WebElementWrapper LastBottomLink { get; set; }


        public string GetPageResults()
        {
            ResultsLabel.Wait(3);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                ResultsLabel.Text = FakeText;
            }
            return ResultsLabel.Text;
        }
        public void SelectResultsPerPage(string resultsPerPage)
        {
            ResultsPerPageSelect.Wait(3).SelectByText(resultsPerPage);
            DriverCommands.WaitAndMeasurePageLoadTime(60, 30);
            InitElements();
        }
        public void SelectResultsPerPage()
        {
            //TODO: add data object
        }

        private bool IsEnabled(WebElementWrapper element)
        {
            bool isEnabled = true;
            //use wait until exists because Dev uses 2 different 'a' tags for each link, and they toggle which is enabled
            element.WaitUntilExists(3);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                element.FakeAttributeClass = FakeText;
            }
            if (element.GetAttribute("class").Trim().ToLower().Contains("aspNetDisabled".ToLower()))
            {
                return false;
            }
            return isEnabled;
        }
        public bool IsFirstPageEnabled
        {
            get
            {
                return IsEnabled(FirstTopLink);
            }
        }
        public void ClickFirstPage()
        {
            if (PaginationLinkCount == 4)
            {
                if (IsFirstPageEnabled)
                {
                    FirstTopLink.Wait(3).Click();
                    DriverCommands.WaitAndMeasurePageLoadTime(60, 30);
                    InitElements();
                }
            }
        }
        public bool IsPreviousPageEnabled
        {
            get
            {
                bool isEnabled;
                if (PaginationLinkCount == 4)
                {
                    isEnabled = IsEnabled(PreviousTopLink);
                }
                else
                {
                    isEnabled = IsEnabled(FirstTopLink);
                }
                return isEnabled;
            }
        }
        public void ClickPreviousPage()
        {
            if (PaginationLinkCount == 2)
            {
                if (IsFirstPageEnabled)
                {
                    FirstTopLink.Wait(3).Click();
                    DriverCommands.WaitAndMeasurePageLoadTime(60, 30);
                    InitElements();
                }
            }
            if (PaginationLinkCount == 4)
            {
                if (IsPreviousPageEnabled)
                {
                    PreviousTopLink.Wait(3).Click();
                    DriverCommands.WaitAndMeasurePageLoadTime(60, 30);
                    InitElements();
                }
            }
        }
        public bool IsNextPageEnabled
        {
            get
            {
                bool isEnabled;
                if (PaginationLinkCount == 4)
                {
                    isEnabled = IsEnabled(NextTopLink);
                }
                else
                {
                    isEnabled = IsEnabled(LastTopLink);
                }
                return isEnabled;
            }
        }
        public void ClickNextPage()
        {
            if (PaginationLinkCount == 2)
            {
                if (IsLastPageEnabled)
                {
                    LastTopLink.Wait(3).Click();
                    DriverCommands.WaitAndMeasurePageLoadTime(60, 30);
                    InitElements();
                }
            }
            if (PaginationLinkCount == 4)
            {
                if (IsNextPageEnabled)
                {
                    NextTopLink.Wait(3).Click();
                    DriverCommands.WaitAndMeasurePageLoadTime(60, 30);
                    InitElements();
                }
            }
        }
        public bool IsLastPageEnabled
        {
            get
            {
                return IsEnabled(LastTopLink);
            }
        }
        public void ClickLastPage()
        {
            if (PaginationLinkCount == 4)
            {
                if (IsLastPageEnabled)
                {
                    LastTopLink.Wait(3).Click();
                    DriverCommands.WaitAndMeasurePageLoadTime(60, 30);
                    InitElements();
                }
            }
        }
    }
}
