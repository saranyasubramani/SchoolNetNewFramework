using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.ItemResponse;

namespace UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.OneTest
{
    /// <summary>
    /// the benchmark tests tab detail
    /// </summary>
    public class BenchmarkTestsTabOneTestViewForm : SNForm
    {
        /// <summary>
        /// the benchmark tests tab constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public BenchmarkTestsTabOneTestViewForm( string overrideControlPrefix = null)
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
            TestDate = new WebElementWrapper( ByTestDate);
            Score = new WebElementWrapper( ByScore);
            ScoreGroup = new WebElementWrapper( ByScoreGroup);
            ShowSummaryStatistics = new WebElementWrapper( ByShowSummaryStatistics);
            Grid = new BenchmarkTestsTabOneTestViewGrid( _gridLocator);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new BenchmarkTestsTabOneTestViewData Data
        {
            get
            {
                return (BenchmarkTestsTabOneTestViewData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private string _controlPre2 = "StudentProfileDetailControl_ctl07_BenchmarkTestAnalysisControl_";
        private By ByTestDate { get { return By.Id(ControlPrefix + _controlPre2 + "lblTestDate"); } }
        private WebElementWrapper TestDate { get; set; }
        //ctl00_MainContent_StudentProfileDetailControl_ctl07_BenchmarkTestAnalysisControl_lblPoints
        private By ByScore { get { return By.Id(ControlPrefix + _controlPre2 + "lblPoints"); } }
        private WebElementWrapper Score { get; set; }
        private By ByScoreGroup { get { return By.Id(ControlPrefix + _controlPre2 + "ScoreGroupImageControl_LabelScoreGroup"); } }
        private WebElementWrapper ScoreGroup { get; set; }
        private By ByShowSummaryStatistics { get { return By.Id("showSummary"); } }
        private WebElementWrapper ShowSummaryStatistics { get; set; }
        private string _gridLocator = "#ctl00_MainContent_StudentProfileDetailControl_ctl07_BenchmarkTestAnalysisControl_DataGridQuestions";
        public BenchmarkTestsTabOneTestViewGrid Grid { get; set; }

        /// <summary>
        /// expand on show summary statistics
        /// </summary>
        public void ExpandShowSummaryStatistics()
        {
            ShowSummaryStatistics.Wait(3).Click();
        }

        /// <summary>
        /// Get Score above the Show Summary Statistics
        /// </summary>
        /// <returns></returns>
        public string GetScore()
        {
            if (this.Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                return FakeText;
            }
            return Score.Wait(3).Text;
        }

        #region Grid

        /// <summary>
        /// One test view, grid. Get last data row
        /// </summary>
        public BenchmarkTestsTabOneTestViewRow GetLastRowData()
        {
            Grid.SetGridLists();
            return Grid.GetLastRowData();
        }

        /// <summary>
        /// click on view link for an item
        /// specified the item number through dataObject
        /// </summary>
        public BenchmarkTestsTab GridSelectItemView()
        {
            int itemNumber = Convert.ToInt32(Data.ItemNumber);
            Grid.SetGridLists();

            BenchmarkTestsTabOneTestViewRow found = Grid.GetsRow(itemNumber);

            if (found != null)
            {
                Report.Write("Attempting to click on view for item " + itemNumber);
                found.SelectColumn(BenchmarkTestsTabOneTestViewColumnNames.ItemNumber);
            }

            return new BenchmarkTestsTabItemResponseView();
        }

        #endregion
    }
}
