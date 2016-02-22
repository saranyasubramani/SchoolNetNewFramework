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
    /// the SchoolDistrict Configure Goal Modal Dialog form
    /// </summary>
    public class KPIGoalsConfigureForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        public KPIGoalsConfigureForm()
            : base()
        {
            Driver.SwitchTo().Frame("lightBoxFrame");
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            configFrame = new WebElementWrapper(byconfigFrame);
            NorthRegApply = new WebElementWrapper( byNorthRegApply);
            SouthRegApply = new WebElementWrapper( bySouthRegApply);
            SpecRegApply = new WebElementWrapper( bySpecRegApply);
            NorthRegExpand = new WebElementWrapper( byNorthRegExpand);
            SouthRegExpand = new WebElementWrapper( bySouthRegExpand);
            SpecRegExpand = new WebElementWrapper( bySpecRegExpand);
            NorthRegText = new WebElementWrapper( byNorthRegText);
            SouthRegText = new WebElementWrapper( bySouthRegText);
            SpecRegText = new WebElementWrapper( bySpecRegText);
        }

        //Config Goal Frame
        public By byconfigFrame = By.CssSelector("iframe#lightBoxFrame");
        public WebElementWrapper configFrame { get; set; }
        //Each Region Apply CheckBox
        public string ControlPrefix = "input#region_goal_checkbox_";
        public By byNorthRegApply { get { return By.CssSelector(ControlPrefix + "1295"); } }
        public WebElementWrapper NorthRegApply { get; set; }
        public By bySouthRegApply { get { return By.CssSelector(ControlPrefix + "1294"); } }
        public WebElementWrapper SouthRegApply { get; set; }
        public By bySpecRegApply { get { return By.CssSelector(ControlPrefix + "1297"); } }
        public WebElementWrapper SpecRegApply { get; set; }
        //Each Region Expand 
        public By byNorthRegExpand = By.CssSelector("img[related_div='#div0']");
        public WebElementWrapper NorthRegExpand { get; set; }
        public By bySouthRegExpand = By.CssSelector("img[related_div='#div1']");
        public WebElementWrapper SouthRegExpand { get; set; }
        public By bySpecRegExpand = By.CssSelector("img[related_div='#div2']");
        public WebElementWrapper SpecRegExpand { get; set; }
        //Each Region TextBox 
        public string ControlPrefix2 = "input#school_goal_";
        public By byNorthRegText { get { return By.CssSelector(ControlPrefix2 + "1295"); } }
        public WebElementWrapper NorthRegText { get; set; }
        public By bySouthRegText { get { return By.CssSelector(ControlPrefix2 + "1294"); } }
        public WebElementWrapper SouthRegText { get; set; }
        public By bySpecRegText { get { return By.CssSelector(ControlPrefix2 + "1297"); } }
        public WebElementWrapper SpecRegText { get; set; }
        //Command Buttons
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.CssSelector("#ctl00_MainContent_ConfigureKPIGoals1_LinkButtonSaveGoals"); } }
        /// <summary>
        /// cancel by
        /// </summary>
        public override By ByCancel { get { return By.CssSelector("#ctl00_MainContent_ConfigureKPIGoals1_LinkButtonCancelGoals"); } }

        /// <summary>
        /// verify KPI dialog fields exist
        /// </summary>
        /// <param name="region_name">region name</param>
        /// <returns>true or false</returns>
        public bool VerifyKPIDialogFieldsExist(String region_name)
        {
            bool fieldexist = false;
            switch (region_name)
            {
                case "North":
                    if (NorthRegApply.Displayed && NorthRegExpand.Displayed && NorthRegText.Displayed)
                    {
                        fieldexist = true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "South":
                    if (SouthRegApply.Displayed && SouthRegExpand.Displayed && SouthRegText.Displayed)
                    {
                        fieldexist = true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "Special":
                    if (SpecRegApply.Displayed && SpecRegExpand.Displayed && SpecRegText.Displayed)
                    {
                        fieldexist = true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
            }
            if (this.Submit.Wait(5).Displayed && this.Cancel.Wait(5).Displayed)
            {
                fieldexist = true;
            }
            else
            {
                return false;
            }
            return fieldexist;
        }
        /// <summary>
        /// set KPI value region to schools level
        /// </summary>
        /// <param name="region">region</param>
        /// <param name="val">value</param>
        public void setKPIValue_RegiontoSchoolslevel(String region, String val)
        {
            switch (region)
            {
                case "North":
                    NorthRegText.Clear();
                    NorthRegText.SendKeys(val);
                    NorthRegApply.Click();
                    break;
                case "South":
                    SouthRegText.SendKeys(val);
                    SouthRegApply.Click();
                    break;
                case "Special":
                    SpecRegText.SendKeys(val);
                    SpecRegApply.Click();
                    break;
            }
        }
        /// <summary>
        /// set KPI value region level
        /// </summary>
        /// <param name="region">region</param>
        /// <param name="val">value</param>
        public void setKPIValue_Regionlevel(String region, String val)
        {
            switch (region)
            {
                case "North":
                    NorthRegText.Clear();
                    NorthRegText.SendKeys(val);
                    break;
                case "South":
                    SouthRegText.Clear();
                    SouthRegText.SendKeys(val);
                    break;
                case "Special":
                    SpecRegText.Clear();
                    SpecRegText.SendKeys(val);
                    break;
            }
        }
        /// <summary>
        /// select region
        /// </summary>
        /// <param name="region_name">region name</param>
        public void selectRegion(string region_name)
        {
            switch (region_name)
            {
                case "North":
                    NorthRegExpand.Click();
                    break;
                case "South":
                    SouthRegExpand.Click();
                    break;
                case "Special":
                    SpecRegExpand.Click();
                    break;
            }
        }
    }
}
