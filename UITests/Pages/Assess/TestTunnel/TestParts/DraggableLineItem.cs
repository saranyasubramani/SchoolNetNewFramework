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
    /// represents the test tunnel drag and drop form: draggable question choice line item
    /// </summary>
    public class DraggableLineItem : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="key">the line item's key</param>
        /// <param name="choiceContent">the draggable choice content</param>
        public DraggableLineItem(  string key, string choiceContent)
            : base()
        {
            Key = key;
            ChoiceContent = choiceContent;
            QuestionChoice = new WebElementWrapper( ByQuestionChoice);
        }

        /// <summary>
        /// the line item's key
        /// </summary>
        public string Key { get; private set; }
        /// <summary>
        /// the line item's draggable choice content
        /// </summary>
        public string ChoiceContent { get; private set; }

        private By ByQuestionChoice { get { return By.CssSelector("li[data-key='" + Key + "']"); } }
        /// <summary>
        /// the line item question choice
        /// </summary>
        public WebElementWrapper QuestionChoice { get; private set; }
    }
}
