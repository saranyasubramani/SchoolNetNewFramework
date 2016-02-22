using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Controls;

namespace UITests.Pages.Assess.Dashboard.ProfileHome.Tabs
{
    /// <summary>
    /// Search form on the Assessment Dashboard's tabs (Active Tests, Benchmark Tests, and Classroom Tests)
    /// </summary>
    public class ProfileHomeTabSearchForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="tabName">the tab name</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ProfileHomeTabSearchForm(ProfileHomeTabNames tabName, string overrideControlPrefix = null)
            : base()
        {
            TabName = tabName;
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }

        public override void InitElements()
        {
            TestCategoriesSelect = new SelectElementWrapper(new WebElementWrapper(ByTestCategoriesSelect));
            SubjectElement subject = new SubjectElement(PageNames.TeacherAssessDashboard);
            SubjectSelect = subject.SelectElement;
            GradeLevelElement gradeLevel = new GradeLevelElement(PageNames.TeacherAssessDashboard);
            GradeFromSelect = gradeLevel.FromSelectElement;
            GradeToSelect = gradeLevel.ToSelectElement;
        }

        private ProfileHomeTabNames TabName { get; set; }

        /// <summary>
        /// the data object
        /// </summary>
        public new ProfileHomeTabSearchData Data
        {
            get
            {
                return (ProfileHomeTabSearchData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// the submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ProfileControl_ButtonFilter"); } }

        private By ByTestCategoriesSelect { get { return By.Id(ControlPrefix + "ProfileControl_TestCategorySelector1_DropDownListCategory"); } }
        private SelectElementWrapper TestCategoriesSelect { get; set; }

        public SelectElementWrapper SubjectSelect { get; private set; }
        public SelectElementWrapper GradeFromSelect { get; private set; }
        public SelectElementWrapper GradeToSelect { get; private set; }

        public override void InputFormFields()
        {
            TestCategoriesSelect.Wait(5).SelectByText(Data.TestCategory);
            SubjectSelect.Wait().SelectByText(Data.Subject);
            GradeFromSelect.Wait().SelectByText(Data.GradeLow);
            GradeToSelect.Wait().SelectByText(Data.GradeHigh);
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return new TeacherProfileHomePage(TabName);
        }
        public override IBaseScreenView ReturnCancelPage()
        {
            return null;
        }
    }
}
