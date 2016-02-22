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

namespace UITests.Pages.Assess.Dashboard.ProfileHome.Tabs
{
    /// <summary>
    /// the assessment dashboard tab grids
    /// </summary>
    public class ProfileHomeTabGrid : SNGrid
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="initializeGrid">initialize the grid?</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ProfileHomeTabGrid(string gridCssSelector, bool initializeGrid = false, string overrideControlPrefix = null) 
            : base(gridCssSelector, initializeGrid, overrideControlPrefix)
        {
        }

        public override List<IWebElement> GetDummyElementsColumns()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementColumnList == null)
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    dummy1.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$TestName')'>Test Name</a>";
                    dummy1.FakeAttributeClass = "sortable";
                    DummyWebElement dummy2 = new DummyWebElement();
                    dummy2.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$TestCategory')'>Test Category</a>";
                    dummy2.FakeAttributeClass = "sortable"; 
                    DummyWebElement dummy3 = new DummyWebElement();
                    dummy3.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$OnlinePasscode')'>Online Passcode</a>";
                    dummy3.FakeAttributeClass = "sortable"; 
                    DummyWebElement dummy4 = new DummyWebElement();
                    dummy4.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$Assigned')'>Assigned</a>";
                    dummy4.FakeAttributeClass = "sortable"; 
                    DummyWebElement dummy5 = new DummyWebElement();
                    dummy5.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$Stage')'>Stage</a>";
                    dummy5.FakeAttributeClass = "sortable"; 
                    DummyWebElement dummy6 = new DummyWebElement();
                    dummy6.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$StartDate')'>Start Date</a>";
                    dummy6.FakeAttributeClass = "sortable active-descending"; 
                    DummyWebElement dummy7 = new DummyWebElement();
                    dummy7.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$SubjectName')'>Subject</a>";
                    dummy7.FakeAttributeClass = "sortable active-descending"; 
                    DummyWebElement dummy8 = new DummyWebElement();
                    dummy8.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$LoGrade')'>Grade</a>";
                    dummy8.FakeAttributeClass = "sortable"; 
                    DummyWebElement dummy9 = new DummyWebElement();
                    dummy9.Text = "Collection Status";
                    DummyWebElement dummy10 = new DummyWebElement();
                    dummy10.Text = "<a href='javascript:__doPostBack('ctl00$MainContent$ProfileControl$gridResults','Sort$GradebookStatus')'>Gradebook Updated</a>";
                    DummyWebElement dummy11 = new DummyWebElement();
                    dummy11.Text = "Student Performance";
                    DummyWebElement dummy12 = new DummyWebElement();
                    dummy12.Text = "Actions";
                    dummy12.FakeAttributeClass = "last-child"; 
                    DummyElementColumnList = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4, dummy5, dummy6, dummy7, dummy8, dummy9, dummy10, dummy11, dummy12 };
                }
            }
            return DummyElementColumnList;
        }
        public override List<IWebElement> GetDummyElementsHeaderRows()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                if (DummyElementHeaderRowList == null)
                {
                    DummyWebElement dummy1 = new DummyWebElement();
                    dummy1.Text = "Test Name";
                    DummyElementHeaderRowList = new List<IWebElement> { dummy1 };
                }
            }
            return DummyElementHeaderRowList;
        }
        public override List<IWebElement> GetDummyElementsDataRows()
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

        public override void SetColumnLists()
        {
            base.SetColumnLists();
            int columnIndex = 0;
            foreach (var webElement in WebElementColumns)
            {
                Report.Write("GridColumn by index: " + columnIndex);
                var lineItem = new ProfileHomeTabColumn(gridCssSelector, webElement, columnIndex, ControlPrefix);
                ColumnList.Add(lineItem);
                columnIndex++;
            }
        }
        public override void SetRowLists()
        {
            base.SetRowLists();
            int rowIndex = 0;
            foreach (var webElement in WebElementRows)
            {
                Report.Write("GridRow by index: " + rowIndex);
                GridRowType rowType = GetGridRowType(rowIndex);
                Report.Write("GridRowType: " + rowType);
                var lineItem = new ProfileHomeTabRow(gridCssSelector, webElement, rowIndex, rowType, ColumnList, ControlPrefix);
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
        public new List<ProfileHomeTabRow> GetsRowsContainingTextToFindFromList(string columnName, string textToFind)
        {
            if (RowList.Count == 0)
            {
                Assert.Fail("No items were found in the search results column list.");
                return null;
            }
            else
            {
                List<ProfileHomeTabRow> rowList = new List<ProfileHomeTabRow>();
                string text = null;
                int index = 0;
                foreach (var row in RowList)
                {
                    ProfileHomeTabRow assessDashboardTabRow = (ProfileHomeTabRow)row;
                    //get the text by column name
                    if (columnName.Equals(ProfileHomeTabColumnNames.Actions))
                    {
                        text = assessDashboardTabRow.GetActions();
                    }
                    if (columnName.Equals(ProfileHomeTabColumnNames.Assigned))
                    {
                        text = assessDashboardTabRow.GetAssigned();
                    }
                    if (columnName.Equals(ProfileHomeTabColumnNames.CollectionStatus))
                    {
                        text = assessDashboardTabRow.GetCollectionStatus();
                    }
                    if (columnName.Equals(ProfileHomeTabColumnNames.Grade))
                    {
                        text = assessDashboardTabRow.GetGrade();
                    }
                    if (columnName.Equals(ProfileHomeTabColumnNames.GradebookUpdated))
                    {
                        text = assessDashboardTabRow.GetGradebookUpdated();
                    }
                    if (columnName.Equals(ProfileHomeTabColumnNames.OnlinePasscode))
                    {
                        text = assessDashboardTabRow.GetOnlinePasscode();
                    }
                    if (columnName.Equals(ProfileHomeTabColumnNames.Stage))
                    {
                        text = assessDashboardTabRow.GetStage();
                    }
                    if (columnName.Equals(ProfileHomeTabColumnNames.StartDate))
                    {
                        text = assessDashboardTabRow.GetStartDate();
                    }
                    if (columnName.Equals(ProfileHomeTabColumnNames.StudentPerformance))
                    {
                        text = assessDashboardTabRow.GetStudentPerformance();
                    }
                    if (columnName.Equals(ProfileHomeTabColumnNames.Subject))
                    {
                        text = assessDashboardTabRow.GetSubject();
                    }
                    if (columnName.Equals(ProfileHomeTabColumnNames.TestCategory))
                    {
                        text = assessDashboardTabRow.GetTestCategory();
                    }
                    if (columnName.Equals(ProfileHomeTabColumnNames.TestName))
                    {
                        text = assessDashboardTabRow.GetTestName();
                    }
                    //if the text is not null
                    if (text != null)
                    {
                        //if the text contains the text to find
                        if (text.Contains(textToFind))
                        {
                            rowList.Add(assessDashboardTabRow);
                        }
                    }
                }
                //may return empty row list if text is not found
                return rowList;
            }
        }
    }
}
