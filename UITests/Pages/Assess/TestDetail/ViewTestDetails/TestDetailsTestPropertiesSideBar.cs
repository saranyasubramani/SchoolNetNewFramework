using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Controls;
using UITests.Pages.Assess.Components;

namespace UITests.Pages.Assess.TestDetail.ViewTestDetails
{
    /// <summary>
    /// the test details: test properties side bar component
    /// </summary>
    public class TestDetailsTestPropertiesSideBar : TestDetailsSideBar
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TestDetailsTestPropertiesSideBar()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            TestPropertiesLink = new WebElementWrapper(ByTestPropertiesLink);
            EditPropertiesLink = new WebElementWrapper( ByEditPropertiesLink);
            //label fields
            UseEnableToolsManipulativesLabel = new WebElementWrapper( ByUseEnableToolsManipulativesLabel);
            //editable fields
            SubjectElement subject = new SubjectElement(PageNames.ViewTestDetailsTestProperties);
            SubjectSelect = subject.SelectElement;
            GradeLevelElement gradeLevel = new GradeLevelElement(PageNames.ViewTestDetailsTestProperties);
            GradeFromSelect = gradeLevel.FromSelectElement;
            GradeToSelect = gradeLevel.ToSelectElement;
            InstitutionSource = new WebElementWrapper( ByInstitutionSource);
            TestCategory = new SelectElementWrapper(new WebElementWrapper( ByTestCategory));
            ScoreType = new SelectElementWrapper(new WebElementWrapper( ByScoreType));
            PreferredStandardsDocument = new SelectElementWrapper(new WebElementWrapper( ByPreferredStandardsDocument));
            DescriptionText = new WebElementWrapper( ByDescriptionText);
            TestCreatorText = new WebElementWrapper( ByTestCreatorText);
            EnableTextFormatting = new EnableTextFormatting( PageNames.ViewTestDetailsTestProperties, this.ControlPrefix);
            AnswerChoiceLayout = new AnswerChoiceLayout( PageNames.ViewTestDetailsTestProperties, this.ControlPrefix);
            EnableToolsManipulatives = new EnableToolsManipulatives( PageNames.ViewTestDetailsTestProperties, this.ControlPrefix);
            StudentCommentEndOfTest = new WebElementWrapper( ByStudentCommentEndOfTest);
            StudentCommentEachItem = new WebElementWrapper( ByStudentCommentEachItem);
            TeacherCommentsYes = new WebElementWrapper( ByTeacherCommentsYes);
            TeacherCommentsNo = new WebElementWrapper( ByTeacherCommentsNo);
            StudentSelfAssessmentYes = new WebElementWrapper( ByStudentSelfAssessmentYes);
            StudentSelfAssessmentNo = new WebElementWrapper( ByStudentSelfAssessmentNo);
            HideItemContentYes = new WebElementWrapper( ByHideItemContentYes);
            HideItemContentNo = new WebElementWrapper( ByHideItemContentNo);
            CancelButton = new WebElementWrapper( ByCancelButton);
            SubmitButton = new WebElementWrapper( BySubmitButton);
        }

        //the '3h' keeps changing based on conditions, we really need a unique ID added to the page
        //private By ByTestPropertiesLink { get { return By.CssSelector(".well .AccordianHeader[headerindex='3h']"); } }
        private By ByTestPropertiesLink { get { return By.XPath("//div[@class='well']/div[@class='PlainBox']/h5/div[@headerindex][contains(text(),'Test Properties')]"); } }
        private WebElementWrapper TestPropertiesLink { get; set; }
        private By ByEditPropertiesLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_ButtonEditProperties"); } }
        private WebElementWrapper EditPropertiesLink { get; set; }
        //label fields
        private By ByUseEnableToolsManipulativesLabel { get { return By.CssSelector("span[id^='" + ControlPrefix + "TestInfoSidebar1_LabelUseManipulatives']"); } }
        private WebElementWrapper UseEnableToolsManipulativesLabel { get; set; }
        //editable fields
        public SelectElementWrapper SubjectSelect { get; private set; }
        public SelectElementWrapper GradeFromSelect { get; private set; }
        public SelectElementWrapper GradeToSelect { get; private set; }
        protected EnableTextFormatting EnableTextFormatting { get; private set; }
        protected AnswerChoiceLayout AnswerChoiceLayout { get; private set; }
        protected EnableToolsManipulatives EnableToolsManipulatives { get; private set; }
        protected By ByInstitutionSource { get { return By.Id(ControlPrefix + "TestInfoSidebar1_AutoCompleteSourceInstitution"); } }
        protected WebElementWrapper InstitutionSource { get; private set; }
        protected By ByTestCategory { get { return By.Id(ControlPrefix + "TestInfoSidebar1_TestCategorySelector1_DropDownListCategory"); } }
        protected SelectElementWrapper TestCategory { get; private set; }
        protected By ByScoreType { get { return By.Id(ControlPrefix + "TestInfoSidebar1_DropDownListScoreType"); } }
        protected SelectElementWrapper ScoreType { get; private set; }
        protected By ByPreferredStandardsDocument { get { return By.Id(ControlPrefix + "TestInfoSidebar1_DropDownListStandardsDoc"); } }
        protected SelectElementWrapper PreferredStandardsDocument { get; private set; }
        protected By ByDescriptionText { get { return By.Id(ControlPrefix + "TestInfoSidebar1_TextBoxDescription"); } }
        protected WebElementWrapper DescriptionText { get; private set; }
        // ctl00_MainContent_TestInfoSidebar1_LabelTestCreator        
        protected By ByTestCreatorText { get { return By.Id(ControlPrefix + "TestInfoSidebar1_LabelTestCreator"); } }
        protected WebElementWrapper TestCreatorText { get; private set; }
        protected By ByStudentCommentEndOfTest { get { return By.Id(ControlPrefix + "TestInfoSidebar1_cblStudentComment_0"); } }
        protected WebElementWrapper StudentCommentEndOfTest { get; private set; }
        protected By ByStudentCommentEachItem { get { return By.Id(ControlPrefix + "TestInfoSidebar1_cblStudentComment_1"); } }
        protected WebElementWrapper StudentCommentEachItem { get; private set; }
        protected By ByTeacherCommentsYes { get { return By.Id(ControlPrefix + "TestInfoSidebar1_RadioEnableCaptureTeacherComments_0"); } }
        protected WebElementWrapper TeacherCommentsYes { get; private set; }
        protected By ByTeacherCommentsNo { get { return By.Id(ControlPrefix + "TestInfoSidebar1_RadioEnableCaptureTeacherComments_1"); } }
        protected WebElementWrapper TeacherCommentsNo { get; private set; }
        protected By ByStudentSelfAssessmentYes { get { return By.Id(ControlPrefix + "TestInfoSidebar1_RadioEnableSelfAssessment_0"); } }
        protected WebElementWrapper StudentSelfAssessmentYes { get; private set; }
        protected By ByStudentSelfAssessmentNo { get { return By.Id(ControlPrefix + "TestInfoSidebar1_RadioEnableSelfAssessment_1"); } }
        protected WebElementWrapper StudentSelfAssessmentNo { get; private set; }
        protected By ByHideItemContentYes { get { return By.Id(ControlPrefix + "TestInfoSidebar1_RadioButtonListHideItemContent_0"); } }
        protected WebElementWrapper HideItemContentYes { get; private set; }
        protected By ByHideItemContentNo { get { return By.Id(ControlPrefix + "TestInfoSidebar1_RadioButtonListHideItemContent_1"); } }
        protected WebElementWrapper HideItemContentNo { get; private set; }
        /// <summary>
        /// cancel by
        /// </summary>
        public By ByCancelButton { get { return By.Id(ControlPrefix + "TestInfoSidebar1_ButtonCancelProperties"); } }
        protected WebElementWrapper CancelButton { get; private set; }
        /// <summary>
        /// submit by
        /// </summary>
        public By BySubmitButton { get { return By.Id(ControlPrefix + "TestInfoSidebar1_ButtonSaveProperties"); } }
        protected WebElementWrapper SubmitButton { get; private set; }


        /// <summary>
        /// expand test properties
        /// </summary>
        public override void ExpandLink()
        {
            TestPropertiesLink.Wait(2);
            TestPropertiesLink.FakeAttributeClass = "AccordianClosed";
            if (TestPropertiesLink.GetAttribute("class").Trim().ToLower().Contains("accordianclosed"))
            {
                TestPropertiesLink.Click();
            }
        }
        /// <summary>
        /// collapse test properties
        /// </summary>
        public override void CollapseLink()
        {
            TestPropertiesLink.Wait(2);
            TestPropertiesLink.FakeAttributeClass = "AccordianOpen";
            if (TestPropertiesLink.GetAttribute("class").Trim().ToLower().Contains("accordianopen"))
            {
                TestPropertiesLink.Click();
            }
        }
        /// <summary>
        /// edit properties
        /// </summary>
        public void EditProperties()
        {
            EditPropertiesLink.Wait(2).Click();
        }

        /// <summary>
        /// get test creator data
        /// </summary>
        /// <returns>text</returns>
        public string GetTestCreatorData()
        {
            string text = TestCreatorText.Wait(3).Text;
            if (Driver.GetType() == typeof(DummyDriver))
            {
                text = FakeText;
            }
            return text;
        }

        //label fields
        /// <summary>
        /// verify the enable tools and manipulatives is set to yes
        /// </summary>
        public void VerifyEnableToolsManipulatives_Yes()
        {
            string expected = "Yes";
            UseEnableToolsManipulativesLabel.Wait(2);
            UseEnableToolsManipulativesLabel.Text = expected;
            string actual = UseEnableToolsManipulativesLabel.Text.Trim();
            Assert.AreEqual(expected, actual, "EnableToolsManipulatives actual: '" + actual + "' does not match expected: '" + expected + "'.");
        }
        /// <summary>
        /// verify the enable tools and manipulatives is set to no
        /// </summary>
        public void VerifyEnableToolsManipulatives_No()
        {
            string expected = "No";
            UseEnableToolsManipulativesLabel.Wait(2);
            UseEnableToolsManipulativesLabel.Text = expected;
            string actual = UseEnableToolsManipulativesLabel.Text.Trim();
            Assert.AreEqual(expected, actual, "EnableToolsManipulatives actual: '" + actual + "' does not match expected: '" + expected + "'.");
        }
        /// <summary>
        /// verify the enable tools and manipulatives is set to Use Item Settings
        /// </summary>
        public void VerifyEnableToolsManipulatives_UseItemSettings()
        {
            string expected = "Use Item Settings";
            UseEnableToolsManipulativesLabel.Wait(2);
            UseEnableToolsManipulativesLabel.Text = expected;
            string actual = UseEnableToolsManipulativesLabel.Text.Trim();
            Assert.AreEqual(expected, actual, "EnableToolsManipulatives actual: '" + actual + "' does not match expected: '" + expected + "'.");
        }

        //edit fields

        /// <summary>
        /// select enable manipulatives: yes
        /// </summary>
        public void SelectEnableManipulativesYes()
        {
            EnableToolsManipulatives.Yes.Wait(3).Click();
        }
        /// <summary>
        /// select enable manipulatives: no
        /// </summary>
        public void SelectEnableManipulativesNo()
        {
            EnableToolsManipulatives.No.Wait(3).Click();
        }
        /// <summary>
        /// check enable manipulatives
        /// </summary>
        public void CheckEnableManipulatives()
        {
            EnableToolsManipulatives.Check.Wait(3).Check();
        }
        /// <summary>
        /// uncheck enable manipulatives
        /// </summary>
        public void UnCheckEnableManipulatives()
        {
            EnableToolsManipulatives.Check.Wait(3).UnCheck();
        }

        /// <summary>
        /// check Four Function Calculator
        /// </summary>
        public void CheckFourFunctionCalculator()
        {
            EnableToolsManipulatives.FourFunctionCalculator.Wait(3).Check();
        }
        /// <summary>
        /// uncheck Four Function Calculator
        /// </summary>
        public void UnCheckFourFunctionCalculator()
        {
            EnableToolsManipulatives.FourFunctionCalculator.Wait(3).UnCheck();
        }

        /// <summary>
        /// check Scientific Calculator
        /// </summary>
        public void CheckScientificCalculator()
        {
            EnableToolsManipulatives.ScientificCalculator.Wait(3).Check();
        }
        /// <summary>
        /// uncheck Scientific Calculator
        /// </summary>
        public void UnCheckScientificCalculator()
        {
            EnableToolsManipulatives.ScientificCalculator.Wait(3).UnCheck();
        }

        /// <summary>
        /// check Graphing Calculator
        /// </summary>
        public void CheckGraphingCalculator()
        {
            EnableToolsManipulatives.GraphingCalculator.Wait(3).Check();
        }
        /// <summary>
        /// uncheck Graphing Calculator
        /// </summary>
        public void UnCheckGraphingCalculator()
        {
            EnableToolsManipulatives.GraphingCalculator.Wait(3).UnCheck();
        }

        /// <summary>
        /// check Compass
        /// </summary>
        public void CheckCompass()
        {
            EnableToolsManipulatives.Compass.Wait(3).Check();
        }
        /// <summary>
        /// uncheck Compass
        /// </summary>
        public void UnCheckCompass()
        {
            EnableToolsManipulatives.Compass.Wait(3).UnCheck();
        }

        /// <summary>
        /// check Centimeter Ruler
        /// </summary>
        public void CheckCentimeterRuler()
        {
            EnableToolsManipulatives.CentimeterRuler.Wait(3).Check();
        }
        /// <summary>
        /// uncheck Centimeter Ruler
        /// </summary>
        public void UnCheckCentimeterRuler()
        {
            EnableToolsManipulatives.CentimeterRuler.Wait(3).UnCheck();
        }

        /// <summary>
        /// check Inch Ruler
        /// </summary>
        public void CheckInchRuler()
        {
            EnableToolsManipulatives.InchRuler.Wait(3).Check();
        }
        /// <summary>
        /// uncheck Inch Ruler
        /// </summary>
        public void UnCheckInchRuler()
        {
            EnableToolsManipulatives.InchRuler.Wait(3).UnCheck();
        }

        /// <summary>
        /// check Unit Ruler
        /// </summary>
        public void CheckUnitRuler()
        {
            EnableToolsManipulatives.UnitRuler.Wait(3).Check();
        }
        /// <summary>
        /// uncheck Unit Ruler
        /// </summary>
        public void UnCheckUnitRuler()
        {
            EnableToolsManipulatives.UnitRuler.Wait(3).UnCheck();
        }

        /// <summary>
        /// check Protractor
        /// </summary>
        public void CheckProtractor()
        {
            EnableToolsManipulatives.Protractor.Wait(3).Check();
        }
        /// <summary>
        /// uncheck Protractor
        /// </summary>
        public void UnCheckProtractor()
        {
            EnableToolsManipulatives.Protractor.Wait(3).UnCheck();
        }
        /// <summary>
        /// cancel
        /// </summary>
        public void Cancel()
        {
            CancelButton.Wait(3).Click();
        }
        /// <summary>
        /// submit
        /// </summary>
        public void Submit()
        {
            SubmitButton.Wait(3).Click();
        }
    }
}
