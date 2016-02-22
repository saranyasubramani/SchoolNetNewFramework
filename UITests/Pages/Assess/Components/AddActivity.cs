using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.ItemCentral;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;

namespace UITests.Pages.Assess.Components
{
    /// <summary>
    /// The add activity button dropdown component
    /// </summary>
    public class AddActivity : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="pageName">the page name</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public AddActivity(PageNames pageName, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            PageName = pageName;
            AddActivityButton = new WebElementWrapper(ByAddActivityButton());
            MultipleChoiceLink = new WebElementWrapper(ByMultipleChoiceLink());
            TrueFalseLink = new WebElementWrapper(ByTrueFalseLink());
            GriddedLink = new WebElementWrapper(ByGriddedLink());
            OpenResponseLink = new WebElementWrapper(ByOpenResponseLink());
            InlineResponseLink = new WebElementWrapper(ByInlineResponseLink());
            MatchingLink = new WebElementWrapper(ByMatchingLink());
            HotSpotMultipleSelectionLink = new WebElementWrapper(ByHotSpotMultipleSelectionLink());
            HotSpotSingleSelectionLink = new WebElementWrapper(ByHotSpotSingleSelectionLink());
            DragAndDropLink = new WebElementWrapper(ByDragAndDropLink());
            ClickStickClickDropLink = new WebElementWrapper(ByClickStickClickDropLink());
            ImportFromItemCentralLink = new WebElementWrapper(ByImportFromItemCentralLink());
        }

        private PageNames PageName;

        //private By ByAddActivityButton { get { return By.CssSelector("button.btn.dropdown-toggle"); } }
        private WebElementWrapper AddActivityButton { get; set; }
        //private By ByMultipleChoiceLink { get { return By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl00_linkActivityType"); } }
        private WebElementWrapper MultipleChoiceLink { get; set; }
        //private By ByTrueFalseLink { get { return By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl01_linkActivityType"); } }
        private WebElementWrapper TrueFalseLink { get; set; }
        //private By ByGriddedLink { get { return By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl02_linkActivityType"); } }
        private WebElementWrapper GriddedLink { get; set; }
        //private By ByOpenResponseLink { get { return By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl03_linkActivityType"); } }
        private WebElementWrapper OpenResponseLink { get; set; }
        //private By ByInlineResponseLink { get { return By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl04_linkActivityType"); } }
        private WebElementWrapper InlineResponseLink { get; set; }
        //private By ByMatchingLink { get { return By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl05_linkActivityType"); } }
        private WebElementWrapper MatchingLink { get; set; }
        //private By ByHotSpotMultipleSelectionLink { get { return By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl06_linkActivityType"); } }
        private WebElementWrapper HotSpotMultipleSelectionLink { get; set; }
        //private By ByHotSpotSingleSelectionLink { get { return By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl07_linkActivityType"); } }
        private WebElementWrapper HotSpotSingleSelectionLink { get; set; }
        //private By ByDragAndDropLink { get { return By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl08_linkActivityType"); } }
        private WebElementWrapper DragAndDropLink { get; set; }
        //private By ByClickStickClickDropLink { get { return By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl09_linkActivityType"); } }
        private WebElementWrapper ClickStickClickDropLink { get; set; }
        //private By ByImportFromItemCentralLink { get { return By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_linkExistingActivity"); } }
        private WebElementWrapper ImportFromItemCentralLink { get; set; }

        private By ByAddActivityButton()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateNewItem:
                    by = By.CssSelector("button.btn.dropdown-toggle");
                    break;
                case PageNames.EditTask:
                    by = By.CssSelector("button.btn.dropdown-toggle");
                    break;
                case PageNames.CreateTestPortal:
                    by = By.CssSelector(".btn.dropdown-toggle");
                    break;
            }
            return by;
        }
        private By ByMultipleChoiceLink()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl00_linkActivityType");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + "ActivityTypeSelector_rptActivityTypes_ctl00_linkActivityType");
                    break;
                case PageNames.CreateTestPortal:
                    by = By.CssSelector(".dropdown-menu > li > a[href='/AssessItems.mvc/TestItem']");
                    break;
            }
            return by;
        }
        private By ByTrueFalseLink()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl01_linkActivityType");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + "ActivityTypeSelector_rptActivityTypes_ctl01_linkActivityType");
                    break;
            }
            return by;
        }
        private By ByGriddedLink()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl02_linkActivityType");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + "ActivityTypeSelector_rptActivityTypes_ctl02_linkActivityType");
                    break;
            }
            return by;
        }
        private By ByOpenResponseLink()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl03_linkActivityType");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + "ActivityTypeSelector_rptActivityTypes_ctl03_linkActivityType");
                    break;
            }
            return by;
        }
        private By ByInlineResponseLink()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl04_linkActivityType");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + "ActivityTypeSelector_rptActivityTypes_ctl04_linkActivityType");
                    break;
            }
            return by;
        }
        private By ByMatchingLink()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl05_linkActivityType");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + "ActivityTypeSelector_rptActivityTypes_ctl05_linkActivityType");
                    break;
            }
            return by;
        }
        private By ByHotSpotMultipleSelectionLink()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl06_linkActivityType");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + "ActivityTypeSelector_rptActivityTypes_ctl06_linkActivityType");
                    break;
            }
            return by;
        }
        private By ByHotSpotSingleSelectionLink()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl07_linkActivityType");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + "ActivityTypeSelector_rptActivityTypes_ctl07_linkActivityType");
                    break;
            }
            return by;
        }
        private By ByDragAndDropLink()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl08_linkActivityType");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + "ActivityTypeSelector_rptActivityTypes_ctl08_linkActivityType");
                    break;
            }
            return by;
        }
        private By ByClickStickClickDropLink()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_rptActivityTypes_ctl09_linkActivityType");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + "ActivityTypeSelector_rptActivityTypes_ctl09_linkActivityType");
                    break;
            }
            return by;
        }
        private By ByImportFromItemCentralLink()
        {
            By by = null;
            switch (PageName)
            {
                case PageNames.CreateNewItem:
                    by = By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ActivityTypeSelector_linkExistingActivity");
                    break;
                case PageNames.EditTask:
                    by = By.Id(ControlPrefix + "ActivityTypeSelector_linkExistingActivity");
                    break;
            }
            return by;
        }

        /// <summary>
        /// select add activity
        /// </summary>
        public void SelectAddActivity()
        {
            AddActivityButton.Wait(3).Click();
            //pause the script for a second to let the pop-up display
            System.Threading.Thread.Sleep(1000);
        }
        /// <summary>
        /// select add activity, then select multiple choice
        /// </summary>
        public EditTaskPage SelectAddActivityMultipleChoice()
        {
            SelectAddActivity();
            MultipleChoiceLink.Wait(3).Click();
            return new EditTaskPage(new ItemTypeMultipleChoiceForm());
        }
        /// <summary>
        /// select add activity, then select true/false
        /// </summary>
        public EditTaskPage SelectAddActivityTrueFalse()
        {
            SelectAddActivity();
            TrueFalseLink.Wait(3).Click();
            return new EditTaskPage(new ItemTypeTrueFalseForm());
        }
        /// <summary>
        /// select add activity, then select gridded
        /// </summary>
        public EditTaskPage SelectAddActivityGridded()
        {
            SelectAddActivity();
            GriddedLink.Wait(3).Click();
            return new EditTaskPage(new ItemTypeGriddedForm());
        }
        /// <summary>
        /// select add activity, then select open response
        /// </summary>
        public EditTaskPage SelectAddActivityOpenResponse()
        {
            SelectAddActivity();
            OpenResponseLink.Wait(3).Click();
            return new EditTaskPage(new ItemTypeOpenResponseForm());
        }
        /// <summary>
        /// select add activity, then select inline response
        /// </summary>
        public EditTaskPage SelectAddActivityInlineResponse()
        {
            SelectAddActivity();
            InlineResponseLink.Wait(3).Click();
            return new EditTaskPage(new ItemTypeInlineResponseForm());
        }
        /// <summary>
        /// select add activity, then select matching
        /// </summary>
        public EditTaskPage SelectAddActivityMatching()
        {
            SelectAddActivity();
            MatchingLink.Wait(3).Click();
            return new EditTaskPage(new ItemTypeMatchingForm());
        }
        /// <summary>
        /// select add activity, then select hot spot multiple selection
        /// </summary>
        public EditTaskPage SelectAddActivityHotSpotMultipleSelection()
        {
            SelectAddActivity();
            HotSpotMultipleSelectionLink.Wait(3).Click();
            //TODO change this with hot spot
            return new EditTaskPage(new ItemTypeMultipleChoiceForm());
        }
        /// <summary>
        /// select add activity, then select hot spot single selection
        /// </summary>
        public EditTaskPage SelectAddActivityHotSpotSingleSelection()
        {
            SelectAddActivity();
            HotSpotSingleSelectionLink.Wait(3).Click();
            //TODO change this with hot spot
            return new EditTaskPage(new ItemTypeMultipleChoiceForm());
        }
        /// <summary>
        /// select add activity, then select drag and drop
        /// </summary>
        public EditTaskPage SelectAddActivityDragAndDrop()
        {
            SelectAddActivity();
            DragAndDropLink.Wait(3).Click();
            return new EditTaskPage(new ItemTypeDragDropForm());
        }
        /// <summary>
        /// select add activity, then select click stick click drop
        /// </summary>
        public EditTaskPage SelectAddActivityClickStickClickDrop()
        {
            SelectAddActivity();
            ClickStickClickDropLink.Wait(3).Click();
            //TODO change this with click drop
            return new EditTaskPage(new ItemTypeMultipleChoiceForm());
        }
        /// <summary>
        /// select add activity, then select import from item central
        /// </summary>
        public ItemCentralHomePage SelectAddActivityImportFromItemCentral()
        {
            SelectAddActivity();
            ImportFromItemCentralLink.Wait(3).Click();
            return new ItemCentralHomePage();
        }

        /* new create items 
        /// <summary>
        /// select create item, then select multiple choice
        /// </summary>
        /// <returns>TestItemPage</returns>
        public TestItemPage SelectCreateItemMultipleChoice()
        {
            SelectAddActivity();
            MultipleChoiceLink.Wait(3).Click();
            return new TestItemPage(Driver, ItemType.MultipleChoice);
        }
        */
    }
}
