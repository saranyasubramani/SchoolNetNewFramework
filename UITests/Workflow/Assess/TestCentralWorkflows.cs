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
using UITests.Pages.Components;
using UITests.Pages.Assess;
using UITests.Pages.Assess.Dashboard;
using UITests.Pages.Assess.ItemCentral;
using UITests.Pages.Assess.ItemCentral.ItemCentral;
using UITests.Pages.Assess.ItemCentral.ItemCentralHome;
using UITests.Pages.Assess.ItemCentral.ItemCentralSearchResults;
using UITests.Pages.Assess.ItemCentral.ItemCentralStandardPicker;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditItemAvailability;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditQuestion;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTask;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTestItem;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;
using UITests.Pages.Assess.ItemCreateEdit.v01.ViewItemStatistics;
using UITests.Pages.Assess.Passage;
using UITests.Pages.Assess.Passage.EditPassage;
using UITests.Pages.Assess.Passage.PassageDetail;
using UITests.Pages.Assess.PrintTest;
using UITests.Pages.Assess.Rubric;
using UITests.Pages.Assess.Rubric.Components;
using UITests.Pages.Assess.Rubric.EditRubric;
using UITests.Pages.Assess.Rubric.EditRubricAvailability;
using UITests.Pages.Assess.Rubric.RubricDetail;
using UITests.Pages.Assess.Scantron;
using UITests.Pages.Assess.Schedule;
using UITests.Pages.Assess.Schedule.EditSchedule;
using UITests.Pages.Assess.Schedule.EditAssignmentCourse;
using UITests.Pages.Assess.Standards;
using UITests.Pages.Assess.TestCentral;
using UITests.Pages.Assess.TestCentral.TestCentralHome;
using UITests.Pages.Assess.TestCreateEdit;
using UITests.Pages.Assess.TestCreateEdit.Components;
using UITests.Pages.Assess.TestCreateEdit.CreateTestManual;
using UITests.Pages.Assess.TestCreateEdit.CreateTestBySelectingStandards;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestDetail.ViewTestDetails;
using UITests.Pages.Assess.TestTunnel;
using UITests.Pages.Assess.TestTunnel.Default;
using UITests.Pages.Assess.TestTunnel.Login;
using UITests.Pages.Assess.TestWindow;
using UITests.Pages.Assess.TestWindow.CreateEditTestWindow;
using UITests.Pages.Assess.TestWindow.PlanHome;
using UITests.Pages.Assess.TestWindow.ViewTestWindow;
using UITests.Pages.Assess.Track;
using UITests.Pages.Home;
using UITests.Workflow;

namespace UITests.Workflow.Assess
{
    /// <summary>
    /// the test central workflows
    /// </summary>
    public class TestCentralWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public TestCentralWorkflows( AssessWorkflows workflows)
            : base()
        {
            AssessWorkflows = workflows;
        }

        //workflows
        public AssessWorkflows AssessWorkflows { get; set; }

        /// <summary>
        /// navigate to the test central page
        /// </summary>
        /// <returns>Workflows</returns>
        public TestCentralWorkflows NavigateToTestCentralHomePage()
        {
            AssessWorkflows.NavigateToAssessDashboardPage().NavigateToTestCentralHomePage();
            if (AssessWorkflows.TestCentralHomePage == null)
            {
                throw new Exception("Navigate to the TestCentralHomePage before trying to use this workflow.");
            }
            return this;
        }

        /// <summary>
        /// Search a test using testname or test id
        /// </summary>
        /// <returns>Workflows</returns>
        public TestCentralWorkflows SearchForTestByName(string testName)
        {
            if (AssessWorkflows.TestCentralHomePage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.TestCentralHomePage before trying to use this workflow.");
            }
            TestCentralHomePageInputAndSubmitForm(testName);
            return this;
        }

        /// <summary>
        /// Search a test by test name and select the private draft stage
        /// </summary>
        /// <returns>Workflows</returns>
        public TestCentralWorkflows SearchForTestByNameAndStagePrivateDraft(string testName)
        {
            if (AssessWorkflows.TestCentralHomePage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.TestCentralHomePage before trying to use this workflow.");
            }
            AssessWorkflows.TestCentralHomePage.Form.CheckPrivateDraft();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckPublicDraft();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckReady();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckScheduled();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckInProgress();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckCompleted();
            TestCentralHomePageInputAndSubmitForm(testName);
            return this;
        }
        /// <summary>
        /// Search a test by test name and select the public draft stage
        /// </summary>
        /// <returns>Workflows</returns>
        public TestCentralWorkflows SearchForTestByNameAndStagePublicDraft(string testName)
        {
            if (AssessWorkflows.TestCentralHomePage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.TestCentralHomePage before trying to use this workflow.");
            }
            AssessWorkflows.TestCentralHomePage.Form.UnCheckPrivateDraft();
            AssessWorkflows.TestCentralHomePage.Form.CheckPublicDraft();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckReady();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckScheduled();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckInProgress();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckCompleted();
            TestCentralHomePageInputAndSubmitForm(testName);
            return this;
        }
        /// <summary>
        /// Search a test by test name and select the ready stage
        /// </summary>
        /// <returns>Workflows</returns>
        public TestCentralWorkflows SearchForTestByNameAndStageReady(string testName)
        {
            if (AssessWorkflows.TestCentralHomePage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.TestCentralHomePage before trying to use this workflow.");
            }
            AssessWorkflows.TestCentralHomePage.Form.UnCheckPrivateDraft();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckPublicDraft();
            AssessWorkflows.TestCentralHomePage.Form.CheckReady();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckScheduled();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckInProgress();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckCompleted();
            TestCentralHomePageInputAndSubmitForm(testName);
            return this;
        }
        /// <summary>
        /// Search a test by test name and select the scheduled stage
        /// </summary>
        /// <returns>Workflows</returns>
        public TestCentralWorkflows SearchForTestByNameAndStageScheduled(string testName)
        {
            if (AssessWorkflows.TestCentralHomePage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.TestCentralHomePage before trying to use this workflow.");
            }
            AssessWorkflows.TestCentralHomePage.Form.UnCheckPrivateDraft();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckPublicDraft();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckReady();
            AssessWorkflows.TestCentralHomePage.Form.CheckScheduled();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckInProgress();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckCompleted();
            TestCentralHomePageInputAndSubmitForm(testName);
            return this;
        }
        /// <summary>
        /// Search a test by test name and select the in progress stage
        /// </summary>
        /// <returns>Workflows</returns>
        public TestCentralWorkflows SearchForTestByNameAndStageInProgress(string testName)
        {
            if (AssessWorkflows.TestCentralHomePage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.TestCentralHomePage before trying to use this workflow.");
            }
            AssessWorkflows.TestCentralHomePage.Form.UnCheckPrivateDraft();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckPublicDraft();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckReady();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckScheduled();
            AssessWorkflows.TestCentralHomePage.Form.CheckInProgress();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckCompleted();
            TestCentralHomePageInputAndSubmitForm(testName);
            return this;
        }
        /// <summary>
        /// Search a test by test name and select the completed stage
        /// </summary>
        /// <returns>Workflows</returns>
        public TestCentralWorkflows SearchForTestByNameAndStageCompleted(string testName)
        {
            if (AssessWorkflows.TestCentralHomePage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.TestCentralHomePage before trying to use this workflow.");
            }
            AssessWorkflows.TestCentralHomePage.Form.UnCheckPrivateDraft();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckPublicDraft();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckReady();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckScheduled();
            AssessWorkflows.TestCentralHomePage.Form.UnCheckInProgress();
            AssessWorkflows.TestCentralHomePage.Form.CheckCompleted();
            TestCentralHomePageInputAndSubmitForm(testName);
            return this;
        }

        /// <summary>
        /// Clear input fields
        /// </summary>
        /// <returns>Workflows</returns>
        public TestCentralWorkflows ClearBasicSearchFields()
        {
            if (AssessWorkflows.TestCentralHomePage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.TestCentralHomePage before trying to use this workflow.");
            }
            AssessWorkflows.TestCentralHomePage.Form.ClearForm();
            return this;
        }

        private void TestCentralHomePageInputAndSubmitForm(string testName)
        {
            AssessWorkflows.TestCentralHomePage.InitData();
            AssessWorkflows.TestCentralHomePage.Data.TestName = testName;
            AssessWorkflows.TestCentralHomePage.Form.InputAndSubmitForm();
        }

        /// <summary>
        /// A search had been performed. Arrange the test to show the oldest on the first item. 
        /// Oldest item mean earlier date. Ascending the startdate will give earlier item.
        /// Used startdate to arrange test.  
        /// </summary>
        /// <returns>Workflows</returns>
        public TestCentralWorkflows SortTestOldestItemFirst()
        {
            if (AssessWorkflows.TestCentralHomePage == null)
            {
                throw new Exception("A search must be performed before trying to use this workflow.");
            }
            AssessWorkflows.TestCentralHomePage.Detail.SortColumnAscending(TestCentralHomeColumnNames.StartDate);
            return this;
        }

        /// <summary>
        /// A search had been performed. Click on testname link of the first item on the result list 
        /// </summary>
        /// <returns>Workflows</returns>
        public TestCentralWorkflows ClickFirstItemTestnameLink()
        {
            if (AssessWorkflows.TestCentralHomePage == null)
            {
                throw new Exception("A search must be performed before trying to use this workflow.");
            }
            AssessWorkflows.TestCentralHomePage.Detail.GetItemFromSearchResultGrid(0).ClickTestNameLink();
            AssessWorkflows.ViewTestDetailsPage = new ViewTestDetailsPage();
            return this;
        }

        /// <summary>
        /// A search had been performed. Click on test with the EXACT name match
        /// </summary>
        /// <returns>Workflows</returns>
        public TestCentralWorkflows ClickTestnameLink(string testName)
        {
            if (AssessWorkflows.TestCentralHomePage == null)
            {
                throw new Exception("A search must be performed before trying to use this workflow.");
            }
            List<TestCentralHomeRow> results = AssessWorkflows.TestCentralHomePage.Detail.GetItemFromSearchResultGrid(TestCentralHomeColumnNames.TestName, testName);
            results[0].SelectTestName();

            AssessWorkflows.ViewTestDetailsPage = new ViewTestDetailsPage();
            return this;
        }
    }
}
