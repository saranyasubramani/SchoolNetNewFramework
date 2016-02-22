using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Components
{
    /// <summary>
    /// represents the Item Type custom control field
    /// </summary>
    public class ItemTypeControl : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="pageNames">the page name</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemTypeControl(PageNames pageNames, string overrideControlPrefix = null)
            : base()
        {
            this.PageNames = pageNames;
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            switch (PageNames)
            {
                case PageNames.ItemCentral:
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_ddlItemType_label
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_ddlItemType
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_ddlItemType_ctl00_ctl00_label
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_ddlItemType_ctl00_ctl00_checkBox
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_ddlItemType_ctl00_ctl01_label
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_ddlItemType_ctl00_ctl01_checkBox
                    ControlMiddle = "ItemFinder1_ItemFinderSearch1_";
                    break;
            }
            DropdownSelect = new WebElementWrapper(ByDropdownSelect);
            MultipleChoiceCheck = new WebElementWrapper(ByMultipleChoiceCheck);
            GriddedCheck = new WebElementWrapper(ByGriddedCheck);
            TrueFalseCheck = new WebElementWrapper(ByTrueFalseCheck);
            OpenResponseCheck = new WebElementWrapper(ByOpenResponseCheck);
            InlineResponseCheck = new WebElementWrapper(ByInlineResponseCheck);
            MatchingCheck = new WebElementWrapper(ByMatchingCheck);
            TaskCheck = new WebElementWrapper(ByTaskCheck);
            HotSpotSingleSelectionCheck = new WebElementWrapper(ByHotSpotSingleSelectionCheck);
            HotSpotMultipleSelectionCheck = new WebElementWrapper(ByHotSpotMultipleSelectionCheck);
            DragAndDropCheck = new WebElementWrapper(ByDragAndDropCheck);
            ClickStickClickDropCheck = new WebElementWrapper(ByClickStickClickDropCheck);
            CancelButton = new WebElementWrapper(ByCancelButton);
            OkButton = new WebElementWrapper(ByOkButton);
        }

        private PageNames PageNames { get; set; }
        private string ControlMiddle { get; set; }
        private By ByDropdownSelect { get { return By.Id(ControlPrefix + ControlMiddle + "ddlItemType_label"); } }
        private WebElementWrapper DropdownSelect { get; set; }
        private By ByMultipleChoiceCheck { get { return By.Id(ControlPrefix + ControlMiddle + "ddlItemType_ctl00_ctl00_checkBox"); } }
        private WebElementWrapper MultipleChoiceCheck { get; set; }
        private By ByGriddedCheck { get { return By.Id(ControlPrefix + ControlMiddle + "ddlItemType_ctl00_ctl01_checkBox"); } }
        private WebElementWrapper GriddedCheck { get; set; }
        private By ByTrueFalseCheck { get { return By.Id(ControlPrefix + ControlMiddle + "ddlItemType_ctl00_ctl02_checkBox"); } }
        private WebElementWrapper TrueFalseCheck { get; set; }
        private By ByOpenResponseCheck { get { return By.Id(ControlPrefix + ControlMiddle + "ddlItemType_ctl00_ctl03_checkBox"); } }
        private WebElementWrapper OpenResponseCheck { get; set; }
        private By ByInlineResponseCheck { get { return By.Id(ControlPrefix + ControlMiddle + "ddlItemType_ctl00_ctl04_checkBox"); } }
        private WebElementWrapper InlineResponseCheck { get; set; }
        private By ByMatchingCheck { get { return By.Id(ControlPrefix + ControlMiddle + "ddlItemType_ctl00_ctl05_checkBox"); } }
        private WebElementWrapper MatchingCheck { get; set; }
        private By ByTaskCheck { get { return By.Id(ControlPrefix + ControlMiddle + "ddlItemType_ctl00_ctl06_checkBox"); } }
        private WebElementWrapper TaskCheck { get; set; }
        private By ByHotSpotSingleSelectionCheck { get { return By.Id(ControlPrefix + ControlMiddle + "ddlItemType_ctl00_ctl07_checkBox"); } }
        private WebElementWrapper HotSpotSingleSelectionCheck { get; set; }
        private By ByHotSpotMultipleSelectionCheck { get { return By.Id(ControlPrefix + ControlMiddle + "ddlItemType_ctl00_ctl08_checkBox"); } }
        private WebElementWrapper HotSpotMultipleSelectionCheck { get; set; }
        private By ByDragAndDropCheck { get { return By.Id(ControlPrefix + ControlMiddle + "ddlItemType_ctl00_ctl09_checkBox"); } }
        private WebElementWrapper DragAndDropCheck { get; set; }
        private By ByClickStickClickDropCheck { get { return By.Id(ControlPrefix + ControlMiddle + "ddlItemType_ctl00_ctl10_checkBox"); } }
        private WebElementWrapper ClickStickClickDropCheck { get; set; }
        private By ByCancelButton { get { return By.CssSelector("#ctl00_MainContent_ItemFinder1_ItemFinderSearch1_ddlItemType input.checkBoxCancel"); } }
        private WebElementWrapper CancelButton { get; set; }
        private By ByOkButton { get { return By.CssSelector("#ctl00_MainContent_ItemFinder1_ItemFinderSearch1_ddlItemType input.checkBoxOK"); } }
        private WebElementWrapper OkButton { get; set; }

        /// <summary>
        /// select the item type
        /// </summary>
        public void SelectItemType()
        {
            DropdownSelect.Wait(3).Click();
        }
        /// <summary>
        /// select multiple choice
        /// </summary>
        public void MultipleChoice()
        {
            MultipleChoiceCheck.Wait(3).Click();
        }
        /// <summary>
        /// select gridded
        /// </summary>
        public void Gridded()
        {
            GriddedCheck.Wait(3).Click();
        }
        /// <summary>
        /// select true/false
        /// </summary>
        public void TrueFalse()
        {
            TrueFalseCheck.Wait(3).Click();
        }
        /// <summary>
        /// select open response
        /// </summary>
        public void OpenResponse()
        {
            OpenResponseCheck.Wait(3).Click();
        }
        /// <summary>
        /// select inline response
        /// </summary>
        public void InlineResponse()
        {
            InlineResponseCheck.Wait(3).Click();
        }
        /// <summary>
        /// select matching
        /// </summary>
        public void Matching()
        {
            MatchingCheck.Wait(3).Click();
        }
        /// <summary>
        /// select task
        /// </summary>
        public void Task()
        {
            TaskCheck.Wait(3).Click();
        }
        /// <summary>
        /// select hot spot single selection
        /// </summary>
        public void HotSpotSingleSelection()
        {
            HotSpotSingleSelectionCheck.Wait(3).Click();
        }
        /// <summary>
        /// select hot spot multiple selection
        /// </summary>
        public void HotSpotMultipleSelection()
        {
            HotSpotMultipleSelectionCheck.Wait(3).Click();
        }
        /// <summary>
        /// select drag and drop
        /// </summary>
        public void DragAndDrop()
        {
            DragAndDropCheck.Wait(3).Click();
        }
        /// <summary>
        /// select click stick click drop
        /// </summary>
        public void ClickStickClickDrop()
        {
            ClickStickClickDropCheck.Wait(3).Click();
        }
        /// <summary>
        /// select cancel
        /// </summary>
        public void Cancel()
        {
            CancelButton.WaitUntilVisible(3).Click();
        }
        /// <summary>
        /// select ok
        /// </summary>
        public void Ok()
        {
            OkButton.WaitUntilVisible(3).Click();
        }
    }
}
