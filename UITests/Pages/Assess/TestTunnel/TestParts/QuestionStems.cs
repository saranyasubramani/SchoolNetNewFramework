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
    /// represents the question stems in the online test tunnel page
    /// </summary>
    public class QuestionStems : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public QuestionStems( )
            : base()
        {
            QuestionGrid = new WebElementWrapper(ByQuestionGrid);
            QuestionContentRows = new WebElementWrapper(ByQuestionContentRows);
        }

        private By ByQuestionGrid { get { return By.ClassName("matchQuestions"); } }
        private WebElementWrapper QuestionGrid { get; set; }
        private By ByQuestionContentRows { get { return By.CssSelector(".matchQuestions tr > td p"); } }
        private WebElementWrapper QuestionContentRows { get; set; }
        private ReadOnlyCollection<IWebElement> QuestionContentWebElementList { get; set; }
        private List<QuestionLineItem> QuestionStemList { get; set; }

        /// <summary>
        /// sets the question stem list.
        /// </summary>
        /// <param name="questionStem">list of question stems</param>
        public void SetQuestionStemList(List<string> questionStem)
        {
            QuestionStemList = new List<QuestionLineItem>();
            QuestionGrid.Wait(3);
            QuestionContentWebElementList = QuestionContentRows.WaitForElements(5);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy1 = new DummyWebElement();
                dummy1.Text = "banana";
                DummyWebElement dummy2 = new DummyWebElement();
                dummy2.Text = "carrot";
                DummyWebElement dummy3 = new DummyWebElement();
                dummy3.Text = "eggplant";
                List<IWebElement> list = new List<IWebElement> { dummy1, dummy2, dummy3 };
                QuestionContentWebElementList = new ReadOnlyCollection<IWebElement>(list);
            }

            foreach (var webElement in QuestionContentWebElementList)
            {
                string question = webElement.Text.Trim();
                if (questionStem.Contains(question))
                {
                    int index = 1 + questionStem.IndexOf(question);
                    Report.Write("QuestionLineItem index: '" + index + "'; question: '" + question);
                    var questionLineItem = new QuestionLineItem( index, question);
                    QuestionStemList.Add(questionLineItem);
                }
                else
                {
                    throw new Exception("Expected to find the question: '" + question + "', but it does not exist in the question parts.");
                }
            }
        }

        /// <summary>
        /// sets the question stem list.
        /// </summary>
        public void SetQuestionStemList()
        {
            QuestionStemList = new List<QuestionLineItem>();
            QuestionGrid.Wait(3);
            QuestionContentWebElementList = QuestionContentRows.WaitForElements(5);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy1 = new DummyWebElement();
                dummy1.Text = "banana";
                DummyWebElement dummy2 = new DummyWebElement();
                dummy2.Text = "carrot";
                DummyWebElement dummy3 = new DummyWebElement();
                dummy3.Text = "eggplant";
                List<IWebElement> list = new List<IWebElement> { dummy1, dummy2, dummy3 };
                QuestionContentWebElementList = new ReadOnlyCollection<IWebElement>(list);
            }

            int index = 0;
            foreach (var webElement in QuestionContentWebElementList)
            {
                string question = webElement.Text.Trim();
                Report.Write("QuestionLineItem index: '" + index + "'; question: '" + question);
                var questionLineItem = new QuestionLineItem( index, question);
                QuestionStemList.Add(questionLineItem);
                index++;
            }
        }

        /// <summary>
        /// gets the question stem list
        /// </summary>
        /// <returns></returns>
        public List<QuestionLineItem> GetQuestionStemList()
        {
            return QuestionStemList;
        }

        /// <summary>
        /// select a matching question/answer pair
        /// </summary>
        /// <param name="questionIndex">the question's index</param>
        /// <param name="answerIndex">the answer's index</param>
        public void SelectMatchingPair(int questionIndex, int answerIndex)
        {
            QuestionStemList[questionIndex].StemSelect.SelectByValue(Convert.ToString(answerIndex));
        }

        /// <summary>
        /// get the question's index
        /// </summary>
        /// <param name="stem">the question stem</param>
        /// <returns>the index</returns>
        public int GetQuestionIndex(string stem)
        {
            int index = -1;
            foreach (var questionStem in QuestionStemList)
            {
                if (questionStem.StemContent.Equals(stem))
                {
                    index = questionStem.Index;
                    break;
                }
            }
            return index;
        }
    }
}
