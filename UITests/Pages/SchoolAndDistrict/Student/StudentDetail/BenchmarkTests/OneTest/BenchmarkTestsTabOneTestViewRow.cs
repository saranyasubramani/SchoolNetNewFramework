using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.OneTest
{
    /// <summary>
    /// represents the benchmark tab - one test view - grid row.
    /// </summary>
    public class BenchmarkTestsTabOneTestViewRow : SNGridRow
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="columns">the list of columns</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public BenchmarkTestsTabOneTestViewRow(string gridCssSelector, IWebElement webElement, int index, GridRowType type, bool lastRow, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base(gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
            //ctl00_MainContent_StudentProfileDetailControl_ctl07_BenchmarkTestAnalysisControl_DataGridQuestions
            _lastRow = lastRow;
            //initElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Row text: " + Element.Text);
            ViewLink = new WebElementWrapper(ByViewLink);
            ItemNumber = new WebElementWrapper(ByItemNumber);
            StandardMappedTo = new WebElementWrapper(ByStandardMappedTo);
            StandardsDocument = new WebElementWrapper(ByStandardsDocument);
            CorrectAnswer = new WebElementWrapper(ByCorrectAnswer);
            StudentsAnswer = new WebElementWrapper(ByStudentsAnswer);
            TotalScore = new WebElementWrapper(ByTotalScore);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private bool _lastRow;
        //ctl00_MainContent_StudentProfileDetailControl_ctl07_BenchmarkTestAnalysisControl_DataGridQuestions_ctl03_ItemDetailsLinkButton
        private string _controlPrefix2 =
            "StudentProfileDetailControl_ctl07_BenchmarkTestAnalysisControl_DataGridQuestions_";
        private By ByViewLink { get { return By.Id(ControlPrefix + _controlPrefix2 + GetRowControlId() + "_ItemDetailsLinkButton"); } }
        private WebElementWrapper ViewLink { get; set; }
        private By ByItemNumber { get { return GetColumnLocator(BenchmarkTestsTabOneTestViewColumnNames.ItemNumber); } }
        private WebElementWrapper ItemNumber { get; set; }
        private By ByStandardMappedTo { get { return GetColumnLocator(BenchmarkTestsTabOneTestViewColumnNames.StandardMappedTo); } }
        private WebElementWrapper StandardMappedTo { get; set; }
        private By ByStandardsDocument { get { return GetColumnLocator(BenchmarkTestsTabOneTestViewColumnNames.StandardsDocument); } }
        private WebElementWrapper StandardsDocument { get; set; }
        private By ByCorrectAnswer { get { return GetColumnLocator(BenchmarkTestsTabOneTestViewColumnNames.CorrectAnswer); } }
        private WebElementWrapper CorrectAnswer { get; set; }
        private By ByStudentsAnswer { get { return GetColumnLocator(BenchmarkTestsTabOneTestViewColumnNames.StudentsAnswer); } }
        private WebElementWrapper StudentsAnswer { get; set; }
        private By ByTotalScore { get { return GetColumnLocator(BenchmarkTestsTabOneTestViewColumnNames.TotalScore); } }
        private WebElementWrapper TotalScore { get; set; }

        private string GetRowControlId()
        {
            string controlId = "";
            int rowIndex = Index;
            rowIndex++;
            if (rowIndex >= 0 && rowIndex <= 9)
                controlId = "ctl0" + rowIndex;
            if (rowIndex >= 10)
                controlId = "ctl" + rowIndex;
            return controlId;
        }

        /// <summary>
        /// get column locator
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        protected override By GetColumnLocator(string columnName)
        {
            By by = null;
            for (int i = 0; i < Columns.Count - 1; i++) //Don't look at last row, count - 1
            {
                if (Columns[i].Name.Equals(columnName))
                {
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > td:nth-of-type(" + (Columns[i].Index + 1) + ")");
                    break;
                }
            }
            //last row is different. Only 2 columns
            //TotalScore column is in column 2. 
            if (_lastRow)
            {
                if (columnName.Equals(BenchmarkTestsTabOneTestViewColumnNames.TotalScore))
                {
                    by = By.CssSelector(gridCssSelector + " tr:nth-of-type(" + (Index + 1) + ") > td:nth-of-type(2)");
                }
            }

            return by;
        }

        /// <summary>
        /// get the score text
        /// </summary>
        /// <returns>text</returns>
        public string GetTotalScore()
        {
            TotalScore.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                TotalScore.Text = FakeText;
            }
            return TotalScore.Text;
        }
    }
}
