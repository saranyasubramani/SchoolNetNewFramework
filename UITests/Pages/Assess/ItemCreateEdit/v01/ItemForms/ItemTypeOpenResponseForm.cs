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
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms
{
    /// <summary>
    /// the item type: open response form
    /// </summary>
    public class ItemTypeOpenResponseForm : ItemTypeForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="driver">IWebDriver</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemTypeOpenResponseForm(string overrideControlPrefix = null)
            : base(ItemType.OpenResponse)
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
            EnableTextFormatting = new EnableTextFormatting(PageNames.CreateNewItem, this.ControlPrefix);
            QuestionContent = new WebElementWrapper(ByQuestionContent);
            QuestionContentReedit = new WebElementWrapper(ByQuestionContentReedit);
            ResponseTypeSelect = new SelectElementWrapper(new WebElementWrapper(ByResponseTypeSelect));
            RubricButton = new WebElementWrapper(ByRubricButton);
            //page is only initialized upon selecting button
            //AttachRubricDialog = new AttachRubricDialog();
            AttachRubric = new AttachRubric();
            MaximumPointsText = new WebElementWrapper(ByMaximumPointsText);
            NumberOfAnswerSheetPagesSelect = new SelectElementWrapper(new WebElementWrapper(ByNumberOfAnswerSheetPagesSelect));
            ScoringInstructionsAddLabel = new WebElementWrapper(ByScoringInstructionsAddLabel);
            ScoringInstructionsEditLabel = new WebElementWrapper(ByScoringInstructionsEditLabel);
            ExemplarsAddLabel = new WebElementWrapper(ByExemplarsAddLabel);
            ExemplarsEditLabel = new WebElementWrapper(ByExemplarsEditLabel);
            ExemplarsUploadButton = new WebElementWrapper(ByExemplarsUploadButton);
            StudentInstructionsText = new WebElementWrapper(ByStudentInstructionsText);
            //FormulaReferenceSheetButton = new WebElementWrapper(ByFormulaReferenceSheetButton);
            ExpectedRequiredErrorsList = new List<string>()
            {
                "Enter content"
            };
        }

        /// <summary>
        /// the html editor
        /// </summary>
        public Editor Editor { get; set; }
        /// <summary>
        /// the rubric weight after attaching a rubric
        /// </summary>
        public AttachRubric AttachRubric { get; set; }
        /// <summary>
        /// the rubric dialog when attaching a rubric
        /// </summary>
        public AttachRubricDialog AttachRubricDialog { get; set; }
        private bool isEnableTextFormattingVisible { get; set; }
        //15.3
        //private By ByQuestionContentLabel { get { return By.Id("divNoItemContent"); } }
        //15.4
        private By ByQuestionContent { get { return By.Id("anhcrNoItemContent"); } }
        private WebElementWrapper QuestionContent { get; set; }
        private By ByQuestionContentReedit { get { return By.Id("divItemContent"); } }
        private WebElementWrapper QuestionContentReedit { get; set; }
        //15.3
        //private By ByResponseTypeSelect { get { return By.Id(ControlPrefix + "EditTestItemControl_rbtWritten"); } }
        //private WebElementWrapper ResponseTypeSelect { get; set; }
        //15.4
        private By ByResponseTypeSelect { get { return By.Id(ControlPrefix + "EditTestItemControl_drResponse"); } }
        private SelectElementWrapper ResponseTypeSelect { get; set; }
        private By ByRubricButton { get { return By.Id(ControlPrefix + "EditTestItemControl_RubricQuickPicker1_btnRubric"); } }
        private WebElementWrapper RubricButton { get; set; }
        private By ByMaximumPointsText { get { return By.Id(ControlPrefix + "EditTestItemControl_txtOpenResponseMaximumPoints"); } }
        private WebElementWrapper MaximumPointsText { get; set; }
        private By ByNumberOfAnswerSheetPagesSelect { get { return By.Id(ControlPrefix + "EditTestItemControl_ddlCaptureStudentWork"); } }
        private SelectElementWrapper NumberOfAnswerSheetPagesSelect { get; set; }
        private By ByScoringInstructionsAddLabel { get { return By.Id("divNoTeacherInstructions"); } }
        private WebElementWrapper ScoringInstructionsAddLabel { get; set; }
        private By ByScoringInstructionsEditLabel { get { return By.Id("divTeacherInstructions"); } }
        private WebElementWrapper ScoringInstructionsEditLabel { get; set; }
        private By ByExemplarsAddLabel { get { return By.Id("divNoExemplar"); } }
        private WebElementWrapper ExemplarsAddLabel { get; set; }
        private By ByExemplarsEditLabel { get { return By.Id("divExemplar"); } }
        private WebElementWrapper ExemplarsEditLabel { get; set; }
        private By ByExemplarsUploadButton { get { return By.Id(ControlPrefix + "EditTestItemControl_OpenResponseExemplarUpload1_ButtonUpload"); } }
        private WebElementWrapper ExemplarsUploadButton { get; set; }
        private By ByStudentInstructionsText { get { return By.Id(ControlPrefix + "EditTestItemControl_TextBoxStudentInstructions"); } }
        private WebElementWrapper StudentInstructionsText { get; set; }
        //private By ByFormulaReferenceSheetButton { get { return By.ClassName("btn fileupload"); } }
        //private WebElementWrapper FormulaReferenceSheetButton { get; set; }

        //specific methods
        /// <summary>
        /// select question content, return the element clicked.
        /// When the question context had value entered, the question context element change. 
        /// Hence another element will be return. 
        /// </summary>
        /// <returns>WebElementWrapper</returns>
        public WebElementWrapper SelectQuestionContent()
        {
            try
            {
                QuestionContent.Wait(5).Click();
                return QuestionContent;
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
        }
        /// <summary>
        /// select the response type
        /// </summary>
        /// <param name="response">the response</param>
        public void SelectResponseType(string response)
        {
            //15.3
            //ResponseTypeSelect.Wait(5).Click();
            //15.4
            ResponseTypeSelect.Wait(5).SelectByText(response);
            if (response.Trim().ToLower().Equals("written"))
            {
                isEnableTextFormattingVisible = true;
            }
            else
            {
                isEnableTextFormattingVisible = false;
            }
        }

        /// <summary>
        /// select the rubric button
        /// </summary>
        /// <param name="response">the rubric</param>
        public void SelectRubric()
        {
            RubricButton.Click();
            System.Threading.Thread.Sleep(2000);
            AttachRubricDialog = new AttachRubricDialog();
        }
        /// <summary>
        /// search for a rubric and attach the rubric
        /// </summary>
        /// <param name="instructions">the instructions</param>
        public void SearchAndAttachRubric()
        {
            AttachRubricDialog.Data = Data.RubricSearchData;
            AttachRubricDialog.Form.InputAndSubmitForm();

            System.Threading.Thread.Sleep(2000);
            AttachRubricDialog = new AttachRubricDialog();
            AttachRubricDialog.Detail.GetItemFromResultsList(0).SelectAttach();
        }
        /// <summary>
        /// input rubric points
        /// </summary>
        /// <param name="points">the point value</param>
        public void InputRubricPoints()
        {
            for (int i = 0; i < Data.PointsValueList.Count; i++)
            {
                AttachRubric.GetItemFromWeightList(i).InputPoints(Data.PointsValueList[i]);
            }
        }

        /// <summary>
        /// input maximum points
        /// </summary>
        /// <param name="points">the point value</param>
        public void InputMaximumPoints(int points)
        {
            MaximumPointsText.Wait(5).SendKeys("" + points);
        }
        /// <summary>
        /// input maximum points
        /// </summary>
        /// <param name="points">the point value</param>
        public void InputMaximumPoints(string points)
        {
            MaximumPointsText.Wait(5).SendKeys(points);
        }
        /// <summary>
        /// select number of answer sheet pages
        /// </summary>
        /// <param name="answerSheetsNumber">the number of answer sheet pages</param>
        public void SelectNumberOfAnswerSheetPages(string answerSheetsNumber)
        {
            NumberOfAnswerSheetPagesSelect.SelectByText(answerSheetsNumber);
        }
        /// <summary>
        /// select scoring instructions add content
        /// </summary>
        /// <returns>WebElementWrapper</returns>
        public WebElementWrapper SelectScoringInstructionsAdd()
        {
            try
            {
                ScoringInstructionsAddLabel.Wait(5).Click();
                return ScoringInstructionsAddLabel;
            }
            catch (Exception e)
            {
                //The first click is not happening, assume user had already input a value. 
                //When question editor had inputed value, it will show up inside another div element with different id.
                //Click on this other element.
                Report.Write("Re-attempting to click this element by: '" + ScoringInstructionsEditLabel.By.ToString() + "'.");
                ScoringInstructionsEditLabel.Wait(5).Click();
                return ScoringInstructionsEditLabel;
            }
        }
        /// <summary>
        /// select exemplars add content
        /// </summary>
        /// <returns>WebElementWrapper</returns>
        public WebElementWrapper SelectExemplarsAddLabelAdd()
        {
            try
            {
                ExemplarsAddLabel.Wait(5).Click();
                return ExemplarsAddLabel;
            }
            catch (Exception e)
            {
                //The first click is not happening, assume user had already input a value. 
                //When question editor had inputed value, it will show up inside another div element with different id.
                //Click on this other element.
                Report.Write("Re-attempting to click this element by: '" + ExemplarsEditLabel.By.ToString() + "'.");
                ExemplarsEditLabel.Wait(5).Click();
                return ExemplarsEditLabel;
            }
        }
        /// <summary>
        /// input student instructions
        /// </summary>
        /// <param name="instructions">the instructions</param>
        public void InputStudentInstructions(string instructions)
        {
            StudentInstructionsText.Clear();
            StudentInstructionsText.SendKeys(instructions);
        }

        //implemented methods
        public override void InputFormFields()
        {
            WebElementWrapper questionContentElement = SelectQuestionContent();
            string questionContent = null;
            string responseType = null;
            string pointsValue = null;
            string scoringInstructions = null;
            string exemplars = null;
            string studentInstructions = null;
            Dictionary<bool, Dictionary<string, string>> fileUploadTree = null;

            //QuestionAnswerData
            if (_questionAnswerDataObject != null)
            {
                questionContent = _questionAnswerDataObject.QuestionContent;
                responseType = _questionAnswerDataObject.ResponseType;
                pointsValue = _questionAnswerDataObject.PointValueList[0];
                scoringInstructions = _questionAnswerDataObject.ScoringInstructions;
                exemplars = _questionAnswerDataObject.Exemplars;
                studentInstructions = _questionAnswerDataObject.StudentInstructions;
                fileUploadTree = _questionAnswerDataObject.FileUploadTree;
            }
            else //ItemTypeData
            {
                questionContent = Data.QuestionContent;
                responseType = Data.ResponseType;
                pointsValue = "" + Data.PointsValue;
                scoringInstructions = Data.ScoringInstructions;
                exemplars = Data.Exemplars;
                studentInstructions = Data.StudentInstructions;
                fileUploadTree = Data.FileUploadTree;
            }

            Utilities.DoFileUpload(Editor, _autoItDataObject, fileUploadTree, questionContent);
            Editor.ContentData = questionContent;
            Editor.InputAndSubmitForm(questionContentElement);

            SelectResponseType(responseType);
            if (isEnableTextFormattingVisible == true)
            {
                CheckEnableTextFormatting();
            }

            InputMaximumPoints(pointsValue);

            //SelectNumberOfAnswerSheetPages(Data.NumberOfAnswerSheetPages);

            WebElementWrapper scoringInstructionsAddElement = SelectScoringInstructionsAdd();
            Utilities.DoFileUpload(Editor, _autoItDataObject, fileUploadTree, scoringInstructions);
            Editor.ContentData = scoringInstructions;
            Editor.InputAndSubmitForm(scoringInstructionsAddElement);

            WebElementWrapper exemplarsAddLabelAddElement = SelectExemplarsAddLabelAdd();
            Utilities.DoFileUpload(Editor, _autoItDataObject, fileUploadTree, exemplars);
            Editor.ContentData = exemplars;
            Editor.InputAndSubmitForm(exemplarsAddLabelAddElement);

            //removed for version 16.3 in Bug #98933: Assess: Open Response: Student Instructions text box was removed
            //InputStudentInstructions(studentInstructions);

            //this is only applicable on https://qa-153mt.sndev.net
            //SelectEnableManipulativesNo();
            //TODO: work on enable manipulatives for version 15.4
        }

        public override void InputFormFields_AnswerKeyOnly()
        {
            throw new NotImplementedException();
        }

        public void VerifyFieldsExist(List<ItemTypeOpenResponseFields> fields)
        {
            foreach (var field in fields)
            {
                if (field.Equals(ItemTypeOpenResponseFields.RubricWeightTable))
                {
                    AttachRubricPointsLineItem lineItem = AttachRubric.GetItemFromWeightList(0);
                    Assert.IsNotNull(lineItem,
                        "The rubric weight table was not found.");

                    Report.Write("Found the rubric weight table.");
                }
            }
        }
    }
}
