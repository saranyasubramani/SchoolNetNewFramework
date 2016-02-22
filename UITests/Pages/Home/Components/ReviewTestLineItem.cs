using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Framework;
using Core.Views;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages;

namespace UITests.Pages.Home.Components
{
    public class ReviewTestLineItem : SNDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="index">the index</param>
        /// <param name="uniqueId">the unique ID is the div id for that row</param>
        public ReviewTestLineItem(int index, string uniqueId)
            : base()
        {
            UniqueId = uniqueId;
            Index = index;
            InitElements();
        }
        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            ControlPrefix = "ctl00MainContent";
            ReviewLink = new WebElementWrapper(ByReviewLink);
            TestTitle = new WebElementWrapper(ByTestTitle);
            TestSubjectGrade = new WebElementWrapper(ByTestSubjectGrade);
            TestDate = new WebElementWrapper(ByTestDate);
        }

        /// <summary>
        /// the line item's unique ID
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        /// the line item's index
        /// </summary>
        public int Index { get; set; }
        private string ControlPrefix2 = "ctl00ctl00WebPartManager1wp1078669889wp452309171_RepeaterLatestTests_";
        //ctl00MainContentctl00ctl00WebPartManager1wp1078669889wp452309171_RepeaterLatestTests_ctl01_panel2
        private By ByReviewLink { get { return By.Id(ControlPrefix + ControlPrefix2 + GetControlId() + "_panel2"); } }
        private WebElementWrapper ReviewLink { get; set; }
        private By ByTestTitle { get { return By.CssSelector("span[style*='font-size:1.2em']"); } }
        private WebElementWrapper TestTitle { get; set; }
        private By ByTestSubjectGrade { get { return By.CssSelector("span strong"); } }
        private WebElementWrapper TestSubjectGrade { get; set; }
        private By ByTestDate { get { return By.CssSelector("span.text-muted"); } }
        private WebElementWrapper TestDate { get; set; }

        private string GetControlId()
        {
            int lineItemIndex = Index + 1;
            if (lineItemIndex >= 1 && lineItemIndex <= 9) // between 1 to 9 (ie 1 digit)
                return "ctl" + "0" + lineItemIndex.ToString();
            if (lineItemIndex >= 10 && lineItemIndex <= 99) // between 10 to 99 (ie 2 digit)
                return "ctl" + lineItemIndex.ToString();

            return null;
        }

        /// <summary>
        /// click review link
        /// </summary>
        public void ClickReviewLink()
        {
            ReviewLink.Wait(3).Click();
        }
    }
}
