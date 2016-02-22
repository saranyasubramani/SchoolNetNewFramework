using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages;
using UITests.Pages.Home;
using UITests.Pages.SchoolAndDistrict;
using UITests.Pages.SchoolAndDistrict.Dashboard;
using UITests.Pages.SchoolAndDistrict.Student;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.AllTests;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.OneTest;
using UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.ItemResponse;
using UITests.Workflow;

namespace UITests.Workflow.SchoolAndDistrict
{
    /// <summary>
    /// the student profile workflows
    /// </summary>
    public class StudentProfileWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public StudentProfileWorkflows(SchoolDistrictWorkflows workflows)
            : base()
        {
            SchoolDistrictWorkflows = workflows;
        }

        //workflows
        public SchoolDistrictWorkflows SchoolDistrictWorkflows { get; set; }

        /// <summary>
        /// find a student and click on the auto popup
        /// </summary>
        /// <returns>Workflows</returns>
        public StudentProfileWorkflows FindAStudentUsingAutoPopup(string studentId)
        {
            if (SchoolDistrictWorkflows.Workflows.HomePage == null)
            {
                throw new Exception("Navigate to the HomePage before trying to use this workflow.");
            }

            SchoolDistrictWorkflows.Workflows.HomePage.Header.Data = studentId;
            SchoolDistrictWorkflows.Workflows.HomePage.Header.FindAStudentUsingAutoPopup();

            StudentDetailData previousData = null; //remember previous data
            if ((SchoolDistrictWorkflows.StudentDetailPage != null) 
                && (SchoolDistrictWorkflows.StudentDetailPage.Data != null))
            {
                //if previous page data exist
                previousData = (StudentDetailData)SchoolDistrictWorkflows.StudentDetailPage.Data;
            }
            SchoolDistrictWorkflows.StudentDetailPage = new StudentDetailPage();
            SchoolDistrictWorkflows.StudentDetailPage.Data = previousData;
            return this;
        }

        /// <summary>
        /// navigate to benchmark tab
        /// </summary>
        /// <returns>Workflows</returns>
        public StudentProfileWorkflows NavigateToBenchmarkTestsTab()
        {
            if (SchoolDistrictWorkflows.StudentDetailPage == null)
            {
                throw new Exception("Navigate to the StudentDetailPage before trying to use this workflow.");
            }
            BenchmarkTestsTab benchTab = SchoolDistrictWorkflows.StudentDetailPage.SelectBenchmarkTestsTab();
            return this;
        }

        /// <summary>
        /// click show filter button
        /// </summary>
        /// <returns>Workflows</returns>
        public StudentProfileWorkflows BenchmarkTestsTabShowFilters()
        {
            if ((SchoolDistrictWorkflows.StudentDetailPage == null) ||
                (SchoolDistrictWorkflows.StudentDetailPage.Tabs[StudentDetailTabs.BenchmarkTestsAllTests] == null))
            {
                throw new Exception("Navigate to the StudentDetailPage before trying to use this workflow.");
            }

            BenchmarkTestsTabAllTestsView benchmarkView = 
                ((BenchmarkTestsTabAllTestsView)SchoolDistrictWorkflows.StudentDetailPage.Tabs[StudentDetailTabs.BenchmarkTestsAllTests]);
            SchoolDistrictWorkflows.StudentDetailPage = 
                (StudentDetailPage)benchmarkView.Form.SelectShowFilters();
            return this;

        }

        /// <summary>
        /// at benchmark tab, view with all tests. 
        /// click on first test for a subject (ie ELA or Computer Science)
        /// </summary>
        /// <returns>Workflows</returns>
        public StudentProfileWorkflows BenchmarkTestsTabSelectTestNameForSubject(string subject)
        {
            if ((SchoolDistrictWorkflows.StudentDetailPage == null) ||
                (SchoolDistrictWorkflows.StudentDetailPage.Tabs[StudentDetailTabs.BenchmarkTestsAllTests] == null))
            {
                throw new Exception("Navigate to the StudentDetailPage before trying to use this workflow.");
            }

            BenchmarkTestsTabAllTestsView benchmarkView = 
                ((BenchmarkTestsTabAllTestsView)SchoolDistrictWorkflows.StudentDetailPage.Tabs[StudentDetailTabs.BenchmarkTestsAllTests]);
            if (subject == BenchmarkTestsTabAllTestsViewGridNames.ELA)
            {
                BenchmarkTestsTabOneTestView nextBenchmarkView = 
                    (BenchmarkTestsTabOneTestView)benchmarkView.Form.ELAGridSelectTestName();
            }
            return this;

        }

        /// <summary>
        /// at benchmark tab, view with a selected test.
        /// click on item in a test
        /// </summary>
        /// <returns>Workflows</returns>
        public StudentProfileWorkflows BenchmarkTestsTabSelectItemInATest()
        {
            if (SchoolDistrictWorkflows.StudentDetailPage == null ||
                SchoolDistrictWorkflows.StudentDetailPage.Tabs[StudentDetailTabs.BenchmarkTestsOneTest] == null)
            {
                throw new Exception("Navigate to the StudentDetailPage before trying to use this workflow.");
            }

            BenchmarkTestsTabOneTestView benchmarkView = 
                ((BenchmarkTestsTabOneTestView)SchoolDistrictWorkflows.StudentDetailPage.Tabs[StudentDetailTabs.BenchmarkTestsOneTest]);
            BenchmarkTestsTabItemResponseView nextBenchmarkView =
                (BenchmarkTestsTabItemResponseView)benchmarkView.Form.GridSelectItemView();
            return this;
        }
    }
}
