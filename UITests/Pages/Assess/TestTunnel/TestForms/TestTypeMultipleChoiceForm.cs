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
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.TestTunnel.TestParts;

namespace UITests.Pages.Assess.TestTunnel.TestForms
{
    /// <summary>
    /// represents the test tunnel multiple choice form
    /// </summary>
    public class TestTypeMultipleChoiceForm : TestTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TestTypeMultipleChoiceForm()
            : base(ItemType.MultipleChoice)
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Question = new Question();
            AnswerChoices = new AnswerChoices(ItemType.MultipleChoice);
        }

        /// <summary>
        /// the question
        /// </summary>
        public Question Question { get; private set; }
        /// <summary>
        /// the answer choices
        /// </summary>
        public AnswerChoices AnswerChoices { get; private set; }
        public MultipleChoiceLayout Layout { get; set; }
        private By ByAnswerA { get { return By.CssSelector("#divAnswers > table > tbody > tr#tra0 > td#tda_0 > div#diva0 > span#ac0"); ; } }
        private WebElementWrapper AnswerA { get; set; }
        private By ByAnswerB { get { return AnswerBLocator(); } }
        private WebElementWrapper AnswerB { get; set; }
        private By ByAnswerC { get { return AnswerCLocator(); } }
        private WebElementWrapper AnswerC { get; set; }
        private By ByAnswerD { get { return AnswerDLocator(); } }
        private WebElementWrapper AnswerD { get; set; }

        private By AnswerBLocator()
        {
            By by = null;
            switch (Layout)
            {
                case MultipleChoiceLayout.OneColumn:
                    by = By.CssSelector("#divAnswers > table > tbody > tr#tra1 > td#tda_1 > div#diva1 > span#ac1");
                    break;
                case MultipleChoiceLayout.TwoColumnsAcrossThenDown:
                    by = By.CssSelector("#divAnswers > table > tbody > tr#tra0 > td#tda_1 > div#diva1 > span#ac1");
                    break;
                case MultipleChoiceLayout.TwoColumnsDownThenAcross:
                    by = By.CssSelector("#divAnswers > table > tbody > tr#tra1 > td#tda_1 > div#diva1 > span#ac1");
                    break;
            }
            return by;
        }

        private By AnswerCLocator()
        {
            By by = null;
            switch (Layout)
            {
                case MultipleChoiceLayout.OneColumn:
                    by = By.CssSelector("#divAnswers > table > tbody > tr#tra2 > td#tda_2 > div#diva2 > span#ac2");
                    break;
                case MultipleChoiceLayout.TwoColumnsAcrossThenDown:
                    by = By.CssSelector("#divAnswers > table > tbody > tr#tra2 > td#tda_2 > div#diva2 > span#ac2");
                    break;
                case MultipleChoiceLayout.TwoColumnsDownThenAcross:
                    by = By.CssSelector("#divAnswers > table > tbody > tr#tra0 > td#tda_2 > div#diva2 > span#ac2");
                    break;
            }
            return by;
        }

        private By AnswerDLocator()
        {
            By by = null;
            switch (Layout)
            {
                case MultipleChoiceLayout.OneColumn:
                    by = By.CssSelector("#divAnswers > table > tbody > tr#tra3 > td#tda_3 > div#diva3 > span#ac3");
                    break;
                case MultipleChoiceLayout.TwoColumnsAcrossThenDown:
                    by = By.CssSelector("#divAnswers > table > tbody > tr#tra2 > td#tda_3 > div#diva3 > span#ac3");
                    break;
                case MultipleChoiceLayout.TwoColumnsDownThenAcross:
                    by = By.CssSelector("#divAnswers > table > tbody > tr#tra1 > td#tda_3 > div#diva3 > span#ac3");
                    break;
            }
            return by;
        }

        /// <summary>
        /// verifies the question text
        /// </summary>
        public void VerifyQuestionText()
        {
            Question.VerifyQuestionText(Data.QuestionContent);
        }

        /// <summary>
        /// Verified the layout in test tunnel is either:
        /// One column down
        /// Two column across, then down
        /// Two column down, then across
        /// 
        /// This code use the answer choice D to determine the layout. This is because only D
        /// had cssSelector path that is different for the 3 layout. 
        /// </summary>
        public void VerifyLayoutInTestTunnel()
        {
            AnswerD = new WebElementWrapper(ByAnswerD);
            AnswerD.FindElement();
        }

        //overridden methods

        public override void InputFormFields()
        {
            Report.Write(" Test Item: 'Multiple Choice'");
            VerifyQuestionText();
            AnswerChoices.SetAnswerChoiceList();
            AnswerChoices.SelectAnswer(Data.StudentAnswer);
            this.TestItemStatus = TestItemStatus.Answered;
        }
    }
}
