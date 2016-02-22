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
using UITests.Pages.Assess.Passage;
using UITests.Pages.Assess.Rubric;


namespace UITests.Pages.Assess.TestCreateEdit.CreateTestPortal
{
    /// <summary>
    /// the create test portal detail
    /// </summary>
    public class CreateTestPortalDetail : SNDetail
    {
        /// <summary>
        /// the create test portal detail
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public CreateTestPortalDetail(  string overrideControlPrefix = null)
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
            ExpressTestStartNow = new WebElementWrapper( ByExpressTestStartNow);
            ManualTestStartNow = new WebElementWrapper( ByManualTestStartNow);
            AssessLinks = new AssessLinks( PageNames.CreateTestPortal, ControlPrefix);
            CreateItemDropdown = new AddActivity( PageNames.CreateTestPortal, this.ControlPrefix);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new CreateTestPortalData Data
        {
            get
            {
                return (CreateTestPortalData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private By ByExpressTestStartNow { get { return By.Id(ControlPrefix + "btnByStandards"); } }
        private WebElementWrapper ExpressTestStartNow { get; set; }
        private By ByManualTestStartNow { get { return By.Id(ControlPrefix + "btnByQuestionNumber"); } }
        private WebElementWrapper ManualTestStartNow { get; set; }
        private AssessLinks AssessLinks { get; set; }
        private AddActivity CreateItemDropdown { get; set; }

        /// <summary>
        /// create an express test
        /// </summary>
        /// <returns>CreateTestExpressPage</returns>
        public CreateTestExpressPage CreateExpressTest()
        {
            //this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            this.Utilities.FocusOnMainContentArea();
            ExpressTestStartNow.Click();
            return new CreateTestExpressPage();
        }
        /// <summary>
        /// create a test manually
        /// </summary>
        /// <returns>CreateTestManualPage</returns>
        public CreateTestManualPage CreateManualTest()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            ManualTestStartNow.Click();
            return new CreateTestManualPage();
        }
        /// <summary>
        /// create an item
        /// </summary>
        /// <returns>EditTestItemChooseNewItemPage</returns>
        public EditTestItemChooseNewItemPage CreateAnItem()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            return AssessLinks.CreateAnItem();
        }
        /// <summary>
        /// create a passage
        /// </summary>
        /// <returns>CreatePassagePage</returns>
        public EditPassagePage CreateAPassage()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            return AssessLinks.CreateAPassage();
        }
        /// <summary>
        /// create a rubric
        /// </summary>
        /// <returns>ChooseGroupingRubricDialog</returns>
        public ChooseGroupingRubricDialog CreateARubric()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            return AssessLinks.CreateARubric();
        }
        /// <summary>
        /// pending items
        /// </summary>
        /// <returns>?</returns>
        public SNWebPage PendingItems()
        {
            this.Utilities.FocusOnMainContentArea();//this.Parent.Header.SelectWelcomeMessage(); //stop hover over menu
            return AssessLinks.PendingItems();
        }

        //new create item dropdown link
        /// <summary>
        /// select create item dropdown
        /// </summary>
        public void SelectCreateItemDropdown()
        {
            CreateItemDropdown.SelectAddActivity();
        }

        /*
        /// <summary>
        /// select create item, then select multiple choice
        /// </summary>
        /// <returns>TestItemPage</returns>
        public TestItemPage SelectCreateItemMultipleChoice()
        {
            TestItemPage testItem = CreateItemDropdown.SelectCreateItemMultipleChoice();
            return testItem;
        }
        */
    }
}
