using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Controls;
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.Standards;
using UITests.Pages.Assess.TestDetail;

namespace UITests.Pages.Assess.TestCreateEdit.CreateTestBySelectingStandards
{
    /// <summary>
    /// the create test by selecting standards form
    /// </summary>
    public class CreateTestBySelectingStandardsForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public CreateTestBySelectingStandardsForm(string overrideControlPrefix = null)
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
            StandardPickerForm = new StandardPickerForm(PageNames.CreateTestBySelectingStandardsPage, ControlPrefix);
            ItemStatisticsForm = new ItemStatisticsForm(PageNames.CreateTestBySelectingStandardsPage, ControlPrefix);
            SelectStandardsButton = new WebElementWrapper(BySelectStandardsButton);
            DefineTestMapButton = new WebElementWrapper(ByDefineTestMapButton);
            AdvancedOptionsButton = new WebElementWrapper(ByAdvancedOptionsButton);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new CreateTestBySelectingStandardsData Data
        {
            get
            {
                return (CreateTestBySelectingStandardsData)base.Data;
            }
            set
            {
                base.Data = value;
                StandardPickerForm.Data = ((CreateTestBySelectingStandardsData)base.Data).StandardPickerData;
                ItemStatisticsForm.Data = ((CreateTestBySelectingStandardsData)base.Data).ItemTypeMapData;
            }
        }

        /// <summary>
        /// the standard picker form
        /// </summary>
        public StandardPickerForm StandardPickerForm { get; private set; }
        /// <summary>
        /// the item type map form
        /// </summary>
        public ItemStatisticsForm ItemStatisticsForm { get; private set; }
        private TestId TestId { get; set; }
        private By BySelectStandardsButton { get { return By.Id("toggleStandards"); } }
        private WebElementWrapper SelectStandardsButton { get; set; }
        private By ByDefineTestMapButton { get { return By.Id("toggleTestMap"); } }
        private WebElementWrapper DefineTestMapButton { get; set; }
        private By ByAdvancedOptionsButton { get { return By.Id("toggleAdvancedOptions"); } }
        private WebElementWrapper AdvancedOptionsButton { get; set; }
        /// <summary>
        /// the submit by
        /// </summary>
        public override By BySubmit { get { return By.Id("btnGenerate"); } }

        /// <summary>
        /// remove available standard
        /// </summary>
        /// <param name="byStandardId"></param>
        public void RemoveAvailableStandard(int byStandardId)
        {
            StandardPickerForm.RemoveAvailableStandard(byStandardId);
        }

        /// <summary>
        /// set the available standard item quantity
        /// </summary>
        /// <param name="byStandardId">set by the standard ID</param>
        /// <param name="quantity">quantity</param>
        public void SetAvailableStandardItemQuantity(int byStandardId, int quantity)
        {
            StandardPickerForm.SetAvailableStandardItemQuantity(byStandardId, quantity);
        }

        /// <summary>
        /// edit and save test name
        /// </summary>
        /// <param name="name">test name</param>
        public void EditAndSaveTestName(string name)
        {
            TestId.EditName.Wait(3).Click();
            TestId.Name.Wait(3).SendKeys(name);
            TestId.SaveName.Wait(3).Click();
        }

        /// <summary>
        /// expand select standards
        /// </summary>
        public void ExpandSelectStandards()
        {
            SelectStandardsButton.FakeAttributeClass = "closed";
            if (SelectStandardsButton.WaitUntilExists(3).GetAttribute("class").Equals("closed"))
            {
                SelectStandardsButton.Wait(3).Click();
            }
        }

        /// <summary>
        /// collapse select standards
        /// </summary>
        public void CollapseSelectStandards()
        {
            SelectStandardsButton.FakeAttributeClass = "open";
            if (SelectStandardsButton.WaitUntilExists(3).GetAttribute("class").Equals("open"))
            {
                SelectStandardsButton.Wait(3).Click();
            }
        }

        /// <summary>
        /// expand define test map
        /// </summary>
        public void ExpandDefineTestMap()
        {
            DefineTestMapButton.FakeAttributeClass = "closed";
            if (DefineTestMapButton.WaitUntilExists(3).GetAttribute("class").Equals("closed"))
            {
                DefineTestMapButton.Wait(3).Click();
            }
        }

        /// <summary>
        /// collapse define test map
        /// </summary>
        public void CollapseDefineTestMap()
        {
            DefineTestMapButton.FakeAttributeClass = "open";
            if (DefineTestMapButton.WaitUntilExists(3).GetAttribute("class").Equals("open"))
            {
                DefineTestMapButton.Wait(3).Click();
            }
        }

        /// <summary>
        /// expand advanced options
        /// </summary>
        public void ExpandAdvancedOptions()
        {
            AdvancedOptionsButton.FakeAttributeClass = "closed";
            if (AdvancedOptionsButton.WaitUntilExists(3).GetAttribute("class").Equals("closed"))
            {
                AdvancedOptionsButton.Wait(3).Click();
            }
        }

        /// <summary>
        /// collapse advanced options
        /// </summary>
        public void CollapseAdvancedOptions()
        {
            AdvancedOptionsButton.FakeAttributeClass = "open";
            if (AdvancedOptionsButton.WaitUntilExists(3).GetAttribute("class").Equals("open"))
            {
                AdvancedOptionsButton.Wait(3).Click();
            }
        }

        //implemented methods
        public override void InputFormFields()
        {
            StandardPickerForm.InputAndSubmitForm();
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
            InitElements();
            //TODO: implement
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return new ViewTestDetailsPage();
        }
    }
}
