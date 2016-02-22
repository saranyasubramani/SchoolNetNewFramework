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
    /// KPI Dashboard SchoolDistrictData KPI Key Form
    /// </summary> 
    public class KeyKPIDashboardTabForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        public KeyKPIDashboardTabForm()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            KPIName = new WebElementWrapper( byKPIName);
            imgLink = new WebElementWrapper( byimgLink);
            kpilist = new WebElementWrapper( bykpilist);
            kpilistheader = new WebElementWrapper( bykpilistheader);
            ListItem = new WebElementWrapper( byListItem);
            ConfigLink = new WebElementWrapper( byConfigLink);
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

        //Configure Link Under the Related Items
        public By byconfigGoal = By.Id("lnkKpiGoalsModal");
        //Selected KPI Display
        public By byKPIName = By.CssSelector("#KpiName");
        public By byimgLink = By.CssSelector("#KpiName>img");
        public By bykpilist = By.CssSelector("#KpiList");
        public By bykpilistheader = By.CssSelector("#KpiList>strong");
        public By byListItem = By.CssSelector(".KpiListItem");
        public By byConfigLink = By.CssSelector("#lnkKpiGoalsModal");
        public WebElementWrapper KPIName { get; set; }
        public WebElementWrapper imgLink { get; set; }
        public WebElementWrapper kpilist { get; set; }
        public WebElementWrapper kpilistheader { get; set; }
        public WebElementWrapper ListItem { get; set; }
        public WebElementWrapper ConfigLink { get; set; }

        /// <summary>
        /// config link click
        /// </summary>
        /// <returns>KPIGoalsConfigure</returns>
        public KPIGoalsConfigure ConfigLinkClick()
        {
            if (ConfigLink.Displayed)
            {
                ConfigLink.Click();
                return new KPIGoalsConfigure();
            }
            return null;
        }
    }
}
