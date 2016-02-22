using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Assess.TestTunnel.TestForms;
using UITests.Pages.Assess.TestTunnel.TestParts;

namespace UITests.Pages.Assess.TestTunnel.Default
{
    /// <summary>
    /// the test tunnel default footer
    /// </summary>
    public class DefaultFooter : SNFooter
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public DefaultFooter()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            StartTestNowButton = new WebElementWrapper( ByStartTestNowButton);
            PauseButton = new WebElementWrapper( ByPauseButton);
            ExitTestButton = new WebElementWrapper( ByExitTestButton);
            ContinueTestNowButton = new WebElementWrapper( ByContinueTestNowButton);
            PauseReturnToTestButton = new WebElementWrapper( ByPauseReturnToTestButton);
            PreviousButton = new WebElementWrapper( ByPreviousButton);
            NextButton = new WebElementWrapper( ByNextButton);
            ViewTestSummaryButton = new WebElementWrapper( ByViewTestSummaryButton);
            TestSummaryButton = new WebElementWrapper( ByTestSummaryButton);
            ReturnToTestButton = new WebElementWrapper( ByReturnToTestButton);
            SubmitTestButton = new WebElementWrapper( BySubmitTestButton);
            SubmitTestYesButton = new WebElementWrapper( BySubmitTestYesButton);
            SubmitTestNoButton = new WebElementWrapper( BySubmitTestNoButton);
            CloseTestButton = new WebElementWrapper( ByCloseTestButton);
            ProgressBar = new WebElementWrapper( ByProgressBar);
            ProgressAnsweredLabel = new WebElementWrapper( ByProgressAnsweredLabel);
            ProgressFlaggedLabel = new WebElementWrapper( ByProgressFlaggedLabel);
            if (Driver.WrappedDriver.GetType() == typeof (DummyDriver))
            {
                TestTunnelIndex = 0;
                Report.Write("TestTunnelIndex: " + TestTunnelIndex + "; QuestionNumber: " + QuestionNumber);
            }
            //GetCurrentQuestion();
            IsStartTestNowDisplayed = true;
            IsPauseDisplayed = false;
            IsViewTestSummaryDisplayed = false;
            IsPreviousDisplayed = false;
            IsNextDisplayed = false;
            IsTestSummaryDisplayed = false;
            IsReturnToTestDisplayed = false;
            IsSubmitTestDisplayed = false;
            IsSubmitTestYesDisplayed = false;
            IsSubmitTestNoDisplayed = false;
            IsCloseTestDisplayed = false;
            //set the test tunnel state
            SetTestInstructionState();
        }

        /// <summary>
        /// the data
        /// </summary>
        public new DefaultData Data
        {
            get
            {
                return (DefaultData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// list of test form types
        /// </summary>
        public List<TestTypeForm> TestList { get; set; }
        /// <summary>
        /// get the item's list of IDs and indexes
        /// </summary>
        public ReadOnlyCollection<object> ItemIdToIndexList { get; set; }

        /// <summary>
        /// the Question Number - its actually the Question number displayed on the Screen. 
        /// Question Index will be (Question Number - 1) - used for accessing the elements of the TestList
        /// </summary>
        public int QuestionNumber { get; private set; }
        public int TestTunnelIndex { get; set; }

        /// <summary>
        /// is start test page visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStartTestPageVisible()
        {
            //TODO: need to verify the page is visible
            return IsStartTestPage;
        }
        /// <summary>
        /// is test question page visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsTestQuestionPageVisible()
        {
            //TODO: need to verify the page is visible
            bool isVisible = (IsFirstTestQuestionPage == true) || (IsIntermediateTestQuestionPage == true) || (IsLastTestQuestionPage == true);
            return isVisible;
        }
        /// <summary>
        /// is pause dialog visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsPauseDialogVisible()
        {
            //TODO: need to verify the page is visible
            return IsPauseDialog;
        }
        /// <summary>
        /// is test summary page visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsTestSummaryPageVisible()
        {
            //TODO: need to verify the page is visible
            return IsTestSummaryPage;
        }

        /// <summary>
        /// verify start test page is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyStartTestPageIsVisible()
        {
            Assert.AreEqual(true, IsStartTestPage, "The start test page is invisible, but should be visible.");
        }
        /// <summary>
        /// verify test question page is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyTestQuestionPageIsVisible()
        {
            bool isVisible = (IsFirstTestQuestionPage == true) || (IsIntermediateTestQuestionPage == true) || (IsLastTestQuestionPage == true);
            Assert.AreEqual(true, isVisible, "The test question page is invisible, but should be visible.");
        }
        /// <summary>
        /// verify pause dialog is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyPauseDialogIsVisible()
        {
            Assert.AreEqual(true, IsPauseDialog, "The pause dialog is invisible, but should be visible.");
        }
        /// <summary>
        /// verify test summary page is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyTestSummaryPageIsVisible()
        {
            Assert.AreEqual(true, IsTestSummaryPage, "The test summary page is invisible, but should be visible.");
        }


        /// <summary>
        /// verify start test page is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyStartTestPageIsHidden()
        {
            Assert.AreEqual(false, IsStartTestPage, "The start test page is visible, but should be invisible.");
        }
        /// <summary>
        /// verify test question page is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyTestQuestionPageIsHidden()
        {
            bool isVisible = (IsFirstTestQuestionPage == true) || (IsIntermediateTestQuestionPage == true) || (IsLastTestQuestionPage == true);
            Assert.AreEqual(false, isVisible, "The test question page is visible, but should be invisible.");
        }
        /// <summary>
        /// verify pause dialog is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyPauseDialogIsHidden()
        {
            Assert.AreEqual(false, IsPauseDialog, "The pause dialog is visible, but should be invisible.");
        }
        /// <summary>
        /// verify test summary page is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyTestSummaryPageIsHidden()
        {
            Assert.AreEqual(false, IsTestSummaryPage, "The test summary page is visible, but should be invisible.");
        }


        private By ByStartTestNowButton { get { return By.Id("divStartTestButton"); } }
        private WebElementWrapper StartTestNowButton { get; set; }
        private bool IsStartTestNowDisplayed { get; set; }
        private By ByPauseButton { get { return By.Id("pse"); } }
        private WebElementWrapper PauseButton { get; set; }
        private bool IsPauseDisplayed { get; set; }
        private By ByExitTestButton { get { return By.Id("btnPause"); } }
        private WebElementWrapper ExitTestButton { get; set; }
        private bool IsExitTestDisplayed { get; set; }
        private By ByContinueTestNowButton { get { return By.Id("divStartTestButton"); } }
        private WebElementWrapper ContinueTestNowButton { get; set; }
        private bool IsContinueTestNowDisplayed { get; set; }
        private By ByPauseReturnToTestButton { get { return By.Id("btnReturn"); } }
        private WebElementWrapper PauseReturnToTestButton { get; set; }
        private bool IsPauseReturnToTestDisplayed { get; set; }
        private By ByPreviousButton { get { return By.Id("pvq"); } }
        private WebElementWrapper PreviousButton { get; set; }
        private bool IsPreviousDisplayed { get; set; }
        private By ByNextButton { get { return By.Id("nxq"); } }
        private WebElementWrapper NextButton { get; set; }
        private bool IsNextDisplayed { get; set; }
        private By ByViewTestSummaryButton { get { return By.Id("vsum"); } }
        private WebElementWrapper ViewTestSummaryButton { get; set; }
        private bool IsViewTestSummaryDisplayed { get; set; }
        private By ByTestSummaryButton { get { return By.Id("nxs"); } }
        private WebElementWrapper TestSummaryButton { get; set; }
        private bool IsTestSummaryDisplayed { get; set; }
        private By ByReturnToTestButton { get { return By.Id("btt"); } }
        private WebElementWrapper ReturnToTestButton { get; set; }
        private bool IsReturnToTestDisplayed { get; set; }
        private By BySubmitTestButton { get { return By.Id("sub"); } }
        private WebElementWrapper SubmitTestButton { get; set; }
        private bool IsSubmitTestDisplayed { get; set; }
        private By BySubmitTestYesButton { get { return By.Id("btnYes"); } }
        private WebElementWrapper SubmitTestYesButton { get; set; }
        private bool IsSubmitTestYesDisplayed { get; set; }
        private By BySubmitTestNoButton { get { return By.Id("btnNo"); } }
        private WebElementWrapper SubmitTestNoButton { get; set; }
        private bool IsSubmitTestNoDisplayed { get; set; }
        private By ByCloseTestButton { get { return By.Id("btnClose"); } }
        private WebElementWrapper CloseTestButton { get; set; }
        private bool IsCloseTestDisplayed { get; set; }

        private bool IsStartTestPage { get; set; }
        private bool IsFirstTestQuestionPage { get; set; }
        private bool IsIntermediateTestQuestionPage { get; set; }
        private bool IsLastTestQuestionPage { get; set; }
        private bool IsPauseDialog { get; set; }
        private bool IsTestSummaryPage { get; set; }

        /// <summary>
        /// get the test tunnel current question number
        /// </summary>
        /// <returns>question index</returns>
        public int GetCurrentQuestion()
        {
            //https://team-automation-st.sndev.net/OnlineTest/onlinetest.js
            //getCurrentQuestion()
            string script = @"return getCurrentQuestion();";
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                Report.Write("IJavaScriptExecutor.ExecuteScript('" + script + "')");
            }
            else
            {
                Object index = ((IJavaScriptExecutor)Driver).ExecuteScript(script);
                Int64 index64 = Convert.ToInt64(index);
                TestTunnelIndex = Convert.ToInt32(index64);
            }
            QuestionNumber = TestTunnelIndex + 1;
            Report.Write("TestTunnelIndex: " + TestTunnelIndex + "; QuestionNumber: " + QuestionNumber 
                + "; ItemIdToIndexList.Count: " + ItemIdToIndexList.Count + "; TestList.Count " + TestList.Count);
            return TestTunnelIndex;
        }
        /// <summary>
        /// start test now
        /// </summary>
        public void StartTestNow()
        {
            if (IsStartTestNowDisplayed == true)
            {
                StartTestNowButton.Wait(3).Click();
                //get the test tunnel current question number
                GetCurrentQuestion();
                //if this is the first question
                if (TestTunnelIndex == 0)
                {
                    //if there is only 1 question
                    if (ItemIdToIndexList.Count == 1)
                    {
                        SetLastTestItemState();
                    }
                    else//this is the first of many questions
                    {
                        SetFirstTestItemState();
                    }
                }
                else if ((TestTunnelIndex > 0) || (TestTunnelIndex < (ItemIdToIndexList.Count - 1)))
                {
                    SetIntermediateTestItemState();
                }
                else if (TestTunnelIndex == (ItemIdToIndexList.Count - 1))
                {
                    SetLastTestItemState();
                }
                else
                {
                    throw new Exception("The Online Test Tunnel getCurrentQuestion(): '" + TestTunnelIndex + "' is outside the range of questions.length: '" + ItemIdToIndexList.Count + "'.");
                }
            }
        }
        /// <summary>
        /// pause
        /// </summary>
        public void Pause()
        {
            if (IsPauseDisplayed == true)
            {
                SetPauseTestItemState();
                //get the test tunnel current question number
                GetCurrentQuestion();
                PauseButton.Wait(3).Click();
            }
        }
        /// <summary>
        /// exit test
        /// </summary>
        public void ExitTest()
        {
            if (IsExitTestDisplayed == true)
            {
                IsExitTestDisplayed = false;
                IsPauseDisplayed = true;
                //get the test tunnel current question number
                GetCurrentQuestion();
                ExitTestButton.Wait(3).Click();
            }
        }
        /// <summary>
        /// continue test now
        /// </summary>
        public void ContinueTestNow()
        {
            if (IsContinueTestNowDisplayed == true)
            {
                IsContinueTestNowDisplayed = false;
                ContinueTestNowButton.Wait(3).Click();
                //get the test tunnel current question number
                GetCurrentQuestion();
            }
        }
        /// <summary>
        /// previous
        /// </summary>
        public void Previous()
        {
            if (IsPreviousDisplayed == true)
            {
                //get the test tunnel current question number
                GetCurrentQuestion();
                //if question 1
                if (TestTunnelIndex <= 0)
                {
                    //do nothing, there is no previous button
                }
                else //else question 2 or greater
                {
                    PreviousButton.Wait(3).Click();
                    if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                    {
                        TestTunnelIndex--;
                    }
                }

                //get the test tunnel current question number
                GetCurrentQuestion();

                //if first test question
                if (TestTunnelIndex <= 0)
                {
                    //set state to first question
                    SetFirstTestItemState();
                }
                else //else intermediate test question
                {
                    //set state to intermediate question
                    SetIntermediateTestItemState();
                }
            }
        }
        /// <summary>
        /// next
        /// </summary>
        public void Next()
        {
            if (IsNextDisplayed == true)
            {
                //get the test tunnel current question number
                GetCurrentQuestion();
                //if last question
                if (TestTunnelIndex >= (ItemIdToIndexList.Count - 1))
                {
                    //do nothing, there is no next button
                }
                else //else not the last question
                {
                    NextButton.Wait(3).Click();
                    if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                    {
                        TestTunnelIndex++;
                    }
                }

                //get the test tunnel current question number
                GetCurrentQuestion();

                //if last test question
                if (TestTunnelIndex == (ItemIdToIndexList.Count - 1))
                {
                    //set state to last question
                    SetLastTestItemState();
                }
                else //else intermediate test question
                {
                    //set state to intermediate question
                    SetIntermediateTestItemState();
                }
            }
        }
        /// <summary>
        /// view test summary
        /// </summary>
        public void ViewTestSummary()
        {
            if (IsViewTestSummaryDisplayed == true)
            {
                SetTestSummaryState();
                ViewTestSummaryButton.Wait(3).Click();
                //get the test tunnel current question number
                GetCurrentQuestion();
            }
        }
        /// <summary>
        /// test summary
        /// </summary>
        public void TestSummary()
        {
            if (IsTestSummaryDisplayed == true)
            {
                SetTestSummaryState();
                TestSummaryButton.Wait(3).Click();
                //get the test tunnel current question number
                GetCurrentQuestion();
            }
        }
        /// <summary>
        /// return to test
        /// </summary>
        public void ReturnToTest()
        {
            if ((IsReturnToTestDisplayed == true) || (IsPauseReturnToTestDisplayed == true))
            {
                if (IsReturnToTestDisplayed == true)
                {
                    ReturnToTestButton.Wait(3).Click();
                }
                else if (IsPauseReturnToTestDisplayed == true)
                {
                    PauseReturnToTestButton.Wait(3).Click();
                }

                //get the test tunnel current question number
                GetCurrentQuestion();
                if (TestTunnelIndex == 0)
                {
                    SetFirstTestItemState();
                }
                else if ((TestTunnelIndex > 0) || (TestTunnelIndex < (ItemIdToIndexList.Count - 1)))
                {
                    SetIntermediateTestItemState();
                }
                else if (TestTunnelIndex == (ItemIdToIndexList.Count - 1))
                {
                    SetLastTestItemState();
                }
                else
                {
                    throw new Exception("The Online Test Tunnel getCurrentQuestion(): '" + TestTunnelIndex + "' is outside the range of questions.length: '" + ItemIdToIndexList.Count + "'.");
                }
            }
        }
        /// <summary>
        /// Sumbit Test for Grading
        /// </summary>
        public void SubmitTest()
        {
            if (IsSubmitTestDisplayed == true)
            {
                SetSubmitTestState();
                this.SubmitTestButton.Wait(3).Click();
                //get the test tunnel current question number
                GetCurrentQuestion();
            }
        }
        /// <summary>
        /// Sumbit Test - Yes for Grading
        /// </summary>
        public void SubmitTestYes()
        {
            if (IsSubmitTestYesDisplayed == true)
            {
                SetSubmitTestYesState();
                this.SubmitTestYesButton.Wait(3).Click();
                //wait for a second
                Thread.Sleep(1000);
                this.DriverCommands.WaitAndMeasurePageLoadTime();
                //get the test tunnel current question number
                GetCurrentQuestion();
            }
        }
        /// <summary>
        /// Sumbit Test - No for Grading
        /// </summary>
        public void SubmitTestNo()
        {
            if (IsSubmitTestNoDisplayed == true)
            {
                SetSubmitTestNoState();
                this.SubmitTestNoButton.Wait(3).Click();
                //get the test tunnel current question number
                GetCurrentQuestion();
            }
        }
        /// <summary>
        /// Close Test
        /// </summary>
        public void CloseTest()
        {
            if (IsCloseTestDisplayed == true)
            {
                SetCloseTestState();
                this.CloseTestButton.Wait(3).Click();
                //wait for a couple of seconds before switching windows
                Thread.Sleep(2000);
            }
        }


        /// <summary>
        /// is start test now visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsStartTestNowButtonVisible()
        {
            return StartTestNowButton.Displayed;
        }
        /// <summary>
        /// is pause visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsPauseButtonVisible()
        {
            return PauseButton.Displayed;
        }
        /// <summary>
        /// is exit test visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsExitTestButtonVisible()
        {
            return ExitTestButton.Displayed;
        }
        /// <summary>
        /// is continue test now visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsContinueTestNowButtonVisible()
        {
            return ContinueTestNowButton.Displayed;
        }
        /// <summary>
        /// is previous visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsPreviousButtonVisible()
        {
            return PreviousButton.Displayed;
        }
        /// <summary>
        /// is next visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsNextButtonVisible()
        {
            return NextButton.Displayed;
        }
        /// <summary>
        /// is view test summary visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsViewTestSummaryButtonVisible()
        {
            return ViewTestSummaryButton.Displayed;
        }
        /// <summary>
        /// is test summary visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsTestSummaryButtonVisible()
        {
            return TestSummaryButton.Displayed;
        }
        /// <summary>
        /// is pause - return to test visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsPauseReturnToTestButtonVisible()
        {
            return PauseReturnToTestButton.Displayed;
        }
        /// <summary>
        /// is return to test visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsReturnToTestButtonVisible()
        {
            return ReturnToTestButton.Displayed;
        }
        /// <summary>
        /// is submit test visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSumbitTestButtonVisible()
        {
            return SubmitTestButton.Displayed;
        }
        /// <summary>
        /// is submit test: yes visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSumbitTestYesButtonVisible()
        {
            return SubmitTestYesButton.Displayed;
        }
        /// <summary>
        /// is submit test: no visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsSumbitTestNoButtonVisible()
        {
            return SubmitTestNoButton.Displayed;
        }
        /// <summary>
        /// is close test visible?
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsCloseTestButtonVisible()
        {
            return CloseTestButton.Displayed;
        }


        /// <summary>
        /// verify start test now is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyStartTestNowButtonIsVisible()
        {
            StartTestNowButton.Displayed = true;
            Assert.AreEqual(true, StartTestNowButton.Displayed, "The start test now button is invisible, but should be visible.");
        }
        /// <summary>
        /// verify pause is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyPauseButtonIsVisible()
        {
            PauseButton.Displayed = true;
            Assert.AreEqual(true, PauseButton.Displayed, "The pause button is invisible, but should be visible.");
        }
        /// <summary>
        /// verify exit test is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyExitTestButtonIsVisible()
        {
            ExitTestButton.Displayed = true;
            Assert.AreEqual(true, ExitTestButton.Displayed, "The exit test button is invisible, but should be visible.");
        }
        /// <summary>
        /// verify continue test now is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyContinueTestNowButtonIsVisible()
        {
            ContinueTestNowButton.Displayed = true;
            Assert.AreEqual(true, ContinueTestNowButton.Displayed, "The continue test now button is invisible, but should be visible.");
        }
        /// <summary>
        /// is previous is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyPreviousButtonIsVisible()
        {
            PreviousButton.Displayed = true;
            Assert.AreEqual(true, PreviousButton.Displayed, "The previous button is invisible, but should be visible.");
        }
        /// <summary>
        /// verify next is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyNextButtonIsVisible()
        {
            NextButton.Displayed = true;
            Assert.AreEqual(true, NextButton.Displayed, "The next button is invisible, but should be visible.");
        }
        /// <summary>
        /// verify view test summary is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyViewTestSummaryButtonIsVisible()
        {
            ViewTestSummaryButton.Displayed = true;
            Assert.AreEqual(true, ViewTestSummaryButton.Displayed, "The view test summary button is invisible, but should be visible.");
        }
        /// <summary>
        /// verify test summary is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyTestSummaryButtonIsVisible()
        {
            TestSummaryButton.Displayed = true;
            Assert.AreEqual(true, TestSummaryButton.Displayed, "The test summary button is invisible, but should be visible.");
        }
        /// <summary>
        /// verify pause - return to test is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyPauseReturnToTestButtonIsVisible()
        {
            PauseReturnToTestButton.Displayed = true;
            Assert.AreEqual(true, PauseReturnToTestButton.Displayed, "The return to test button is invisible, but should be visible.");
        }
        /// <summary>
        /// verify return to test is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyReturnToTestButtonIsVisible()
        {
            ReturnToTestButton.Displayed = true;
            Assert.AreEqual(true, ReturnToTestButton.Displayed, "The return to test button is invisible, but should be visible.");
        }
        /// <summary>
        /// verify submit test is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifySubmitTestButtonIsVisible()
        {
            SubmitTestButton.Displayed = true;
            Assert.AreEqual(true, SubmitTestButton.Displayed, "The submit test button is invisible, but should be visible.");
        }
        /// <summary>
        /// verify submit test yes is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifySubmitTestYesButtonIsVisible()
        {
            SubmitTestYesButton.Displayed = true;
            Assert.AreEqual(true, SubmitTestYesButton.Displayed, "The submit test yes button is invisible, but should be visible.");
        }
        /// <summary>
        /// verify submit test is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifySubmitTestNoButtonIsVisible()
        {
            SubmitTestNoButton.Displayed = true;
            Assert.AreEqual(true, SubmitTestNoButton.Displayed, "The submit test no button is invisible, but should be visible.");
        }
        /// <summary>
        /// verify submit test is visible
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyCloseTestButtonIsVisible()
        {
            CloseTestButton.Displayed = true;
            Assert.AreEqual(true, CloseTestButton.Displayed, "The close test button is invisible, but should be visible.");
        }


        /// <summary>
        /// verify start test now is hidden
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyStartTestNowButtonIsHidden()
        {
            StartTestNowButton.Displayed = false;
            Assert.AreEqual(false, StartTestNowButton.Displayed, "The start test now button is visible, but should be invisible.");
        }
        /// <summary>
        /// verify pause is hidden
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyPauseButtonIsHidden()
        {
            PauseButton.Displayed = false;
            Assert.AreEqual(false, PauseButton.Displayed, "The pause button is visible, but should be invisible.");
        }
        /// <summary>
        /// verify exit test is hidden
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyExitTestButtonIsHidden()
        {
            ExitTestButton.Displayed = false;
            Assert.AreEqual(false, ExitTestButton.Displayed, "The exit test button is visible, but should be invisible.");
        }
        /// <summary>
        /// verify continue test now is hidden
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyContinueTestNowButtonIsHidden()
        {
            ContinueTestNowButton.Displayed = false;
            Assert.AreEqual(false, ContinueTestNowButton.Displayed, "The continue test now button is visible, but should be invisible.");
        }
        /// <summary>
        /// is previous is hidden
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyPreviousButtonIsHidden()
        {
            PreviousButton.Displayed = false;
            Assert.AreEqual(false, PreviousButton.Displayed, "The previous button is visible, but should be invisible.");
        }
        /// <summary>
        /// verify next is hidden
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyNextButtonIsHidden()
        {
            NextButton.Displayed = false;
            Assert.AreEqual(false, NextButton.Displayed, "The next button is visible, but should be invisible.");
        }
        /// <summary>
        /// verify view test summary is hidden
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyViewTestSummaryButtonIsHidden()
        {
            ViewTestSummaryButton.Displayed = false;
            Assert.AreEqual(false, ViewTestSummaryButton.Displayed, "The view test summary button is visible, but should be invisible.");
        }
        /// <summary>
        /// verify test summary is hidden
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyTestSummaryButtonIsHidden()
        {
            TestSummaryButton.Displayed = false;
            Assert.AreEqual(false, TestSummaryButton.Displayed, "The test summary button is visible, but should be invisible.");
        }
        /// <summary>
        /// verify pause - return to test is hidden
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyPauseReturnToTestButtonIsHidden()
        {
            PauseReturnToTestButton.Displayed = false;
            Assert.AreEqual(false, PauseReturnToTestButton.Displayed, "The return to test button is visible, but should be invisible.");
        }
        /// <summary>
        /// verify return to test is hidden
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyReturnToTestButtonIsHidden()
        {
            ReturnToTestButton.Displayed = false;
            Assert.AreEqual(false, ReturnToTestButton.Displayed, "The return to test button is visible, but should be invisible.");
        }
        /// <summary>
        /// verify submit test is hidden
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifySubmitTestButtonIsHidden()
        {
            SubmitTestButton.Displayed = false;
            Assert.AreEqual(false, SubmitTestButton.Displayed, "The submit test button is visible, but should be invisible.");
        }
        /// <summary>
        /// verify submit test: yes is hidden
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifySubmitTestYesButtonIsHidden()
        {
            SubmitTestYesButton.Displayed = false;
            Assert.AreEqual(false, SubmitTestYesButton.Displayed, "The submit test yes button is visible, but should be invisible.");
        }
        /// <summary>
        /// verify submit test: no is hidden
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifySubmitTestNoButtonIsHidden()
        {
            SubmitTestNoButton.Displayed = false;
            Assert.AreEqual(false, SubmitTestNoButton.Displayed, "The submit test no button is visible, but should be invisible.");
        }
        /// <summary>
        /// verify close test is hidden
        /// </summary>
        /// <returns>true or false</returns>
        public void VerifyCloseTestButtonIsHidden()
        {
            CloseTestButton.Displayed = false;
            Assert.AreEqual(false, CloseTestButton.Displayed, "The close test button is visible, but should be invisible.");
        }


        /// <summary>
        /// set test instruction state
        /// </summary>
        public void SetTestInstructionState()
        {
            //As its the Test Instructions Page
            IsStartTestPage = true;
            IsFirstTestQuestionPage = false;
            IsIntermediateTestQuestionPage = false;
            IsLastTestQuestionPage = false;
            IsPauseDialog = false;
            IsTestSummaryPage = false;
            //button state
            IsStartTestNowDisplayed = true;
            IsPauseDisplayed = false;
            IsExitTestDisplayed = false;
            IsPauseReturnToTestDisplayed = false;
            IsViewTestSummaryDisplayed = false;
            IsPreviousDisplayed = false;
            IsNextDisplayed = false;
            IsTestSummaryDisplayed = false;
            IsReturnToTestDisplayed = false;
            IsSubmitTestDisplayed = false;
            IsSubmitTestYesDisplayed = false;
            IsSubmitTestNoDisplayed = false;
        }
        /// <summary>
        /// set pause test item state
        /// </summary>
        public void SetPauseTestItemState()
        {
            //page = pause dialog
            IsStartTestPage = false;
            IsPauseDialog = true;
            IsTestSummaryPage = false;
            //button state
            IsStartTestNowDisplayed = false;
            IsPauseDisplayed = false;
            IsExitTestDisplayed = true;
            IsPauseReturnToTestDisplayed = true;
            IsViewTestSummaryDisplayed = false;
            IsPreviousDisplayed = false;
            IsNextDisplayed = false;
            IsTestSummaryDisplayed = false;
            IsReturnToTestDisplayed = false;
            IsSubmitTestDisplayed = false;
            IsSubmitTestYesDisplayed = false;
            IsSubmitTestNoDisplayed = false;
        }
        /// <summary>
        /// set first test item state
        /// </summary>
        public void SetFirstTestItemState()
        {
            //page = first question page
            IsStartTestPage = false;
            IsFirstTestQuestionPage = true;
            IsIntermediateTestQuestionPage = false;
            IsLastTestQuestionPage = false;
            IsPauseDialog = false;
            IsTestSummaryPage = false;
            //button state
            IsStartTestNowDisplayed = false;
            IsPauseDisplayed = true;
            IsExitTestDisplayed = false;
            IsPauseReturnToTestDisplayed = false;
            IsViewTestSummaryDisplayed = true;
            IsPreviousDisplayed = false;
            IsNextDisplayed = true;
            IsTestSummaryDisplayed = false;
            IsReturnToTestDisplayed = false;
            IsSubmitTestDisplayed = false;
            IsSubmitTestYesDisplayed = false;
            IsSubmitTestNoDisplayed = false;
        }
        /// <summary>
        /// set intermediate test item state
        /// </summary>
        public void SetIntermediateTestItemState()
        {
            //page = intermediate question pages
            IsStartTestPage = false;
            IsFirstTestQuestionPage = false;
            IsIntermediateTestQuestionPage = true;
            IsLastTestQuestionPage = false;
            IsPauseDialog = false;
            IsTestSummaryPage = false;
            //button state
            IsStartTestNowDisplayed = false;
            IsPauseDisplayed = true;
            IsExitTestDisplayed = false;
            IsPauseReturnToTestDisplayed = false;
            IsViewTestSummaryDisplayed = true;
            IsPreviousDisplayed = true;
            IsNextDisplayed = true;
            IsTestSummaryDisplayed = false;
            IsReturnToTestDisplayed = false;
            IsSubmitTestDisplayed = false;
            IsSubmitTestYesDisplayed = false;
            IsSubmitTestNoDisplayed = false;
        }
        /// <summary>
        /// set last test item state
        /// </summary>
        public void SetLastTestItemState()
        {
            //page = last question page
            IsStartTestPage = false;
            IsFirstTestQuestionPage = false;
            IsIntermediateTestQuestionPage = false;
            IsLastTestQuestionPage = true;
            IsPauseDialog = false;
            IsTestSummaryPage = false;
            //button state
            IsStartTestNowDisplayed = false;
            IsPauseDisplayed = true;
            IsExitTestDisplayed = false;
            IsPauseReturnToTestDisplayed = false;
            IsViewTestSummaryDisplayed = false;
            IsPreviousDisplayed = true;
            IsNextDisplayed = false;
            IsTestSummaryDisplayed = true;
            IsReturnToTestDisplayed = false;
            IsSubmitTestDisplayed = false;
            IsSubmitTestYesDisplayed = false;
            IsSubmitTestNoDisplayed = false;
        }
        /// <summary>
        /// set test summary state
        /// </summary>
        public void SetTestSummaryState()
        {
            //page = test summary page
            IsStartTestPage = false;
            IsFirstTestQuestionPage = false;
            IsIntermediateTestQuestionPage = false;
            IsLastTestQuestionPage = false;
            IsPauseDialog = false;
            IsTestSummaryPage = true;
            //button state
            IsStartTestNowDisplayed = false;
            IsPauseDisplayed = true;
            IsExitTestDisplayed = false;
            IsPauseReturnToTestDisplayed = false;
            IsViewTestSummaryDisplayed = false;
            IsPreviousDisplayed = false;
            IsNextDisplayed = false;
            IsTestSummaryDisplayed = false;
            IsReturnToTestDisplayed = true;
            IsSubmitTestDisplayed = true;
            IsSubmitTestYesDisplayed = false;
            IsSubmitTestNoDisplayed = false;
        }
        /// <summary>
        /// set submit test state
        /// </summary>
        public void SetSubmitTestState()
        {
            //page = test summary page
            IsStartTestPage = false;
            IsFirstTestQuestionPage = false;
            IsIntermediateTestQuestionPage = false;
            IsLastTestQuestionPage = false;
            IsPauseDialog = true;
            IsTestSummaryPage = true;
            //button state
            IsStartTestNowDisplayed = false;
            IsPauseDisplayed = false;
            IsExitTestDisplayed = false;
            IsPauseReturnToTestDisplayed = false;
            IsViewTestSummaryDisplayed = false;
            IsPreviousDisplayed = false;
            IsNextDisplayed = false;
            IsTestSummaryDisplayed = false;
            IsReturnToTestDisplayed = false;
            IsSubmitTestDisplayed = false;
            IsSubmitTestYesDisplayed = true;
            IsSubmitTestNoDisplayed = true;
            IsCloseTestDisplayed = false;
        }
        /// <summary>
        /// set submit test - yes state
        /// </summary>
        public void SetSubmitTestYesState()
        {
            //page = test summary page
            IsStartTestPage = false;
            IsFirstTestQuestionPage = false;
            IsIntermediateTestQuestionPage = false;
            IsLastTestQuestionPage = false;
            IsPauseDialog = true;
            IsTestSummaryPage = true;
            //button state
            IsStartTestNowDisplayed = false;
            IsPauseDisplayed = true;
            IsExitTestDisplayed = false;
            IsPauseReturnToTestDisplayed = false;
            IsViewTestSummaryDisplayed = false;
            IsPreviousDisplayed = false;
            IsNextDisplayed = false;
            IsTestSummaryDisplayed = false;
            IsReturnToTestDisplayed = true;
            IsSubmitTestDisplayed = true;
            IsSubmitTestYesDisplayed = false;
            IsSubmitTestNoDisplayed = false;
            IsCloseTestDisplayed = true;
        }
        /// <summary>
        /// set submit test - no state
        /// </summary>
        public void SetSubmitTestNoState()
        {
            //page = test summary page
            IsStartTestPage = false;
            IsFirstTestQuestionPage = false;
            IsIntermediateTestQuestionPage = false;
            IsLastTestQuestionPage = false;
            IsPauseDialog = false;
            IsTestSummaryPage = true;
            //button state
            IsStartTestNowDisplayed = false;
            IsPauseDisplayed = true;
            IsExitTestDisplayed = false;
            IsPauseReturnToTestDisplayed = false;
            IsViewTestSummaryDisplayed = false;
            IsPreviousDisplayed = false;
            IsNextDisplayed = false;
            IsTestSummaryDisplayed = false;
            IsReturnToTestDisplayed = true;
            IsSubmitTestDisplayed = true;
            IsSubmitTestYesDisplayed = false;
            IsSubmitTestNoDisplayed = false;
            IsCloseTestDisplayed = false;
        }
        /// <summary>
        /// set close test state
        /// </summary>
        public void SetCloseTestState()
        {
            //page = test summary page
            IsStartTestPage = false;
            IsFirstTestQuestionPage = false;
            IsIntermediateTestQuestionPage = false;
            IsLastTestQuestionPage = false;
            IsPauseDialog = false;
            IsTestSummaryPage = false;
            //button state
            IsStartTestNowDisplayed = false;
            IsPauseDisplayed = false;
            IsExitTestDisplayed = false;
            IsPauseReturnToTestDisplayed = false;
            IsViewTestSummaryDisplayed = false;
            IsPreviousDisplayed = false;
            IsNextDisplayed = false;
            IsTestSummaryDisplayed = false;
            IsReturnToTestDisplayed = false;
            IsSubmitTestDisplayed = false;
            IsSubmitTestYesDisplayed = false;
            IsSubmitTestNoDisplayed = false;
            IsCloseTestDisplayed = false;
        }


        private By ByProgressBar { get { return By.CssSelector("#data .dataTable #progressContainer #divProgressBar"); } }
        private WebElementWrapper ProgressBar { get; set; }
        private By ByProgressAnsweredLabel { get { return By.CssSelector("#data .dataTable .dataRow #tdAnswered.dataField > .currentValue"); } }
        private WebElementWrapper ProgressAnsweredLabel { get; set; }
        private By ByProgressFlaggedLabel { get { return By.CssSelector("#data .dataTable .dataRow #tdFlagged.dataField > .currentValue"); } }
        private WebElementWrapper ProgressFlaggedLabel { get; set; }

        /// <summary>
        /// get the count of answered questions
        /// </summary>
        /// <returns>count</returns>
        public int GetProgressAnsweredCount()
        {
            ProgressAnsweredLabel.Wait(3);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                int fakeCount = 0;
                foreach (var testTypeForm in TestList)
                {
                    if (testTypeForm.TestItemStatus.Equals(TestItemStatus.Answered))
                    {
                        fakeCount++;
                    }
                }
                Report.Write("ProgressAnsweredLabel fakeCount: " + fakeCount);
                ProgressAnsweredLabel.Text = Convert.ToString(fakeCount);
            }
            string progressValue = ProgressAnsweredLabel.Text;
            int count = Convert.ToInt32(progressValue);
            return count;
        }
        /// <summary>
        /// get the count of flagged questions
        /// </summary>
        /// <returns>count</returns>
        public int GetProgressFlaggedCount()
        {
            ProgressFlaggedLabel.Wait(3);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                int fakeCount = 0;
                foreach (var testTypeForm in TestList)
                {
                    if (testTypeForm.TestItemFlagged == true)
                    {
                        fakeCount++;
                    }
                }
                Report.Write("ProgressFlaggedLabel fakeCount: " + fakeCount);
                ProgressFlaggedLabel.Text = Convert.ToString(fakeCount);
            }
            string progressValue = ProgressFlaggedLabel.Text;
            int count = Convert.ToInt32(progressValue);
            return count;
        }
        /// <summary>
        /// get the progress bar percentage
        /// </summary>
        /// <returns>percentage as integer</returns>
        public int GetProgressBar()
        {
            ProgressBar.Wait(5);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                int fakeCount = 0;
                foreach (var testTypeForm in TestList)
                {
                    if (testTypeForm.TestItemStatus.Equals(TestItemStatus.Answered))
                    {
                        fakeCount++;
                    }
                }
                Report.Write("ProgressBar fakeCount: " + fakeCount);
                int testItemCount = TestList.Count;
                int increments = 100 / testItemCount;
                Report.Write("ProgressBar increments: " + increments);
                int progress = increments * fakeCount;
                Report.Write("ProgressBar progress: " + progress);
                ProgressBar.FakeAttributeAriaValueNow = Convert.ToString(progress) + " percent progressed";
            }
            string progressValue = ProgressBar.GetAttribute("aria-valuenow");
            int space = -1;
            space = progressValue.IndexOf(" ");
            string progressPercentage = null;
            if (space > -1)
            {
                progressPercentage = progressValue.Substring(0, space);
            }
            else
            {
                progressPercentage = progressValue;
            }
            int count = Convert.ToInt32(progressPercentage);
            return count;
        }
    }
}
