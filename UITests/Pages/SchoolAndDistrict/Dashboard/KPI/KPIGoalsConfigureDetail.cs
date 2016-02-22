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
    /// KPI Dashboard SchoolDistrict Configure Goal Dialog Detail Definition
    /// </summary>
    public class KPIGoalsConfigureDetail : SNDetail
    {
        /// <summary>
        /// constructor
        /// </summary>
        public KPIGoalsConfigureDetail()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.ControlPrefix = "ctl00_MainContent_ConfigureKPIGoals1_RepeaterRegions_";
            NorthRegionSchools = new WebElementWrapper( byNorthRegionSchool);
            SouthRegionSchools = new WebElementWrapper( bySouthRegionSchool);
            SpecRegionSchools = new WebElementWrapper( bySpecRegionSchool);
            NorthregionTable = new WebElementWrapper( byNorthregionTable);
            SouthregionTable = new WebElementWrapper( bySouthregionTable);
            SpecregionTable = new WebElementWrapper( bySpecregionTable);
        }

        public By byNorthRegionSchool { get { return By.Id(ControlPrefix + "ctl00_DataList1"); } }
        public WebElementWrapper NorthRegionSchools { get; set; }
        public By bySouthRegionSchool { get { return By.Id(ControlPrefix + "ctl02_DataList1"); } }
        public WebElementWrapper SouthRegionSchools { get; set; }
        public By bySpecRegionSchool { get { return By.Id(ControlPrefix + "ctl04_DataList1"); } }
        public WebElementWrapper SpecRegionSchools { get; set; }
        public By byNorthregionTable = By.CssSelector("table#ctl00_MainContent_ConfigureKPIGoals1_RepeaterRegions_ctl00_DataList1");
        public WebElementWrapper NorthregionTable { get; set; }
        public By bySouthregionTable = By.CssSelector("table#ctl00_MainContent_ConfigureKPIGoals1_RepeaterRegions_ctl02_DataList1");
        public WebElementWrapper SouthregionTable { get; set; }
        public By bySpecregionTable = By.CssSelector("table#ctl00_MainContent_ConfigureKPIGoals1_RepeaterRegions_ctl04_DataList1");
        public WebElementWrapper SpecregionTable { get; set; }

        /// <summary>
        /// get region data row
        /// </summary>
        /// <param name="region_name">region name</param>
        /// <returns>List<IWebElement></returns>
        public List<IWebElement> GetRegionDataRow(string region_name)
        {
            List<IWebElement> totalRow = null;
            switch (region_name)
            {
                case "North":
                    totalRow = NorthregionTable.FindElements(By.CssSelector("tbody>tr")).ToList();
                    break;
                case "South":
                    totalRow = SouthregionTable.FindElements(By.CssSelector("tbody>tr")).ToList();
                    break;
                case "Special":
                    totalRow = SpecregionTable.FindElements(By.CssSelector("tbody>tr")).ToList();
                    break;
            }
            return totalRow;
        }
        /// <summary>
        /// validate region school KPI
        /// </summary>
        /// <param name="region_name">region name</param>
        /// <returns>true or false</returns>
        public bool validateRegionSchoolKpi(String region_name)
        {
            List<IWebElement> totalrow = GetRegionDataRow(region_name);
            bool schoolKpi = validateSchool_KpiValDisplay(totalrow);
            return schoolKpi;
        }
        /// <summary>
        /// KPI value school level
        /// </summary>
        /// <param name="region_name">region name</param>
        /// <param name="regKPI">reg KPI</param>
        public void KPIValue_Schoollevel(String region_name, int regKPI)
        {
            List<IWebElement> totalrow = GetRegionDataRow(region_name);
            setKPIValue_Schoollevel(totalrow, regKPI);
        }
        /// <summary>
        /// set KIP value school level
        /// </summary>
        /// <param name="childRow">child row</param>
        /// <param name="regKPI">reg KPI</param>
        private void setKPIValue_Schoollevel(List<IWebElement> childRow, int regKPI)
        {
            int kpivalue = regKPI + 15;
            foreach (IWebElement ele in childRow)
            {
                List<IWebElement> totalCol = null;
                totalCol = ele.FindElements(By.CssSelector("td")).ToList();
                foreach (IWebElement kpiele in totalCol)
                {
                    String val = kpivalue.ToString();
                    kpiele.FindElement(By.CssSelector("div>input[id^='school_goal']")).Clear();
                    kpiele.FindElement(By.CssSelector("div>input[id^='school_goal']")).SendKeys(val);
                    kpivalue = kpivalue + 15;
                }
            }
        }
        /// <summary>
        /// validate school KPI value display
        /// </summary>
        /// <param name="childRow">child row</param>
        /// <returns>true or false</returns>
        private bool validateSchool_KpiValDisplay(List<IWebElement> childRow)
        {
            bool schoolKpi = false;
            foreach (IWebElement ele in childRow)
            {
                List<IWebElement> totalCol = null;
                totalCol = ele.FindElements(By.CssSelector("td")).ToList();
                foreach (IWebElement kpiele in totalCol)
                {
                    if ((kpiele.FindElement(By.CssSelector("div>p")).Displayed) &&
                     (kpiele.FindElement(By.CssSelector("div>input[id^='school_goal']")).Displayed))
                    {
                        schoolKpi = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return schoolKpi;
        }
        /// <summary>
        /// validate school KPI value match
        /// </summary>
        /// <param name="region_name">region name</param>
        /// <param name="val">value</param>
        /// <returns>true or false</returns>
        public bool ValidateSchool_KpiValueMatch(String region_name, String val)
        {
            bool schoolKpi = false;
            List<IWebElement> childRow = GetRegionDataRow(region_name);
            foreach (IWebElement ele in childRow)
            {
                List<IWebElement> totalCol = null;
                String kpiValue;
                totalCol = ele.FindElements(By.CssSelector("td")).ToList();
                foreach (IWebElement kpiele in totalCol)
                {
                    kpiValue = kpiele.FindElement(By.CssSelector("div>input[id^='school_goal']")).GetAttribute("value").ToString();
                    if (String.Equals(val, kpiValue))
                    {
                        schoolKpi = true;
                    }
                    else
                    {
                        return (false);
                    }
                }

            }
            return schoolKpi;
        }
        /// <summary>
        /// validate school KPI value
        /// </summary>
        /// <param name="region_name">region name</param>
        /// <param name="val">value</param>
        /// <returns></returns>
        public bool ValidateSchool_KpiValue(String region_name, String val)
        {
            bool schoolKpi = false;
            List<IWebElement> childRow = GetRegionDataRow(region_name);
            foreach (IWebElement ele in childRow)
            {
                List<IWebElement> totalCol = null;
                String kpiValue;
                totalCol = ele.FindElements(By.CssSelector("td")).ToList();
                foreach (IWebElement kpiele in totalCol)
                {
                    kpiValue = kpiele.FindElement(By.CssSelector("div>input[id^='school_goal']")).GetAttribute("value").ToString();

                    if (!String.Equals(val, kpiValue))
                    {
                        schoolKpi = true;
                    }
                    else
                    {
                        return (false);
                    }
                }

            }
            return schoolKpi;
        }
    }
}
