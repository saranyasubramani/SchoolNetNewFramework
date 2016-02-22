using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using Core.Views.Grids;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Controls;

namespace UITests.Pages.Assess.TestWindow.PlanHome
{
    /// <summary>
    /// Plan Home form
    /// </summary>
    public class PlanHomeForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override Control Prefix</param>
        public PlanHomeForm(string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            //Subject = new Subject(PageNames.TestWindowPlanHome);
            //GradeLevel = new GradeLevel(PageNames.TestWindowPlanHome, this.ControlPrefix);
            SubjectElement subject = new SubjectElement(PageNames.TestWindowPlanHome);
            SubjectSelect = subject.SelectElement;
            GradeLevelElement gradeLevel = new GradeLevelElement(PageNames.TestWindowPlanHome);
            GradeFromSelect = gradeLevel.FromSelectElement;
            GradeToSelect = gradeLevel.ToSelectElement;
            TestWindowName = new WebElementWrapper(ByTestWindowName);
            DateFrom = new WebElementWrapper(ByDateFrom);
            DateTo = new WebElementWrapper(ByDateTo);
            Grid = new PlanHomeGrid(GridLocator);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new PlanHomeData Data
        {
            get
            {
                return (PlanHomeData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        //ctl00_MainContent_TestWindowSearchResults1_TestWindowFinderSearch1_ButtonGo
        public override By BySubmit { get { return By.Id(ControlPrefix + "TestWindowSearchResults1_TestWindowFinderSearch1_ButtonGo"); } }
        //id="ctl00_MainContent_TestWindowSearchResults1_TestWindowFinderSearch1_TextBoxTestName"
        private By ByTestWindowName { get { return By.Id(ControlPrefix + "TestWindowSearchResults1_TestWindowFinderSearch1_TextBoxTestName"); } }
        private WebElementWrapper TestWindowName { get; set; }
        //private Subject Subject { get; set; }
        //private GradeLevel GradeLevel { get; set; }
        public SelectElementWrapper SubjectSelect { get; private set; }
        public SelectElementWrapper GradeFromSelect { get; private set; }
        public SelectElementWrapper GradeToSelect { get; private set; }
        //ctl00_MainContent_TestWindowSearchResults1_TestWindowFinderSearch1_TextBoxAdminStartDate
        private By ByDateFrom { get { return By.Id(ControlPrefix + "TestWindowSearchResults1_TestWindowFinderSearch1_TextBoxAdminStartDate"); } }
        private WebElementWrapper DateFrom { get; set; }
        //ctl00_MainContent_TestWindowSearchResults1_TestWindowFinderSearch1_TextBoxAdminEndDate
        private By ByDateTo { get { return By.Id(ControlPrefix + "TestWindowSearchResults1_TestWindowFinderSearch1_TextBoxAdminEndDate"); } }
        private WebElementWrapper DateTo { get; set; }
        //ctl00_MainContent_TestWindowSearchResults1_TestWindowFinderResults1_gridResults
        private string GridLocator { get { return "#" + ControlPrefix + "TestWindowSearchResults1_TestWindowFinderResults1_gridResults"; } }
        public PlanHomeGrid Grid { get; set; }


        #region Grid

        /// <summary>
        /// Find the test window name and click on the link 
        /// </summary>
        public void SelectTestWindowName()
        {
            string testWindowName = Data.TestWindowName;
            Grid.SetGridLists();

            //List<PlanHomeRow> testWindowFound =
            //    Grid.GetsRowsContainingTextToFindFromList(PlanHomeColumnNames.TestWindowName, testWindowName);
            //get the first row to prevent index out of range for null values
            PlanHomeRow testWindowFound = Grid.GetsFirstRowContainingTextToFindFromList(PlanHomeColumnNames.TestWindowName, testWindowName);

            if (testWindowFound != null)
            {
                Report.Write("Attempting to select test window " + testWindowName);
                //testWindowFound[0].SelectColumn(PlanHomeColumnNames.TestWindowName);
                testWindowFound.SelectColumn(PlanHomeColumnNames.TestWindowName);
            }

        }

        /// <summary>
        /// Click on the Link Test icon 
        /// </summary>
        public void SelectLinkTestIcon()
        {
            string testWindowName = Data.TestWindowName;
            Grid.SetGridLists();

            List<PlanHomeRow> testWindowFound =
                Grid.GetsRowsContainingTextToFindFromList(PlanHomeColumnNames.TestWindowName, testWindowName);

            if (testWindowFound != null)
            {
                Report.Write("Found test window: " + testWindowName + ". Attempting to click on link test icon.");
                testWindowFound[0].SelectLinkTest();
            }
        }

        /// <summary>
        /// Click on the Create Test icon 
        /// </summary>
        public void SelectCreateTestIcon()
        {
            string testWindowName = Data.TestWindowName;
            Grid.SetGridLists();

            List<PlanHomeRow> testWindowFound =
                Grid.GetsRowsContainingTextToFindFromList(PlanHomeColumnNames.TestWindowName, testWindowName);

            if (testWindowFound != null)
            {
                Report.Write("Found test window: " + testWindowName + ". Attempting to click on create test icon.");
                testWindowFound[0].SelectCreateTest();
            }
        }

        /// <summary>
        /// Click on the Test Window Name column header to rearrange the column in ascending order
        /// </summary>
        public void SortTestWindowNameAscendingOrder()
        {
            Grid.SetGridLists();
            Grid.SortAscending(Data.ColumnName.ToString());
        }

        /// <summary>
        /// Click on the Test Window Name column header to rearrange the column in descending order
        /// </summary>
        public void SortTestWindowNameDescendingOrder()
        {
            Grid.SetGridLists();
            Grid.SortDescending(Data.ColumnName.ToString());
        }

        /// <summary>
        /// Select X results per page  
        /// </summary>
        public PlanHomePage SelectResultsPerPage()
        {
            Grid.SetGridLists();
            Report.Write("Attempting to click on " + Data.ResultsPerPage + " result per page.");
            Grid.SelectResultsPerPage(Data.ResultsPerPage);

            //page postback
            return new PlanHomePage();
        }

        /// <summary>
        /// Select next page 
        /// </summary>
        public PlanHomePage SelectNextPage()
        {
            Grid.SetGridLists();
            Report.Write("Attempting to click next page.");
            Grid.ClickNextPage();

            //page postback
            return new PlanHomePage();
        }

        /// <summary>
        /// Select previous page 
        /// </summary>
        public PlanHomePage SelectPreviousPage()
        {
            Grid.SetGridLists();
            Report.Write("Attempting to click previous page.");
            Grid.ClickPreviousPage();

            //page postback
            return new PlanHomePage();
        }

        /// <summary>
        /// Select last page 
        /// </summary>
        public PlanHomePage SelectLastPage()
        {
            Grid.SetGridLists();
            Report.Write("Attempting to click next page.");
            Grid.ClickLastPage();

            //page postback
            return new PlanHomePage();
        }

        /// <summary>
        /// Find a test window containing text for a column. Must specified data in PlanHomeData object. This will return the first row found
        /// TestWindowName, Subject, DateFrom, DateTo  are the text you are searching for. 
        /// ColumnName the name of column to search for this text
        /// </summary>
        public PlanHomeRow FindTestWindowUsingColumn()
        {
            Grid.SetGridLists();
            string textToFind = "";

            if (Data.ColumnName == PlanHomeColumnNames.TestWindowName)
            {
                textToFind = Data.TestWindowName;
            }
            if (Data.ColumnName == PlanHomeColumnNames.Subject)
            {
                textToFind = Data.Subject;
            }
            if (Data.ColumnName == PlanHomeColumnNames.StartDate)
            {
                textToFind = Data.DateFrom;
            }
            if (Data.ColumnName == PlanHomeColumnNames.EndDate)
            {
                textToFind = Data.DateTo;
            }

            Report.Write("Attempting to find " + textToFind + " in column " + Data.ColumnName);

            List<PlanHomeRow> testWindowFound =
                Grid.GetsRowsContainingTextToFindFromList(Data.ColumnName, textToFind);

            if (testWindowFound.Count > 0)
            {
                Report.Write("Found the text " + textToFind);
                return testWindowFound[0];
            }

            return null;
        }

        /// <summary>
        /// get page result label
        /// </summary>
        /// <returns></returns>
        public string GetPageResultLabel()
        {
            return Grid.GetPageResults();
        }

        #endregion


        /// <summary>
        /// Verified test window grid return some result. It make sure the column "test window name" 
        /// had some value and that it is not empty. Index is the N-th row to check. Index 1, 2 ,3 ....
        /// Make sure the index is pointing to a data row. 
        /// Index 1 is pagination row
        /// Index 2 is header row
        /// Index 3 is the data row 
        /// 
        /// Return true when found the row N-th with some values in the "test window name" column
        /// </summary>
        public bool VerifyTestWindowNameColumnHadSomeValues(int index)
        {
            Grid.SetGridLists();
            SNGridRow row = Grid.GetRowFromList(index - 1);
            string text = "";

            if (row.Type == GridRowType.Data)
            {
                PlanHomeRow PlanHomeRow = (PlanHomeRow)row;
                text = PlanHomeRow.GetTestWindowName();
            }

            // if test window name is not emtpy, values exist
            if (!string.IsNullOrEmpty(text))
                return true;

            return false;
        }

        //implemented methods
        public override void ClearForm()
        {
            TestWindowName.Clear();
            SubjectSelect.Wait(3).SelectByText("All subjects");
            GradeFromSelect.Wait(5).SelectByText("");
            GradeToSelect.Wait(5).SelectByText("");
            DateFrom.Clear();
            DateTo.Clear();
        }

        public override void InputFormFields()
        {
            if (Data.TestWindowName != null)
            {
                TestWindowName.SendKeys(Data.TestWindowName);
            }
            if (Data.Subject != null)
            {
                SubjectSelect.Wait(3).SelectByText(Data.Subject);
            }
            if (Data.GradeLow != null)
            {
                GradeFromSelect.Wait(5);
                GradeFromSelect.Wait(5).SelectByText(Data.GradeLow);
            }
            if (Data.GradeHigh != null)
            {
                GradeToSelect.Wait(5);
                GradeToSelect.Wait(5).SelectByText(Data.GradeHigh);
            }
            if (Data.DateFrom != null)
            {
                DateFrom.SendKeys(Data.DateFrom);
            }
            if (Data.DateTo != null)
            {
                DateTo.SendKeys(Data.DateTo);
            }
        }
    }
}
