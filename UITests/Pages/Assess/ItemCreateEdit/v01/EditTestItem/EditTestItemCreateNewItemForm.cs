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
using UITests.Pages.Assess.Standards;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.EditTestItem
{
    /// <summary>
    /// the create new item form
    /// </summary>
    public class EditTestItemCreateNewItemForm : SNForm
    {
        /// <summary>
        /// the create new item form constructor
        /// </summary>
        /// <param name="itemTypeForm">item type form</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        /// <param name="pageNames">the page name (optional)</param>
        public EditTestItemCreateNewItemForm(ItemTypeForm itemTypeForm, string overrideControlPrefix = null, PageNames pageNames = PageNames.CreateNewItem)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            ItemTypeForm = itemTypeForm;
            ItemType = itemTypeForm.ItemType;
            PageNames = pageNames;
            InitElements();
        }
        /// <summary>
        /// the create new item form constructor
        /// </summary>
        /// <param name="itemType">item type</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        /// <param name="pageNames">the page name (optional)</param>
        public EditTestItemCreateNewItemForm(ItemType itemType, string overrideControlPrefix = null, PageNames pageNames = PageNames.CreateNewItem)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            ItemType = itemType;
            ItemTypeForm = null;
            PageNames = pageNames;
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            switch (ItemType)
            {
                case ItemType.ClickStickClickDrop:
                    ItemTypeForm = new ItemTypeDragDropForm();
                    break;
                case ItemType.DragAndDrop:
                    ItemTypeForm = new ItemTypeDragDropForm();
                    break;
                case ItemType.Gridded:
                    ItemTypeForm = new ItemTypeGriddedForm();
                    break;
                case ItemType.HotSpotMultipleSelection:
                    //TODO not implemented
                    break;
                case ItemType.HotSpotSingleSelection:
                    //TODO not implemented
                    break;
                case ItemType.InlineResponse:
                    ItemTypeForm = new ItemTypeInlineResponseForm();
                    break;
                case ItemType.Matching:
                    ItemTypeForm = new ItemTypeMatchingForm();
                    break;
                case ItemType.MultipleChoice:
                    ItemTypeForm = new ItemTypeMultipleChoiceForm();
                    break;
                case ItemType.OpenResponse:
                    ItemTypeForm = new ItemTypeOpenResponseForm();
                    break;
                case ItemType.Task:
                    ItemTypeForm = new ItemTypeTaskForm();
                    break;
                case ItemType.TrueFalse:
                    ItemTypeForm = new ItemTypeTrueFalseForm();
                    break;
            }
            /* DO NOT DELETE THIS SECTION - MARTIN
            if (ItemTypeForm.GetType() == typeof(ItemTypeFormMultipleChoice))
            {
                ItemTypeForm = new ItemTypeFormMultipleChoice();
            }
            else if (ItemTypeForm.GetType() == typeof(ItemTypeFormTrueFalse))
            {
                ItemTypeForm = new ItemTypeFormTrueFalse();
            }
            else if (ItemTypeForm.GetType() == typeof(ItemTypeGriddedForm))
            {
                ItemTypeForm = new ItemTypeGriddedForm();
            }
            else if (ItemTypeForm.GetType() == typeof(ItemTypeOpenResponseForm))
            {
                ItemTypeForm = new ItemTypeOpenResponseForm();
            }
            else if (ItemTypeForm.GetType() == typeof(ItemTypeFormInlineResponse))
            {
                ItemTypeForm = new ItemTypeFormInlineResponse();
            }
            else if (ItemTypeForm.GetType() == typeof(ItemTypeFormMatching))
            {
                ItemTypeForm = new ItemTypeFormMatching();
            }
            else if (ItemTypeForm.GetType() == typeof(ItemTypeDragDropForm))
            {
                ItemTypeForm = new ItemTypeDragDropForm();
            }
            */

            ItemPropertiesForm = new ItemPropertiesForm(PageNames, ControlPrefix);
            //StandardPickerForm = new StandardPickerForm(PageNames, ControlPrefix);
            ChangeType_link = new WebElementWrapper(ByChangeType_link); // added by Oleg Feb 20, 2014
            ChangeItemType_dropdown = new SelectElementWrapper(new WebElementWrapper(ByChangeItemType_dropdown)); // added by Oleg Feb 20, 2014
            AddLink = new WebElementWrapper(ByAddLink);
            NewPassageLink = new WebElementWrapper(ByNewPassageLink);
            SearchForPassageLink = new WebElementWrapper(BySearchForPassageLink);
            EnterPassageTitleText = new WebElementWrapper(ByEnterPassageTitleText);
            DeletePassageButton = new WebElementWrapper(ByDeletePassageButton);
            EditPassageButton = new WebElementWrapper(ByEditPassageButton);
            PassageTitleLink = new WebElementWrapper(ByPassageTitleLink);
            CancelPassageTitleLink = new WebElementWrapper(ByCancelPassageTitleLink);
            SaveAndPreviewLink = new WebElementWrapper(BySaveAndPreviewLink);
            WithManipulativesLink = new WebElementWrapper(ByWithManipulativesLink);
            WithoutManipulativesLink = new WebElementWrapper(ByWithoutManipulativesLink);
            StepsToCompleteLabels = new WebElementWrapper(ByStepsToCompleteLabels);
            StepsCompletedLabel = new WebElementWrapper(ByStepsCompletedLabel);
            DeleteItemButton = new WebElementWrapper(ByDeleteItemButton);
        }

        /// <summary>
        /// the data object
        /// </summary>
        public EditPageData Data
        {
            get
            {
                return (EditPageData)base.Data;
            }
            set
            {
                Report.Write("Martin... in EditTestItemCreateNewItemForm.Data...");
                base.Data = value;
                EditPageData data = (EditPageData)value;
                ItemPropertiesForm.Data = data.ItemTypeData;
                ItemPropertiesForm.AutoItDataObject = data.AutoItData;
                //StandardPickerForm.DataObject = data.StandardPickerData;
                if (StandardPopupDialog != null)
                {
                    StandardPopupDialog.Data = data.StandardPickerData;
                }
                ItemTypeForm.Data = data.ItemTypeData;
                ItemTypeForm.QuestionAnswerDataObject = data.QuestionAnswerData;
                ItemTypeForm.AutoItDataObject = data.AutoItData;
            }
        }

        private PageNames PageNames { get; set; }
        /// <summary>
        /// the submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ButtonSubmit"); } }
        /// <summary>
        /// the cancel by
        /// </summary>
        public override By ByCancel { get { return By.Id(ControlPrefix + "ButtonCancel"); } }
        protected By ByDeleteItemButton { get { return By.Id(ControlPrefix + "ButtonDelete"); } }
        protected WebElementWrapper DeleteItemButton { get; private set; }
        /// <summary>
        /// the item properties form
        /// </summary>
        public ItemPropertiesForm ItemPropertiesForm { get; private set; }
        /*
        /// <summary>
        /// the standard picker form
        /// </summary>
        public StandardPickerForm StandardPickerForm { get; private set; }
        */
        /// <summary>
        /// the standard popup dialog (page)
        /// </summary>
        public StandardPopupDialog StandardPopupDialog { get; set; }
        /// <summary>
        /// the item type form
        /// </summary>
        public ItemTypeForm ItemTypeForm { get; set; }
        /// <summary>
        /// the item type
        /// </summary>
        private ItemType ItemType { get; set; }
        protected By ByChangeType_link { get { return By.Id("anchorEditQuestionTypeInControl"); } } // added by Oleg Feb 20, 2014
        protected WebElementWrapper ChangeType_link { get; private set; }
        protected By ByChangeItemType_dropdown { get { return By.Id(ControlPrefix + "EditTestItemControl_DropDownListQuestionType"); } } // added by Oleg Feb 20, 2014
        protected SelectElementWrapper ChangeItemType_dropdown { get; private set; }
        protected By ByAddLink { get { return By.CssSelector("#PassageBox .btn.dropdown-toggle"); } }
        protected WebElementWrapper AddLink { get; private set; }
        protected By ByNewPassageLink { get { return By.CssSelector("a[href^='javascript:choosePassage(0)']"); } }
        protected WebElementWrapper NewPassageLink { get; private set; }
        protected By BySearchForPassageLink { get { return By.CssSelector(".search-passage-listItem"); } }
        protected WebElementWrapper SearchForPassageLink { get; private set; }
        protected By ByEnterPassageTitleText { get { return By.Id(ControlPrefix + "EditTestItemControl_AutoCompletePassage"); } }
        protected WebElementWrapper EnterPassageTitleText { get; private set; }
        //("div.ac_results > ul > li > span.ac_resultFull[title='martin passage']");
        protected By ByEnterPassageTitleAutoCompleteLabel { get { return By.CssSelector("div.ac_results > ul > li > span.ac_resultFull[title='" + Data.PassageTitle + "']"); } }
        protected WebElementWrapper EnterPassageTitleAutoCompleteLabel { get; private set; }
        protected By ByDeletePassageButton { get { return By.Id(ControlPrefix + "EditTestItemControl_ctlItemPassage_gridPassages_ctl02_ButtonDeletePassage"); } }
        protected WebElementWrapper DeletePassageButton { get; private set; }
        protected By ByEditPassageButton { get { return By.Id(ControlPrefix + "EditTestItemControl_ctlItemPassage_gridPassages_ctl02_ButtonEditPassage"); } }
        protected WebElementWrapper EditPassageButton { get; private set; }
        protected By ByPassageTitleLink { get { return By.Id(ControlPrefix + "EditTestItemControl_ctlItemPassage_gridPassages_ctl02_LinkButtonPassageTitle"); } }
        protected WebElementWrapper PassageTitleLink { get; private set; }
        protected By ByCancelPassageTitleLink { get { return By.Id(ControlPrefix + "EditTestItemControl_btnSearchCancel"); } }
        protected WebElementWrapper CancelPassageTitleLink { get; private set; }
        protected By BySaveAndPreviewLink { get { return By.CssSelector(".form-actions .btn-group .btn.dropdown-toggle"); } }
        protected WebElementWrapper SaveAndPreviewLink { get; private set; }
        protected By ByWithManipulativesLink { get { return By.CssSelector(".form-actions .btn-group .dropdown-menu li:nth-of-type(1) > a"); } }
        protected WebElementWrapper WithManipulativesLink { get; private set; }
        protected By ByWithoutManipulativesLink { get { return By.CssSelector(".form-actions .btn-group .dropdown-menu li:nth-of-type(2) > a"); } }
        protected WebElementWrapper WithoutManipulativesLink { get; private set; }
        protected By ByStepsToCompleteLabels { get { return By.CssSelector(".well .divTable .divTableCell > span"); } }
        protected WebElementWrapper StepsToCompleteLabels { get; private set; }
        protected By ByStepsCompletedLabel { get { return By.Id("ctl00_MainContent_Panel2"); } }
        protected WebElementWrapper StepsCompletedLabel { get; private set; }

        /// <summary>
        /// select add, then select new passage
        /// </summary>
        public void AddNewPassage()
        {
            AddLink.Wait(3).Click();
            NewPassageLink.Wait(3).Click();
        }
        /// <summary>
        /// select add, then select search for passage
        /// </summary>
        public void SearchForPassage()
        {
            AddLink.Wait(3).Click();
            SearchForPassageLink.Wait(3).Click();
        }
        /// <summary>
        /// enter the passage title and select it
        /// </summary>
        public void EnterPassageTitle()
        {
            EnterPassageTitleText.Wait(3).SendKeys(Data.PassageTitle);
            EnterPassageTitleAutoCompleteLabel = new WebElementWrapper(ByEnterPassageTitleAutoCompleteLabel);
            EnterPassageTitleAutoCompleteLabel.WaitUntilVisible(10).Click();
        }
        /// <summary>
        /// delete the passage
        /// </summary>
        public void DeletePassage()
        {
            DeletePassageButton.Wait(10).Click();
        }
        /// <summary>
        /// edit the passage
        /// </summary>
        public void EditPassage()
        {
            EditPassageButton.Wait(10).Click();
        }
        /// <summary>
        /// select the passage title link
        /// </summary>
        public void SelectPassageTitle()
        {
            PassageTitleLink.Wait(10).Click();
        }
        /// <summary>
        /// select save and preview, then select with manipulatives
        /// </summary>
        public void SaveAndPreviewWithManipulatives()
        {
            SaveAndPreviewLink.Wait(3).Click();
            WithManipulativesLink.Wait(3).Click();
        }
        /// <summary>
        /// select save and preview, then select without manipulatives
        /// </summary>
        public void SaveAndPreviewWithoutManipulatives()
        {
            SaveAndPreviewLink.Wait(3).Click();
            WithoutManipulativesLink.Wait(3).Click();
        }
        /// <summary>
        /// Change the item type
        /// </summary>
        /// <param name="itemType">the item type</param>
        public void ChangeItemType(ItemType itemType) // added by Oleg Feb 20, 2014
        {
            string option = null;
            switch (itemType)
            {
                case ItemType.DragAndDrop:
                    option = "Drag and Drop";
                    break;
                case ItemType.ClickStickClickDrop:
                    option = "Click Stick Click Drop";
                    break;
                case ItemType.Gridded:
                    option = "Gridded";
                    break;
                case ItemType.HotSpotMultipleSelection:
                    option = "Hot Spot - Multiple Selection";
                    break;
                case ItemType.HotSpotSingleSelection:
                    option = "Hot Spot - Single Selection";
                    break;
                case ItemType.InlineResponse:
                    option = "Inline Response";
                    break;
                case ItemType.Matching:
                    option = "Matching";
                    break;
                case ItemType.MultipleChoice:
                    option = "Multiple Choice";
                    break;
                case ItemType.OpenResponse:
                    option = "Open Response";
                    break;
                case ItemType.Task:
                    option = "Task";
                    break;
                case ItemType.TrueFalse:
                    option = "True/False";
                    break;
                default:
                    option = "Select Item Type";
                    break;
            }
            if (option != null)
            {
                this.Parent.CurrentWindowHandle = Driver.CurrentWindowHandle;
                Report.Write("The current window is: '" + this.Parent.CurrentWindowHandle + "'.");

                ChangeType_link.Click();
                ChangeItemType_dropdown.Wait(3).SelectByText(option);

                //TODO: this is inconsistent behavior, and I pointed the issue out to Boris
                //  so Boris talked to Product Owners, but won't it be fixed anytime soon
                //  there could be test failures as a side affect
                //if item type is not multiple choice, then handle the pop-up
                if (ItemTypeForm.GetType() != typeof(ItemTypeMultipleChoiceForm))
                {
                    IAlert alert = Driver.SwitchTo().Alert();
                    string expected1 = "Some content cannot be carried over.";
                    if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                    {
                        ((DummyIAlert)alert).Text = expected1;
                    }
                    string actual = alert.Text;
                    Report.Write("The alert text: '" + actual + "'.");
                    Assert.IsTrue(actual.Contains(expected1), "The delete confirmation pop-up does not contain the expected text: '" + expected1 + "'; actual text: '" + actual + "'.");
                    alert.Accept();

                    //switch to window
                    DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 5);
                }

                this.DriverCommands.WaitForPageToLoad(60);
            }
            switch (itemType)
            {
                case ItemType.DragAndDrop:
                    ItemTypeForm = new ItemTypeDragDropForm();
                    break;
                case ItemType.ClickStickClickDrop:
                    ItemTypeForm = new ItemTypeDragDropForm();
                    break;
                case ItemType.Gridded:
                    ItemTypeForm = new ItemTypeGriddedForm();
                    break;
                case ItemType.HotSpotMultipleSelection:
                    //TODO: add later
                    //ItemTypeForm = null;
                    break;
                case ItemType.HotSpotSingleSelection:
                    //TODO: add later
                    //ItemTypeForm = null;
                    break;
                case ItemType.InlineResponse:
                    ItemTypeForm = new ItemTypeInlineResponseForm();
                    break;
                case ItemType.Matching:
                    ItemTypeForm = new ItemTypeMatchingForm();
                    break;
                case ItemType.MultipleChoice:
                    ItemTypeForm = new ItemTypeMultipleChoiceForm();
                    break;
                case ItemType.OpenResponse:
                    ItemTypeForm = new ItemTypeOpenResponseForm();
                    break;
                case ItemType.Task:
                    ItemTypeForm = new ItemTypeTaskForm();
                    break;
                case ItemType.TrueFalse:
                    ItemTypeForm = new ItemTypeTrueFalseForm();
                    break;
            }
            //may need to call initElements() if there are problems
            ItemTypeForm.Data = Data.ItemTypeData;
        }

        /// <summary>
        /// Delete the item and Accept the Alert.
        /// </summary>
        public void DeleteItem()
        {
            this.Parent.CurrentWindowHandle = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + this.Parent.CurrentWindowHandle + "'.");

            DeleteItemButton.Wait(3).Click();

            AlertHandler alert = new AlertHandler();
            alert.VerifyText("Are you sure you wish to delete this item?");
            alert.Accept();

            //switch to window
            DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 5);
        }

        private void VerifyExpectedIsInActualList(string expected, List<string> actualList)
        {
            bool isFound = false;
            foreach (var actual in actualList)
            {
                //check that the expected error message is found in the actual error message list
                if (actual.Contains(expected))
                {
                    isFound = true;
                }
            }
            Assert.IsTrue(isFound, "The expected message '" + expected + "' was not found in the actual message list.");
            Report.Write("Verified the expected message: '" + expected + "' was found within the actual message list.");
        }

        /// <summary>
        /// verify the steps are completed
        /// </summary>
        public void VerifyStepsCompleted()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                StepsCompletedLabel.Text = " 	                                 Completed                              ";
                StepsCompletedLabel.Displayed = true;
            }

            string actualMessage = "";

            //if the error message element is displayed
            if (StepsCompletedLabel.Displayed)
            {
                actualMessage = StepsCompletedLabel.Text.Trim();
                Report.Write("Actual message: " + actualMessage);
            }
            //the expected message matches
            Assert.AreEqual("Completed", actualMessage, "The expected message 'Completed' was not found in the actual message list.");
            Report.Write("Verified the expected message: 'Completed' was found within the actual message list.");
        }

        public override void InputFormFields()
        {
            ItemPropertiesForm.InputFormFields();
            //if not a task item
            if (ItemTypeForm.GetType() != typeof(ItemTypeTaskForm))
            {
                //then select a standard
                StandardPopupDialog = ItemPropertiesForm.StandardLookup();
                StandardPopupDialog.Data = Data.StandardPickerData;
                StandardPopupDialog.Form.InputAndSubmitForm();
                this.DriverCommands.WaitAndMeasurePageLoadTime();
                InitElements();
                ItemPropertiesForm.Data = Data.ItemTypeData;
                ItemPropertiesForm.AutoItDataObject = Data.AutoItData;
            }
            ItemTypeForm.Data = Data.ItemTypeData;
            ItemTypeForm.QuestionAnswerDataObject = Data.QuestionAnswerData;
            ItemTypeForm.AutoItDataObject = Data.AutoItData;
            ItemTypeForm.InputFormFields();
        }

        public override void InputAllFieldsExcept(List<string> excludeFields)
        {
            ItemPropertiesForm.InputAllFieldsExcept(excludeFields);
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            //Oleg found can return more than 1 page depending upon certain conditions
            //return new EditItemAvailabilityPage(Driver);
            return null;
        }

        public override IBaseScreenView SubmitForm()
        {
            Submit.MoveToElement(); //IE sometimes doesn't click on save button if not display on screen. 
            Submit.Wait(3).Click();
            return ReturnSubmitPage();
        }

        public override void SubmitFormAndVerifyErrors()
        {
            base.SubmitFormAndVerifyErrors();
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();
            ItemPropertiesForm.Data = Data.ItemTypeData;
            //the standard popup should not be displayed here, so skip setting the data
            //StandardPickerForm.DataObject = Data.StandardPickerData;
            //StandardPopupDialog.DataObject = Data.StandardPickerData;
            ItemTypeForm.Data = Data.ItemTypeData;
        }

        public override void VerifyErrorsForRequiredFields()
        {
            ItemPropertiesForm.VerifyErrorsForRequiredFields();
            ItemTypeForm.VerifyErrorsForRequiredFields();
            /*
            List<string> actualRequiredErrorsList = new List<string>();
            //get the error message element list
            ReadOnlyCollection<IWebElement> messageElements = StepsToCompleteLabels.WaitForElements(5);

            if (Driver.GetType() == typeof(DummyDriver))
            {
                messageElements = StandardPickerForm.GetDummyStepsToCompleteLabels();
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
                    Debug.WriteLine("Actual required message: " + actualMessage);
                }
            }
            //for each expected error message in the list
            foreach (var expectedMessage in StandardPickerForm.ExpectedRequiredErrorsList)
            {
                //assert that the expected error message is found in the actual error message list
                Assert.IsTrue(actualRequiredErrorsList.Contains(expectedMessage),
                    "The expected required message '" + expectedMessage + "' was not found in the actual required message list.");
            }
            */
        }

        public override void VerifyFieldsExist()
        {
            ItemPropertiesForm.VerifyFieldsExist();
            ItemTypeForm.VerifyFieldsExist();
        }

        public override void VerifyFieldsAreEnabled(List<string> includeFields)
        {
            ItemPropertiesForm.VerifyFieldsAreEnabled(includeFields);
        }

        public override void VerifyFieldsAreDisabled(List<string> includeFields)
        {
            ItemPropertiesForm.VerifyFieldsAreDisabled(includeFields);
        }

        public override void VerifyFieldsAreVisible(List<string> includeFields)
        {
            ItemPropertiesForm.VerifyFieldsAreVisible(includeFields);
        }

        public override void VerifyFieldsAreInvisible(List<string> includeFields)
        {
            ItemPropertiesForm.VerifyFieldsAreInvisible(includeFields);
        }

        public override void VerifyFieldsListOfValues(List<string> includeFields)
        {
            ItemPropertiesForm.VerifyFieldsListOfValues(includeFields);
        }
    }
}
