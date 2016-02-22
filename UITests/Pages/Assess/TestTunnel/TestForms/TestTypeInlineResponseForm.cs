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
    /// represents the test tunnel inline response form
    /// </summary>
    public class TestTypeInlineResponseForm : TestTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TestTypeInlineResponseForm()
            : base(ItemType.InlineResponse)
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Question = new Question();
        }

        /// <summary>
        /// the question
        /// </summary>
        public Question Question { get; private set; }

        /// <summary>
        /// verifies the question text
        /// </summary>
        public void VerifyQuestionText()
        {
            Question.VerifyQuestionText(Data.QuestionList);
        }

        /// <summary>
        /// select the question gap
        /// </summary>
        public void SelectQuestionGap()
        {
            Question.SetQuestionGapList();
            int index = 0;
            foreach (var question in Data.QuestionList)
            {
                string answer = Data.StudentAnswerPair[question];
                Report.Write("answer: '" + answer + "'; question index: '" + index + "'; question gap: '" + question);
                Question.SelectQuestionGap(index, answer);
                index++;
            }
        }

        //overridden methods

        public override void InputFormFields()
        {
            Report.Write(" Test Item: 'Inline Response'");
            VerifyQuestionText();
            SelectQuestionGap();
            this.TestItemStatus = TestItemStatus.Answered;
        }
    }
}
