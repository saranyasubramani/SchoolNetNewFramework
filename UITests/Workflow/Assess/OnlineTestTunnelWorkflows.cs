using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using UITests.Pages.Assess.TestTunnel.TestAccess;
using UITests.Pages.Assess.TestTunnel.TestForms;
using UITests.Pages.Assess.TestTunnel.TestParts;
using UITests.Pages.Assess.TestWindow;
using UITests.Pages.Assess.TestWindow.CreateEditTestWindow;
using UITests.Pages.Assess.TestWindow.PlanHome;
using UITests.Pages.Assess.TestWindow.ViewTestWindow;
using UITests.Pages.Assess.Track;
using UITests.Pages.Home;
using UITests.Pages.Home.Components;
using UITests.Workflow;

namespace UITests.Workflow.Assess
{
    /// <summary>
    /// the online test tunnel workflows
    /// </summary>
    public class OnlineTestTunnelWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public OnlineTestTunnelWorkflows( AssessWorkflows workflows)
            : base()
        {
            AssessWorkflows = workflows;
        }

        //workflows
        public AssessWorkflows AssessWorkflows { get; set; }

        /// <summary>
        /// sign in as district admin, search for a test, copy the test, and then preview the online test
        /// </summary>
        /// <param name="searchTestName">the name of the test to search for</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows SearchCopyAndPreviewTestByDistrictAdmin(string searchTestName)
        {
            //sign in as district admin
            this.AssessWorkflows.Workflows.SignInAsDistrictAdmin();
            SearchCopyAndPreviewTest(searchTestName);
            return this;
        }
        /// <summary>
        /// sign in as leadership, search for a test, copy the test, and then preview the online test
        /// </summary>
        /// <param name="searchTestName">the name of the test to search for</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows SearchCopyAndPreviewTestByLeadership(string searchTestName)
        {
            //sign in as district admin
            this.AssessWorkflows.Workflows.SignInAsLeadership();
            SearchCopyAndPreviewTest(searchTestName);
            return this;
        }
        /// <summary>
        /// search for a test, copy the test, and then preview the online test
        /// </summary>
        /// <param name="searchTestName">the name of the test to search for</param>
        /// <returns>Workflows</returns>
        private OnlineTestTunnelWorkflows SearchCopyAndPreviewTest(string searchTestName)
        {
            Report.Write("--search for a test, copy it, and preview the test--");
            //shorten the copied test name to under 70 characters
            int length = searchTestName.Length;
            String shorterTestName = null;
            if (length > 70)
            {
                shorterTestName = searchTestName.Substring(0, 70);
            }
            else
            {
                shorterTestName = searchTestName;
            }
            //copy the test name
            string copyTestName = string.Format("Zcopy {0}: {1}", shorterTestName, DateTime.Now.ToString("yyMMddMMssfff"));

            //navigate to test central
            this.AssessWorkflows.TestCentralWorkflows.NavigateToTestCentralHomePage();

            //search for the test
            this.AssessWorkflows.TestCentralWorkflows
                .SearchForTestByNameAndStageReady(searchTestName)
                .ClickFirstItemTestnameLink();

            //copy the test
            this.AssessWorkflows.ViewTestDetailsWorkflows
                .ViewTestDetailsPageVerifyIsReadyToSchedule()
                .ViewTestDetailsPageCopyTest();

            //modify the copied test name
            CreateTestManualData manualTestData = new CreateTestManualData();
            manualTestData.TestId = copyTestName;
            this.AssessWorkflows.CreateTestManualPage.Data = manualTestData;
            this.AssessWorkflows.CreateManualTestWorkflows
                .CopiedManualTestToViewTestDetails();

            //preview the test
            this.AssessWorkflows.ViewTestDetailsWorkflows
                .ViewTestDetailsPagePreviewOnlineTest();

            //get the search results from the view test details page
            AssessWorkflows.ViewTestDetailsPageGridList = AssessWorkflows.ViewTestDetailsPage.Form.GetResultsList();
            /* create your question/answer item data:
             *     QuestionAnswerData itemData = getMultipleChoiceData();
             * get the item ID from the search results, and set it to your item data:
             *     itemData.ItemID = ViewTestDetailsPageGridList[0].ItemId;
             */

            //set the test tunnel data
            AssessWorkflows.TestTunnelPage.InitData();
            AssessWorkflows.TestTunnelPage.Data.TestName = copyTestName;
            return this;
        }

        /// <summary>
        /// sign in as district admin, search for a test, copy the test, schedule the test,
        /// sign in as a student, and then start the online test
        /// </summary>
        /// <remarks>requires the OnlinePassCode and StudentHomePage to be initialized in this class</remarks>
        /// <param name="searchTestName">the name of the test to search for</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows SearchCopyAndScheduleTestByDistrictAdmin_StudentStartsTest(string searchTestName)
        {
            //sign in as district admin
            this.AssessWorkflows.Workflows.SignInAsDistrictAdmin();
            SearchCopyAndScheduleTest_StudentStartsTest(searchTestName);
            return this;
        }
        /// <summary>
        /// sign in as leadership, search for a test, copy the test, schedule the test,
        /// sign in as a student, and then start the online test
        /// </summary>
        /// <remarks>requires the OnlinePassCode and StudentHomePage to be initialized in this class</remarks>
        /// <param name="searchTestName">the name of the test to search for</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows SearchCopyAndScheduleTestByLeadership_StudentStartsTest(string searchTestName)
        {
            //sign in as district admin
            this.AssessWorkflows.Workflows.SignInAsLeadership();
            SearchCopyAndScheduleTest_StudentStartsTest(searchTestName);
            return this;
        }
        /// <summary>
        /// search for a test, copy the test, schedule the test,
        /// sign in as a student, and then start the online test
        /// </summary>
        /// <remarks>requires the OnlinePassCode and StudentHomePage to be initialized in this class</remarks>
        /// <param name="searchTestName">the name of the test to search for</param>
        /// <returns>Workflows</returns>
        private OnlineTestTunnelWorkflows SearchCopyAndScheduleTest_StudentStartsTest(string searchTestName)
        {
            Report.Write("--search for a test, copy it, schedule it, sign in as student, start the test--");
            //shorten the copied test name to under 70 characters
            int length = searchTestName.Length;
            String shorterTestName = null;
            if (length > 70)
            {
                shorterTestName = searchTestName.Substring(0, 70);
            }
            else
            {
                shorterTestName = searchTestName;
            }
            //copy the test name
            string copyTestName = string.Format("Zcopy {0}: {1}", shorterTestName, DateTime.Now.ToString("yyMMddMMssfff"));

            //navigate to test central
            this.AssessWorkflows.TestCentralWorkflows.NavigateToTestCentralHomePage();

            //search for the test
            this.AssessWorkflows.TestCentralWorkflows
                .SearchForTestByNameAndStageReady(searchTestName)
                .ClickFirstItemTestnameLink();

            //copy the test
            this.AssessWorkflows.ViewTestDetailsWorkflows
                .ViewTestDetailsPageVerifyIsReadyToSchedule()
                .ViewTestDetailsPageCopyTest();

            //modify the copied test name
            CreateTestManualData manualTestData = new CreateTestManualData();
            manualTestData.TestId = copyTestName;
            this.AssessWorkflows.CreateTestManualPage.Data = manualTestData;
            this.AssessWorkflows.CreateManualTestWorkflows
                .CopiedManualTestToViewTestDetails();

            //schedule the test
            this.AssessWorkflows.ViewTestDetailsWorkflows
                .ViewTestDetailsPageMakePublic()
                .ViewTestDetailsPageVerifyIsPublicDraft()
                .ViewTestDetailsPageReadyToSchedule()
                .ViewTestDetailsPageVerifyIsReadyToSchedule()
                .ViewTestDetailsPageSchedule();
            this.AssessWorkflows.EditSchedulePage.Data = getScheduleData(-1);
            this.AssessWorkflows.EditScheduleWorkflows
                .EditSchedulePageAcceptQuickAssignmentInputAndSubmitForm();

            //get the search results from the view test details page
            AssessWorkflows.ViewTestDetailsPageGridList = AssessWorkflows.ViewTestDetailsPage.Form.GetResultsList();
            /* create your question/answer item data:
             *     QuestionAnswerData itemData = getMultipleChoiceData();
             * get the item ID from the search results, and set it to your item data:
             *     itemData.ItemID = ViewTestDetailsPageGridList[0].ItemId;
             */

            //get the online pass code
            string onlinePassCode = this.AssessWorkflows.EditScheduleWorkflows.OnlinePassCode;

            //sign out of district admin
            this.AssessWorkflows.Workflows.SignOut();

            //sign in as a student
            this.AssessWorkflows.Workflows.SignInAsStudent();

            //search for the test by passcode, and start the test
            StudentHomeData studentData = (StudentHomeData)AssessWorkflows.StudentHomePage.Data;
            studentData.Passcode = onlinePassCode;
            this.StudentHomePageTakeATestFormInputAndSubmitForm()
                .StudentHomePageTakeATestFormStartTest();

            //set the test tunnel data
            AssessWorkflows.TestTunnelPage.InitData();
            AssessWorkflows.TestTunnelPage.Data.TestName = copyTestName;
            AssessWorkflows.TestTunnelPage.Data.TestersFirstName = studentData.FirstName;
            AssessWorkflows.TestTunnelPage.Data.TestersLastName = studentData.LastName;
            AssessWorkflows.TestTunnelPage.Data.OnlinePassCode = onlinePassCode;
            return this;
        }

        /// <summary>
        /// sign in as district admin, search for a test, copy the test, schedule the test,
        /// sign in as a student, and then start the online test
        /// </summary>
        /// <remarks>requires the OnlinePassCode and StudentHomePage to be initialized in this class</remarks>
        /// <param name="searchTestName">the name of the test to search for</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows SearchCopyAndScheduleTimeTestByDistrictAdmin_StudentStartsTest(string searchTestName)
        {
            //sign in as district admin
            this.AssessWorkflows.Workflows.SignInAsDistrictAdmin();
            SearchCopyAndScheduleTimeTest_StudentStartsTest(searchTestName);
            return this;
        }
        /// <summary>
        /// sign in as leadership, search for a test, copy the test, schedule the test,
        /// sign in as a student, and then start the online test
        /// </summary>
        /// <remarks>requires the OnlinePassCode and StudentHomePage to be initialized in this class</remarks>
        /// <param name="searchTestName">the name of the test to search for</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows SearchCopyAndScheduleTimeTestByLeadership_StudentStartsTest(string searchTestName)
        {
            //sign in as district admin
            this.AssessWorkflows.Workflows.SignInAsLeadership();
            SearchCopyAndScheduleTimeTest_StudentStartsTest(searchTestName);
            return this;
        }
        /// <summary>
        /// search for a test, copy the test, schedule the test,
        /// sign in as a student, and then start the online test
        /// </summary>
        /// <remarks>requires the OnlinePassCode and StudentHomePage to be initialized in this class</remarks>
        /// <param name="searchTestName">the name of the test to search for</param>
        /// <returns>Workflows</returns>
        private OnlineTestTunnelWorkflows SearchCopyAndScheduleTimeTest_StudentStartsTest(string searchTestName)
        {
            Report.Write("--search for a test, copy it, schedule it, sign in as student, start the test--");
            //shorten the copied test name to under 70 characters
            int length = searchTestName.Length;
            String shorterTestName = null;
            if (length > 70)
            {
                shorterTestName = searchTestName.Substring(0, 70);
            }
            else
            {
                shorterTestName = searchTestName;
            }
            //copy the test name
            string copyTestName = string.Format("Zcopy {0}: {1}", shorterTestName, DateTime.Now.ToString("yyMMddMMssfff"));

            //navigate to test central
            this.AssessWorkflows.TestCentralWorkflows.NavigateToTestCentralHomePage();

            //search for the test
            this.AssessWorkflows.TestCentralWorkflows
                .SearchForTestByNameAndStageReady(searchTestName)
                .ClickFirstItemTestnameLink();

            //copy the test
            this.AssessWorkflows.ViewTestDetailsWorkflows
                .ViewTestDetailsPageVerifyIsReadyToSchedule()
                .ViewTestDetailsPageCopyTest();

            //modify the copied test name
            CreateTestManualData manualTestData = new CreateTestManualData();
            manualTestData.TestId = copyTestName;
            this.AssessWorkflows.CreateTestManualPage.Data = manualTestData;
            this.AssessWorkflows.CreateManualTestWorkflows
                .CopiedManualTestToViewTestDetails();

            //schedule the test
            this.AssessWorkflows.ViewTestDetailsWorkflows
                .ViewTestDetailsPageMakePublic()
                .ViewTestDetailsPageVerifyIsPublicDraft()
                .ViewTestDetailsPageReadyToSchedule()
                .ViewTestDetailsPageVerifyIsReadyToSchedule()
                .ViewTestDetailsPageSchedule();
            //set time
            this.AssessWorkflows.EditSchedulePage.Data = getScheduleData_testTime(-1);
            this.AssessWorkflows.EditScheduleWorkflows
                .EditSchedulePageInputFormFields()
                .EditSchedulePageAcceptQuickAssignment()
                .EditSchedulePageSelectTestTime()
                .EditSchedulePageSubmitForm()
                ;

            //get the search results from the view test details page
            AssessWorkflows.ViewTestDetailsPageGridList = AssessWorkflows.ViewTestDetailsPage.Form.GetResultsList();

            //get the online pass code
            string onlinePassCode = this.AssessWorkflows.EditScheduleWorkflows.OnlinePassCode;

            //sign out of district admin
            this.AssessWorkflows.Workflows.SignOut();

            //sign in as a student
            this.AssessWorkflows.Workflows.SignInAsStudent();

            //search for the test by passcode, and start the test
            StudentHomeData studentData = (StudentHomeData)AssessWorkflows.StudentHomePage.Data;
            studentData.Passcode = onlinePassCode;
            this.StudentHomePageTakeATestFormInputAndSubmitForm()
                .StudentHomePageTakeATestFormStartTest();

            //set the test tunnel data
            AssessWorkflows.TestTunnelPage.InitData();
            AssessWorkflows.TestTunnelPage.Data.TestName = copyTestName;
            AssessWorkflows.TestTunnelPage.Data.TestersFirstName = studentData.FirstName;
            AssessWorkflows.TestTunnelPage.Data.TestersLastName = studentData.LastName;
            AssessWorkflows.TestTunnelPage.Data.OnlinePassCode = onlinePassCode;
            return this;
        }

        /// <summary>
        /// search and copy a test
        /// </summary>
        /// <remarks>requires the OnlinePassCode and StudentHomePage to be initialized in this class</remarks>
        /// <param name="searchTestName">the name of the test to search for</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows SearchAndCopyTest(string searchTestName)
        {
            Report.Write("--search for a test, copy it, schedule it, sign in as student, start the test--");
            //shorten the copied test name to under 70 characters
            int length = searchTestName.Length;
            String shorterTestName = null;
            if (length > 70)
            {
                shorterTestName = searchTestName.Substring(0, 70);
            }
            else
            {
                shorterTestName = searchTestName;
            }
            //copy the test name
            string copyTestName = string.Format("Zcopy {0}: {1}", shorterTestName, DateTime.Now.ToString("yyMMddMMssfff"));

            //navigate to test central
            AssessWorkflows.TestCentralWorkflows.NavigateToTestCentralHomePage();

            //search for the test
            this.AssessWorkflows.TestCentralWorkflows
                .SearchForTestByNameAndStagePrivateDraft(searchTestName)
                .ClickFirstItemTestnameLink();

            //copy the test
            AssessWorkflows.ViewTestDetailsWorkflows
                //.ViewTestDetailsPageVerifyIsReadyToSchedule()
                .ViewTestDetailsPageCopyTest();

            //modify the copied test name
            AssessWorkflows.CreateTestManualPage.InitData();
            AssessWorkflows.CreateTestManualPage.Data.TestId = copyTestName;
            AssessWorkflows.CreateManualTestWorkflows
                .CopiedManualTestToViewTestDetails();
            return this;
        }


        /// <summary>
        /// create a multiple choice test item, and add it to the test tunnel
        /// </summary>
        /// <remarks>requires the item ID</remarks>
        /// <param name="itemData">the item data</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows CreateTestItemMultipleChoice(QuestionAnswerData itemData)
        {
            if (itemData.ItemID <= 0)
            {
                throw new Exception("The QuestionAnswerData.ItemID is not set, please initialize it before trying to use it in a workflow.");
            }
            TestTypeMultipleChoiceForm testItem = new TestTypeMultipleChoiceForm();
            testItem.Data = itemData;
            AssessWorkflows.TestTunnelPage.TestList.Add(testItem);
            return this;
        }
        /// <summary>
        /// create a true/false test item, and add it to the test tunnel
        /// </summary>
        /// <remarks>requires the item ID</remarks>
        /// <param name="itemData">the item data</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows CreateTestItemTrueFalse(QuestionAnswerData itemData)
        {
            if (itemData.ItemID <= 0)
            {
                throw new Exception("The QuestionAnswerData.ItemID is not set, please initialize it before trying to use it in a workflow.");
            }
            TestTypeTrueFalseForm testItem = new TestTypeTrueFalseForm();
            testItem.Data = itemData;
            AssessWorkflows.TestTunnelPage.TestList.Add(testItem);
            return this;
        }
        /// <summary>
        /// create a gridded test item, and add it to the test tunnel
        /// </summary>
        /// <remarks>requires the item ID</remarks>
        /// <param name="itemData">the item data</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows CreateTestItemGridded(QuestionAnswerData itemData)
        {
            if (itemData.ItemID <= 0)
            {
                throw new Exception("The QuestionAnswerData.ItemID is not set, please initialize it before trying to use it in a workflow.");
            }
            TestTypeGriddedForm testItem = new TestTypeGriddedForm();
            testItem.Data = itemData;
            AssessWorkflows.TestTunnelPage.TestList.Add(testItem);
            return this;
        }
        /// <summary>
        /// create a open response - spoken test item, and add it to the test tunnel
        /// </summary>
        /// <remarks>requires the item ID</remarks>
        /// <param name="itemData">the item data</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows CreateTestItemOpenResponseSpoken(QuestionAnswerData itemData)
        {
            if (itemData.ItemID <= 0)
            {
                throw new Exception("The QuestionAnswerData.ItemID is not set, please initialize it before trying to use it in a workflow.");
            }
            TestTypeOpenResponseForm testItem = new TestTypeOpenResponseForm(OpenResponseType.Spoken);
            testItem.Data = itemData;
            AssessWorkflows.TestTunnelPage.TestList.Add(testItem);
            return this;
        }
        /// <summary>
        /// create a open response - upload file test item, and add it to the test tunnel
        /// </summary>
        /// <remarks>requires the item ID</remarks>
        /// <param name="itemData">the item data</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows CreateTestItemOpenResponseUploadFile(QuestionAnswerData itemData)
        {
            if (itemData.ItemID <= 0)
            {
                throw new Exception("The QuestionAnswerData.ItemID is not set, please initialize it before trying to use it in a workflow.");
            }
            TestTypeOpenResponseForm testItem = new TestTypeOpenResponseForm(OpenResponseType.UploadFile);
            testItem.Data = itemData;
            AssessWorkflows.TestTunnelPage.TestList.Add(testItem);
            return this;
        }
        /// <summary>
        /// create a open response - written test item, and add it to the test tunnel
        /// </summary>
        /// <remarks>requires the item ID</remarks>
        /// <param name="itemData">the item data</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows CreateTestItemOpenResponseWritten(QuestionAnswerData itemData)
        {
            if (itemData.ItemID <= 0)
            {
                throw new Exception("The QuestionAnswerData.ItemID is not set, please initialize it before trying to use it in a workflow.");
            }
            TestTypeOpenResponseForm testItem = new TestTypeOpenResponseForm(OpenResponseType.Written);
            testItem.Data = itemData;
            AssessWorkflows.TestTunnelPage.TestList.Add(testItem);
            return this;
        }
        /// <summary>
        /// create a inline response test item, and add it to the test tunnel
        /// </summary>
        /// <remarks>requires the item ID</remarks>
        /// <param name="itemData">the item data</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows CreateTestItemInlineResponse(QuestionAnswerData itemData)
        {
            if (itemData.ItemID <= 0)
            {
                throw new Exception("The QuestionAnswerData.ItemID is not set, please initialize it before trying to use it in a workflow.");
            }
            TestTypeInlineResponseForm testItem = new TestTypeInlineResponseForm();
            testItem.Data = itemData;
            AssessWorkflows.TestTunnelPage.TestList.Add(testItem);
            return this;
        }
        /// <summary>
        /// create a matching test item, and add it to the test tunnel
        /// </summary>
        /// <remarks>requires the item ID</remarks>
        /// <param name="itemData">the item data</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows CreateTestItemMatching(QuestionAnswerData itemData)
        {
            if (itemData.ItemID <= 0)
            {
                throw new Exception("The QuestionAnswerData.ItemID is not set, please initialize it before trying to use it in a workflow.");
            }
            TestTypeMatchingForm testItem = new TestTypeMatchingForm();
            testItem.Data = itemData;
            AssessWorkflows.TestTunnelPage.TestList.Add(testItem);
            return this;
        }
        /// <summary>
        /// create a drag and drop test item, and add it to the test tunnel
        /// </summary>
        /// <remarks>requires the item ID</remarks>
        /// <param name="itemData">the item data</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows CreateTestItemDragDrop(QuestionAnswerData itemData)
        {
            if (itemData.ItemID <= 0)
            {
                throw new Exception("The QuestionAnswerData.ItemID is not set, please initialize it before trying to use it in a workflow.");
            }
            TestTypeDragDropForm testItem = new TestTypeDragDropForm();
            testItem.Data = itemData;
            AssessWorkflows.TestTunnelPage.TestList.Add(testItem);
            return this;
        }
        /// <summary>
        /// create a click stick click drop test item, and add it to the test tunnel
        /// </summary>
        /// <remarks>requires the item ID</remarks>
        /// <param name="itemData">the item data</param>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows CreateTestItemClickStickClickDrop(QuestionAnswerData itemData)
        {
            if (itemData.ItemID <= 0)
            {
                throw new Exception("The QuestionAnswerData.ItemID is not set, please initialize it before trying to use it in a workflow.");
            }
            TestTypeClickStickClickDropForm testItem = new TestTypeClickStickClickDropForm();
            testItem.Data = itemData;
            AssessWorkflows.TestTunnelPage.TestList.Add(testItem);
            return this;
        }
        /// <summary>
        /// focus on the view test details page
        /// </summary>
        /// <remarks>requires the ViewTestDetailsPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows ViewTestDetailsPageFocus()
        {
            //wait for a couple of seconds before switching windows
            Thread.Sleep(2000);
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception("The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ViewTestDetailsPage.SwitchToWindow();
            return this;
        }
        /// <summary>
        /// focus on the student home page
        /// </summary>
        /// <remarks>requires the StudentHomePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows StudentHomePageFocus()
        {
            //wait for a couple of seconds before switching windows
            Thread.Sleep(2000);
            if (AssessWorkflows.StudentHomePage == null)
            {
                throw new Exception("The StudentHomePage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.StudentHomePage.SwitchToWindow();
            return this;
        }
        /// <summary>
        /// reload the student home page
        /// </summary>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows StudentHomePageReload()
        {
            AssessWorkflows.StudentHomePage = new StudentHomePage();
            return this;
        }
        /// <summary>
        /// student home page take a test input form fields
        /// </summary>
        /// <remarks>requires the OnlinePassCode and StudentHomePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows StudentHomePageTakeATestFormInputFormFields()
        {
            if (AssessWorkflows.StudentHomePage == null)
            {
                throw new Exception("The StudentHomePage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.StudentHomePage.Data == null)
            {
                throw new Exception("The StudentHomeData is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.StudentHomePage.StudentHomeTakeATestForm.InputFormFields();
            return this;
        }
        /// <summary>
        /// submit student home page take a test form
        /// </summary>
        /// <remarks>requires the OnlinePassCode and StudentHomePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows StudentHomePageTakeATestFormSubmitForm()
        {
            if (AssessWorkflows.StudentHomePage == null)
            {
                throw new Exception("The StudentHomePage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.StudentHomePage.Data == null)
            {
                throw new Exception("The StudentHomeData is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.StudentHomePage.StudentHomeTakeATestForm.SubmitForm();
            return this;
        }
        /// <summary>
        /// student home page take a test input form fields and submit
        /// </summary>
        /// <remarks>requires the OnlinePassCode and StudentHomePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows StudentHomePageTakeATestFormInputAndSubmitForm()
        {
            if (AssessWorkflows.StudentHomePage == null)
            {
                throw new Exception("The StudentHomePage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.StudentHomePage.Data == null)
            {
                throw new Exception("The StudentHomeData is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.StudentHomePage.StudentHomeTakeATestForm.InputAndSubmitForm();
            return this;
        }
        /// <summary>
        /// student home page start the test
        /// </summary>
        /// <remarks>requires the StudentHomePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows StudentHomePageTakeATestFormStartTest()
        {
            if (AssessWorkflows.StudentHomePage == null)
            {
                throw new Exception("The StudentHomePage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage = AssessWorkflows.StudentHomePage.StudentHomeTakeATestForm.ClickStartTestButton();
            return this;
        }
        /// <summary>
        /// online test tunnel: test instructions page start test now
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestInstructionsPageStartTestNow()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.TestTunnelPage.TestList == null)
            {
                throw new Exception("The TestTunnelPage.TestList is null, please initialize it before trying to use it in a workflow.");
            }
            int index = 0;
            foreach (var testTypeForm in AssessWorkflows.TestTunnelPage.TestList)
            {
                Assert.IsNotNull(testTypeForm.Data, "The TestTunnelPage.TestList[" + index + "].DataObject is null, please initialize it before trying to use it in a workflow.");
                index++;
            }
            //associate the test tunnel's index with the item id in the list of test items
            AssessWorkflows.TestTunnelPage.AssociateTestTunnelIndexWithTestList();
            AssessWorkflows.TestTunnelPage.Footer.StartTestNow();
            return this;
        }
        /// <summary>
        /// online test tunnel: test instructions page open schoolnet online help page
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestInstructionsPageOpenOnlineTestHelp()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.TestTunnelPage.Data == null)
            {
                throw new Exception("The TestTunnelData is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.SchoolnetOnlineHelpPage = AssessWorkflows.TestTunnelPage.Header.SelectOnlineTestHelp();
            return this;
        }
        /// <summary>
        /// online test tunnel: schoolnet online help page close
        /// </summary>
        /// <remarks>
        /// requires the TestTunnelPage to be initialized in this class, 
        /// requires the SchoolnetOnlineHelpPage to be initialized in this class
        /// </remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows SchoolnetOnlineHelpPageClose()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.SchoolnetOnlineHelpPage == null)
            {
                throw new Exception("The SchoolnetOnlineHelpPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.SchoolnetOnlineHelpPage.Close();
            AssessWorkflows.TestTunnelPage.SwitchToTestTunnelWindow();
            return this;
        }
        /// <summary>
        /// online test tunnel: test instructions page verify test name
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestInstructionsPageVerifyTestName()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.TestTunnelPage.Data == null)
            {
                throw new Exception("The TestTunnelData is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Detail.VerifyTestNameInTestInstructions();
            return this;
        }
        /// <summary>
        /// online test tunnel: test instructions page verify first name
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestInstructionsPageVerifyFirstName()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.TestTunnelPage.Data == null)
            {
                throw new Exception("The TestTunnelData is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Detail.VerifyTestersFirstNameInTestInstructions();
            return this;
        }
        /// <summary>
        /// online test tunnel: test instructions page verify last name
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestInstructionsPageVerifyLastName()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.TestTunnelPage.Data == null)
            {
                throw new Exception("The TestTunnelData is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Detail.VerifyTestersLastNameInTestInstructions();
            return this;
        }
        /// <summary>
        /// online test tunnel: test instructions page verify test name
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestTunnelHeaderVerifyTestName()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.TestTunnelPage.Data == null)
            {
                throw new Exception("The TestTunnelData is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Header.VerifyTestName();
            return this;
        }
        /// <summary>
        /// online test tunnel: test instructions page verify first name
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestTunnelHeaderVerifyFirstName()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.TestTunnelPage.Data == null)
            {
                throw new Exception("The TestTunnelData is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Header.VerifyTestersFirstName();
            return this;
        }
        /// <summary>
        /// online test tunnel: test instructions page verify last name
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestTunnelHeaderVerifyLastName()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.TestTunnelPage.Data == null)
            {
                throw new Exception("The TestTunnelData is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Header.VerifyTestersLastName();
            return this;
        }
        /// <summary>
        /// online test tunnel: test header verify clock time. 
        /// This function verified that the actual time is LESS than or EQUAL to expected time. 
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestTunnelHeaderVerifyClockTime()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.TestTunnelPage.Data == null)
            {
                throw new Exception("The TestTunnelData is null, please initialize it before trying to use it in a workflow.");
            }
            string actualTime = AssessWorkflows.TestTunnelPage.Header.GetClockTime();

            DateTime actualClockTime = Convert.ToDateTime(actualTime);
            DateTime expectedClockTime = Convert.ToDateTime(((DefaultData)AssessWorkflows.TestTunnelPage.Data).ExpectedResult);
            Assert.IsTrue(expectedClockTime >= actualClockTime,
                string.Format("Test Tunnel header, actual time is greater than expected time {0}", expectedClockTime));

            return this;
        }
        /// <summary>
        /// online test tunnel: pause test
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestTunnelPagePause()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Footer.Pause();
            return this;
        }
        /// <summary>
        /// online test tunnel: exit test,
        /// focus on the view test details page
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestTunnelPageExitTestToViewTestDetailsPage()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Footer.ExitTest();
            ViewTestDetailsPageFocus();
            return this;
        }
        /// <summary>
        /// online test tunnel: exit test,
        /// focus on the student home page
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestTunnelPageExitTestToStudentHomePage()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Footer.ExitTest();
            StudentHomePageFocus();
            StudentHomePageReload();
            return this;
        }
        /// <summary>
        /// online test tunnel page view test summary
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestTunnelPageViewTestSummary()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Footer.ViewTestSummary();
            return this;
        }
        /// <summary>
        /// online test tunnel: test response summary page, go to a question
        /// Index 0, 1, 2 ... 0 is the first question.
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestResponseSummaryPageGoToQuestion(int index)
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.TestResponseSummary.GoToQuestion(index + 1);
            return this;
        }
        /// <summary>
        /// online test tunnel: test response summary page view test summary
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestResponseSummaryPageReturnToTest()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Footer.ReturnToTest();
            return this;
        }
        /// <summary>
        /// online test tunnel: test response summary page submit test
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestResponseSummaryPageSubmitTest()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Footer.SubmitTest();
            return this;
        }
        /// <summary>
        /// online test tunnel: test response summary page submit test yes
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestResponseSummaryPageSubmitTestYes()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Footer.SubmitTestYes();
            return this;
        }
        /// <summary>
        /// online test tunnel: test response summary page submit test no
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestResponseSummaryPageSubmitTestNo()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Footer.SubmitTestNo();
            return this;
        }
        /// <summary>
        /// online test tunnel: test response summary page close test,
        /// focus on the view test details page
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestResponseSummaryPageCloseTestToViewTestDetailsPage()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Footer.CloseTest();
            ViewTestDetailsPageFocus();
            return this;
        }
        /// <summary>
        /// online test tunnel: test response summary page close test,
        /// focus on the student home page
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestResponseSummaryPageCloseTestToStudentHomePage()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Footer.CloseTest();
            StudentHomePageFocus();
            StudentHomePageReload();
            return this;
        }
        /// <summary>
        /// online test tunnel: test response summary page, verified warning message
        /// focus on the student home page
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestResponseSummaryPageVerifyWarningMessage(string expectedMessage)
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                AssessWorkflows.TestTunnelPage.Data = new DefaultData { ExpectedResult = expectedMessage };
            }
            string actualWarning = AssessWorkflows.TestTunnelPage.TestResponseSummary.GetWarningMessage();
            Assert.IsTrue(actualWarning.Contains(expectedMessage));

            return this;
        }
        /// <summary>
        /// online test tunnel: next item
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestTunnelPageNext()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Footer.Next();
            return this;
        }
        /// <summary>
        /// online test tunnel: previous item
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestTunnelPagePrevious()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Footer.Previous();
            return this;
        }
        /// <summary>
        /// online test tunnel: test summary
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestTunnelPageTestSummary()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Footer.TestSummary();
            return this;
        }
        /// <summary>
        /// online test tunnel: item input form fields
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestTunnelPageItemInputFormFields()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.TestTunnelPage.TestList == null)
            {
                throw new Exception("The TestTunnelPage.TestList is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.TestTunnelPage.TestList.Count == 0)
            {
                throw new Exception("The TestTunnelPage.TestList count is 0, please initialize it before trying to use it in a workflow.");
            }
            int index = 0;
            foreach (var testTypeForm in AssessWorkflows.TestTunnelPage.TestList)
            {
                testTypeForm.InputFormFields();
                if (index >= AssessWorkflows.TestTunnelPage.TestList.Count - 1)
                {
                    //No next button on last item page. Click Test Summary to proceed. 
                    AssessWorkflows.TestTunnelPage.Footer.TestSummary();
                }
                else
                {
                    AssessWorkflows.TestTunnelPage.Footer.Next();
                }
                index++;
            }
            return this;
        }
        /// <summary>
        /// online test tunnel: light box: verify message text
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestTunnelPageLightBoxVerifyMessageText(string expectedMessage)
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.Form.LightBoxMessageVerifyText(expectedMessage);
            return this;
        }
        /// <summary>
        /// online test tunnel: test response summary page: verify warning message
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestResponseSummaryPageVerifyWarningMessage()
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.TestTunnelPage.TestResponseSummary.VerifyWarningMessage();
            return this;
        }

        /// <summary>
        /// online test tunnel: flag an item
        /// Index 0 is the first item
        /// </summary>
        /// <remarks>requires the TestTunnelPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public OnlineTestTunnelWorkflows TestTunnelPageFlagItem(int index)
        {
            if (AssessWorkflows.TestTunnelPage == null)
            {
                throw new Exception("The TestTunnelPage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.TestTunnelPage.TestList == null)
            {
                throw new Exception("The TestTunnelPage.TestList is null, please initialize it before trying to use it in a workflow.");
            }
            if (AssessWorkflows.TestTunnelPage.TestList.Count == 0)
            {
                throw new Exception("The TestTunnelPage.TestList count is 0, please initialize it before trying to use it in a workflow.");
            }

            AssessWorkflows.TestTunnelPage.TestList[index].FlagItem();
            return this;
        }


        private EditScheduleData getScheduleData(int addDays)
        {
            EditScheduleData data = new EditScheduleData();
            data.StartDate = DateTime.Now.AddDays(addDays).ToString("MM/dd/yyyy");
            data.EndDate = DateTime.Now.AddDays(addDays + 1).ToString("MM/dd/yyyy");
            data.ScoreDate = DateTime.Now.AddDays(addDays + 1).ToString("MM/dd/yyyy");
            return data;
        }

        private EditScheduleData getScheduleData_testTime(int addDays)
        {
            EditScheduleData data = new EditScheduleData();
            data.StartDate = DateTime.Now.AddDays(addDays).ToString("MM/dd/yyyy");
            data.EndDate = DateTime.Now.AddDays(addDays + 1).ToString("MM/dd/yyyy");
            data.ScoreDate = DateTime.Now.AddDays(addDays + 1).ToString("MM/dd/yyyy");
            data.TestTime = "1"; // 1 minute
            return data;
        }
    }
}
