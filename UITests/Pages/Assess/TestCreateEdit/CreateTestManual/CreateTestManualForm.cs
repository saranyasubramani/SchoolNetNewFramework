using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.TestCreateEdit;
using UITests.Pages.Assess.TestCreateEdit.Components;
using UITests.Pages.Assess.TestDetail;

namespace UITests.Pages.Assess.TestCreateEdit.CreateTestManual
{
    /// <summary>
    /// the create test manual form
    /// </summary>
    public class CreateTestManualForm : CreateTestForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public CreateTestManualForm(string overrideControlPrefix = null, CreateTestModes createTestMode = CreateTestModes.CreateManualTest)
            : base(overrideControlPrefix)
        {
            testCreationMode = createTestMode;
            //base class calls InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Martin CreateTestManualForm.InitElements");
            base.InitElements();
            NumberOfItemsText = new WebElementWrapper(ByNumberOfItemsText);
            AllMultipleChoiceButton = new WebElementWrapper(ByAllMultipleChoiceButton);
            DescriptionText = new WebElementWrapper(ByDescriptionText);
            LinkToTestWindowSelect = new SelectElementWrapper(new WebElementWrapper(ByLinkToTestWindowSelect));
        }

        /// <summary>
        /// the data
        /// </summary>
        public new CreateTestManualData Data
        {
            get
            {
                return (CreateTestManualData)base.Data;
            }
            set
            {
                Report.Write("Martin CreateTestManualForm.Data");
                base.Data = value;
            }
        }

        /// <summary>
        /// Determines how did you get to the Create Manual Test page
        /// </summary>
        private CreateTestModes testCreationMode = CreateTestModes.CreateManualTest;
        private By ByNumberOfItemsText { get { return By.Id(ControlPrefix + "TextBoxNumberItems"); } }
        private WebElementWrapper NumberOfItemsText { get; set; }
        private By ByAllMultipleChoiceButton { get { return By.Id(ControlPrefix + "CheckBoxAllMultipleChoice"); } }
        private WebElementWrapper AllMultipleChoiceButton { get; set; }
        private By ByDescriptionText { get { return By.Id(ControlPrefix + "TextBoxDescription"); } }
        private WebElementWrapper DescriptionText { get; set; }
        private By ByLinkToTestWindowSelect { get { return By.Id(ControlPrefix + "DropDownListLinkTestWindow"); } }
        private SelectElementWrapper LinkToTestWindowSelect { get; set; }

        /// <summary>
        /// select all multiple choices checkbox
        /// </summary>
        public void SelectAllMultipleChoice()
        {
            AllMultipleChoiceButton.Check();
        }

        //implemented methods
        public override void InputFormFields()
        {
            base.InputFormFields();

            if (testCreationMode == CreateTestModes.CreateManualTest)
            {
                NumberOfItemsText.Wait(3).Clear();
                NumberOfItemsText.SendKeys("" + Data.NumberOfItems);
            }

            ExpandOptional();

            if (Data.Description != null)
            {
                DescriptionText.Wait(3).Clear();
                DescriptionText.SendKeys(Data.Description);
            }
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            SNWebPage returnPage = null;

            if (testCreationMode == CreateTestModes.CreateManualTest)
            {
                returnPage = new EditQuestionChooseNewItemPage();
            }

            if (testCreationMode == CreateTestModes.CreateCopyOfTest)
            {
                returnPage = new ViewTestDetailsPage(TestStage.PrivateDraft);
            }

            return returnPage;
        }
    }
}
