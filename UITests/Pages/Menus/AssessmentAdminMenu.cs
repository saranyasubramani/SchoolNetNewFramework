using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Framework;
using Core.Views;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Assess.Dashboard;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestCentral;
using UITests.Pages.Assess.TestWindow;
using UITests.Pages.Assess.ItemCentral;
using UITests.Pages.Assess.TestCreateEdit;

namespace UITests.Pages.Menus
{
    /// <summary>
    /// assessment admin menu
    /// </summary>
    public class AssessmentAdminMenu : BaseApplication, IBaseComponentView
    {
        /// <summary>
        /// constructor
        /// </summary>
        public AssessmentAdminMenu()
            : base()
        {
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public void InitElements()
        {
            Dashboard = new WebElementWrapper(ByDashboard);
            Create = new WebElementWrapper(ByCreate);
            FindTest = new WebElementWrapper(ByFindTest);
            TestWindows = new WebElementWrapper(ByTestWindows);
            AssessmentAdmin = new WebElementWrapper(ByAssessmentAdmin);
            //hover over the assess admin menu
            if (this.TestConfiguration.BrowserName != BrowserType.SAFARI)
            {
                AssessmentAdmin.MoveToElement();
            }
        }

        /// <summary>
        /// the parent
        /// </summary>
        public IBaseComponentView Parent { get; set; }

        public By ByAssessmentAdmin { get { return By.CssSelector("a[href$='/assess/']"); } }
        public WebElementWrapper AssessmentAdmin { get; private set; }
        public By ByDashboard { get { return By.CssSelector("a[href^='/Assess/ProfileHome.aspx']"); } }
        public WebElementWrapper Dashboard { get; private set; }
        public By ByCreate { get { return By.CssSelector("a[href^='/Assess/CreateTestPortal.aspx']"); } }
        public WebElementWrapper Create { get; private set; }
        public By ByFindTest { get { return By.CssSelector("a[href^='/Assess/TestCentralHome.aspx']"); } }
        public WebElementWrapper FindTest { get; private set; }
        public By ByTestWindows { get { return By.CssSelector("a[href^='/Assess/PlanHome.aspx']"); } }
        public WebElementWrapper TestWindows { get; private set; }

        /// <summary>
        /// click on the assess admin menu to load the dashboard page
        /// we need this because hovering over the menu doesn't seem to work in a virtual machine
        /// </summary>
        /// <returns>ProfileHomePage</returns>
        public ProfileHomePage DashboardPage()
        {
            AssessmentAdmin.Click();
            return new ProfileHomePage();
        }
        /// <summary>
        /// click on the assess admin menu to load the teacher dashboard page
        /// we need this because hovering over the menu doesn't seem to work in a virtual machine
        /// </summary>
        /// <returns>TeacherProfileHomePage</returns>
        public TeacherProfileHomePage DashboardTeacherPage()
        {
            AssessmentAdmin.Click();
            return new TeacherProfileHomePage();
        }
        /// <summary>
        /// hover over the assess admin menu, then click on the dashboard submenu
        /// </summary>
        /// <returns>ProfileHomePage</returns>
        public ProfileHomePage DashboardMenu()
        {
            Dashboard.Wait().Click();
            //still working on this...
            //AssessmentAdmin.MouseOverAndClick(Dashboard);
            return new ProfileHomePage();
        }
        /// <summary>
        /// hover over the assess admin menu, then click on the create menu submenu
        /// </summary>
        /// <returns>CreateTestPortalPage</returns>
        public CreateTestPortalPage CreateMenu()
        {
            Create.Wait().Click();
            //still working on this...
            //AssessmentAdmin.MouseOverAndClick(Create);
            return new CreateTestPortalPage();
        }
        /// <summary>
        /// hover over the assess admin menu, then click on the find a test submenu
        /// </summary>
        /// <returns>TestCentralHomePage</returns>
        public TestCentralHomePage FindATest()
        {
            FindTest.Wait().Click();
            //still working on this...
            //AssessmentAdmin.MouseOverAndClick(FindTest);
            return new TestCentralHomePage();
        }
        /// <summary>
        /// hover over the assess admin menu, then click on the manage test windows submenu
        /// </summary>
        /// <returns>PlanHomePage</returns>
        public PlanHomePage ManageTestWindows()
        {
            //TestWindows.Wait(5).Click();
            //still working on this...
            //AssessmentAdmin.MouseOverAndClick(FindTest);

            //for now just navigate to the url:
            Driver.Navigate().GoToUrl(this.TestConfiguration.ApplicationPath + "/" + "Assess/PlanHome.aspx");
            return new PlanHomePage();
        }
        /// <summary>
        /// find an item
        /// </summary>
        /// <returns>ItemCentralHomePage</returns>
        public ItemCentralHomePage FindAnItem()
        {
            //still working on this...
            //AssessmentAdmin.MouseOverAndClick(FindTest);

            //for now just navigate to the url:
            Driver.Navigate().GoToUrl(this.TestConfiguration.ApplicationPath + "/" + "Assess/ItemCentralHome.aspx");
            return new ItemCentralHomePage();
        }
    }
}
