using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCentral;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts
{
    /// <summary>
    /// choose an item type component
    /// </summary>
    public class ChooseAnItemType : SNComponent
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ChooseAnItemType() : base() { }

        private const string MultipleChoiceIndex = "0";
        private const string TrueFalseIndex = "1";
        private const string OpenResponseIndex = "2";
        private const string GriddedIndex = "5";
        private const string InlineReponseIndex = "6";
        private const string MatchingIndex = "7";
        private const string TaskIndex = "10";
        private const string HotSpotSingleSelectionIndex = "11";
        private const string HotSpotMultipleSelectionIndex = "12";
        private const string DragAndDropIndex = "13";
        private const string ClickStickClickDropIndex = "14";
        private const string LookupInItemCentralIndex = "LOOKUP";

        public By ByImage(string index)
        {
            return By.CssSelector("a[href=\"javascript:updateQuestionType('" + index + "');\"] > img");
        }
        public WebElementWrapper Image(string index)
        {
            return new WebElementWrapper(ByImage(index));
        }

        public By ByLink(string index)
        {
            return By.CssSelector("a[href=\"javascript:updateQuestionType('" + index + "');\"]");
        }
        public WebElementWrapper Link(string index)
        {
            return new WebElementWrapper(ByLink(index));
        }

        //mutlipleChoiceIndex
        /// <summary>
        /// Select the multiple choice image
        /// </summary>
        public void SelectMultipleChoiceImage()
        {
            Image(MultipleChoiceIndex).Wait(5).Click();
        }
        /// <summary>
        /// Select the multiple choice link
        /// </summary>
        public void SelectMultipleChoiceLink()
        {
            Link(MultipleChoiceIndex).Wait(5).Click();
        }

        //trueFalseIndex
        /// <summary>
        /// Select the true/false image
        /// </summary>
        public void SelectTrueFalseImage()
        {
            Image(TrueFalseIndex).Wait(5).Click();
        }
        /// <summary>
        /// Select the true/false link
        /// </summary>
        public void SelectTrueFalseLink()
        {
            Link(TrueFalseIndex).Wait(5).Click();
        }

        //griddedIndex
        /// <summary>
        /// Select the gridded image
        /// </summary>
        public void SelectGriddedImage()
        {
            Image(GriddedIndex).Wait(5).Click();
        }
        /// <summary>
        /// Select the gridded link
        /// </summary>
        public void SelectGriddedLink()
        {
            Link(GriddedIndex).Wait(5).Click();
        }

        //openResponseIndex
        /// <summary>
        /// Select the open response image
        /// </summary>
        public void SelectOpenResponseImage()
        {
            Image(OpenResponseIndex).Wait(5).Click();
        }
        /// <summary>
        /// Select the open response link
        /// </summary>
        public void SelectOpenResponseLink()
        {
            Link(OpenResponseIndex).Wait(5).Click();
        }

        //inlineReponseIndex
        /// <summary>
        /// Select the inline response image
        /// </summary>
        public void SelectInlineResponseImage()
        {
            Image(InlineReponseIndex).Wait(5).Click();
        }
        /// <summary>
        /// Select the inline response link
        /// </summary>
        public void SelectInlineResponseLink()
        {
            Link(InlineReponseIndex).Wait(5).Click();
        }

        //matchingIndex
        /// <summary>
        /// Select the matching image
        /// </summary>
        public void SelectMatchingImage()
        {
            Image(MatchingIndex).Wait(5).Click();
        }
        /// <summary>
        /// Select the matching link
        /// </summary>
        public void SelectMatchingLink()
        {
            Link(MatchingIndex).Wait(5).Click();
        }

        //hotSpotSingleSelectionIndex
        /// <summary>
        /// Select the hot spot single selection image
        /// </summary>
        public void SelectHotSpotSingleSelectionImage()
        {
            Image(HotSpotSingleSelectionIndex).Wait(5).Click();
        }
        /// <summary>
        /// Select the hot spot single selection link
        /// </summary>
        public void SelectHotSpotSingleSelectionLink()
        {
            Link(HotSpotSingleSelectionIndex).Wait(5).Click();
        }

        //hotSpotMultipleSelectionIndex
        /// <summary>
        /// Select the hot spot multiple selection image
        /// </summary>
        public void SelectHotSpotMultipleSelectionImage()
        {
            Image(HotSpotMultipleSelectionIndex).Wait(5).Click();
        }
        /// <summary>
        /// Select the hot spot multiple selection link
        /// </summary>
        public void SelectHotSpotMultipleSelectionLink()
        {
            Link(HotSpotMultipleSelectionIndex).Wait(5).Click();
        }

        //dragAndDropIndex
        /// <summary>
        /// Select the drag and drop image
        /// </summary>
        public void SelectDragAndDropImage()
        {
            Image(DragAndDropIndex).Wait(5).Click();
        }
        /// <summary>
        /// Select the drag and drop link
        /// </summary>
        public void SelectDragAndDropLink()
        {
            Link(DragAndDropIndex).Wait(5).Click();
        }

        //ClickStickClickDrop
        /// <summary>
        /// Select the click stick click drop image
        /// </summary>
        public void SelectClickStickClickDropImage()
        {
            Image(ClickStickClickDropIndex).Wait(5).Click();
        }
        /// <summary>
        /// Select the click stick click drop link
        /// </summary>
        public void SelectClickStickClickDropLink()
        {
            Link(ClickStickClickDropIndex).Wait(5).Click();
        }

        //taskIndex
        /// <summary>
        /// Select the task image
        /// </summary>
        public void SelectTaskImage()
        {
            Image(TaskIndex).Wait(5).Click();
        }
        /// <summary>
        /// Select the task link
        /// </summary>
        public void SelectTaskLink()
        {
            Link(TaskIndex).Wait(5).Click();
        }

        //LookupInItemCentralIndex
        public ItemCentralHomePage LookupInItemCentralImage()
        {
            Image(LookupInItemCentralIndex).Wait(5).Click();
            return new ItemCentralHomePage();
        }
        public ItemCentralHomePage LookupInItemCentralLink()
        {
            Link(LookupInItemCentralIndex).Wait(5).Click();
            return new ItemCentralHomePage();
        }
    }
}
