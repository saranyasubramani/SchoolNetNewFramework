using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestTunnel.TestParts
{
    /// <summary>
    /// represents the test tunnel drag and drop form: draggable answer choices
    /// </summary>
    public class DraggableChoices : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public DraggableChoices( )
            : base()
        {
            AnswerChoiceGrid = new WebElementWrapper( ByAnswerChoiceGrid);
            AnswerChoiceRows = new WebElementWrapper( ByAnswerChoiceRows);
        }

        private By ByAnswerChoiceGrid { get { return By.CssSelector(".dad-wrapper"); } }
        private WebElementWrapper AnswerChoiceGrid { get; set; }
        private By ByAnswerChoiceRows { get { return By.CssSelector(".choice"); } }
        private WebElementWrapper AnswerChoiceRows { get; set; }
        private ReadOnlyCollection<IWebElement> AnswerChoiceWebElementList { get; set; }
        /// <summary>
        /// a list of question choices
        /// </summary>
        public List<DraggableLineItem> AnswerChoiceList { get; private set; }

        private ReadOnlyCollection<IWebElement> GetDummyIdentifiers()
        {
            ReadOnlyCollection<IWebElement> webElements = null;
            List<IWebElement> list = new List<IWebElement>();
            DummyWebElement dummy1 = new DummyWebElement();
            DummyWebElement dummy2 = new DummyWebElement();
            DummyWebElement dummy3 = new DummyWebElement();
            DummyWebElement dummy4 = new DummyWebElement();
            dummy1.FakeAttributeDataKey = "A";
            dummy1.Text = "apple";
            dummy2.FakeAttributeDataKey = "B";
            dummy2.Text = "strawberry";
            dummy3.FakeAttributeDataKey = "C";
            dummy3.Text = "grape";
            dummy4.FakeAttributeDataKey = "D";
            dummy4.Text = "banana";
            list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4 };
            webElements = new ReadOnlyCollection<IWebElement>(list);
            return webElements;
        }

        /// <summary>
        /// sets the answer choice list
        /// </summary>
        public void SetAnswerChoiceList()
        {
            AnswerChoiceList = new List<DraggableLineItem>();
            AnswerChoiceGrid.Wait(3);
            AnswerChoiceWebElementList = AnswerChoiceRows.WaitForElements(5);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                AnswerChoiceWebElementList = GetDummyIdentifiers();
            }

            foreach (var webElement in AnswerChoiceWebElementList)
            {
                string key = webElement.GetAttribute("data-key");
                string answer = webElement.Text.Trim();
                Report.Write("DraggableLineItem data-key: '" + key + "'; answer: '" + answer);
                var draggableLineItem = new DraggableLineItem( key, answer);
                AnswerChoiceList.Add(draggableLineItem);
            }
        }

        /// <summary>
        /// get the answer's line item
        /// </summary>
        /// <param name="choice">the answer choice</param>
        /// <returns>the Draggable Line Item</returns>
        public DraggableLineItem GetAnswerLineItem(string choice)
        {
            DraggableLineItem draggableLineItem = null;
            foreach (var answerChoice in AnswerChoiceList)
            {
                if (answerChoice.ChoiceContent.Equals(choice))
                {
                    draggableLineItem = answerChoice;
                    break;
                }
            }
            return draggableLineItem;
        }
    }
}
