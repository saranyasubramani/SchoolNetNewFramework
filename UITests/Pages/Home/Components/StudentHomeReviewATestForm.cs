using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages;
using UITests.Pages.Home;

namespace UITests.Pages.Home.Components
{
    /// <summary>
    /// student home page, review a test widget
    /// </summary>
    public class StudentHomeReviewATestForm : SNForm
    {
        /// <summary>
        /// the constructor for review a test widget
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public StudentHomeReviewATestForm(string overrideControlPrefix = null)
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
            ReviewTestGrid = new WebElementWrapper(ByReviewTestGrid);
            //generates a list on the page load
            SetReviewTestList();
        }

        /// <summary>
        /// the data
        /// </summary>
        public new StudentHomeData Data
        {
            get
            {
                return (StudentHomeData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private By ByReviewTestGrid { get { return By.CssSelector("#ctl00MainContentctl00ctl00WebPartManager1wp1078669889wp452309171 .space1"); } }
        private WebElementWrapper ReviewTestGrid { get; set; }
        List<ReviewTestLineItem> ReviewLineItemList { get; set; }
        private ReadOnlyCollection<IWebElement> ReviewTestRowWebElementList { get; set; }
        private By ByReviewTestRow { get { return By.CssSelector("a[key]"); } }

        /// <summary>
        /// Generate a list of item for the component on the review a test grid
        /// </summary>
        private void SetReviewTestList()
        {
            ReviewLineItemList = new List<ReviewTestLineItem>();
            ReviewTestRowWebElementList = ReviewTestGrid.WaitForElements(5);

            if (Driver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy1 = new DummyWebElement();
                dummy1.TagName = "div";
                dummy1.FakeAttributeId = "ctl00MainContentctl00ctl00WebPartManager1wp1078669889wp452309171_RepeaterLatestTests_ctl01_panel2";
                dummy1.FakeAttributeClass = "space1";
                DummyWebElement dummy2 = new DummyWebElement();
                dummy2.TagName = "div";
                dummy2.FakeAttributeId = "ctl00MainContentctl00ctl00WebPartManager1wp1078669889wp452309171_RepeaterLatestTests_ctl02_panel2";
                dummy2.FakeAttributeClass = "space1";

                List<IWebElement> list = new List<IWebElement> { dummy1, dummy2 };
                ReviewTestRowWebElementList = new ReadOnlyCollection<IWebElement>(list);
            }

            int index = 0;
            foreach (var webElement in ReviewTestRowWebElementList)
            {
                string uniqueId = webElement.GetAttribute("id");
                ReviewTestLineItem lineItem = new ReviewTestLineItem(index, uniqueId);
                ReviewLineItemList.Add(lineItem);
                index++;
            }
        }

        /// <summary>
        /// get the review a test grid list
        /// </summary>
        /// <returns>List of ReviewTestLineItem</returns>
        public List<ReviewTestLineItem> GetReviewTestList()
        {
            return ReviewLineItemList;
        }

        /// <summary>
        /// gets an item from the review a test grid list
        /// </summary>
        /// <param name="index">the index of the item</param>
        /// <returns>ReviewLineItemList</returns>
        public ReviewTestLineItem GetItemFromReviewTestGrid(int index)
        {
            return ReviewLineItemList[index];
        }

        //implement methods
        public override IBaseScreenView ReturnSubmitPage()
        {
            return null;
        }
        public override IBaseScreenView ReturnCancelPage()
        {
            return null;
        }
    }
}
