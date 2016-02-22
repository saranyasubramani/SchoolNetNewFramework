using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Framework;
using Core.Views;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts
{
    /// <summary>
    /// attach rubric line item
    /// </summary>
    public class AttachRubricLineItem : SNComponent
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="index"></param>
        /// <param name="uniqueId"></param>
        /// <param name="parentWindow"></param>
        /// <param name="overrideControlPrefix"></param>
        public AttachRubricLineItem(int itemid, int index, string uniqueId, string parentWindow, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }

            ItemId = itemid;
            Index = index;
            UniqueId = uniqueId;
            ParentWindow = parentWindow;

            AttachButton = new WebElementWrapper(ByAttachButton);
        }

        /// <summary>
        /// the parent window to get back to
        /// </summary>
        public string ParentWindow { get; set; }
        /// <summary>
        /// the line's item ID
        /// </summary>        
        public int ItemId { get; private set; }
        /// <summary>
        /// the line item's index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// the line item's unique ID
        /// </summary>
        public string UniqueId { get; set; }

        //ctl00_MainContent_GridRubrics_ctl03_AddButton
        private By ByAttachButton { get { return By.Id(ControlPrefix + "GridRubrics_" + UniqueId + "_AddButton"); } }
        private WebElementWrapper AttachButton { get; set; }

        /// <summary>
        /// attach
        /// </summary>
        public void SelectAttach()
        {
            AttachButton.Wait(5).Click();
            this.DriverCommands.WaitToSwitchWindow(ParentWindow, 3);
        }
    }
}
