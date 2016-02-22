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
    /// the SchoolDistrict KPI dashboard form
    /// </summary>
    public class KPIDashboardTabForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        public KPIDashboardTabForm()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            TextSchoolTeacherSection = new WebElementWrapper(ByTextSchoolTeacherSection);
            RegionMenu = new WebElementWrapper( ByRegionMenu);
            NorthRegionName = new WebElementWrapper( ByNorthRegionName);
            SouthRegionName = new WebElementWrapper( BySouthRegionName);
            SpecialRegionName = new WebElementWrapper( BySpecialRegionName);
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

        public By ByTextSchoolTeacherSection { get { return By.Id(ControlPrefix + "ctl00_ProfileNavigator_AutoComplete1"); } }
        public WebElementWrapper TextSchoolTeacherSection { get; private set; }
        public By ByRegionMenu = By.CssSelector(".bc_menu:nth-of-type(2)>img");
        public WebElementWrapper RegionMenu { get; set; }
        public By ByNorthRegionName { get { return By.XPath(("//li[contains(@onclick,'institution_id=1295')]")); } }
        public WebElementWrapper NorthRegionName { get; set; }
        public By BySouthRegionName { get { return By.XPath(("//li[contains(@onclick,'institution_id=1294')]")); } }
        public WebElementWrapper SouthRegionName { get; set; }
        public By BySpecialRegionName { get { return By.XPath(("//li[contains(@onclick,'institution_id=1297')]")); } }
        public WebElementWrapper SpecialRegionName { get; set; }

        /// <summary>
        /// select region
        /// </summary>
        /// <param name="region">the region</param>
        public void selectRegion(String region)
        {
            regionMenu_Click();
            switch (region)
            {
                case "North":
                    NorthRegionName.InitializeWebElement();
                    NorthRegionName.WaitUntilExists();
                    if (NorthRegionName.Displayed)
                    {
                        NorthRegionName.Click();
                    }
                    break;
                case "South":
                    SouthRegionName.InitializeWebElement();
                    SouthRegionName.WaitUntilExists();
                    if (SouthRegionName.Displayed)
                    {
                        SouthRegionName.Click();
                    }
                    break;
                case "Special":
                    SpecialRegionName.InitializeWebElement();
                    SpecialRegionName.WaitUntilExists();
                    if (SpecialRegionName.Displayed)
                    {
                        SpecialRegionName.Click();
                    }
                    break;
            }

        }
        /// <summary>
        /// region menu
        /// </summary>
        public void regionMenu_Click()
        {
            RegionMenu.InitializeWebElement();
            RegionMenu.WaitUntilExists();

            if (RegionMenu.Displayed)
            {
                RegionMenu.Click();
            }
        }
        /// <summary>
        /// verify fields are empty
        /// </summary>
        /// <param name="child_ele">child elements</param>
        public void VerifyFieldsAreEmpty(IReadOnlyCollection<IWebElement> child_ele)
        {
            foreach (IWebElement e in child_ele)
            {
                if (string.IsNullOrEmpty(e.Text) == true)
                {
                    Console.WriteLine("KPI Name is empty");
                }
            }
        }
    }
}
