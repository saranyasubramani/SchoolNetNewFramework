using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.Passage.PassageDetail
{
    /// <summary>
    /// items linked to passage line item (row)
    /// </summary>
    public class ItemsLinkedToPassageLineItem : SNDetail
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="itemid">item ID</param>
        /// <param name="index">index</param>
        /// <param name="uniqueId">unique ID</param>
        public ItemsLinkedToPassageLineItem(string itemid, int index, string uniqueId)
            : base()
        {
            ItemId = itemid;
            Index = index;
            UniqueId = uniqueId;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            AddItemToTestCheck = new WebElementWrapper(ByAddItemToTestCheck);
            ExpandCollapseContainer = new WebElementWrapper(ByExpandCollapseContainer);
            ExpandCollapseLink = new WebElementWrapper(ByExpandCollapseLink);
            ItemDetailLabel = new WebElementWrapper(ByItemDetailLabel);
            ViewLink = new WebElementWrapper(ByViewLink);
            RemoveLink = new WebElementWrapper(ByRemoveLink);
        }

        /// <summary>
        /// the line's item ID
        /// </summary>
        public string ItemId { get; private set; }
        /// <summary>
        /// the line item's index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// the line item's unique ID
        /// </summary>
        public string UniqueId { get; set; }

        private By ByAddItemToTestCheck { get { return By.Id(ControlPrefix + "RepeaterTestItemsLinkedToPassage_" + this.UniqueId + "_CheckBoxAddToTest"); } }
        private WebElementWrapper AddItemToTestCheck { get; set; }
        //("thead#ctl00_MainContent_divExpandCollapseLinks + tbody > tr:nth-of-type(2) > td:nth-of-type(2) > span");
        private By ByExpandCollapseContainer { get { return By.CssSelector("thead#ctl00_MainContent_divExpandCollapseLinks + tbody > tr:nth-of-type(" + (this.Index + 1) + ") > td:nth-of-type(2) > span"); } }
        private WebElementWrapper ExpandCollapseContainer { get; set; }
        private By ByExpandCollapseLink { get { return By.CssSelector("a.testItem[_detail='" + this.ItemId + "']"); } }
        private WebElementWrapper ExpandCollapseLink { get; set; }
        private By ByItemDetailLabel { get { return By.CssSelector("#" + this.ItemId + " > p"); } }
        private WebElementWrapper ItemDetailLabel { get; set; }
        private By ByViewLink { get { return By.CssSelector(ControlPrefix + "RepeaterTestItemsLinkedToPassage_" + this.UniqueId + "_LinkButtonTestItemDetails"); } }
        private WebElementWrapper ViewLink { get; set; }
        private By ByRemoveLink { get { return By.CssSelector(ControlPrefix + "RepeaterTestItemsLinkedToPassage_" + this.UniqueId + "_LinkButtonUnLink"); } }
        private WebElementWrapper RemoveLink { get; set; }

        /// <summary>
        /// check add item to test
        /// </summary>
        public void CheckAddItemToTest()
        {
            AddItemToTestCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck add item to test
        /// </summary>
        public void UnCheckAddItemToTest()
        {
            AddItemToTestCheck.Wait(3).UnCheck();
        }

        /// <summary>
        /// expand
        /// </summary>
        public void Expand()
        {
            ExpandCollapseContainer.FakeAttributeClass = "closed";
            string classAttribute = ExpandCollapseContainer.WaitUntilExists(3).GetAttribute("class");
            Report.Write("ExpandCollapseContainer class: " + classAttribute);
            if (classAttribute.Contains("closed"))
            {
                ExpandCollapseLink.Wait(3).Click();
            }
        }

        /// <summary>
        /// collapse
        /// </summary>
        public void Collapse()
        {
            ExpandCollapseContainer.FakeAttributeClass = "opened";
            string classAttribute = ExpandCollapseContainer.WaitUntilExists(3).GetAttribute("class");
            Report.Write("ExpandCollapseContainer class: " + classAttribute);
            if (classAttribute.Contains("opened"))
            {
                ExpandCollapseLink.Wait(3).Click();
            }
        }

        /// <summary>
        /// get the item detail text
        /// </summary>
        /// <returns>item detail text</returns>
        public string GetItemDetail()
        {
            Expand();
            return ItemDetailLabel.Wait(3).Text;
        }

        /// <summary>
        /// click the view link
        /// </summary>
        public void SelectView()
        {
            ViewLink.Wait(3).Click();
            //returns /Assess/Items/ViewItemStatistics.aspx
        }

        /// <summary>
        /// click the remove link
        /// </summary>
        public void SelectRemove()
        {
            RemoveLink.Wait(3).Click();
        }
    }
}
