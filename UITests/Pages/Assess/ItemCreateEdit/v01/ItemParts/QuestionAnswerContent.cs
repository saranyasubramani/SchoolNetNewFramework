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
    /// Represents the Question Stem, Answer Choice, Available Choice, and "Click to add content" fields.
    /// </summary>
    public class QuestionAnswerContent : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="label">the label</param>
        /// <param name="index">the index</param>
        /// <param name="uniqueId">the unique ID</param>
        /// <param name="contentType">the content type</param>
        /// <param name="itemType">the item type</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public QuestionAnswerContent(string label, int index, string uniqueId, ContentType contentType, ItemType itemType, string overrideControlPrefix = null)
            : base()
        {
            this.Label = label;
            this.Index = index;
            this.UniqueId = uniqueId;
            this.ContentType = contentType;
            this.ItemType = itemType;
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            ContentLabel = new WebElementWrapper(ByContentLabel());
            ContentAdd = new WebElementWrapper(ByContentAdd());
            ContentEdit = new WebElementWrapper(ByContentEdit());
            ContentRemove = new WebElementWrapper(ByContentRemove());
            ChoiceCanBeUsedSelect = new SelectElementWrapper(new WebElementWrapper(ByChoiceCanBeUsedSelect()));
        }
        /// <summary>
        /// labele
        /// </summary>
        public string Label { get; private set; }
        /// <summary>
        /// index
        /// </summary>
        public int Index { get; private set; }
        /// <summary>
        /// unique ID
        /// </summary>
        public string UniqueId { get; private set; }
        /// <summary>
        /// content type
        /// </summary>
        private ContentType ContentType { get; set; }
        /// <summary>
        /// item type
        /// </summary>
        private ItemType ItemType { get; set; }

        /// <summary>
        /// The Question Stem, Answer Choice, Available Choice field or label, ie. 1, 2, 3, A, B, C, D.
        /// </summary>
        public WebElementWrapper ContentLabel { get; private set; }

        /// <summary>
        /// The "Click to add content" label to add content.
        /// </summary>
        public WebElementWrapper ContentAdd { get; private set; }

        /// <summary>
        /// The "Click to add content" label or text box to edit content. 
        /// </summary>
        public WebElementWrapper ContentEdit { get; private set; }

        /// <summary>
        /// The remove line link.
        /// </summary>
        public WebElementWrapper ContentRemove { get; private set; }

        /// <summary>
        /// The "This answer choice can be used 'n' time(s)" select/dropdown.
        /// </summary>
        public SelectElementWrapper ChoiceCanBeUsedSelect { get; private set; }

        /// <summary>
        /// The Question Stem, Answer Choice, Available Choice field or label by
        /// </summary>
        /// <returns>By</returns>
        public By ByContentLabel()
        {
            By by = null;
            switch (this.ContentType)
            {
                case ContentType.AnswerChoice:
                    if ((ItemType == ItemType.MultipleChoice) || (ItemType == ItemType.TrueFalse))
                    {
                        by = By.Id(ControlPrefix + "EditTestItemControl_RepeaterAnswers_" + this.UniqueId + "_txtAnswerLabel");
                    }
                    if (ItemType == ItemType.InlineResponse)
                    {
                        by = By.Id(ControlPrefix + "EditTestItemControl_RepeaterClozeStemAnswers_" + this.UniqueId + "_txtAnswerLabel");
                    }
                    if (ItemType == ItemType.DragAndDrop)
                    {
                        by = By.CssSelector(".tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + Index + ") .AnswerLabel");
                    }
                    if (ItemType == ItemType.HotSpotSingleSelection)
                    {
                        by = By.CssSelector("#tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + Index + ") .AnswerLabel");
                    }
                    break;
                case ContentType.AvailableChoice:
                    if (ItemType == ItemType.Matching)
                    {
                        by = By.Id(ControlPrefix + "EditTestItemControl_choicesRepeator_" + this.UniqueId + "_txtChoiceLabel");
                    }
                    if (ItemType == ItemType.DragAndDrop)
                    {
                        by = By.CssSelector(".listChoices li[data-ng-repeat='choice in TestItem.Choices']:nth-of-type(" + Index + ") .AnswerLabel");
                    }
                    break;
                case ContentType.QuestionStem:
                    by = By.Id(ControlPrefix + "EditTestItemControl_stemRepeator_" + this.UniqueId + "_txtStemLabel");
                    break;
                case ContentType.TargetContainer:
                    by = By.CssSelector(".listChoices li[data-ng-repeat='container in TestItem.Containers']:nth-of-type(" + Index + ") .AnswerLabel");
                    break;
            }
            return by;
        }

        /// <summary>
        /// The "Click to add content" label to add content by
        /// </summary>
        /// <returns>By</returns>
        public By ByContentAdd()
        {
            By by = null;
            switch (this.ContentType)
            {
                case ContentType.AnswerChoice:
                    if ((ItemType == ItemType.MultipleChoice) || (ItemType == ItemType.TrueFalse))
                    {
                        by = By.Id("divNoAnswerContent" + this.Index);
                    }
                    if (ItemType == ItemType.InlineResponse)
                    {
                        by = By.Id(ControlPrefix + "EditTestItemControl_RepeaterClozeStemAnswers_" + this.UniqueId + "_txtAnswerContent");
                    }
                    if (ItemType == ItemType.DragAndDrop)
                    {
                        by = By.CssSelector(".tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + Index + ") div[data-ng-bind-html-unsafe]");
                    }
                    if (ItemType == ItemType.HotSpotSingleSelection)
                    {
                        by = By.CssSelector("#tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + Index + ") ..itemContent > #divNoanswer0A");
                    }
                    break;
                case ContentType.AvailableChoice:
                    if (ItemType == ItemType.Matching)
                    {
                        by = By.Id("divNoMatchChoiceContent" + this.Index);
                    }
                    if (ItemType == ItemType.DragAndDrop)
                    {
                        by = By.CssSelector(".listChoices li[data-ng-repeat='choice in TestItem.Choices']:nth-of-type(" + Index + ") .itemContent");
                    }
                    break;
                case ContentType.QuestionStem:
                    by = By.Id("divNoMatchStemContent" + this.Index);
                    break;
                case ContentType.TargetContainer:
                    by = By.CssSelector(".listChoices li[data-ng-repeat='container in TestItem.Containers']:nth-of-type(" + this.Index + ") .itemContent");
                    break;
            }
            return by;
        }

        /// <summary>
        /// The "Click to add content" label or text box to edit content by
        /// </summary>
        /// <returns>By</returns>
        public By ByContentEdit()
        {
            By by = null;
            switch (this.ContentType)
            {
                case ContentType.AnswerChoice:
                    if ((ItemType == ItemType.MultipleChoice) || (ItemType == ItemType.TrueFalse))
                    {
                        by = By.Id("divAnswerContent" + this.Index);
                    }
                    if (ItemType == ItemType.InlineResponse)
                    {
                        by = By.Id(ControlPrefix + "EditTestItemControl_RepeaterClozeStemAnswers_" + this.UniqueId + "_txtAnswerContent");
                    }
                    if (ItemType == ItemType.DragAndDrop)
                    {
                        //15.4
                        //by = By.CssSelector(".tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + Index + ") div[data-ng-bind-html-unsafe]");
                        //16.0
                        by = By.CssSelector(".tab-pane.ng-scope.active .listChoices li[data-ng-repeat='tabChoice in tab.AllChoices']:nth-of-type(" + Index + ") div[data-ng-bind-html]");
                    }
                    if (ItemType == ItemType.HotSpotSingleSelection)
                    {
                        by = By.CssSelector("#tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + Index + ") ..itemContent > #divanswer0A");
                    }
                    break;
                case ContentType.AvailableChoice:
                    if (ItemType == ItemType.Matching)
                    {
                        by = By.Id("divMatchChoiceContent" + this.Index);
                    }
                    if (ItemType == ItemType.DragAndDrop)
                    {
                        by = By.CssSelector(".listChoices li[data-ng-repeat='choice in TestItem.Choices']:nth-of-type(" + Index + ") .itemContent");
                    }
                    break;
                case ContentType.QuestionStem:
                    by = By.Id("divMatchStemContent" + this.Index);
                    break;
                case ContentType.TargetContainer:
                    by = By.CssSelector(".listChoices li[data-ng-repeat='container in TestItem.Containers']:nth-of-type(" + this.Index + ") .itemContent");
                    break;
            }
            return by;
        }

        /// <summary>
        /// The remove line link by
        /// </summary>
        /// <returns>By</returns>
        public By ByContentRemove()
        {
            By by = null;
            switch (this.ContentType)
            {
                case ContentType.AnswerChoice:
                    if ((ItemType == ItemType.MultipleChoice) || (ItemType == ItemType.TrueFalse))
                    {
                        by = By.Id(ControlPrefix + "EditTestItemControl_RepeaterAnswers_" + this.UniqueId + "_LinkButton1");
                    }
                    if (ItemType == ItemType.InlineResponse)
                    {
                        by = By.Id(ControlPrefix + "EditTestItemControl_RepeaterClozeStemAnswers_" + this.UniqueId + "_DelClozeChoice");
                    }
                    if (ItemType == ItemType.DragAndDrop)
                    {
                        by = By.CssSelector("");
                    }
                    if (ItemType == ItemType.HotSpotSingleSelection)
                    {
                        by = By.CssSelector("#tblAnswers tbody[ng-repeat='answer in TestItem.Answers']:nth-of-type(" + Index + ") .pull-right > a");
                    }
                    break;
                case ContentType.AvailableChoice:
                    if (ItemType == ItemType.Matching)
                    {
                        by = By.Id(ControlPrefix + "EditTestItemControl_choicesRepeator_" + this.UniqueId + "_lnkDeleteChoice");
                    }
                    if (ItemType == ItemType.DragAndDrop)
                    {
                        by = By.CssSelector(".listChoices li[data-ng-repeat='choice in TestItem.Choices']:nth-of-type(" + Index + ") a");
                    }
                    break;
                case ContentType.QuestionStem:
                    by = By.Id(ControlPrefix + "EditTestItemControl_stemRepeator_" + this.UniqueId + "_lnkDeleteStem");
                    break;
                case ContentType.TargetContainer:
                    by = By.CssSelector(".listChoices li[data-ng-repeat='container in TestItem.Containers']:nth-of-type(" + this.Index + ") a");
                    break;
            }
            return by;
        }

        /// <summary>
        /// The "This answer choice can be used 'n' time(s)" select/dropdown by
        /// </summary>
        /// <returns>By</returns>
        public By ByChoiceCanBeUsedSelect()
        {
            By by = null;
            switch (this.ContentType)
            {
                case ContentType.AnswerChoice:
                    break;
                case ContentType.AvailableChoice:
                    if (ItemType == ItemType.DragAndDrop)
                    {
                        by = By.CssSelector(".listChoices li[data-ng-repeat='choice in TestItem.Choices']:nth-of-type(" + Index + ") select");
                    }
                    break;
                case ContentType.QuestionStem:
                    break;
                case ContentType.TargetContainer:
                    break;
            }
            return by;
        }
    }
}
