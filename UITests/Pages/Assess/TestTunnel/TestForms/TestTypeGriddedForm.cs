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
    /// represents the test tunnel gridded form
    /// </summary>
    public class TestTypeGriddedForm : TestTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TestTypeGriddedForm()
            : base(ItemType.Gridded)
        {
            InitElements();
            /*
             * load AnswerChoices only when it is being called, so this class can be initialized before the test tunnel is invoked
             * AnswerChoices = new AnswerGrids(Driver);
            */
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
        private AnswerGrids _answerGrids;
        /// <summary>
        /// the answer choice grids
        /// </summary>
        public AnswerGrids AnswerChoices
        {
            get
            {
                if (_answerGrids == null)
                {
                    _answerGrids = new AnswerGrids();
                }
                return _answerGrids;
            }
        }

        /// <summary>
        /// is the question answered?
        /// </summary>
        /// <returns>true or false</returns>
        public override bool IsQuestionAnswered()
        {
            bool status = false;
            int count = AnswerChoices.CountAnsweredGrids();
            if (count > 0)
            {
                this.TestItemStatus = TestItemStatus.Answered;
                status = true;
            }
            return status;
        }

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
            Report.Write(" Test Item: 'Gridded'");
            VerifyQuestionText();
            //skip the 1st minus "-" column
            int index = 1;
            foreach (var answer in Data.StudentAnswerList)
            {
                AnswerChoices.InputAnswer(index, answer);
                index++;
            }
            this.TestItemStatus = TestItemStatus.Answered;
        }
    }
}
