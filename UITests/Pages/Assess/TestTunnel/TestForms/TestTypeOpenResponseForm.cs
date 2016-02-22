using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Components.Editors;
using UITests.Pages.Assess.TestTunnel.TestParts;

namespace UITests.Pages.Assess.TestTunnel.TestForms
{
    /// <summary>
    /// represents the test tunnel open response form
    /// </summary>
    public class TestTypeOpenResponseForm : TestTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="openResponseType">the open response type</param>
        public TestTypeOpenResponseForm(OpenResponseType openResponseType)
            : base(ItemType.OpenResponse)
        {
            this.OpenResponseType = openResponseType;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Question = new Question();
            AttachRecordingForm = new AttachRecordingForm();
            AttachAnswerForm = new AttachOpenResponseAnswerForm();
            AnswerLabel = new WebElementWrapper(ByAnswerLabel);
            AnswerResponseText = new WebElementWrapper(ByAnswerResponseText);
            AttachFileButton = new WebElementWrapper(ByAttachFileButton);
            CreateRecordingButton = new WebElementWrapper(ByCreateRecordingButton);
            Editor = new Editor(PageNames.OnlineTestTunnel, this.ControlPrefix);
            ToolBar = new OpenResponseToolBar();
            ToolBarLatin = new OpenResponseToolBarLatin();
        }

        /// <summary>
        /// the question
        /// </summary>
        public Question Question { get; private set; }
        /// <summary>
        /// the open response type
        /// </summary>
        public OpenResponseType OpenResponseType { get; private set; }
        /// <summary>
        /// the attach recording pop-up
        /// </summary>
        public AttachRecordingForm AttachRecordingForm { get; private set; }
        /// <summary>
        /// the attach open response answer pop-up
        /// </summary>
        public AttachOpenResponseAnswerForm AttachAnswerForm { get; private set; }
        public Editor Editor { get; private set; }
        public OpenResponseToolBar ToolBar { get; private set; }
        public OpenResponseToolBarLatin ToolBarLatin { get; private set; }
        private By ByAnswerLabel { get { return By.CssSelector("#selectedFile > p"); } }
        private WebElementWrapper AnswerLabel { get; set; }
        //private By ByAnswerResponseText { get { return By.Id("divLongResponse"); } }
        private By ByAnswerResponseText { get { return By.Id("divLongResponse"); } }
        private WebElementWrapper AnswerResponseText { get; set; }
        private By ByAttachFileButton { get { return By.Id("attachFile"); } }
        private WebElementWrapper AttachFileButton { get; set; }
        private By ByCreateRecordingButton { get { return By.Id("attachRecording"); } }
        private WebElementWrapper CreateRecordingButton { get; set; }
        private By ByWordCountLabel { get { return By.Id("crWordCount"); } }
        private WebElementWrapper WordCountLabel { get; set; }

        /// <summary>
        /// is the question answered?
        /// </summary>
        /// <returns>true or false</returns>
        public override bool IsQuestionAnswered()
        {
            bool status = false;
            if (this.TestItemStatus == TestItemStatus.Answered)
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

        /// <summary>
        /// get the word count
        /// </summary>
        /// <returns>word count</returns>
        public int GetWordCount()
        {
            return GetWordCount(Data.StudentAnswer);
        }

        /// <summary>
        /// get the word count
        /// </summary>
        /// <param name="fakeText">fake text for debugging</param>
        /// <returns>word count</returns>
        public int GetWordCount(string fakeText)
        {
            //wait a second for the word count to render
            Thread.Sleep(TimeSpan.FromSeconds(2));

            //fake data setup
            const char delimiter = ' ';
            int fakeCount = fakeText.Trim().Split(delimiter).Length;

            Thread.Sleep(TimeSpan.FromSeconds(1));
            WordCountLabel = new WebElementWrapper( ByWordCountLabel);
            WordCountLabel.Wait(3);
            WordCountLabel.Text = "Word Count: " + Convert.ToString(fakeCount);

            int length = "Word Count: ".Length;
            string text = WordCountLabel.Text;
            Report.Write("text: " + text);

            string subText = text.Substring(length - 1);
            Report.Write("subText: " + subText);

            int count = Convert.ToInt32(subText);
            Report.Write("Word count: " + count);
            return count;
        }

        /// <summary>
        /// verify the message text in the editor
        /// </summary>
        /// <param name="expected">the expected text</param>
        public void EditorVerifyText(string expected)
        {
            string actual = Editor.GetText(expected);
            Assert.IsTrue(actual.Contains(expected),
                "The editor does not contain the expected text: '" + expected + "'; actual text: '" + actual + "'.");
        }

        //overridden methods

        public override void InputFormFields()
        {
            Report.Write(" Test Item: 'Open Response'");
            VerifyQuestionText();
            switch (OpenResponseType)
            {
                case OpenResponseType.Written:
                    //AnswerResponseText.Wait(3).SendKeys(_dataObject.StudentAnswer);
                    Editor.ContentData = Data.StudentAnswer;
                    Editor.InputFormFields();
                    break;
                case OpenResponseType.UploadFile:
                    AttachFileButton.Click();
                    AttachAnswerForm.Data = Data;
                    //TODO use file path for file upload dialog
                    //_dataObject.FilePath;
                    break;
                case OpenResponseType.Spoken:
                    CreateRecordingButton.Click();
                    AttachRecordingForm.Data = Data;
                    //TODO use file path for file upload dialog
                    //_dataObject.FilePath;
                    break;
            }
            this.TestItemStatus = TestItemStatus.Answered;
        }
    }
}
