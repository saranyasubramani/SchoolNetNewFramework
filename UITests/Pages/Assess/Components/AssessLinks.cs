using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.Passage;
using UITests.Pages.Assess.Rubric;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestCreateEdit;

namespace UITests.Pages.Assess.Components
{
    /// <summary>
    /// the assessment links for create item, create passage, create rubric, and pending items
    /// </summary>
    public class AssessLinks : SNDetail
    {
        /// <summary>
        /// the assess links constructor
        /// </summary>
        /// <param name="pageNames">the page names</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public AssessLinks(PageNames pageNames, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            PageNames = pageNames;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            CreateItem = new WebElementWrapper(ByCreateItem);
            CreatePassage = new WebElementWrapper(ByCreatePassage);
            CreateRubric = new WebElementWrapper(ByCreateRubric);
            PendingItem = new WebElementWrapper(ByPendingItem);
        }

        private PageNames PageNames { get; set; }
        private WebElementWrapper ManualTestStartNow { get; set; }
        private By ByCreateItem { get { return CreateItemLocator(); } }
        private WebElementWrapper CreateItem { get; set; }
        private By ByCreatePassage { get { return CreatePassageLocator(); } }
        private WebElementWrapper CreatePassage { get; set; }
        private By ByCreateRubric { get { return CreateRubricLocator(); } }
        private WebElementWrapper CreateRubric { get; set; }
        private By ByPendingItem { get { return PendingItemLocator(); } }
        private WebElementWrapper PendingItem { get; set; }

        private By CreateItemLocator()
        {
            By by = null;
            switch (PageNames)
            {
                case PageNames.CreateTestPortal:
                    by = By.ClassName("linkCreateItem");
                    break;
                case PageNames.ItemCentralHome:
                    by = By.Id(ControlPrefix + "ButtonCreateItem");
                    break;
                case PageNames.ItemCentral:
                    by = By.Id(ControlPrefix + "ItemFinder1_ButtonCreateItem");
                    break;
            }
            return by;
        }
        private By CreatePassageLocator()
        {
            By by = null;
            switch (PageNames)
            {
                case PageNames.CreateTestPortal:
                    by = By.ClassName("linkCreatePassage");
                    break;
                case PageNames.ItemCentralHome:
                    by = By.Id(ControlPrefix + "ButtonCreatePassage");
                    break;
                case PageNames.ItemCentral:
                    by = By.Id(ControlPrefix + "ItemFinder1_ButtonCreatePassage");
                    break;
            }
            return by;
        }
        private By CreateRubricLocator()
        {
            By by = null;
            switch (PageNames)
            {
                case PageNames.CreateTestPortal:
                    by = By.ClassName("linkCreateRubric");
                    break;
                case PageNames.ItemCentralHome:
                    by = By.Id(ControlPrefix + "ButtonCreateRubric");
                    break;
                case PageNames.ItemCentral:
                    by = By.Id(ControlPrefix + "ItemFinder1_ButtonCreateRubric");
                    break;
            }
            return by;
        }
        private By PendingItemLocator()
        {
            By by = null;
            switch (PageNames)
            {
                case PageNames.CreateTestPortal:
                    by = By.ClassName("pendingItemsLink");
                    break;
                case PageNames.ItemCentralHome:
                    by = By.ClassName("lnkPendingItems");
                    break;
                case PageNames.ItemCentral:
                    by = By.ClassName("lnkPendingItems");
                    break;
            }
            return by;
        }

        /// <summary>
        /// create an item
        /// </summary>
        /// <returns>EditTestItemChooseNewItemPage</returns>
        public EditTestItemChooseNewItemPage CreateAnItem()
        {
            CreateItem.Click();
            return new EditTestItemChooseNewItemPage();
        }
        /// <summary>
        /// create a passage
        /// </summary>
        /// <returns>EditPassagePage</returns>
        public EditPassagePage CreateAPassage()
        {
            CreatePassage.Click();
            return new EditPassagePage();
        }
        /// <summary>
        /// create a rubric
        /// </summary>
        /// <returns>ChooseGroupingRubricDialog</returns>
        public ChooseGroupingRubricDialog CreateARubric()
        {
            CreateRubric.Click();
            return new ChooseGroupingRubricDialog();
        }
        /// <summary>
        /// pending items
        /// </summary>
        /// <returns>?</returns>
        public SNWebPage PendingItems()
        {
            PendingItem.Click();
            //TODO place holder for new page object
            return new CreateTestPortalPage();
        }
    }
}
