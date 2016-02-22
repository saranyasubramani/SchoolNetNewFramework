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
    /// represents the test tunnel true/false form
    /// </summary>
    public class TestTypeTrueFalseForm : TestTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TestTypeTrueFalseForm()
            : base(ItemType.TrueFalse)
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Question = new Question();
            AnswerChoices = new AnswerChoices(ItemType.TrueFalse);
        }

        /// <summary>
        /// the question
        /// </summary>
        public Question Question { get; private set; }
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

        //overridden methods

        public override void InputFormFields()
        {
            Report.Write(" Test Item: 'True/False'");
            VerifyQuestionText();
            AnswerChoices.SetAnswerChoiceList();
            AnswerChoices.SelectAnswer(Data.StudentAnswer);
            this.TestItemStatus = TestItemStatus.Answered;
        }
    }
}
