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
using UITests.Pages.Controls;
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;

namespace UITests.Pages.Assess.Passage.EditPassage
{
    /// <summary>
    /// edit passage form
    /// </summary>
    public class EditPassageForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public EditPassageForm(string overrideControlPrefix = null)
            : base()
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
            SubjectElement subject = new SubjectElement(PageNames.CreatePassage);
            SubjectSelect = subject.SelectElement;
            GradeLevelElement gradeLevel = new GradeLevelElement(PageNames.CreatePassage);
            GradeFromSelect = gradeLevel.FromSelectElement;
            GradeToSelect = gradeLevel.ToSelectElement;
            TeacherInstructionEditor = new TeacherInstructionEditor(PageNames.CreatePassage);
            Title_textbox = new WebElementWrapper(ByTitle_textbox);
            OptionalProperties_link = new WebElementWrapper(ByOptionalProperties_link);
            OptionalProperties_icon = new WebElementWrapper(ByOptionalProperties_icon);
            AdditionalPassageID_textbox = new WebElementWrapper(ByAdditionalPassageID_textbox);
            AssetType_textbox = new WebElementWrapper(ByAssetType_textbox);
            Author_textbox = new WebElementWrapper(ByAuthor_textbox);
            CourseID_textbox = new WebElementWrapper(ByCourseID_textbox);
            FleschKincaid_textbox = new WebElementWrapper(ByFleschKincaid_textbox);
            Genre_textbox = new WebElementWrapper(ByGenre_textbox);
            QuestionLanguage_dropdown = new SelectElementWrapper(new WebElementWrapper(ByQuestionLanguage_dropdown));
            LexileCode_dropdown = new SelectElementWrapper(new WebElementWrapper(ByLexileCode_dropdown));
            Lexile_textbox = new WebElementWrapper(ByLexile_textbox);
            BeginningReader_chkbox = new WebElementWrapper(ByBeginningReader_chkbox);
            Publisher_textbox = new WebElementWrapper(ByPublisher_textbox);
            ReadingMaturityMetric_textbox = new WebElementWrapper(ByReadingMaturityMetric_textbox);
            Topic_textbox = new WebElementWrapper(ByTopic_textbox);
            Type_dropdown = new SelectElementWrapper(new WebElementWrapper(ByType_dropdown));
            Year_textbox = new WebElementWrapper(ByYear_textbox);
            Batch_textbox = new WebElementWrapper(ByBatch_textbox);
            TeacherInstruction = new TeacherInstruction(PageNames.CreatePassage);
            Editor = new Editor(PageNames.CreatePassage, this.ControlPrefix);
            PortraitLayout = new WebElementWrapper(ByPortraitLayout);
            LandscapeLayout = new WebElementWrapper(ByLandscapeLayout);
        }

        /// <summary>
        /// the data
        /// </summary>
        public EditPassageData Data
        {
            get
            {
                return (EditPassageData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        // LOCATORS
        public override By ByCancel { get { return By.Id(ControlPrefix + "ButtonCancel"); } }
        public WebElementWrapper Cancel { get { return new WebElementWrapper(ByCancel); } }

        public override By BySubmit { get { return By.Id(ControlPrefix + "ButtonSave"); } }
        public WebElementWrapper Submit { get { return new WebElementWrapper(BySubmit); } }

        public By ByAddItem_button { get { return By.Id(ControlPrefix + "ButtonAddItem"); } }
        public WebElementWrapper AddItem_button { get { return new WebElementWrapper(ByAddItem_button); } }

        public By BySave_button { get { return By.Id(ControlPrefix + "ButtonSave"); } }
        public WebElementWrapper Save_button { get { return new WebElementWrapper(BySave_button); } }

        public SelectElementWrapper SubjectSelect { get; private set; }
        public SelectElementWrapper GradeFromSelect { get; private set; }
        public SelectElementWrapper GradeToSelect { get; private set; }

        public By ByTitle_textbox { get { return By.Id(ControlPrefix + "TextBoxPassageTitle"); } }
        public WebElementWrapper Title_textbox { get; private set; }

        public By ByOptionalProperties_link { get { return By.Id("lnkMoreOptions"); } }
        public WebElementWrapper OptionalProperties_link { get; private set; }
        public By ByOptionalProperties_icon { get { return By.CssSelector("#lnkMoreOptions > i"); } }
        public WebElementWrapper OptionalProperties_icon { get; private set; }

        public By ByAdditionalPassageID_textbox { get { return By.Id(ControlPrefix + "UIN"); } }
        public WebElementWrapper AdditionalPassageID_textbox { get; private set; }

        public By ByAssetType_textbox { get { return By.Id(ControlPrefix + "AssetType"); } }
        public WebElementWrapper AssetType_textbox { get; private set; }

        public By ByAuthor_textbox { get { return By.Id(ControlPrefix + "TextBoxAuthor"); } }
        public WebElementWrapper Author_textbox { get; private set; }

        public By ByCourseID_textbox { get { return By.Id(ControlPrefix + "CourseID"); } }
        public WebElementWrapper CourseID_textbox { get; private set; }

        public By ByFleschKincaid_textbox { get { return By.Id(ControlPrefix + "TextBoxFleschKincaid"); } }
        public WebElementWrapper FleschKincaid_textbox { get; private set; }

        public By ByGenre_textbox { get { return By.Id(ControlPrefix + "TextBoxGenre"); } }
        public WebElementWrapper Genre_textbox { get; private set; }

        public By ByQuestionLanguage_dropdown { get { return By.Id(ControlPrefix + "ddlLanguages"); } }
        //public By ByQuestionLanguage_dropdown { get { return By.Id(ControlPrefix + "DropDownListLanguages"); } }
        public SelectElementWrapper QuestionLanguage_dropdown { get; private set; }

        public By ByLexileCode_dropdown { get { return By.Id(ControlPrefix + "ddlLexileCodes"); } }
        public SelectElementWrapper LexileCode_dropdown { get; private set; }

        public By ByLexile_textbox { get { return By.Id(ControlPrefix + "TextBoxLexile"); } }
        public WebElementWrapper Lexile_textbox { get; private set; }

        public By ByBeginningReader_chkbox { get { return By.Id(ControlPrefix + "CheckBoxLexile"); } }
        public WebElementWrapper BeginningReader_chkbox { get; private set; }

        public By ByPublisher_textbox { get { return By.Id(ControlPrefix + "TextBoxPublisher"); } }
        public WebElementWrapper Publisher_textbox { get; private set; }

        public By ByReadingMaturityMetric_textbox { get { return By.Id(ControlPrefix + "RMM"); } }
        public WebElementWrapper ReadingMaturityMetric_textbox { get; private set; }

        public By ByTopic_textbox { get { return By.Id(ControlPrefix + "TextBoxTopic"); } }
        public WebElementWrapper Topic_textbox { get; private set; }

        //public By ByType_dropdown { get { return By.Id(ControlPrefix + "DropDownListTypes"); } }
        public By ByType_dropdown { get { return By.Id(ControlPrefix + "ddlTypes"); } }
        public SelectElementWrapper Type_dropdown { get; private set; }

        public By ByYear_textbox { get { return By.Id(ControlPrefix + "Year"); } }
        public WebElementWrapper Year_textbox { get; private set; }

        public By ByBatch_textbox { get { return By.Id(ControlPrefix + "Batch"); } }
        public WebElementWrapper Batch_textbox { get; private set; }

        private TeacherInstruction TeacherInstruction { get; set; }
        public TeacherInstructionEditor TeacherInstructionEditor { get; private set; }

        public Editor Editor { get; private set; }

        public By ByPortraitLayout { get { return By.Id(ControlPrefix + "rboListOrientation_0"); } }
        public WebElementWrapper PortraitLayout { get; private set; }

        public By ByLandscapeLayout { get { return By.Id(ControlPrefix + "rboListOrientation_1"); } }
        public WebElementWrapper LandscapeLayout { get; private set; }

        //public By ByEditorContentArea { get { return By.Id("tinymce"); } }//{ get { return By.TagName("body"); } }
        //public WebElementWrapper EditorContentArea { get; private set; }

        //public By ByThesaurus { get { return By.CssSelector("#divEditor > .modal-footer > input[value='Thesaurus']"); } }
        //public WebElementWrapper Thesaurus { get; private set; }

        //public override By ByTextArea { get { return By.CssSelector("#divEditor .mceLast > #" + ControlPrefix + "EditTestItemControl_HtmlEditor_Editor1_ifr #tinymce"); } }
        //public By ByTextArea { get { return By.CssSelector("#divEditor .mceLast > #" + ControlPrefix + "HtmlEditor_HtmlEditor_ifr #tinymce"); } }
        //public WebElementWrapper TextArea { get; private set; }

        //wait.Until(d => d.FindElement(By.CssSelector("textarea[id$='HtmlEditor']")), "The Passage Text Area did not load onto the page yet");
        //   HtmlEditorHelper ed = new HtmlEditorHelper(driver, "HtmlEditor_HtmlEditor_ifr", "", false);           

        /// <summary>
        /// select show optional properties link
        /// </summary>
        public void SelectShowOptionalProperties()
        {
            OptionalProperties_link.Wait(2);
            OptionalProperties_icon.Wait(2);
            OptionalProperties_icon.FakeAttributeClass = "icon-chevron-down";
            if (OptionalProperties_icon.GetAttribute("class").Trim().ToLower().Contains("icon-chevron-down"))
            {
                OptionalProperties_link.Click();
            }
        }

        /// <summary>
        /// select show optional properties link
        /// </summary>
        public void SelectHideOptionalProperties()
        {
            OptionalProperties_link.Wait(2);
            OptionalProperties_icon.Wait(2);
            OptionalProperties_icon.FakeAttributeClass = "icon-chevron-up";
            if (OptionalProperties_icon.GetAttribute("class").Trim().ToLower().Contains("icon-chevron-up"))
            {
                OptionalProperties_link.Click();
            }
        }

        // TO BE ADDED LATER TO COMPONENTS
        // SelectCourseName method to check/uncheck checkbox 
        // Parameters:
        // WebElementWrapper checkBox 
        // bool status = true  - check the checkbox
        // bool status = false - uncheck the checkbox
        public void CheckBoxClick(WebElementWrapper checkBox, bool status)
        {
            switch (status)
            {
                case true:
                    if (!checkBox.Selected)
                    {
                        checkBox.Click();
                    }
                    break;
                case false:
                    if (checkBox.Selected)
                    {
                        checkBox.Click();
                    }
                    break;
            }
        }

        /// <summary>
        /// add item buttom
        /// </summary>
        /// <returns>ItemTypeFormMultipleChoice</returns>
        public ItemTypeForm ClickAddItemButton()
        {
            AddItem_button.Click();
            return new ItemTypeMultipleChoiceForm();
        }

        /// <summary>
        /// input teacher instructions
        /// </summary>
        public void InputTeacherInstructions()
        {
            TeacherInstruction.Control.Wait(3).Click();
            TeacherInstructionEditor.Form.ContentData = Data.AddTeacherInstructions;
            TeacherInstructionEditor.Form.InputAndSubmitForm();
        }

        /// <summary>
        /// save
        /// </summary>
        /// <returns></returns>
        public PassageDetailPage ClickSave()
        {
            Save_button.Wait(3).Click();
            return new PassageDetailPage();
        }

        /// <summary>
        /// edit passage fields
        /// </summary>
        /// <param name="field">field</param>
        /// <param name="InputData">input data</param>
        public void EditPassageFields(string field, string InputData)
        {
            switch (field)
            {
                case "Title_textbox":
                    {
                        Title_textbox.Clear();
                        Title_textbox.SendKeys(InputData);
                        break;
                    }
                case "GradeLow":
                    {
                        GradeFromSelect.Wait(3).SelectByText(InputData);
                        break;
                    }
                case "GradeHigh":
                    {
                        GradeToSelect.Wait(3).SelectByText(InputData);
                        break;
                    }
                case "LandScape":
                    {
                        LandscapeLayout.Selected = true;
                        break;
                    }
                case "Portrait":
                    {
                        LandscapeLayout.Selected = true;
                        break;
                    }
            }
        }

        public override void InputFormFields()
        {

            //if (string.IsNullOrWhiteSpace(Data.Title))
            //{
            //    Title_textbox.SendKeys(Data.Title);
            //    //Data.Title = string.Format("Web Test Passage: {0}", DateTime.Now.ToString("yyMMddMMssfff"));
            //}

            if (Data.Title != null)
            {
                Title_textbox.Wait(5).Clear();
                Title_textbox.SendKeys(Data.Title);
            }
            if (Data.Subject != null)
            {
                SubjectSelect.Wait(5).SelectByText(Data.Subject);
            }
            if (Data.GradeLow != null)
            {
                GradeFromSelect.Wait(5).SelectByText(Data.GradeLow);
                this.DriverCommands.WaitAndMeasurePageLoadTime();
                InitElements();
            }
            if (Data.GradeHigh != null)
            {
                GradeToSelect.Wait(5).SelectByText(Data.GradeHigh);
                this.DriverCommands.WaitAndMeasurePageLoadTime();
                InitElements();
            }

            //HideOptionalProperties_link.Wait(5).Click();
            SelectShowOptionalProperties();

            if (Data.AdditionalPassageID != null)
            {
                AdditionalPassageID_textbox.Wait(5).Clear();
                AdditionalPassageID_textbox.SendKeys(Data.AdditionalPassageID);
            }
            if (Data.AssetType != null)
            {
                AssetType_textbox.Wait(5).Clear();
                AssetType_textbox.SendKeys(Data.AssetType);
            }
            if (Data.Author != null)
            {
                Author_textbox.Wait(5).Clear();
                Author_textbox.SendKeys(Data.Author);
            }
            if (Data.CourseID != null)
            {
                CourseID_textbox.Wait(5).Clear();
                CourseID_textbox.SendKeys(Data.CourseID);
            }
            if (Data.FleschKincaid != null)
            {
                FleschKincaid_textbox.SendKeys(Data.FleschKincaid);
            }
            if (Data.Genre != null)
            {
                Genre_textbox.Wait(5).Clear();
                Genre_textbox.SendKeys(Data.Genre);
            }
            if (Data.QuestionLanguage != null)
            {
                QuestionLanguage_dropdown.Wait(5).SelectByText(Data.QuestionLanguage);
                this.DriverCommands.WaitAndMeasurePageLoadTime();
                InitElements();
                //when selecting a different language, the page reloads and hides the optional properties
                SelectShowOptionalProperties();
            }
            if (Data.LexileCode != null) // new, implemented in 160
            {
                LexileCode_dropdown.Wait(5).SelectByText(Data.LexileCode);
            }
            if (Data.Lexile != null)
            {
                Lexile_textbox.Wait(5).Clear();
                Lexile_textbox.SendKeys(Data.Lexile);
            }
            // commented for 160 since checkbox is removed
            //if (Data.BeginningReader != null)
            //{
            //    if (Data.BeginningReader.Equals("1"))
            //    {
            //        SelectCourseName(BeginningReader_chkbox, true);
            //    }
            //}
            if (Data.Publisher != null)
            {
                Publisher_textbox.Wait(5).Clear();
                Publisher_textbox.SendKeys(Data.Publisher);
            }
            if (Data.ReadingMaturityMetric != null)
            {
                ReadingMaturityMetric_textbox.Wait(5).SendKeys(Data.ReadingMaturityMetric);
            }
            if (Data.Topic != null)
            {
                Topic_textbox.Wait(5).Clear();
                Topic_textbox.SendKeys(Data.Topic);
            }
            if (Data.Type != null)
            {
                Type_dropdown.Wait(5).SelectByText(Data.Type);
            }
            if (Data.Year != null)
            {
                Year_textbox.Wait(5).Clear();
                Year_textbox.SendKeys(Data.Year);
            }
            if (Data.Batch != null)
            {
                Batch_textbox.Wait(5).Clear();
                Batch_textbox.Wait(5).SendKeys(Data.Batch);
            }
            if (Data.PassageText != null)
            {
                this.Utilities.DoFileUpload(Editor, Data.AutoItData, Data.FileUploadTree, Data.PassageText);

                Editor.ContentData = Data.PassageText;
                Editor.InputFormFields();
            }
        }
    }
}
