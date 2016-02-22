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
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.EditTestItem
{
    /// <summary>
    /// The edit test item choose item type detail
    /// </summary>
    public class EditTestItemChooseNewItemDetail : SNDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public EditTestItemChooseNewItemDetail()
            : base()
        {
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            ChooseAnItemType = new ChooseAnItemType();
        }

        /// <summary>
        /// choose an item type
        /// </summary>
        protected ChooseAnItemType ChooseAnItemType { get; set; }


        //mutlipleChoiceIndex
        /// <summary>
        /// Select the multiple choice image
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectMultipleChoiceImage()
        {
            ChooseAnItemType.SelectMultipleChoiceImage();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeFormMultipleChoice(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.MultipleChoice);
        }
        /// <summary>
        /// Select the multiple choice link
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectMultipleChoiceLink()
        {
            ChooseAnItemType.SelectMultipleChoiceLink();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeFormMultipleChoice(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.MultipleChoice);
        }

        //trueFalseIndex
        /// <summary>
        /// Select the true/false image
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectTrueFalseImage()
        {
            ChooseAnItemType.SelectTrueFalseImage();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeFormTrueFalse(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.TrueFalse);
        }
        /// <summary>
        /// Select the true/false link
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectTrueFalseLink()
        {
            ChooseAnItemType.SelectTrueFalseLink();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeFormTrueFalse(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.TrueFalse);
        }

        //griddedIndex
        /// <summary>
        /// Select the gridded image
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectGriddedImage()
        {
            ChooseAnItemType.SelectGriddedImage();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeGriddedForm(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.Gridded);
        }
        /// <summary>
        /// Select the gridded link
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectGriddedLink()
        {
            ChooseAnItemType.SelectGriddedLink();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeGriddedForm(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.Gridded);
        }

        //openResponseIndex
        /// <summary>
        /// Select the open response image
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectOpenResponseImage()
        {
            ChooseAnItemType.SelectOpenResponseImage();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeOpenResponseForm(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.OpenResponse);
        }
        /// <summary>
        /// Select the open response link
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectOpenResponseLink()
        {
            ChooseAnItemType.SelectOpenResponseLink();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeOpenResponseForm(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.OpenResponse);
        }

        //inlineReponseIndex
        /// <summary>
        /// Select the inline response image
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectInlineResponseImage()
        {
            ChooseAnItemType.SelectInlineResponseImage();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeFormInlineResponse(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.InlineResponse);
        }
        /// <summary>
        /// Select the inline response link
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectInlineResponseLink()
        {
            ChooseAnItemType.SelectInlineResponseLink();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeFormInlineResponse(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.InlineResponse);
        }

        //matchingIndex
        /// <summary>
        /// Select the matching image
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectMatchingImage()
        {
            ChooseAnItemType.SelectMatchingImage();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeFormMatching(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.Matching);
        }
        /// <summary>
        /// Select the matching link
        /// </summary>
        /// <returns></returns>
        public EditTestItemCreateNewItemPage SelectMatchingLink()
        {
            ChooseAnItemType.SelectMatchingLink();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeFormMatching(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.Matching);
        }

        //hotSpotSingleSelectionIndex
        /// <summary>
        /// Select the hot spot single selection image
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectHotSpotSingleSelectionImage()
        {
            ChooseAnItemType.SelectHotSpotSingleSelectionImage();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeFormMatching(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.HotSpotSingleSelection);
        }
        /// <summary>
        /// Select the hot spot single selection link
        /// </summary>
        /// <returns></returns>
        public EditTestItemCreateNewItemPage SelectHotSpotSingleSelectionLink()
        {
            ChooseAnItemType.SelectHotSpotSingleSelectionLink();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeFormMatching(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.HotSpotSingleSelection);
        }

        //hotSpotMultipleSelectionIndex
        /// <summary>
        /// Select the hot spot multiple selection image
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectHotSpotMultipleSelectionImage()
        {
            ChooseAnItemType.SelectHotSpotMultipleSelectionImage();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeFormMatching(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.HotSpotMultipleSelection);
        }
        /// <summary>
        /// Select the hot spot multiple selection link
        /// </summary>
        /// <returns></returns>
        public EditTestItemCreateNewItemPage SelectHotSpotMultipleSelectionLink()
        {
            ChooseAnItemType.SelectHotSpotMultipleSelectionLink();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeFormMatching(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.HotSpotMultipleSelection);
        }

        //dragAndDropIndex
        /// <summary>
        /// Select the drag and drop image
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectDragAndDropImage()
        {
            ChooseAnItemType.SelectDragAndDropImage();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeDragDropForm(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.DragAndDrop);
        }
        /// <summary>
        /// Select the drag and drop link
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectDragAndDropLink()
        {
            ChooseAnItemType.SelectDragAndDropLink();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeDragDropForm(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.DragAndDrop);
        }

        //ClickStickClickDrop
        /// <summary>
        /// Select the click stick click drop image
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectClickStickClickDropImage()
        {
            ChooseAnItemType.SelectClickStickClickDropImage();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeDragDropForm(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.ClickStickClickDrop);
        }
        /// <summary>
        /// Select the click stick click drop link
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectClickStickClickDropLink()
        {
            ChooseAnItemType.SelectClickStickClickDropLink();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeDragDropForm(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.ClickStickClickDrop);
        }

        //taskIndex
        /// <summary>
        /// Select the task image
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectTaskImage()
        {
            ChooseAnItemType.SelectTaskImage();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeTaskForm(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.Task);
        }
        /// <summary>
        /// Select the task link
        /// </summary>
        /// <returns>EditTestItemCreateNewItemPage</returns>
        public EditTestItemCreateNewItemPage SelectTaskLink()
        {
            ChooseAnItemType.SelectTaskLink();
            //return new EditTestItemCreateNewItemPage(Driver, new ItemTypeTaskForm(Driver));
            return new EditTestItemCreateNewItemPage(ItemType.Task);
        }
    }
}
