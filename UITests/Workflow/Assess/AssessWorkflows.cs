using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages;
using UITests.Pages.Assess;
using UITests.Pages.Assess.Components;
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
using UITests.Pages.Assess.Scantron;
using UITests.Pages.Assess.Schedule;
using UITests.Pages.Assess.Schedule.EditSchedule;
using UITests.Pages.Assess.Standards;
using UITests.Pages.Assess.TestCentral;
using UITests.Pages.Assess.TestCreateEdit;
using UITests.Pages.Assess.TestCreateEdit.Components;
using UITests.Pages.Assess.TestCreateEdit.CreateTestBySelectingStandards;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestDetail.ViewTestDetails;
using UITests.Pages.Assess.TestTunnel;
using UITests.Pages.Assess.TestWindow;
using UITests.Pages.Assess.Track;
using UITests.Pages.Home;
using UITests.Pages.OnlineHelp;
using UITests.Workflow;

namespace UITests.Workflow.Assess
{
    /// <summary>
    /// the assessment workflows
    /// </summary>
    public class AssessWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public AssessWorkflows(Workflows workflows)
            : base()
        {
            this.Workflows = workflows;
            CreateItemWorkflows = new CreateItemWorkflows( this);
            PassageWorkflows = new PassageWorkflows( this);
            RubricWorkflows = new RubricWorkflows( this);
            CreateExpressTestWorkflows = new CreateExpressTestWorkflows( this);
            CreateManualTestWorkflows = new CreateManualTestWorkflows( this);
            ViewTestDetailsWorkflows = new ViewTestDetailsWorkflows( this);
            EditScheduleWorkflows = new EditScheduleWorkflows( this);
            EditAssignmentCourseWorkflows = new EditAssignmentCourseWorkflows( this);
            OnlineTestTunnelWorkflows = new OnlineTestTunnelWorkflows( this);
            ItemCentralWorkflows = new ItemCentralWorkflows( this);
            TestCentralWorkflows = new TestCentralWorkflows( this);
            TestWindowWorkflows = new TestWindowWorkflows( this);
        }
        //workflows
        /// <summary>
        /// Workflows
        /// </summary>
        public Workflows Workflows { get; set; }
        /// <summary>
        /// CreateItemWorkflows
        /// </summary>
        public CreateItemWorkflows CreateItemWorkflows { get; set; }
        /// <summary>
        /// PassageWorkflows
        /// </summary>
        public PassageWorkflows PassageWorkflows { get; set; }
        /// <summary>
        /// RubricWorkflows
        /// </summary>
        public RubricWorkflows RubricWorkflows { get; set; }
        /// <summary>
        /// CreateExpressTestWorkflows
        /// </summary>
        public CreateExpressTestWorkflows CreateExpressTestWorkflows { get; set; }
        /// <summary>
        /// CreateManualTestWorkflows
        /// </summary>
        public CreateManualTestWorkflows CreateManualTestWorkflows { get; set; }
        /// <summary>
        /// ViewTestDetailsWorkflows
        /// </summary>
        public ViewTestDetailsWorkflows ViewTestDetailsWorkflows { get; set; }
        /// <summary>
        /// EditScheduleWorkflows
        /// </summary>
        public EditScheduleWorkflows EditScheduleWorkflows { get; set; }
        /// <summary>
        /// EditAssignmentCourseWorkflows
        /// </summary>
        public EditAssignmentCourseWorkflows EditAssignmentCourseWorkflows { get; set; }
        /// <summary>
        /// OnlineTestTunnelWorkflows
        /// </summary>
        public OnlineTestTunnelWorkflows OnlineTestTunnelWorkflows { get; set; }
        /// <summary>
        /// ItemCentralWorkflows
        /// </summary>
        public ItemCentralWorkflows ItemCentralWorkflows { get; set; }
        /// <summary>
        /// TestCentralWorkflows
        /// </summary>
        public TestCentralWorkflows TestCentralWorkflows { get; set; }
        /// <summary>
        /// TestWindowWorkflows
        /// </summary>
        public TestWindowWorkflows TestWindowWorkflows { get; set; }


        //pages
        /// <summary>
        /// HomePage
        /// </summary>
        public HomePage HomePage { get; set; }
        /// <summary>
        /// StudentHomePage
        /// </summary>
        public StudentHomePage StudentHomePage { get; set; }
        /// <summary>
        /// TeacherHomePage
        /// </summary>
        public TeacherHomePage TeacherHomePage { get; set; }
        /// <summary>
        /// ProfileHomePage
        /// </summary>
        public ProfileHomePage ProfileHomePage { get; set; }
        /// <summary>
        /// TeacherProfileHomePage
        /// </summary>
        public TeacherProfileHomePage TeacherProfileHomePage { get; set; }
        /// <summary>
        /// CreateTestPortalPage
        /// </summary>
        public CreateTestPortalPage CreateTestPortalPage { get; set; }
        /// <summary>
        /// ItemCentralHomePage
        /// </summary>
        public ItemCentralHomePage ItemCentralHomePage { get; set; }
        /// <summary>
        /// ItemCentralPage
        /// </summary>
        public ItemCentralPage ItemCentralPage { get; set; }
        /// <summary>
        /// ItemCentralSearchResultsPage
        /// </summary>
        public ItemCentralSearchResultsPage ItemCentralSearchResultsPage { get; set; }
        /// <summary>
        /// ViewItemStatisticsPage
        /// </summary>
        public ViewItemStatisticsPage ViewItemStatisticsPage { get; set; }
        /// <summary>
        /// ViewTestDetailsPage GridList
        /// </summary>
        public List<TestContentLineItem> ViewTestDetailsPageGridList { get; set; }
        /// <summary>
        /// TestCentralHomePage
        /// </summary>
        public TestCentralHomePage TestCentralHomePage { get; set; }
        /// <summary>
        /// CreateTestExpressPage
        /// </summary>
        public CreateTestExpressPage CreateTestExpressPage { get; set; }
        /// <summary>
        /// CreateTestManualPage
        /// </summary>
        public CreateTestManualPage CreateTestManualPage { get; set; }
        /// <summary>
        /// CreateTestBySelectingStandardsPage
        /// </summary>
        public CreateTestBySelectingStandardsPage CreateTestBySelectingStandardsPage { get; set; }
        /// <summary>
        /// CreatePassagePage
        /// </summary>
        public EditPassagePage EditPassagePage { get; set; }
        /// ItemCentralcreateNewItem
        /// </summary>
        public EditTestItemCreateNewItemPage CreateItemPage { get; set; }
        /// ItemCentralChooseItemType
        /// </summary>
        public EditTestItemChooseNewItemPage EditTestItemChooseNewItemPage { get; set; }
        /// <summary>
        /// PassageDetailPage
        /// </summary>
        public PassageDetailPage PassageDetailPage { get; set; }
        /// <summary>
        /// PlanHomePage
        /// </summary>
        public PlanHomePage PlanHomePage { get; set; }
        /// <summary>
        /// CreateEditTestWindowPage
        /// </summary>
        public CreateEditTestWindowPage CreateEditTestWindowPage { get; set; }
        /// <summary>
        /// ViewTestWindowPage
        /// </summary>
        public ViewTestWindowPage ViewTestWindowPage { get; set; }
        /// <summary>
        /// EditTestItemCreateNewItemPage
        /// </summary>
        public EditTestItemCreateNewItemPage EditTestItemCreateNewItemPage { get; set; }
        /// <summary>
        /// EditQuestionChooseNewItemPage
        /// </summary>
        public EditQuestionChooseNewItemPage EditQuestionChooseNewItemPage { get; set; }
        /// <summary>
        /// EditQuestionCreateNewItemPage
        /// </summary>
        public EditQuestionCreateNewItemPage EditQuestionCreateNewItemPage { get; set; }
        /// <summary>
        /// ViewTestDetailsPage
        /// </summary>
        public ViewTestDetailsPage ViewTestDetailsPage { get; set; }
        /// <summary>
        /// EditSchedulePage
        /// </summary>
        public EditSchedulePage EditSchedulePage { get; set; }
        /// <summary>
        /// EditItemAvailabilityPage
        /// </summary>
        public EditItemAvailabilityPage EditItemAvailabilityPage { get; set; }
        /// <summary>
        /// ChooseGroupingRubricDialog
        /// </summary>
        public ChooseGroupingRubricDialog ChooseGroupingRubricDialog { get; set; }
        /// <summary>
        /// EditRubricPage
        /// </summary>
        public EditRubricPage EditRubricPage { get; set; }
        /// <summary>
        /// EditRubricAvailabilityPage
        /// </summary>
        public EditRubricAvailabilityPage EditRubricAvailabilityPage { get; set; }
        /// <summary>
        /// ShareWithOtherUser
        /// </summary>
        public ShareWithOtherUser ShareWithOtherUser { get; set; }
        /// <summary>
        /// test tunnel default page
        /// </summary>
        public DefaultPage TestTunnelPage { get; set; }
        /// <summary>
        /// EditAssignmentCoursePage
        /// </summary>
        public EditAssignmentCoursePage EditAssignmentCoursePage { get; set; }
        /// <summary>
        /// EditTeacherAssignmentPage
        /// </summary>
        public EditTeacherAssignmentPage EditTeacherAssignmentPage { get; set; }
        /// <summary>
        /// SchoolnetOnlineHelpPage
        /// </summary>
        public SchoolnetOnlineHelpPage SchoolnetOnlineHelpPage { get; set; }

        //Data
        public string TestName;
        public string OnlinePasscode;
        public List<TestContentLineItem> TestItem;

        /// <summary>
        /// navigate to the assess dashboard page
        /// </summary>
        /// <returns>Workflows</returns>
        public AssessWorkflows NavigateToAssessDashboardPage()
        {
            if (Workflows.HomePage == null)
            {
                throw new Exception("The HomePage is null, please initialize it before trying to use it in a workflow.");
            }
            HomePage = Workflows.HomePage;
            if ((Workflows.IsDistrictAdmin)
                || (Workflows.IsSchoolAdmin)
                || (Workflows.IsLeadership)
                || (Workflows.IsStudent)
                || (Workflows.IsSystemSetup)
                || (Workflows.IsStateAdmin)
                || (Workflows.IsRegionalAdmin))
            {
                ProfileHomePage = HomePage.Header.AssessmentAdminPage();
            }
            if (Workflows.IsTeacher)
            {
                TeacherProfileHomePage = HomePage.Header.AssessmentAdminTeacherPage();
                ProfileHomePage = TeacherProfileHomePage;
            }
            return this;
        }
        /// <summary>
        /// navigate to the create test portal page
        /// </summary>
        /// <returns>Workflows</returns>
        public AssessWorkflows NavigateToCreateTestPortalPage()
        {
            CreateTestPortalPage = null;
            if ((Workflows.IsDistrictAdmin)
                || (Workflows.IsSchoolAdmin)
                || (Workflows.IsLeadership)
                || (Workflows.IsStudent)
                || (Workflows.IsSystemSetup)
                || (Workflows.IsRegionalAdmin))
            {
                if (ProfileHomePage == null)
                {
                    throw new Exception("Navigate to the ProfileHomePage before trying to use this workflow.");
                }
                CreateTestPortalPage = ProfileHomePage.Detail.CreateATest();
            }
            if (Workflows.IsTeacher)
            {
                if (TeacherProfileHomePage == null)
                {
                    throw new Exception("Navigate to the ProfileHomePage before trying to use this workflow.");
                }
                CreateTestPortalPage = TeacherProfileHomePage.Detail.CreateATest();
            }
            return this;
        }
        /// <summary>
        /// navigate to the item central page
        /// </summary>
        /// <returns>Workflows</returns>
        public AssessWorkflows NavigateToItemCentralHomePage()
        {
            ItemCentralHomePage = null;
            if ((Workflows.IsDistrictAdmin)
                || (Workflows.IsSchoolAdmin)
                || (Workflows.IsLeadership)
                || (Workflows.IsStudent)
                || (Workflows.IsSystemSetup)
                || (Workflows.IsRegionalAdmin))
            {
                if (ProfileHomePage == null)
                {
                    throw new Exception("Navigate to the ProfileHomePage before trying to use this workflow.");
                }
                ItemCentralHomePage = ProfileHomePage.Detail.FindAnItem();
            }

            if (Workflows.IsTeacher)
            {
                if (TeacherProfileHomePage == null)
                {
                    throw new Exception("Navigate to the ProfileHomePage before trying to use this workflow.");
                }
                ItemCentralHomePage = TeacherProfileHomePage.Detail.FindAnItem();
            }
            return this;
        }
        /// <summary>
        /// navigate to the test central page
        /// </summary>
        /// <returns>Workflows</returns>
        public AssessWorkflows NavigateToTestCentralHomePage()
        {
            TestCentralHomePage = null;
            if ((Workflows.IsDistrictAdmin)
                || (Workflows.IsSchoolAdmin)
                || (Workflows.IsLeadership)
                || (Workflows.IsStudent)
                || (Workflows.IsSystemSetup)
                || (Workflows.IsStateAdmin)
                || (Workflows.IsRegionalAdmin))
            {
                if (ProfileHomePage == null)
                {
                    throw new Exception("Navigate to the ProfileHomePage before trying to use this workflow.");
                }
                TestCentralHomePage = ProfileHomePage.Form.ClickTestCentralLink();
            }
            if (Workflows.IsTeacher)
            {
                if (TeacherProfileHomePage == null)
                {
                    throw new Exception("Navigate to the ProfileHomePage before trying to use this workflow.");
                }
                TestCentralHomePage = TeacherProfileHomePage.Detail.FindATest();
            }
            return this;
        }

        /// <summary>
        /// navigate to the assess dashboard page
        /// </summary>
        /// <returns>Workflows</returns>
        public AssessWorkflows NavigateToAssessTestWindowsPage()
        {
            if (Workflows.HomePage == null)
            {
                throw new Exception("The HomePage is null, please initialize it before trying to use it in a workflow.");
            }
            HomePage = Workflows.HomePage;
            HomePage.Header.InitElements();

            if ((Workflows.IsDistrictAdmin)
                || (Workflows.IsSchoolAdmin)
                || (Workflows.IsLeadership)
                || (Workflows.IsStudent)
                || (Workflows.IsSystemSetup)
                || (Workflows.IsTeacher)
                || (Workflows.IsRegionalAdmin))
            {
                PlanHomePage = HomePage.Header.AssessmentAdminMenu().ManageTestWindows();
            }
            //if (Workflows.IsTeacher)
            //{
            //    TeacherProfileHomePage = HomePage.Header.AssessmentAdminTeacherPage();
            //    ProfileHomePage = TeacherProfileHomePage;
            //}
            return this;
        }

        /// <summary>
        /// sign in as district admin, search for a test, and delete the test
        /// </summary>
        /// <param name="searchTestName">the name of the test to search for</param>
        /// <returns>Workflows</returns>
        public AssessWorkflows SearchAndDeleteTestByDistrictAdmin(string searchTestName)
        {
            Workflows.SignInAsDistrictAdmin();
            SearchAndDeleteTest(searchTestName);
            return this;
        }
        /// <summary>
        /// sign in as leadership, search for a test, and delete the test
        /// </summary>
        /// <param name="searchTestName">the name of the test to search for</param>
        /// <returns>Workflows</returns>
        public AssessWorkflows SearchAndDeleteTestByLeadership(string searchTestName)
        {
            Workflows.SignInAsLeadership();
            SearchAndDeleteTest(searchTestName);
            return this;
        }
        /// <summary>
        /// search for a test, and delete the test
        /// </summary>
        /// <param name="searchTestName">the name of the test to search for</param>
        /// <returns>Workflows</returns>
        private AssessWorkflows SearchAndDeleteTest(string searchTestName)
        {
            Report.Write("--search for a test and delete it--");
            TestCentralWorkflows
                .NavigateToTestCentralHomePage()
                .SearchForTestByName(searchTestName)
                .ClickFirstItemTestnameLink();

            ViewTestDetailsWorkflows
                .ViewTestDetailsPageDeleteTest();
            return this;
        }

        /// <summary>
        /// search for a test, and copy the oldest test
        /// </summary>
        /// <param name="searchTestName">the name of the test to search for</param>
        /// <returns>Workflows</returns>
        public AssessWorkflows SearchAndCopyOldestTest(string searchTestName)
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
            TestName = string.Format("Zcopy {0}: {1}", shorterTestName, DateTime.Now.ToString("yyMMddMMssfff"));

            //navigate to test central
            TestCentralWorkflows.NavigateToTestCentralHomePage();

            //search for the test
            TestCentralWorkflows
                .SearchForTestByName(searchTestName)
                .SortTestOldestItemFirst()
                .ClickTestnameLink(searchTestName);

            //copy the test
            ViewTestDetailsWorkflows.ViewTestDetailsPageCopyTest();

            //modify the copied test name
            CreateTestManualPage.Data.TestId = TestName;
            CreateManualTestWorkflows
                .CopiedManualTestToViewTestDetails();

            return this;
        }

        /// <summary>
        /// search for a item, and copy the item
        /// </summary>
        /// <param name="itemName">the name of the item to search for</param>
        /// <returns>Workflows</returns>
        public AssessWorkflows SearchAndCopyItem(string itemName)
        {
            Report.Write("--search for a item, copy it--");

            //navigate to item central
            NavigateToItemCentralHomePage();

            ItemCentralHomePage.InitData();
            ItemCentralHomePage.Data.SearchData = itemName;
            //search and view item
            ItemCentralWorkflows
                .ItemCentralHomePageInputAndSubmitForm()
                .ItemCentralSearchResultsPageViewFirstItem()
                ;

            ViewItemStatisticsPage = new ViewItemStatisticsPage();
            //https://qa-163st.sndev.net/Assess/Items/ViewItemStatistics.aspx?test_item_id=410795&referrer=~%2FAssess%2FItemCentral.aspx%3Freferrer%3D~%252fAssess%252fItemCentralHome.aspx
            //copy item
            ViewItemStatisticsPage.Detail.CopyItem();
            //postback
            ViewItemStatisticsPage = new ViewItemStatisticsPage();

            return this;
        }

        /// <summary>
        /// search for a passage, and copy the passage
        /// </summary>
        /// <param name="passageName">the name of the passage to search for</param>
        /// <returns>Workflows</returns>
        public AssessWorkflows SearchAndCopyPassage(string passageName)
        {
            Report.Write("--search for a passage, copy it--");

            //navigate to item central
            NavigateToItemCentralHomePage();

            ItemCentralHomePage.InitData();
            ItemCentralHomePage.Data.SearchData = passageName;
            //search and view passage
            ItemCentralWorkflows
                .SelectPassageTab()
                .ItemCentralHomePageInputAndSubmitForm()
                .ItemCentralSearchResultsPageViewFirstItem()
                ;

            PassageDetailPage = new PassageDetailPage();
            //https://qa-163st.sndev.net/Assess/Items/ViewItemStatistics.aspx?test_item_id=410795&referrer=~%2FAssess%2FItemCentral.aspx%3Freferrer%3D~%252fAssess%252fItemCentralHome.aspx
            //copy passage
            PassageDetailPage.Detail.ClickCopyLink();
            //postback
            PassageDetailPage = new PassageDetailPage();

            return this;
        }

        /// <summary>
        /// schedule test from public status
        /// </summary>
        /// <returns>Workflows</returns>
        public AssessWorkflows ScheduleTestFromPublicStatus()
        {
            //schedule the test
            ViewTestDetailsWorkflows
                .ViewTestDetailsPageMakePublic()
                .ViewTestDetailsPageVerifyIsPublicDraft()
                .ViewTestDetailsPageReadyToSchedule()
                .ViewTestDetailsPageVerifyIsReadyToSchedule()
                .ViewTestDetailsPageSchedule();
            EditSchedulePage.Data = getScheduleData(-1);
            EditScheduleWorkflows
                .EditSchedulePageAcceptQuickAssignmentInputAndSubmitForm()
                ;

            //get the online pass code
            OnlinePasscode = EditScheduleWorkflows.OnlinePassCode;
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
    }
}
