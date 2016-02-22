using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages.Components;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestDetail.TrackTestStatus
{
    /// <summary>
    /// completion statistic line item
    /// </summary>
    public class CompletionStatisticLineItem : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="webElement">IWebElement</param>
        /// <param name="key">the key, read from location url</param>
        /// <param name="index">the index</param>
        /// <param name="uniqueId">the unique ID</param>
        /// <param name="columnOnOff"></param>
        public CompletionStatisticLineItem(WebElementWrapper webElement, string key, int index, string uniqueId, CompletionStatisticConfiguration columnOnOff)
            : base()
        {
            ColumnConfiguration = columnOnOff;
            Key = key;
            UniqueId = uniqueId;
            Index = index;
            Location = new WebElementWrapper(ByLocation);
        }

        /// <summary>
        /// completion statistic configuration
        /// </summary>
        public CompletionStatisticConfiguration ColumnConfiguration;
        /// <summary>
        /// the line item's key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// the line item's unique ID
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        /// the line item's index
        /// </summary>
        public int Index { get; set; }
        private string ControlPrefix2 = "TrackTestDetail_DataCollectionGridView1_gridInstitutionView_";
        private string ControlPrefix3 = "TrackTestDetail_DataCollectionGridView1_";
        private By ByLocation { get { return By.CssSelector("a[href*='key=" + Key + "&section']"); } }
        //TrackTestResults.aspx?id=19504&key=1295&section=False&student=False&testedonly=True&student_section_key=0&referrer=~%2FAssess%2FViewTestDetails.aspx%3Ftestid%3D30067%26referrer%3D~%252fAssess%252fTestCentralHome.aspx&status=InProgress
        private WebElementWrapper Location { get; set; }
        private By ByStatus { get { return By.Id(ControlPrefix + ControlPrefix2 + ControlPrefix3 + UniqueId + "_HyperLinkDataCollectionReport"); } }
        private WebElementWrapper Status { get; set; }

        /// <summary>
        /// click location link
        /// </summary>
        public void ClickLocationLink()
        {
            Location.Click();
        }
    }
}
