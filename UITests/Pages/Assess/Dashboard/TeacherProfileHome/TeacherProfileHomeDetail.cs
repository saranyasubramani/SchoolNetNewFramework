using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Assess.Dashboard.ProfileHome.Tabs;
using UITests.Pages.Assess.ItemCentral;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestCentral;
using UITests.Pages.Assess.TestCreateEdit;
using UITests.Pages.Assess.Dashboard.ProfileHome;

namespace UITests.Pages.Assess.Dashboard.TeacherProfileHome
{
    /// <summary>
    /// the assessment dashboard detail for the teacher
    /// </summary>
    public class TeacherProfileHomeDetail : ProfileHomeDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="tabName">the tab name</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public TeacherProfileHomeDetail(ProfileHomeTabNames tabName, string overrideControlPrefix = null)
            : base()
        {
            TabName = tabName;
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }

        public override void InitElements(){
            //base.InitElements();
            FindTest = new WebElementWrapper(ByFindTest);
            FindItem = new WebElementWrapper(ByFindItem);
            CreateTest = new WebElementWrapper(ByCreateTest);
            CreateItem = new WebElementWrapper(ByCreateItem);
            HeaderTitleLabel = new WebElementWrapper(ByHeaderTitleLabel);
            //extended for teacher
            CreateDropdown = new WebElementWrapper(ByCreateDropdown);
            FindDropdown = new WebElementWrapper(ByFindDropdown);
            ActiveTestsLink = new WebElementWrapper(ByActiveTestsLink);
            BenchmarkTestsLink = new WebElementWrapper(ByBenchmarkTestsLink);
            ClassroomTestsLink = new WebElementWrapper(ByClassroomTestsLink);
            switch (TabName)
            {
                case ProfileHomeTabNames.ActiveTests:
                    ActiveTestsTab = new ProfileHomeTabDetail(TabName);
                    break;
                case ProfileHomeTabNames.BenchmarkTests:
                    BenchmarkTestsTab = new ProfileHomeTabDetail(TabName);
                    break;
                case ProfileHomeTabNames.ClassroomTests:
                    ClassroomTestsTab = new ProfileHomeTabDetail(TabName);
                    break;
            }
        }

        /// <summary>
        /// the data
        /// </summary>
        public TeacherProfileHomeData Data
        {
            get
            {
                return (TeacherProfileHomeData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// the tab name
        /// </summary>
        public ProfileHomeTabNames TabName { get; set; }


        protected new By ByFindTest { get { return By.Id(ControlPrefix + "ProfileControl_ButtonFindTest"); } }
        protected new WebElementWrapper FindTest { get; set; }
        private By ByCreateDropdown { get { return By.CssSelector("a.dropdown-toggle > i.icon-plus-sign"); } }
        private WebElementWrapper CreateDropdown { get; set; }
        private By ByFindDropdown { get { return By.CssSelector("a.dropdown-toggle > i.icon-search"); } }
        private WebElementWrapper FindDropdown { get; set; }

        protected By ByActiveTestsLink { get { return By.Id(ControlPrefix + "ProfileControl_ProfileTabControl1_RepeaterTabs_ctl00_LinkButtonTab"); } }
        protected WebElementWrapper ActiveTestsLink { get; set; }
        protected By ByBenchmarkTestsLink { get { return By.Id(ControlPrefix + "ProfileControl_ProfileTabControl1_RepeaterTabs_ctl01_LinkButtonTab"); } }
        protected WebElementWrapper BenchmarkTestsLink { get; set; }
        protected By ByClassroomTestsLink { get { return By.Id(ControlPrefix + "ProfileControl_ProfileTabControl1_RepeaterTabs_ctl02_LinkButtonTab"); } }
        protected WebElementWrapper ClassroomTestsLink { get; set; }

        /// <summary>
        /// active tests tab
        /// </summary>
        public ProfileHomeTabDetail ActiveTestsTab { get; set; }
        /// <summary>
        /// benchmark tests tab
        /// </summary>
        public ProfileHomeTabDetail BenchmarkTestsTab { get; set; }
        /// <summary>
        /// classroom tests tab
        /// </summary>
        public ProfileHomeTabDetail ClassroomTestsTab { get; set; }

        public TestCentralHomePage FindATest()
        {
            Find();
            FindTest.Wait(3).Click();
            return new TestCentralHomePage();
        }
        public ItemCentralHomePage FindAnItem()
        {
            Find();
            FindItem.Wait(3).Click();
            return new ItemCentralHomePage();
        }
        public CreateTestPortalPage CreateATest()
        {
            Create();
            CreateTest.Wait(3).Click();
            return new CreateTestPortalPage();
        }
        public EditTestItemChooseNewItemPage CreateAnItem()
        {
            Create();
            CreateItem.Wait(3).Click();
            return new EditTestItemChooseNewItemPage();
        }

        public void Create()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage();  //stop hover over menu
            CreateDropdown.Wait(3).Click();
            //pause the script for a second to let the pop-up display
            System.Threading.Thread.Sleep(1000);
        }
        public void Find()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            FindDropdown.Wait(3).Click();
            //pause the script for a second to let the pop-up display
            System.Threading.Thread.Sleep(1000);
        }

        /// <summary>
        /// select active tests tab
        /// </summary>
        public void SelectActiveTestsTab()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            ActiveTestsLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime();
            ((TeacherProfileHomePage)Parent).TabName = ProfileHomeTabNames.ActiveTests;
            ((TeacherProfileHomePage)Parent).InitElements();
        }
        /// <summary>
        /// select benchmark tests tab
        /// </summary>
        public void SelectBenchmarkTestsTab()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            BenchmarkTestsLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime();
            ((TeacherProfileHomePage)Parent).TabName = ProfileHomeTabNames.BenchmarkTests;
            ((TeacherProfileHomePage)Parent).InitElements();
        }
        /// <summary>
        /// select classroom tests tab
        /// </summary>
        public void SelectClassroomTestsTab()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            ClassroomTestsLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime();
            ((TeacherProfileHomePage)Parent).TabName = ProfileHomeTabNames.ClassroomTests;
            ((TeacherProfileHomePage)Parent).InitElements();
        }
    }
}
