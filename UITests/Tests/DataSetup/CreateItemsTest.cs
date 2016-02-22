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
using UITests.Data.Assess.Standards;
using UITests.Pages.Login;
using UITests.Pages.Login.Components;
using UITests.Pages.Home;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;
using UITests.Workflow;

namespace UITests.Tests.DataSetup
{
    /// <summary>
    /// Data setup script to create items.
    /// </summary>
    [TestFixture()]
    [Parallelizable(ParallelScope.Fixtures)]//Parallelizable(ParallelScope.Children) not working yet...
    [Category("UITest"), Category("Assess"), Category("DataSetup"), Category("CreateItems")]
    public class CreateItemsTest : TestRunner
    {
        public CreateItemsTest()
        {
            TestContext.WriteLine("CreateItemsTest");
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
            testConfiguration.TestGrid = TestGridType.SAUCE_LABS;
            testConfiguration.ApplicationName = ApplicationName.schoolnetsingletenant;
            testConfiguration.ApplicationType = ApplicationType.LINUX_WEB_FIREFOX;
            testConfiguration.OperatingSystemVersion = "";
            testConfiguration.BrowserVersion = "38";
            testConfiguration.EnvironmentName = "automation";
            testConfiguration.DeviceOrientation = "landscape";
            testConfiguration.ReleaseVersion = "17";
            */
            this.ReadEnvironmentVariables(testConfiguration);
            this.SetUpBeforeMethodNUnit(testConfiguration);
        }

        #region Create Multiple Choice Items

        /// <summary>
        /// Data setup script: District Admin Create multiple choice item with publisher
        /// </summary>
        /// <remarks>Test Case #25342</remarks>
        [Test(Author = "Santosh", Description = "Data setup script: District Admin Create multiple choice item with publisher")]
        public void DistrictAdmin_Create_MultipleChoice_With_Publisher()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInAsDistrictAdmin();

                TestContext.WriteLine("\n--- Create a multiple choice item ---");
                workflows.AssessWorkflows.CreateItemWorkflows
                    .NavigateToEditTestItemChooseNewItemPage()
                    .EditTestItemCreateNewItemSelectMultipleChoice()
                    ;

                //set up data for EditTestItem.aspx
                EditPageData editPageData = workflows.AssessWorkflows.EditTestItemCreateNewItemPage.InitData();
                editPageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.MultipleChoiceItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageData.ItemTypeData.Name = "OriginalAutomationItemMC";
                editPageData.ItemTypeData.Keyword = "OriginalAutomationItemMC_Keyword";
                editPageData.ItemTypeData.Publisher = "OriginalAutomationItemMC_Publisher";
                editPageData.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditTestItemCreateNewItemPage.Data = editPageData;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditTestItemCreateNewItemPageInputAndSubmitForm()
                    .EditItemAvailabilityShareWithEveryone()
                    .EditItemAvailabilityPageSubmitForm()
                    ;

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
        /// Data setup script: Leadership Create a Multiple Choice Item With One Column Layout From Create New Item Page
        /// </summary>
        [Test(Author = "Santosh", Description = "Data setup script: Leadership Create a Multiple Choice Item With One Column Layout From Create New Item Page")]
        public void Leadership_Create_A_Multiple_Choice_Item_With_One_Column_Layout()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInAsLeadership();

                TestContext.WriteLine("\n--- Create a multiple choice item ---");
                workflows.AssessWorkflows.CreateItemWorkflows
                    .NavigateToEditTestItemChooseNewItemPage()
                    .EditTestItemCreateNewItemSelectMultipleChoice();

                //set up data for EditTestItem.aspx
                EditPageData editPageData = workflows.AssessWorkflows.EditTestItemCreateNewItemPage.InitData();
                editPageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.MultipleChoiceItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageData.ItemTypeData.Name = "OriginalAutomationMCItemWithOneColumnLayoutName";
                editPageData.ItemTypeData.Keyword = "OriginalAutomationMultipleChoiceItemKeyword";
                editPageData.ItemTypeData.Publisher = "SNAutomationTeam";
                editPageData.QuestionAnswerData.AnswerChoiceLayoutOption = MultipleChoiceLayout.OneColumn;
                editPageData.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditTestItemCreateNewItemPage.Data = editPageData;

                /* Open response only
                 * 
                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditTestItemCreateNewItemPageInputFormFields()
                    ;
                 * 
                //16.3, EnableSpecialCharacterPalette is no longer check as default. Need to check on this as tc 80866
                //will fail if this doesn't
                if (workflows.AssessWorkflows.EditTestItemCreateNewItemPage.Form.ItemTypeForm.GetType() == typeof(ItemTypeOpenResponseForm))
                {
                    ((ItemTypeOpenResponseForm)workflows.AssessWorkflows.EditTestItemCreateNewItemPage.Form.ItemTypeForm).CheckEnableSpecialCharacterPalette();
                }
                */

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditTestItemCreateNewItemPageInputAndSubmitForm()
                    .EditItemAvailabilityShareWithEveryone()
                    .EditItemAvailabilityPageSubmitForm();

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
        /// Data setup script: Leadership Create a Multiple Choice Item With Two Columns Across Then Down Layout From Create New Item Page
        /// </summary>
        [Test(Author = "Santosh", Description = "Data setup script: Leadership Create a Multiple Choice Item With Two Columns Across Then Down Layout From Create New Item Page")]
        public void Leadership_Create_A_Multiple_Choice_Item_With_Two_Columns_Across_Then_Down_Layout()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInAsLeadership();

                TestContext.WriteLine("\n--- Create a multiple choice item ---");
                workflows.AssessWorkflows.CreateItemWorkflows
                    .NavigateToEditTestItemChooseNewItemPage()
                    .EditTestItemCreateNewItemSelectMultipleChoice();

                //set up data for EditTestItem.aspx
                EditPageData editPageData = workflows.AssessWorkflows.EditTestItemCreateNewItemPage.InitData();
                editPageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.MultipleChoiceItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageData.ItemTypeData.Name = "OriginalAutomationMCItemWithTwoColumnsAcrossThenDownLayoutName";
                editPageData.ItemTypeData.Keyword = "OriginalAutomationMultipleChoiceItemKeyword";
                editPageData.ItemTypeData.Publisher = "SNAutomationTeam";
                editPageData.QuestionAnswerData.AnswerChoiceLayoutOption = MultipleChoiceLayout.TwoColumnsAcrossThenDown;
                editPageData.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditTestItemCreateNewItemPage.Data = editPageData;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditTestItemCreateNewItemPageInputAndSubmitForm()
                    .EditItemAvailabilityShareWithEveryone()
                    .EditItemAvailabilityPageSubmitForm();

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
        /// Data setup script: Leadership Create a Multiple Choice Item With Two Columns Down Then Across Layout From Create New Item Page
        /// </summary>
        [Test(Author = "Santosh", Description = "Data setup script: Leadership Create a Multiple Choice Item With Two Columns Down Then Across Layout From Create New Item Page")]
        public void Leadership_Create_A_Multiple_Choice_Item_With_Two_Columns_Down_Then_Across_Layout()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInAsLeadership();

                TestContext.WriteLine("\n--- Create a multiple choice item ---");
                workflows.AssessWorkflows.CreateItemWorkflows
                    .NavigateToEditTestItemChooseNewItemPage()
                    .EditTestItemCreateNewItemSelectMultipleChoice();

                //set up data for EditTestItem.aspx
                EditPageData editPageData = workflows.AssessWorkflows.EditTestItemCreateNewItemPage.InitData();
                editPageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.MultipleChoiceItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageData.ItemTypeData.Name = "OriginalAutomationMCItemWithTwoColumnsDownThenAcrossLayoutName";
                editPageData.ItemTypeData.Keyword = "OriginalAutomationMultipleChoiceItemKeyword";
                editPageData.ItemTypeData.Publisher = "SNAutomationTeam";
                editPageData.QuestionAnswerData.AnswerChoiceLayoutOption = MultipleChoiceLayout.TwoColumnsDownThenAcross;
                editPageData.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditTestItemCreateNewItemPage.Data = editPageData;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditTestItemCreateNewItemPageInputAndSubmitForm()
                    .EditItemAvailabilityShareWithEveryone()
                    .EditItemAvailabilityPageSubmitForm();

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
        /// Data setup script: Leadership Create 5 Multiple Choice Items With One Column Layout From Create New Item Page
        /// </summary>
        [Test(Author = "Santosh", Description = "Data setup script: Leadership Create 5 Multiple Choice Items With One Column Layout From Create New Item Page")]
        public void Leadership_Create_5_Multiple_Choice_Items_With_One_Column_Layout()
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Leadership_Create_A_Multiple_Choice_Item_With_One_Column_Layout();
                }
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace);
                new DriverCommands().GetScreenshotAndPageSource();
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        /// <summary>
        /// Data setup script: Leadership Create 2 Multiple Choice Items With Two Columns Across Then Down Layout From Create New Item Page
        /// </summary>
        [Test(Author = "Santosh", Description = "Data setup script: Leadership Create 2 Multiple Choice Items With Two Columns Across Then Down Layout From Create New Item Page")]
        public void Leadership_Create_2_Multiple_Choice_Items_With_Two_Columns_Across_Then_Down_Layout()
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    Leadership_Create_A_Multiple_Choice_Item_With_Two_Columns_Across_Then_Down_Layout();
                }
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace);
                new DriverCommands().GetScreenshotAndPageSource();
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        /// <summary>
        /// Data setup script: Leadership Create 2 Multiple Choice Items With Two Columns Down Then Across Layout From Create New Item Page
        /// </summary>
        [Test(Author = "Santosh", Description = "Data setup script: Leadership Create 2 Multiple Choice Items With Two Columns Down Then Across Layout From Create New Item Page")]
        public void Leadership_Create_2_Multiple_Choice_Items_With_Two_Columns_Down_Then_Across_Layout()
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    Leadership_Create_A_Multiple_Choice_Item_With_Two_Columns_Down_Then_Across_Layout();
                }
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace);
                new DriverCommands().GetScreenshotAndPageSource();
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        #endregion //Create Multiple Choice Items

        #region Create True/False Items

        /// <summary>
        ///   Data setup script: District Admin Create true false item with publisher
        /// </summary>
        /// <remarks>Test Case #25343</remarks>
        [Test(Author = "Santosh", Description = "Data setup script: District Admin Create true false item with publisher")]
        public void DistrictAdmin_Create_TrueFalse_With_Publisher()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInAsDistrictAdmin();

                TestContext.WriteLine("\n--- Create a true/false item ---");
                workflows.AssessWorkflows.CreateItemWorkflows
                    .NavigateToEditTestItemChooseNewItemPage()
                    .EditTestItemCreateNewItemSelectTrueFalse()
                    ;

                //set up data for EditTestItem.aspx
                EditPageData editPageData = workflows.AssessWorkflows.EditTestItemCreateNewItemPage.InitData();
                editPageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.TrueFalseItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageData.ItemTypeData.Name = "OriginalAutomationItemTF";
                editPageData.ItemTypeData.Keyword = "OriginalAutomationItemTF_Keyword";
                editPageData.ItemTypeData.Publisher = "OriginalAutomationItemTF_Publisher";
                editPageData.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditTestItemCreateNewItemPage.Data = editPageData;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditTestItemCreateNewItemPageInputAndSubmitForm()
                    .EditItemAvailabilityShareWithEveryone()
                    .EditItemAvailabilityPageSubmitForm()
                    ;

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
        /// Data setup script: Leadership Create a True False Item With Correct Answer Set To True From Create New Item Page
        /// </summary>
        [Test(Author = "Santosh", Description = "Data setup script: Leadership Create a True False Item With Correct Answer Set To True From Create New Item Page")]
        public void Leadership_Create_A_True_False_Item_With_Correct_Answer_Set_To_True()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInAsLeadership();

                TestContext.WriteLine("\n--- Create a true/false item ---");
                workflows.AssessWorkflows.CreateItemWorkflows
                    .NavigateToEditTestItemChooseNewItemPage()
                    .EditTestItemCreateNewItemSelectTrueFalse();

                //set up data for EditTestItem.aspx
                EditPageData editPageData = workflows.AssessWorkflows.EditTestItemCreateNewItemPage.InitData();
                editPageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.TrueFalseItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageData.ItemTypeData.Name = "OriginalAutomationTFItemWithCorrectResponseTrueName";
                editPageData.ItemTypeData.Keyword = "OriginalAutomationTrueFalseItemKeyword";
                editPageData.ItemTypeData.Publisher = "SNAutomationTeam";
                editPageData.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditTestItemCreateNewItemPage.Data = editPageData;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditTestItemCreateNewItemPageInputAndSubmitForm()
                    .EditItemAvailabilityShareWithEveryone()
                    .EditItemAvailabilityPageSubmitForm();

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
        /// Data setup script: Leadership Create 5 True False Items With Correct Answer Set To True From Create New Item Page
        /// </summary>
        [Test(Author = "Santosh", Description = "Data setup script: Leadership Create 5 True False Items With Correct Answer Set To True From Create New Item Page")]
        public void Leadership_Create_5_True_False_Items_With_Correct_Answer_Set_To_True()
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Leadership_Create_A_True_False_Item_With_Correct_Answer_Set_To_True();
                }
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace);
                new DriverCommands().GetScreenshotAndPageSource();
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        #endregion //Create True/False Items

        #region Create Matching Items

        /// <summary>
        /// Data setup script: Leadership Create a Matching Item From Create New Item Page
        /// </summary>
        [Test(Author = "Santosh", Description = "Data setup script: Leadership Create a Matching Item From Create New Item Page")]
        public void Leadership_Create_A_Matching_Item()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInAsLeadership();

                TestContext.WriteLine("\n--- Create a matching item ---");
                workflows.AssessWorkflows.CreateItemWorkflows
                    .NavigateToEditTestItemChooseNewItemPage()
                    .EditTestItemCreateNewItemSelectMatching();

                //set up data for EditTestItem.aspx
                EditPageData editPageData = workflows.AssessWorkflows.EditTestItemCreateNewItemPage.InitData();
                editPageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.MatchingItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageData.ItemTypeData.Name = "OriginalAutomationMatchingItemName";
                editPageData.ItemTypeData.Keyword = "OriginalAutomationMatchingItemKeyword";
                editPageData.ItemTypeData.Publisher = "SNAutomationTeam";
                editPageData.QuestionAnswerData.QuestionAnswerPair.Add("carrot", "orange");
                editPageData.QuestionAnswerData.QuestionAnswerPair.Add("eggplant", "purple");
                editPageData.QuestionAnswerData.CorrectAnswerPair.Add("carrot", "orange");
                editPageData.QuestionAnswerData.CorrectAnswerPair.Add("eggplant", "purple");
                editPageData.QuestionAnswerData.StudentAnswerPair.Add("carrot", "orange");
                editPageData.QuestionAnswerData.StudentAnswerPair.Add("eggplant", "purple");
                editPageData.QuestionAnswerData.PointValuePair.Add("carrot", "5");
                editPageData.QuestionAnswerData.PointValuePair.Add("eggplant", "5");
                editPageData.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditTestItemCreateNewItemPage.Data = editPageData;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditTestItemCreateNewItemPageInputAndSubmitForm()
                    .EditItemAvailabilityShareWithEveryone()
                    .EditItemAvailabilityPageSubmitForm();

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
        /// Data setup script: Leadership Create 2 Matching Items From Create New Item Page
        /// </summary>
        [Test(Author = "Santosh", Description = "Data setup script: Leadership Create 2 Matching Items From Create New Item Page")]
        public void Leadership_Create_2_Matching_Items()
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    Leadership_Create_A_Matching_Item();
                }
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace);
                new DriverCommands().GetScreenshotAndPageSource();
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        #endregion //Create Matching Items

        #region Create Gridded Items

        /// <summary>
        ///   Data setup script: District Admin Create gridded item with publisher
        /// </summary>
        /// <remarks>Test Case #25344</remarks>
        [Test(Author = "Santosh", Description = "Data setup script: District Admin Create gridded item with publisher")]
        public void DistrictAdmin_Create_Gridded_With_Publisher()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInAsDistrictAdmin();

                TestContext.WriteLine("\n--- Create a gridded item ---");
                workflows.AssessWorkflows.CreateItemWorkflows
                    .NavigateToEditTestItemChooseNewItemPage()
                    .EditTestItemCreateNewItemSelectGridded()
                    ;

                //set up data for EditTestItem.aspx
                EditPageData editPageData = workflows.AssessWorkflows.EditTestItemCreateNewItemPage.InitData();
                editPageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.GriddedItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageData.ItemTypeData.Name = "OriginalAutomationItemGridded";
                editPageData.ItemTypeData.Keyword = "OriginalAutomationItemGridded_Keyword";
                editPageData.ItemTypeData.Publisher = "OriginalAutomationItemGridded_Publisher";
                editPageData.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditTestItemCreateNewItemPage.Data = editPageData;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditTestItemCreateNewItemPageInputAndSubmitForm()
                    .EditItemAvailabilityShareWithEveryone()
                    .EditItemAvailabilityPageSubmitForm()
                    ;

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
        ///   Data setup script: Leadership Create gridded item with leadership
        /// </summary>
        /// <remarks>Test Case #24197</remarks>
        [Test(Author = "Santosh", Description = "Data setup script: Leadership Create gridded item with leadership")]
        public void Leadership_Create_Gridded_With_Leadership()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInAsLeadership();

                TestContext.WriteLine("\n--- Create a gridded item ---");
                workflows.AssessWorkflows.CreateItemWorkflows
                    .NavigateToEditTestItemChooseNewItemPage()
                    .EditTestItemCreateNewItemSelectGridded()
                    ;

                //set up data for EditTestItem.aspx
                EditPageData editPageData = workflows.AssessWorkflows.EditTestItemCreateNewItemPage.InitData();
                editPageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.GriddedItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageData.ItemTypeData.Name = "OriginalAutomationItemGriddedBm_Leadership";
                editPageData.ItemTypeData.Keyword = "OriginalAutomationItemGriddedBm_Leadership_Keyword";
                editPageData.ItemTypeData.Publisher = "OriginalAutomationItemGriddedBm_Leadership_Publisher";
                editPageData.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditTestItemCreateNewItemPage.Data = editPageData;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditTestItemCreateNewItemPageInputAndSubmitForm()
                    .EditItemAvailabilityShareWithEveryone()
                    .EditItemAvailabilityPageSubmitForm()
                    ;

                workflows.SignOut();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace);
                new DriverCommands().GetScreenshotAndPageSource();
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        #endregion //Create Gridded Items

        #region Create Open Response Items

        /// <summary>
        ///   Data setup script: District Admin Create open response item with publisher
        /// </summary>
        /// <remarks>Test Case #25345</remarks>
        [Test(Author = "Santosh", Description = "Data setup script: District Admin Create open response item with publisher")]
        public void DistrictAdmin_Create_OpenResponse_With_Publisher()
        {
            try
            {
                this.SchoolNet().LoadWebPage();
                Workflows workflows = new Workflows();
                workflows.SignInAsDistrictAdmin();

                TestContext.WriteLine("\n--- Create a open response item ---");
                workflows.AssessWorkflows.CreateItemWorkflows
                    .NavigateToEditTestItemChooseNewItemPage()
                    .EditTestItemCreateNewItemSelectOpenResponse()
                    ;

                //set up data for EditTestItem.aspx
                EditPageData editPageData = workflows.AssessWorkflows.EditTestItemCreateNewItemPage.InitData();
                editPageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.OpenResponseItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageData.ItemTypeData.Name = "OriginalAutomationItemOR";
                editPageData.ItemTypeData.Keyword = "OriginalAutomationItemOR_Keyword";
                editPageData.ItemTypeData.Publisher = "OriginalAutomationItemOR_Publisher";
                editPageData.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                workflows.AssessWorkflows.EditTestItemCreateNewItemPage.Data = editPageData;

                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditTestItemCreateNewItemPageInputAndSubmitForm()
                    .EditItemAvailabilityShareWithEveryone()
                    .EditItemAvailabilityPageSubmitForm()
                    ;

                workflows.SignOut();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace);
                new DriverCommands().GetScreenshotAndPageSource();
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        #endregion //Create Open Response Items


    }
}
