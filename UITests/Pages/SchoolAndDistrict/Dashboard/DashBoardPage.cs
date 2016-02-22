using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.SchoolAndDistrict.Dashboard.Components;
using UITests.Pages.SchoolAndDistrict.Dashboard.KPI;

namespace UITests.Pages.SchoolAndDistrict.Dashboard
{
    /// <summary>
    /// the SchoolDistrict dashboard page 
    /// </summary>
    public class DashBoardPage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public DashBoardPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Account/Dashboard.aspx";
            this.VerifyCurrentUrl();
            this.tabInFocus = DashboardTabs.KPIDashboard;
            InitElements();
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="tabInFocus">the current tab in focus</param>
        public DashBoardPage(DashboardTabs tabInFocus)
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Account/Dashboard.aspx";
            this.VerifyCurrentUrl();
            this.tabInFocus = tabInFocus;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            switch (this.tabInFocus)
            {
                case DashboardTabs.KPIDashboard:
                    this.Tab = new KPIDashboardTab();
                    this.Tabs.Add(DashboardTabs.KPIDashboard, this.Tab);
                    break;
                case DashboardTabs.KeyKPIDashboard:
                    this.Tab = new KeyKPIDashboardTab();
                    this.Tabs.Add(DashboardTabs.KeyKPIDashboard, this.Tab);
                    break;
                case DashboardTabs.BenchmarkTests:
                    break;
                case DashboardTabs.ReportBank:
                    break;
                default:
                    this.Tab = new KPIDashboardTab();
                    this.Tabs.Add(DashboardTabs.KPIDashboard, this.Tab);
                    break;
            }
            KPITab = new WebElementWrapper( byKPITab);
        }
        /// <summary>
        /// the tabs
        /// </summary>
        public new Dictionary<object, Tab> Tabs { get; private set; }
        private DashboardTabs tabInFocus;

        /// <summary>
        /// the data
        /// </summary>
        public new DashboardData Data
        {
            get
            {
                return (DashboardData)base.Data;
            }
            set
            {
                base.Data = value;
                DashboardData data = (DashboardData)value;
                KPIDashboardTab kpiDashboard = 
                    (KPIDashboardTab)this.Tabs[DashboardTabs.KPIDashboard];
                kpiDashboard.Data = data.SchoolDistrictKPIDashboardTabData;
                KeyKPIDashboardTab keyKPIDashboard =
                    (KeyKPIDashboardTab)this.Tabs[DashboardTabs.KeyKPIDashboard];
                keyKPIDashboard.Data = data.SchoolDistrictKeyKPIDashboardTabData;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new DashboardData InitData()
        {
            base.InitData(new DashboardData());
            return (DashboardData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public DashboardData InitData(object data)
        {
            base.InitData(data);
            return (DashboardData)base.Data;
        }

        public By byKPITab = By.Id("ctl00_MainContent_ProfileTabControl1_RepeaterTabs_ctl00_HyperLinkTab");
        public WebElementWrapper KPITab { get; set; }

        /// <summary>
        /// KPI Dashboard tab
        /// </summary>
        /// <returns>SchoolDistrictKPIDashboardTab</returns>
        public KPIDashboardTab clickKPITab()
        {
            KPITab.Click();
            this.Tab = new KPIDashboardTab();
            return (KPIDashboardTab)this.Tab;
        }
    }
}
