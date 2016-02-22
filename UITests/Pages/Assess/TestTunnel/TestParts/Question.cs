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
    /// represents the question content in the online test tunnel page
    /// </summary>
    public class Question : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public Question( )
            : base()
        {
            QuestionLabel = new WebElementWrapper( ByQuestionLabel);
            QuestionGapsDropdowns = new WebElementWrapper( ByQuestionGapsDropdowns);
        }

        private By ByQuestionLabel { get { return By.CssSelector("#divRight > p, #divRight .dad-content > p"); } }
        private WebElementWrapper QuestionLabel { get; set; }

        private By ByQuestionGapsDropdowns { get { return By.CssSelector("#divRight select.Gap"); } }
        private WebElementWrapper QuestionGapsDropdowns { get; set; }

        private ReadOnlyCollection<IWebElement> QuestionGapWebElementList { get; set; }
        private List<QuestionGap> QuestionGapList { get; set; }

        /// <summary>
        /// sets the question gap list
        /// </summary>
        public void SetQuestionGapList()
        {
            QuestionGapList = new List<QuestionGap>();
            QuestionLabel.Wait(3);
            QuestionGapWebElementList = QuestionGapsDropdowns.WaitForElements(5);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                List<IWebElement> list = new List<IWebElement>();
                DummyWebElement dummy1 = new DummyWebElement();
                DummyWebElement dummy2 = new DummyWebElement();
                DummyWebElement dummy3 = new DummyWebElement();
                dummy1.FakeAttributeClass = "This morning, I went to the ";
                dummy2.FakeAttributeClass = "and bought some milk and eggs. I knew it was going to rain, but I forgot my ";
                dummy3.FakeAttributeClass = "and ended up getting ";
                list = new List<IWebElement> { dummy1, dummy2, dummy3 };
                QuestionGapWebElementList = new ReadOnlyCollection<IWebElement>(list);
            }

            int index = 0;
            foreach (var webElement in QuestionGapWebElementList)
            {
                Report.Write("QuestionGap index: '" + index);
                var answerLineItem = new QuestionGap( index);
                QuestionGapList.Add(answerLineItem);
                index++;
            }
        }

        /// <summary>
        /// gets the question gap list
        /// </summary>
        /// <returns></returns>
        public List<QuestionGap> GetQuestionGapList()
        {
            return QuestionGapList;
        }

        /// <summary>
        /// select the question gap
        /// </summary>
        /// <param name="index">the question gap's index</param>
        /// <param name="option">the dropdown/select option</param>
        public void SelectQuestionGap(int index, string option)
        {
            QuestionGapList[index].GapSelect.SelectByText(option);
        }

        /// <summary>
        /// gets the question text
        /// </summary>
        /// <returns>question text</returns>
        public string GetQuestionText()
        {
            QuestionLabel.Text = "Match the fruits and vegetables to their colors";
            return QuestionLabel.Text;
        }

        /// <summary>
        /// verifies the question text
        /// </summary>
        /// <param name="question">the question</param>
        public void VerifyQuestionText(string question)
        {
            Report.Write("Verifying the actual question does contain the expected question.");
            QuestionLabel.Text = "Match the fruits and vegetables to their colors";
            string actual = QuestionLabel.Text;
            Assert.IsTrue(actual.Contains(question), "The actual question: '" + actual + "' does not contain the expected question: '" + question + "'.");
            Report.Write("Verified the actual question: '" + actual + "' does contain the expected question: '" + question + "'.");
        }

        /// <summary>
        /// verifies the question text
        /// </summary>
        /// <param name="questionParts">the question parts</param>
        public void VerifyQuestionText(List<string> questionParts)
        {
            Report.Write("Verifying the actual question does contain the expected question.");
            QuestionLabel.Text = "This morning, I went to the " +
                "and bought some milk and eggs. I knew it was going to rain, but I forgot my " +
                "and ended up getting ";
            string actual = QuestionLabel.Text;
            foreach (var questionPart in questionParts)
            {
                Assert.IsTrue(actual.Contains(questionPart), "The actual question: '" + actual + "' does not contain the expected question: '" + questionPart + "'.");
                Report.Write("Verified the actual question: '" + actual + "' does contain the expected question: '" + questionPart + "'.");
            }
        }
    }
}
