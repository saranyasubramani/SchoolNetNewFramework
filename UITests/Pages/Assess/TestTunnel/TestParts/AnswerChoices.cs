using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.TestTunnel.TestParts
{
    /// <summary>
    /// represents the answer choices in the online test tunnel page
    /// </summary>
    public class AnswerChoices : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="itemType">the item type</param>
        public AnswerChoices(ItemType itemType)
            : base()
        {
            ItemType = itemType;
            AnswerChoiceGrid = new WebElementWrapper(ByAnswerChoiceGrid);
            AnswerContentRows = new WebElementWrapper(ByAnswerContentRows);
        }

        /// <summary>
        /// the item type
        /// </summary>
        public ItemType ItemType { get; private set; }
        /// <summary>
        /// the current status of the test item
        /// </summary>
        public TestItemStatus TestItemStatus { get; set; }
        private By ByAnswerChoiceGrid { get { return AnswerGridLocator(); } }
        private WebElementWrapper AnswerChoiceGrid { get; set; }
        private By ByAnswerContentRows { get { return AnswerContentRowsLocator(); } }
        private WebElementWrapper AnswerContentRows { get; set; }
        private ReadOnlyCollection<IWebElement> AnswerContentWebElementList { get; set; }
        private List<AnswerLineItem> AnswerChoiceList { get; set; }

        private By AnswerGridLocator()
        {
            By by = null;
            switch (ItemType)
            {
                case ItemType.Matching:
                    by = By.ClassName("matchAnswers");
                    break;
                case ItemType.MultipleChoice:
                    by = By.ClassName("AnswerChoice");
                    break;
                case ItemType.TrueFalse:
                    by = By.ClassName("AnswerChoice");
                    break;
            }
            return by;
        }

        private By AnswerContentRowsLocator()
        {
            By by = null;
            switch (ItemType)
            {
                case ItemType.Matching:
                    by = By.CssSelector(".matchAnswerContent > div > p");
                    break;
                case ItemType.MultipleChoice:
                    by = By.CssSelector(".AnswerChoice > span:not([aria-labelledby])");
                    break;
                case ItemType.TrueFalse:
                    by = By.CssSelector(".AnswerChoice > span:not([aria-labelledby])");
                    break;
            }
            return by;
        }

        private ReadOnlyCollection<IWebElement> GetDummyIdentifiers()
        {
            ReadOnlyCollection<IWebElement> webElements = null;
            List<IWebElement> list = new List<IWebElement>();
            DummyWebElement dummy1 = new DummyWebElement();
            DummyWebElement dummy2 = new DummyWebElement();
            DummyWebElement dummy3 = new DummyWebElement();
            DummyWebElement dummy4 = new DummyWebElement();
            DummyWebElement dummy5 = new DummyWebElement();
            DummyWebElement dummy6 = new DummyWebElement();
            DummyWebElement dummy7 = new DummyWebElement();
            DummyWebElement dummy8 = new DummyWebElement();
            DummyWebElement dummy9 = new DummyWebElement();
            switch (ItemType)
            {
                case ItemType.InlineResponse:
                    dummy1.FakeAttributeValue = "A";
                    dummy2.FakeAttributeValue = "B";
                    dummy3.FakeAttributeValue = "C";

                    list = new List<IWebElement> { dummy1, dummy2, dummy3 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
                case ItemType.Matching:
                    dummy1.Text = "blue";
                    dummy2.Text = "purple";
                    dummy3.Text = "yellow";
                    dummy4.Text = "orange";

                    list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
                case ItemType.MultipleChoice:
                    dummy1.Text = "blue";
                    dummy2.Text = "purple";
                    dummy3.Text = "yellow";
                    dummy4.Text = "orange";

                    list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
                case ItemType.TrueFalse:
                    dummy1.Text = "True";
                    dummy2.Text = "False";

                    list = new List<IWebElement> { dummy1, dummy2 };
                    webElements = new ReadOnlyCollection<IWebElement>(list);
                    break;
            }
            return webElements;
        }

        /// <summary>
        /// sets the answer choice list
        /// </summary>
        /// <param name="answerChoice">list of answer choices</param>
        public void SetAnswerChoiceList(List<string> answerChoice)
        {
            AnswerChoiceList = new List<AnswerLineItem>();
            AnswerChoiceGrid.Wait(3);
            AnswerContentWebElementList = AnswerContentRows.WaitForElements(5);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                AnswerContentWebElementList = GetDummyIdentifiers();
            }

            if (ItemType == ItemType.TrueFalse)
            {
                answerChoice = new List<string>() { "True", "False" };
            }

            foreach (var webElement in AnswerContentWebElementList)
            {
                string answer = webElement.Text.Trim();
                if (answerChoice.Contains(answer))
                {
                    int index = answerChoice.IndexOf(answer);
                    Report.Write("AnswerLineItem index: '" + index + "'; question: '" + answer);
                    var answerLineItem = new AnswerLineItem( ItemType, index, answer);
                    AnswerChoiceList.Add(answerLineItem);
                }
                else
                {
                    throw new Exception("Expected to find the answer: '" + answer + "', but it does not exist in the answer choices.");
                }
            }
        }

        /// <summary>
        /// sets the answer choice list
        /// </summary>
        public void SetAnswerChoiceList()
        {
            AnswerChoiceList = new List<AnswerLineItem>();
            AnswerChoiceGrid.Wait(3);
            AnswerContentWebElementList = AnswerContentRows.WaitForElements(5);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                AnswerContentWebElementList = GetDummyIdentifiers();
            }

            int index = 0;
            foreach (var webElement in AnswerContentWebElementList)
            {
                string answer = webElement.Text.Trim();
                Report.Write("AnswerLineItem index: '" + index + "'; question: '" + answer);
                var answerLineItem = new AnswerLineItem( ItemType, index, answer);
                AnswerChoiceList.Add(answerLineItem);
                index++;
            }
        }

        /// <summary>
        /// gets the answer choice list
        /// </summary>
        /// <returns>list of answer line item</returns>
        public List<AnswerLineItem> GetAnswerChoiceList()
        {
            return AnswerChoiceList;
        }

        /// <summary>
        /// hide the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void HideAnswer(int index)
        {
            AnswerChoiceList[index].HideShowLink.Text = "Hide";
            if (AnswerChoiceList[index].HideShowLink.Text.Trim().Equals("Hide"))
            {
                AnswerChoiceList[index].HideShowLink.Click();
            }
        }

        /// <summary>
        /// show the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void ShowAnswer(int index)
        {
            AnswerChoiceList[index].HideShowLink.Text = "Show";
            if (AnswerChoiceList[index].HideShowLink.Text.Trim().Equals("Show"))
            {
                AnswerChoiceList[index].HideShowLink.Click();
            }
        }

        /// <summary>
        /// is the answer hidden?
        /// </summary>
        /// <param name="index">the answer's index</param>
        /// <param name="fakeText">Fake text for debugging purposes only. Values are either "Hide" or "Show". Defaults to "Hide".</param>
        /// <returns>true or false</returns>
        public bool IsAnswerHidden(int index, string fakeText = "Hide")
        {
            AnswerChoiceList[index].HideShowLink.Text = fakeText;
            return AnswerChoiceList[index].HideShowLink.Text.Trim().Equals("Show");
        }

        /// <summary>
        /// select the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void SelectAnswer(int index)
        {
            AnswerChoiceList[index].AnswerLink.Click();
            AnswerChoiceList[index].TestItemStatus = TestItemStatus.Answered;
        }

        /// <summary>
        /// select the answer
        /// </summary>
        /// <param name="choice">the answer choice</param>
        public void SelectAnswer(string choice)
        {
            foreach (var answerChoice in AnswerChoiceList)
            {
                if (answerChoice.ChoiceContent.Equals(choice))
                {
                    answerChoice.AnswerLink.Click();
                    answerChoice.TestItemStatus = TestItemStatus.Answered;
                    break;
                }
            }
        }

        /// <summary>
        /// get the answer's index
        /// </summary>
        /// <param name="choice">the answer choice</param>
        /// <returns>the index</returns>
        public int GetAnswerIndex(string choice)
        {
            int index = -1;
            foreach (var answerChoice in AnswerChoiceList)
            {
                if (answerChoice.ChoiceContent.Equals(choice))
                {
                    index = answerChoice.Index;
                    break;
                }
            }
            return index;
        }
    }
}
