using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.TestTunnel;
using UITests.Pages.Assess.TestDetail;

namespace UITests.Pages.Assess.Schedule.EditSchedule
{
    /// <summary>
    /// Schedule a Test: Test Settings form
    /// </summary>
    public class EditSchedulePageForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public EditSchedulePageForm(string overrideControlPrefix = null)
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
            //Test Stage
            TestStages = new TestStages(PageNames.EditSchedule);

            //Test Settings
            StartDateText = new WebElementWrapper(ByStartDateText);
            EndDateText = new WebElementWrapper(ByEndDateText);
            ScoreDueDateText = new WebElementWrapper(ByScoreDueDateText);
            PreventStudentsFromAccessingCheck = new WebElementWrapper(ByPreventStudentFromAccessingCheck);
            AllowAccessFromApprovedCheck = new WebElementWrapper(ByAllowAccessFromApprovedCheck);

            //Online Test Options
            PreviewOnlineTestLink = new WebElementWrapper(ByPreviewOnlineTestLink);
            AdministerTestWithTestTunnelRadio = new WebElementWrapper(ByAdministerTestWithtestTunnelRadio);
            AdministerTestWithSecureTesterRadio = new WebElementWrapper(ByAdministerTestWithSecureTesterRadio);
            OnlinePasscodeLabel = new WebElementWrapper(ByOnlinePasscodeLabel);
            ShowStudentScoresCheck = new WebElementWrapper(ByShowStudentScoresCheck);
            DisplayThisTestCheck = new WebElementWrapper(ByDisplayThisTestCheck);
            PreventStudentAccessBeforeStartOrAfterEndCheck = new WebElementWrapper(ByPreventStudentAccessBeforeStartOrAfterEndCheck);
            EnforceTestTimeCheck = new WebElementWrapper(ByEnforceTestTimeCheck);
            TimedTestCheck = new WebElementWrapper(ByTimedTestCheck);
            TimedTestText = new WebElementWrapper(ByTimedTestText);
            TrackAndDisplayStudentResponseTimesCheck = new WebElementWrapper(ByTrackAndDisplayStudentResponseTimesCheck);
            ScrambleQuestionOrderCheck = new WebElementWrapper(ByScrambleQuestionOrderCheck);
            ScrambleAnswerChoicesCheck = new WebElementWrapper(ByScrambleAnswerChoicesCheck);
            AllowStudentsToPauseCheck = new WebElementWrapper(ByAllowStudentsToPauseCheck);
            AllowOnlyAssignedStudentsCheck = new WebElementWrapper(ByAllowOnlyAssignedStudentsCheck);
            LimitStudentTestAccessCheck = new WebElementWrapper(ByLimitStudentTestAccessCheck);

            //Assignment
            EditAssignmentLink = new WebElementWrapper(ByEditAssignmentLink);
            AssignToStudentsRadio = new WebElementWrapper(ByAssignToStudentsRadio);
            RecommendToTeachersRadio = new WebElementWrapper(ByRecommendToTeachersRadio);
            RecommendToSchoolsRadio = new WebElementWrapper(ByRecommendToSchoolsRadio);
            AcceptQuickAssignmentLink = new WebElementWrapper(ByAcceptQuickAssignmentLink);
            ViewAssignmentSummaryLink = new WebElementWrapper(ByViewAssignmentSummaryLink);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new EditScheduleData Data
        {
            get
            {
                return (EditScheduleData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        //Test Stage
        private TestStages TestStages { get; set; }
        //Test settings elements
        private By ByStartDateText { get { return By.Id(ControlPrefix + "TextBoxAdminStartDate"); } }
        private WebElementWrapper StartDateText { get; set; }
        private By ByEndDateText { get { return By.Id(ControlPrefix + "TextBoxAdminEndDate"); } }
        private WebElementWrapper EndDateText { get; set; }
        private By ByScoreDueDateText { get { return By.Id(ControlPrefix + "TextBoxScoreDueDate"); } }
        private WebElementWrapper ScoreDueDateText { get; set; }
        private By ByPreventStudentFromAccessingCheck { get { return By.Id(ControlPrefix + "CheckBoxPreventEarlyAccess"); } }
        private WebElementWrapper PreventStudentsFromAccessingCheck { get; set; }
        private By ByAllowAccessFromApprovedCheck { get { return By.Id(ControlPrefix + "CheckBoxAllowTestContent"); } }
        private WebElementWrapper AllowAccessFromApprovedCheck { get; set; }
        //Online test options elements
        private By ByPreviewOnlineTestLink { get { return By.Id("ButtonPreviewTest"); } }
        private WebElementWrapper PreviewOnlineTestLink { get; set; }
        private By ByAdministerTestWithtestTunnelRadio { get { return By.Id(ControlPrefix + "AdminWithSchoolnet"); } }
        private WebElementWrapper AdministerTestWithTestTunnelRadio { get; set; }
        private By ByAdministerTestWithSecureTesterRadio { get { return By.Id(ControlPrefix + "AdminWithSchoolnetSecure"); } }
        private WebElementWrapper AdministerTestWithSecureTesterRadio { get; set; }
        private By ByOnlinePasscodeLabel { get { return By.Id(ControlPrefix + "TextBoxPassCode"); } }
        private WebElementWrapper OnlinePasscodeLabel { get; set; }
        private By ByShowStudentScoresCheck { get { return By.Id(ControlPrefix + "CheckBoxIsScoreDisplayedAfterSubmit"); } }
        private WebElementWrapper ShowStudentScoresCheck { get; set; }
        private By ByDisplayThisTestCheck { get { return By.Id(ControlPrefix + "CheckBoxShowInStudentTakeATest"); } }
        private WebElementWrapper DisplayThisTestCheck { get; set; }
        private By ByPreventStudentAccessBeforeStartOrAfterEndCheck { get { return By.Id(ControlPrefix + "CheckBoxLimitAccessToSchedule"); } }
        private WebElementWrapper PreventStudentAccessBeforeStartOrAfterEndCheck { get; set; }
        private By ByEnforceTestTimeCheck { get { return By.Id(ControlPrefix + "CheckBoxEnforceTestTime"); } }
        private WebElementWrapper EnforceTestTimeCheck { get; set; }
        private By ByTimedTestCheck { get { return By.Id(ControlPrefix + "CheckBoxTimedTest"); } }
        private WebElementWrapper TimedTestCheck { get; set; }
        private By ByTimedTestText { get { return By.Id(ControlPrefix + "TextBoxTestDuration"); } }
        private WebElementWrapper TimedTestText { get; set; }
        private By ByTrackAndDisplayStudentResponseTimesCheck { get { return By.Id(ControlPrefix + "cbShowResponseTimes"); } }
        private WebElementWrapper TrackAndDisplayStudentResponseTimesCheck { get; set; }
        private By ByScrambleQuestionOrderCheck { get { return By.Id(ControlPrefix + "CheckBoxScrambleQuestionOrder"); } }
        private WebElementWrapper ScrambleQuestionOrderCheck { get; set; }
        private By ByScrambleAnswerChoicesCheck { get { return By.Id(ControlPrefix + "CheckBoxScrambleAnswerChoices"); } }
        private WebElementWrapper ScrambleAnswerChoicesCheck { get; set; }
        private By ByAllowStudentsToPauseCheck { get { return By.Id(ControlPrefix + "CheckBoxIsPauseEnabled"); } }
        private WebElementWrapper AllowStudentsToPauseCheck { get; set; }
        private By ByAllowOnlyAssignedStudentsCheck { get { return By.Id(ControlPrefix + "CheckBoxIsAssignmentEnforced"); } }
        private WebElementWrapper AllowOnlyAssignedStudentsCheck { get; set; }
        private By ByLimitStudentTestAccessCheck { get { return By.Id(ControlPrefix + "CheckBoxUseIpConstraint"); } }
        private WebElementWrapper LimitStudentTestAccessCheck { get; set; }
        //Assignment elements
        //ctl00_MainContent_ButtonEditInstitutionAssignment
        //ctl00_MainContent_ButtonEditTeacherAssignment
        //private By ByEditAssignmentLink { get { return By.Id(ControlPrefix + "ButtonEditInstitutionAssignment"); } }
        private By ByEditAssignmentLink { get { return By.CssSelector("a[id^='" + ControlPrefix + "ButtonEdit']"); } }
        private WebElementWrapper EditAssignmentLink { get; set; }
        private By ByAssignToStudentsRadio { get { return By.Id(ControlPrefix + "RadioButtonListAssignmentType_0"); } }
        private WebElementWrapper AssignToStudentsRadio { get; set; }
        private By ByRecommendToTeachersRadio { get { return By.Id(ControlPrefix + "RadioButtonListAssignmentType_1"); } }
        private WebElementWrapper RecommendToTeachersRadio { get; set; }
        private By ByRecommendToSchoolsRadio { get { return By.Id(ControlPrefix + "RadioButtonListAssignmentType_2"); } }
        private WebElementWrapper RecommendToSchoolsRadio { get; set; }
        //ctl00_MainContent_ButtonDefaultInstitutionAssignment
        //ctl00_MainContent_ButtonDefaultTeacherAssignment
        //private By ByAcceptQuickAssignmentLink { get { return By.Id(ControlPrefix + "ButtonDefaultInstitutionAssignment"); } }
        private By ByAcceptQuickAssignmentLink { get { return By.CssSelector("a[id^='" + ControlPrefix + "ButtonDefault']"); } }
        private WebElementWrapper AcceptQuickAssignmentLink { get; set; }
        //this link is visible after assignment
        private By ByViewAssignmentSummaryLink { get { return By.LinkText("View Assignment Summary"); } }
        private WebElementWrapper ViewAssignmentSummaryLink { get; set; }
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ButtonSave"); } }
        /// <summary>
        /// cancel by
        /// </summary>
        public override By ByCancel { get { return By.Id(ControlPrefix + "ButtonCancel"); } }

        /// <summary>
        /// Set the "Prevent the Students from accessing..." checkbox
        /// </summary>
        /// <param name="state">True for enabled, false for not</param>
        public void Set_Prevent_Students_From_Accessing_Checkbox(bool state)
        {
            handleCheckbox(PreventStudentsFromAccessingCheck, state);
        }

        /// <summary>
        /// Set the "Allow test content access from approved internet..." checkbox
        /// </summary>
        /// <param name="state">True for enabled, false for not</param>
        public void Set_Allow_Access_From_Approved_IP_Checkbox(bool state)
        {
            handleCheckbox(AllowAccessFromApprovedCheck, state);
        }

        /// <summary>
        /// Handle the clicking of a checkbox.
        /// If the current web element is not enabled and desiredState is true, click.
        /// If the current web element is enabled and desired state is false, click.
        /// Otherwise the checkbox is already in the desired state.
        /// </summary>
        /// <param name="e">WebElementWrapper</param>
        /// <param name="desiredState">True to have the checkbox enabled, false for not</param>
        private void handleCheckbox(WebElementWrapper e, bool desiredState)
        {
            bool isEnabled = e.Enabled;
            if ((isEnabled && !desiredState) || (!isEnabled && desiredState))
            {
                e.Click();
            }
        }

        //***ONLINE TEST OPTIONS FUNCTIONS

        /// <summary>
        /// Enable Schoolnet Browser Test Tunnel radio button
        /// </summary>
        public void Enable_Schoolnet_Browser_Test_Tunnel()
        {
            if (!AdministerTestWithTestTunnelRadio.Selected)
            {
                AdministerTestWithTestTunnelRadio.Click();
            }
        }

        /// <summary>
        /// Enable Schoolnet Secure Tester radio button        
        /// </summary>
        public void Enable_Schoolnet_Secure_Tester()
        {
            if (!AdministerTestWithSecureTesterRadio.Selected)
            {
                AdministerTestWithSecureTesterRadio.Click();
            }
        }

        /// <summary>
        /// Get the online passcode for a student to access this test
        /// </summary>
        /// <returns>String passcode</returns>
        public String Get_Online_Passcode()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                OnlinePasscodeLabel.FakeAttributeValue = "AUTOCODE";
            }
            Data.OnlinePassCode = OnlinePasscodeLabel.GetAttribute("value");
            Report.Write("Online Passcode: " + Data.OnlinePassCode);
            return Data.OnlinePassCode;
        }

        /// <summary>
        /// check Show student scores upon test submission
        /// </summary>
        public void CheckShowStudentScores()
        {
            ShowStudentScoresCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck Show student scores upon test submission
        /// </summary>
        public void UnCheckShowStudentScores()
        {
            ShowStudentScoresCheck.Wait(3).UnCheck();
        }

        /// <summary>
        /// check time test
        /// </summary>
        public void CheckTimeTest()
        {
            TimedTestCheck.Wait(3).Check();
            TimedTestText.Clear();
            TimedTestText.SendKeys(Data.TestTime);
        }
        /// <summary>
        /// uncheck time test
        /// </summary>
        public void UnCheckTimeTest()
        {
            TimedTestCheck.Wait(3).UnCheck();
        }

        /// <summary>
        /// check Allow students to pause test
        /// </summary>
        public void CheckAllowStudentsToPause()
        {
            AllowStudentsToPauseCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck Allow students to pause test
        /// </summary>
        public void UnCheckAllowStudentsToPause()
        {
            AllowStudentsToPauseCheck.Wait(3).UnCheck();
        }

        /// <summary>
        /// check Scramble answer choices (applies to Multiple Choice, Inline Response, Matching, Drag and Drop, and Click Stick Click Drop item types) 
        /// </summary>
        public void CheckScrambleAnswerChoices()
        {
            ScrambleAnswerChoicesCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck Scramble answer choices (applies to Multiple Choice, Inline Response, Matching, Drag and Drop, and Click Stick Click Drop item types) 
        /// </summary>
        public void UnCheckScrambleAnswerChoices()
        {
            ScrambleAnswerChoicesCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// check scramble question
        /// </summary>
        public void CheckScrambleQuestionOrder()
        {
            ScrambleQuestionOrderCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck scramble question
        /// </summary>
        public void UnCheckScrambleQuestionOrder()
        {
            ScrambleQuestionOrderCheck.Wait(3).UnCheck();
        }

        //***ASSIGNMENT FUNCTIONS

        /// <summary>
        /// select Assign To Students
        /// </summary>
        public void SelectAssignToStudents()
        {
            AssignToStudentsRadio.Wait(3).Check();
        }

        /// <summary>
        /// Select Recommend to schools radio button        
        /// </summary>
        public void Select_Recommend_To_Schools()
        {
            if (!RecommendToSchoolsRadio.Selected)
            {
                RecommendToSchoolsRadio.Click();
            }
        }

        /// <summary>
        /// Select Recommend to teacjers radio button        
        /// </summary>
        public void Select_Recommend_To_Teachers()
        {
            if (!RecommendToTeachersRadio.Selected)
            {
                this.RecommendToTeachersRadio.Click();
            }
        }

        /// <summary>
        /// Preview online test. Another window like test tunnel will appear
        /// </summary>
        /// <returns></returns>
        public DefaultPage ClickPreviewOnlineTest()
        {
            PreviewOnlineTestLink.Click();
            return new DefaultPage();
        }

        /// <summary>
        /// Accept the quick assignment
        /// </summary>
        public void Accept_Quick_Assignment()
        {
            AcceptQuickAssignmentLink.Wait(3).Click();

            DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();

            //Wait for page to reload 
            //Wait until the View Assignment Summary link is visible
            ViewAssignmentSummaryLink.WaitUntilVisible(120);
        }

        /// <summary>
        /// Edit assignment
        /// </summary>
        public void Edit_Assignment()
        {
            EditAssignmentLink.Wait(3).Click();
            //can return EditAssignmentCourse.aspx or EditTeacherAssignment.aspx
        }

        //OVERRIDDEN FUNCTIONS

        //public Page CancelForm()
        //{ clicking Done button can return multiple pages,
        //  so do NOT override the base CancelForm() method
        //    base.CancelForm();
        //    return new ViewTestDetailsPage(Driver);
        //}

        public override void InputFormFields()
        {
            if (Data.StartDate != null)
            {
                StartDateText.SendKeys(Data.StartDate);
            }
            if (Data.EndDate != null)
            {
                EndDateText.SendKeys(Data.EndDate);
            }
            if (Data.ScoreDate != null)
            {
                ScoreDueDateText.SendKeys(Data.ScoreDate);
            }
            if (Data.OnlinePassCode != null)
            {
                OnlinePasscodeLabel.Clear();
                OnlinePasscodeLabel.SendKeys(Data.OnlinePassCode);
            }
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return new ViewTestDetailsPage();
        }
    }
}
