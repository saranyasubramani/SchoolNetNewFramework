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
    /// represents the test tunnel click stick click drop form
    /// </summary>
    public class TestTypeClickStickClickDropForm : TestTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TestTypeClickStickClickDropForm( )
            : base( ItemType.ClickStickClickDrop)
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Question = new Question();
            AnswerChoices = new DraggableChoices();
            QuestionChoices = new DroppableChoices();
        }

        /// <summary>
        /// the question
        /// </summary>
        public Question Question { get; private set; }
        /// <summary>
        /// the draggable question choices
        /// </summary>
        public DraggableChoices AnswerChoices { get; private set; }
        /// <summary>
        /// the droppable answer choices
        /// </summary>
        public DroppableChoices QuestionChoices { get; private set; }

        /// <summary>
        /// verifies the question text
        /// </summary>
        public void VerifyQuestionText()
        {
            Question.VerifyQuestionText(Data.QuestionContent);
        }

        /// <summary>
        /// click the answer and click on the question
        /// </summary>
        /// <param name="clickAnswer">the answer to click</param>
        /// <param name="clickQuestion">the question to click on</param>
        public void ClickAnswerAndClickOnQuestion(DraggableLineItem clickAnswer, DroppableLineItem clickQuestion)
        {
            clickQuestion.GetQuestionChoiceList().Add(clickAnswer);
            clickAnswer.QuestionChoice.Wait(3).Click();
            clickQuestion.AnswerChoice.Wait(3).Click();
        }

        /// <summary>
        /// click the answers and click on the questions
        /// </summary>
        public void ClickAnswersAndClickOnQuestions()
        {
            QuestionChoices.SetQuestionChoiceList();
            AnswerChoices.SetAnswerChoiceList();
            foreach (var question in Data.QuestionList)
            {
                DroppableLineItem clickQuestion = QuestionChoices.GetQuestionLineItem(question);
                List<string> answerList = Data.StudentAnswerTree[question];
                foreach (var answer in answerList)
                {
                    DraggableLineItem clickAnswer = AnswerChoices.GetAnswerLineItem(answer);
                    Report.Write("question: '" + question + "'; clickQuestion.Key: '" + clickQuestion.Key
                        + "'; answer: '" + answer + "'; clickAnswer.Key: '" + clickAnswer.Key);
                    ClickAnswerAndClickOnQuestion(clickAnswer, clickQuestion);
                }
            }
        }

        /// <summary>
        /// is the question dropped on the answer?
        /// </summary>
        /// <param name="clickQuestion">the clicked question</param>
        /// <param name="clickAnswer">the answer clicked on</param>
        public void IsQuestionDroppedOnAnswer(DraggableLineItem clickQuestion, DroppableLineItem clickAnswer)
        {
            clickAnswer.IsQuestionDroppedOnAnswer(clickQuestion);
        }

        //overridden methods

        public override void InputFormFields()
        {
            Report.Write(" Test Item: 'Click Stick Click Drop'");
            VerifyQuestionText();
            ClickAnswersAndClickOnQuestions();
            this.TestItemStatus = TestItemStatus.Answered;
        }
    }
}
