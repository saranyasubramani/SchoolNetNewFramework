using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Assess.TestTunnel;
using UITests.Pages.Assess.TestDetail.Components;
using UITests.Pages.Assess.TestCreateEdit;
using UITests.Pages.Assess.TestCreateEdit.Components;

namespace UITests.Pages.Assess.TestDetail.ViewTestDetails
{
    /// <summary>
    /// the test details: test actions side bar component
    /// </summary>
    public class TestDetailsTestActionsSideBar : TestDetailsSideBar
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TestDetailsTestActionsSideBar()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            TestActionsLink = new WebElementWrapper( ByTestActionsLink);
            CopyTestLink = new WebElementWrapper( ByCopyTestLink);
            DeleteTestLink = new WebElementWrapper( ByDeleteTestLink);
            AnswerSheetsLink = new WebElementWrapper( ByAnswerSheetsLink);
            ScoreTestLink = new WebElementWrapper( ByScoreTestLink);
            ViewUsernamesLink = new WebElementWrapper( ByViewUsernamesLink);
            TrackAccomodationsLink = new WebElementWrapper( ByTrackAccomodationsLink);
            PreviewOnlineTestLink = new WebElementWrapper( ByPreviewOnlineTestLink);
            StudentTestBookletPdfLink = new WebElementWrapper( ByStudentTestBookletPdfLink);
            StudentTestBookletDocLink = new WebElementWrapper( ByStudentTestBookletDocLink);
            AnswerKeyPdfLink = new WebElementWrapper( ByAnswerKeyPdfLink);
            TestRubricsPdfLink = new WebElementWrapper( ByTestRubricsPdfLink);
            ScoringInstructionsPdfLink = new WebElementWrapper( ByScoringInstructionsPdfLink);
            CoverSheetPdfLink = new WebElementWrapper( ByCoverSheetPdfLink);
        }

        private string CurrentWindow;
        private By ByTestActionsLink { get { return By.CssSelector(".well #" + ControlPrefix + "TestInfoSidebar1_PanelToolbox .AccordianHeader"); } }
        private WebElementWrapper TestActionsLink { get; set; }
        private By ByCopyTestLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_ButtonCopy"); } }
        private WebElementWrapper CopyTestLink { get; set; }
        private By ByDeleteTestLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_ButtonDeleteTest"); } }
        private WebElementWrapper DeleteTestLink { get; set; }
        private By ByAnswerSheetsLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_LinkAnswerSheets"); } }
        private WebElementWrapper AnswerSheetsLink { get; set; }
        private By ByScoreTestLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_LinkScore"); } }
        private WebElementWrapper ScoreTestLink { get; set; }
        private By ByViewUsernamesLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_LinkViewUsernames"); } }
        private WebElementWrapper ViewUsernamesLink { get; set; }
        private By ByTrackAccomodationsLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_LinkTrackAccommodations"); } }
        private WebElementWrapper TrackAccomodationsLink { get; set; }
        private By ByPreviewOnlineTestLink { get { return By.Id("ButtonPreviewTest"); } }
        private WebElementWrapper PreviewOnlineTestLink { get; set; }
        private By ByStudentTestBookletPdfLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_ButtonDownloadTestPDF"); } }
        private WebElementWrapper StudentTestBookletPdfLink { get; set; }
        private By ByStudentTestBookletDocLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_ButtonDownloadTestWord"); } }
        private WebElementWrapper StudentTestBookletDocLink { get; set; }
        private By ByAnswerKeyPdfLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_ButtonDownloadAnswerKey"); } }
        private WebElementWrapper AnswerKeyPdfLink { get; set; }
        private By ByTestRubricsPdfLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_ButtonDownloadTestRubrics"); } }
        private WebElementWrapper TestRubricsPdfLink { get; set; }
        private By ByScoringInstructionsPdfLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_ButtonDownloadInstructions"); } }
        private WebElementWrapper ScoringInstructionsPdfLink { get; set; }
        private By ByCoverSheetPdfLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_ButtonDownloadCoverSheet"); } }
        private WebElementWrapper CoverSheetPdfLink { get; set; }

        /// <summary>
        /// expand test actions
        /// </summary>
        public override void ExpandLink()
        {
            TestActionsLink.Wait(2);
            TestActionsLink.FakeAttributeClass = "AccordianClosed";
            if (TestActionsLink.GetAttribute("class").Trim().ToLower().Contains("accordianclosed"))
            {
                TestActionsLink.Click();
            }
        }

        /// <summary>
        /// collapse test actions
        /// </summary>
        public override void CollapseLink()
        {
            TestActionsLink.Wait(2);
            TestActionsLink.FakeAttributeClass = "AccordianOpen";
            if (TestActionsLink.GetAttribute("class").Trim().ToLower().Contains("accordianopen"))
            {
                TestActionsLink.Click();
            }
        }

        /// <summary>
        /// copy the test
        /// </summary>
        public CreateTestManualPage CopyTest()
        {
            CopyTestLink.Wait(2).Click();
            //pause the script for a second to let the click event register before waiting for the page to load - click seems to be delayed
            System.Threading.Thread.Sleep(1000);
            return new CreateTestManualPage( CreateTestModes.CreateCopyOfTest);
        }

        /// <summary>
        /// Delete the test. Clicking this link and Accepting the Alert can take you to different pages based on the Workflow.
        /// </summary>
        public void DeleteTest()
        {
            CurrentWindow = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + CurrentWindow + "'.");

            DeleteTestLink.Wait(2).Click();
            AlertHandler alert = new AlertHandler();
            alert.VerifyText("Are you sure you want to delete this test?");
            alert.VerifyText("This cannot be undone.");
            alert.Accept();
            /*
            IAlert alert = Driver.SwitchTo().Alert();
            string expected1 = "Are you sure you want to delete this test?";
            string expected2 = "This cannot be undone.";
            if (Driver.GetType() == typeof (DummyDriver))
            {
                ((DummyIAlert)alert).Text = expected1 + " " + expected2;
            }
            string actual = alert.Text;
            Debug.WriteLine("The alert text: '" + actual + "'.");
            Assert.IsTrue(actual.Contains(expected1), "The delete confirmation pop-up does not contain the expected text: '" + expected1 + "'; actual text: '" + actual + "'.");
            Assert.IsTrue(actual.Contains(expected2), "The delete confirmation pop-up does not contain the expected text: '" + expected2 + "'; actual text: '" + actual + "'.");
            alert.Accept();
            */

            //switch to window
            DriverCommands.WaitToSwitchWindow(CurrentWindow, 5);
        }

        /// <summary>
        /// Answer Sheets Generation
        /// </summary>
        public void AnswerSheets()
        {
            AnswerSheetsLink.Wait(2).Click();
        }

        /// <summary>
        /// Score the Test. Clicking this Link can take you to different Score Pages based on the permissions of the User.
        /// </summary>
        public void ScoreTest()
        {
            ScoreTestLink.Wait(2).Click();
        }

        /// <summary>
        /// View Usernames of Students to which this Test has been assigned
        /// </summary>
        public UsernameGeneratorPage ViewUsernames()
        {
            ViewUsernamesLink.Wait(2).Click();
            return new UsernameGeneratorPage();
        }

        /// <summary>
        /// To Track Accomodations
        /// </summary>
        public TrackAccomodationsPage TrackAccomodations()
        {
            TrackAccomodationsLink.Wait(2).Click();
            return new TrackAccomodationsPage();
        }

        /// <summary>
        /// preview online test tunnel
        /// </summary>
        /// <returns>TestTunnelPage</returns>
        public DefaultPage PreviewOnlineTest()
        {
            //CurrentWindow = Driver.CurrentWindowHandle;
            //Debug.WriteLine("The current window is: '" + CurrentWindow + "'.");

            PreviewOnlineTestLink.Wait(2).Click();
            /*
            var windowHandles = Driver.WindowHandles;

            foreach (var windowHandle in windowHandles)
            {
                Debug.WriteLine("The current window is: '" + windowHandle + "'.");
                if (windowHandle != CurrentWindow)
                {
                    Driver.SwitchTo().Window(windowHandle);
                }
            }
            */
            return new DefaultPage();
        }

        /// <summary>
        /// student test booklet PDF
        /// </summary>
        public void StudentTestBookletPdf()
        {
            StudentTestBookletPdfLink.Wait(2).Click();
        }

        /// <summary>
        /// student test booklet Word document
        /// </summary>
        public void StudentTestBookletDoc()
        {
            StudentTestBookletDocLink.Wait(2).Click();
        }

        /// <summary>
        /// answer key PDF
        /// </summary>
        public void AnswerKeyPdf()
        {
            AnswerKeyPdfLink.Wait(2).Click();
        }

        /// <summary>
        /// Test Rubrics PDF
        /// </summary>
        public void TestRubricsPdf()
        {
            TestRubricsPdfLink.Wait(2).Click();
        }

        /// <summary>
        /// Scoring Instructions PDF
        /// </summary>
        public void ScoringInstructionsPdf()
        {
            ScoringInstructionsPdfLink.Wait(2).Click();
        }

        /// <summary>
        /// cover sheet PDF
        /// </summary>
        public void CoverSheetPdf()
        {
            CoverSheetPdfLink.Wait(2).Click();
        }
    }
}
