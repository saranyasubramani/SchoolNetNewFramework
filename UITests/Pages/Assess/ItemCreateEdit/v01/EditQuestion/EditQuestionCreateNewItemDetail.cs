using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.EditQuestion
{
    /// <summary>
    /// the edit question detail
    /// </summary>
    public class EditQuestionCreateNewItemDetail : SNDetail
    {
        /// <summary>
        /// the edit question detail constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public EditQuestionCreateNewItemDetail(string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            AddItemLink = new WebElementWrapper(ByAddItemLink);
            DeleteItemButton = new WebElementWrapper(ByDeleteItemButton);
        }

        /// <summary>
        /// the data object
        /// </summary>
        public new EditPageData Data
        {
            get
            {
                return (EditPageData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private By ByAddItemLink { get { return By.Id(ControlPrefix + "btnAddQuestion"); } }
        private WebElementWrapper AddItemLink { get; set; }
        private By ByDeleteItemButton { get { return By.Id(ControlPrefix + "ButtonDelete"); } }
        private WebElementWrapper DeleteItemButton { get; set; }

        /// <summary>
        /// add item
        /// </summary>
        public void AddItem()
        {
            AddItemLink.Wait(5).Click();
            ((EditQuestionCreateNewItemPage)Parent).SetRibbonBarItems();
        }
        /// <summary>
        /// delete item
        /// </summary>
        public void DeleteItem()
        {
            this.Parent.CurrentWindowHandle = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + this.Parent.CurrentWindowHandle + "'.");

            DeleteItemButton.Wait(5).Click();
            IAlert alert = Driver.SwitchTo().Alert();
            string expected = "Are you sure you wish to delete this item?";
            if (Driver.GetType() == typeof(DummyDriver))
            {
                ((DummyIAlert)alert).Text = expected;
            }
            string actual = alert.Text;
            Report.Write("The alert text: '" + actual + "'.");
            Assert.IsTrue(actual.Contains(expected), "The delete confirmation pop-up does not contain the expected text: '" + expected + "'; actual text: '" + actual + "'.");
            alert.Accept();

            //switch to window
            DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 5);
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            ((EditQuestionCreateNewItemPage)Parent).SetRibbonBarItems();
        }
        /// <summary>
        /// select the ribbon bar item by index
        /// </summary>
        /// <param name="index">the index label</param>
        public void SelectItemByIndex(int index)
        {
            List<RibbonBarItem> ribbonBarItemList = ((EditQuestionCreateNewItemPage)Parent).RibbonBarItemList;
            foreach (var ribbonBarItem in ribbonBarItemList)
            {
                if (ribbonBarItem.Index == index)
                {
                    ribbonBarItem.SelectItem();
                }
            }
        }
        /// <summary>
        /// select the ribbon bar item by item ID
        /// </summary>
        /// <param name="itemId">the item ID</param>
        public void SelectItemByItemId(int itemId)
        {
            List<RibbonBarItem> ribbonBarItemList = ((EditQuestionCreateNewItemPage)Parent).RibbonBarItemList;
            foreach (var ribbonBarItem in ribbonBarItemList)
            {
                if (ribbonBarItem.ItemId == itemId)
                {
                    ribbonBarItem.SelectItem();
                }
            }
        }
        /// <summary>
        /// get the ribbon bar item state by index
        /// </summary>
        /// <param name="index">the index label</param>
        /// <returns>RibbonBarItemState</returns>
        public RibbonBarItemState GetItemStateByIndex(int index)
        {
            //default
            RibbonBarItemState itemState = RibbonBarItemState.RibbonBarSelectedItem;
            List<RibbonBarItem> ribbonBarItemList = ((EditQuestionCreateNewItemPage)Parent).RibbonBarItemList;
            foreach (var ribbonBarItem in ribbonBarItemList)
            {
                if (ribbonBarItem.Index == index)
                {
                    itemState = ribbonBarItem.GetItemState();
                }
            }
            return itemState;
        }
        /// <summary>
        /// get the ribbon bar item state by item ID
        /// </summary>
        /// <param name="itemId">the item ID</param>
        /// <returns>RibbonBarItemState</returns>
        public RibbonBarItemState GetItemStateByItemId(int itemId)
        {
            //default
            RibbonBarItemState itemState = RibbonBarItemState.RibbonBarSelectedItem;
            List<RibbonBarItem> ribbonBarItemList = ((EditQuestionCreateNewItemPage)Parent).RibbonBarItemList;
            foreach (var ribbonBarItem in ribbonBarItemList)
            {
                if (ribbonBarItem.ItemId == itemId)
                {
                    itemState = ribbonBarItem.GetItemState();
                }
            }
            return itemState;
        }
    }
}
