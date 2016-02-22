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

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts
{
    /// <summary>
    /// represents the item detail - item content line item row.
    /// </summary>
    public class ItemContentLineItem : ContentLineItem
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="webElement">IWebElement</param>
        /// <param name="itemid">the item ID</param>
        /// <param name="index">the index</param>
        /// <param name="uniqueId">the unique ID</param>
        /// <param name="label">the label</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemContentLineItem(IWebElement webElement, int itemid, int index, string uniqueId, string label,
            string overrideControlPrefix = null)
            : base(webElement, itemid, index, uniqueId, label, overrideControlPrefix)
        {
            /*
            ItemContent = new WebElementWrapper(Driver, ByItemContent);
            MoreLessLink = new WebElementWrapper(Driver, ByMoreLessLink);
            ActionsLink = new WebElementWrapper(Driver, ByActionsLink);
            ViewLink = new WebElementWrapper(Driver, ByViewLink);
            EditLink = new WebElementWrapper(Driver, ByEditLink);
            DeleteLink = new WebElementWrapper(Driver, ByDeleteLink);
            CorrectAnswerLabel = new WebElementWrapper(Driver, ByCorrectAnswerLabel);
            PointValueLabel = new WebElementWrapper(Driver, ByPointValueLabel);
            StandardIdLabel = new WebElementWrapper(Driver, ByStandardIdLabel);
            StepsToCompleteLabels = new WebElementWrapper(Driver, ByStepsToCompleteLabels);

            expectedRequiredErrorsList = new List<string>()
            {
                "Align to a standard",
                "Add question content for question container 1,2,3",
                "Add content for answer choice A,B,C,D",
                "Select correct answer for question container 1,2,3",
                "Not worth any points"
            };
            */
        }

        protected override By ByItemContent { get { return By.Id("contentDiv_" + ItemId); } }
        //ShowHideAll(this,'256338', 'false');return false;
        protected override By ByMoreLessLink { get { return By.CssSelector("a[onclick*='ShowHideAll(this, '" + Index + "']"); } }
        //CSS selector does not work, so I have to use XPath, need to have Dev fix this
        //private By ByActionsLink { get { return By.CssSelector("div[ng-app='testitem'] > table.DataGridTable > tbody > tr:nth-of-type(" + (Index + 1) + ") .dropdown-toggle"); } }
        protected override By ByActionsLink { get { return By.XPath("//tr[@class='DataGridRow'][" + (Index + 1) + "]/td/div[@class='btn-group']/a[@class='btn dropdown-toggle']"); } }
        protected override By ByViewLink { get { return By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ViewTaskItemControl_RepeaterTaskItems_" + UniqueId + "_ButtonItemDetails"); } }
        protected override By ByEditLink { get { return By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ViewTaskItemControl_RepeaterTaskItems_" + UniqueId + "_ButtonEditItem"); } }
        protected override By ByDeleteLink { get { return By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ViewTaskItemControl_RepeaterTaskItems_" + UniqueId + "_ButtonDeleteItem"); } }
        //tr#ctl00_MainContent_EditTestItemControl_EditTaskItemControl1_ViewTaskItemControl_RepeaterTaskItems_ctl01_MetadaInfo_Tr1 > td.itemmetadataheading
        protected override By ByCorrectAnswerLabel
        {
            get
            {
                return By.CssSelector("tr#" + ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ViewTaskItemControl_RepeaterTaskItems_" + UniqueId + "_MetadaInfo_Tr1 + tr > td.itemmetadataheading");
            }
        }
        protected override By ByPointValueLabel { get { return By.CssSelector("tr#" + ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ViewTaskItemControl_RepeaterTaskItems_" + UniqueId + "_MetadaInfo_Tr1 + tr + tr + tr > td.itemmetadata"); } }
        protected override By ByStandardIdLabel { get { return By.CssSelector("tr#" + ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ViewTaskItemControl_RepeaterTaskItems_" + UniqueId + "_MetadaInfo_Tr2 + tr > td.itemmetadata"); } }
        //("#ctl00_MainContent_RepeaterTestItems_ctl01_ViewTestItems1_MetadaInfo_Tr2 + tr + tr + tr + tr > td > table > tbody > tr > td.itemmetadata");
        protected override By ByStepsToCompleteLabels { get { return By.CssSelector("tr#" + ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ViewTaskItemControl_RepeaterTaskItems_" + UniqueId + "_MetadaInfo_Tr2 + tr + tr + tr + tr > td > table > tbody > tr > td.itemmetadata"); } }
        
    }
}
