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
    /// represents the test tunnel drag and drop form: droppable question choices
    /// </summary>
    public class DroppableChoices : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public DroppableChoices( )
            : base()
        {
            QuestionChoiceGrid = new WebElementWrapper(ByQuestionChoiceGrid);
            QuestionChoiceRows = new WebElementWrapper(ByQuestionChoiceRows);
        }

        private By ByQuestionChoiceGrid { get { return By.CssSelector(".dad-wrapper"); } }
        private WebElementWrapper QuestionChoiceGrid { get; set; }
        private By ByQuestionChoiceRows { get { return By.CssSelector(".target"); } }
        private WebElementWrapper QuestionChoiceRows { get; set; }
        private ReadOnlyCollection<IWebElement> QuestionChoiceWebElementList { get; set; }
        /// <summary>
        /// a list of answer choices
        /// </summary>
        public List<DroppableLineItem> QuestionChoiceList { get; private set; }

        private ReadOnlyCollection<IWebElement> GetDummyIdentifiers()
        {
            ReadOnlyCollection<IWebElement> webElements = null;
            List<IWebElement> list = new List<IWebElement>();
            DummyWebElement dummy1 = new DummyWebElement();
            DummyWebElement dummy2 = new DummyWebElement();
            DummyWebElement dummy3 = new DummyWebElement();
            DummyWebElement dummy4 = new DummyWebElement();
            dummy1.FakeAttributeDataKey = "1";
            dummy1.Text = "yellow";
            dummy2.FakeAttributeDataKey = "2";
            dummy2.Text = "green";
            dummy3.FakeAttributeDataKey = "3";
            dummy3.Text = "red";
            dummy4.FakeAttributeDataKey = "4";
            dummy4.Text = "blue";
            list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4 };
            webElements = new ReadOnlyCollection<IWebElement>(list);
            return webElements;
        }

        /// <summary>
        /// sets the question choice list
        /// </summary>
        public void SetQuestionChoiceList()
        {
            QuestionChoiceList = new List<DroppableLineItem>();
            QuestionChoiceGrid.Wait(3);
            QuestionChoiceWebElementList = QuestionChoiceRows.WaitForElements(5);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                QuestionChoiceWebElementList = GetDummyIdentifiers();
            }

            foreach (var webElement in QuestionChoiceWebElementList)
            {
                string key = webElement.GetAttribute("data-key");
                string question = webElement.Text.Trim();
                Report.Write("DroppableLineItem data-key: '" + key + "'; question: '" + question);
                var droppableLineItem = new DroppableLineItem( key, question);
                QuestionChoiceList.Add(droppableLineItem);
            }
        }

        /// <summary>
        /// get the question's line item
        /// </summary>
        /// <param name="choice">the question choice</param>
        /// <returns>the Droppable Line Item</returns>
        public DroppableLineItem GetQuestionLineItem(string choice)
        {
            DroppableLineItem droppableLineItem = null;
            foreach (var questionChoice in QuestionChoiceList)
            {
                if (questionChoice.ChoiceContent.Equals(choice))
                {
                    droppableLineItem = questionChoice;
                    break;
                }
            }
            return droppableLineItem;
        }
    }
}
