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
using UITests.Pages.Components.Editors;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms
{
    /// <summary>
    /// the item type: true/false form
    /// </summary>
    public class ItemTypeTrueFalseForm : ItemTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemTypeTrueFalseForm(string overrideControlPrefix = null)
            : base(ItemType.TrueFalse)
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            SetUniqueControlIdentifiers();
            Editor = new Editor(PageNames.EditorPopup, this.ControlPrefix);
            QuestionContent = new WebElementWrapper(ByQuestionContent);
            QuestionContentReedit = new WebElementWrapper(ByQuestionContentReedit);
            ExpectedRequiredErrorsList = new List<string>()
            {
                "Enter content",
                "Select correct answer",
                "Not worth any points"
            };
        }

        /// <summary>
        /// a list of answer choices
        /// </summary>
        public List<AnswerChoice> AnswerChoiceList { get; private set; }
        /// <summary>
        /// a list of unique control identifiers by letter
        /// </summary>
        public Dictionary<string, string> UniqueControlIdentifiers { get; private set; }

        private By ByQuestionContent { get { return By.Id("divNoItemContent"); } }
        private WebElementWrapper QuestionContent { get; set; }
        private By ByQuestionContentReedit { get { return By.Id("divItemContent"); } }
        private WebElementWrapper QuestionContentReedit { get; set; }

        private By ByAnswerLabels { get { return By.ClassName("AnswerLabel"); } }

        /// <summary>
        /// the html editor
        /// </summary>
        public Editor Editor { get; private set; }

        private void SetUniqueControlIdentifiers()
        {
            //get a hash of the answer choice's: label and unique control identifier using WebDriver.FindElements(By.ClassName)
            UniqueControlIdentifiers = GetUniqueControlIdentifiers(ByAnswerLabels);
            AnswerChoiceList = new List<AnswerChoice>();
            //for each element in the hash
            foreach (var key in UniqueControlIdentifiers.Keys)
            {
                //is the key numeric?
                int index;
                bool isNumeric = int.TryParse(key, out index);
                if (isNumeric == false)
                {
                    //get a numeric zero based index based on the letter of the answer label
                    index = this.GetIndexByTrueFalse(key);
                    //get the unique control identifier
                    string uniqueId = UniqueControlIdentifiers[key];
                    Report.Write("Unique control identifier by key: " + key + "; index: " + index + "; ID: " + uniqueId);
                    //create an answer choice object
                    var answerChoice = new AnswerChoice(ItemType.TrueFalse, key, index, uniqueId, ControlPrefix);
                    //add the answer choice object to the collection (A, B, C, D)
                    AnswerChoiceList.Add(answerChoice);
                }
            }
        }

        //specific methods
        /// <summary>
        /// select question content
        /// </summary>
        public WebElementWrapper SelectQuestionContent()
        {
            try
            {
                QuestionContent.Wait(3).Click();
            }
            catch (Exception e)
            {
                //The first click is not happening, assume user had already input a value. 
                //When question editor had inputed value, it will show up inside another div element with different id.
                //Click on this other element.
                Report.Write("Re-attempting to click this element by: '" + QuestionContentReedit.By.ToString() + "'.");
                QuestionContentReedit.Wait(3).Click();
                return QuestionContentReedit;
            }
            return QuestionContent;
        }

        //implemented methods
        public override void InputFormFields()
        {
            WebElementWrapper questionContentElement = SelectQuestionContent();

            //QuestionAnswerData
            if (_questionAnswerDataObject != null)
            {
                Utilities.DoFileUpload(Editor, _autoItDataObject, _questionAnswerDataObject.FileUploadTree, _questionAnswerDataObject.QuestionContent);
                Editor.ContentData = _questionAnswerDataObject.QuestionContent;
            }
            else //ItemTypeData
            {
                Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.QuestionContent);
                Editor.ContentData = Data.QuestionContent;
            }

            Editor.InputAndSubmitForm(questionContentElement);

            int index = 0;
            foreach (var answerChoice in AnswerChoiceList)
            {
                answerChoice.SelectTeacherExplanation();

                //QuestionAnswerData
                if (_questionAnswerDataObject != null)
                {
                    Utilities.DoFileUpload(Editor, _autoItDataObject, _questionAnswerDataObject.FileUploadTree, _questionAnswerDataObject.TeacherExplanationList[0]);
                    Editor.ContentData = _questionAnswerDataObject.TeacherExplanationList[0];
                }
                else //ItemTypeData
                {
                    Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.TeacherExplanation);
                    Editor.ContentData = Data.TeacherExplanation;
                }

                Editor.InputAndSubmitForm(answerChoice.TeacherExplanation.Add);

                answerChoice.SelectEditStudentExplanation();

                //QuestionAnswerData
                if (_questionAnswerDataObject != null)
                {
                    Utilities.DoFileUpload(Editor, _autoItDataObject, _questionAnswerDataObject.FileUploadTree, _questionAnswerDataObject.StudentExplanationList[0]);
                    Editor.ContentData = _questionAnswerDataObject.StudentExplanationList[0];
                }
                else //ItemTypeData
                {
                    Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.StudentExplanation);
                    Editor.ContentData = Data.StudentExplanation;
                }

                Editor.InputAndSubmitForm(answerChoice.StudentExplanation.Edit);

                //QuestionAnswerData
                if (_questionAnswerDataObject != null)
                {
                    //get the answer
                    string answer = _questionAnswerDataObject.AnswerList[index];
                    Report.Write("answer: " + answer);
                    try
                    {
                        string points = _questionAnswerDataObject.PointValuePair[answer];
                        Report.Write("answer: " + answer + "; points: " + points);
                        answerChoice.SelectIsCorrectResponse();
                        answerChoice.EditPointsPossible(points);
                    }
                    catch (Exception e)
                    {
                        //do nothing
                    }
                }
                else //ItemTypeData
                {
                    AnswerChoiceList.First().SelectIsCorrectResponse();
                    AnswerChoiceList.First().EditPointsPossible("" + Data.PointsValue);
                }
                index++;
            }
            //this is only applicable on https://qa-153mt.sndev.net
            //SelectEnableManipulativesNo();
            //TODO: work on enable manipulatives for version 15.4
        }

        public override void InputFormFields_AnswerKeyOnly()
        {
            throw new NotImplementedException();
        }
    }
}
