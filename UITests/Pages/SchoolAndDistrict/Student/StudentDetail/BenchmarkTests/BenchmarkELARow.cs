using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests
{
    /// <summary>
    /// represents the benchmark tab - ela grid row.
    /// </summary>
    public class BenchmarkELARow : SNGridRow
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="driver">IWebDriver</param>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="columns">the list of columns</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public BenchmarkELARow(string gridCssSelector, IWebElement webElement, int gridIndex, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base(gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
            //ELA grid id:  SubjectGroup0
            _gridIndex = gridIndex;
            //InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Row text: " + Element.Text);
            TestName = new WebElementWrapper(ByTestName);
            Date = new WebElementWrapper(ByDate);
            Score = new WebElementWrapper(ByScore);
            ScoreGroup = new WebElementWrapper(ByScoreGroup);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        //ctl00_MainContent_StudentProfileDetailControl_ctl07_RepeaterBenchmarkReportsByTest_ctl00_BenchmarkTestReportControl_RepeaterByTest_ctl01_btnAdminViewItemAnalysis
        //ctl00_MainContent_StudentProfileDetailControl_ctl07_RepeaterBenchmarkReportsByTest_ctl00_BenchmarkTestReportControl_RepeaterByTest_ctl02_btnAdminViewItemAnalysis
        private string _controlPrefix2 =
            "StudentProfileDetailControl_ctl07_RepeaterBenchmarkReportsByTest_";
        private string _controlPrefix3 =
            "_BenchmarkTestReportControl_RepeaterByTest_";
        private int _gridIndex;
        private By ByTestName { get { return By.Id(ControlPrefix + _controlPrefix2 + GetGridControlId() + _controlPrefix3 + GetRowControlId() + "_btnAdminViewItemAnalysis"); } }
        private WebElementWrapper TestName { get; set; }
        private By ByDate { get { return GetColumnLocator(BenchmarkELAColumnNames.TestDate); } }
        private WebElementWrapper Date { get; set; }
        private By ByScore { get { return GetColumnLocator(BenchmarkELAColumnNames.TestScore); } }
        private WebElementWrapper Score { get; set; }
        private By ByScoreGroup { get { return GetColumnLocator(BenchmarkELAColumnNames.ScoreGroup); } }
        private WebElementWrapper ScoreGroup { get; set; }

        private string GetRowControlId()
        {
            string controlId = "";
            int rowIndex = Index;
            rowIndex++;
            if (rowIndex >= 0 && rowIndex <= 9)
                controlId = "ctl0" + rowIndex;
            if (rowIndex >= 10) // && rowIndex <= 99)
                controlId = "ctl" + rowIndex;
            return controlId;
        }

        private string GetGridControlId()
        {
            string controlId = "";
            //int rowIndex = Index;
            //rowIndex++;
            if (_gridIndex >= 0 && _gridIndex <= 9)
                controlId = "ctl0" + _gridIndex;
            if (_gridIndex >= 10)
                controlId = "ctl" + _gridIndex;
            return controlId;
        }

        /// <summary>
        /// get the test name text
        /// </summary>
        /// <returns>text</returns>
        public string GetTestName()
        {
            TestName.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                TestName.Text = FakeText;
            }
            return TestName.Text;
        }

        /// <summary>
        /// get test score text
        /// </summary>
        /// <returns>text</returns>
        public string GetTestScore()
        {
            Score.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                Score.Text = FakeText;
            }
            return Score.Text;
        }    
    }
}
