using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Assess.Components;

namespace UITests.Pages.Assess.TestDetail.ViewTestDetails
{
    /// <summary>
    /// represents the test detail - test content line item row.
    /// </summary>
    public class TestContentLineItem : ContentLineItem
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="webElement">IWebElement</param>
        /// <param name="itemid">the item ID</param>
        /// <param name="index">the index</param>
        /// <param name="uniqueId">the unique ID</param>
        /// <param name="label">the label</param>
        /// <param name="testContentLineItemState">test content line item state - defaults to minimized</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public TestContentLineItem(  IWebElement webElement, int itemid, int index, string uniqueId, string label,
            //ItemType itemType,
            TestContentLineItemState testContentLineItemState = TestContentLineItemState.Minimized, string overrideControlPrefix = null)
            : base( webElement, itemid, index, uniqueId, label, overrideControlPrefix)
        {
        }

        protected override By ByItemContent { get { return By.Id("contentDiv_" + ItemId); } }
        //ShowHideAll(this,'256338', 'false');return false;
        protected override By ByMoreLessLink { get { return By.CssSelector("a[onclick*='ShowHideAll(this, '" + Index + "']"); } }
        //CSS selector does not work, so I have to use XPath, need to have Dev fix this
        //private By ByActionsLink { get { return By.CssSelector("div[ng-app='testitem'] > table.DataGridTable > tbody > tr:nth-of-type(" + (Index + 1) + ") .dropdown-toggle"); } }
        protected override By ByActionsLink { get { return By.XPath("//tr[@class='DataGridRow'][" + (Index + 1) + "]/td/div[@class='btn-group']/a[@class='btn dropdown-toggle']"); } }
        protected override By ByViewLink { get { return By.Id(ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_ButtonItemDetails"); } }
        //protected override By ByEditLink { get { return By.Id(ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_ButtonEditItem"); } }
        protected override By ByEditLink { get { return By.Id(ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_LinkEditItem"); } }
        protected override By ByReplaceLink { get { return By.Id(ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_ButtonReplaceItem"); } }
        protected override By ByRemoveFromTestLink { get { return By.Id(ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_ButtonDeleteItem"); } }
        protected override By ByTimerOffLink { get { return By.Id(ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_ButtonItemDetails"); } }
        protected override By ByCorrectAnswerLabel { get { return By.CssSelector("tr#" + ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_MetadaInfo_Tr1 + tr > td.itemmetadata"); } }
        protected override By ByPointValueLabel { get { return By.CssSelector("tr#" + ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_MetadaInfo_Tr1 + tr + tr + tr > td.itemmetadata"); } }
        protected override By ByStandardIdLabel { get { return By.CssSelector("tr#" + ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_MetadaInfo_Tr2 + tr > td.itemmetadata"); } }
        //("#ctl00_MainContent_RepeaterTestItems_ctl01_ViewTestItems1_MetadaInfo_Tr2 + tr + tr + tr + tr > td > table > tbody > tr > td.itemmetadata");
        protected override By ByStepsToCompleteLabels { get { return By.CssSelector("tr#" + ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_MetadaInfo_Tr2 + tr + tr + tr + tr > td > table > tbody > tr > td.itemmetadata"); } }
        //public WebElementWrapper TestContentLineItemRowWebElementWrapper { get; private set; }
    }
}
