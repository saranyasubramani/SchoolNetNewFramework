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

namespace UITests.Pages.Assess.TestCentral.TestCentralHome
{
    /// <summary>
    /// the test central home form
    /// </summary>
    public class TestCentralHomeForm : SNForm
    {
        /// <summary>
        /// the test central home form constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public TestCentralHomeForm(  string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            SubjectElement subject = new SubjectElement(PageNames.TestCentralHome);
            SubjectSelect = subject.SelectElement;
            GradeLevelElement gradeLevel = new GradeLevelElement(PageNames.TestCentralHome);
            GradeFromSelect = gradeLevel.FromSelectElement;
            GradeToSelect = gradeLevel.ToSelectElement;
            TestNameId = new WebElementWrapper( ByTestNameId);
            PrivateDraft = new WebElementWrapper( ByPrivateDraft);
            Scheduled = new WebElementWrapper( ByScheduled);
            PublicDraft = new WebElementWrapper( ByPublicDraft);
            InProgress = new WebElementWrapper( ByInProgress);
            Ready = new WebElementWrapper( ByReady);
            Completed = new WebElementWrapper( ByCompleted);
            AdvancedBasicSearchLink = new WebElementWrapper( ByAdvancedBasicSearchLink);
            DataCollectionStatus = new SelectElementWrapper(new WebElementWrapper( ByDataCollectionStatus));
            TestContent = new WebElementWrapper( ByTestContent);
            TestCreatorFirstname = new WebElementWrapper( ByTestCreatorFirstname);
            TestCreatorLastname = new WebElementWrapper( ByTestCreatorLastname);
            StandardSet = new SelectElementWrapper(new WebElementWrapper( ByStandardSet));
            Institution = new WebElementWrapper( ByInstitution);
            TestCategory = new SelectElementWrapper(new WebElementWrapper( ByTestCategory));
            AdaptiveTests = new SelectElementWrapper(new WebElementWrapper( ByAdaptiveTests));
            Publisher = new WebElementWrapper( ByPublisher);
            ExternalTestId = new WebElementWrapper( ByExternalTestId);
            IncludePersonalTests = new WebElementWrapper( ByIncludePersonalTests);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new TestCentralHomeData Data
        {
            get
            {
                return (TestCentralHomeData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private string ControlPrefix2 = "TestSearchResults1_TestFinderSearch1_";
        public SelectElementWrapper SubjectSelect { get; private set; }
        public SelectElementWrapper GradeFromSelect { get; private set; }
        public SelectElementWrapper GradeToSelect { get; private set; }
        // ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TextBoxTestName
        private By ByTestNameId { get { return By.Id(ControlPrefix + ControlPrefix2 + "TextBoxTestName"); } }
        private WebElementWrapper TestNameId { get; set; }
        private By ByPrivateDraft { get { return By.Id(ControlPrefix + ControlPrefix2 + "CheckBoxListTestStage_0"); } }
        private WebElementWrapper PrivateDraft { get; set; }
        private By ByScheduled { get { return By.Id(ControlPrefix + ControlPrefix2 + "CheckBoxListTestStage_1"); } }
        private WebElementWrapper Scheduled { get; set; }
        private By ByPublicDraft { get { return By.Id(ControlPrefix + ControlPrefix2 + "CheckBoxListTestStage_2"); } }
        private WebElementWrapper PublicDraft { get; set; }
        private By ByInProgress { get { return By.Id(ControlPrefix + ControlPrefix2 + "CheckBoxListTestStage_3"); } }
        private WebElementWrapper InProgress { get; set; }
        private By ByReady { get { return By.Id(ControlPrefix + ControlPrefix2 + "CheckBoxListTestStage_4"); } }
        private WebElementWrapper Ready { get; set; }
        private By ByCompleted { get { return By.Id(ControlPrefix + ControlPrefix2 + "CheckBoxListTestStage_5"); } }
        private WebElementWrapper Completed { get; set; }
        private By ByAdvancedBasicSearchLink { get { return By.Id(ControlPrefix + ControlPrefix2 + "LinkFindType"); } }
        private WebElementWrapper AdvancedBasicSearchLink { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TestCollectionStatusSelector1_DropDownListStatus
        private By ByDataCollectionStatus { get { return By.Id(ControlPrefix + ControlPrefix2 + "TestCollectionStatusSelector1_DropDownListStatus"); } }
        private SelectElementWrapper DataCollectionStatus { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TextBoxKeyword
        private By ByTestContent { get { return By.Id(ControlPrefix + ControlPrefix2 + "TextBoxKeyword"); } }
        private WebElementWrapper TestContent { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TextBoxTestCreatorFName
        private By ByTestCreatorFirstname { get { return By.Id(ControlPrefix + ControlPrefix2 + "TextBoxTestCreatorFName"); } }
        private WebElementWrapper TestCreatorFirstname { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TextBoxTestCreatorLName
        private By ByTestCreatorLastname { get { return By.Id(ControlPrefix + ControlPrefix2 + "TextBoxTestCreatorLName"); } }
        private WebElementWrapper TestCreatorLastname { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_DropDownListStandardSet
        private By ByStandardSet { get { return By.Id(ControlPrefix + ControlPrefix2 + "DropDownListStandardSet"); } }
        private SelectElementWrapper StandardSet { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_AutoCompleteSourceInstitution
        private By ByInstitution { get { return By.Id(ControlPrefix + ControlPrefix2 + "AutoCompleteSourceInstitution"); } }
        private WebElementWrapper Institution { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TestCategorySelector1_DropDownListCategory
        private By ByTestCategory { get { return By.Id(ControlPrefix + ControlPrefix2 + "TestCategorySelector1_DropDownListCategory"); } }
        private SelectElementWrapper TestCategory { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_CATInclusionOption
        private By ByAdaptiveTests { get { return By.Id(ControlPrefix + ControlPrefix2 + "CATInclusionOption"); } }
        private SelectElementWrapper AdaptiveTests { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TextBoxPublisher
        private By ByPublisher { get { return By.Id(ControlPrefix + ControlPrefix2 + "TextBoxPublisher"); } }
        private WebElementWrapper Publisher { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TextBoxExternalId
        private By ByExternalTestId { get { return By.Id(ControlPrefix + ControlPrefix2 + "TextBoxExternalId"); } }
        private WebElementWrapper ExternalTestId { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_CheckBoxIncludeAllClassroomTests
        private By ByIncludePersonalTests { get { return By.Id(ControlPrefix + ControlPrefix2 + "CheckBoxIncludeAllClassroomTests"); } }
        private WebElementWrapper IncludePersonalTests { get; set; }
        // ctl00_MainContent_TestSearchResults1_TestFinderSearch1_ButtonGo
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + ControlPrefix2 + "ButtonGo"); } }

        /// <summary>
        /// select subject
        /// </summary>
        public void SelectSubject()
        {
            SubjectSelect.Wait(1).SelectByText(Data.Subject);
        }
        /// <summary>
        /// select grades
        /// </summary>
        public void SelectGrades()
        {
            GradeFromSelect.Wait(3).SelectByText(Data.FromGrade);
            GradeToSelect.Wait(3).SelectByText(Data.ToGrade);
        }
        /// <summary>
        /// check private draft
        /// </summary>
        public void CheckPrivateDraft()
        {
            PrivateDraft.Wait(1).Check();
        }
        /// <summary>
        /// uncheck private draft
        /// </summary>
        public void UnCheckPrivateDraft()
        {
            PrivateDraft.Wait(1).UnCheck();
        }
        /// <summary>
        /// check public draft
        /// </summary>
        public void CheckPublicDraft()
        {
            PublicDraft.Wait(1).Check();
        }
        /// <summary>
        /// uncheck public draft
        /// </summary>
        public void UnCheckPublicDraft()
        {
            PublicDraft.Wait(1).UnCheck();
        }
        /// <summary>
        /// check ready
        /// </summary>
        public void CheckReady()
        {
            Ready.Wait(1).Check();
        }
        /// <summary>
        /// uncheck ready
        /// </summary>
        public void UnCheckReady()
        {
            Ready.Wait(1).UnCheck();
        }
        /// <summary>
        /// check scheduled
        /// </summary>
        public void CheckScheduled()
        {
            Scheduled.Wait(1).Check();
        }
        /// <summary>
        /// uncheck scheduled
        /// </summary>
        public void UnCheckScheduled()
        {
            Scheduled.Wait(1).UnCheck();
        }
        /// <summary>
        /// check in progress
        /// </summary>
        public void CheckInProgress()
        {
            InProgress.Wait(1).Check();
        }
        /// <summary>
        /// uncheck in progress
        /// </summary>
        public void UnCheckInProgress()
        {
            InProgress.Wait(1).UnCheck();
        }
        /// <summary>
        /// check completed
        /// </summary>
        public void CheckCompleted()
        {
            Completed.Wait(1).Check();
        }
        /// <summary>
        /// uncheck completed
        /// </summary>
        public void UnCheckCompleted()
        {
            Completed.Wait(1).UnCheck();
        }
        /// <summary>
        /// check include all personal tests
        /// </summary>
        public void CheckIncludeAllPersonalTests()
        {
            IncludePersonalTests.Wait(1).Check();
        }
        /// <summary>
        /// uncheck include all personal tests
        /// </summary>
        public void UnCheckIncludeAllPersonalTests()
        {
            IncludePersonalTests.Wait(1).UnCheck();
        }
        /// <summary>
        /// Select advanced search
        /// </summary>
        public void ClickAdvancedBasicSearch()
        {
            AdvancedBasicSearchLink.Click();
        }
        /// <summary>
        /// input show more form fields
        /// </summary>
        public void InputFormFieldsShowMore()
        {
            if (string.IsNullOrEmpty(Data.DataCollectionStatus) == false)
                DataCollectionStatus.SelectByText(Data.DataCollectionStatus);
            if (string.IsNullOrEmpty(Data.TestContent) == false)
                TestContent.SendKeys(Data.TestContent);
            if (string.IsNullOrEmpty(Data.TestCreatorFirstname) == false)
                TestCreatorFirstname.SendKeys(Data.TestCreatorFirstname);
            if (string.IsNullOrEmpty(Data.TestCreatorLastname) == false)
                TestCreatorLastname.SendKeys(Data.TestCreatorLastname);
            if (string.IsNullOrEmpty(Data.StandardSet) == false)
                StandardSet.SelectByText(Data.StandardSet);
            if (string.IsNullOrEmpty(Data.Institution) == false)
                Institution.SendKeys(Data.Institution);
            if (string.IsNullOrEmpty(Data.TestCategory) == false)
                TestCategory.SelectByText(Data.TestCategory);
            if (string.IsNullOrEmpty(Data.AdaptiveTests) == false)
                AdaptiveTests.SelectByText(Data.AdaptiveTests);
            if (string.IsNullOrEmpty(Data.Publisher) == false)
                Publisher.SendKeys(Data.Publisher);
            if (string.IsNullOrEmpty(Data.ExternalTestId) == false)
                ExternalTestId.SendKeys(Data.ExternalTestId);
        }

        //overridden methods

        public override void ClearForm()
        {
            TestNameId.Wait(1).Clear();
            SubjectSelect.Wait(5).SelectByText("All subjects");
            GradeFromSelect.Wait(1).SelectByText("");
            GradeToSelect.Wait(1).SelectByText("");
            UnCheckCompleted();
        }

        public override void InputFormFields()
        {
            TestNameId.SendKeys(Data.TestName);
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return new TestCentralHomePage();
        }
    }
}
