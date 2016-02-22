using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages;
using UITests.Pages.Home;
using UITests.Pages.Controls;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestCentral;

namespace UITests.Pages.Assess.Dashboard.ProfileHome
{
    /// <summary>
    /// Assess Dashboard Advanced Search Form
    /// </summary>
    public class ProfileHomeForm : SNForm
    {
        public ProfileHomeForm() : base()
        {
            InitElements();
        }
        /// <summary>
        /// intialize elements
        /// </summary>
        public override void InitElements()
        {
            TestCentralLink = new WebElementWrapper(ByTestCentralLink);
            TestId = new WebElementWrapper(ByTestId);
            RecentlyViewedTests = new SelectElementWrapper(new WebElementWrapper(ByRecentlyViewedTests));
            SubjectElement subject = new SubjectElement(PageNames.AssessDashboard);
            SubjectSelect = subject.SelectElement;
            GradeLevelElement gradeLevel = new GradeLevelElement(PageNames.AssessDashboard);
            GradeFromSelect = gradeLevel.FromSelectElement;
            GradeToSelect = gradeLevel.ToSelectElement;
        }
        /// <summary>
        /// the data
        /// </summary>
        public new ProfileHomeData Data
        {
            get
            {
                return (ProfileHomeData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        public By ByTestCentralLink { get { return By.Id(ControlPrefix + "ProfileControl_TestFinderSearchCompressed1_LinkAdvancedSearch"); } }
        public WebElementWrapper TestCentralLink { get; private set; }
        public By ByTestId { get { return By.Id(ControlPrefix + "ProfileControl_TestFinderSearchCompressed1_TextBoxTestName"); } }
        public WebElementWrapper TestId { get; private set; }
        public By ByRecentlyViewedTests { get { return By.Id(ControlPrefix + "ProfileControl_TestFinderSearchCompressed1_DropDownListRecentlyViewedTests"); } }
        public SelectElementWrapper RecentlyViewedTests { get; private set; }
        public override By BySubmit { get { return By.Id(ControlPrefix + "ProfileControl_TestFinderSearchCompressed1_ButtonGo"); } }

        public SelectElementWrapper SubjectSelect { get; private set; }
        public SelectElementWrapper GradeFromSelect { get; private set; }
        public SelectElementWrapper GradeToSelect { get; private set; }

        /// <summary>
        /// select test central link
        /// </summary>
        /// <returns>TestCentralHomePage</returns>
        public TestCentralHomePage ClickTestCentralLink()
        {
            TestCentralLink.Wait().Click();
            return new TestCentralHomePage();
        }

        //implemented methods
        public override void InputFormFields()
        {
            if (Data.TestId != null)
            {
                //TestId.MouseOverAndClick(TestId);
                TestId.Clear();
                TestId.SendKeys(Data.TestId);
            }
            if (Data.Subject != null)
            {
                SubjectSelect.Wait().SelectByText(Data.Subject);
            }
            if (Data.RecentlyViewedTests != null)
            {
                RecentlyViewedTests.SelectByText(Data.RecentlyViewedTests);
            }
            if (Data.GradeLevelFrom != null)
            {
                GradeFromSelect.Wait().SelectByText(Data.GradeLevelFrom);
            }
            if (Data.GradeLevelTo != null)
            {
                GradeToSelect.Wait().SelectByText(Data.GradeLevelTo);
            }
        }

        public virtual IBaseScreenView SubmitForm()
        {
            try
            {
                Submit.Click();
                DriverCommands.WaitAndMeasurePageLoadTime();
            }
            catch (Exception e)
            {
                //
            }
            return ReturnSubmitPage();
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return null;
        }
        public override IBaseScreenView ReturnCancelPage()
        {
            return null;
        }
    }
}
