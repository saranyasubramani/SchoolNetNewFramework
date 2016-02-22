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
using UITests.Pages.Controls;
using UITests.Pages.Assess.TestWindow.PlanHome;

namespace UITests.Pages.Assess.TestWindow.ViewTestWindow
{
    /// <summary>
    /// view test window form
    /// </summary>
    public class ViewTestWindowForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public ViewTestWindowForm(string overrideControlPrefix = null)
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
            //Subject = new Subject(PageNames.TestWindowViewTestWindow);
            //GradeLevel = new GradeLevel(PageNames.TestWindowViewTestWindow, this.ControlPrefix);
            SubjectElement subject = new SubjectElement(PageNames.TestWindowViewTestWindow);
            SubjectSelect = subject.SelectElement;
            GradeLevelElement gradeLevel = new GradeLevelElement(PageNames.TestWindowViewTestWindow);
            GradeFromSelect = gradeLevel.FromSelectElement;
            GradeToSelect = gradeLevel.ToSelectElement;
            TestWindowName = new WebElementWrapper(ByTestWindowName);
            DateFrom = new WebElementWrapper(ByDateFrom);
            DateTo = new WebElementWrapper(ByDateTo);
            Grid = new PlanHomeGrid(GridLocator);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new ViewTestWindowData Data
        {
            get
            {
                return (ViewTestWindowData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_ButtonGo
        public override By BySubmit { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_ButtonGo"); } }
        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TextBoxTestName
        private By ByTestWindowName { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_TextBoxTestName"); } }
        private WebElementWrapper TestWindowName { get; set; }
        //private Subject Subject { get; set; }
        //private GradeLevel GradeLevel { get; set; }
        public SelectElementWrapper SubjectSelect { get; private set; }
        public SelectElementWrapper GradeFromSelect { get; private set; }
        public SelectElementWrapper GradeToSelect { get; private set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TextBoxAdminStartDate
        private By ByDateFrom { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_TextBoxAdminStartDate"); } }
        private WebElementWrapper DateFrom { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TextBoxAdminEndDate
        private By ByDateTo { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderSearch1_TextBoxAdminEndDate"); } }
        private WebElementWrapper DateTo { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderResults1_gridResults
        private string GridLocator { get { return "#" + ControlPrefix + "TestSearchResults1_TestFinderResults1_gridResults"; } }
        public PlanHomeGrid Grid { get; set; }

        #region Grid

        /// <summary>
        /// Find the test window name and click on the link 
        /// </summary>
        public void SelectTestWindowName()
        {
            string testWindowName = Data.TestWindowName;
            Grid.SetGridLists();

            List<PlanHomeRow> testWindowFound =
                Grid.GetsRowsContainingTextToFindFromList(PlanHomeColumnNames.TestWindowName, testWindowName);

            if (testWindowFound != null)
            {
                Report.Write("Attempting to select test window " + testWindowName);
                testWindowFound[0].SelectColumn(PlanHomeColumnNames.TestWindowName);
            }
        }

        /// <summary>
        /// Find the test window name and click on the Select link 
        /// </summary>
        public void SelectTest()
        {
            string testWindowName = Data.TestWindowName;
            Grid.SetGridLists();

            List<PlanHomeRow> testList =
                Grid.GetsRowsContainingTextToFindFromList(PlanHomeColumnNames.TestWindowName, testWindowName);

            if (testList != null)
            {
                Report.Write("Attempting to click the Select link for test: " + testWindowName);
                testList[0].SelectTest();
            }
        }

        #endregion

        //implemented methods
        public override void InputFormFields()
        {
            if (Data.TestWindowName != null)
            {
                TestWindowName.Wait(5).SendKeys(Data.TestWindowName);
            }
            if (Data.Subject != null)
            {
                SubjectSelect.Wait(3).SelectByText(Data.Subject);
            }
            if (Data.GradeLow != null)
            {
                GradeFromSelect.Wait(5);
                GradeFromSelect.Wait(5).SelectByText(Data.GradeLow);
            }
            if (Data.GradeHigh != null)
            {
                GradeToSelect.Wait(5);
                GradeToSelect.Wait(5).SelectByText(Data.GradeHigh);
            }
            if (Data.DateFrom != null)
            {
                DateFrom.Wait(5).SendKeys(Data.DateFrom);
            }
            if (Data.DateTo != null)
            {
                DateTo.Wait(5).SendKeys(Data.DateTo);
            }
        }
    }
}
