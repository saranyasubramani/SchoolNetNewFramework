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
    /// KPI Dashboard SchoolDistrictData KPI Key detail
    /// </summary> 
    public class KeyKPIDashboardTabDetail : SNDetail
    {
        /// <summary>
        /// constructor
        /// </summary>
        public KeyKPIDashboardTabDetail()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            // KPI Tables - Grade-Stud Subgroups-Region
            KpiTables = new WebElementWrapper( byKpiTables);
            KpiTableheader = new WebElementWrapper( byKpiTables);
            KpiDataTable = new WebElementWrapper( byKpiTables);
            KpiDataTableColheader = new WebElementWrapper( byKpiTables);
            KpiData_NestTable = new WebElementWrapper( byKpiTables);
            KpiDataTablerow = new WebElementWrapper( byKpiTables);
            KpiDataNestTableCol = new WebElementWrapper( byKpiTables);

            // KPI Tables - Related Items
            Kpirelatedtables = new WebElementWrapper( byKpiTables);
            KpirelatedDataheader = new WebElementWrapper( byKpiTables);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new KeyKPIDashboardTabData Data
        {
            get
            {
                return (KeyKPIDashboardTabData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        //Grade-StudentSubGroups-Regions
        public By byKpiTables = By.CssSelector(".span4>div");
        public By byKpiTableheader = By.CssSelector(".ScoreCardLabel>h5");
        public By byKpiDataTable = By.XPath("//table[@class='DataGridTable']");
        public By byKpiDataTableColheader = By.CssSelector("tr.DataGridHeader >th");
        public By byKpiData_NestTable = By.CssSelector(".KPIDetailScoreCardViewPort>table>tbody");
        public By byKpiDataTablerow = By.CssSelector(".DataGridRow");
        public By byKpiDataNestTableCol = By.CssSelector(".DataGridRow.DataGridHighlightRow>td>span>span");
        //Related Items Tables
        public By byKpirelatedtables = By.CssSelector(".span4.noPrint>div");
        public By byKpirelatedDataheader = By.XPath("//div[contains(@class,'Accordian')]");
        // KPI Tables - Grade-Stud Subgroups-Region
        public WebElementWrapper KpiTables { get; set; }
        public WebElementWrapper KpiTableheader { get; set; }
        public WebElementWrapper KpiDataTable { get; set; }
        public WebElementWrapper KpiDataTableColheader { get; set; }
        public WebElementWrapper KpiData_NestTable { get; set; }
        public WebElementWrapper KpiDataTablerow { get; set; }
        public WebElementWrapper KpiDataNestTableCol { get; set; }
        // KPI Tables - Related Items
        public WebElementWrapper Kpirelatedtables { get; set; }
        public WebElementWrapper KpirelatedDataheader { get; set; }


    }
}
