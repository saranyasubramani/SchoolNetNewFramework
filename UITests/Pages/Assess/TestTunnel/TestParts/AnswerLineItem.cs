using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.TestTunnel.TestParts
{
    /// <summary>
    /// represents the answer line item in the online test tunnel page
    /// </summary>
    public class AnswerLineItem : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="index">the index</param>
        /// <param name="choiceContent">the answer choice content</param>
        /// <param name="isCorrectAnswer">is the correct answer?</param>
        public AnswerLineItem(ItemType itemType, int index, string choiceContent)
            : base()
        {
            ItemType = itemType;
            Index = index;
            ChoiceContent = choiceContent;
            HideShowLink = new WebElementWrapper( ByHideShowLink);
            AnswerLink = new WebElementWrapper( ByAnswerLink);
        }

        /// <summary>
        /// the item type
        /// </summary>
        public ItemType ItemType { get; private set; }
        /// <summary>
        /// the current status of the test item
        /// </summary>
        public TestItemStatus TestItemStatus { get; set; }
        /// <summary>
        /// is this the correct answer?
        /// </summary>
        public bool IsCorrectAnswer { get; set; }
        /// <summary>
        /// the line item's index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// the line item's answer choice content
        /// </summary>
        public string ChoiceContent { get; private set; }
        private By ByHideShowLink { get { return HideShowLinkLocator(); } }
        /// <summary>
        /// the hide/show link
        /// </summary>
        public WebElementWrapper HideShowLink { get; private set; }
        private By ByAnswerLink { get { return AnswerLinkLocator(); } }
        /// <summary>
        /// the answer button/link
        /// </summary>
        public WebElementWrapper AnswerLink { get; private set; }

        private By HideShowLinkLocator()
        {
            By by = null;
            switch (ItemType)
            {
                case ItemType.Matching:
                    by = By.CssSelector("#divAnswers > span[aria-labelledby='pMatch_" + Index + "']");
                    break;
                case ItemType.MultipleChoice:
                    by = By.CssSelector(".AnswerChoice > span[aria-labelledby='pMultiple_" + Index + "']#lnkHideAnswer");
                    break;
                case ItemType.TrueFalse:
                    break;
            }
            return by;
        }

        private By AnswerLinkLocator()
        {
            By by = null;
            switch (ItemType)
            {
                case ItemType.Matching:
                    break;
                case ItemType.MultipleChoice:
                    by = By.CssSelector(".AnswerChoice > span[aria-labelledby='pMultiple_" + Index + "'][role='radio']");
                    break;
                case ItemType.TrueFalse:
                    by = By.CssSelector(".AnswerChoice > span[aria-labelledby='pMultiple_" + Index + "'][role='radio']");
                    break;
            }
            return by;
        }
    }
}
