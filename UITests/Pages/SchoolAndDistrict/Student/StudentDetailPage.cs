using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.AllTests;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.OneTest;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.ItemResponse;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail.StudentOverview;

namespace UITests.Pages.SchoolAndDistrict.Student
{
    /// <summary>
    /// student detail page
    /// </summary>
    public class StudentDetailPage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public StudentDetailPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/StudentDetail.aspx";
            this.VerifyCurrentUrl();
            this.tabInFocus = StudentDetailTabs.StudentOverview;
            InitElements();
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="tabInFocus">the current tab in focus</param>
        public StudentDetailPage(StudentDetailTabs tabInFocus)
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/StudentDetail.aspx";
            this.VerifyCurrentUrl();
            this.tabInFocus = tabInFocus;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Detail = new StudentDetailDetail();
            this.Detail.Parent = this;
            this.Form = new StudentDetailForm();
            this.Form.Parent = this;
            this.Tabs = new Dictionary<object, Tab>();
            switch (this.tabInFocus)
            {
                case StudentDetailTabs.StudentOverview:
                    this.Tab = new StudentOverviewTab();
                    this.Tabs.Add(StudentDetailTabs.StudentOverview, this.Tab);
                    break;
                case StudentDetailTabs.BenchmarkTestsAllTests:
                    this.Tab = new BenchmarkTestsTabAllTestsView();
                    this.Tabs.Add(StudentDetailTabs.BenchmarkTestsAllTests, this.Tab);
                    break;
                case StudentDetailTabs.BenchmarkTestsOneTest:
                    this.Tab = new BenchmarkTestsTabOneTestView();
                    this.Tabs.Add(StudentDetailTabs.BenchmarkTestsAllTests, this.Tab);
                    break;
                case StudentDetailTabs.BenchmarkTestsItemResponse:
                    this.Tab = new BenchmarkTestsTabItemResponseView();
                    this.Tabs.Add(StudentDetailTabs.BenchmarkTestsAllTests, this.Tab);
                    break;
                default:
                    this.Tab = new BenchmarkTestsTabAllTestsView();
                    this.Tabs.Add(StudentDetailTabs.StudentOverview, this.Tab);
                    break;
            }
            StudentOverviewTab = new WebElementWrapper(ByStudentOverviewTab);
            BenchmarkTestsTab = new WebElementWrapper(ByBenchmarkTestsTab);
        }
        /// <summary>
        /// the detail
        /// </summary>
        public new StudentDetailDetail Detail { get; set; }
        /// <summary>
        /// the form
        /// </summary>
        public new StudentDetailForm Form { get; set; }
        /// <summary>
        /// the tabs
        /// </summary>
        public new Dictionary<object, Tab> Tabs { get; private set; }
        private StudentDetailTabs tabInFocus;

        /// <summary>
        /// the data
        /// </summary>
        public new StudentDetailData Data
        {
            get
            {
                return (StudentDetailData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Detail.Data = value;
                this.Form.Data = value;
                StudentDetailData data = (StudentDetailData)value;
                BenchmarkTestsTabAllTestsView benchmarkTestsAllTests = 
                    (BenchmarkTestsTabAllTestsView)this.Tabs[StudentDetailTabs.BenchmarkTestsAllTests];
                benchmarkTestsAllTests.Data = data.BenchmarkTestsTabAllTestsViewData;
                BenchmarkTestsTabOneTestView benchmarkTestsOneTest = 
                    (BenchmarkTestsTabOneTestView)this.Tabs[StudentDetailTabs.BenchmarkTestsOneTest];
                benchmarkTestsOneTest.Data = data.BenchmarkTestsTabOneTestViewData;
                BenchmarkTestsTabItemResponseView benchmarkTestsItemResponse = 
                    (BenchmarkTestsTabItemResponseView)this.Tabs[StudentDetailTabs.BenchmarkTestsItemResponse];
                benchmarkTestsItemResponse.Data = data.BenchmarkTestsTabItemResponseViewData;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new StudentDetailData InitData()
        {
            base.InitData(new StudentDetailData());
            return (StudentDetailData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public StudentDetailData InitData(object data)
        {
            base.InitData(data);
            return (StudentDetailData)base.Data;
        }

        private string _controlPrefix2 = "StudentProfileDetailControl_ProfileTabControl1_RepeaterTabs_";
        //ctl00_MainContent_StudentProfileDetailControl_ProfileTabControl1_RepeaterTabs_ctl00_HyperLinkTab
        private By ByStudentOverviewTab { get { return By.Id(ControlPrefix + _controlPrefix2 + "ctl00_HyperLinkTab"); } }
        private WebElementWrapper StudentOverviewTab { get; set; }
        //ctl00_MainContent_StudentProfileDetailControl_ProfileTabControl1_RepeaterTabs_ctl07_HyperLinkTab
        private By ByBenchmarkTestsTab { get { return By.Id(ControlPrefix + _controlPrefix2 + "ctl07_HyperLinkTab"); } }
        private WebElementWrapper BenchmarkTestsTab { get; set; }

        /// <summary>
        /// click on student overview tab
        /// </summary>
        /// <returns>StudentOverviewTab</returns>
        public StudentOverviewTab SelectStudentOverviewTab()
        {
            StudentOverviewTab.Wait(3).Click();
            this.Tab = new StudentOverviewTab();
            return (StudentOverviewTab)this.Tab;
        }

        /// <summary>
        /// click on benchmark tests tab
        /// </summary>
        /// <returns>BenchmarkTestsTab</returns>
        public BenchmarkTestsTab SelectBenchmarkTestsTab()
        {
            BenchmarkTestsTab.Wait(3).Click();
            this.Tab = new BenchmarkTestsTabAllTestsView();
            return (BenchmarkTestsTabAllTestsView)this.Tab;
        }
    }
}
