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
    /// the item type: gridded form
    /// </summary>
    public class ItemTypeGriddedForm : ItemTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemTypeGriddedForm(string overrideControlPrefix = null)
            : base(ItemType.Gridded)
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
            Editor = new Editor(PageNames.EditorPopup, this.ControlPrefix);
            QuestionContent = new WebElementWrapper(ByQuestionContent);
            QuestionContentReedit = new WebElementWrapper(ByQuestionContentReedit);
            NumberOfAnswerColumnsSelect = new SelectElementWrapper(new WebElementWrapper(ByNumberOfAnswerColumnsSelect));
            CorrectAnswerText = new WebElementWrapper(ByCorrectAnswerText);
            PointsText = new WebElementWrapper(ByPointsText);
            AnswerEachDigitInMathematicalPlaceCheck = new WebElementWrapper(ByAnswerEachDigitInMathematicalPlaceCheck);
            PrePopulateDecimalPointCheck = new WebElementWrapper(ByPrePopulateDecimalPointCheck);
            PrePopulateDecimalPointSelect = new SelectElementWrapper(new WebElementWrapper(ByPrePopulateDecimalPointSelect));
            AnswerExactlyAsShownCheck = new WebElementWrapper(ByAnswerExactlyAsShownCheck);
            ShowNegativeSignCheck = new WebElementWrapper(ByShowNegativeSignCheck);
            ShowFractionCheck = new WebElementWrapper(ByShowFractionCheck);
            ShowDecimalPointCheck = new WebElementWrapper(ByShowDecimalPointCheck);
            ExpectedRequiredErrorsList = new List<string>()
            {
                "Enter content",
                "Select correct answer",
                "Not worth any points"
            };
        }

        /// <summary>
        /// the html editor
        /// </summary>
        public Editor Editor { get; private set; }

        //16.0
        //private By ByQuestionContent { get { return By.Id("divNoItemContent"); } }
        //16.1
        //private By ByQuestionContent { get { return By.CssSelector("div[data-content='QuestionContent'] > div[id^='divNo']"); } }
        private By ByQuestionContent { get { return By.CssSelector("div[data-content='QuestionContent']"); } }
        private WebElementWrapper QuestionContent { get; set; }
        //16.0
        //private By ByQuestionContentReedit { get { return By.Id("divItemContent"); } }
        //16.1
        private By ByQuestionContentReedit { get { return By.CssSelector("div[data-content='QuestionContent'] > div[id^='div']:not([id^='divNo'])"); } }
        private WebElementWrapper QuestionContentReedit { get; set; }
        //16.0
        //private By ByNumberOfAnswerColumnsSelect { get { return By.Id(ControlPrefix + "EditTestItemControl_ddlAnswerLength"); } }
        //16.1
        private By ByNumberOfAnswerColumnsSelect { get { return By.CssSelector("select[data-ng-model='TestItem.GriddedAnswerLength']"); } }
        private SelectElementWrapper NumberOfAnswerColumnsSelect { get; set; }
        //16.0
        //private By ByCorrectAnswerText { get { return By.Id(ControlPrefix + "EditTestItemControl_txtCorrectAnswer"); } }
        //16.1
        private By ByCorrectAnswerText { get { return By.Id("answerLabel"); } }
        private WebElementWrapper CorrectAnswerText { get; set; }
        //16.0
        //private By ByPointsText { get { return By.Id(ControlPrefix + "EditTestItemControl_txtPoints"); } }
        //16.1
        private By ByPointsText { get { return By.CssSelector("input[data-ng-model='TestItem.Answers[0].Points']"); } }
        private WebElementWrapper PointsText { get; set; }

        //id=ck_whole_enforceplace
        //Answer must be entered with each digit in the column corresponding to its mathematical place 
        private By ByAnswerEachDigitInMathematicalPlaceCheck { get { return By.Id("ck_whole_enforceplace"); } }
        private WebElementWrapper AnswerEachDigitInMathematicalPlaceCheck { get; set; }

        //id=ck_decimal_decimalplace
        //checkbox Pre-populate the decimal point in column
        private By ByPrePopulateDecimalPointCheck { get { return By.Id("ck_decimal_decimalplace"); } }
        private WebElementWrapper PrePopulateDecimalPointCheck { get; set; }

        //data-ng-model=TestItem.DecimalPosition
        //select Pre-populate the decimal point in column
        private By ByPrePopulateDecimalPointSelect { get { return By.CssSelector("select[data-ng-model='TestItem.DecimalPosition']"); } }
        private SelectElementWrapper PrePopulateDecimalPointSelect { get; set; }

        //id=ck_fraction_exactmatch
        //Answer must be entered exactly as shown here
        private By ByAnswerExactlyAsShownCheck { get { return By.Id("ck_fraction_exactmatch"); } }
        private WebElementWrapper AnswerExactlyAsShownCheck { get; set; }

        //id=ck_negative
        //Show negative sign option
        private By ByShowNegativeSignCheck { get { return By.Id("ck_negative"); } }
        private WebElementWrapper ShowNegativeSignCheck { get; set; }

        //id=ck_fraction
        //Show fraction (/) option 
        private By ByShowFractionCheck { get { return By.Id("ck_fraction"); } }
        private WebElementWrapper ShowFractionCheck { get; set; }

        //id=ck_decimal
        //Show decimal point option
        private By ByShowDecimalPointCheck { get { return By.Id("ck_decimal"); } }
        private WebElementWrapper ShowDecimalPointCheck { get; set; }

        //specific methods
        /// <summary>
        /// select question content, return the element clicked.
        /// When the question context had value entered, the question context element change. 
        /// Hence another element will be return. 
        /// </summary>
        public WebElementWrapper SelectQuestionContent()
        {
            QuestionContent.Wait(5).Click();
            /*
            try
            {
                QuestionContent.Wait(5).Click();
            }
            catch (Exception e)
            {
                //The first click is not happening, assume user had already input a value. 
                //When question editor had inputed value, it will show up inside another div element with different id.
                //Click on this other element.
                Debug.WriteLine("Re-attempting to click this element by: '" + QuestionContentReedit.By.ToString() + "'.");
                QuestionContentReedit.Wait(5).Click();
                return QuestionContentReedit;
            }
            */
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

            //Editor.ContentData = Data.QuestionContent;
            Editor.InputAndSubmitForm(questionContentElement);

            //QuestionAnswerData
            if (_questionAnswerDataObject != null)
            {
                NumberOfAnswerColumnsSelect.SelectByText("" + _questionAnswerDataObject.AnswerList.Count);
                string answer = "";
                foreach (var answerItem in _questionAnswerDataObject.AnswerList)
                {
                    answer = answer + answerItem;
                }
                CorrectAnswerText.SendKeys(answer);
                PointsText.SendKeys("" + _questionAnswerDataObject.PointValueList[0]);
            }
            else //ItemTypeData
            {
                NumberOfAnswerColumnsSelect.SelectByText("" + Data.CorrectAnswer.Length);
                CorrectAnswerText.SendKeys(Data.CorrectAnswer);
                PointsText.SendKeys("" + Data.PointsValue);
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
