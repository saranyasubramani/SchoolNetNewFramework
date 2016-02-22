using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Assess.Schedule;

namespace UITests.Pages.Assess.TestDetail.ViewTestDetails
{
    /// <summary>
    /// the test details: schedule information side bar component
    /// </summary>
    public class TestDetailsScheduleInformationSideBar : TestDetailsSideBar
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TestDetailsScheduleInformationSideBar()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            ScheduleInformationLink = new WebElementWrapper( ByScheduleInformationLink);
            StartDateLabel = new WebElementWrapper( ByStartDateLabel);
            EndDateLabel = new WebElementWrapper( ByEndDateLabel);
            ScoreDateLabel = new WebElementWrapper( ByScoreDateLabel);
            TestIsRecommendedAssignedToSchoolsLabel = new WebElementWrapper( ByTestIsRecommendedAssignedToSchoolsLabel);
            TestIsRecommendedAssignedToCoursesLabel = new WebElementWrapper( ByTestIsRecommendedAssignedToCoursesLabel);
            TestResultsWillNotBeExportedLabel = new WebElementWrapper( ByTestResultsWillNotBeExportedLabel);
            EditScheduleAndSettingsLink = new WebElementWrapper( ByEditScheduleAndSettingsLink);
            ViewAssignmentSummaryLink = new WebElementWrapper( ByViewAssignmentSummaryLink);
            ScheduleTestLink = new WebElementWrapper( ByScheduleTestLink);
            TestWindowLink = new WebElementWrapper( ByTestWindowLink);
        }

        private By ByScheduleInformationLink { get { return By.CssSelector(".well #" + ControlPrefix + "TestInfoSidebar1_PanelSchedule .AccordianHeader"); } }
        private WebElementWrapper ScheduleInformationLink { get; set; }
        private By ByStartDateLabel { get { return By.CssSelector(".well #" + ControlPrefix + "TestInfoSidebar1_PanelSchedule .AccordianContent > div:nth-of-type(2)"); } }
        private WebElementWrapper StartDateLabel { get; set; }
        private By ByEndDateLabel { get { return By.CssSelector(".well #" + ControlPrefix + "TestInfoSidebar1_PanelSchedule .AccordianContent > div:nth-of-type(3)"); } }
        private WebElementWrapper EndDateLabel { get; set; }
        private By ByScoreDateLabel { get { return By.CssSelector(".well #" + ControlPrefix + "TestInfoSidebar1_PanelSchedule .AccordianContent > div:nth-of-type(4)"); } }
        private WebElementWrapper ScoreDateLabel { get; set; }
        private By ByTestIsRecommendedAssignedToSchoolsLabel { get { return By.CssSelector(".well #" + ControlPrefix + "TestInfoSidebar1_PanelSchedule .AccordianContent > div:nth-of-type(6)"); } }
        private WebElementWrapper TestIsRecommendedAssignedToSchoolsLabel { get; set; }
        private By ByTestIsRecommendedAssignedToCoursesLabel { get { return By.CssSelector(".well #" + ControlPrefix + "TestInfoSidebar1_PanelSchedule .AccordianContent > div:nth-of-type(7)"); } }
        private WebElementWrapper TestIsRecommendedAssignedToCoursesLabel { get; set; }
        private By ByTestResultsWillNotBeExportedLabel { get { return By.CssSelector(".well #" + ControlPrefix + "TestInfoSidebar1_PanelSchedule .AccordianContent > div:nth-of-type(8)"); } }
        private WebElementWrapper TestResultsWillNotBeExportedLabel { get; set; }
        private By ByEditScheduleAndSettingsLink { get { return By.Id("HyperLinkEditSchedule"); } }
        private WebElementWrapper EditScheduleAndSettingsLink { get; set; }
        private By ByViewAssignmentSummaryLink { get { return By.Id("HyperLinkViewSchedule"); } }
        private WebElementWrapper ViewAssignmentSummaryLink { get; set; }
        //15.4
        //private By ByScheduleTestLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_ButtonEditSchedule"); } }
        //16.0
        //HyperLinkEditSchedule
        private By ByScheduleTestLink { get { return By.Id("HyperLinkEditSchedule"); } }
        private WebElementWrapper ScheduleTestLink { get; set; }
        //15.4
        //private By ByTestWindowLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_ButtonLinkTestWindow"); } }
        //16.0
        private By ByTestWindowLink { get { return By.Id("ButtonLinkTestWindow"); } }
        private WebElementWrapper TestWindowLink { get; set; }

        /// <summary>
        /// expand schedule information
        /// </summary>
        public override void ExpandLink()
        {
            ScheduleInformationLink.Wait(2);
            ScheduleInformationLink.FakeAttributeClass = "AccordianClosed";
            if (ScheduleInformationLink.GetAttribute("class").Trim().ToLower().Contains("accordianclosed"))
            {
                ScheduleInformationLink.Click();
                StartDateLabel.Wait(10);
            }
        }
        /// <summary>
        /// collapse schedule information
        /// </summary>
        public override void CollapseLink()
        {
            ScheduleInformationLink.Wait(2);
            ScheduleInformationLink.FakeAttributeClass = "AccordianOpen";
            if (ScheduleInformationLink.GetAttribute("class").Trim().ToLower().Contains("accordianopen"))
            {
                ScheduleInformationLink.Click();
            }
        }

        /// <summary>
        /// get the start data
        /// </summary>
        /// <returns>text</returns>
        public string GetStartDate()
        {
            return this.StartDateLabel.Wait(2).Text;
        }
        /// <summary>
        /// get the end date
        /// </summary>
        /// <returns>text</returns>
        public string GetEndDate()
        {
            return this.EndDateLabel.Wait(2).Text;
        }
        /// <summary>
        /// get the score date
        /// </summary>
        /// <returns>text</returns>
        public string GetScoreDate()
        {
            return this.ScoreDateLabel.Wait(2).Text;
        }

        /// <summary>
        /// get the text is recommended/assigned to schools
        /// </summary>
        /// <returns>text</returns>
        public string GetTestIsRecommendedAssignedToSchools()
        {
            this.TestIsRecommendedAssignedToSchoolsLabel.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                TestIsRecommendedAssignedToSchoolsLabel.Text = FakeText;
            }
            return this.TestIsRecommendedAssignedToSchoolsLabel.Text;
        }

        /// <summary>
        /// get the text is recommended/assigned to courses in schools
        /// </summary>
        /// <returns>text</returns>
        public string GetTestIsRecommendedAssignedToCourses()
        {
            this.TestIsRecommendedAssignedToCoursesLabel.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                TestIsRecommendedAssignedToCoursesLabel.Text = FakeText;
            }
            return this.TestIsRecommendedAssignedToCoursesLabel.Text;
        }
        /// <summary>
        /// get the test results will not be exported
        /// </summary>
        /// <returns>text</returns>
        public string GetTestResultsWillNotBeExported()
        {
            return this.TestResultsWillNotBeExportedLabel.Wait(2).Text;
        }

        /// <summary>
        /// edit schedule and settings
        /// </summary>
        /// <returns>EditSchedulePage</returns>
        public EditSchedulePage EditScheduleAndSettings()
        {
            EditScheduleAndSettingsLink.Wait(2).Click();
            return new EditSchedulePage();
        }
        /// <summary>
        /// view assignment summary
        /// </summary>
        public void ViewAssignmentSummary()
        {
            ViewAssignmentSummaryLink.Wait(2).Click();
        }
        /// <summary>
        /// schedule this test
        /// </summary>
        /// <returns>EditSchedulePage</returns>
        public EditSchedulePage ScheduleTest()
        {
            ScheduleTestLink.Wait(2).Click();
            return new EditSchedulePage();
        }
        /// <summary>
        /// link to test window
        /// </summary>
        public void LinkTestWindow()
        {
            TestWindowLink.Wait(2).Click();
            //TODO: return LinkTestWindow.aspx
        }
    }
}
