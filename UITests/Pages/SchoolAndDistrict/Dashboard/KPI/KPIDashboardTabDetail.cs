using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.SchoolAndDistrict.Dashboard.KPI
{
    /// <summary>
    /// the SchoolDistrict KPI dashboard detail
    /// </summary>
    public class KPIDashboardTabDetail : SNDetail
    {
        /// <summary>
        /// constructor
        /// </summary>
        public KPIDashboardTabDetail() : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            SectionHeading = new WebElementWrapper( bySectionHeading);
            StudKPIDailyAttendance = new WebElementWrapper( byStudKPIDailyAttendance);
            DistrictWideKPIELA = new WebElementWrapper( byDistrictWideKPIELA); 
        }

        /// <summary>
        /// the data
        /// </summary>
        public new KPIDashboardTabData Data
        {
            get
            {
                return (KPIDashboardTabData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        public By bySectionHeading { get { return By.CssSelector(".section_container.space4"); } }
        public WebElementWrapper SectionHeading { get; set; }
        public By byStudKPIDailyAttendance { get { return By.XPath(("//div[contains(@onclick,'kpi_key=31')]")); } }
        //public By byStudKPIDailyAttendance { get { return By.CssSelector("div.KpiCell[onclick*='kpi_key=31']");}}
        public WebElementWrapper StudKPIDailyAttendance { get; set; }
        public By byDistrictWideKPIELA { get { return By.CssSelector("div.KpiCell[onclick*='kpi_key=8']"); } }
        public WebElementWrapper DistrictWideKPIELA { get; set; }
        private KeyKPIDashboardTab KeyKPIDashboardTab; 

        // <summary>
        /// click on Student Attendance and Enrollment KpiName
        /// </summary>
        public KeyKPIDashboardTab StudAttendEnrollment_DailyAttendance()
        {
            StudKPIDailyAttendance.InitializeWebElement();
            StudKPIDailyAttendance.WaitUntilExists();
            if (StudKPIDailyAttendance.Displayed)
            {
                StudKPIDailyAttendance.Click();
            }
            KeyKPIDashboardTab = new KeyKPIDashboardTab();
            return KeyKPIDashboardTab;
        }

        // <summary>
        /// click on District - Wide KPI Name
        /// </summary>
        public KeyKPIDashboardTab DistrictWide()
        {
            DistrictWideKPIELA.WaitUntilExists();
            DistrictWideKPIELA.InitializeWebElement();
            if (DistrictWideKPIELA.Displayed)
            {
                DistrictWideKPIELA.Click();
            }
            KeyKPIDashboardTab = new KeyKPIDashboardTab();
            return KeyKPIDashboardTab;
        }
    }
}
