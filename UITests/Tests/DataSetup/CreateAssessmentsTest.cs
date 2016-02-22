using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TestContext = NUnit.Framework.TestContext;
using TestConfiguration = Core.Config.TestConfiguration;
using ApplicationType = Core.Framework.ApplicationType;
using TestGridType = Core.Framework.TestGridType;
using TestToolType = Core.Framework.TestToolType;
using ApplicationName = UITests.Framework.ApplicationName;
using TestRunner = UITests.Framework.TestRunner;
using DriverCommands = Core.Tools.WebDriver.DriverCommands;
using Core.Tools.WebDriver;
using UITests.Data.Assess.Standards;
using UITests.Pages.Login;
using UITests.Pages.Login.Components;
using UITests.Pages.Home;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCentral.ItemCentral;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.Schedule;
using UITests.Pages.Assess.Schedule.EditSchedule;
using UITests.Pages.Assess.TestCreateEdit;
using UITests.Pages.Assess.TestCreateEdit.CreateTestManual;
using UITests.Workflow;

namespace UITests.Tests.DataSetup
{
    /// <summary>
    /// Data setup script to create assessments.
    /// </summary>
    [TestFixture()]
    [Parallelizable(ParallelScope.Fixtures)]//Parallelizable(ParallelScope.Children) not working yet...
    [Category("UITest"), Category("Assess"), Category("DataSetup"), Category("CreateAssessmentsTests")]
    public class CreateAssessmentsTest : TestRunner
    {
        public CreateAssessmentsTest()
        {
            TestContext.WriteLine("CreateAssessmentsTest");
        }

        [SetUp]
        public void SetUp()
        {
            TestConfiguration testConfiguration = new TestConfiguration();
            testConfiguration.TestName = TestContext.CurrentContext.Test.FullName;
            testConfiguration.TextWriter = TestContext.Out;
            /*
            testConfiguration.Language = "en";
            testConfiguration.Country = "US";
            testConfiguration.TestTool = TestToolType.WEBDRIVER;
            testConfiguration.TestGrid = TestGridType.LOCAL;
            testConfiguration.ApplicationName = ApplicationName.schoolnetsingletenant;
            testConfiguration.ApplicationType = ApplicationType.WINDOWS_WEB_FIREFOX;
            testConfiguration.OperatingSystemVersion = "8";
            testConfiguration.BrowserVersion = "32";
            testConfiguration.EnvironmentName = "automation";
            testConfiguration.DeviceOrientation = "landscape";
            testConfiguration.ReleaseVersion = "17";
            */
            this.ReadEnvironmentVariables(testConfiguration);
            this.SetUpBeforeMethodNUnit(testConfiguration);
        }

        /// <summary>
        /// Data setup script: State Admin Create Manual Test With One True False Item
        /// </summary>
        [Test(Author = "Santosh", Description = "Data setup script: State Admin Create Manual Test With One True False Item")]
        public void StateAdmin_Create_Manual_Test_With_One_True_False_Item()
        {
            try
            {
                this.SchoolNet().LoadWebPage();

                Workflows workflows = new Workflows();
                workflows.SignInAsStateAdmin();

                //Create manual test
                TestContext.WriteLine("\n --- Create manual test ---");
                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .NavigateToCreateManualTestPage();

                //set up data for CreateTest.aspx
                CreateTestManualData createTestManualData = workflows.AssessWorkflows.CreateTestManualPage.InitData();
                createTestManualData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.TestCreateEdit.CreateTestResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                createTestManualData.TestId = "OriginalAutomationTest_StateAdminCreateTrueFalseItemTest";
                createTestManualData.TestCategory = "State Benchmark";
                workflows.AssessWorkflows.CreateTestManualPage.Data = createTestManualData;

                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .NavigateToChooseNewItemPage()
                    .ChooseNewItemTrueFalse();

                //Create item True False
                TestContext.WriteLine("\n --- Create true false item ---");

                //set up data for EditTestItem.aspx
                EditPageData editPageData = workflows.AssessWorkflows.EditQuestionCreateNewItemPage.InitData();
                editPageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.TrueFalseItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageData.ItemTypeData.Name = "OriginalAutomationItem_StateAdminCreateTrueFalseItem";
                editPageData.ItemTypeData.Keyword = "OriginalAutomationItem_StateAdminCreateTrueFalseItem_Keyword";
                editPageData.ItemTypeData.Publisher = "OriginalAutomationItem_StateAdminCreateTrueFalseItem_Publisher";
                editPageData.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditQuestionCreateNewItemPage.Data = editPageData;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditQuestionCreateNewItemPageInputAndSubmitForm();

                //Schedule manual test
                TestContext.WriteLine("\n --- Schedule manual test ---");
                workflows.AssessWorkflows.ViewTestDetailsWorkflows
                    .ViewTestDetailsPageMakePublic()
                    .ViewTestDetailsPageReadyToSchedule()
                    .ViewTestDetailsPageSchedule();

                //set up data for EditSchedule.aspx
                workflows.AssessWorkflows.EditSchedulePage.Data = getScheduleData(-1);

                workflows.AssessWorkflows.EditScheduleWorkflows
                    .EditSchedulePageAcceptQuickAssignmentInputAndSubmitForm();

                //Get online passcode
                TestContext.WriteLine("\n --- Get online passcode ---");
                string onlinePassCode = workflows.AssessWorkflows.EditScheduleWorkflows.OnlinePassCode;

                //TEARDOWN
                TestContext.WriteLine("\n --- Sign out ---");
                workflows.SignOut();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace);
                new DriverCommands().GetScreenshotAndPageSource();
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        /// <summary>
        /// Data setup script: Leadership Create Manual Test With One Multiple Choice Item
        /// </summary>
        [Test(Author = "Santosh", Description = "Data setup script: Leadership Create Manual Test With One Multiple Choice Item")]
        public void Leadership_Create_Manual_Test_With_One_Multiple_Choice_Item()
        {
            try
            {
                this.SchoolNet().LoadWebPage();

                Workflows workflows = new Workflows();
                workflows.SignInAsLeadership();

                //Create manual test
                TestContext.WriteLine("\n --- Create manual test ---");
                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .NavigateToCreateManualTestPage();

                //set up data for CreateTest.aspx
                CreateTestManualData createTestManualData = workflows.AssessWorkflows.CreateTestManualPage.InitData();
                createTestManualData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.TestCreateEdit.CreateTestResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                createTestManualData.TestId = "OriginalAutomationTest_ManualTestOneMulipleChoiceItem";
                createTestManualData.TestCategory = "District Benchmark";
                workflows.AssessWorkflows.CreateTestManualPage.Data = createTestManualData;

                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .NavigateToChooseNewItemPage()
                    .ChooseNewItemMultipleChoice()
                    ;

                //Create item Multiple Choice
                TestContext.WriteLine("\n --- Create multiple choice item ---");

                //set up data for EditTestItem.aspx
                EditPageData editPageData = workflows.AssessWorkflows.EditQuestionCreateNewItemPage.InitData();
                editPageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.MultipleChoiceItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageData.ItemTypeData.Name = "OriginalAutomationTest_ManualTestOneMulipleChoiceItem";
                editPageData.ItemTypeData.Keyword = "OriginalAutomationTest_ManualTestOneMulipleChoiceItem_Keyword";
                editPageData.ItemTypeData.Publisher = "OriginalAutomationTest_ManualTestOneMulipleChoiceItem_Publisher";
                /* Martin: I don't think this modified data is necessary, the default data should be sufficient
                editPageData.QuestionAnswerData.QuestionContent = "Scrambling answer choice";
                editPageData.QuestionAnswerData.AnswerList.Clear();
                editPageData.QuestionAnswerData.AnswerList.Add("A");
                editPageData.QuestionAnswerData.AnswerList.Add("B");
                editPageData.QuestionAnswerData.AnswerList.Add("C");
                editPageData.QuestionAnswerData.AnswerList.Add("D");
                editPageData.QuestionAnswerData.CorrectAnswerList.Clear();
                editPageData.QuestionAnswerData.CorrectAnswerList.Add("A");
                editPageData.QuestionAnswerData.PointValuePair.Clear();
                editPageData.QuestionAnswerData.PointValuePair.Add("A", "1");
                */
                editPageData.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditQuestionCreateNewItemPage.Data = editPageData;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditQuestionCreateNewItemPageInputAndSubmitForm();

                ////Manual test set to public
                //TestContext.WriteLine("\n --- Make manual test public ---");
                //workflows.AssessWorkflows.ViewTestDetailsWorkflows
                //    .ViewTestDetailsPageMakePublic();
                //    .ViewTestDetailsPageReadyToSchedule()
                //    .ViewTestDetailsPageSchedule();

                //TEARDOWN
                TestContext.WriteLine("\n --- Sign out ---");
                workflows.SignOut();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace);
                new DriverCommands().GetScreenshotAndPageSource();
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        /// <summary>
        /// Data setup script: District Admin Create Manual Test With One True False Item
        /// </summary>
        [Test(Author = "Santosh", Description = "Data setup script: District Admin Create Manual Test With One True False Item")]
        public void DistrictAdmin_Create_Manual_Test_With_One_True_False_Item()
        {
            try
            {
                this.SchoolNet().LoadWebPage();

                Workflows workflows = new Workflows();
                workflows.SignInAsDistrictAdmin();

                //Create manual test
                TestContext.WriteLine("\n --- Create manual test ---");
                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .NavigateToCreateManualTestPage();

                //set up data for CreateTest.aspx
                CreateTestManualData createTestManualData = workflows.AssessWorkflows.CreateTestManualPage.InitData();
                createTestManualData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.TestCreateEdit.CreateTestResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                createTestManualData.TestId = "OriginalAutomationTest_ManualTestOneTrueFalseItem";
                createTestManualData.TestCategory = "District Benchmark";
                workflows.AssessWorkflows.CreateTestManualPage.Data = createTestManualData;

                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .NavigateToChooseNewItemPage()
                    .ChooseNewItemTrueFalse()
                    ;

                //Create item true false
                TestContext.WriteLine("\n --- Create true false item ---");

                //set up data for EditTestItem.aspx
                EditPageData editPageData = workflows.AssessWorkflows.EditQuestionCreateNewItemPage.InitData();
                editPageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.TrueFalseItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageData.ItemTypeData.Name = "OriginalAutomationTest_ManualTestOneTrueFalseItem";
                editPageData.ItemTypeData.Keyword = "OriginalAutomationTest_ManualTestOneTrueFalseItem_Keyword";
                editPageData.ItemTypeData.Publisher = "OriginalAutomationTest_ManualTestOneTrueFalseItem_Publisher";
                editPageData.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditQuestionCreateNewItemPage.Data = editPageData;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditQuestionCreateNewItemPageInputAndSubmitForm();

                ////Manual test set to public
                //TestContext.WriteLine("\n --- Make manual test public ---");
                //workflows.AssessWorkflows.ViewTestDetailsWorkflows
                //    .ViewTestDetailsPageMakePublic();
                //    .ViewTestDetailsPageReadyToSchedule()
                //    .ViewTestDetailsPageSchedule();

                //TEARDOWN
                TestContext.WriteLine("\n --- Sign out ---");
                workflows.SignOut();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace);
                new DriverCommands().GetScreenshotAndPageSource();
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        /// <summary>
        /// Data setup script: Leadership Create Manual Test With 2 open response, 1 multiple choice, 1 Gridded Items
        /// </summary>
        [Test(Author = "Santosh", Description = "Data setup script: Leadership Create Manual Test With 2 open response, 1 multiple choice, 1 Gridded Items")]
        public void Leadership_Create_Manual_Test_With_2OR_1MC_1Grid_Items()
        {
            try
            {
                this.SchoolNet().LoadWebPage();

                Workflows workflows = new Workflows();
                workflows.SignInAsLeadership();

                //Create manual test
                TestContext.WriteLine("\n --- Create manual test ---");
                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .NavigateToCreateManualTestPage();

                //set up data for CreateTest.aspx
                CreateTestManualData createTestManualData = workflows.AssessWorkflows.CreateTestManualPage.InitData();
                createTestManualData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.TestCreateEdit.CreateTestResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                createTestManualData.TestId = "OriginalAutomationTest_ManualTest2OR1MC1GridItem";
                createTestManualData.TestCategory = "District Benchmark";
                createTestManualData.NumberOfItems = 4;
                workflows.AssessWorkflows.CreateTestManualPage.Data = createTestManualData;

                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .NavigateToChooseNewItemPage()
                    .ChooseNewItemOpenResponse()
                    ;

                //Create item Open Response
                TestContext.WriteLine("\n --- Create 1st item, open response ---");

                //set up data for EditTestItem.aspx
                EditPageData editPageDataOR = workflows.AssessWorkflows.EditQuestionCreateNewItemPage.InitData();
                editPageDataOR.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.OpenResponseItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageDataOR.ItemTypeData.Name = "OriginalAutomationTest_ManualTest2OR1MC1GridItem";
                editPageDataOR.ItemTypeData.Keyword = "OriginalAutomationTest_ManualTest2OR1MC1GridItem_Keyword";
                editPageDataOR.ItemTypeData.Publisher = "OriginalAutomationTest_ManualTest2OR1MC1GridItem_Publisher";
                editPageDataOR.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditQuestionCreateNewItemPage.Data = editPageDataOR;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditQuestionCreateNewItemPageInputFormFields()
                    .EditQuestionCreateNewItemPageSelectRibbon(2)
                    .AssessWorkflows.CreateManualTestWorkflows
                    .ChooseNewItemOpenResponse()
                    ;

                TestContext.WriteLine("\n --- Create 2nd item, open response ---");
                workflows.AssessWorkflows.EditQuestionCreateNewItemPage.Data = editPageDataOR;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditQuestionCreateNewItemPageInputFormFields()
                    .EditQuestionCreateNewItemPageSelectRibbon(3)
                    .AssessWorkflows.CreateManualTestWorkflows
                    .ChooseNewItemMultipleChoice()
                    ;

                TestContext.WriteLine("\n --- Create 3rd item, multiple choice ---");

                //set up data for EditTestItem.aspx
                EditPageData editPageDataMC = workflows.AssessWorkflows.EditQuestionCreateNewItemPage.InitData();
                editPageDataMC.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.MultipleChoiceItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageDataMC.ItemTypeData.Name = "OriginalAutomationTest_ManualTestOneMulipleChoiceItem";
                editPageDataMC.ItemTypeData.Keyword = "OriginalAutomationTest_ManualTestOneMulipleChoiceItem_Keyword";
                editPageDataMC.ItemTypeData.Publisher = "OriginalAutomationTest_ManualTestOneMulipleChoiceItem_Publisher";
                editPageDataMC.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditQuestionCreateNewItemPage.Data = editPageDataMC;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditQuestionCreateNewItemPageInputFormFields()
                    .EditQuestionCreateNewItemPageSelectRibbon(4)
                    .AssessWorkflows.CreateManualTestWorkflows
                    .ChooseNewItemGridded()
                    ;

                TestContext.WriteLine("\n --- Create 4th item, gridded ---");

                //set up data for EditTestItem.aspx
                EditPageData editPageDataGr = workflows.AssessWorkflows.EditQuestionCreateNewItemPage.InitData();
                editPageDataGr.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.GriddedItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageDataGr.ItemTypeData.Name = "OriginalAutomationTest_ManualTestOneMulipleChoiceItem";
                editPageDataGr.ItemTypeData.Keyword = "OriginalAutomationTest_ManualTestOneMulipleChoiceItem_Keyword";
                editPageDataGr.ItemTypeData.Publisher = "OriginalAutomationTest_ManualTestOneMulipleChoiceItem_Publisher";
                editPageDataGr.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditQuestionCreateNewItemPage.Data = editPageDataGr;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditQuestionCreateNewItemPageInputAndSubmitForm()
                    ;

                ////Manual test set to public
                //TestContext.WriteLine("\n --- Make manual test public ---");
                //workflows.AssessWorkflows.ViewTestDetailsWorkflows
                //    .ViewTestDetailsPageMakePublic();
                //    .ViewTestDetailsPageReadyToSchedule()
                //    .ViewTestDetailsPageSchedule();

                //TEARDOWN
                TestContext.WriteLine("\n --- Sign out ---");
                workflows.SignOut();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace);
                new DriverCommands().GetScreenshotAndPageSource();
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }



        private EditScheduleData getScheduleData(int addDays)
        {
            EditScheduleData editScheduleData = new EditScheduleData();
            editScheduleData.StartDate = DateTime.Now.AddDays(addDays).ToString("MM/dd/yyyy");
            editScheduleData.EndDate = DateTime.Now.AddDays(addDays + 7).ToString("MM/dd/yyyy");
            editScheduleData.ScoreDate = DateTime.Now.AddDays(addDays + 7).ToString("MM/dd/yyyy");
            return editScheduleData;
        }
    }
}

