using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Assess.TestTunnel.TestParts;

namespace UITests.Pages.Assess.TestTunnel.TestForms
{
    /// <summary>
    /// represents the test tunnel matching form
    /// </summary>
    public class TestTypeMatchingForm : TestTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TestTypeMatchingForm()
            : base(ItemType.Matching)
        {
            InitElements();
        }

        public override void InitElements()
        {
            Question = new Question();
            QuestionStems = new QuestionStems();
            AnswerChoices = new AnswerChoices(ItemType.Matching);
        }

        /// <summary>
        /// the question
        /// </summary>
        public Question Question { get; private set; }
        /// <summary>
        /// the question stems
        /// </summary>
        public QuestionStems QuestionStems { get; private set; }
        /// <summary>
        /// the answer choices
        /// </summary>
        public AnswerChoices AnswerChoices { get; private set; }

        /// <summary>
        /// verifies the question text
        /// </summary>
        public void VerifyQuestionText()
        {
            Question.VerifyQuestionText(Data.QuestionContent);
        }

        /// <summary>
        /// select a matching question/answer pair
        /// </summary>
        public void SelectMatchingPair()
        {
            QuestionStems.SetQuestionStemList();
            AnswerChoices.SetAnswerChoiceList();
            foreach (var question in Data.QuestionList)
            {
                string answer = Data.StudentAnswerPair[question];
                int questionIndex = QuestionStems.GetQuestionIndex(question);
                int answerIndex = AnswerChoices.GetAnswerIndex(answer);
                Report.Write("question: '" + question + "'; questionIndex: '" + questionIndex 
                    + "'; answer: '" + answer + "'; answerIndex: '" + answerIndex);
                QuestionStems.SelectMatchingPair(questionIndex, answerIndex);
            }
        }

        //overridden methods

        public override void InputFormFields()
        {
            Report.Write(" Test Item: 'Matching'");
            VerifyQuestionText();
            SelectMatchingPair();
            this.TestItemStatus = TestItemStatus.Answered;
        }
    }
}
