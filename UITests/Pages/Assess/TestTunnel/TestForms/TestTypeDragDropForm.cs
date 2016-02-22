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
    /// represents the test tunnel drag and drop form
    /// </summary>
    public class TestTypeDragDropForm : TestTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TestTypeDragDropForm( )
            : base( ItemType.DragAndDrop)
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
        /// drag the answer and drop it on the question
        /// </summary>
        /// <param name="dragAnswer">the answer to drag</param>
        /// <param name="dropQuestion">the question to drop on</param>
        public void DragAnswerAndDropOnQuestion(DraggableLineItem dragAnswer, DroppableLineItem dropQuestion)
        {
            dropQuestion.GetQuestionChoiceList().Add(dragAnswer);
            dragAnswer.QuestionChoice.Wait(3);
            dropQuestion.AnswerChoice.Wait(3);
            //actionbuilder code to drag and drop
            ActionsWrapper actions = new ActionsWrapper();
            actions.DragAndDrop(dragAnswer.QuestionChoice, dropQuestion.AnswerChoice).Build().Perform();
        }

        /// <summary>
        /// drag the answers and drop them onto the questions
        /// </summary>
        public void DragAnswersAndDropOnQuestions()
        {
            QuestionChoices.SetQuestionChoiceList();
            AnswerChoices.SetAnswerChoiceList();
            foreach (var question in Data.QuestionList)
            {
                DroppableLineItem dropQuestion = QuestionChoices.GetQuestionLineItem(question);
                List<string> answerList = Data.StudentAnswerTree[question];
                foreach (var answer in answerList)
                {
                    DraggableLineItem dragAnswer = AnswerChoices.GetAnswerLineItem(answer);
                    Report.Write("question: '" + question + "'; dropQuestion.Key: '" + dropQuestion.Key
                        + "'; answer: '" + answer + "'; dragAnswer.Key: '" + dragAnswer.Key);
                    DragAnswerAndDropOnQuestion(dragAnswer, dropQuestion);
                }
            }
        }

        /// <summary>
        /// is the question dropped on the answer?
        /// </summary>
        /// <param name="dragQuestion">the dragged question</param>
        /// <param name="dropAnswer">the answer dropped on</param>
        public void IsQuestionDroppedOnAnswer(DraggableLineItem dragQuestion, DroppableLineItem dropAnswer)
        {
            dropAnswer.IsQuestionDroppedOnAnswer(dragQuestion);
        }

        //overridden methods

        public override void InputFormFields()
        {
            Report.Write(" Test Item: 'Drag and Drop'");
            VerifyQuestionText();
            DragAnswersAndDropOnQuestions();
            this.TestItemStatus = TestItemStatus.Answered;
        }
    }
}
