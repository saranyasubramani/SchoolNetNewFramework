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
    public class CreateAssessmentsIterativeTest : TestRunner
    {
        public CreateAssessmentsIterativeTest()
        {
            TestContext.WriteLine("CreateAssessmentsIterativeTest");
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
        /// Data setup script: Leadership Create A Manual Test With One Item Search (i.e. Multiple Choice Items only)
        /// Leadership Create A Manual Test By Looking Up Items That Meet A Single Search Criteria in Item Central And Move It To Ready To Schedule Stage.
        /// Works when you have to add only Items which can be found using a Single Search Criteria (Keyword, Name, etc)
        /// </summary>
        /// <param name="createTestAndItemCentralData">create test and item central data</param>
        [Test(Author = "Santosh", Description = "Data setup script: Leadership Create A Manual Test With One Item Search"),
        TestCaseSource(typeof(CreateTestAndItemCentralParameters), "GetParametersToForOneItem")]
        public void Leadership_Create_A_Manual_Test_With_1_Item_Search(CreateTestAndItemCentralData createTestAndItemCentralData)
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
                createTestManualData.TestId = createTestAndItemCentralData.TestID;
                createTestManualData.TestCategory = "District Benchmark";
                createTestManualData.NumberOfItems = createTestAndItemCentralData.NumberOfItems;
                workflows.AssessWorkflows.CreateTestManualPage.Data = createTestManualData;

                //create a manual test and look up an existing item
                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .SetNumberOfItems(createTestManualData.NumberOfItems)
                    .NavigateToChooseNewItemPage()
                    .ChooseNewItemLookupInItemCentral();

                //select item central advanced search
                workflows.AssessWorkflows.ItemCentralWorkflows
                    .SelectAdvanceSearch();

                //set up data for ItemCentral.aspx
                ItemCentralData itemCentralData = workflows.AssessWorkflows.ItemCentralPage.InitData();
                itemCentralData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.ItemStatisticsResource",
                    "UITests.Data.Assess.Passage.PassageResource",
                    "UITests.Data.Assess.ItemCentral.ItemCentralResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                itemCentralData.ItemTypeData.Name = createTestAndItemCentralData.ItemName;
                itemCentralData.ItemTypeData.Keyword = createTestAndItemCentralData.ItemKeyword;
                itemCentralData.ItemTypeData.Publisher = "SNAutomationTeam";
                itemCentralData.ItemTypeData.ItemType = createTestAndItemCentralData.ItemType;
                itemCentralData.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                itemCentralData.ItemStatisticsData = null;
                itemCentralData.NumberOfItemsToBeAddedToTestFromSearchResults = createTestManualData.NumberOfItems;
                workflows.AssessWorkflows.ItemCentralPage.Data = itemCentralData;

                //input the item properties, and search for items
                workflows.AssessWorkflows.ItemCentralWorkflows
                    .ItemCentralPageInputAndSubmitForm_ItemProperties()
                    .ItemCentralPageSubmitForm();

                //check each item in the item central search results list
                for (int searchResultToSelectIndex = 0; searchResultToSelectIndex < createTestAndItemCentralData.NumberOfItems; searchResultToSelectIndex++)
                {
                    workflows.AssessWorkflows.ItemCentralWorkflows
                        .ItemCentralSearchResultsPageSelectItemInResultsListByIndex(searchResultToSelectIndex);
                }
                //add items to test
                workflows.AssessWorkflows.ItemCentralWorkflows
                    .ItemCentralSearchResultsPageAddItemsToViewTestDetailsPage();

                //verify the number of items added appear in the view test details results list
                if (this.SchoolNet().Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                {
                    itemCentralData.NumberOfItemsToBeAddedToTestFromSearchResults = workflows.AssessWorkflows.ViewTestDetailsPage.Form.GetResultsList().Count;
                }
                Assert.AreEqual(itemCentralData.NumberOfItemsToBeAddedToTestFromSearchResults,
                    workflows.AssessWorkflows.ViewTestDetailsPage.Form.GetResultsList().Count,
                    "Required number of Items have not been added to the Test");

                workflows.AssessWorkflows.ViewTestDetailsWorkflows
                    .ViewTestDetailsPageMakePublic()
                    .ViewTestDetailsPageReadyToSchedule();

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
        /// Data setup script: Leadership Create A Manual Test With Two Different Item Searches (i.e. Multiple Choice Items and Matching Items)
        /// Leadership Create A Manual Test By Looking Up  Items That Meet Two Different Search Criteria in Item Central And Move It To Ready To Schedule Stage.
        /// Works when you have to add only Items which can be found using a Single Search Criteria (Keyword, Name, etc)
        /// </summary>
        /// <param name="createTestAndItemCentralData">create test and item central data</param>
        /// <param name="createTestAndItemCentralData2">second create test and item central data</param>
        [Test(Author = "Santosh", Description = "Data setup script: Leadership Create A Manual Test With Two Different Item Searches"),
        TestCaseSource(typeof(CreateTestAndItemCentralParameters), "GetParametersToForTwoItems")]
        public void Leadership_Create_A_Manual_Test_With_2_Different_Item_Searches(CreateTestAndItemCentralData createTestAndItemCentralData,
            CreateTestAndItemCentralData createTestAndItemCentralData2)
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
                createTestManualData.TestId = createTestAndItemCentralData.TestID;
                createTestManualData.TestCategory = "District Benchmark";
                createTestManualData.NumberOfItems = createTestAndItemCentralData.NumberOfItems;
                workflows.AssessWorkflows.CreateTestManualPage.Data = createTestManualData;

                //create a manual test and look up an existing item
                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .SetNumberOfItems(createTestManualData.NumberOfItems)
                    .NavigateToChooseNewItemPage()
                    .ChooseNewItemLookupInItemCentral();

                //select item central advanced search
                workflows.AssessWorkflows.ItemCentralWorkflows
                    .SelectAdvanceSearch();

                //set up data for ItemCentral.aspx
                ItemCentralData itemCentralData = workflows.AssessWorkflows.ItemCentralPage.InitData();
                itemCentralData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.ItemStatisticsResource",
                    "UITests.Data.Assess.Passage.PassageResource",
                    "UITests.Data.Assess.ItemCentral.ItemCentralResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                itemCentralData.ItemTypeData.Name = createTestAndItemCentralData.ItemName;
                itemCentralData.ItemTypeData.Keyword = createTestAndItemCentralData.ItemKeyword;
                itemCentralData.ItemTypeData.Publisher = "SNAutomationTeam";
                itemCentralData.ItemTypeData.ItemType = createTestAndItemCentralData.ItemType;
                itemCentralData.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                itemCentralData.ItemStatisticsData = null;
                itemCentralData.NumberOfItemsToBeAddedToTestFromSearchResults = createTestManualData.NumberOfItems;
                workflows.AssessWorkflows.ItemCentralPage.Data = itemCentralData;

                //input the item properties, and search for items
                workflows.AssessWorkflows.ItemCentralWorkflows
                    .ItemCentralPageInputAndSubmitForm_ItemProperties()
                    .ItemCentralPageSubmitForm();

                //check each item in the item central search results list
                for (int searchResultToSelectIndex = 0; searchResultToSelectIndex < createTestAndItemCentralData.NumberOfItems; searchResultToSelectIndex++)
                {
                    workflows.AssessWorkflows.ItemCentralWorkflows
                        .ItemCentralSearchResultsPageSelectItemInResultsListByIndex(searchResultToSelectIndex);
                }
                //add items to test
                workflows.AssessWorkflows.ItemCentralWorkflows
                    .ItemCentralSearchResultsPageAddItemsToViewTestDetailsPage();

                //verify the number of items added appear in the view test details results list
                if (this.SchoolNet().Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                {
                    itemCentralData.NumberOfItemsToBeAddedToTestFromSearchResults = workflows.AssessWorkflows.ViewTestDetailsPage.Form.GetResultsList().Count;
                }
                Assert.AreEqual(itemCentralData.NumberOfItemsToBeAddedToTestFromSearchResults,
                    workflows.AssessWorkflows.ViewTestDetailsPage.Form.GetResultsList().Count,
                    "Required number of Items have not been added to the Test");

                //Assuming that we are already on the ViewTestDetail Page of the Test to which we need to Add More Items
                workflows.AssessWorkflows.ViewTestDetailsWorkflows
                    .ViewTestDetailsPageAddItem();

                //look up an existing item
                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .ChooseNewItemLookupInItemCentral();

                //select item central advanced search
                workflows.AssessWorkflows.ItemCentralWorkflows
                    .SelectAdvanceSearch();

                //set up data for ItemCentral.aspx
                itemCentralData.ItemTypeData.Name = createTestAndItemCentralData2.ItemName;
                itemCentralData.ItemTypeData.Keyword = createTestAndItemCentralData2.ItemKeyword;
                itemCentralData.ItemTypeData.Publisher = "SNAutomationTeam";
                itemCentralData.ItemTypeData.ItemType = createTestAndItemCentralData2.ItemType;
                itemCentralData.NumberOfItemsToBeAddedToTestFromSearchResults = createTestAndItemCentralData2.NumberOfItems;
                workflows.AssessWorkflows.ItemCentralPage.Data = itemCentralData;

                //input the item properties, and search for items
                workflows.AssessWorkflows.ItemCentralWorkflows
                    .ItemCentralPageInputAndSubmitForm_ItemProperties()
                    .ItemCentralPageSubmitForm();

                //check each item in the item central search results list
                for (int searchResultToSelectIndex = 0; searchResultToSelectIndex < createTestAndItemCentralData2.NumberOfItems; searchResultToSelectIndex++)
                {
                    workflows.AssessWorkflows.ItemCentralWorkflows
                        .ItemCentralSearchResultsPageSelectItemInResultsListByIndex(searchResultToSelectIndex);
                }
                //add items to test
                workflows.AssessWorkflows.ItemCentralWorkflows
                    .ItemCentralSearchResultsPageAddItemsToViewTestDetailsPage();

                //verify the number of items added appear in the view test details results list
                if (this.SchoolNet().Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                {
                    itemCentralData.NumberOfItemsToBeAddedToTestFromSearchResults = workflows.AssessWorkflows.ViewTestDetailsPage.Form.GetResultsList().Count;
                }
                Assert.AreEqual(itemCentralData.NumberOfItemsToBeAddedToTestFromSearchResults,
                    workflows.AssessWorkflows.ViewTestDetailsPage.Form.GetResultsList().Count,
                    "Required number of Items have not been added to the Test");

                workflows.AssessWorkflows.ViewTestDetailsWorkflows
                    .ViewTestDetailsPageMakePublic()
                    .ViewTestDetailsPageReadyToSchedule();

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


