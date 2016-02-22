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
using UITests.Pages;
using UITests.Pages.Components;
using UITests.Pages.Assess;
using UITests.Pages.Assess.Dashboard;
using UITests.Pages.Assess.ItemCentral;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditItemAvailability;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditQuestion;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTask;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTestItem;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;
using UITests.Pages.Assess.ItemCreateEdit.v01.ViewItemStatistics;
using UITests.Pages.Assess.Passage;
using UITests.Pages.Assess.PrintTest;
using UITests.Pages.Assess.Rubric;
using UITests.Pages.Assess.Scantron;
using UITests.Pages.Assess.Schedule;
using UITests.Pages.Assess.Standards;
using UITests.Pages.Assess.TestCentral;
using UITests.Pages.Assess.TestCreateEdit;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestTunnel;
using UITests.Pages.Assess.TestWindow;
using UITests.Pages.Assess.Track;
using UITests.Pages.Home;
using UITests.Workflow;

namespace UITests.Workflow.Assess
{
    /// <summary>
    /// the create item workflows
    /// </summary>
    public class CreateItemWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public CreateItemWorkflows( AssessWorkflows workflows)
            : base()
        {
            AssessWorkflows = workflows;
        }

        //workflows
        public AssessWorkflows AssessWorkflows { get; set; }

        /// <summary>
        /// the item type form
        /// </summary>
        public ItemTypeForm ItemTypeForm { get; set; }

        /// <summary>
        /// EditQuestion page, return new instance of the form type. 
        /// Ie ItemTypeOpenResponseForm, ItemTypeFormMultipleChoice, ItemTypeFormTrueFalse ...
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <param name="itemTypeForm">ItemTypeForm</param>
        private void setItemTypeForm(ItemTypeForm itemTypeForm)
        {
            if (itemTypeForm.GetType() == typeof(ItemTypeMultipleChoiceForm))
            {
                ItemTypeForm = new ItemTypeMultipleChoiceForm();
            }
            else if (itemTypeForm.GetType() == typeof(ItemTypeTrueFalseForm))
            {
                ItemTypeForm = new ItemTypeTrueFalseForm();
            }
            else if (itemTypeForm.GetType() == typeof(ItemTypeGriddedForm))
            {
                ItemTypeForm = new ItemTypeGriddedForm();
            }
            else if (itemTypeForm.GetType() == typeof(ItemTypeOpenResponseForm))
            {
                ItemTypeForm = new ItemTypeOpenResponseForm();
            }
            else if (itemTypeForm.GetType() == typeof(ItemTypeInlineResponseForm))
            {
                ItemTypeForm = new ItemTypeInlineResponseForm();
            }
            else if (itemTypeForm.GetType() == typeof(ItemTypeMatchingForm))
            {
                ItemTypeForm = new ItemTypeMatchingForm();
            }
            else if (itemTypeForm.GetType() == typeof(ItemTypeDragDropForm))
            {
                ItemTypeForm = new ItemTypeDragDropForm();
            }
        }

        /// <summary>
        /// navigate to the create test portal page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows NavigateToCreateTestPortalPage()
        {
            AssessWorkflows.NavigateToAssessDashboardPage();
            AssessWorkflows.CreateTestPortalPage = null;
            if ((AssessWorkflows.Workflows.IsDistrictAdmin)
                || (AssessWorkflows.Workflows.IsLeadership)
                || (AssessWorkflows.Workflows.IsStudent)
                || (AssessWorkflows.Workflows.IsSystemSetup))
            {
                AssessWorkflows.CreateTestPortalPage = AssessWorkflows.ProfileHomePage.CreateATest();
            }
            if (AssessWorkflows.Workflows.IsTeacher)
            {
                AssessWorkflows.CreateTestPortalPage = AssessWorkflows.TeacherProfileHomePage.CreateATest();
            }
            if (AssessWorkflows.CreateTestPortalPage == null)
            {
                throw new Exception("Navigate to the AssessDashboardPage before trying to use this workflow.");
            }
            return this;
        }
        /// <summary>
        /// navigate to the edit test item: choose new item page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows NavigateToEditTestItemChooseNewItemPage()
        {
            AssessWorkflows.NavigateToAssessDashboardPage();
            AssessWorkflows.EditTestItemChooseNewItemPage = null;
            if ((AssessWorkflows.Workflows.IsDistrictAdmin)
                || (AssessWorkflows.Workflows.IsLeadership)
                || (AssessWorkflows.Workflows.IsStudent)
                || (AssessWorkflows.Workflows.IsSystemSetup))
            {
                AssessWorkflows.EditTestItemChooseNewItemPage = AssessWorkflows.ProfileHomePage.CreateAnItem();
            }
            if (AssessWorkflows.Workflows.IsTeacher)
            {
                AssessWorkflows.EditTestItemChooseNewItemPage = AssessWorkflows.TeacherProfileHomePage.CreateAnItem();
            }
            if (AssessWorkflows.EditTestItemChooseNewItemPage == null)
            {
                throw new Exception("Navigate to the AssessDashboardPage before trying to use this workflow.");
            }
            return this;
        }
        /// <summary>
        /// navigate to the edit test item: create new item page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditTestItemCreateNewItemSelectClicStickClickDrop()
        {
            if (AssessWorkflows.EditTestItemChooseNewItemPage == null)
            {
                throw new Exception("The EditTestItemChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditTestItemCreateNewItemPage = AssessWorkflows.EditTestItemChooseNewItemPage.Detail.SelectClickStickClickDropLink();
            return this;
        }
        /// <summary>
        /// navigate to the edit test item: create new item page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditTestItemCreateNewItemSelectDragAndDrop()
        {
            if (AssessWorkflows.EditTestItemChooseNewItemPage == null)
            {
                throw new Exception("The EditTestItemChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditTestItemCreateNewItemPage = AssessWorkflows.EditTestItemChooseNewItemPage.Detail.SelectDragAndDropLink();
            return this;
        }
        /// <summary>
        /// navigate to the edit test item: create new item page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditTestItemCreateNewItemSelectGridded()
        {
            if (AssessWorkflows.EditTestItemChooseNewItemPage == null)
            {
                throw new Exception("The EditTestItemChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditTestItemCreateNewItemPage = AssessWorkflows.EditTestItemChooseNewItemPage.Detail.SelectGriddedLink();
            return this;
        }
        /// <summary>
        /// navigate to the edit test item: create new item page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditTestItemCreateNewItemSelectHotSpotMultipleSelection()
        {
            if (AssessWorkflows.EditTestItemChooseNewItemPage == null)
            {
                throw new Exception("The EditTestItemChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditTestItemCreateNewItemPage = AssessWorkflows.EditTestItemChooseNewItemPage.Detail.SelectHotSpotMultipleSelectionLink();
            return this;
        }
        /// <summary>
        /// navigate to the edit test item: create new item page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditTestItemCreateNewItemSelectHotSpotSingleSelection()
        {
            if (AssessWorkflows.EditTestItemChooseNewItemPage == null)
            {
                throw new Exception("The EditTestItemChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditTestItemCreateNewItemPage = AssessWorkflows.EditTestItemChooseNewItemPage.Detail.SelectHotSpotSingleSelectionLink();
            return this;
        }
        /// <summary>
        /// navigate to the edit test item: create new item page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditTestItemCreateNewItemSelectInlineResponse()
        {
            if (AssessWorkflows.EditTestItemChooseNewItemPage == null)
            {
                throw new Exception("The EditTestItemChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditTestItemCreateNewItemPage = AssessWorkflows.EditTestItemChooseNewItemPage.Detail.SelectInlineResponseLink();
            return this;
        }
        /// <summary>
        /// navigate to the edit test item: create new item page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditTestItemCreateNewItemSelectMatching()
        {
            if (AssessWorkflows.EditTestItemChooseNewItemPage == null)
            {
                throw new Exception("The EditTestItemChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditTestItemCreateNewItemPage = AssessWorkflows.EditTestItemChooseNewItemPage.Detail.SelectMatchingLink();
            return this;
        }
        /// <summary>
        /// navigate to the edit test item: create new item page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditTestItemCreateNewItemSelectMultipleChoice()
        {
            if (AssessWorkflows.EditTestItemChooseNewItemPage == null)
            {
                throw new Exception("The EditTestItemChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditTestItemCreateNewItemPage = AssessWorkflows.EditTestItemChooseNewItemPage.Detail.SelectMultipleChoiceLink();
            return this;
        }
        /// <summary>
        /// navigate to the edit test item: create new item page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditTestItemCreateNewItemSelectOpenResponse()
        {
            if (AssessWorkflows.EditTestItemChooseNewItemPage == null)
            {
                throw new Exception("The EditTestItemChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditTestItemCreateNewItemPage = AssessWorkflows.EditTestItemChooseNewItemPage.Detail.SelectOpenResponseLink();
            return this;
        }
        /// <summary>
        /// navigate to the edit test item: create new item page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditTestItemCreateNewItemSelectTask()
        {
            if (AssessWorkflows.EditTestItemChooseNewItemPage == null)
            {
                throw new Exception("The EditTestItemChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditTestItemCreateNewItemPage = AssessWorkflows.EditTestItemChooseNewItemPage.Detail.SelectTaskLink();
            return this;
        }
        /// <summary>
        /// navigate to the edit test item: create new item page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditTestItemCreateNewItemSelectTrueFalse()
        {
            if (AssessWorkflows.EditTestItemChooseNewItemPage == null)
            {
                throw new Exception("The EditTestItemChooseNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditTestItemCreateNewItemPage = AssessWorkflows.EditTestItemChooseNewItemPage.Detail.SelectTrueFalseLink();
            return this;
        }
        /// <summary>
        /// navigate to the edit test item: create new item page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditTestItemCreateNewItemToEditItemAvailabilityPage()
        {
            if (AssessWorkflows.EditTestItemCreateNewItemPage == null)
            {
                throw new Exception("The EditTestItemCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditTestItemCreateNewItemPage.Form.InputAndSubmitForm();
            AssessWorkflows.EditItemAvailabilityPage = new EditItemAvailabilityPage();
            return this;
        }

        /// <summary>
        /// edit test item page input form fields
        /// </summary>
        /// <remarks>requires the EditTestItemCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditTestItemCreateNewItemPageInputFormFields()
        {
            if (AssessWorkflows.EditTestItemCreateNewItemPage == null)
            {
                throw new Exception("The EditTestItemCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditTestItemCreateNewItemPage.Form.InputFormFields();
            return this;
        }
        /// <summary>
        /// submit edit test item page
        /// </summary>
        /// <remarks>requires the EditTestItemCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditTestItemCreateNewItemPageSubmitForm()
        {
            if (AssessWorkflows.EditTestItemCreateNewItemPage == null)
            {
                throw new Exception("The EditTestItemCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditTestItemCreateNewItemPage.Form.SubmitForm();
            return this;
        }
        /// <summary>
        /// edit test item page input form fields and submit
        /// </summary>
        /// <remarks>requires the EditTestItemCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditTestItemCreateNewItemPageInputAndSubmitForm()
        {
            if (AssessWorkflows.EditTestItemCreateNewItemPage == null)
            {
                throw new Exception("The EditTestItemCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditTestItemCreateNewItemPage.Form.InputAndSubmitForm();
            AssessWorkflows.EditItemAvailabilityPage = new EditItemAvailabilityPage();
            return this;
        }


        /// <summary>
        /// edit item availability page is viewable only to me
        /// </summary>
        /// <remarks>requires the EditItemAvailabilityPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditItemAvailabilitySeenOnlyByMe()
        {
            if (AssessWorkflows.EditItemAvailabilityPage == null)
            {
                throw new Exception("The EditItemAvailabilityPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditItemAvailabilityPage.Form.SharingItem;

            AssessWorkflows.ShareWithOtherUser.SelectOnlyToMe();
            AssessWorkflows.EditItemAvailabilityPage = new EditItemAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditItemAvailabilityPage.Form.SharingItem;
            return this;
        }
        /// <summary>
        /// edit item availability page is shared with everyone
        /// </summary>
        /// <remarks>requires the EditItemAvailabilityPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditItemAvailabilityShareWithEveryone()
        {
            if (AssessWorkflows.EditItemAvailabilityPage == null)
            {
                throw new Exception("The EditItemAvailabilityPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditItemAvailabilityPage.Form.SharingItem;

            AssessWorkflows.ShareWithOtherUser.SelectShareWithOthers();
            AssessWorkflows.EditItemAvailabilityPage = new EditItemAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditItemAvailabilityPage.Form.SharingItem;

            AssessWorkflows.ShareWithOtherUser.SelectEveryone();
            AssessWorkflows.EditItemAvailabilityPage = new EditItemAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditItemAvailabilityPage.Form.SharingItem;
            return this;
        }
        /// <summary>
        /// edit item availability page is shared with district item admins only
        /// </summary>
        /// <remarks>requires the EditItemAvailabilityPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditItemAvailabilityShareWithDistrictItemAdminsOnly()
        {
            if (AssessWorkflows.EditItemAvailabilityPage == null)
            {
                throw new Exception("The EditItemAvailabilityPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditItemAvailabilityPage.Form.SharingItem;

            AssessWorkflows.ShareWithOtherUser.SelectShareWithOthers();
            AssessWorkflows.EditItemAvailabilityPage = new EditItemAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditItemAvailabilityPage.Form.SharingItem;

            AssessWorkflows.ShareWithOtherUser.SelectDistrictItemAdminsOnly();
            AssessWorkflows.EditItemAvailabilityPage = new EditItemAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditItemAvailabilityPage.Form.SharingItem;
            return this;
        }
        /// <summary>
        /// edit item availability page is shared with district and regional item admins
        /// </summary>
        /// <remarks>requires the EditItemAvailabilityPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditItemAvailabilityShareWithDistrictRegionalItemAdmins()
        {
            if (AssessWorkflows.EditItemAvailabilityPage == null)
            {
                throw new Exception("The EditItemAvailabilityPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditItemAvailabilityPage.Form.SharingItem;

            AssessWorkflows.ShareWithOtherUser.SelectShareWithOthers();
            AssessWorkflows.EditItemAvailabilityPage = new EditItemAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditItemAvailabilityPage.Form.SharingItem;

            AssessWorkflows.ShareWithOtherUser.SelectDistrictAndRegionalItemAdmins();
            AssessWorkflows.EditItemAvailabilityPage = new EditItemAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditItemAvailabilityPage.Form.SharingItem;
            return this;
        }
        /// <summary>
        /// edit item availability page is shared with district regional and school item admins
        /// </summary>
        /// <remarks>requires the EditItemAvailabilityPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditItemAvailabilityShareWithDistrictRegionalSchoolItemAdmins()
        {
            if (AssessWorkflows.EditItemAvailabilityPage == null)
            {
                throw new Exception("The EditItemAvailabilityPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditItemAvailabilityPage.Form.SharingItem;

            AssessWorkflows.ShareWithOtherUser.SelectShareWithOthers();
            AssessWorkflows.EditItemAvailabilityPage = new EditItemAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditItemAvailabilityPage.Form.SharingItem;

            AssessWorkflows.ShareWithOtherUser.SelectDistrictRegionalAndSchoolItemAdmins();
            AssessWorkflows.EditItemAvailabilityPage = new EditItemAvailabilityPage();
            AssessWorkflows.ShareWithOtherUser = AssessWorkflows.EditItemAvailabilityPage.Form.SharingItem;
            return this;
        }

        /// <summary>
        /// edit item availability page input form fields
        /// </summary>
        /// <remarks>requires the EditItemAvailabilityPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditItemAvailabilityPageInputFormFields()
        {
            if (AssessWorkflows.EditItemAvailabilityPage == null)
            {
                throw new Exception("The EditItemAvailabilityPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditItemAvailabilityPage.Form.InputFormFields();
            return this;
        }
        /// <summary>
        /// submit edit item availability page
        /// </summary>
        /// <remarks>requires the EditItemAvailabilityPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditItemAvailabilityPageSubmitForm()
        {
            if (AssessWorkflows.EditItemAvailabilityPage == null)
            {
                throw new Exception("The EditItemAvailabilityPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditItemAvailabilityPage.Form.SubmitForm();
            return this;
        }

        /// <summary>
        /// edit question page input form fields
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageInputFormFields()
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage.Form.InputFormFields();
            return this;
        }
        /// <summary>
        /// edit question page input form fields for answer key only
        /// When answer key only is chosen during creation of a manual test, the item page
        /// does not have ability to add question content. User can only choose the correct
        /// answer. 
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageInputFormFields_AnswerKeyOnly(string index = "")
        {
            Report.Write("\n\n AnswerKey index is " + index); //For debugging 
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage.Form.InputFormFields_AnswerKeyOnly();
            return this;
        }
        /// <summary>
        /// edit question page input item properties fields only
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageInputFormFields_ItemProperties()
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage.Form.InputFormFields_ItemProperties();
            return this;
        }
        /// <summary>
        /// edit question page select standard using edit link. This link is above the 
        /// standard lookup button
        /// <param name="standardDoc">example...Ohio English Language Arts 2003</param>
        /// <param name="standardName">example...LA.1.R.1: Reading / Phonemic Awareness, Word Recognition and Fluency</param>         
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageInputFormFields_SelectStandardUsingEditLink(string standardDoc, string standardName)
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            EditQuestionCreateNewItemForm form = AssessWorkflows.EditQuestionCreateNewItemPage.Form;
            form.ItemPropertiesForm.SelectEditStandard();
            StandardControlsForm standardControls = new StandardControlsForm(PageNames.EditTestItem);
            standardControls.SelectStandard(standardDoc, standardName);
            return this;
        }
        /// <summary>
        /// edit question page select standard
        /// - expand the parent standard group, look up from Data. 
        /// - select the standard based on the standardName. For example:
        /// LA.9.R.2: Reading / Acquisition of Vocabulary
        ///     LA.9.R.2.A: Use context clues and text structures to determine the meaning of new vocabulary.
        ///         LA.9.R.2.A.1: Contextual Understanding cause and effect
        ///     LA.9.R.2.B: Examine the relationships of analogical statements to infer word meanings.
        /// LA.9.R.3: Reading / Reading Process: Self-Monitoring Strategies
        /// 
        /// if standardName equal "LA.9.R.2.A", then "LA.9.R.2.A: Use context clues ..." is selected
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageInputFormFields_SelectStandard(string standardName)
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            EditQuestionCreateNewItemForm form = AssessWorkflows.EditQuestionCreateNewItemPage.Form;
            form.StandardPopupDialog = form.ItemPropertiesForm.StandardLookup();
            StandardPickerData data = ((EditPageData)AssessWorkflows.EditQuestionCreateNewItemPage.Data).StandardPickerData;
            form.StandardPopupDialog.Data = data;
            form.StandardPopupDialog.Form.ExpandStandardInGroupById(data.SelectedStandardsGroupData.StandardId);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                form.StandardPopupDialog.Form.FakeText = standardName;
            }
            form.StandardPopupDialog.Form.SelectStandardInGroupByName(standardName);
            form.StandardPopupDialog.Form.SubmitForm();
            form.Parent.WaitForPageToLoad();
            form.InitElements();
            return this;
        }
        /// <summary>
        /// edit question page input item fields only
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageInputFormFields_Item()
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage.Form.InputFormFields_ItemForm();
            return this;
        }
        /// <summary>
        /// submit edit question page
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageSubmitForm()
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionCreateNewItemPage.Form.SubmitForm();
            return this;
        }
        /// <summary>
        /// edit question page input form fields and submit
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageInputAndSubmitForm()
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ViewTestDetailsPage = (ViewTestDetailsPage)AssessWorkflows.EditQuestionCreateNewItemPage.Form.InputAndSubmitForm();
            return this;
        }

        /// <summary>
        /// EditQuestion page - add passage by searching for existing passage
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageSearchPassageAndAddPassage()
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }

            AssessWorkflows.EditQuestionCreateNewItemPage.Form.SearchForPassage();
            AssessWorkflows.EditQuestionCreateNewItemPage.Form.EnterPassageTitle();

            return this;
        }
        /// <summary>
        /// EditQuestion page - create new item, click on ribbon to proceed with next create item
        /// Index begin with 1, 2, 3 ...
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageSelectRibbon(int index)
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }

            AssessWorkflows.EditQuestionCreateNewItemPage.Detail.SelectItemByIndex(index);
            //post back, need to reinitialize page
            if (AssessWorkflows.CreateManualTestWorkflows.AllMultipleChoiceSelected)
            {
                //When all MC is checked during manual test creation, user no longer had to choose item. 
                //User is brought to MC item page.
                EditPageData previousData = (EditPageData)AssessWorkflows.EditQuestionCreateNewItemPage.Data;
                AssessWorkflows.EditQuestionCreateNewItemPage = new EditQuestionCreateNewItemPage( ItemType.MultipleChoice);
                AssessWorkflows.EditQuestionCreateNewItemPage.Data = previousData;
            }
            else
            {
                AssessWorkflows.EditQuestionChooseNewItemPage = new EditQuestionChooseNewItemPage();
            }

            return this;
        }
        /// <summary>
        /// EditQuestion page - create new item, click on add item to proceed with next create item
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageSelectAddItem()
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }

            AssessWorkflows.EditQuestionCreateNewItemPage.Detail.AddItem();
            //post back, need to reinitialize page
            if (AssessWorkflows.CreateManualTestWorkflows.AllMultipleChoiceSelected)
            {
                //When all MC is checked during manual test creation, user no longer had to choose item. 
                //User is brought to MC item page.
                EditPageData previousData = (EditPageData)AssessWorkflows.EditQuestionCreateNewItemPage.Data;
                AssessWorkflows.EditQuestionCreateNewItemPage = new EditQuestionCreateNewItemPage( ItemType.MultipleChoice);
                AssessWorkflows.EditQuestionCreateNewItemPage.Data = previousData;
            }
            else
            {
                //EditQuestionChooseNewItemPage = new EditQuestionChooseNewItemPage(Driver);
                AssessWorkflows.EditQuestionChooseNewItemPage = new EditQuestionChooseNewItemPage();
            }

            return this;
        }
        /// <summary>
        /// EditQuestion page - create new item, attaching rubric
        /// Attaching rubric applied to Open Response question only
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageAttachRubric(string rubricKeyword)
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }

            ItemTypeOpenResponseForm ORForm1 = ((ItemTypeOpenResponseForm)AssessWorkflows.EditQuestionCreateNewItemPage.Form.ItemTypeForm);
            ItemTypeData formData = (ItemTypeData)ORForm1.Data;
            //the user click on rubric button
            ORForm1.SelectRubric();
            AttachRubricDialog beforePostbackDialog = ORForm1.AttachRubricDialog;
            //post back, need to reinitialize page
            setItemTypeForm(AssessWorkflows.EditQuestionCreateNewItemPage.Form.ItemTypeForm);
            AssessWorkflows.EditQuestionCreateNewItemPage = new EditQuestionCreateNewItemPage( ItemTypeForm);
            ORForm1 = ((ItemTypeOpenResponseForm)AssessWorkflows.EditQuestionCreateNewItemPage.Form.ItemTypeForm);
            formData.RubricSearchData = new AttachRubricDialogData() { FilterKeyword = rubricKeyword };
            ORForm1.Data = formData;
            ORForm1.AttachRubricDialog = beforePostbackDialog;
            //the user search for the rubric using keyword and attach it.
            //((ItemTypeData)ORForm1.Data).RubricSearchData = new AttachRubricDialogData() { FilterKeyword = rubricKeyword };
            ORForm1.SearchAndAttachRubric();
            //post back, need to reinitialize page
            Thread.Sleep(1000); //wait 1 sec. If post back is slow, the page instance is create, get stale element exception as it read old page
            setItemTypeForm(AssessWorkflows.EditQuestionCreateNewItemPage.Form.ItemTypeForm);
            AssessWorkflows.EditQuestionCreateNewItemPage = new EditQuestionCreateNewItemPage( ItemTypeForm);
            ORForm1 = ((ItemTypeOpenResponseForm)AssessWorkflows.EditQuestionCreateNewItemPage.Form.ItemTypeForm);
            //verified rubric is attached by checking rubric weight table
            ORForm1.VerifyFieldsExist(new List<ItemTypeOpenResponseFields>() { ItemTypeOpenResponseFields.RubricWeightTable });

            return this;
        }

        /// <summary>
        /// EditQuestion page - multiple choice form add answer choice
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageMultipleChoiceFormAddAnswerChoice()
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            ItemTypeMultipleChoiceForm form = ((ItemTypeMultipleChoiceForm)AssessWorkflows.EditQuestionCreateNewItemPage.Form.ItemTypeForm);
            form.AddAnswerChoice();
            return this;
        }
        /// <summary>
        /// EditQuestion page - matching form add answer choice
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageMatchingFormAddAnswerChoice()
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            ItemTypeMatchingForm form = ((ItemTypeMatchingForm)AssessWorkflows.EditQuestionCreateNewItemPage.Form.ItemTypeForm);
            form.AddAnswerChoice();
            return this;
        }
        /// <summary>
        /// EditQuestion page - multiple choice form select one column
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageMultipleChoiceFormSelectOneColumn()
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            ItemTypeMultipleChoiceForm form = ((ItemTypeMultipleChoiceForm)AssessWorkflows.EditQuestionCreateNewItemPage.Form.ItemTypeForm);
            form.SelectOneColumn();
            return this;
        }
        /// <summary>
        /// EditQuestion page - multiple choice form select two columns across
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageMultipleChoiceFormSelectTwoColumnsAcross()
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            ItemTypeMultipleChoiceForm form = ((ItemTypeMultipleChoiceForm)AssessWorkflows.EditQuestionCreateNewItemPage.Form.ItemTypeForm);
            form.SelectTwoColumnsAcross();
            return this;
        }
        /// <summary>
        /// EditQuestion page - multiple choice form select two columns down
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageMultipleChoiceFormSelectTwoColumnsDown()
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            ItemTypeMultipleChoiceForm form = ((ItemTypeMultipleChoiceForm)AssessWorkflows.EditQuestionCreateNewItemPage.Form.ItemTypeForm);
            form.SelectTwoColumnsDown();
            return this;
        }
        /// <summary>
        /// EditQuestion page - open response form check enable text formatting
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageOpenResponseFormCheckEnableTextFormatting()
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            ItemTypeOpenResponseForm form = ((ItemTypeOpenResponseForm)AssessWorkflows.EditQuestionCreateNewItemPage.Form.ItemTypeForm);
            form.CheckEnableTextFormatting();
            return this;
        }
        /// <summary>
        /// EditQuestion page - open response form check enable special character palette
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageOpenResponseFormCheckEnableSpecialCharacterPalette()
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            ItemTypeOpenResponseForm form = ((ItemTypeOpenResponseForm)AssessWorkflows.EditQuestionCreateNewItemPage.Form.ItemTypeForm);
            form.CheckEnableSpecialCharacterPalette();
            return this;
        }
        /// <summary>
        /// EditQuestion page - open response form check enable equation editor
        /// </summary>
        /// <remarks>requires the EditQuestionCreateNewItemPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateItemWorkflows EditQuestionCreateNewItemPageOpenResponseFormCheckEnableEquationEditor()
        {
            if (AssessWorkflows.EditQuestionCreateNewItemPage == null)
            {
                throw new Exception("The EditQuestionCreateNewItemPage is null, please initialize it before trying to use it in a workflow.");
            }
            ItemTypeOpenResponseForm form = ((ItemTypeOpenResponseForm)AssessWorkflows.EditQuestionCreateNewItemPage.Form.ItemTypeForm);
            form.CheckEnableEquationEditor();
            return this;
        }
    }
}
