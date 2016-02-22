using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Menus;
using UITests.Pages.Admin;
using UITests.Pages.Assess.Dashboard;
using UITests.Pages.SchoolAndDistrict.Dashboard;
using UITests.Pages.Components;

namespace UITests.Pages
{
    public class SNHeader : Header
    {
        public SNHeader() : base()
        {
            DriverCommands = new SNDriverCommands();
            Utilities = new SNGlobalUtilities();
            InitElements();
        }

        protected new SNDriverCommands DriverCommands { get; set; }
        protected SNGlobalUtilities Utilities { get; set; }

        public new SNWebPage Parent { get; set; }

        public override void InitElements()
        {
            ControlPrefix = "ctl00_AppHeader_";
            WelcomeMessage = new WebElementWrapper(ByWelcomeMessage);
            SignOut = new WebElementWrapper(BySignOut);
            MyAccount = new WebElementWrapper(ByMyAccount);
            Help = new WebElementWrapper(ByHelp);
            SearchField = new WebElementWrapper(BySearchField);
            SearchButton = new WebElementWrapper(BySearchButton);
            UserManagementLink = new WebElementWrapper(ByUserManagementLink);
            SystemLink = new WebElementWrapper(BySystemLink);
        }

        public By ByWelcomeMessage { get { return By.Id("Username"); } }
        public WebElementWrapper WelcomeMessage { get; set; }
        //public By BySignOut { get { return By.CssSelector("a[href^='/Authentication.aspx?mode=logout']"); } }
        public By BySignOut { get { return By.Id(ControlPrefix + "UserStatus_linkLogout"); } }
        public WebElementWrapper SignOut { get; set; }
        public By ByMyAccount { get { return By.CssSelector("a[href^='/UserSettings.aspx']"); } }
        public WebElementWrapper MyAccount { get; set; }
        public By ByHelp { get { return By.CssSelector("a[href^='/HelpAndSupport.aspx']"); } }
        public WebElementWrapper Help { get; set; }

        public By BySearchField { get { return By.ClassName("ToolboxSearchField"); } }
        public WebElementWrapper SearchField { get; set; }
        public By BySearchButton { get { return By.CssSelector("#pnlQuickStudentSearch > div > button"); } }
        public WebElementWrapper SearchButton { get; set; }
        protected By ByFindStudentAutoCompleteLabel { get { return By.CssSelector("div.ac_results > ul > li > span.ac_result"); } }
        protected WebElementWrapper FindStudentAutoCompleteLabel { get; private set; }

        public By ByUserManagementLink { get { return By.CssSelector("#AdminNav a[href*='/directory/']"); } }
        public WebElementWrapper UserManagementLink { get; set; }
        public By BySystemLink { get { return By.CssSelector("#AdminNav a[href*='/admin/']"); } }
        public WebElementWrapper SystemLink { get; set; }

        /// <summary>
        /// click on welcome message, to stop hover over menu
        /// </summary>
        public void SelectWelcomeMessage()
        {
            try
            {
                WelcomeMessage.Wait(3).Click();
            }
            catch (Exception e)
            {
                throw new Exception("\nInnerException:\n" + e.InnerException + "\nStackTrace:\n" + e.StackTrace, e);
            }

        }
        /// <summary>
        /// logout
        /// </summary>
        public void Logout()
        {
            SignOut.Wait(5).Click();
            DriverCommands.WaitAndMeasurePageLoadTime();
        }
        /// <summary>
        /// find a student
        /// </summary>
        public void FindAStudent()
        {
            //TODO: need data object
            //SearchField.SendKeys("");
            SearchField.SendKeys(Data.ToString());
            SearchButton.Click();
        }

        /// <summary>
        /// find a student and click on the auto pop with the student found
        /// </summary>
        public void FindAStudentUsingAutoPopup()
        {
            SearchField.SendKeys(Data.ToString());
            FindStudentAutoCompleteLabel = new WebElementWrapper(ByFindStudentAutoCompleteLabel);
            string studentInfo = FindStudentAutoCompleteLabel.WaitUntilVisible(10).GetAttribute("title");
            if (studentInfo.Contains(Data.ToString()))
            {
                FindStudentAutoCompleteLabel.WaitUntilVisible(10).Click();
            }
        }

        /// <summary>
        /// select user management link
        /// </summary>
        public void SelectUserManagement()
        {
            UserManagementLink.Wait(5).Click();
        }
        /// <summary>
        /// select system link
        /// </summary>
        /// <returns>SystemOperationPage</returns>
        public SystemOperationPage SelectSystem()
        {
            SystemLink.Wait(5).Click();
            return new SystemOperationPage();
        }
        /// <summary>
        /// hover over the assess admin menu
        /// </summary>
        /// <returns>AssessmentAdminMenu</returns>
        public AssessmentAdminMenu AssessmentAdminMenu()
        {
            return new AssessmentAdminMenu();
        }
        /// <summary>
        /// click on the assess admin menu to load the dashboard page
        /// </summary>
        /// <returns>ProfileHomePage</returns>
        public ProfileHomePage AssessmentAdminPage()
        {
            //dashboard page should always return the AssessDashboardPage
            return new AssessmentAdminMenu().DashboardPage();
            //return new AssessDashboardPage(Driver);
        }
        /// <summary>
        /// click on the assess admin menu to load the teacher dashboard page
        /// </summary>
        /// <returns>TeacherProfileHomePage</returns>
        public TeacherProfileHomePage AssessmentAdminTeacherPage()
        {
            //dashboard page should always return the AssessDashboardPage
            return new AssessmentAdminMenu().DashboardTeacherPage();
            //return new AssessDashboardPage(Driver);
        }
        /// <summary>
        /// hover over the School District menu
        /// </summary>
        /// <returns>SchoolDistrictDashBoardPage</returns>
        public DashBoardPage SchoolDistrictMenu()
        {
            //dashboard page 
            return new SchoolDistrictMenu().DashboardPage();
        }
    }
}
