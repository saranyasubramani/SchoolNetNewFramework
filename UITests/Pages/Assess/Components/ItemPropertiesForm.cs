using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Framework;
using UITests.Pages.Controls;
using UITests.Pages.Components;
using UITests.Pages.Components.Editors;
using UITests.Pages.Assess.Standards;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;

namespace UITests.Pages.Assess.Components
{
    /// <summary>
    /// the item properties form
    /// </summary>
    public class ItemPropertiesForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="pageName">the page name</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemPropertiesForm(PageNames pageName, string overrideControlPrefix = null)
            : base()
        {
            PageNames = pageName;
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }

            InitElements();

            FieldNames = new List<ItemPropertiesFields>()
            {
                ItemPropertiesFields.Subject, ItemPropertiesFields.GradeLevelFrom, ItemPropertiesFields.GradeLevelTo,
                ItemPropertiesFields.QuestionLanguage, ItemPropertiesFields.ResponseLanguage, ItemPropertiesFields.Name,
                ItemPropertiesFields.Publisher, ItemPropertiesFields.Keywords, ItemPropertiesFields.AdditionalItemIdentifier,
                ItemPropertiesFields.Author, ItemPropertiesFields.AuthoredDifficulty, ItemPropertiesFields.Batch,
                ItemPropertiesFields.BloomsTaxonomy, ItemPropertiesFields.CognitiveDemandLevel, ItemPropertiesFields.CourseId,
                ItemPropertiesFields.CurriculumMT, ItemPropertiesFields.CurriculumST, ItemPropertiesFields.CourseSpecificItems,
                ItemPropertiesFields.Relativity, ItemPropertiesFields.ItemCategory, ItemPropertiesFields.Webb,
                ItemPropertiesFields.Year, ItemPropertiesFields.CreatedBy
            };
            //TODO align to a standard does not display on task item type
            ExpectedRequiredErrorsList = new List<string>()
            {
                "Select a subject", 
                "Select a grade level",
                "Align to a standard"
            };
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            switch (PageNames)
            {
                case PageNames.CreateNewItem:
                    //ctl00_MainContent_EditTestItemControl_txtKeyword
                    ControlMiddle = "EditTestItemControl_";
                    break;
                case PageNames.EditTestItem:
                    //ctl00_MainContent_EditTestItemControl_txtKeyword
                    ControlMiddle = "EditTestItemControl_";
                    break;
                case PageNames.EditTask:
                    //ctl00_MainContent_EditTestItemControl_txtKeyword
                    ControlMiddle = "EditTestItemControl_";
                    break;
                case PageNames.EditQuestion:
                    //ctl00_MainContent_EditTestItemControl_UIN
                    ControlMiddle = "EditTestItemControl_";
                    break;
                case PageNames.ItemCentral:
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_txtKeyword
                    ControlMiddle = "ItemFinder1_ItemFinderSearch1_";
                    break;
                case PageNames.EditRubric:
                    //ctl00_MainContent_ctl00_TextBoxKeyword
                    ControlMiddle = "ctl00_";
                    break;
            }

            //Subject = new Subject(Driver, PageNames, this.ControlPrefix);
            //GradeLevel = new GradeLevel(Driver, PageNames, this.ControlPrefix);
            SubjectElement subject = new SubjectElement(PageNames, this.ControlPrefix);
            SubjectSelect = subject.SelectElement;
            GradeLevelElement gradeLevel = new GradeLevelElement(PageNames, this.ControlPrefix);
            GradeFromSelect = gradeLevel.FromSelectElement;
            GradeToSelect = gradeLevel.ToSelectElement;

            ItemTypeControl = new ItemTypeControl(PageNames, ControlPrefix);
            StandardControlsForm = new StandardControlsForm(PageNames, ControlPrefix);
            TeacherInstruction = new TeacherInstruction(PageNames);
            TeacherInstructionEditor = new TeacherInstructionEditor(PageNames);
            QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(ByQuestionLanguage));
            ResponseLanguage = new SelectElementWrapper(new WebElementWrapper(ByResponseLanguage));
            Name = new WebElementWrapper(ByName);
            Publisher = new WebElementWrapper(ByPublisher);
            Keywords = new WebElementWrapper(ByKeywords);
            ShowMoreLess = new WebElementWrapper(ByShowMoreLess);
            //more fields
            AdditionalItemIdentifier = new WebElementWrapper(ByAdditionalItemIdentifier);
            Author = new WebElementWrapper(ByAuthor);
            AuthoredDifficulty = new SelectElementWrapper(new WebElementWrapper(ByAuthoredDifficulty));
            Batch = new WebElementWrapper(ByBatch);
            BloomsTaxonomy = new SelectElementWrapper(new WebElementWrapper(ByBloomsTaxonomy));
            CognitiveDemandLevel = new SelectElementWrapper(new WebElementWrapper(ByCognitiveDemandLevel));
            CourseId = new WebElementWrapper(ByCourseId);
            CourseSpecificItems = new SelectElementWrapper(new WebElementWrapper(ByCourseSpecificItems));
            CurriculumMT = new SelectElementWrapper(new WebElementWrapper(ByCurriculumMT));
            CurriculumST = new SelectElementWrapper(new WebElementWrapper(ByCurriculumST));
            Relativity = new SelectElementWrapper(new WebElementWrapper(ByRelativity));
            HardToMeasureYes = new WebElementWrapper(ByHardToMeasureYes);
            HardToMeasureNo = new WebElementWrapper(ByHardToMeasureNo);
            ItemCategory = new WebElementWrapper(ByItemCategory);
            Webb = new SelectElementWrapper(new WebElementWrapper(ByWebb));
            Year = new WebElementWrapper(ByYear);
            CreatedBy = new SelectElementWrapper(new WebElementWrapper(ByCreatedBy));
            //TODO ReadingLevels combo box
            ReadingLevelsText = new WebElementWrapper(ByReadingLevelsText);
            ReadingLevelsFromText = new WebElementWrapper(ByReadingLevelsFromText);
            ReadingLevelsToText = new WebElementWrapper(ByReadingLevelsToText);
            StepsToCompleteLabels = new WebElementWrapper(ByStepsToCompleteLabels);
        }

        /// <summary>
        /// the data
        /// </summary>
        public ItemTypeData Data
        {
            get
            {
                return (ItemTypeData)base.Data;
            }
            set
            {
                Report.Write("Martin... in ItemPropertiesForm.Data...");
                base.Data = value;
            }
        }

        protected AutoItData _autoItDataObject;
        /// <summary>
        /// Auto It Data Object
        /// </summary>
        public AutoItData AutoItDataObject
        {
            get
            {
                return _autoItDataObject;
            }
            set
            {
                _autoItDataObject = value;
            }
        }

        private PageNames PageNames { get; set; }
        /// <summary>
        /// the subject control
        /// </summary>
        public SelectElementWrapper SubjectSelect { get; private set; }
        /// <summary>
        /// the grade level controls
        /// </summary>
        public SelectElementWrapper GradeFromSelect { get; private set; }
        /// <summary>
        /// the grade level controls
        /// </summary>
        public SelectElementWrapper GradeToSelect { get; private set; }

        protected List<ItemPropertiesFields> FieldNames { get; set; }
        public List<string> ExpectedRequiredErrorsList { get; set; }

        protected By ByStepsToCompleteLabels { get { return By.CssSelector(".well .divTable .divTableCell > span"); } }
        protected WebElementWrapper StepsToCompleteLabels { get; private set; }

        private ItemTypeControl ItemTypeControl { get; set; }
        private StandardControlsForm StandardControlsForm { get; set; }
        private TeacherInstruction TeacherInstruction { get; set; }
        public TeacherInstructionEditor TeacherInstructionEditor { get; private set; }

        private string ControlMiddle { get; set; }
        private By ByQuestionLanguage { get { return QuestionLanguageLocator(); } }
        private SelectElementWrapper QuestionLanguage { get; set; }
        private By ByResponseLanguage { get { return By.Id(ControlPrefix + "ddlResponseLanguage"); } }
        private SelectElementWrapper ResponseLanguage { get; set; }

        private By ByName { get { return NameLocator(); } }
        private WebElementWrapper Name { get; set; }
        private By ByPublisher { get { return PublisherLocator(); } }
        private WebElementWrapper Publisher { get; set; }
        private By ByKeywords { get { return KeywordLocator(); } }
        private WebElementWrapper Keywords { get; set; }
        private By ByShowMoreLess { get { return ShowMoreLessLocator(); } }
        private WebElementWrapper ShowMoreLess { get; set; }

        //more fields
        private By ByAdditionalItemIdentifier { get { return By.Id(ControlPrefix + ControlMiddle + "UIN"); } }
        private WebElementWrapper AdditionalItemIdentifier { get; set; }
        private By ByAuthor { get { return AuthorLocator(); } }
        private WebElementWrapper Author { get; set; }
        private By ByAuthoredDifficulty { get { return AuthoredDifficultyLocator(); } }
        private SelectElementWrapper AuthoredDifficulty { get; set; }
        private By ByBatch { get { return By.Id(ControlPrefix + ControlMiddle + "Batch"); } }
        private WebElementWrapper Batch { get; set; }
        private By ByBloomsTaxonomy { get { return By.Id(ControlPrefix + ControlMiddle + "ddlBloomTaxa"); } }
        private SelectElementWrapper BloomsTaxonomy { get; set; }
        private By ByCognitiveDemandLevel { get { return By.Id(ControlPrefix + ControlMiddle + "ddlCognitiveDemandLevel"); } }
        private SelectElementWrapper CognitiveDemandLevel { get; set; }
        private By ByCourseId { get { return By.Id(ControlPrefix + ControlMiddle + "CourseID"); } }
        private WebElementWrapper CourseId { get; set; }
        private By ByCourseSpecificItems { get { return CourseSpecificItemsLocator(); } }
        private SelectElementWrapper CourseSpecificItems { get; set; }
        private By ByCurriculumMT { get { return CurriculumLocator(); } }
        private SelectElementWrapper CurriculumMT { get; set; }
        private By ByCurriculumST { get { return CurriculumLocator(); } }
        private SelectElementWrapper CurriculumST { get; set; }
        private By ByRelativity { get { return By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl01_ddlItemAttribute"); } }
        private SelectElementWrapper Relativity { get; set; }
        private By ByHardToMeasureYes { get { return By.Id(ControlPrefix + ControlMiddle + "HardToMeasure_0"); } }
        private WebElementWrapper HardToMeasureYes { get; set; }
        private By ByHardToMeasureNo { get { return By.Id(ControlPrefix + ControlMiddle + "HardToMeasure_1"); } }
        private WebElementWrapper HardToMeasureNo { get; set; }
        private By ByItemCategory { get { return By.Id(ControlPrefix + ControlMiddle + "ItemCategory"); } }
        private WebElementWrapper ItemCategory { get; set; }
        private By ByWebb { get { return By.Id(ControlPrefix + ControlMiddle + "ddlWebb"); } }
        private SelectElementWrapper Webb { get; set; }
        private By ByYear { get { return By.Id(ControlPrefix + ControlMiddle + "Year"); } }
        private WebElementWrapper Year { get; set; }
        private By ByCreatedBy { get { return By.Id(ControlPrefix + ControlMiddle + "ddlItemAvailability"); } }
        private SelectElementWrapper CreatedBy { get; set; }
        //TODO ReadingLevels special control combo box
        private By ByReadingLevelsText { get { return By.ClassName("combobox"); } }
        private WebElementWrapper ReadingLevelsText { get; set; }
        //private By ByReadingLevelsSelect { get { return By.ClassName("combobox"); } }
        //private SelectElementWrapper ReadingLevelsSelect { get; set; }
        private By ByReadingLevelsFromText { get { return By.ClassName("combobox"); } }
        private WebElementWrapper ReadingLevelsFromText { get; set; }
        private By ByReadingLevelsToText { get { return By.ClassName("combobox"); } }
        private WebElementWrapper ReadingLevelsToText { get; set; }

        private By ShowMoreLessLocator()
        {
            By by = null;
            switch (PageNames)
            {
                case PageNames.CreateNewItem:
                    by = By.Id("lnkMoreOptions");
                    break;
                case PageNames.EditTestItem:
                    by = By.Id("lnkMoreOptions");
                    break;
                case PageNames.EditTask:
                    by = By.Id("lnkMoreOptions");
                    break;
                case PageNames.EditQuestion:
                    by = By.Id("lnkMoreOptions");
                    break;
                case PageNames.ItemCentral:
                    by = By.Id("lnkMoreOptions");
                    break;
                case PageNames.EditRubric:
                    by = By.Id("vopt");
                    break;
                case PageNames.CreatePassage:
                    by = By.Id("lnkMoreOptions");
                    break;
                case PageNames.EditPassage:
                    by = By.Id("lnkMoreOptions");
                    break;
            }
            return by;
        }

        private By QuestionLanguageLocator()
        {
            By by = null;
            switch (PageNames)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + "ddlLanguage");
                    break;
                case PageNames.EditTestItem:
                    by = By.Id(ControlPrefix + "ddlLanguage");
                    break;
                case PageNames.EditQuestion:
                    by = By.Id(ControlPrefix + "ddlLanguage");
                    break;
                case PageNames.ItemCentral:
                    by = By.Id(ControlPrefix + ControlMiddle + "ddlItemLanguages");
                    break;
                case PageNames.EditRubric:
                    by = By.Id(ControlPrefix + ControlMiddle + "TestLanguageSelector");
                    break;
                case PageNames.CreatePassage:
                    by = By.Id(ControlPrefix + "ddlLanguages");
                    break;
                case PageNames.EditPassage:
                    by = By.Id(ControlPrefix + "ddlLanguages");
                    break;
            }
            return by;
        }

        private By PublisherLocator()
        {
            By by = null;
            switch (PageNames)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + ControlMiddle + "AutoCompletePublisher");
                    break;
                case PageNames.EditTestItem:
                    by = By.Id(ControlPrefix + ControlMiddle + "AutoCompletePublisher");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + ControlMiddle + "AutoCompletePublisher");
                    break;
                case PageNames.EditQuestion:
                    by = By.Id(ControlPrefix + ControlMiddle + "AutoCompletePublisher");
                    break;
                case PageNames.ItemCentral:
                    by = By.Id(ControlPrefix + ControlMiddle + "txtPublisher");
                    break;
                case PageNames.EditRubric:
                    by = By.Id(ControlPrefix + ControlMiddle + "TextBoxPublisher");
                    break;
                case PageNames.CreatePassage:
                    by = By.Id(ControlPrefix + ControlMiddle + "TextBoxPublisher");
                    break;
                case PageNames.EditPassage:
                    by = By.Id(ControlPrefix + ControlMiddle + "TextBoxPublisher");
                    break;
            }
            return by;
        }

        private By KeywordLocator()
        {
            By by = null;
            switch (PageNames)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + ControlMiddle + "txtKeyword");
                    break;
                case PageNames.EditTestItem:
                    by = By.Id(ControlPrefix + ControlMiddle + "txtKeyword");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + ControlMiddle + "txtKeyword");
                    break;
                case PageNames.EditQuestion:
                    by = By.Id(ControlPrefix + ControlMiddle + "txtKeyword");
                    break;
                case PageNames.ItemCentral:
                    by = By.Id(ControlPrefix + ControlMiddle + "txtKeyword");
                    break;
                case PageNames.EditRubric:
                    by = By.Id(ControlPrefix + ControlMiddle + "TextBoxKeyword");
                    break;
                case PageNames.CreatePassage:
                    //does not exist for EditPassage
                    by = By.Id("");
                    break;
                case PageNames.EditPassage:
                    //does not exist for EditPassage
                    by = By.Id("");
                    break;
            }
            return by;
        }

        private By NameLocator()
        {
            By by = null;
            switch (PageNames)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + ControlMiddle + "txtName");
                    break;
                case PageNames.EditTestItem:
                    by = By.Id(ControlPrefix + ControlMiddle + "txtName");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + ControlMiddle + "txtName");
                    break;
                case PageNames.EditQuestion:
                    by = By.Id(ControlPrefix + ControlMiddle + "txtName");
                    break;
                case PageNames.ItemCentral:
                    by = By.Id(ControlPrefix + ControlMiddle + "txtItemName");
                    break;
                case PageNames.EditRubric:
                    by = By.Id(ControlPrefix + ControlMiddle + "TextBoxName");
                    break;
                case PageNames.CreatePassage:
                    //does not exist for EditPassage
                    by = By.Id("");
                    break;
                case PageNames.EditPassage:
                    //does not exist for EditPassage
                    by = By.Id("");
                    break;
            }
            return by;
        }

        private By AuthorLocator()
        {
            By by = null;
            switch (PageNames)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + ControlMiddle + "AutoCompleteAuthor");
                    break;
                case PageNames.EditTestItem:
                    by = By.Id(ControlPrefix + ControlMiddle + "AutoCompleteAuthor");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + ControlMiddle + "AutoCompleteAuthor");
                    break;
                case PageNames.EditQuestion:
                    by = By.Id(ControlPrefix + ControlMiddle + "AutoCompleteAuthor");
                    break;
                case PageNames.ItemCentral:
                    by = By.Id(ControlPrefix + ControlMiddle + "txtAuthor");
                    break;
                case PageNames.CreatePassage:
                    by = By.Id(ControlPrefix + ControlMiddle + "TextBoxAuthor");
                    break;
                case PageNames.EditPassage:
                    by = By.Id(ControlPrefix + ControlMiddle + "TextBoxAuthor");
                    break;
            }
            return by;
        }

        private By AuthoredDifficultyLocator()
        {
            By by = null;
            switch (PageNames)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + ControlMiddle + "ddlDifficulty");
                    break;
                case PageNames.EditTestItem:
                    by = By.Id(ControlPrefix + ControlMiddle + "ddlDifficulty");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + ControlMiddle + "ddlDifficulty");
                    break;
                case PageNames.EditQuestion:
                    by = By.Id(ControlPrefix + ControlMiddle + "ddlDifficulty");
                    break;
                case PageNames.ItemCentral:
                    by = By.Id(ControlPrefix + ControlMiddle + "ddlAuthoredDifficulty");
                    break;
                case PageNames.CreatePassage:
                    //does not exist for EditPassage
                    by = By.Id("");
                    break;
                case PageNames.EditPassage:
                    //does not exist for EditPassage
                    by = By.Id("");
                    break;
            }
            return by;
        }

        private By CourseSpecificItemsLocator()
        {
            By by = null;
            switch (PageNames)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl00_ddlItemAttribute");
                    break;
                case PageNames.EditTestItem:
                    by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl00_ddlItemAttribute");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl00_ddlItemAttribute");
                    break;
                case PageNames.EditQuestion:
                    by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl00_ddlItemAttribute");
                    break;
                case PageNames.ItemCentral:
                    by = By.Id(ControlPrefix + ControlMiddle + "RepeaterCustomCategory_ctl00_ddlCustomCategory");
                    break;
                case PageNames.CreatePassage:
                    //does not exist for EditPassage
                    by = By.Id("");
                    break;
                case PageNames.EditPassage:
                    //does not exist for EditPassage
                    by = By.Id("");
                    break;
            }
            return by;
        }

        private By CurriculumLocator()
        {
            By by = null;
            switch (PageNames)
            {
                case PageNames.CreateNewItem:
                    if (this.TestConfiguration.ApplicationName.Equals(ApplicationName.schoolnetmultitenant))
                    {
                        by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl00_ddlItemAttribute");
                    }
                    else
                    {
                        //by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl01_ddlItemAttribute");
                        //changed for release 16.3
                        by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl02_ddlItemAttribute");
                    }
                    break;
                case PageNames.EditTestItem:
                    if (this.TestConfiguration.ApplicationName.Equals(ApplicationName.schoolnetmultitenant))
                    {
                        by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl00_ddlItemAttribute");
                    }
                    else
                    {
                        //by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl01_ddlItemAttribute");
                        //changed for release 16.3
                        by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl02_ddlItemAttribute");
                    }
                    break;
                case PageNames.EditTask:
                    if (this.TestConfiguration.ApplicationName.Equals(ApplicationName.schoolnetmultitenant))
                    {
                        by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl00_ddlItemAttribute");
                    }
                    else
                    {
                        //by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl01_ddlItemAttribute");
                        //changed for release 16.3
                        by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl02_ddlItemAttribute");
                    }
                    break;
                case PageNames.EditQuestion:
                    if (this.TestConfiguration.ApplicationName.Equals(ApplicationName.schoolnetmultitenant))
                    {
                        by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl00_ddlItemAttribute");
                    }
                    else
                    {
                        //by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl01_ddlItemAttribute");
                        //changed for release 16.3
                        by = By.Id(ControlPrefix + ControlMiddle + "RepeaterItemAttributeTypes_ctl02_ddlItemAttribute");
                    }
                    break;
                case PageNames.ItemCentral:
                    by = By.Id(ControlPrefix + ControlMiddle + "RepeaterCustomCategory_ctl01_ddlCustomCategory");
                    break;
                case PageNames.CreatePassage:
                    //does not exist for EditPassage
                    by = By.Id("");
                    break;
                case PageNames.EditPassage:
                    //does not exist for EditPassage
                    by = By.Id("");
                    break;
            }
            return by;
        }

        //specific methods

        /// <summary>
        /// select the standard lookup button, and opens the standard popup dialog (page)
        /// </summary>
        /// <returns>StandardPopupDialog</returns>
        public StandardPopupDialog StandardLookup()
        {
            StandardPopupDialog standardPopupDialog = StandardControlsForm.StandardLookup_StandardPopup();
            InitElements();
            return standardPopupDialog;
        }

        /// <summary>
        /// select show more link
        /// </summary>
        public void SelectShowMore()
        {
            ShowMoreLess.Wait(3).Click();
        }

        /// <summary>
        /// select show less link
        /// </summary>
        public void SelectShowLess()
        {
            ShowMoreLess.Wait(3).Click();
        }

        //todo: rename
        public void SelectEditStandard()
        {
            StandardControlsForm.EditStandard();
        }

        /// <summary>
        /// select hard to measure: yes
        /// </summary>
        public void SelectHardToMeasureYes()
        {
            HardToMeasureYes.Click();
        }

        /// <summary>
        /// select hard to measure: no
        /// </summary>
        public void SelectHardToMeasureNo()
        {
            HardToMeasureNo.Click();
        }

        /// <summary>
        /// check item type: multiple choice
        /// </summary>
        public void SelectMultipleChoice()
        {
            ItemTypeControl.SelectItemType();
            ItemTypeControl.MultipleChoice();
            ItemTypeControl.Ok();
        }

        /// <summary>
        /// check item type: gridded
        /// </summary>
        public void SelectGridded()
        {
            ItemTypeControl.SelectItemType();
            ItemTypeControl.Gridded();
            ItemTypeControl.Ok();
        }

        /// <summary>
        /// check item type: true/false
        /// </summary>
        public void SelectTrueFalse()
        {
            ItemTypeControl.SelectItemType();
            ItemTypeControl.TrueFalse();
            ItemTypeControl.Ok();
        }

        /// <summary>
        /// check item type: open response
        /// </summary>
        public void SelectOpenResponse()
        {
            ItemTypeControl.SelectItemType();
            ItemTypeControl.OpenResponse();
            ItemTypeControl.Ok();
        }

        /// <summary>
        /// check item type: inline response
        /// </summary>
        public void SelectInlineResponse()
        {
            ItemTypeControl.SelectItemType();
            ItemTypeControl.InlineResponse();
            ItemTypeControl.Ok();
        }

        /// <summary>
        /// check item type: matching
        /// </summary>
        public void SelectMatching()
        {
            ItemTypeControl.SelectItemType();
            ItemTypeControl.Matching();
            ItemTypeControl.Ok();
        }

        /// <summary>
        /// check item type: task
        /// </summary>
        public void SelectTask()
        {
            ItemTypeControl.SelectItemType();
            ItemTypeControl.Task();
            ItemTypeControl.Ok();
        }

        /// <summary>
        /// check item type: hot spot single selection
        /// </summary>
        public void SelectHotSpotSingleSelection()
        {
            ItemTypeControl.SelectItemType();
            ItemTypeControl.HotSpotSingleSelection();
            ItemTypeControl.Ok();
        }

        /// <summary>
        /// check item type: hot spot multiple selection
        /// </summary>
        public void SelectHotSpotMultipleSelection()
        {
            ItemTypeControl.SelectItemType();
            ItemTypeControl.HotSpotMultipleSelection();
            ItemTypeControl.Ok();
        }

        /// <summary>
        /// check item type: drag and drop
        /// </summary>
        public void SelectDragAndDrop()
        {
            ItemTypeControl.SelectItemType();
            ItemTypeControl.DragAndDrop();
            ItemTypeControl.Ok();
        }

        /// <summary>
        /// check item type: click stick click drop
        /// </summary>
        public void SelectClickStickClickDrop()
        {
            ItemTypeControl.SelectItemType();
            ItemTypeControl.ClickStickClickDrop();
            ItemTypeControl.Ok();
        }

        /// <summary>
        /// select teacher instructions
        /// </summary>
        public void InputTeacherInstructions()
        {
            if (Data.TeacherInstruction != null)
            {
                TeacherInstruction.Control.Wait(5).Click();
                DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
                InitElements();
                this.Utilities.DoFileUpload(TeacherInstructionEditor, _autoItDataObject, Data.FileUploadTree, Data.TeacherInstruction);
                TeacherInstructionEditor.Form.ContentData = Data.TeacherInstruction;
                TeacherInstructionEditor.Form.InputAndSubmitForm();
            }
        }

        /// <summary>
        /// select the question language
        /// </summary>
        public void SelectQuestionLanguage()
        {
            QuestionLanguage.Wait(5).SelectByText(Data.QuestionLanguage);
            //QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(Driver, ByQuestionLanguage));
            //ResponseLanguage = new SelectElementWrapper(new WebElementWrapper(Driver, ByResponseLanguage));
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();
        }
        /// <summary>
        /// select the response language
        /// </summary>
        public void SelectResponseLanguage()
        {
            ResponseLanguage.Wait(5).SelectByText(Data.ResponseLanguage);
            //QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(Driver, ByQuestionLanguage));
            //ResponseLanguage = new SelectElementWrapper(new WebElementWrapper(Driver, ByResponseLanguage));
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();
        }


        #region Input various form fields

        private void InputFormFields_CreateNewItemPage()
        {
            this.SubjectSelect.Wait().SelectByText(Data.Subject);
            //GradeLevel.From.Wait(5);
            this.GradeFromSelect.Wait(5).SelectByText(Data.GradeLow);
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();

            //GradeLevel.To.Wait(5);
            this.GradeToSelect.Wait(5).SelectByText(Data.GradeHigh);
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();

            //QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(Driver, ByQuestionLanguage));
            QuestionLanguage.Wait(5).SelectByText(Data.QuestionLanguage);
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();

            //ResponseLanguage = new SelectElementWrapper(new WebElementWrapper(Driver, ByResponseLanguage));
            ResponseLanguage.Wait(5).SelectByText(Data.ResponseLanguage);
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();

            Name.Wait(5).SendKeys(Data.Name);
            Publisher.Wait(5).Clear();
            Publisher.Wait(5).SendKeys(Data.Publisher);
            Keywords.Wait(5).SendKeys(Data.Keyword);

            InputTeacherInstructions();
        }

        public void InputFormFields_EditQuestionPage()
        {
            //QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(Driver, ByQuestionLanguage));
            QuestionLanguage.Wait(5).SelectByText(Data.QuestionLanguage);
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();

            //ResponseLanguage = new SelectElementWrapper(new WebElementWrapper(Driver, ByResponseLanguage));
            ResponseLanguage.Wait(5).SelectByText(Data.ResponseLanguage);
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();

            Name.Wait(5).SendKeys(Data.Name);
            Publisher.Wait(5).Clear();
            Publisher.Wait(5).SendKeys(Data.Publisher);
            Keywords.Wait(5).SendKeys(Data.Keyword);

            InputTeacherInstructions();
        }

        public void InputFormFields_EditTaskPage()
        {
            Name.Wait(5).SendKeys(Data.Name);
            Publisher.Wait(5).Clear();
            Publisher.Wait(5).SendKeys(Data.Publisher);
            Keywords.Wait(5).SendKeys(Data.Keyword);

            InputTeacherInstructions();
        }

        private void InputFormFields_ItemCentralPage()
        {
            if (Data.Subject != null)
            {
                SubjectSelect.Wait().SelectByText(Data.Subject);
            }
            if (Data.GradeLow != null)
            {
                GradeFromSelect.Wait(5);
                GradeFromSelect.Wait(5).SelectByText(Data.GradeLow);
            }
            if (Data.GradeHigh != null)
            {
                GradeToSelect.Wait(5);
                GradeToSelect.Wait(5).SelectByText(Data.GradeHigh);
            }

            if (Data.Keyword != null)
            {
                Keywords.Wait(5).SendKeys(Data.Keyword);
            }

            //TODO: bug 85672 - uncomment when fixed
            if (Data.Name != null)
            {
                Name.Wait(5).SendKeys(Data.Name);
            }

            //TODO add field to smoketestitem
            CreatedBy.Wait(5).SelectByText("Any Institution");
            //TODO add field to smoketestitem
            Author.Wait(5).SendKeys("");
            Publisher.Wait(5).Clear();
            Publisher.Wait(5).SendKeys(Data.Publisher);
            //TODO add field to smoketestitem
            AuthoredDifficulty.Wait(5).SelectByText("None Selected");
            //TODO add field to smoketestitem
            //TODO BloomsTaxonomy combo box
            //BloomsTaxonomy.Wait(5).SelectByText("Understanding");
            //TODO add field to smoketestitem
            CognitiveDemandLevel.Wait(5).SelectByText("None Selected");
            //TODO add field to smoketestitem
            QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(ByQuestionLanguage));
            QuestionLanguage.Wait(5).SelectByText("None Selected");
            //TODO ReadingLevels combo box

            //TODO add field to smoketestitem
            Webb.SelectByText("None Selected");
            if (this.TestConfiguration.ApplicationName.Equals(ApplicationName.schoolnetsingletenant))
            {
                //TODO add field to smoketestitem
                CourseSpecificItems.Wait(5).SelectByText("None Selected");
                //TODO add field to smoketestitem
                CurriculumST.Wait(5).SelectByText("None Selected");
                //TODO ReadingLevels combo box
            }
        }

        private void InputFormFields_EditRubricPage()
        {
            Name.Wait(5).SendKeys(Data.Name);
            this.SubjectSelect.Wait(5).SelectByText(Data.Subject);
            this.GradeFromSelect.Wait(5);
            this.GradeFromSelect.Wait(5).SelectByText(Data.GradeLow);
            this.GradeToSelect.Wait(5);
            this.GradeToSelect.Wait(5).SelectByText(Data.GradeHigh);
            QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(ByQuestionLanguage));
            QuestionLanguage.Wait(5).SelectByText(Data.QuestionLanguage);

            SelectShowMore();
            Keywords.Wait(5).SendKeys(Data.Keyword);
            Publisher.Wait(5).Clear();
            Publisher.Wait(5).SendKeys(Data.Publisher);
        }

        #endregion

        /// <summary>
        /// input show more form fields
        /// </summary>
        public void InputFormFieldsShowMore()
        {
            AdditionalItemIdentifier.Wait(5).SendKeys(Data.AdditionalItemIdentifier);
            //TODO add field to smoketestitem
            Author.SendKeys("Test, QA");
            //TODO add field to smoketestitem
            AuthoredDifficulty.SelectByText("Low");
            Batch.SendKeys(Data.Batch);
            //TODO add field to smoketestitem
            BloomsTaxonomy.SelectByText("Understanding");
            //TODO add field to smoketestitem
            CognitiveDemandLevel.SelectByText("Low");
            CourseId.SendKeys(Data.CourseId);
            if (this.TestConfiguration.ApplicationName.Equals(ApplicationName.schoolnetmultitenant))
            {
                //TODO add field to smoketestitem
                CurriculumMT.SelectByText("English 101");
                //TODO add field to smoketestitem
                Relativity.SelectByText("");
            }
            if (this.TestConfiguration.ApplicationName.Equals(ApplicationName.schoolnetsingletenant))
            {
                //TODO add field to smoketestitem
                //CourseSpecificItems.SelectByText("101");
                //TODO add field to smoketestitem
                CurriculumST.SelectByText("English 101");
                //TODO ReadingLevels combo box

            }
            ItemCategory.SendKeys(Data.ItemCategory);
            //TODO add field to smoketestitem
            Webb.SelectByText("Level 1: Recall");
            Year.SendKeys(Data.Year);
        }

        private void InputAllFieldsExcept_CreateNewItemPage(List<ItemPropertiesFields> excludeFields)
        {
            //do not input the excluded fields
            foreach (var excludeField in excludeFields)
            {
                //if the field does match, then make it blank
                if (excludeField.Equals(ItemPropertiesFields.Subject))
                {
                    this.SubjectSelect.Wait(3).SelectByValue("0");
                }
                if (excludeField.Equals(ItemPropertiesFields.GradeLevelFrom))
                {
                    this.GradeFromSelect.Wait(5).SelectByValue("0");
                    DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
                    InitElements();
                }

                if (excludeField.Equals(ItemPropertiesFields.GradeLevelTo))
                {
                    this.GradeToSelect.Wait(5).SelectByValue("0");
                    DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
                    InitElements();
                }

                if (excludeField.Equals(ItemPropertiesFields.QuestionLanguage))
                {
                    //QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(Driver, ByQuestionLanguage));
                    QuestionLanguage.Wait(5).SelectByValue("1");
                    DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
                    InitElements();
                }

                if (excludeField.Equals(ItemPropertiesFields.ResponseLanguage))
                {
                    //ResponseLanguage = new SelectElementWrapper(new WebElementWrapper(Driver, ByResponseLanguage));
                    ResponseLanguage.Wait(5).SelectByValue("1");
                    DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
                    InitElements();
                }

                if (excludeField.Equals(ItemPropertiesFields.Name))
                {
                    Name.Wait(5).Clear();
                }
                if (excludeField.Equals(ItemPropertiesFields.Publisher))
                {
                    Publisher.Wait(5).Clear();
                }
                if (excludeField.Equals(ItemPropertiesFields.Keywords))
                {
                    Keywords.Wait(5).Clear();
                }
            }
            //input the included fields
            foreach (var includeField in FieldNames)
            {
                //if the field does match, then input it
                if (includeField.Equals(ItemPropertiesFields.Subject))
                {
                    this.SubjectSelect.Wait(3).SelectByText(Data.Subject);
                }
                if (includeField.Equals(ItemPropertiesFields.GradeLevelFrom))
                {
                    this.GradeFromSelect.Wait(5).SelectByText(Data.GradeLow);
                    DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
                    InitElements();
                }
                if (includeField.Equals(ItemPropertiesFields.GradeLevelTo))
                {
                    this.GradeToSelect.Wait(5).SelectByText(Data.GradeHigh);
                    DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
                    InitElements();
                }
                if (includeField.Equals(ItemPropertiesFields.QuestionLanguage))
                {
                    //QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(Driver, ByQuestionLanguage));
                    QuestionLanguage.Wait(5).SelectByText(Data.QuestionLanguage);
                    DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
                    InitElements();
                }
                if (includeField.Equals(ItemPropertiesFields.ResponseLanguage))
                {
                    //ResponseLanguage = new SelectElementWrapper(new WebElementWrapper(Driver, ByResponseLanguage));
                    ResponseLanguage.Wait(5).SelectByText(Data.ResponseLanguage);
                    DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
                    InitElements();
                }
                if (includeField.Equals(ItemPropertiesFields.Name))
                {
                    Name.Wait(5).SendKeys(Data.Name);
                }
                if (includeField.Equals(ItemPropertiesFields.Publisher))
                {
                    Publisher.Wait(5).SendKeys(Data.Publisher);
                }
                if (includeField.Equals(ItemPropertiesFields.Keywords))
                {
                    Keywords.Wait(5).SendKeys(Data.Keyword);
                }
            }
        }

        public void InputAllFieldsExcept_EditQuestionPage(List<ItemPropertiesFields> excludeFields)
        {
            //do not input the excluded fields
            foreach (var excludeField in excludeFields)
            {
                //if the field does match, then make it blank
                if (excludeField.Equals(ItemPropertiesFields.QuestionLanguage))
                {
                    QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(ByQuestionLanguage));
                    QuestionLanguage.Wait(5).SelectByValue("1");
                    DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
                    InitElements();
                }
                if (excludeField.Equals(ItemPropertiesFields.ResponseLanguage))
                {
                    ResponseLanguage = new SelectElementWrapper(new WebElementWrapper(ByResponseLanguage));
                    ResponseLanguage.Wait(5).SelectByValue("1");
                    DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
                    InitElements();
                }
                if (excludeField.Equals(ItemPropertiesFields.Name))
                {
                    Name.Wait(5).Clear();
                }
                if (excludeField.Equals(ItemPropertiesFields.Publisher))
                {
                    Publisher.Wait(5).Clear();
                }
                if (excludeField.Equals(ItemPropertiesFields.Keywords))
                {
                    Keywords.Wait(5).Clear();
                }
            }
            //input the included fields
            foreach (var includeField in FieldNames)
            {
                //if the field does match, then input it
                if (includeField.Equals(ItemPropertiesFields.QuestionLanguage))
                {
                    QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(ByQuestionLanguage));
                    QuestionLanguage.Wait(5).SelectByText(Data.QuestionLanguage);
                    DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
                    InitElements();
                }
                if (includeField.Equals(ItemPropertiesFields.ResponseLanguage))
                {
                    ResponseLanguage = new SelectElementWrapper(new WebElementWrapper(ByResponseLanguage));
                    ResponseLanguage.Wait(5).SelectByText(Data.ResponseLanguage);
                    DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
                    InitElements();
                }
                if (includeField.Equals(ItemPropertiesFields.Name))
                {
                    Name.Wait(5).SendKeys(Data.Name);
                }
                if (includeField.Equals(ItemPropertiesFields.Publisher))
                {
                    Publisher.Wait(5).SendKeys(Data.Publisher);
                }
                if (includeField.Equals(ItemPropertiesFields.Keywords))
                {
                    Keywords.Wait(5).SendKeys(Data.Keyword);
                }
            }
        }

        private void InputAllFieldsExcept_ItemCentralPage(List<ItemPropertiesFields> excludeFields)
        {
            //do not input the excluded fields
            foreach (var excludeField in excludeFields)
            {
                //if the field does match, then make it blank
                if (excludeField.Equals(ItemPropertiesFields.Subject))
                {
                    this.SubjectSelect.Wait(3).SelectByValue("0");
                }
                if (excludeField.Equals(ItemPropertiesFields.GradeLevelFrom))
                {
                    this.GradeFromSelect.Wait(5).SelectByValue("0");
                }
                if (excludeField.Equals(ItemPropertiesFields.GradeLevelTo))
                {
                    this.GradeToSelect.Wait(5).SelectByValue("0");
                }
                if (excludeField.Equals(ItemPropertiesFields.QuestionLanguage))
                {
                    QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(ByQuestionLanguage));
                    QuestionLanguage.Wait(5).SelectByValue("1");
                }
                if (excludeField.Equals(ItemPropertiesFields.Name))
                {
                    Name.Wait(5).Clear();
                }
                if (excludeField.Equals(ItemPropertiesFields.Publisher))
                {
                    Publisher.Wait(5).Clear();
                }
                if (excludeField.Equals(ItemPropertiesFields.Keywords))
                {
                    Keywords.Wait(5).Clear();
                }
                if (excludeField.Equals(ItemPropertiesFields.CreatedBy))
                {
                    CreatedBy.Wait(5).SelectByValue("0");
                }
                if (excludeField.Equals(ItemPropertiesFields.Author))
                {
                    Author.Wait(5).Clear();
                }
                if (excludeField.Equals(ItemPropertiesFields.AuthoredDifficulty))
                {
                    AuthoredDifficulty.Wait(5).SelectByValue("0");
                }
                if (excludeField.Equals(ItemPropertiesFields.CognitiveDemandLevel))
                {
                    CognitiveDemandLevel.Wait(5).SelectByValue("0");
                }
                if (this.TestConfiguration.ApplicationName.Equals(ApplicationName.schoolnetsingletenant))
                {
                    if (excludeField.Equals(ItemPropertiesFields.CurriculumST))
                    {
                        CurriculumST.Wait(5).SelectByValue("0");
                    }
                    if (excludeField.Equals(ItemPropertiesFields.CourseSpecificItems))
                    {
                        CourseSpecificItems.Wait(5).SelectByValue("0");
                    }
                }
                if (excludeField.Equals(ItemPropertiesFields.Webb))
                {
                    Webb.Wait(5).SelectByValue("0");
                }
            }
            //input the included fields
            foreach (var includeField in FieldNames)
            {
                //if the field does match, then input it
                if (includeField.Equals(ItemPropertiesFields.Subject))
                {
                    this.SubjectSelect.Wait(3).SelectByText(Data.Subject);
                }
                if (includeField.Equals(ItemPropertiesFields.GradeLevelFrom))
                {
                    this.GradeFromSelect.Wait(5).SelectByText(Data.GradeLow);
                }
                if (includeField.Equals(ItemPropertiesFields.GradeLevelTo))
                {
                    this.GradeToSelect.Wait(5).SelectByText(Data.GradeHigh);
                }
                if (includeField.Equals(ItemPropertiesFields.QuestionLanguage))
                {
                    QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(ByQuestionLanguage));
                    QuestionLanguage.Wait(5).SelectByText(Data.QuestionLanguage);
                }
                if (includeField.Equals(ItemPropertiesFields.Name))
                {
                    Name.Wait(5).SendKeys(Data.Name);
                }
                if (includeField.Equals(ItemPropertiesFields.Publisher))
                {
                    Publisher.Wait(5).SendKeys(Data.Publisher);
                }
                if (includeField.Equals(ItemPropertiesFields.Keywords))
                {
                    Keywords.Wait(5).SendKeys(Data.Keyword);
                }
                if (includeField.Equals(ItemPropertiesFields.CreatedBy))
                {
                    CreatedBy.Wait(5).SelectByText("Any Institution");
                }
                if (includeField.Equals(ItemPropertiesFields.Author))
                {
                    Author.Wait(5).SendKeys("");
                }
                if (includeField.Equals(ItemPropertiesFields.AuthoredDifficulty))
                {
                    AuthoredDifficulty.Wait(5).SelectByText("Low");
                }
                if (includeField.Equals(ItemPropertiesFields.CognitiveDemandLevel))
                {
                    CognitiveDemandLevel.Wait(5).SelectByText("Low");
                }
                if (this.TestConfiguration.ApplicationName.Equals(ApplicationName.schoolnetsingletenant))
                {
                    if (includeField.Equals(ItemPropertiesFields.CurriculumST))
                    {
                        CurriculumST.Wait(5).SelectByText("English 101");
                    }
                    if (includeField.Equals(ItemPropertiesFields.CourseSpecificItems))
                    {
                        CourseSpecificItems.Wait(5).SelectByText("101");
                    }
                }
                if (includeField.Equals(ItemPropertiesFields.Webb))
                {
                    Webb.Wait(5).SelectByText("None Selected");
                }
            }
        }

        private void InputAllFieldsExcept_EditRubricPage(List<ItemPropertiesFields> excludeFields)
        {
            //show more
            SelectShowMore();

            //do not input the excluded fields
            foreach (var excludeField in excludeFields)
            {
                //if the field does match, then make it blank
                if (excludeField.Equals(ItemPropertiesFields.Subject))
                {
                    this.SubjectSelect.Wait(3).SelectByValue("0");
                }
                if (excludeField.Equals(ItemPropertiesFields.GradeLevelFrom))
                {
                    this.GradeFromSelect.Wait(5).SelectByValue("0");
                }
                if (excludeField.Equals(ItemPropertiesFields.GradeLevelTo))
                {
                    this.GradeToSelect.Wait(5).SelectByValue("0");
                }
                if (excludeField.Equals(ItemPropertiesFields.QuestionLanguage))
                {
                    QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(ByQuestionLanguage));
                    QuestionLanguage.Wait(5).SelectByValue("1");
                }
                if (excludeField.Equals(ItemPropertiesFields.Name))
                {
                    Name.Wait(5).Clear();
                }
                if (excludeField.Equals(ItemPropertiesFields.Publisher))
                {
                    Publisher.Wait(5).Clear();
                }
                if (excludeField.Equals(ItemPropertiesFields.Keywords))
                {
                    Keywords.Wait(5).Clear();
                }
            }
            //input the included fields
            foreach (var includeField in FieldNames)
            {
                //if the field does match, then input it
                if (includeField.Equals(ItemPropertiesFields.Subject))
                {
                    this.SubjectSelect.Wait(3).SelectByText(Data.Subject);
                }
                if (includeField.Equals(ItemPropertiesFields.GradeLevelFrom))
                {
                    this.GradeFromSelect.Wait(5).SelectByText(Data.GradeLow);
                }
                if (includeField.Equals(ItemPropertiesFields.GradeLevelTo))
                {
                    this.GradeToSelect.Wait(5).SelectByText(Data.GradeHigh);
                }
                if (includeField.Equals(ItemPropertiesFields.QuestionLanguage))
                {
                    QuestionLanguage = new SelectElementWrapper(new WebElementWrapper(ByQuestionLanguage));
                    QuestionLanguage.Wait(5).SelectByText(Data.QuestionLanguage);
                }
                if (includeField.Equals(ItemPropertiesFields.Name))
                {
                    Name.Wait(5).SendKeys(Data.Name);
                }
                if (includeField.Equals(ItemPropertiesFields.Publisher))
                {
                    Publisher.Wait(5).SendKeys(Data.Publisher);
                }
                if (includeField.Equals(ItemPropertiesFields.Keywords))
                {
                    Keywords.Wait(5).SendKeys(Data.Keyword);
                }
            }
        }

        public void InputAllFieldsExcept_ShowMore(List<ItemPropertiesFields> excludeFields)
        {
            //do not input the excluded fields
            foreach (var excludeField in excludeFields)
            {
                //if the field does match, then make it blank
                if (excludeField.Equals(ItemPropertiesFields.AdditionalItemIdentifier))
                {
                    AdditionalItemIdentifier.Wait(5).Clear();
                }
                if (excludeField.Equals(ItemPropertiesFields.Author))
                {
                    Author.Wait(5).Clear();
                }
                if (excludeField.Equals(ItemPropertiesFields.AuthoredDifficulty))
                {
                    AuthoredDifficulty.Wait(5).SelectByValue("0");
                }
                if (excludeField.Equals(ItemPropertiesFields.Batch))
                {
                    Batch.Wait(5).Clear();
                }
                if (excludeField.Equals(ItemPropertiesFields.BloomsTaxonomy))
                {
                    BloomsTaxonomy.Wait(5).SelectByValue("0");
                }
                if (excludeField.Equals(ItemPropertiesFields.CognitiveDemandLevel))
                {
                    CognitiveDemandLevel.Wait(5).SelectByValue("0");
                }
                if (excludeField.Equals(ItemPropertiesFields.CourseId))
                {
                    CourseId.Wait(5).Clear();
                }
                if (this.TestConfiguration.ApplicationName.Equals(ApplicationName.schoolnetmultitenant))
                {
                    if (excludeField.Equals(ItemPropertiesFields.CurriculumMT))
                    {
                        CurriculumMT.Wait(5).SelectByValue("0");
                    }
                    if (excludeField.Equals(ItemPropertiesFields.Relativity))
                    {
                        Relativity.Wait(5).SelectByValue("0");
                    }
                }
                if (this.TestConfiguration.ApplicationName.Equals(ApplicationName.schoolnetsingletenant))
                {
                    if (excludeField.Equals(ItemPropertiesFields.CurriculumST))
                    {
                        CurriculumST.Wait(5).SelectByValue("0");
                    }
                    if (excludeField.Equals(ItemPropertiesFields.CourseSpecificItems))
                    {
                        CourseSpecificItems.Wait(5).SelectByValue("0");
                    }
                }
                if (excludeField.Equals(ItemPropertiesFields.ItemCategory))
                {
                    ItemCategory.Wait(5).Clear();
                }
                if (excludeField.Equals(ItemPropertiesFields.Webb))
                {
                    Webb.Wait(5).SelectByValue("0");
                }
                if (excludeField.Equals(ItemPropertiesFields.Year))
                {
                    Year.Wait(5).Clear();
                }
            }
            //input the included fields
            foreach (var includeField in FieldNames)
            {
                //if the field does match, then input it
                if (includeField.Equals(ItemPropertiesFields.AdditionalItemIdentifier))
                {
                    AdditionalItemIdentifier.Wait(5).SendKeys(Data.AdditionalItemIdentifier);
                }
                if (includeField.Equals(ItemPropertiesFields.Author))
                {
                    Author.Wait(5).SendKeys("");
                }
                if (includeField.Equals(ItemPropertiesFields.AuthoredDifficulty))
                {
                    AuthoredDifficulty.Wait(5).SelectByText("Low");
                }
                if (includeField.Equals(ItemPropertiesFields.Batch))
                {
                    Batch.Wait(5).SendKeys(Data.Batch);
                }
                if (includeField.Equals(ItemPropertiesFields.BloomsTaxonomy))
                {
                    BloomsTaxonomy.Wait(5).SelectByText("Understanding");
                }
                if (includeField.Equals(ItemPropertiesFields.CognitiveDemandLevel))
                {
                    CognitiveDemandLevel.Wait(5).SelectByText("Low");
                }
                if (includeField.Equals(ItemPropertiesFields.CourseId))
                {
                    CourseId.Wait(5).SendKeys(Data.CourseId);
                }
                if (this.TestConfiguration.ApplicationName.Equals(ApplicationName.schoolnetmultitenant))
                {
                    if (includeField.Equals(ItemPropertiesFields.CurriculumMT))
                    {
                        CurriculumMT.Wait(5).SelectByText("English 101");
                    }
                    if (includeField.Equals(ItemPropertiesFields.Relativity))
                    {
                        Relativity.Wait(5).SelectByText("");
                    }
                }
                if (this.TestConfiguration.ApplicationName.Equals(ApplicationName.schoolnetsingletenant))
                {
                    if (includeField.Equals(ItemPropertiesFields.CurriculumST))
                    {
                        CurriculumST.Wait(5).SelectByText("English 101");
                    }
                    if (includeField.Equals(ItemPropertiesFields.CourseSpecificItems))
                    {
                        CourseSpecificItems.Wait(5).SelectByText("101");
                    }
                }
                if (includeField.Equals(ItemPropertiesFields.ItemCategory))
                {
                    ItemCategory.Wait(5).Clear();
                }
                if (includeField.Equals(ItemPropertiesFields.Webb))
                {
                    Webb.Wait(5).SelectByText("None Selected");
                }
                if (includeField.Equals(ItemPropertiesFields.Year))
                {
                    Year.Wait(5).SendKeys(Data.Year);
                }
            }
        }

        public override void InputFormFields()
        {
            switch (PageNames)
            {
                case PageNames.CreateNewItem:
                    InputFormFields_CreateNewItemPage();
                    break;
                case PageNames.EditTask:
                    InputFormFields_EditTaskPage();
                    break;
                case PageNames.ItemCentral:
                    InputFormFields_ItemCentralPage();
                    break;
                case PageNames.EditRubric:
                    InputFormFields_EditRubricPage();
                    break;
            }
        }

        public void InputAllFieldsExcept(List<ItemPropertiesFields> excludeFields)
        {
            //remove the excluded fields
            foreach (var excludeField in excludeFields)
            {
                if (FieldNames.Contains(excludeField))
                {
                    Report.Write("Removing: " + excludeField);
                    FieldNames.Remove(excludeField);
                }
            }
            switch (PageNames)
            {
                case PageNames.CreateNewItem:
                    InputAllFieldsExcept_CreateNewItemPage(excludeFields);
                    break;
                case PageNames.ItemCentral:
                    InputAllFieldsExcept_ItemCentralPage(excludeFields);
                    break;
                case PageNames.EditRubric:
                    InputAllFieldsExcept_EditRubricPage(excludeFields);
                    break;
            }
        }

        private ReadOnlyCollection<IWebElement> GetDummyStepsToCompleteLabels()
        {
            ReadOnlyCollection<IWebElement> webElements = null;
            List<IWebElement> list = new List<IWebElement>();
            DummyWebElement dummy1 = new DummyWebElement();
            DummyWebElement dummy2 = new DummyWebElement();
            DummyWebElement dummy3 = new DummyWebElement();
            dummy1.Text = ExpectedRequiredErrorsList[0];
            dummy1.Displayed = true;
            dummy2.Text = ExpectedRequiredErrorsList[1];
            dummy2.Displayed = true;
            dummy3.Text = ExpectedRequiredErrorsList[2];
            dummy3.Displayed = true;

            list = new List<IWebElement> { dummy1, dummy2, dummy3 };
            webElements = new ReadOnlyCollection<IWebElement>(list);
            return webElements;
        }

        public override void VerifyErrorsForRequiredFields()
        {
            List<string> actualRequiredErrorsList = new List<string>();
            //get the error message element list
            ReadOnlyCollection<IWebElement> messageElements = StepsToCompleteLabels.WaitForElements(5);

            if (Driver.GetType() == typeof(DummyDriver))
            {
                messageElements = GetDummyStepsToCompleteLabels();
            }

            //for each element in the list
            foreach (var messageElement in messageElements)
            {
                //if the error message element is displayed
                if (messageElement.Displayed)
                {
                    string actualMessage = messageElement.Text;
                    //get the error message text and add it to the actual error message list
                    actualRequiredErrorsList.Add(actualMessage);
                    Report.Write("Actual required message: " + actualMessage);
                }
            }
            //for each expected error message in the list
            foreach (var expectedMessage in ExpectedRequiredErrorsList)
            {
                //assert that the expected error message is found in the actual error message list
                Assert.IsTrue(actualRequiredErrorsList.Contains(expectedMessage),
                    "The expected required message '" + expectedMessage + "' was not found in the actual required message list.");
            }
        }

        public void VerifyErrorForRequiredField(List<ItemPropertiesFields> requiredFields)
        {
            List<string> actualRequiredErrorsList = new List<string>();
            //get the error message element list
            ReadOnlyCollection<IWebElement> messageElements = StepsToCompleteLabels.WaitForElements(5);

            if (Driver.GetType() == typeof(DummyDriver))
            {
                messageElements = GetDummyStepsToCompleteLabels();
            }

            //for each element in the list
            foreach (var messageElement in messageElements)
            {
                //if the error message element is displayed
                if (messageElement.Displayed)
                {
                    string actualMessage = messageElement.Text;
                    //get the error message text and add it to the actual error message list
                    actualRequiredErrorsList.Add(actualMessage);
                    Report.Write("Actual required message: " + actualMessage);
                }
            }
            foreach (var requiredField in requiredFields)
            {
                if (requiredField.Equals(ItemPropertiesFields.Subject))
                {
                    //get the element's selected option
                    WebElementWrapper element = this.SubjectSelect.Wait(3).SelectedOption;
                    element.Text = "- Choose a subject -";
                    string actual = element.Text.Trim();
                    //assert that the element's default option is selected
                    Assert.AreEqual("- Choose a subject -", actual, "Subject should be default option.");
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(ExpectedRequiredErrorsList[0]),
                        "The expected required message '" + ExpectedRequiredErrorsList[0] + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemPropertiesFields.GradeLevelFrom))
                {
                    //get the element's selected option
                    WebElementWrapper element = this.GradeFromSelect.Wait(3).SelectedOption;
                    element.Text = "";
                    string actual = element.Text.Trim();
                    //assert that the element's value is null
                    Assert.AreEqual("", actual, "GradeLevelFrom should be null.");
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(ExpectedRequiredErrorsList[1]),
                        "The expected required message '" + ExpectedRequiredErrorsList[1] + "' was not found in the actual required message list.");
                }
                if (requiredField.Equals(ItemPropertiesFields.GradeLevelTo))
                {
                    //get the element's selected option
                    WebElementWrapper element = this.GradeToSelect.Wait(3).SelectedOption;
                    element.Text = "";
                    string actual = element.Text.Trim();
                    //assert that the element's value is null
                    Assert.AreEqual("", actual, "GradeLevelTo should be null.");
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(ExpectedRequiredErrorsList[1]),
                        "The expected required message '" + ExpectedRequiredErrorsList[1] + "' was not found in the actual required message list.");
                }
            }
        }

        public override void VerifyFieldsExist()
        {
            this.SubjectSelect.Wrapper.Displayed = true;
            Assert.IsTrue(this.SubjectSelect.Wrapper.Displayed, this.Utilities.GetInvisibleErrorMessage(this.SubjectSelect.Wrapper.By.ToString()));
            this.GradeFromSelect.Wrapper.Displayed = true;
            Assert.IsTrue(this.GradeFromSelect.Wrapper.Displayed, this.Utilities.GetInvisibleErrorMessage(this.GradeFromSelect.Wrapper.By.ToString()));
            this.GradeToSelect.Wrapper.Displayed = true;
            Assert.IsTrue(this.GradeToSelect.Wrapper.Displayed, this.Utilities.GetInvisibleErrorMessage(this.GradeToSelect.Wrapper.By.ToString()));
            QuestionLanguage.Wrapper.Displayed = true;
            Assert.IsTrue(QuestionLanguage.Wrapper.Displayed, this.Utilities.GetInvisibleErrorMessage(QuestionLanguage.Wrapper.By.ToString()));
            ResponseLanguage.Wrapper.Displayed = true;
            Assert.IsTrue(ResponseLanguage.Wrapper.Displayed, this.Utilities.GetInvisibleErrorMessage(ResponseLanguage.Wrapper.By.ToString()));
            this.StandardControlsForm.VerifyFieldsExist();
            Name.Displayed = true;
            Assert.IsTrue(Name.Displayed, this.Utilities.GetInvisibleErrorMessage(Name.By.ToString()));
            Publisher.Displayed = true;
            Assert.IsTrue(Publisher.Displayed, this.Utilities.GetInvisibleErrorMessage(Publisher.By.ToString()));
            Keywords.Displayed = true;
            Assert.IsTrue(Keywords.Displayed, this.Utilities.GetInvisibleErrorMessage(Keywords.By.ToString()));
        }

        public void VerifyFieldSelectedOption(List<ItemPropertiesFields> requiredFields)
        {
            //input the included fields
            foreach (var requiredField in requiredFields)
            {
                //if the field does match, then input it
                if (requiredField.Equals(ItemPropertiesFields.QuestionLanguage))
                {
                    if (Driver.GetType() == typeof(DummyDriver))
                    {
                        DummyWebElement dummy = new DummyWebElement();
                        dummy.Text = Data.QuestionLanguage;
                        QuestionLanguage.FakeSelectedOption = dummy;
                    }
                    string actualText = QuestionLanguage.Wait(5).SelectedOption.Text.Trim();
                    //assert that the expected option is found in the actual option
                    Assert.AreEqual(Data.QuestionLanguage, actualText,
                        "The expected selected option's text '" + Data.QuestionLanguage + "' was not found in the actual selection option's text '" + actualText + "'.");
                }
                if (requiredField.Equals(ItemPropertiesFields.ResponseLanguage))
                {
                    if (Driver.GetType() == typeof(DummyDriver))
                    {
                        DummyWebElement dummy = new DummyWebElement();
                        dummy.Text = Data.ResponseLanguage;
                        ResponseLanguage.FakeSelectedOption = dummy;
                    }
                    string actualText = ResponseLanguage.Wait(5).SelectedOption.Text.Trim();
                    //assert that the expected option is found in the actual option
                    Assert.AreEqual(Data.ResponseLanguage, actualText,
                        "The expected selected option's text '" + Data.ResponseLanguage + "' was not found in the actual selection option's text '" + actualText + "'.");
                }
            }
        }

        public void VerifyFieldsListOfValues(List<ItemPropertiesFields> requiredFields)
        {
            //input the included fields
            foreach (var requiredField in requiredFields)
            {
                //if the field does match, then input it
                if (requiredField.Equals(ItemPropertiesFields.QuestionLanguage))
                {
                    IList<IWebElement> actualOption = QuestionLanguage.Wait(5).Options;
                    if (Driver.GetType() == typeof(DummyDriver))
                    {
                        foreach (var language in Data.QuestionLanguageList)
                        {
                            DummyWebElement dummy = new DummyWebElement();
                            dummy.Text = language;
                            actualOption.Add(dummy);
                        }
                    }

                    bool found = false;
                    foreach (var expectedText in Data.QuestionLanguageList)
                    {
                        found = false;
                        foreach (var actual in actualOption)
                        {
                            if (actual.Text.Contains(expectedText))
                            {
                                found = true;
                                break;
                            }
                        }
                        Assert.IsTrue(found, "The expected option's text '" + expectedText +
                            "' was not found in the QuestionLanguage dropdown.");
                    }
                }
                //if the field does match, then input it
                if (requiredField.Equals(ItemPropertiesFields.ResponseLanguage))
                {
                    IList<IWebElement> actualOption = ResponseLanguage.Wait(5).Options;
                    if (Driver.GetType() == typeof(DummyDriver))
                    {
                        foreach (var language in Data.ResponseLanguageList)
                        {
                            DummyWebElement dummy = new DummyWebElement();
                            dummy.Text = language;
                            actualOption.Add(dummy);
                        }
                    }

                    bool found = false;
                    foreach (var expectedText in Data.ResponseLanguageList)
                    {
                        found = false;
                        foreach (var actual in actualOption)
                        {
                            if (actual.Text.Contains(expectedText))
                            {
                                found = true;
                                break;
                            }
                        }
                        Assert.IsTrue(found, "The expected option's text '" + expectedText +
                            "' was not found in the ResponseLanguage dropdown.");
                    }
                }
            }
        }
    }
}
