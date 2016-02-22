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
using UITests.Pages.Assess.PrintTest;
using UITests.Pages.Assess.Rubric;
using UITests.Pages.Assess.Scantron;
using UITests.Pages.Assess.Schedule;
using UITests.Pages.Assess.Standards;
using UITests.Pages.Assess.TestCentral;
using UITests.Pages.Assess.TestCreateEdit;
using UITests.Pages.Assess.TestCreateEdit.Components;
using UITests.Pages.Assess.TestCreateEdit.CreateTestManual;
using UITests.Pages.Assess.TestCreateEdit.CreateTestBySelectingStandards;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestTunnel;
using UITests.Pages.Assess.TestWindow;
using UITests.Pages.Assess.Track;
using UITests.Pages.Home;
using UITests.Workflow;

namespace UITests.Workflow.Assess
{
    /// <summary>
    /// the create manual test workflows
    /// </summary>
    public class CreateManualTestWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public CreateManualTestWorkflows( AssessWorkflows workflows)
            : base()
        {
            AssessWorkflows = workflows;
        }

        //workflows
        public AssessWorkflows AssessWorkflows { get; set; }

        //specific variable
        /// <summary>
        /// This is to keep track if user had selected "All multiple choice" checkbox
        /// When all MC is checked, user no longer had to choose item after submit.
        /// User is brought to item page.  
        /// </summary>
        public bool AllMultipleChoiceSelected { get; set; }

        /// <summary>
        /// navigate to the create manual test page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows NavigateToCreateManualTestPage()
        {
            AssessWorkflows.NavigateToAssessDashboardPage();
            AssessWorkflows.CreateTestPortalPage = null;
            if ((AssessWorkflows.Workflows.IsDistrictAdmin)
                || (AssessWorkflows.Workflows.IsLeadership)
                || (AssessWorkflows.Workflows.IsStudent)
                || (AssessWorkflows.Workflows.IsSystemSetup)
                || (AssessWorkflows.Workflows.IsStateAdmin))
            {
                AssessWorkflows.ProfileHomePage = AssessWorkflows.ProfileHomePage;
                AssessWorkflows.CreateTestPortalPage = AssessWorkflows.ProfileHomePage.CreateATest();
            }
            if (AssessWorkflows.Workflows.IsTeacher)
            {
                AssessWorkflows.ProfileHomePage = AssessWorkflows.TeacherProfileHomePage;
                AssessWorkflows.CreateTestPortalPage = AssessWorkflows.TeacherProfileHomePage.CreateATest();
            }
            if (AssessWorkflows.CreateTestPortalPage == null)
            {
                throw new Exception("Navigate to the ProfileHomePage before trying to use this workflow.");
            }
            AssessWorkflows.CreateTestManualPage = AssessWorkflows.CreateTestPortalPage.Detail.CreateManualTest();
            if (AssessWorkflows.CreateTestManualPage.Data == null)
            {//use default data
                AssessWorkflows.CreateTestManualPage.InitData();
                AssessWorkflows.CreateTestManualPage.Data.GetTestDataFromResxResource(
                    "UITests.Data.Assess.TestCreateEdit.CreateTestResource",
                    "default_" + this.TestConfiguration.ApplicationName, 0);
            }
            return this;
        }
        /// <summary>
        /// create test manual page input form fields
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageInputFormFields()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.InputFormFields();
            return this;
        }

        /// <summary>
        /// create test manual page, select test focus, "ELA" radio button
        /// This will only show up if "English Language and Literature" subject is selected
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageSelectTestFocusELA()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.SelectTestFocusELA();
            return this;
        }
        /// <summary>
        /// create test manual page, select test focus, "Reading" radio button
        /// This will only show up if "English Language and Literature" subject is selected
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageSelectTestFocusReading()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.SelectTestFocusReading();
            return this;
        }
        /// <summary>
        /// create test manual page, select test focus, "Writing" radio button
        /// This will only show up if "English Language and Literature" subject is selected
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageSelectTestFocusWriting()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.SelectTestFocusWriting();
            return this;
        }
        /// <summary>
        /// create test manual page, select answer key only, "yes" radio button
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageSelectAnswerKeyOnlyYes()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.SelectAnswerKeyOnlyYes();
            return this;
        }
        /// <summary>
        /// create test manual page, select answer key only, "no" radio button
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageSelectAnswerKeyOnlyNo()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.SelectAnswerKeyOnlyNo();
            return this;
        }
        /// <summary>
        /// create test manual page, select all multiple choice checkbox
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageSelectAllMultipleChoice()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.SelectAllMultipleChoice();
            AllMultipleChoiceSelected = true;
            return this;
        }

        /// <summary>
        /// navigate to the choose new item page
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageEnableTextFormattingUserItemSettings()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.ExpandInitialItemSettings();
            AssessWorkflows.CreateTestManualPage.Form.SelectEnableTextFormattingUseItemSettings();
            return this;
        }
        /// <summary>
        /// navigate to the choose new item page
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageEnableTextFormattingOpenResponseItems()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.ExpandInitialItemSettings();
            AssessWorkflows.CreateTestManualPage.Form.SelectEnableTextFormattingOpenResponseItems();
            return this;
        }
        /// <summary>
        /// navigate to the choose new item page
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageEnableTextFormattingSpecialCharacterPalette()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.CheckEnableSpecialCharacterPalette();
            return this;
        }
        /// <summary>
        /// navigate to the choose new item page
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageEnableTextFormattingSpellChecker()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.CheckEnableSpellChecker();
            return this;
        }
        /// <summary>
        /// navigate to the choose new item page
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageEnableTextFormattingGrammarChecker()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.CheckEnableGrammarChecker();
            return this;
        }
        /// <summary>
        /// navigate to the choose new item page
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageEnableTextFormattingEquationEditor()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.CheckEnableEquationEditor();
            return this;
        }
        /// <summary>
        /// navigate to the choose new item page
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageDisableTextFormattingOpenResponseItems()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.ExpandInitialItemSettings();
            AssessWorkflows.CreateTestManualPage.Form.SelectDisableTextFormattingOpenResponseItems();
            return this;
        }

        /// <summary>
        /// expand initial item settings, choose yes enable tools & manipulatives
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageEnableToolsManipulativesYes()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.ExpandInitialItemSettings();
            AssessWorkflows.CreateTestManualPage.Form.SelectEnableManipulativesYes();
            return this;
        }
        /// <summary>
        /// initial item settings had been expanded, enable tools & manipulatives is yes, now check compass
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageEnableToolsManipulativesCheckCompass()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.CheckCompass();
            return this;
        }
        /// <summary>
        /// initial item settings had been expanded, enable tools & manipulatives is yes, now check centimeter ruler
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageEnableToolsManipulativesCheckCentimeterRuler()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.CheckCentimeterRuler();
            return this;
        }
        /// <summary>
        /// initial item settings had been expanded, enable tools & manipulatives is yes, now check inch ruler
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageEnableToolsManipulativesCheckInchRuler()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.CheckInchRuler();
            return this;
        }
        /// <summary>
        /// initial item settings had been expanded, enable tools & manipulatives is yes, now check unit ruler
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageEnableToolsManipulativesCheckUnitRuler()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.CheckUnitRuler();
            return this;
        }
        /// <summary>
        /// initial item settings had been expanded, enable tools & manipulatives is yes, now check protractor ruler
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageEnableToolsManipulativesCheckProtractorRuler()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.CheckProtractor();
            return this;
        }
        /// <summary>
        /// initial item settings had been expanded, enable tools & manipulatives is yes, now check four function calculator
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageEnableToolsManipulativesCheckFourFunctionCalculator()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.CheckFourFunctionCalculator();
            return this;
        }
        /// <summary>
        /// initial item settings had been expanded, enable tools & manipulatives is yes, now check scientific calculator
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageEnableToolsManipulativesCheckScientificCalculator()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.CheckScientificCalculator();
            return this;
        }
        /// <summary>
        /// initial item settings had been expanded, enable tools & manipulatives is yes, now check graphing calculator
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageEnableToolsManipulativesCheckGraphingCalculator()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.CheckGraphingCalculator();
            return this;
        }

        /// <summary>
        /// expand test settings
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageExpandTestSettings()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.ExpandTestItemSettings();
            return this;
        }
        /// <summary>
        /// expand test settings, choose student comments -> comment at the end of test
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageCheckCommentEndOfTest()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.CheckStudentCommentEndOfTest();
            return this;
        }
        /// <summary>
        /// expand test settings, choose student comments -> comment on each item
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageCheckCommentEachItem()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestManualPage.Form.CheckStudentCommentEachItem();
            return this;
        }

        /// <summary>
        /// submit create test manual page
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CreateTestManualPageSubmitForm()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            if (AllMultipleChoiceSelected)
            {
                //When all MC is checked, user no longer had to choose item after submit. User is brought to
                //MC item page.
                AssessWorkflows.CreateTestManualPage.Form.SubmitForm();
                AssessWorkflows.EditQuestionCreateNewItemPage = new EditQuestionCreateNewItemPage( ItemType.MultipleChoice);
            }
            else
            {              
                AssessWorkflows.EditQuestionChooseNewItemPage = (EditQuestionChooseNewItemPage)AssessWorkflows.CreateTestManualPage.Form.SubmitForm();
            }
            return this;
        }
        /// <summary>
        /// copied manual test page, then navigate to the view test details page:
        /// create test manual page input form fields, and then submit the page
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows CopiedManualTestToViewTestDetails()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ViewTestDetailsPage = (ViewTestDetailsPage)AssessWorkflows.CreateTestManualPage.Form.InputAndSubmitForm();
            AssessWorkflows.TestItem = AssessWorkflows.ViewTestDetailsPage.Form.GetResultsList();
            return this;
        }
        /// <summary>
        /// navigate to the choose new item page:
        /// create test manual page input form fields, and then submit the page
        /// </summary>
        /// <remarks>requires the CreateTestManualPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows NavigateToChooseNewItemPage()
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionChooseNewItemPage = (EditQuestionChooseNewItemPage)AssessWorkflows.CreateTestManualPage.Form.InputAndSubmitForm();
            return this;
        }
        /// <summary>
        /// choose new item: lookup in item central
        /// </summary>
        /// <remarks>requires the EditQuestionChooseNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows ChooseNewItemLookupInItemCentral()
        {
            //if (EditQuestionChooseNewItemPage == null)
            if (AssessWorkflows.EditQuestionChooseNewItemPage == null)
            {
                throw new Exception("The EditQuestionChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ItemCentralHomePage = AssessWorkflows.EditQuestionChooseNewItemPage.Detail.LookupInItemCentralLink();
            return this;
        }
        /// <summary>
        /// choose new item: click stick click drop
        /// </summary>
        /// <remarks>requires the EditQuestionChooseNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows ChooseNewItemClickStickClickDrop()
        {
            //if (EditQuestionChooseNewItemPage == null)
            if (AssessWorkflows.EditQuestionChooseNewItemPage == null)
            {
                throw new Exception("The EditQuestionChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage = AssessWorkflows.EditQuestionChooseNewItemPage.Detail.SelectClickStickClickDropLink();
            return this;
        }
        /// <summary>
        /// choose new item: drag and drop
        /// </summary>
        /// <remarks>requires the EditQuestionChooseNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows ChooseNewItemDragAndDrop()
        {
            //if (EditQuestionChooseNewItemPage == null)
            if (AssessWorkflows.EditQuestionChooseNewItemPage == null)
            {
                throw new Exception("The EditQuestionChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage = AssessWorkflows.EditQuestionChooseNewItemPage.Detail.SelectDragAndDropLink();
            return this;
        }
        /// <summary>
        /// choose new item: gridded
        /// </summary>
        /// <remarks>requires the EditQuestionChooseNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows ChooseNewItemGridded()
        {
            //if (EditQuestionChooseNewItemPage == null)
            if (AssessWorkflows.EditQuestionChooseNewItemPage == null)
            {
                throw new Exception("The EditQuestionChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage = AssessWorkflows.EditQuestionChooseNewItemPage.Detail.SelectGriddedLink();
            return this;
        }
        /// <summary>
        /// choose new item: hot spot multiple selection
        /// </summary>
        /// <remarks>requires the EditQuestionChooseNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows ChooseNewItemHotSpotMultipleSelection()
        {
            //if (EditQuestionChooseNewItemPage == null)
            if (AssessWorkflows.EditQuestionChooseNewItemPage == null)
            {
                throw new Exception("The EditQuestionChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage = AssessWorkflows.EditQuestionChooseNewItemPage.Detail.SelectHotSpotMultipleSelectionLink();
            return this;
        }
        /// <summary>
        /// choose new item: hot spont single selection
        /// </summary>
        /// <remarks>requires the EditQuestionChooseNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows ChooseNewItemHotSpotSingleSelection()
        {
            //if (EditQuestionChooseNewItemPage == null)
            if (AssessWorkflows.EditQuestionChooseNewItemPage == null)
            {
                throw new Exception("The EditQuestionChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage = AssessWorkflows.EditQuestionChooseNewItemPage.Detail.SelectHotSpotSingleSelectionLink();
            return this;
        }
        /// <summary>
        /// choose new item: inline response
        /// </summary>
        /// <remarks>requires the EditQuestionChooseNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows ChooseNewItemInlineResponse()
        {
            //if (EditQuestionChooseNewItemPage == null)
            if (AssessWorkflows.EditQuestionChooseNewItemPage == null)
            {
                throw new Exception("The EditQuestionChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage = AssessWorkflows.EditQuestionChooseNewItemPage.Detail.SelectInlineResponseLink();
            return this;
        }
        /// <summary>
        /// choose new item: matching
        /// </summary>
        /// <remarks>requires the EditQuestionChooseNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows ChooseNewItemMatching()
        {
            //if (EditQuestionChooseNewItemPage == null)
            if (AssessWorkflows.EditQuestionChooseNewItemPage == null)
            {
                throw new Exception("The EditQuestionChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage = AssessWorkflows.EditQuestionChooseNewItemPage.Detail.SelectMatchingLink();
            return this;
        }
        /// <summary>
        /// choose new item: multiple choice
        /// </summary>
        /// <remarks>requires the EditQuestionChooseNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows ChooseNewItemMultipleChoice()
        {
            //if (EditQuestionChooseNewItemPage == null)
            if (AssessWorkflows.EditQuestionChooseNewItemPage == null)
            {
                throw new Exception("The EditQuestionChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage = AssessWorkflows.EditQuestionChooseNewItemPage.Detail.SelectMultipleChoiceLink();
            return this;
        }
        /// <summary>
        /// choose new item: open response
        /// </summary>
        /// <remarks>requires the EditQuestionChooseNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows ChooseNewItemOpenResponse()
        {
            //if (EditQuestionChooseNewItemPage == null)
            if (AssessWorkflows.EditQuestionChooseNewItemPage == null)
            {
                throw new Exception("The EditQuestionChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage = AssessWorkflows.EditQuestionChooseNewItemPage.Detail.SelectOpenResponseLink();
            return this;
        }
        /// <summary>
        /// choose new item: task
        /// </summary>
        /// <remarks>requires the EditQuestionChooseNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows ChooseNewTask()
        {
            //if (EditQuestionChooseNewItemPage == null)
            if (AssessWorkflows.EditQuestionChooseNewItemPage == null)
            {
                throw new Exception("The EditQuestionChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage = AssessWorkflows.EditQuestionChooseNewItemPage.Detail.SelectTaskLink();
            return this;
        }
        /// <summary>
        /// choose new item: true/false
        /// </summary>
        /// <remarks>requires the EditQuestionChooseNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows ChooseNewItemTrueFalse()
        {
            //if (EditQuestionChooseNewItemPage == null)
            if (AssessWorkflows.EditQuestionChooseNewItemPage == null)
            {
                throw new Exception("The EditQuestionChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage = AssessWorkflows.EditQuestionChooseNewItemPage.Detail.SelectTrueFalseLink();
            return this;
        }
        /// <summary>
        /// set number of items
        /// </summary>
        /// <remarks>requires the EditQuestionChooseNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateManualTestWorkflows SetNumberOfItems(int numberOfItem)
        {
            if (AssessWorkflows.CreateTestManualPage == null)
            {
                throw new Exception(
                    "The CreateTestManualPage is null, please initialize it before trying to use it in a workflow.");
            }
            ((CreateTestManualData)AssessWorkflows.CreateTestManualPage.Data).NumberOfItems = numberOfItem;
            return this;
        }
    }
}
