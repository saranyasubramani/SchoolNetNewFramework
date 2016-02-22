using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.OneTest;

namespace UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.AllTests
{
    /// <summary>
    /// the benchmark tests tab form
    /// </summary>
    public class BenchmarkTestsTabAllTestsViewForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public BenchmarkTestsTabAllTestsViewForm(string overrideControlPrefix = null)
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
            Show = new SelectElementWrapper(new WebElementWrapper(ByShow));
            ShowFilters = new WebElementWrapper(ByShowFilters);
            HideFilters = new WebElementWrapper(ByHideFilters);
            GetGridLocator();
            GridELA = new BenchmarkELAGrid(_gridELALocator, _gridELAIndex);
            SchoolYear = new SelectElementWrapper(new WebElementWrapper(BySchoolYear));
            TestCategory = new SelectElementWrapper(new WebElementWrapper(ByTestCategory));
        }

        /// <summary>
        /// the data
        /// </summary>
        public new BenchmarkTestsTabAllTestsViewData Data
        {
            get
            {
                return (BenchmarkTestsTabAllTestsViewData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private string _controlPrefix2 = "StudentProfileDetailControl_";
        private By ByShow { get { return By.Id(ControlPrefix + _controlPrefix2 + "ctl07_ddlViewBy"); } }
        private SelectElementWrapper Show { get; set; }
        //ctl00_MainContent_StudentProfileDetailControl_ctl07_btnShow
        private By ByShowFilters { get { return By.Id(ControlPrefix + _controlPrefix2 + "ctl07_btnShow"); } }
        private WebElementWrapper ShowFilters { get; set; }
        //ctl00_MainContent_StudentProfileDetailControl_ctl07_btnHide
        private By ByHideFilters { get { return By.Id(ControlPrefix + _controlPrefix2 + "ctl07_btnHide"); } }
        private WebElementWrapper HideFilters { get; set; }
        //ctl00_MainContent_StudentProfileDetailControl_ctl07_DropDownListYear
        private By BySchoolYear { get { return By.Id(ControlPrefix + _controlPrefix2 + "ctl07_DropDownListYear"); } }
        public SelectElementWrapper SchoolYear { get; private set; }
        private By ByTestCategory { get { return By.Id(ControlPrefix + _controlPrefix2 + "ctl07_ddlTestCategories"); } }
        private SelectElementWrapper TestCategory { get; set; }
        private By ByStandardColumn { get { return By.CssSelector("table > thead > tr:nth-of-type(1) > th:nth-of-type(1)"); } }
        private WebElementWrapper StandardColumn { get; set; }
        private int _gridELAIndex;
        private string _gridELALocator;
        public BenchmarkELAGrid GridELA { get; set; }
        private string _gridComputerScienceLocator;
        //Computer science grid to be implemented 
        private string _gridMathematicsLocator;
        //Mathematics grid to be implemented


        
        public void GetGridLocator()
        {
            By ByAllGrids = By.CssSelector("h4[class='section_title']");
            WebElementWrapper AllGrids = new WebElementWrapper(ByAllGrids);
            ReadOnlyCollection<IWebElement> gridList = AllGrids.FindElements();

            for (int i = 0; i < gridList.Count; i++)
            {
                if (gridList[i].Text.Contains(BenchmarkTestsTabAllTestsViewGridNames.ELA))
                {
                    _gridELAIndex = i;
                    _gridELALocator = "#SubjectGroup" + Convert.ToString(_gridELAIndex);
                }
                //case "ELA":
                //    _gridELAIndex = i;
                //    _gridELALocator = "#SubjectGroup" + Convert.ToString(_gridELAIndex);
                //    break;
                //case "Computer and Information Sciences":
                //    _gridComputerScienceLocator = "#SubjectGroup" + Convert.ToString(i);
                //    break;
                //case "Mathematics":
                //    _gridMathematicsLocator = "#SubjectGroup" + Convert.ToString(i);
                //    break;

                //}
            }

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                _gridELALocator = "#SubjectGroup0";
                _gridComputerScienceLocator = "#SubjectGroup1";
                _gridMathematicsLocator = "#SubjectGroup2";
            }
        }

        /// <summary>
        /// click on show filters tab
        /// </summary>
        public SNWebPage SelectShowFilters()
        {
            ShowFilters.Wait(3).Click();
            //postback
            //return new BenchmarkTestsTabAllTestsView();
            return new StudentDetailPage(StudentDetailTabs.BenchmarkTestsAllTests);
        }

        #region ELA Grid

        /// <summary>
        /// get all the fields for a row. Index 0, 1, ... 0 is the first row. 
        /// 0th row is the header row. 1st row is the data row
        /// </summary>
        /// <param name="index"></param>
        public BenchmarkELARow ELAGridRowDataByIndex(int index)
        {
            GridELA.SetGridLists();
            return GridELA.GetsRow(index);
        }

        /// <summary>
        /// click on test name
        /// </summary>
        public BenchmarkTestsTab ELAGridSelectTestName()
        {
            string testName = Data.TestName;
            GridELA.SetGridLists();

            BenchmarkELARow testFound = GridELA.GetsFirstRowContainingTextToFindFromList(BenchmarkELAColumnNames.TestName, testName);

            if (testFound != null)
            {
                Report.Write("Attempting to select test name " + testName);
                testFound.SelectColumn(BenchmarkELAColumnNames.TestName);
            }

            //postback
            return new BenchmarkTestsTabOneTestView();
        }

        #endregion

        /// <summary>
        /// verify grid is showing standard mode
        /// </summary>
        public void VerifyGridIsShowingStandardMode()
        {
            StandardColumn = new WebElementWrapper(ByStandardColumn);
            string expect = "Standard";
            string actualColumnValue = StandardColumn.Wait(3).Text;
            Assert.IsTrue(actualColumnValue.Contains(expect),
                "The grid first column did not contain expected value: " + expect + ". Actual: " + actualColumnValue);
        }

        //overridden methods
        public override void InputFormFields()
        {
            if (Data.Show != null)
            {
                Show.Wait(5).SelectByText(Data.Show);
            }
            if (Data.SchoolYear != null)
            {
                SchoolYear.Wait(5).SelectByText(Data.SchoolYear);
            }
            if (Data.TestCategory != null)
            {
                TestCategory.Wait(5).SelectByText(Data.TestCategory);
            }
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            //return new BenchmarkTestsTabAllTestsView();
            return new StudentDetailPage(StudentDetailTabs.BenchmarkTestsAllTests);
        }
    }
}
