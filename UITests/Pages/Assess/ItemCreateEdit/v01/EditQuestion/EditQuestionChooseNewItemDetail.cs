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
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTestItem;
using UITests.Pages.Assess.ItemCentral;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.EditQuestion
{
    /// <summary>
    /// The edit question choose item type detail
    /// </summary>
    public class EditQuestionChooseNewItemDetail : EditTestItemChooseNewItemDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public EditQuestionChooseNewItemDetail()
            : base()
        {
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            TestStages = new TestStages(PageNames.EditQuestion);
            ChooseAnItemType = new ChooseAnItemType();
            AddItemLink = new WebElementWrapper(ByAddItemLink);
            DeleteItemButton = new WebElementWrapper(ByDeleteItemButton);
        }

        private TestStages TestStages { get; set; }
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
            ((EditQuestionChooseNewItemPage)Parent).SetRibbonBarItems();
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
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
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
            ((EditQuestionChooseNewItemPage)Parent).SetRibbonBarItems();
        }
        /// <summary>
        /// select the ribbon bar item by index
        /// </summary>
        /// <param name="index">the index label</param>
        public void SelectItemByIndex(int index)
        {
            List<RibbonBarItem> ribbonBarItemList = ((EditQuestionChooseNewItemPage)Parent).RibbonBarItemList;
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
            List<RibbonBarItem> ribbonBarItemList = ((EditQuestionChooseNewItemPage)Parent).RibbonBarItemList;
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
            List<RibbonBarItem> ribbonBarItemList = ((EditQuestionChooseNewItemPage)Parent).RibbonBarItemList;
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
            List<RibbonBarItem> ribbonBarItemList = ((EditQuestionChooseNewItemPage)Parent).RibbonBarItemList;
            foreach (var ribbonBarItem in ribbonBarItemList)
            {
                if (ribbonBarItem.ItemId == itemId)
                {
                    itemState = ribbonBarItem.GetItemState();
                }
            }
            return itemState;
        }

        //mutlipleChoiceIndex
        /// <summary>
        /// Select the multiple choice image
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectMultipleChoiceImage()
        {
            ChooseAnItemType.SelectMultipleChoiceImage();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeFormMultipleChoice(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.MultipleChoice);
        }
        /// <summary>
        /// Select the multiple choice link
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectMultipleChoiceLink()
        {
            ChooseAnItemType.SelectMultipleChoiceLink();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeFormMultipleChoice(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.MultipleChoice);
        }

        //trueFalseIndex
        /// <summary>
        /// Select the true/false image
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectTrueFalseImage()
        {
            ChooseAnItemType.SelectTrueFalseImage();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeFormTrueFalse(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.TrueFalse);
        }
        /// <summary>
        /// Select the true/false link
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectTrueFalseLink()
        {
            ChooseAnItemType.SelectTrueFalseLink();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeFormTrueFalse(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.TrueFalse);
        }

        //griddedIndex
        /// <summary>
        /// Select the gridded image
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectGriddedImage()
        {
            ChooseAnItemType.SelectGriddedImage();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeGriddedForm(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.Gridded);
        }
        /// <summary>
        /// Select the gridded link
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectGriddedLink()
        {
            ChooseAnItemType.SelectGriddedLink();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeGriddedForm(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.Gridded);
        }

        //openResponseIndex
        /// <summary>
        /// Select the open response image
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectOpenResponseImage()
        {
            ChooseAnItemType.SelectOpenResponseImage();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeOpenResponseForm(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.OpenResponse);
        }
        /// <summary>
        /// Select the open response link
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectOpenResponseLink()
        {
            ChooseAnItemType.SelectOpenResponseLink();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeOpenResponseForm(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.OpenResponse);
        }

        //inlineReponseIndex
        /// <summary>
        /// Select the inline response image
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectInlineResponseImage()
        {
            ChooseAnItemType.SelectInlineResponseImage();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeFormInlineResponse(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.InlineResponse);
        }
        /// <summary>
        /// Select the inline response link
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectInlineResponseLink()
        {
            ChooseAnItemType.SelectInlineResponseLink();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeFormInlineResponse(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.InlineResponse);
        }

        //matchingIndex
        /// <summary>
        /// Select the matching image
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectMatchingImage()
        {
            ChooseAnItemType.SelectMatchingImage();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeFormMatching(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.Matching);
        }
        /// <summary>
        /// Select the matching link
        /// </summary>
        /// <returns></returns>
        public EditQuestionCreateNewItemPage SelectMatchingLink()
        {
            ChooseAnItemType.SelectMatchingLink();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeFormMatching(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.Matching);
        }

        //hotSpotSingleSelectionIndex
        /// <summary>
        /// Select the hot spot single selection image
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectHotSpotSingleSelectionImage()
        {
            ChooseAnItemType.SelectHotSpotSingleSelectionImage();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeFormMatching(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.HotSpotSingleSelection);
        }
        /// <summary>
        /// Select the hot spot single selection link
        /// </summary>
        /// <returns></returns>
        public EditQuestionCreateNewItemPage SelectHotSpotSingleSelectionLink()
        {
            ChooseAnItemType.SelectHotSpotSingleSelectionLink();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeFormMatching(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.HotSpotSingleSelection);
        }

        //hotSpotMultipleSelectionIndex
        /// <summary>
        /// Select the hot spot multiple selection image
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectHotSpotMultipleSelectionImage()
        {
            ChooseAnItemType.SelectHotSpotMultipleSelectionImage();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeFormMatching(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.HotSpotMultipleSelection);
        }
        /// <summary>
        /// Select the hot spot multiple selection link
        /// </summary>
        /// <returns></returns>
        public EditQuestionCreateNewItemPage SelectHotSpotMultipleSelectionLink()
        {
            ChooseAnItemType.SelectHotSpotMultipleSelectionLink();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeFormMatching(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.HotSpotMultipleSelection);
        }

        //dragAndDropIndex
        /// <summary>
        /// Select the drag and drop image
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectDragAndDropImage()
        {
            ChooseAnItemType.SelectDragAndDropImage();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeDragDropForm(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.DragAndDrop);
        }
        /// <summary>
        /// Select the drag and drop link
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectDragAndDropLink()
        {
            ChooseAnItemType.SelectDragAndDropLink();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeDragDropForm(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.DragAndDrop);
        }

        //ClickStickClickDrop
        /// <summary>
        /// Select the click stick click drop image
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectClickStickClickDropImage()
        {
            ChooseAnItemType.SelectClickStickClickDropImage();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeDragDropForm(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.ClickStickClickDrop);
        }
        /// <summary>
        /// Select the click stick click drop link
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectClickStickClickDropLink()
        {
            ChooseAnItemType.SelectClickStickClickDropLink();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeDragDropForm(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.ClickStickClickDrop);
        }

        //taskIndex
        /// <summary>
        /// Select the task image
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectTaskImage()
        {
            ChooseAnItemType.SelectTaskImage();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeTaskForm(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.Task);
        }
        /// <summary>
        /// Select the task link
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public EditQuestionCreateNewItemPage SelectTaskLink()
        {
            ChooseAnItemType.SelectTaskLink();
            //return new EditQuestionCreateNewItemPage(Driver, new ItemTypeTaskForm(Driver));
            return new EditQuestionCreateNewItemPage(ItemType.Task);
        }

        //LookupInItemCentralIndex
        /// <summary>
        /// Select the lookup in item central image
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public ItemCentralHomePage LookupInItemCentralImage()
        {
            return ChooseAnItemType.LookupInItemCentralImage();
        }
        /// <summary>
        /// Select the lookup in item central link
        /// </summary>
        /// <returns>EditQuestionCreateNewItemPage</returns>
        public ItemCentralHomePage LookupInItemCentralLink()
        {
            return ChooseAnItemType.LookupInItemCentralLink();
        }
    }
}
