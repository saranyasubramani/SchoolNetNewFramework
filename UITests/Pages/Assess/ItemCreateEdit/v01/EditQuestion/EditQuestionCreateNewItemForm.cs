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
using UITests.Pages.Components;
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.Standards;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTestItem;
using UITests.Pages.Assess.TestDetail;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.EditQuestion
{
    /// <summary>
    /// the edit question form
    /// </summary>
    public class EditQuestionCreateNewItemForm : EditTestItemCreateNewItemForm
    {
        /// <summary>
        /// the edit question form constructor
        /// </summary>
        /// <param name="itemTypeForm">item type form</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public EditQuestionCreateNewItemForm(ItemTypeForm itemTypeForm, string overrideControlPrefix = null)
            : base(itemTypeForm, overrideControlPrefix, PageNames.EditQuestion)
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }
        /// <summary>
        /// the edit question form constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public EditQuestionCreateNewItemForm(ItemType itemType, string overrideControlPrefix = null)
            : base(itemType, overrideControlPrefix, PageNames.EditQuestion)
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
            base.InitElements();
        }

        /// <summary>
        /// the data object
        /// </summary>
        public new EditPageData Data
        {
            get
            {
                return (EditPageData)base.Data;
            }
            set
            {
                Report.Write("Martin... in EditQuestionCreateNewItemForm.Data...");
                base.Data = value;
                EditPageData data = (EditPageData)value;
            }
        }

        /// <summary>
        /// the submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ButtonSubmit"); } }
        /// <summary>
        /// the cancel by
        /// </summary>
        public override By ByCancel { get { return By.Id(ControlPrefix + "ButtonCancel"); } }

        /// <summary>
        /// input form fields on item properties
        /// </summary>
        public void InputFormFields_ItemProperties()
        {
            ItemPropertiesForm.InputFormFields_EditQuestionPage();
        }
        /// <summary>
        /// input form fields on item form
        /// </summary>
        public void InputFormFields_ItemForm()
        {
            ItemTypeForm.Data = Data.ItemTypeData;
            ItemTypeForm.QuestionAnswerDataObject = Data.QuestionAnswerData;
            ItemTypeForm.AutoItDataObject = Data.AutoItData;
            ItemTypeForm.InputFormFields();
        }

        public void InputFormFields_AnswerKeyOnly()
        {
            ItemTypeForm.InputFormFields_AnswerKeyOnly();
        }

        //implemented methods
        public override void InputFormFields()
        {
            ItemPropertiesForm.InputFormFields_EditQuestionPage();
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

        public override IBaseScreenView ReturnSubmitPage()
        {
            return new ViewTestDetailsPage(TestStage.PrivateDraft);
        }

        public override void VerifyErrorsForRequiredFields()
        {
            ItemTypeForm.VerifyErrorsForRequiredFields();

            List<string> actualRequiredErrorsList = new List<string>();
            //get the error message element list
            ReadOnlyCollection<IWebElement> messageElements = StepsToCompleteLabels.WaitForElements(5);

            if (StandardPopupDialog != null)
            {
                if (Driver.GetType() == typeof(DummyDriver))
                {
                    messageElements = StandardPopupDialog.Form.GetDummyStepsToCompleteLabels();
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
                foreach (var expectedMessage in StandardPopupDialog.Form.ExpectedRequiredErrorsList)
                {
                    //assert that the expected error message is found in the actual error message list
                    Assert.IsTrue(actualRequiredErrorsList.Contains(expectedMessage),
                        "The expected required message '" + expectedMessage + "' was not found in the actual required message list.");
                }
            }
        }
    }
}
