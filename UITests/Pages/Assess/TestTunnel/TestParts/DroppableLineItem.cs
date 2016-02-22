using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestTunnel.TestParts
{
    /// <summary>
    /// represents the test tunnel drag and drop form: droppable answer choice line item
    /// </summary>
    public class DroppableLineItem : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="key">the line item's key</param>
        /// <param name="choiceContent">the droppable choice content</param>
        public DroppableLineItem(  string key, string choiceContent)
            : base()
        {
            Key = key;
            ChoiceContent = choiceContent;
            AnswerChoice = new WebElementWrapper( ByAnswerChoice);
            QuestionChoiceList = new List<DraggableLineItem>();
        }

        /// <summary>
        /// the line item's key
        /// </summary>
        public string Key { get; private set; }
        /// <summary>
        /// the line item's droppable choice content
        /// </summary>
        public string ChoiceContent { get; private set; }

        /// <summary>
        /// the list of dragged questions dropped on the answer
        /// </summary>
        private List<DraggableLineItem> QuestionChoiceList { get; set; }

        /// <summary>
        /// gets the question choice list
        /// </summary>
        /// <returns></returns>
        public List<DraggableLineItem> GetQuestionChoiceList()
        {
            return QuestionChoiceList;
        }

        private By ByAnswerChoice { get { return By.CssSelector("li[data-key='" + Key + "']"); } }
        /// <summary>
        /// the line item answer choice
        /// </summary>
        public WebElementWrapper AnswerChoice { get; private set; }

        private By ByQuestionChoice(string questionKey)
        {
            return By.CssSelector("li[data-key='" + Key + "'] > ul > li[data-key='" + questionKey + "']");
        }
        private WebElementWrapper QuestionChoice { get; set; }

        /// <summary>
        /// is the question dropped on the answer?
        /// </summary>
        /// <param name="dragQuestion">the dragged question</param>
        public void IsQuestionDroppedOnAnswer(DraggableLineItem dragQuestion)
        {
            QuestionChoice = new WebElementWrapper( ByQuestionChoice(dragQuestion.Key));
            Assert.IsNotNull(QuestionChoice.WaitUntilVisible(3), "The question element is null, but should have been found.");
        }
    }
}
