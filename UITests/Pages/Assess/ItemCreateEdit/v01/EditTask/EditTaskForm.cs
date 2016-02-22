using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.Standards;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTestItem;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;
using UITests.Pages.Assess.ItemCentral;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.EditTask
{
    public class EditTaskForm : EditTestItemCreateNewItemForm
    {
        public EditTaskForm(ItemTypeForm itemTypeForm, string overrideControlPrefix = null)
            : base(itemTypeForm, overrideControlPrefix, PageNames.EditTask)
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }
        public override void InitElements()
        {
            ItemList = new List<ItemTypeForm>();
            AddActivity = new AddActivity(PageNames.EditTask, this.ControlPrefix);
            PaginationActivities = new PaginationActivities(this.ControlPrefix);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new EditPageData Data
        {
            get
            {
                return (EditPageData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// list of item form types
        /// </summary>
        public List<ItemTypeForm> ItemList { get; set; }

        public override By BySubmit { get { return By.Id(ControlPrefix + "ButtonSubmit"); } }

        /// <summary>
        /// add activity
        /// </summary>
        private AddActivity AddActivity { get; set; }
        /// <summary>
        /// pagination activities
        /// </summary>
        private PaginationActivities PaginationActivities { get; set; }

        /// <summary>
        /// select add activity
        /// </summary>
        public void SelectAddActivity()
        {
            AddActivity.SelectAddActivity();
        }
        /// <summary>
        /// select add activity, then select multiple choice
        /// </summary>
        public EditTaskPage SelectAddActivityMultipleChoice()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityMultipleChoice();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select true/false
        /// </summary>
        public EditTaskPage SelectAddActivityTrueFalse()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityTrueFalse();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select gridded
        /// </summary>
        public EditTaskPage SelectAddActivityGridded()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityGridded();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select open response
        /// </summary>
        public EditTaskPage SelectAddActivityOpenResponse()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityOpenResponse();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select inline response
        /// </summary>
        public EditTaskPage SelectAddActivityInlineResponse()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityInlineResponse();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select matching
        /// </summary>
        public EditTaskPage SelectAddActivityMatching()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityMatching();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select hot spot multiple selection
        /// </summary>
        public EditTaskPage SelectAddActivityHotSpotMultipleSelection()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityHotSpotMultipleSelection();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select hot spot single selection
        /// </summary>
        public EditTaskPage SelectAddActivityHotSpotSingleSelection()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityHotSpotSingleSelection();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select drag and drop
        /// </summary>
        public EditTaskPage SelectAddActivityDragAndDrop()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityDragAndDrop();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select click stick click drop
        /// </summary>
        public EditTaskPage SelectAddActivityClickStickClickDrop()
        {
            EditTaskPage editTask = AddActivity.SelectAddActivityClickStickClickDrop();
            ItemList.Add(editTask.Form.ItemTypeForm);
            return editTask;
        }
        /// <summary>
        /// select add activity, then select import from item central
        /// </summary>
        public ItemCentralHomePage SelectAddActivityImportFromItemCentral()
        {
            return AddActivity.SelectAddActivityImportFromItemCentral();
        }


        public override void InputFormFields()
        {
            ItemPropertiesForm.InputFormFields();
            StandardPopupDialog = ItemPropertiesForm.StandardLookup();
            //StandardPickerForm.InputAndSubmitForm();
            StandardPopupDialog.Data = Data.StandardPickerData;
            StandardPopupDialog.Form.InputAndSubmitForm();
            ItemTypeForm.Data = Data.ItemTypeData;
            ItemTypeForm.QuestionAnswerDataObject = Data.QuestionAnswerData;
            ItemTypeForm.AutoItDataObject = Data.AutoItData;
            ItemTypeForm.InputFormFields();
        }

        public void InputFormFields_ItemProperties()
        {
            ItemPropertiesForm.InputFormFields();
        }

        public void InputFormFields_SelectStandard(string standardName)
        {
            StandardPopupDialog = ItemPropertiesForm.StandardLookup();
            StandardPopupDialog.Data = Data.StandardPickerData;
            StandardPopupDialog.Form.SelectStandardDocument();
            StandardPopupDialog.Form.SelectSubject();
            StandardPopupDialog.Form.SelectGradeLevel();
            StandardPopupDialog.Form.ExpandStandardInGroupById(Data.StandardPickerData.SelectedStandardsGroupData.StandardId);
            StandardPopupDialog.Form.SelectStandardInGroupByName(standardName);
            StandardPopupDialog.Form.SubmitForm();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();
        }

        public void InputFormFields_Item()
        {
            ItemTypeForm.Data = Data.ItemTypeData;
            ItemTypeForm.QuestionAnswerDataObject = Data.QuestionAnswerData;
            ItemTypeForm.AutoItDataObject = Data.AutoItData;
            ItemTypeForm.InputFormFields();
        }
    }
}
