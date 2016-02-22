using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.Components
{
    /// <summary>
    /// represents the ribbon bar item
    /// </summary>
    public class RibbonBarItem : SNDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="index">the index label</param>
        /// <param name="itemId">the item ID</param>
        public RibbonBarItem(int index, int itemId)
            : base()
        {
            Index = index;
            ItemId = itemId;
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            RibbonBarItemDiv = new WebElementWrapper(ByRibbonBarItemDiv);
        }

        /// <summary>
        /// the index label
        /// </summary>
        public int Index { get; private set; }
        /// <summary>
        /// the item ID
        /// </summary>
        public int ItemId { get; private set; }

        private By ByRibbonBarItemDiv { get { return By.CssSelector(".RibbonBarItem[onclick^='gotoQuestion(" + ItemId + ")']"); } }
        private WebElementWrapper RibbonBarItemDiv { get; set; }

        /// <summary>
        /// select the ribbon bar item
        /// </summary>
        public void SelectItem()
        {
            RibbonBarItemDiv.Wait(5).Click();
        }
        /// <summary>
        /// get the ribbon bar item state
        /// </summary>
        public RibbonBarItemState GetItemState()
        {
            RibbonBarItemState itemState;
            string classAttribute = RibbonBarItemDiv.Wait(5).GetAttribute("class");
            Report.Write("class: " + classAttribute);
            if (classAttribute.Contains("RibbonBarError"))
            {
                itemState = RibbonBarItemState.RibbonBarError;
            }
            else if (classAttribute.Contains("RibbonBarReady"))
            {
                itemState = RibbonBarItemState.RibbonBarReady;
            }
            else if (classAttribute.Contains("RibbonBarSelectedItem"))
            {
                itemState = RibbonBarItemState.RibbonBarSelectedItem;
            }
            else
            {
                itemState = RibbonBarItemState.RibbonBarSelectedItem;
            }
            Report.Write("RibbonBarItemState: " + itemState);
            return itemState;
        }
    }
}
