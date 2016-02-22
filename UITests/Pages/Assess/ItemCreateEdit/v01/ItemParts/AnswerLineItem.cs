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
    /// Represents the points possible, is correct response, and remove line fields.
    /// </summary>
    public class AnswerLineItem : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="uniqueId">the unique ID</param>
        /// <param name="itemType">the item type</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public AnswerLineItem(int index, string uniqueId, ItemType itemType, string overrideControlPrefix = null)
            : base()
        {
            this.Index = index;
            this.UniqueId = uniqueId;
            this.ItemType = itemType;
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            PointsPossible = new WebElementWrapper(ByPointsPossible());
            IsCorrectResponse = new WebElementWrapper(ByIsCorrectResponse());
            RemoveLine = new WebElementWrapper(ByRemoveLine());
        }
        /// <summary>
        /// index
        /// </summary>
        public int Index { get; private set; }
        /// <summary>
        /// unique ID
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        /// item type
        /// </summary>
        private ItemType ItemType { get; set; }

        /// <summary>
        /// The points possible text box.
        /// </summary>
        public WebElementWrapper PointsPossible { get; private set; }

        /// <summary>
        /// The is correct response check box.
        /// </summary>
        public WebElementWrapper IsCorrectResponse { get; private set; }

        /// <summary>
        /// The remove line link.
        /// </summary>
        public WebElementWrapper RemoveLine { get; private set; }

        /// <summary>
        /// The points possible by
        /// </summary>
        /// <returns>By</returns>
        public By ByPointsPossible()
        {
            By by = null;
            switch (this.ItemType)
            {
                case ItemType.Matching:
                    by = By.Id(ControlPrefix + "EditTestItemControl_pairsRepeator_" + this.UniqueId + "_txtPointsPossible");
                    break;
                case ItemType.MultipleChoice:
                    by = By.Id(ControlPrefix + "EditTestItemControl_RepeaterAnswers_" + this.UniqueId + "_txtAnswerPoints");
                    break;
                case ItemType.TrueFalse:
                    by = By.Id(ControlPrefix + "EditTestItemControl_RepeaterAnswers_" + this.UniqueId + "_txtAnswerPoints");
                    break;
                case ItemType.InlineResponse:
                    by = By.Id(ControlPrefix + "EditTestItemControl_RepeaterClozeStemAnswers_" + this.UniqueId + "_txtAnswerPoints");
                    break;
                case ItemType.DragAndDrop:
                    by = By.CssSelector(".tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + Index + ") .AnswerPoints");
                    break;
                case ItemType.HotSpotSingleSelection:
                    by = By.CssSelector("#tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + Index + ") .AnswerPoints");
                    break;
            }
            return by;
        }
        /// <summary>
        /// The is correct response by
        /// </summary>
        /// <returns></returns>
        public By ByIsCorrectResponse()
        {
            By by = null;
            switch (this.ItemType)
            {
                case ItemType.Matching:
                    by = By.Id(ControlPrefix + "EditTestItemControl_pairsRepeator_" + this.UniqueId + "_chkIsCorrect");
                    break;
                case ItemType.MultipleChoice:
                    by = By.Id(ControlPrefix + "EditTestItemControl_RepeaterAnswers_" + this.UniqueId + "_CheckBoxCorrect");
                    break;
                case ItemType.TrueFalse:
                    by = By.Id(ControlPrefix + "EditTestItemControl_RepeaterAnswers_" + this.UniqueId + "_CheckBoxCorrect");
                    break;
                case ItemType.InlineResponse:
                    by = By.Id(ControlPrefix + "EditTestItemControl_RepeaterClozeStemAnswers_" + this.UniqueId + "_CheckBoxCorrect");
                    break;
                case ItemType.DragAndDrop:
                    by = By.CssSelector(".tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + Index + ") .checkbox > input");
                    break;
                case ItemType.HotSpotSingleSelection:
                    by = By.CssSelector("#tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + Index + ") .checkbox > input");
                    break;
            }
            return by;
        }
        /// <summary>
        /// The remove line by
        /// </summary>
        /// <returns></returns>
        public By ByRemoveLine()
        {
            By by = null;
            switch (this.ItemType)
            {
                case ItemType.Matching:
                    by = By.Id(ControlPrefix + "EditTestItemControl_choicesRepeator_" + this.UniqueId + "_lnkDeleteChoice");
                    break;
                case ItemType.MultipleChoice:
                    by = By.Id(ControlPrefix + "EditTestItemControl_RepeaterAnswers_" + this.UniqueId + "_LinkButton1");
                    break;
                case ItemType.TrueFalse:
                    by = By.Id("");
                    break;
                case ItemType.InlineResponse:
                    by = By.Id(ControlPrefix + "EditTestItemControl_RepeaterClozeStemAnswers_" + this.UniqueId + "_DelClozeChoice");
                    break;
                case ItemType.DragAndDrop:
                    by = By.CssSelector("");
                    break;
                case ItemType.HotSpotSingleSelection:
                    by = By.CssSelector("#tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + Index + ") .pull-right > a");
                    break;
            }
            return by;
        }
    }
}
