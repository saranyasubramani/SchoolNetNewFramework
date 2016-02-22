using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Components
{
    /// <summary>
    /// search result line item (row)
    /// </summary>
    public class SearchResultLineItem : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="index">the index</param>
        /// <param name="uniqueId">the unique ID is the div id for that row</param>
        public SearchResultLineItem(int index)
            : base()
        {
            Index = index;
            TestLink = new WebElementWrapper(ByTestLink);
        }

        /// <summary>
        /// the line item's index
        /// </summary>
        public int Index { get; set; }
        private string ControlPrefix2 = "TestSearchResults1_TestFinderResults1_gridResults_";
        //ctl00_MainContent_TestSearchResults1_TestFinderResults1_gridResults_ctl23_HyperLinkTest
        private By ByTestLink { get { return By.Id(ControlPrefix + ControlPrefix2 + GetUniqueId() + "_HyperLinkTest"); } }
        private WebElementWrapper TestLink { get; set; }

        /// <summary>
        /// Get control for each item on the grid. Start with ctl03, ctl04, ctl05 ...
        /// Use index to calculate it based on assumption that first item is always ctl03
        /// </summary>
        /// <returns></returns>
        private string GetUniqueId()
        {
            string control = "ctl";
            if (Index >= 0 && Index <= 9)
            {
                control = control + "0" + (Index + 3).ToString();
            }
            if (Index >= 10 && Index <= 99)
            {
                control = control + (Index + 3).ToString();
            }
            return control;
        }

        /// <summary>
        /// click test name link
        /// </summary>
        public void ClickTestNameLink()
        {
            TestLink.Wait(130).Click(); //Oleg changed wait from  3 to 130
        }

        /// <summary>
        /// get test name
        /// </summary>
        public string GetTestName()
        {
            string name = TestLink.Text;
            //Report.Write("GetTestName. By: " + ByTestLink.ToString() + "  value: " + name);
            return name;
        }
    }
}
