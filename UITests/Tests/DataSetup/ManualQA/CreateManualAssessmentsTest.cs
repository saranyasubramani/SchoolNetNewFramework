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
using UITests.Pages.Assess.Passage;
using UITests.Pages.Assess.Passage.EditPassage;
using UITests.Pages.Assess.Schedule;
using UITests.Pages.Assess.Schedule.EditSchedule;
using UITests.Pages.Assess.TestCreateEdit;
using UITests.Pages.Assess.TestCreateEdit.CreateTestManual;
using UITests.Pages.Assess.TestDetail.ViewTestDetails;
using UITests.Workflow;

namespace UITests.Tests.DataSetup.ManualQA
{
    /// <summary>
    /// Manual QA Data setup script to create assessments.
    /// </summary>
    [TestFixture()]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("UITest"), Category("ManualQADataSetup")]
    public class CreateManualAssessmentsTest : TestRunner
    {
        public CreateManualAssessmentsTest()
        {
            TestContext.WriteLine("CreateManualAssessmentsTest");
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
        /// Manual QA Data setup script: Leadership Creates A Manual Test with Six Items
        /// </summary>
        /// <remarks>Data setup script to assist Manual QA Testing</remarks>
        [Test(Author = "Santosh", Description = "Manual QA Data setup script: Leadership Creates A Manual Test with Six Items")]
        public void Leadership_Creates_A_Manual_Test_With_Six_Items_Manual_QA_Data_Setup()
        {
            try
            {
                this.SchoolNet().LoadWebPage();

                Workflows workflows = new Workflows();
                workflows.SignInAsLeadership();

                TestContext.WriteLine("\n--- Create a passage ---");
                workflows.AssessWorkflows.PassageWorkflows
                    .NavigateToCreatePassagePage();

                //set up data for EditPassage.aspx
                EditPassageData editPassageData = workflows.AssessWorkflows.EditPassagePage.InitData();
                editPassageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.Passage.ManualQAPassageResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPassageData.Title = string.Format("OriginalAutomationTest Passage. Goldfish (from Wikipedia): {0}", DateTime.Now.ToString("yyMMddMMssfff"));
                editPassageData.PassageText = this.createPassageText();
                workflows.AssessWorkflows.EditPassagePage.Data = editPassageData;

                //create a passage, then edit it
                workflows.AssessWorkflows.PassageWorkflows
                    .CreatePassagePageInputFormFields()
                    .PassageDetailPageEdit();

                //set up data for EditPassage.aspx
                editPassageData = workflows.AssessWorkflows.EditPassagePage.InitData();
                editPassageData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.Passage.ManualQAPassageResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPassageData.Title = string.Format("OriginalAutomationTest Passage. Goldfish (from Wikipedia): {0}", DateTime.Now.ToString("yyMMddMMssfff"));
                editPassageData.PassageText = this.editPassageText();
                workflows.AssessWorkflows.EditPassagePage.Data = editPassageData;

                //edit the passage
                TestContext.WriteLine("\n--- Edit a passage ---");
                workflows.AssessWorkflows.PassageWorkflows
                    .EditPassagePageInputFormFields();

                //Create manual test
                TestContext.WriteLine("\n --- Create manual test ---");
                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .NavigateToCreateManualTestPage();

                //set up data for CreateTest.aspx
                CreateTestManualData createTestManualData = workflows.AssessWorkflows.CreateTestManualPage.InitData();
                createTestManualData.GetTestDataFromResxResource(
                    "UITests.Data.Assess.TestCreateEdit.ManualQACreateTestResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                workflows.AssessWorkflows.CreateTestManualPage.Data = createTestManualData;

                //Create 1st multiple choice item
                TestContext.WriteLine("\n --- Create multiple choice item ---");
                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .NavigateToChooseNewItemPage()
                    .ChooseNewItemMultipleChoice();

                //set up data for EditQuestion.aspx
                EditPageData editPageMultipleChoice1Data = workflows.AssessWorkflows.EditQuestionCreateNewItemPage.InitData();
                editPageMultipleChoice1Data.GetTestDataFromResxResource(
                    "UITests.Data.Assess.ItemCreateEdit.ManualQAItemPropertiesResource",
                    "UITests.Data.Assess.ItemCreateEdit.MultipleChoiceItemResource",
                    "default_" + this.SchoolNet().TestConfiguration.ApplicationName, 0);
                editPageMultipleChoice1Data.StandardPickerData = new StandardPickerDataStructures().GetDefaultStandardPickerData();
                editPageMultipleChoice1Data.QuestionAnswerData = getMultipleChoiceData1();//override the default data
                editPageMultipleChoice1Data.PassageTitle = editPassageData.Title;
                workflows.AssessWorkflows.EditQuestionCreateNewItemPage.Data = editPageMultipleChoice1Data;

                //Fill in the multiple choice item
                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditQuestionCreateNewItemPageInputAndSubmitForm();

                //Add another item to the test
                workflows.AssessWorkflows.ViewTestDetailsWorkflows
                    .ViewTestDetailsPageAddItem();

                //Create a 2nd multiple choice item
                TestContext.WriteLine("\n --- Create multiple choice item ---");
                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .ChooseNewItemMultipleChoice();

                //set up data for EditQuestion.aspx
                EditPageData editPageMultipleChoice2Data = workflows.AssessWorkflows.EditQuestionCreateNewItemPage.InitData();
                editPageMultipleChoice2Data.ItemTypeData = editPageMultipleChoice1Data.ItemTypeData;
                editPageMultipleChoice2Data.StandardPickerData = editPageMultipleChoice1Data.StandardPickerData;
                editPageMultipleChoice2Data.QuestionAnswerData = getMultipleChoiceData2();//override the default data
                editPageMultipleChoice2Data.PassageTitle = editPassageData.Title;
                editPageMultipleChoice2Data.AutoItData = getAutoItData();
                workflows.AssessWorkflows.EditQuestionCreateNewItemPage.Data = editPageMultipleChoice2Data;

                //Add an answer choice, fill in the 2nd multiple choice item, search for and add a passage
                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditQuestionCreateNewItemPageMultipleChoiceFormAddAnswerChoice()
                    .EditQuestionCreateNewItemPageInputFormFields()
                    .EditQuestionCreateNewItemPageSearchPassageAndAddPassage()
                    .EditQuestionCreateNewItemPageSubmitForm();

                //Add another item to the test
                workflows.AssessWorkflows.ViewTestDetailsWorkflows
                    .ViewTestDetailsPageAddItem();

                //Create 3rd true false item
                TestContext.WriteLine("\n --- Create true/false item ---");
                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .ChooseNewItemTrueFalse();

                //set up data for EditQuestion.aspx
                EditPageData editPageTrueFalse1Data = workflows.AssessWorkflows.EditQuestionCreateNewItemPage.InitData();
                editPageTrueFalse1Data.ItemTypeData = editPageMultipleChoice1Data.ItemTypeData;
                editPageTrueFalse1Data.StandardPickerData = editPageMultipleChoice1Data.StandardPickerData;
                editPageTrueFalse1Data.QuestionAnswerData = getTrueFalseData();//override the default data
                editPageTrueFalse1Data.PassageTitle = editPassageData.Title;
                editPageTrueFalse1Data.AutoItData = getAutoItData();
                workflows.AssessWorkflows.EditQuestionCreateNewItemPage.Data = editPageTrueFalse1Data;

                //Fill in the true/false item, search for and add a passage
                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditQuestionCreateNewItemPageInputFormFields()
                    .EditQuestionCreateNewItemPageSearchPassageAndAddPassage()
                    .EditQuestionCreateNewItemPageSubmitForm();

                //Add another item to the test
                workflows.AssessWorkflows.ViewTestDetailsWorkflows
                    .ViewTestDetailsPageAddItem();

                //Create 4th multiple choice item
                TestContext.WriteLine("\n --- Create multiple choice item ---");
                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .ChooseNewItemMultipleChoice();

                //set up data for EditQuestion.aspx
                EditPageData editPageMultipleChoice3Data = workflows.AssessWorkflows.EditQuestionCreateNewItemPage.InitData();
                editPageMultipleChoice3Data.ItemTypeData = editPageMultipleChoice1Data.ItemTypeData;
                editPageMultipleChoice3Data.StandardPickerData = editPageMultipleChoice1Data.StandardPickerData;
                editPageMultipleChoice3Data.QuestionAnswerData = getMultipleChoiceData3();//override the default data
                editPageMultipleChoice3Data.PassageTitle = editPassageData.Title;
                editPageMultipleChoice3Data.AutoItData = getAutoItData();
                workflows.AssessWorkflows.EditQuestionCreateNewItemPage.Data = editPageMultipleChoice3Data;

                //Select two columns down, add an answer choice, fill in the 2nd multiple choice item, search for and add a passage
                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditQuestionCreateNewItemPageMultipleChoiceFormSelectTwoColumnsDown()
                    .EditQuestionCreateNewItemPageMultipleChoiceFormAddAnswerChoice()
                    .EditQuestionCreateNewItemPageInputAndSubmitForm();

                //Add another item to the test
                workflows.AssessWorkflows.ViewTestDetailsWorkflows
                    .ViewTestDetailsPageAddItem();

                //Create 5th open response item
                TestContext.WriteLine("\n --- Create open response item ---");
                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .ChooseNewItemOpenResponse();

                //set up data for EditQuestion.aspx
                EditPageData editPageOpenResponse1Data = workflows.AssessWorkflows.EditQuestionCreateNewItemPage.InitData();
                editPageOpenResponse1Data.ItemTypeData = editPageMultipleChoice1Data.ItemTypeData;
                editPageOpenResponse1Data.StandardPickerData = editPageMultipleChoice1Data.StandardPickerData;
                editPageOpenResponse1Data.QuestionAnswerData = getOpenResponseData1();//override the default data
                editPageOpenResponse1Data.PassageTitle = editPassageData.Title;
                editPageOpenResponse1Data.AutoItData = getAutoItData();
                workflows.AssessWorkflows.EditQuestionCreateNewItemPage.Data = editPageOpenResponse1Data;

                //Fill in the 5th open response item
                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditQuestionCreateNewItemPageInputAndSubmitForm();

                //Add another item to the test
                workflows.AssessWorkflows.ViewTestDetailsWorkflows
                    .ViewTestDetailsPageAddItem();

                //Create 6th open response item
                TestContext.WriteLine("\n --- Create open response item ---");
                workflows.AssessWorkflows.CreateManualTestWorkflows
                    .ChooseNewItemOpenResponse();

                //set up data for EditQuestion.aspx
                EditPageData editPageOpenResponse2Data = workflows.AssessWorkflows.EditQuestionCreateNewItemPage.InitData();
                editPageOpenResponse2Data.ItemTypeData = editPageMultipleChoice1Data.ItemTypeData;
                editPageOpenResponse2Data.ItemTypeData.ResponseLanguage = "French";//use French Response language
                editPageOpenResponse2Data.StandardPickerData = editPageMultipleChoice1Data.StandardPickerData;
                editPageOpenResponse2Data.QuestionAnswerData = getOpenResponseData2();//override the default data
                editPageOpenResponse2Data.PassageTitle = editPassageData.Title;
                editPageOpenResponse2Data.AutoItData = getAutoItData();
                workflows.AssessWorkflows.EditQuestionCreateNewItemPage.Data = editPageOpenResponse2Data;

                //Enable Text formatting, special character palette, equation editor, fill in the 6th open response item
                workflows.AssessWorkflows.CreateItemWorkflows
                    .EditQuestionCreateNewItemPageOpenResponseFormCheckEnableTextFormatting()
                    .EditQuestionCreateNewItemPageOpenResponseFormCheckEnableSpecialCharacterPalette()
                    .EditQuestionCreateNewItemPageOpenResponseFormCheckEnableEquationEditor()
                    .EditQuestionCreateNewItemPageInputAndSubmitForm();

                //set up data for ViewTestDetails.aspx
                workflows.AssessWorkflows.ViewTestDetailsPage.Data = getViewTestDetailsData();

                //Add instruction
                TestContext.WriteLine("\n --- Add instruction ---");
                workflows.AssessWorkflows.ViewTestDetailsWorkflows
                    .ViewTestDetailsPageAddInstruction();

                workflows.SignOut();
            }
            catch (Exception e)
            {
                TestContext.WriteLine("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace);
                new DriverCommands().GetScreenshotAndPageSource();
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }
        }

        #region Test Case Data

        private string createPassageText()
        {
            string passageText =
                  "The goldfish is classified as a coldwater fish, and can live in unheated aquaria at a temperature comfortable for humans. However, rapid changes "
                + "in temperature (for example in an office building in winter when the heat is turned off at night) can kill them, especially if the tank is small. "
                + "Care must also be taken when adding water, as the new water may be of a different temperature. Temperatures under about 10 °C (50 °F) are "
                + "dangerous to fancy varieties, though commons and comets can survive slightly lower temperatures. Extremely high temperatures (over 30 °C (86 °F) "
                + "can also harm goldfish. However, higher temperatures may help fight protozoan infestations by accelerating the parasite's life-cycle—thus "
                + "eliminating it more quickly. The optimum temperature for goldfish is between 20 °C (68 °F) and 22 °C (72 °F).[30] \n"

                + "Like all fish, goldfish do not like to be petted. In fact, touching a goldfish can endanger its health, because it can cause the protective "
                + "slime coat to be damaged or removed, exposing the fish’s skin to infection from bacteria or water-born parasites. However, goldfish respond to "
                + "people by surfacing at feeding time, and can be trained or acclimated to taking pellets or flakes from human fingers. The reputation of goldfish "
                + "dying quickly is often due to poor care.[31] The lifespan of goldfish in captivity can extend beyond 10 years. \n"

                + "If left in the dark for a period of time, goldfish gradually change color until they are almost gray.[citation needed] Goldfish produce pigment "
                + "in response to light, in a similar manner to how human skin becomes tanned in the sun. Fish have cells called chromatophores that produce pigments "
                + "which reflect light, and give the fish coloration. The color of a goldfish is determined by which pigments are in the cells, how many pigment molecules "
                + "there are, and whether the pigment is grouped inside the cell or is spaced throughout the cytoplasm. \n";
            return passageText;
        }
        private string editPassageText()
        {
            string passageText =
                "The goldfish (Carassius auratus auratus) is a freshwater fish in the family Cyprinidae of order Cypriniformes. "
                + "It was one of the earliest fish to be domesticated, and is one of the most commonly kept aquarium fish. \n"

                + "A relatively small member of the carp family (which also includes the koi carp and the crucian carp), the goldfish is a "
                + "domesticated version of a less-colorful carp (Carassius auratus) native to east Asia. It was first domesticated in China more "
                + "than a thousand years ago, and several distinct breeds have since been developed. Goldfish breeds vary greatly in size, body shape, "
                + "fin configuration and coloration (various combinations of white, yellow, orange, red, brown, and black are known). \n"

                + "Goldfish are popular pond fish, since they are small, inexpensive, colorful and very hardy. In an outdoor pond or water garden, they "
                + "may even survive for brief periods if ice forms on the surface, as long as there is enough oxygen remaining in the water and the pond does not freeze "
                + "solid. Common goldfish, London and Bristol shubunkins, jikin, wakin, comet and some hardier fantail goldfish can be kept in a pond all year round in "
                + "temperate and subtropical climates. Moor, veiltail, oranda and lionhead can be kept safely in outdoor ponds year-round only in more tropical climates "
                + "and only in summer elsewhere. \n"

                + "Ponds small and large are fine in warmer areas (although it ought to be noted that goldfish can \"overheat\" in small "
                + "volumes of water in summer in tropical climates). In frosty climes the depth should be at least 80 centimeters (31 in) to preclude freezing. During "
                + "winter, goldfish become sluggish, stop eating and often stay on the bottom of the pond. This is normal; they become active again in the spring. "
                + "Unless the pond is large enough to maintain its own ecosystem without interference from humans, a filter is important to clear waste and keep the "
                + "pond clean. Plants are essential as they act as part of the filtration system, as well as a food source for the fish. Plants are further beneficial "
                + "since they raise oxygen levels in the water. \n";
            return passageText;
        }
        private QuestionAnswerData getMultipleChoiceData1()
        {
            QuestionAnswerData createMultipleChoiceData = new QuestionAnswerData();
            createMultipleChoiceData.ItemType = ItemType.MultipleChoice;
            createMultipleChoiceData.QuestionContent = "The contraction “won't” is short for:";
            createMultipleChoiceData.TeacherExplanationList.Add("Teacher Explanation");
            createMultipleChoiceData.StudentExplanationList.Add("Student Explanation");
            createMultipleChoiceData.AnswerList.Add("Would not");
            createMultipleChoiceData.AnswerList.Add("Will not");
            createMultipleChoiceData.AnswerList.Add("Why not");
            createMultipleChoiceData.AnswerList.Add("Is not");
            createMultipleChoiceData.CorrectAnswerList.Add("Will not");
            createMultipleChoiceData.PointValuePair.Add("Will not", "1");
            return createMultipleChoiceData;
        }
        private QuestionAnswerData getMultipleChoiceData2()
        {
            QuestionAnswerData createMultipleChoiceData = new QuestionAnswerData();
            createMultipleChoiceData.ItemType = ItemType.MultipleChoice;
            createMultipleChoiceData.QuestionContent = "Which of the fishes pictured below is NOT a variety of goldfish?";
            createMultipleChoiceData.TeacherExplanationList.Add("Teacher Explanation");
            createMultipleChoiceData.StudentExplanationList.Add("Student Explanation");
            createMultipleChoiceData.AnswerList.Add("A");
            createMultipleChoiceData.AnswerList.Add("B");
            createMultipleChoiceData.AnswerList.Add("C");
            createMultipleChoiceData.AnswerList.Add("D");
            createMultipleChoiceData.AnswerList.Add("E");
            createMultipleChoiceData.CorrectAnswerList.Add("C");
            createMultipleChoiceData.PointValuePair.Add("C", "1");
            var fileNameDictionary = new Dictionary<string, string>();
            fileNameDictionary.Add(createMultipleChoiceData.AnswerList[0], "Common goldfish.jpg");
            fileNameDictionary.Add(createMultipleChoiceData.AnswerList[1], "Lionhead Goldfish.jpg");
            fileNameDictionary.Add(createMultipleChoiceData.AnswerList[2], "Koi.jpg");
            fileNameDictionary.Add(createMultipleChoiceData.AnswerList[3], "Oranda.jpg");
            fileNameDictionary.Add(createMultipleChoiceData.AnswerList[4], "Shubunkin.jpg");
            createMultipleChoiceData.FileUploadTree.Add(true, fileNameDictionary);
            return createMultipleChoiceData;
        }
        private QuestionAnswerData getMultipleChoiceData3()
        {
            QuestionAnswerData createMultipleChoiceData = new QuestionAnswerData();
            createMultipleChoiceData.ItemType = ItemType.MultipleChoice;
            createMultipleChoiceData.QuestionContent = "The month of September is which month of the year?";
            createMultipleChoiceData.TeacherExplanationList.Add("Teacher Explanation");
            createMultipleChoiceData.StudentExplanationList.Add("Student Explanation");
            createMultipleChoiceData.AnswerList.Add("Seventh");
            createMultipleChoiceData.AnswerList.Add("Eighth");
            createMultipleChoiceData.AnswerList.Add("Ninth");
            createMultipleChoiceData.AnswerList.Add("Tenth");
            createMultipleChoiceData.AnswerList.Add("Thirteenth");
            createMultipleChoiceData.AnswerList.Add("Seventeenth");
            createMultipleChoiceData.CorrectAnswerList.Add("Ninth");
            createMultipleChoiceData.PointValuePair.Add("Ninth", "1");
            return createMultipleChoiceData;
        }
        private QuestionAnswerData getTrueFalseData()
        {
            QuestionAnswerData createTrueFalseData = new QuestionAnswerData();
            createTrueFalseData.ItemType = ItemType.TrueFalse;
            createTrueFalseData.QuestionContent = "Goldfish are a domesticated species.";
            createTrueFalseData.TeacherExplanationList.Add("teacher's explanation");
            createTrueFalseData.StudentExplanationList.Add("student's explanation");
            createTrueFalseData.AnswerList = createTrueFalseData.TrueFalseList;
            createTrueFalseData.CorrectAnswerList.Add("True");
            createTrueFalseData.StudentAnswer = "True";
            createTrueFalseData.PointValuePair.Add("True", "1");
            return createTrueFalseData;
        }
        private QuestionAnswerData getOpenResponseData1()
        {
            //create new item open response
            QuestionAnswerData createOpenResponseData = new QuestionAnswerData();
            createOpenResponseData.ItemType = ItemType.OpenResponse;
            createOpenResponseData.QuestionContent = "Write a short book report about your favorite novel.  Maximum 100 words.";
            createOpenResponseData.StudentAnswer = "students answer response";
            createOpenResponseData.ResponseType = "Written";
            createOpenResponseData.PointValueList.Add("10");
            createOpenResponseData.NumberOfAnswerSheetPages = "2 Pages";
            createOpenResponseData.ScoringInstructions = "scoring instructions";
            createOpenResponseData.Exemplars = "exemplar information";
            createOpenResponseData.FilePath = "C:\\uploadfile.txt";
            createOpenResponseData.StudentInstructions = "student instructions";
            return createOpenResponseData;
        }
        private QuestionAnswerData getOpenResponseData2()
        {
            //create new item open response
            QuestionAnswerData createOpenResponseData = new QuestionAnswerData();
            createOpenResponseData.ItemType = ItemType.OpenResponse;
            createOpenResponseData.QuestionContent = "Provide examples of French language words that are now part of the English language.";
            createOpenResponseData.StudentAnswer = "students answer response";
            createOpenResponseData.ResponseType = "Written";
            createOpenResponseData.PointValueList.Add("10");
            createOpenResponseData.NumberOfAnswerSheetPages = "2 Pages";
            createOpenResponseData.ScoringInstructions = "scoring instructions";
            createOpenResponseData.Exemplars = "exemplar information";
            createOpenResponseData.FilePath = "C:\\uploadfile.txt";
            createOpenResponseData.StudentInstructions = "student instructions";
            return createOpenResponseData;
        }
        private AutoItData getAutoItData()
        {
            AutoItData data = new AutoItData();
            data.AutoItExecutableName = "AutoIt3.exe";
            data.DeploymentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            data.UploadImageScriptName = "UploadFile.au3";
            data.UploadImageInIEScriptName = "UploadFileInIE.au3";
            data.UploadImageInChromeScriptName = "UploadFileInChrome.au3";
            return data;
        }
        private ViewTestDetailsData getViewTestDetailsData()
        {
            //create new item open response
            ViewTestDetailsData data = new ViewTestDetailsData();
            data.Instruction = "No talking during the test.  The use of mobile devices are prohibited.";
            return data;
        }
        private EditScheduleData getScheduleData(int addDays)
        {
            EditScheduleData editScheduleData = new EditScheduleData();
            editScheduleData.StartDate = DateTime.Now.AddDays(addDays).ToString("MM/dd/yyyy");
            editScheduleData.EndDate = DateTime.Now.AddDays(addDays + 7).ToString("MM/dd/yyyy");
            editScheduleData.ScoreDate = DateTime.Now.AddDays(addDays + 7).ToString("MM/dd/yyyy");
            return editScheduleData;
        }

        #endregion //Test Case Data
    }
}
