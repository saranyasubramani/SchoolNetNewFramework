using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Framework;
using Core.Views;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.SchoolAndDistrict.Dashboard;

namespace UITests.Pages.Menus
{
    public class SchoolDistrictMenu : BaseApplication, IBaseComponentView
    {
        public SchoolDistrictMenu()
            : base()
        {
            InitElements();
        }
        public void InitElements()
        {
            Dashboard = new WebElementWrapper(ByDashboard);
            Benchmark = new WebElementWrapper(ByBenchmark);
            ReportBank = new WebElementWrapper(ByReportBank);
            SchoolDistrict = new WebElementWrapper(BySchoolDistrict);
            //hover over the assess admin menu
            SchoolDistrict.MoveToElement();
        }

        public IBaseComponentView Parent { get; set; }

        public By BySchoolDistrict { get { return By.CssSelector("a[href$='/account/']"); } }
        public WebElementWrapper SchoolDistrict { get; private set; }
        public By ByDashboard { get { return By.CssSelector("a[href^='/Account/Dashboard.aspx']"); } }
        public WebElementWrapper Dashboard { get; private set; }
        public By ByBenchmark { get { return By.CssSelector("a[href^='/Account/Dashboard.aspx?tab=BenchmarkDashboard']"); } }
        public WebElementWrapper Benchmark { get; private set; }
        public By ByReportBank { get { return By.CssSelector("a[href^='/Account/Dashboard.aspx?tab=ReportBank']"); } }
        public WebElementWrapper ReportBank { get; private set; }

        /// <summary>
        /// click on the School District menu to load the dashboard page        
        /// </summary>
        /// <returns>SchoolDistrictDashboardPage</returns>
        public DashBoardPage DashboardPage()
        {
            SchoolDistrict.Click();
            return new DashBoardPage();
        }

    }
}
