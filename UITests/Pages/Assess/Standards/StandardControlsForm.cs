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

namespace UITests.Pages.Assess.Standards
{
    /// <summary>
    /// represents the controls on a page to invoke the standard picker form.
    /// </summary>
    public class StandardControlsForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="pageName">the page name</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        /// <param name="customControlPrefix">custom id (eg for rubric)</param>
        public StandardControlsForm(PageNames pageName, string overrideControlPrefix = null, string customControlPrefix = null)
            : base()
        {
            this.PageName = pageName;
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            if (customControlPrefix != null)
            {
                this.CustomControlPrefix = customControlPrefix;
            }
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            switch (PageName)
            {
                case PageNames.CreateNewItem:
                    //ctl00_MainContent_StandardsQuickPicker_ddlStandardDoc
                    //ctl00_MainContent_StandardsQuickPicker_AutoCompleteStandard
                    //ctl00_MainContent_StandardsQuickPicker_btnStandards
                    ControlMiddle = "";
                    break;
                case PageNames.EditTestItem:
                    //ctl00_MainContent_StandardsQuickPicker_ddlStandardDoc
                    //ctl00_MainContent_StandardsQuickPicker_AutoCompleteStandard
                    //ctl00_MainContent_StandardsQuickPicker_btnStandards
                    ControlMiddle = "";
                    break;
                case PageNames.EditQuestion:
                    //ctl00_MainContent_StandardsQuickPicker_ddlStandardDoc
                    //ctl00_MainContent_StandardsQuickPicker_AutoCompleteStandard
                    //ctl00_MainContent_StandardsQuickPicker_btnStandards
                    ControlMiddle = "";
                    break;
                case PageNames.ItemCentral:
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_StandardsQuickPicker_ddlStandardDoc
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_StandardsQuickPicker_AutoCompleteStandard
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_StandardsQuickPicker_btnStandards
                    ControlMiddle = "ItemFinder1_ItemFinderSearch1_StandardsQuickPicker_";
                    break;
                case PageNames.EditRubric:
                    //ctl00_MainContent_ctl00_EditRubricStandardControl_rptRubricStandardHeader_ctl00_rptRubricStandard_ctl00_RubricStandardPicker_btnStandards
                    ControlMiddle = "ctl00_EditRubricStandardControl_rptRubricStandardHeader_";
                    break;
            }
            StandardSelect = new SelectElementWrapper(new WebElementWrapper(ByStandardSelect));
            StandardNameText = new WebElementWrapper(ByStandardNameText);
            EditStandardLink = new WebElementWrapper(ByEditStandardLinkLocator());
            StandardLookupButton = new WebElementWrapper(ByStandardLookupButton());
        }

        /// <summary>
        /// the data
        /// </summary>
        public StandardPickerData Data
        {
            get
            {
                return (StandardPickerData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private StandardPickerForm StandardPickerForm { get; set; }
        private PageNames PageName { get; set; }
        private string _standardName;
        private string ControlMiddle { get; set; }
        private string CustomControlPrefix { get; set; }
        private By ByStandardSelect { get { return By.Id(ControlPrefix + ControlMiddle + "StandardsQuickPicker_ddlStandardDoc"); } }
        private SelectElementWrapper StandardSelect { get; set; }
        private By ByStandardNameText { get { return By.Id(ControlPrefix + ControlMiddle + "StandardsQuickPicker_AutoCompleteStandard"); } }
        private WebElementWrapper StandardNameText { get; set; }
        //private By ByEditStandardLink { get { return EditStandardLinkLocator(); } }
        private WebElementWrapper EditStandardLink { get; set; }
        protected By ByStandardNameAutoCompleteLabel { get { return By.CssSelector("div.ac_results > ul > li > span.ac_resultFull[title='" + _standardName + "']"); } }
        protected WebElementWrapper StandardNameAutoCompleteLabel { get; private set; }
        //private By ByStandardLookupButton { get { return By.Id(ControlPrefix + ControlMiddle + "StandardsQuickPicker_btnStandards"); } }
        private WebElementWrapper StandardLookupButton { get; set; }
        /// <summary>
        /// the cancel by
        /// </summary>
        public override By ByCancel { get { return ByCancelLocator(); } }
        /// <summary>
        /// the submit by
        /// </summary>
        public override By BySubmit { get { return BySubmitLocator(); } }

        private By ByCancelLocator()
        {
            By by = null;
            if (PageName == PageNames.TestItem)
            {
                by = By.CssSelector(".modal-footer [data-ng-click='close()']");
            }
            else
            {
                by = By.Id(ControlPrefix + "ButtonCancel");
            }
            return by;
        }
        private By BySubmitLocator()
        {
            By by = null;
            string locator = null;
            switch (PageName)
            {
                case PageNames.TestItemStandardPopup:
                    //ctl00_MainContent_ButtonApply
                    locator = ControlPrefix + "ButtonApply";
                    by = By.Id(locator);
                    break;
                case PageNames.CreateNewItem:
                    locator = ControlPrefix + "ButtonApply";
                    by = By.Id(locator);
                    break;
                case PageNames.EditTestItem:
                    locator = ControlPrefix + "ButtonApply";
                    by = By.Id(locator);
                    break;
                case PageNames.EditTask:
                    locator = ControlPrefix + "ButtonApply";
                    by = By.Id(locator);
                    break;
                case PageNames.EditQuestion:
                    locator = ControlPrefix + "ButtonApply";
                    by = By.Id(locator);
                    break;
                case PageNames.ItemCentral:
                    //ctl00_MainContent_ItemFinder1_ItemFinderSearch1_btnAddStandards
                    locator = ControlPrefix + "ItemFinder1_ItemFinderSearch1_btnAddStandards";
                    by = By.Id(locator);
                    break;
                case PageNames.CreateTestBySelectingStandardsPage:
                    //btnAddBottom
                    locator = "btnAddBottom";
                    by = By.Id(locator);
                    break;
                case PageNames.EditRubric:
                    //btnAddBottom
                    locator = ControlPrefix + "ButtonApply";
                    by = By.Id(locator);
                    break;
                case PageNames.TestItem:
                    by = By.CssSelector(".modal-footer [data-ng-click='submit()']");
                    break;
            }
            return by;
        }
        private By ByStandardLookupButton()
        {
            By by = null;
            if (PageName == PageNames.TestItem)
            {
                //document.querySelectorAll("#test-item-edit-header [data-ng-click='browseStandards()']");
                by = By.CssSelector("#test-item-edit-header [data-ng-click='browseStandards()']");
            }
            else
            {
                by = By.Id(ControlPrefix + ControlMiddle + "StandardsQuickPicker_btnStandards");
            }
            return by;
        }
        private By ByEditStandardLinkLocator()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateNewItem:
                    by = By.CssSelector("#divCurrentStandard > a");
                    break;
                case PageNames.EditTestItem:
                    by = By.CssSelector("#divCurrentStandard > a");
                    break;
                case PageNames.EditQuestion:
                    by = By.CssSelector("#divCurrentStandard > a");
                    break;
                case PageNames.ItemCentral:
                    by = By.CssSelector("#divCurrentStandard > a");
                    break;
                case PageNames.EditRubric:
                    if (CustomControlPrefix != null)
                    {
                        by = By.Id(CustomControlPrefix);
                    }
                    break;
                default:
                    by = By.CssSelector("#divCurrentStandard > a");
                    break;
            }
            return by;
        }

        private StandardPickerForm LoadStandardPickerForm()
        {
            StandardPickerForm = new StandardPickerForm(PageName, ControlPrefix);
            return StandardPickerForm;
        }

        /// <summary>
        /// select the standard lookup button, and displays the standard picker form
        /// </summary>
        /// <returns>StandardPickerForm</returns>
        public StandardPickerForm StandardLookup_StandardForm()
        {
            StandardLookupButton.Wait(3).Click();
            //pause the script for a second to let the pop-up display
            System.Threading.Thread.Sleep(1000);
            //return LoadStandardPickerForm();
            return new StandardPickerForm(PageName, ControlPrefix);
        }
        /// <summary>
        /// select the standard lookup button, and opens the standard popup dialog (page)
        /// </summary>
        /// <returns>StandardPopupDialog</returns>
        public StandardPopupDialog StandardLookup_StandardPopup()
        {
            StandardLookupButton.Wait(3).Click();
            //pause the script for a second to let the pop-up display
            System.Threading.Thread.Sleep(1000);
            return new StandardPopupDialog(PageName, ControlPrefix);
        }

        /// <summary>
        /// select the edit standard link
        /// </summary>
        /// <returns>this StandardControlsForm</returns>
        public StandardControlsForm EditStandard()
        {
            EditStandardLink.Wait(3).Click();
            return this;
        }

        /// <summary>
        /// set the standard document and standard name
        /// </summary>
        /// <param name="standardDocument">example...Ohio English Language Arts 2003</param>
        /// <param name="standardName">example...LA.1.R.1: Reading / Phonemic Awareness, Word Recognition and Fluency</param>
        /// <returns>this StandardControlsForm</returns>
        public StandardControlsForm SelectStandard(string standardDocument, string standardName)
        {
            _standardName = standardName;
            StandardSelect.Wait(3).SelectByText(standardDocument);
            standardName = standardName.Substring(0, 3); //Type just first 3 letters. Autocomplete popup will then appear. 
            StandardNameText.Wait(5).SendKeys(standardName);
            StandardNameAutoCompleteLabel = new WebElementWrapper(ByStandardNameAutoCompleteLabel);
            StandardNameAutoCompleteLabel.WaitUntilVisible(10).Click();
            return this;
        }

        //implemented methods
        public override void VerifyFieldsExist()
        {
            StandardLookupButton.Displayed = true;
            Assert.IsTrue(StandardLookupButton.Displayed, this.Utilities.GetInvisibleErrorMessage(StandardLookupButton.By.ToString()));
        }
    }
}
