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
    /// the item type: matching form
    /// </summary>
    public class ItemTypeMatchingForm : ItemTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemTypeMatchingForm(string overrideControlPrefix = null)
            : base(ItemType.Matching)
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
            AddQuestionStemLink = new WebElementWrapper(ByAddQuestionStemLink);
            AddAnswerChoiceLink = new WebElementWrapper(ByAddAnswerChoiceLink);
            AddMatchingPairLink = new WebElementWrapper(ByAddMatchingPairLink);
            ExpectedRequiredErrorsList = new List<string>()
            {
                "Add content for question 1, 2, 3",
                "Add content for answer choice A, B, C, D",
                "Choose question & answer choices for matches",
                //16.0 "Enter student instructions"
                //16.1
                "Enter content"
            };
        }

        /// <summary>
        /// a list of question stems
        /// </summary>
        public List<QuestionAnswerContent> QuestionStemList { get; private set; }
        /// <summary>
        /// a list of answer choices
        /// </summary>
        public List<QuestionAnswerContent> AnswerChoiceList { get; private set; }
        /// <summary>
        /// a list of matching pairs
        /// </summary>
        public List<MatchingPair> MatchingPairList { get; private set; }
        /// <summary>
        /// a list of unique control identifiers by number
        /// </summary>
        public Dictionary<string, string> QuestionStemUniqueControlIdentifiers { get; private set; }
        /// <summary>
        /// a list of unique control identifiers by letter
        /// </summary>
        public Dictionary<string, string> AnswerChoiceUniqueControlIdentifiers { get; private set; }

        private By ByQuestionContent { get { return By.Id("divNoItemContent"); } }
        private WebElementWrapper QuestionContent { get; set; }
        private By ByQuestionContentReedit { get { return By.Id("divNoItemContent"); } }
        private WebElementWrapper QuestionContentReedit { get; set; }

        private By ByMatchQuestionStemLabels { get { return By.CssSelector(".matchStems .matchLabel"); } }
        private By ByMatchAnswerChoiceLabels { get { return By.CssSelector(".matchChoices .matchLabel"); } }
        private By ByMatchMatchingPairLabels { get { return By.CssSelector(".matchPairsWrapper"); } }

        private By ByAddQuestionStemLink { get { return By.CssSelector("a[id$='_lnkAddMatchStem']"); } }
        private WebElementWrapper AddQuestionStemLink { get; set; }

        private By ByAddAnswerChoiceLink { get { return By.CssSelector("a[id$='_lnkAddMatchChoice']"); } }
        private WebElementWrapper AddAnswerChoiceLink { get; set; }

        private By ByAddMatchingPairLink { get { return By.CssSelector("a[id$='_lnkAddMatchPair']"); } }
        private WebElementWrapper AddMatchingPairLink { get; set; }

        /// <summary>
        /// the html editor
        /// </summary>
        public Editor Editor { get; private set; }

        private void SetUniqueControlIdentifiers()
        {
            //get a hash of the answer choice's: label and unique control identifier using WebDriver.FindElements(By.ClassName)
            QuestionStemUniqueControlIdentifiers = GetUniqueControlIdentifiers(ByMatchQuestionStemLabels);
            AnswerChoiceUniqueControlIdentifiers = GetUniqueControlIdentifiers(ByMatchAnswerChoiceLabels);
            //get the list of answer labels
            var keyList = new List<string>();
            foreach (var key in AnswerChoiceUniqueControlIdentifiers.Keys)
            {
                keyList.Add(key);
            }

            QuestionStemList = new List<QuestionAnswerContent>();
            //for each element in the hash
            foreach (var key in QuestionStemUniqueControlIdentifiers.Keys)
            {
                //is the key numeric?
                int index;
                bool isNumeric = int.TryParse(key, out index);
                if (isNumeric == true)
                {
                    //get a numeric zero based index by subtracting 1 from the number of the question label
                    index = index - 1;
                    //get the unique control identifier
                    string uniqueId = QuestionStemUniqueControlIdentifiers[key];
                    Report.Write("Question stem unique control identifier by key: " + key + "; index: " + index + "; ID: " + uniqueId);
                    //create an question stem object
                    var questionStem = new QuestionAnswerContent(key, index, uniqueId, ContentType.QuestionStem, ItemType.Matching, ControlPrefix);
                    //add the question stem object to the collection (1, 2, 3)
                    QuestionStemList.Add(questionStem);
                }
            }

            AnswerChoiceList = new List<QuestionAnswerContent>();
            //for each element in the hash
            foreach (var key in AnswerChoiceUniqueControlIdentifiers.Keys)
            {
                //is the key numeric?
                int index;
                bool isNumeric = int.TryParse(key, out index);
                if (isNumeric == false)
                {
                    //get a numeric zero based index based on the letter of the answer label
                    index = this.GetIndexByAlphabet(key, keyList);
                    //get the unique control identifier
                    string uniqueId = AnswerChoiceUniqueControlIdentifiers[key];
                    Report.Write("Answer choice unique control identifier by key: " + key + "; index: " + index + "; ID: " + uniqueId);
                    //create an answer choice object
                    var answerChoice = new QuestionAnswerContent(key, index, uniqueId, ContentType.AvailableChoice, ItemType.Matching, ControlPrefix);
                    //add the answer choice object to the collection (A, B, C, D)
                    AnswerChoiceList.Add(answerChoice);
                }
            }

            MatchingPairList = new List<MatchingPair>();
            //for each element in the hash
            foreach (var key in QuestionStemUniqueControlIdentifiers.Keys)
            {
                //is the key numeric?
                int index;
                bool isNumeric = int.TryParse(key, out index);
                if (isNumeric == true)
                {
                    //get a numeric zero based index by subtracting 1 from the number of the question label
                    index = index - 1;
                    //get the unique control identifier
                    string uniqueId = QuestionStemUniqueControlIdentifiers[key];
                    Report.Write("Matching pair unique control identifier by key: " + key + "; index: " + index + "; ID: " + uniqueId);
                    //create an question stem object
                    var matchingPair = new MatchingPair(key, index, uniqueId, ControlPrefix);
                    //add the question stem object to the collection (1, 2, 3)
                    MatchingPairList.Add(matchingPair);
                }
            }
        }

        //specific methods
        /// <summary>
        /// select question content, return the element clicked.
        /// When the question context had value entered, the question context element change. 
        /// Hence another element will be return. 
        /// </summary>
        public WebElementWrapper SelectQuestionContent()
        {
            try
            {
                QuestionContent.Wait(5).Click();
            }
            catch (Exception e)
            {
                //The first click is not happening, assume user had already input a value. 
                //When question editor had inputed value, it will show up inside another div element with different id.
                //Click on this other element.
                Report.Write("Re-attempting to click this element by: '" + QuestionContentReedit.By.ToString() + "'.");
                QuestionContentReedit.Wait(5).Click();
                return QuestionContentReedit;
            }
            return QuestionContent;
        }
        /// <summary>
        /// add question stem
        /// </summary>
        public void AddQuestionStem()
        {
            AddQuestionStemLink.Click();
            QuestionStemList.Clear();
            SetUniqueControlIdentifiers();
        }
        /// <summary>
        /// add answer choice
        /// </summary>
        public void AddAnswerChoice()
        {
            AddAnswerChoiceLink.Click();
            AnswerChoiceList.Clear();
            SetUniqueControlIdentifiers();
        }
        /// <summary>
        /// add matching pair
        /// </summary>
        public void AddMatchingPair()
        {
            AddMatchingPairLink.Click();
            MatchingPairList.Clear();
            SetUniqueControlIdentifiers();
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
            foreach (var questionStem in QuestionStemList)
            {
                questionStem.ContentAdd.Click();

                //QuestionAnswerData
                if (_questionAnswerDataObject != null)
                {
                    Utilities.DoFileUpload(Editor, _autoItDataObject, _questionAnswerDataObject.FileUploadTree, _questionAnswerDataObject.QuestionList[index]);
                    Editor.ContentData = _questionAnswerDataObject.QuestionList[index];
                }
                else //ItemTypeData
                {
                    Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.QuestionStemList[index]);
                    Editor.ContentData = Data.QuestionStemList[index];
                }

                index++;
                Editor.InputAndSubmitForm(questionStem.ContentAdd);
            }

            index = 0;
            foreach (var answerChoice in AnswerChoiceList)
            {
                answerChoice.ContentAdd.Click();

                //QuestionAnswerData
                if (_questionAnswerDataObject != null)
                {
                    Utilities.DoFileUpload(Editor, _autoItDataObject, _questionAnswerDataObject.FileUploadTree, _questionAnswerDataObject.AnswerList[index]);
                    Editor.ContentData = _questionAnswerDataObject.AnswerList[index];
                }
                else //ItemTypeData
                {
                    Utilities.DoFileUpload(Editor, _autoItDataObject, Data.FileUploadTree, Data.AnswerChoiceList[index]);
                    Editor.ContentData = Data.AnswerChoiceList[index];
                }

                index++;
                Editor.InputAndSubmitForm(answerChoice.ContentAdd);
            }

            index = 0;
            foreach (var matchingPair in MatchingPairList)
            {
                matchingPair.SelectQuestionStem(matchingPair.Label);
                matchingPair.SelectAnswerChoice(AnswerChoiceList[index].Label);
                matchingPair.SelectAddTeacherExplanation();

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

                Editor.InputAndSubmitForm(matchingPair.TeacherExplanation.Add);

                matchingPair.SelectEditStudentExplanation();

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

                Editor.InputAndSubmitForm(matchingPair.StudentExplanation.Edit);

                //QuestionAnswerData
                if (_questionAnswerDataObject != null)
                {
                    //get the question
                    string question = _questionAnswerDataObject.QuestionList[index];
                    Report.Write("question: " + question);
                    try
                    {
                        string points = _questionAnswerDataObject.PointValuePair[question];
                        Report.Write("question: " + question + "; points: " + points);
                        matchingPair.SelectIsCorrectResponse();
                        matchingPair.EditPointsPossible(points);
                    }
                    catch (Exception e)
                    {
                        //do nothing
                    }
                }
                else //ItemTypeData
                {
                    MatchingPairList.Last().SelectIsCorrectResponse();
                    MatchingPairList.Last().EditPointsPossible("" + Data.PointsValue);
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

        public override void VerifyFieldsExist()
        {
            QuestionContent.Displayed = true;
            Assert.IsTrue(QuestionContent.Displayed, Utilities.GetInvisibleErrorMessage(QuestionContent.By.ToString()));

            foreach (var questionStem in QuestionStemList)
            {
                questionStem.ContentLabel.Displayed = true;
                Assert.IsTrue(questionStem.ContentLabel.Displayed, Utilities.GetInvisibleErrorMessage(questionStem.ContentLabel.By.ToString()));
                questionStem.ContentAdd.Displayed = true;
                Assert.IsTrue(questionStem.ContentAdd.Displayed, Utilities.GetInvisibleErrorMessage(questionStem.ContentAdd.By.ToString()));
            }

            foreach (var answerChoice in AnswerChoiceList)
            {
                answerChoice.ContentLabel.Displayed = true;
                Assert.IsTrue(answerChoice.ContentLabel.Displayed, Utilities.GetInvisibleErrorMessage(answerChoice.ContentLabel.By.ToString()));
                answerChoice.ContentAdd.Displayed = true;
                Assert.IsTrue(answerChoice.ContentAdd.Displayed, Utilities.GetInvisibleErrorMessage(answerChoice.ContentAdd.By.ToString()));
            }

            foreach (var matchingPair in MatchingPairList)
            {
                matchingPair.QuestionAnswerPair.Choice.Wrapper.Displayed = true;
                Assert.IsTrue(matchingPair.QuestionAnswerPair.Choice.Wrapper.Displayed,
                    Utilities.GetInvisibleErrorMessage(matchingPair.QuestionAnswerPair.Choice.Wrapper.By.ToString()));
                matchingPair.QuestionAnswerPair.Stem.Wrapper.Displayed = true;
                Assert.IsTrue(matchingPair.QuestionAnswerPair.Stem.Wrapper.Displayed,
                    Utilities.GetInvisibleErrorMessage(matchingPair.QuestionAnswerPair.Stem.Wrapper.By.ToString()));

                matchingPair.AnswerLineItem.IsCorrectResponse.Displayed = true;
                Assert.IsTrue(matchingPair.AnswerLineItem.IsCorrectResponse.Displayed,
                    Utilities.GetInvisibleErrorMessage(matchingPair.AnswerLineItem.IsCorrectResponse.By.ToString()));
                matchingPair.AnswerLineItem.PointsPossible.Displayed = true;
                Assert.IsTrue(matchingPair.AnswerLineItem.PointsPossible.Displayed,
                    Utilities.GetInvisibleErrorMessage(matchingPair.AnswerLineItem.PointsPossible.By.ToString()));

                matchingPair.TeacherExplanation.Add.Displayed = true;
                Assert.IsTrue(matchingPair.TeacherExplanation.Add.Displayed,
                    Utilities.GetInvisibleErrorMessage(matchingPair.TeacherExplanation.Add.By.ToString()));
                matchingPair.StudentExplanation.Add.Displayed = true;
                Assert.IsTrue(matchingPair.StudentExplanation.Add.Displayed,
                    Utilities.GetInvisibleErrorMessage(matchingPair.StudentExplanation.Add.By.ToString()));
            }

            /* 15.3
            EnableToolsManipulatives.No.Displayed = true;
            Assert.IsTrue(EnableToolsManipulatives.No.Displayed, GetInvisibleErrorMessage(EnableToolsManipulatives.No.By.ToString()));
            EnableToolsManipulatives.Yes.Displayed = true;
            Assert.IsTrue(EnableToolsManipulatives.Yes.Displayed, GetInvisibleErrorMessage(EnableToolsManipulatives.Yes.By.ToString()));
            */
            //15.4
            EnableToolsManipulatives.Check.Displayed = true;
            Assert.IsTrue(EnableToolsManipulatives.Check.Displayed,
                Utilities.GetInvisibleErrorMessage(EnableToolsManipulatives.Check.By.ToString()));
        }
    }
}
