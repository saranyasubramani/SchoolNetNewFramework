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
using UITests.Pages.Controls;
using UITests.Pages.Assess.Components;

namespace UITests.Pages.Assess.TestCreateEdit.Components
{
    /// <summary>
    /// create test form
    /// </summary>
    public class CreateTestForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">the override control prefix</param>
        public CreateTestForm(  string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            //calls overriding class' InitElements();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Martin CreateTestForm.InitElements");
            SubjectElement subject = new SubjectElement(PageNames.CreateTest);
            SubjectSelect = subject.SelectElement;
            GradeLevelElement gradeLevel = new GradeLevelElement(PageNames.CreateTest);
            GradeFromSelect = gradeLevel.FromSelectElement;
            GradeToSelect = gradeLevel.ToSelectElement;

            TestId = new TestId( PageNames.CreateTest, this.ControlPrefix);

            InstitutionSource = new WebElementWrapper( ByInstitutionSource);
            TestCategory = new SelectElementWrapper(new WebElementWrapper( ByTestCategory));
            UnansweredQuestions = new SelectElementWrapper(new WebElementWrapper( ByUnansweredQuestions));
            ScoreType = new SelectElementWrapper(new WebElementWrapper( ByScoreType));
            TestFocusELA = new WebElementWrapper( ByTestFocusELA);
            TestFocusReading = new WebElementWrapper( ByTestFocusReading);
            TestFocusWriting = new WebElementWrapper( ByTestFocusWriting);
            PreferredStandardsDocument = new SelectElementWrapper(new WebElementWrapper( ByPreferredStandardsDocument));
            AnswerKeyOnlyYes = new WebElementWrapper( ByAnswerKeyOnlyYes);
            AnswerKeyOnlyNo = new WebElementWrapper( ByAnswerKeyOnlyNo);

            EnableTextFormatting = new EnableTextFormatting( PageNames.CreateTest, this.ControlPrefix);
            AnswerChoiceLayout = new AnswerChoiceLayout( PageNames.CreateTest, this.ControlPrefix);
            EnableToolsManipulatives = new EnableToolsManipulatives( PageNames.CreateTest, this.ControlPrefix);

            StudentCommentEndOfTest = new WebElementWrapper( ByStudentCommentEndOfTest);
            StudentCommentEachItem = new WebElementWrapper( ByStudentCommentEachItem);
            TeacherCommentsYes = new WebElementWrapper( ByTeacherCommentsYes);
            TeacherCommentsNo = new WebElementWrapper( ByTeacherCommentsNo);
            StudentSelfAssessmentYes = new WebElementWrapper( ByStudentSelfAssessmentYes);
            StudentSelfAssessmentNo = new WebElementWrapper( ByStudentSelfAssessmentNo);
            HideItemContentYes = new WebElementWrapper( ByHideItemContentYes);
            HideItemContentNo = new WebElementWrapper( ByHideItemContentNo);

            InitialItemSettingsLink = new WebElementWrapper( ByInitialItemSettingsLink);
            InitialItemSettingsContainer = new WebElementWrapper( ByInitialItemSettingsContainer);
            InitialItemSettingsExpandArrow = new WebElementWrapper( ByInitialItemSettingsExpandArrow);
            TestItemSettingsLink = new WebElementWrapper( ByTestItemSettingsLink);
            TestItemSettingsContainer = new WebElementWrapper(ByTestItemSettingsContainer);
            OptionalLink = new WebElementWrapper( ByOptionalLink);
            OptionalContainer = new WebElementWrapper( ByOptionalContainer);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new CreateTestData Data
        {
            get
            {
                return (CreateTestData)base.Data;
            }
            set
            {
                Report.Write("Martin CreateTestForm.Data");
                base.Data = value;
            }
        }

        /// <summary>
        /// cancel by
        /// </summary>
        public override By ByCancel { get { return By.Id(ControlPrefix + "btnCancel"); } }
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ButtonGenerateTest"); } }

        public SelectElementWrapper SubjectSelect { get; private set; }
        public SelectElementWrapper GradeFromSelect { get; private set; }
        public SelectElementWrapper GradeToSelect { get; private set; }
        protected TestId TestId { get; private set; }
        protected EnableTextFormatting EnableTextFormatting { get; private set; }
        protected AnswerChoiceLayout AnswerChoiceLayout { get; private set; }
        protected EnableToolsManipulatives EnableToolsManipulatives { get; private set; }

        protected By ByInstitutionSource { get { return By.Id(ControlPrefix + "AutoCompleteSourceInstitution"); } }
        protected WebElementWrapper InstitutionSource { get; private set; }
        protected By ByTestCategory { get { return By.Id(ControlPrefix + "TestCategorySelector1_DropDownListCategory"); } }
        protected SelectElementWrapper TestCategory { get; private set; }
        protected By ByUnansweredQuestions { get { return By.Id(ControlPrefix + "EnableUnansweredQuestions"); } }
        protected SelectElementWrapper UnansweredQuestions { get; private set; }
        protected By ByScoreType { get { return By.Id(ControlPrefix + "DropDownListScoreType"); } }
        protected SelectElementWrapper ScoreType { get; private set; }
        //ctl00_MainContent_TestFocusSelector1_RadioButtonListTestFocus_0
        protected By ByTestFocusELA { get { return By.Id(ControlPrefix + "TestFocusSelector1_RadioButtonListTestFocus_0"); } }
        protected WebElementWrapper TestFocusELA { get; private set; }
        protected By ByTestFocusReading { get { return By.Id(ControlPrefix + "TestFocusSelector1_RadioButtonListTestFocus_1"); } }
        protected WebElementWrapper TestFocusReading { get; private set; }
        protected By ByTestFocusWriting { get { return By.Id(ControlPrefix + "TestFocusSelector1_RadioButtonListTestFocus_2"); } }
        protected WebElementWrapper TestFocusWriting { get; private set; }
        protected By ByPreferredStandardsDocument { get { return By.Id(ControlPrefix + "DropDownListStandardDocument"); } }
        protected SelectElementWrapper PreferredStandardsDocument { get; private set; }
        protected By ByAnswerKeyOnlyYes { get { return By.Id(ControlPrefix + "RadioButtonListAnswerKeyOnly_0"); } }
        protected WebElementWrapper AnswerKeyOnlyYes { get; private set; }
        protected By ByAnswerKeyOnlyNo { get { return By.Id(ControlPrefix + "RadioButtonListAnswerKeyOnly_1"); } }
        protected WebElementWrapper AnswerKeyOnlyNo { get; private set; }

        protected By ByStudentCommentEndOfTest { get { return By.Id(ControlPrefix + "cblStudentComment_0"); } }
        protected WebElementWrapper StudentCommentEndOfTest { get; private set; }
        protected By ByStudentCommentEachItem { get { return By.Id(ControlPrefix + "cblStudentComment_1"); } }
        protected WebElementWrapper StudentCommentEachItem { get; private set; }
        protected By ByTeacherCommentsYes { get { return By.Id(ControlPrefix + "RadioButtonListTeacherComment_0"); } }
        protected WebElementWrapper TeacherCommentsYes { get; private set; }
        protected By ByTeacherCommentsNo { get { return By.Id(ControlPrefix + "RadioButtonListTeacherComment_1"); } }
        protected WebElementWrapper TeacherCommentsNo { get; private set; }
        protected By ByStudentSelfAssessmentYes { get { return By.Id(ControlPrefix + "RadioButtonSelfAsessment_0"); } }
        protected WebElementWrapper StudentSelfAssessmentYes { get; private set; }
        protected By ByStudentSelfAssessmentNo { get { return By.Id(ControlPrefix + "RadioButtonSelfAsessment_1"); } }
        protected WebElementWrapper StudentSelfAssessmentNo { get; private set; }
        protected By ByHideItemContentYes { get { return By.Id(ControlPrefix + "RadioButtonListHideItemContent_0"); } }
        protected WebElementWrapper HideItemContentYes { get; private set; }
        protected By ByHideItemContentNo { get { return By.Id(ControlPrefix + "RadioButtonListHideItemContent_1"); } }
        protected WebElementWrapper HideItemContentNo { get; private set; }

        protected By ByInitialItemSettingsLink { get { return By.CssSelector("a.accordion-toggle[href='#ctl00_MainContent_dvCollapseInitialTestSettings']"); } }
        protected WebElementWrapper InitialItemSettingsLink { get; set; }
        protected By ByInitialItemSettingsContainer { get { return By.Id("ctl00_MainContent_dvCollapseInitialTestSettings"); } }
        protected WebElementWrapper InitialItemSettingsContainer { get; set; }
        protected By ByInitialItemSettingsExpandArrow { get { return By.Id("ctl00_MainContent_iInitialSettings"); } }
        protected WebElementWrapper InitialItemSettingsExpandArrow { get; set; }
        protected By ByTestItemSettingsLink { get { return By.CssSelector("a.accordion-toggle[href='#ctl00_MainContent_dvCollapseTestItemSettings']"); } }
        protected WebElementWrapper TestItemSettingsLink { get; set; }
        protected By ByTestItemSettingsContainer { get { return By.Id("ctl00_MainContent_dvCollapseTestItemSettings"); } }
        protected WebElementWrapper TestItemSettingsContainer { get; set; }
        protected By ByOptionalLink { get { return By.CssSelector("a.accordion-toggle[href='#ctl00_MainContent_dvCollapseOptional']"); } }
        protected WebElementWrapper OptionalLink { get; set; }
        protected By ByOptionalContainer { get { return By.Id("ctl00_MainContent_dvCollapseOptional"); } }
        protected WebElementWrapper OptionalContainer { get; set; }

        private bool fake;
        /// <summary>
        /// fake dummy boolean value for debugging
        /// </summary>
        public bool FakeDummyBooleanValue
        {
            get { return fake; }
            set
            {
                fake = value;
                EnableTextFormatting.FakeDummyBooleanValue = value;
            }
        }

        /// <summary>
        /// select the answer key only "yes" radio option
        /// </summary>
        public void SelectAnswerKeyOnlyYes()
        {
            AnswerKeyOnlyYes.Click();
        }
        /// <summary>
        /// select the answer key only "no" radio option
        /// </summary>
        public void SelectAnswerKeyOnlyNo()
        {
            AnswerKeyOnlyNo.Click();
        }
        /// <summary>
        /// select the test focus "ELA" radio option. 
        /// this radio option only show up when selecting "English Language and Literature" as subject
        /// </summary>
        public void SelectTestFocusELA()
        {
            TestFocusELA.Click();
        }
        /// <summary>
        /// select the test focus "Reading" radio option. 
        /// this radio option only show up when selecting "English Language and Literature" as subject
        /// </summary>
        public void SelectTestFocusReading()
        {
            TestFocusReading.Click();
        }
        /// <summary>
        /// select the test focus "Writing" radio option. 
        /// this radio option only show up when selecting "English Language and Literature" as subject
        /// </summary>
        public void SelectTestFocusWriting()
        {
            TestFocusWriting.Click();
        }


        /// <summary>
        /// expand Initial Item Settings
        /// </summary>
        public void ExpandInitialItemSettings()
        {
            InitialItemSettingsContainer.FakeAttributeClass = "accordion-body collapse";
            string classAttribute = InitialItemSettingsContainer.WaitUntilExists(3).GetAttribute("class");
            Report.Write("InitialItemSettingsContainer class: " + classAttribute);
            if (classAttribute.Contains("accordion-body collapse"))
            {
                InitialItemSettingsLink.MoveToElement();
                InitialItemSettingsLink.Wait(3).Click();
                //wait a second for the page to render
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            try
            {
                EnableTextFormatting.UseItemSettings.Wait(5);
            }
            catch (Exception e)
            {
                //The first click is not happening, re-click with different element, using the expand arrow.
                Report.Write("Re-attempting to click this element by: '" + InitialItemSettingsExpandArrow.By.ToString() + "'.");
                InitialItemSettingsExpandArrow.Wait(1).Click();
            }

        }

        /// <summary>
        /// collapse Initial Item Settings
        /// </summary>
        public void CollapseInitialItemSettings()
        {
            InitialItemSettingsContainer.FakeAttributeClass = "accordion-body in collapse";
            string classAttribute = InitialItemSettingsContainer.WaitUntilExists(3).GetAttribute("class");
            Report.Write("InitialItemSettingsContainer class: " + classAttribute);
            if (classAttribute.Contains("accordion-body in collapse"))
            {
                InitialItemSettingsLink.Wait(3).Click();
                //wait a second for the page to render
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        /// <summary>
        /// expand Test Item Settings
        /// </summary>
        public void ExpandTestItemSettings()
        {
            TestItemSettingsContainer.FakeAttributeClass = "accordion-body collapse";
            string classAttribute = TestItemSettingsContainer.WaitUntilExists(3).GetAttribute("class");
            Report.Write("TestItemSettingsContainer class: " + classAttribute);
            if (classAttribute.Contains("accordion-body collapse"))
            {
                TestItemSettingsLink.Wait(3).Click();
                //wait a second for the page to render
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        /// <summary>
        /// collapse Test Item Settings
        /// </summary>
        public void CollapseTestItemSettings()
        {
            TestItemSettingsContainer.FakeAttributeClass = "accordion-body in collapse";
            string classAttribute = TestItemSettingsContainer.WaitUntilExists(3).GetAttribute("class");
            Report.Write("TestItemSettingsContainer class: " + classAttribute);
            if (classAttribute.Contains("accordion-body in collapse"))
            {
                TestItemSettingsLink.Wait(3).Click();
                //wait a second for the page to render
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        /// <summary>
        /// expand  Optional
        /// </summary>
        public void ExpandOptional()
        {
            OptionalContainer.FakeAttributeClass = "accordion-body collapse";
            string classAttribute = OptionalContainer.WaitUntilExists(3).GetAttribute("class");
            Report.Write("OptionalContainer class: " + classAttribute);
            if (classAttribute.Contains("accordion-body collapse"))
            {
                OptionalLink.Wait(3).Click();
                //wait a second for the page to render
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        /// <summary>
        /// collapse  Optional
        /// </summary>
        public void CollapseOptional()
        {
            OptionalContainer.FakeAttributeClass = "accordion-body in collapse";
            string classAttribute = OptionalContainer.WaitUntilExists(3).GetAttribute("class");
            Report.Write("OptionalContainer class: " + classAttribute);
            if (classAttribute.Contains("accordion-body in collapse"))
            {
                OptionalLink.Wait(3).Click();
                //wait a second for the page to render
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }


        /// <summary>
        /// check student comment at the end of test
        /// </summary>
        public void CheckStudentCommentEndOfTest()
        {
            StudentCommentEndOfTest.Check();
        }
        /// <summary>
        /// uncheck student comment at the end of test
        /// </summary>
        public void UnCheckStudentCommentEndOfTest()
        {
            StudentCommentEndOfTest.UnCheck();
        }

        /// <summary>
        /// check student comment on each item
        /// </summary>
        public void CheckStudentCommentEachItem()
        {
            StudentCommentEachItem.Check();
        }
        /// <summary>
        /// uncheck student comment on each item
        /// </summary>
        public void UnCheckStudentCommentEachItem()
        {
            StudentCommentEachItem.UnCheck();
        }


        /// <summary>
        /// select user item settings
        /// </summary>
        public void SelectEnableTextFormattingUseItemSettings()
        {
            EnableTextFormatting.SelectEnableTextFormattingUseItemSettings();
        }
        /// <summary>
        /// is user item settings selected?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSelectedEnableTextFormattingUseItemSettings()
        {
            return EnableTextFormatting.IsSelectedEnableTextFormattingUseItemSettings();
        }
        /// <summary>
        /// is enable text formatting: use item settings enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableTextFormattingUseItemSettings()
        {
            return EnableTextFormatting.IsEnabledEnableTextFormattingUseItemSettings();
        }
        /// <summary>
        /// is enable text formatting: use item settings displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableTextFormattingUseItemSettings()
        {
            return EnableTextFormatting.IsDisplayedEnableTextFormattingUseItemSettings();
        }

        /// <summary>
        /// select disable text formatting open response items
        /// </summary>
        public void SelectDisableTextFormattingOpenResponseItems()
        {
            EnableTextFormatting.SelectDisableTextFormattingOpenResponseItems();
        }
        /// <summary>
        /// is disable text formatting open response items selected?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSelectedDisableTextFormattingOpenResponseItems()
        {
            return EnableTextFormatting.IsSelectedDisableTextFormattingOpenResponseItems();
        }
        /// <summary>
        /// is disable text formatting enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledDisableTextFormattingOpenResponseItems()
        {
            return EnableTextFormatting.IsEnabledDisableTextFormattingOpenResponseItems();
        }
        /// <summary>
        /// is disable text formatting displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedDisableTextFormattingOpenResponseItems()
        {
            return EnableTextFormatting.IsDisplayedDisableTextFormattingOpenResponseItems();
        }

        /// <summary>
        /// select enable text formatting open response items
        /// </summary>
        public void SelectEnableTextFormattingOpenResponseItems()
        {
            EnableTextFormatting.SelectEnableTextFormattingOpenResponseItems();
        }
        /// <summary>
        /// is enable text formatting open response items selected?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSelectedEnableTextFormattingOpenResponseItems()
        {
            return EnableTextFormatting.IsSelectedEnableTextFormattingOpenResponseItems();
        }
        /// <summary>
        /// is enable text formatting enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableTextFormattingOpenResponseItems()
        {
            return EnableTextFormatting.IsEnabledEnableTextFormattingOpenResponseItems();
        }
        /// <summary>
        /// is enable text formatting displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableTextFormattingOpenResponseItems()
        {
            return EnableTextFormatting.IsDisplayedEnableTextFormattingOpenResponseItems();
        }

        /// <summary>
        /// check enable text formatting
        /// </summary>
        public void CheckEnableTextFormatting()
        {
            EnableTextFormatting.CheckEnableTextFormatting();
        }
        /// <summary>
        /// uncheck enable text formatting
        /// </summary>
        public void UnCheckEnableTextFormatting()
        {
            EnableTextFormatting.UnCheckEnableTextFormatting();
        }
        /// <summary>
        /// is enable text formatting checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableTextFormatting()
        {
            return EnableTextFormatting.IsCheckedEnableTextFormatting();
        }
        /// <summary>
        /// is enable text formatting enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableTextFormatting()
        {
            return EnableTextFormatting.IsEnabledEnableTextFormatting();
        }
        /// <summary>
        /// is enable text formatting displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableTextFormatting()
        {
            return EnableTextFormatting.IsDisplayedEnableTextFormatting();
        }

        /// <summary>
        /// check enable special character palette
        /// </summary>
        public void CheckEnableSpecialCharacterPalette()
        {
            EnableTextFormatting.CheckEnableSpecialCharacterPalette();
        }
        /// <summary>
        /// uncheck enable special character palette
        /// </summary>
        public void UnCheckEnableSpecialCharacterPalette()
        {
            EnableTextFormatting.UnCheckEnableSpecialCharacterPalette();
        }
        /// <summary>
        /// is enable special character palette checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableSpecialCharacterPalette()
        {
            return EnableTextFormatting.IsCheckedEnableSpecialCharacterPalette();
        }
        /// <summary>
        /// is enable special character palette enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableSpecialCharacterPalette()
        {
            return EnableTextFormatting.IsEnabledEnableSpecialCharacterPalette();
        }
        /// <summary>
        /// is enable special character palette displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableSpecialCharacterPalette()
        {
            return EnableTextFormatting.IsDisplayedEnableSpecialCharacterPalette();
        }

        /// <summary>
        /// check enable spell checker
        /// </summary>
        public void CheckEnableSpellChecker()
        {
            EnableTextFormatting.CheckEnableSpellChecker();
        }
        /// <summary>
        /// uncheck enable spell checker
        /// </summary>
        public void UnCheckEnableSpellChecker()
        {
            EnableTextFormatting.UnCheckEnableSpellChecker();
        }
        /// <summary>
        /// is enable spell checker checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableSpellChecker()
        {
            return EnableTextFormatting.IsCheckedEnableSpellChecker();
        }
        /// <summary>
        /// is enable spell checker enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableSpellChecker()
        {
            return EnableTextFormatting.IsEnabledEnableSpellChecker();
        }
        /// <summary>
        /// is enable spell checker displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableSpellChecker()
        {
            return EnableTextFormatting.IsDisplayedEnableSpellChecker();
        }

        /// <summary>
        /// check enable grammar checker
        /// </summary>
        public void CheckEnableGrammarChecker()
        {
            EnableTextFormatting.CheckEnableGrammarChecker();
        }
        /// <summary>
        /// uncheck enable grammar checker
        /// </summary>
        public void UnCheckEnableGrammarChecker()
        {
            EnableTextFormatting.UnCheckEnableGrammarChecker();
        }
        /// <summary>
        /// is enable grammar checker checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableGrammarChecker()
        {
            return EnableTextFormatting.IsCheckedEnableGrammarChecker();
        }
        /// <summary>
        /// is enable grammar checker enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableGrammarChecker()
        {
            return EnableTextFormatting.IsEnabledEnableGrammarChecker();
        }
        /// <summary>
        /// is enable grammar checker displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableGrammarChecker()
        {
            return EnableTextFormatting.IsDisplayedEnableGrammarChecker();
        }

        /// <summary>
        /// check enable equation editor
        /// </summary>
        public void CheckEnableEquationEditor()
        {
            EnableTextFormatting.CheckEnableEquationEditor();
        }
        /// <summary>
        /// uncheck enable equation editor
        /// </summary>
        public void UnCheckEnableEquationEditor()
        {
            EnableTextFormatting.UnCheckEnableEquationEditor();
        }
        /// <summary>
        /// is enable equation editor checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableEquationEditor()
        {
            return EnableTextFormatting.IsCheckedEnableEquationEditor();
        }
        /// <summary>
        /// is enable equation editor enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableEquationEditor()
        {
            return EnableTextFormatting.IsEnabledEnableEquationEditor();
        }
        /// <summary>
        /// is enable equation editor displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableEquationEditor()
        {
            return EnableTextFormatting.IsDisplayedEnableEquationEditor();
        }



        /// <summary>
        /// select enable manipulatives: use item settings
        /// </summary>
        public void SelectEnableManipulativesUseItemSettings()
        {
            EnableToolsManipulatives.SelectEnableManipulativesUseItemSettings();
        }
        /// <summary>
        /// is enable manipulatives: use item settings checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSelectedEnableManipulativesUseItemSettings()
        {
            return EnableToolsManipulatives.IsSelectedEnableManipulativesUseItemSettings();
        }
        /// <summary>
        /// is enable manipulatives: use item settings enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableManipulativesUseItemSettings()
        {
            return EnableToolsManipulatives.IsEnabledEnableManipulativesUseItemSettings();
        }
        /// <summary>
        /// is enable manipulatives: use item settings displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableManipulativesUseItemSettings()
        {
            return EnableToolsManipulatives.IsDisplayedEnableManipulativesUseItemSettings();
        }

        /// <summary>
        /// select enable manipulatives: yes
        /// </summary>
        public void SelectEnableManipulativesYes()
        {
            EnableToolsManipulatives.SelectEnableManipulativesYes();
        }
        /// <summary>
        /// is enable manipulatives: yes checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSelectedEnableManipulativesYes()
        {
            return EnableToolsManipulatives.IsSelectedEnableManipulativesYes();
        }
        /// <summary>
        /// is enable manipulatives: yes enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableManipulativesYes()
        {
            return EnableToolsManipulatives.IsEnabledEnableManipulativesYes();
        }
        /// <summary>
        /// is enable manipulatives: yes displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableManipulativesYes()
        {
            return EnableToolsManipulatives.IsDisplayedEnableManipulativesYes();
        }

        /// <summary>
        /// select enable manipulatives: no
        /// </summary>
        public void SelectEnableManipulativesNo()
        {
            EnableToolsManipulatives.SelectEnableManipulativesNo();
        }
        /// <summary>
        /// is enable manipulatives: no checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSelectedEnableManipulativesNo()
        {
            return EnableToolsManipulatives.IsSelectedEnableManipulativesNo();
        }
        /// <summary>
        /// is enable manipulatives: no enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableManipulativesNo()
        {
            return EnableToolsManipulatives.IsEnabledEnableManipulativesNo();
        }
        /// <summary>
        /// is enable manipulatives: no displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableManipulativesNo()
        {
            return EnableToolsManipulatives.IsDisplayedEnableManipulativesNo();
        }

        /// <summary>
        /// check enable manipulatives
        /// </summary>
        public void CheckEnableManipulatives()
        {
            EnableToolsManipulatives.CheckEnableManipulatives();
        }
        /// <summary>
        /// uncheck enable manipulatives
        /// </summary>
        public void UnCheckEnableManipulatives()
        {
            EnableToolsManipulatives.UnCheckEnableManipulatives();
        }
        /// <summary>
        /// is enable manipulatives checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedEnableManipulatives()
        {
            return EnableToolsManipulatives.IsCheckedEnableManipulatives();
        }
        /// <summary>
        /// is enable manipulatives enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledEnableManipulatives()
        {
            return EnableToolsManipulatives.IsEnabledEnableManipulatives();
        }
        /// <summary>
        /// is enable manipulatives displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedEnableManipulatives()
        {
            return EnableToolsManipulatives.IsDisplayedEnableManipulatives();
        }

        /// <summary>
        /// check Four Function Calculator
        /// </summary>
        public void CheckFourFunctionCalculator()
        {
            EnableToolsManipulatives.CheckFourFunctionCalculator();
        }
        /// <summary>
        /// uncheck Four Function Calculator
        /// </summary>
        public void UnCheckFourFunctionCalculator()
        {
            EnableToolsManipulatives.UnCheckFourFunctionCalculator();
        }
        /// <summary>
        /// is Four Function Calculator checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedFourFunctionCalculator()
        {
            return EnableToolsManipulatives.IsCheckedFourFunctionCalculator();
        }
        /// <summary>
        /// is Four Function Calculator enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledFourFunctionCalculator()
        {
            return EnableToolsManipulatives.IsEnabledFourFunctionCalculator();
        }
        /// <summary>
        /// is Four Function Calculator displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedFourFunctionCalculator()
        {
            return EnableToolsManipulatives.IsDisplayedFourFunctionCalculator();
        }

        /// <summary>
        /// check Scientific Calculator
        /// </summary>
        public void CheckScientificCalculator()
        {
            EnableToolsManipulatives.CheckScientificCalculator();
        }
        /// <summary>
        /// uncheck Scientific Calculator
        /// </summary>
        public void UnCheckScientificCalculator()
        {
            EnableToolsManipulatives.UnCheckScientificCalculator();
        }
        /// <summary>
        /// is Scientific Calculator checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedScientificCalculator()
        {
            return EnableToolsManipulatives.IsCheckedScientificCalculator();
        }
        /// <summary>
        /// is Scientific Calculator enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledScientificCalculator()
        {
            return EnableToolsManipulatives.IsEnabledScientificCalculator();
        }
        /// <summary>
        /// is Scientific Calculator displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedScientificCalculator()
        {
            return EnableToolsManipulatives.IsDisplayedScientificCalculator();
        }

        /// <summary>
        /// check Graphing Calculator
        /// </summary>
        public void CheckGraphingCalculator()
        {
            EnableToolsManipulatives.CheckGraphingCalculator();
        }
        /// <summary>
        /// uncheck Graphing Calculator
        /// </summary>
        public void UnCheckGraphingCalculator()
        {
            EnableToolsManipulatives.UnCheckGraphingCalculator();
        }
        /// <summary>
        /// is Graphing Calculator checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedGraphingCalculator()
        {
            return EnableToolsManipulatives.IsCheckedGraphingCalculator();
        }
        /// <summary>
        /// is Graphing Calculator enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledGraphingCalculator()
        {
            return EnableToolsManipulatives.IsEnabledGraphingCalculator();
        }
        /// <summary>
        /// is Graphing Calculator displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedGraphingCalculator()
        {
            return EnableToolsManipulatives.IsDisplayedGraphingCalculator();
        }

        /// <summary>
        /// check Compass
        /// </summary>
        public void CheckCompass()
        {
            EnableToolsManipulatives.CheckCompass();
        }
        /// <summary>
        /// uncheck Compass
        /// </summary>
        public void UnCheckCompass()
        {
            EnableToolsManipulatives.UnCheckCompass();
        }
        /// <summary>
        /// is Compass checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedCompass()
        {
            return EnableToolsManipulatives.IsCheckedCompass();
        }
        /// <summary>
        /// is Compass enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledCompass()
        {
            return EnableToolsManipulatives.IsEnabledCompass();
        }
        /// <summary>
        /// is Compass displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedCompass()
        {
            return EnableToolsManipulatives.IsDisplayedCompass();
        }

        /// <summary>
        /// check Centimeter Ruler
        /// </summary>
        public void CheckCentimeterRuler()
        {
            EnableToolsManipulatives.CheckCentimeterRuler();
        }
        /// <summary>
        /// uncheck Centimeter Ruler
        /// </summary>
        public void UnCheckCentimeterRuler()
        {
            EnableToolsManipulatives.UnCheckCentimeterRuler();
        }
        /// <summary>
        /// is Centimeter Ruler checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedCentimeterRuler()
        {
            return EnableToolsManipulatives.IsCheckedCentimeterRuler();
        }
        /// <summary>
        /// is Centimeter Ruler enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledCentimeterRuler()
        {
            return EnableToolsManipulatives.IsEnabledCentimeterRuler();
        }
        /// <summary>
        /// is Centimeter Ruler displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedCentimeterRuler()
        {
            return EnableToolsManipulatives.IsDisplayedCentimeterRuler();
        }

        /// <summary>
        /// check Inch Ruler
        /// </summary>
        public void CheckInchRuler()
        {
            EnableToolsManipulatives.CheckInchRuler();
        }
        /// <summary>
        /// uncheck Inch Ruler
        /// </summary>
        public void UnCheckInchRuler()
        {
            EnableToolsManipulatives.UnCheckInchRuler();
        }
        /// <summary>
        /// is Inch Ruler checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedInchRuler()
        {
            return EnableToolsManipulatives.IsCheckedInchRuler();
        }
        /// <summary>
        /// is Inch Ruler enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledInchRuler()
        {
            return EnableToolsManipulatives.IsEnabledInchRuler();
        }
        /// <summary>
        /// is Inch Ruler displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedInchRuler()
        {
            return EnableToolsManipulatives.IsDisplayedInchRuler();
        }

        /// <summary>
        /// check Unit Ruler
        /// </summary>
        public void CheckUnitRuler()
        {
            EnableToolsManipulatives.CheckUnitRuler();
        }
        /// <summary>
        /// uncheck Unit Ruler
        /// </summary>
        public void UnCheckUnitRuler()
        {
            EnableToolsManipulatives.UnCheckUnitRuler();
        }
        /// <summary>
        /// is Unit Ruler checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedUnitRuler()
        {
            return EnableToolsManipulatives.IsCheckedUnitRuler();
        }
        /// <summary>
        /// is Unit Ruler enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledUnitRuler()
        {
            return EnableToolsManipulatives.IsEnabledUnitRuler();
        }
        /// <summary>
        /// is Unit Ruler displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedUnitRuler()
        {
            return EnableToolsManipulatives.IsDisplayedUnitRuler();
        }

        /// <summary>
        /// check Protractor
        /// </summary>
        public void CheckProtractor()
        {
            EnableToolsManipulatives.CheckProtractor();
        }
        /// <summary>
        /// uncheck Protractor
        /// </summary>
        public void UnCheckProtractor()
        {
            EnableToolsManipulatives.UnCheckProtractor();
        }
        /// <summary>
        /// is Protractor checked?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCheckedProtractor()
        {
            return EnableToolsManipulatives.IsCheckedProtractor();
        }
        /// <summary>
        /// is Protractor enabled?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEnabledProtractor()
        {
            return EnableToolsManipulatives.IsEnabledProtractor();
        }
        /// <summary>
        /// is Protractor displayed?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsDisplayedProtractor()
        {
            return EnableToolsManipulatives.IsDisplayedProtractor();
        }


        //implemented methods
        public override void InputFormFields()
        {
            if (Data.TestId != null)
            {
                TestId.Name.Wait(3).Clear();
                TestId.Name.SendKeys(Data.TestId);
            }
            if (Data.Subject != null)
            {
                SubjectSelect.Wait(5).SelectByText(Data.Subject);
            }
            if (Data.GradeLow != null)
            {
                //GradeLevel.From.Wait(5);
                GradeFromSelect.Wait(5).SelectByText(Data.GradeLow);
                DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
                InitElements();
            }
            if (Data.GradeHigh != null)
            {
                //GradeLevel.To.Wait(5);
                GradeToSelect.Wait(5).SelectByText(Data.GradeHigh);
                DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
                InitElements();
            }
            /* only applies to district, but not teachers
            if (Data.InstitutionSource != null)
            {
                InstitutionSource.Clear();
                InstitutionSource.SendKeys(Data.InstitutionSource);
            }
            */
            if (Data.TestCategory != null)
            {
                TestCategory.SelectByText(Data.TestCategory);
            }
            if (Data.ScoreType != null)
            {
                ScoreType.SelectByText(Data.ScoreType);
            }
            if (Data.PreferredStandardsDocument != null)
            {
                PreferredStandardsDocument.SelectByText(Data.PreferredStandardsDocument);
            }

            ExpandInitialItemSettings();
            //EnableTextFormatting.UseItemSettings.Wait(7).Click();
            EnableTextFormatting.UseItemSettings.Wait(5).Click();

            if (Data.EnableTextFormattingOpenResponse != null)
            {
                if (Data.EnableTextFormattingOpenResponse == "1")
                {
                    SelectEnableTextFormattingOpenResponseItems();
                    if (Data.EnableEquationEditor != null)
                    {
                        if (Data.EnableEquationEditor)
                        {
                            CheckEnableEquationEditor();
                        }
                    }
                }
            }
            if (Data.DisableTextFormattingOpenResponse != null)
            {
                if (Data.DisableTextFormattingOpenResponse == "1")
                {
                    SelectDisableTextFormattingOpenResponseItems();
                }
            }

            AnswerChoiceLayout.UserItemSettings.Click();

            if (Data.EnableYes != null)
            {
                if (Data.EnableYes == "1")
                {
                    SelectEnableManipulativesYes();

                    if (Data.Compass != null)
                    {
                        if (Data.Compass)
                        {
                            CheckCompass();
                        }
                    }
                    if (Data.CentimeterRuler != null)
                    {
                        if (Data.CentimeterRuler)
                        {
                            CheckCentimeterRuler();
                        }
                    }
                    if (Data.InchRuler != null)
                    {
                        if (Data.InchRuler)
                        {
                            CheckInchRuler();
                        }
                    }
                    if (Data.UnitRuler != null)
                    {
                        if (Data.UnitRuler)
                        {
                            CheckUnitRuler();
                        }
                    }

                    if (Data.Protractor != null)
                    {
                        if (Data.Protractor = true)
                        {
                            CheckProtractor();
                        }
                    }
                }
            }
            else if (Data.EnableNo != null)
            {
                if (Data.EnableNo == "1")
                {
                    SelectEnableManipulativesNo();
                }
            }
            else
            {
                SelectEnableManipulativesUseItemSettings();
            }

            ExpandTestItemSettings();

            if (Data.StudentCommentEndOfTest)
            {
                CheckStudentCommentEndOfTest();
            }

            TeacherCommentsNo.Wait(3).Click();
            StudentSelfAssessmentNo.Click();
            HideItemContentNo.Click();
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return new CreateTestBySelectingStandardsPage();
        }
    }
}
