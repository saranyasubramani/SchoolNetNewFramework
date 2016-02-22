using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Controls;
using UITests.Pages.Assess.TestDetail.Components;

namespace UITests.Pages.Assess.TestDetail.TrackTestStatus
{
    /// <summary>
    /// the track test status detail
    /// </summary>
    public class TrackTestStatusDetail : SNDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public TrackTestStatusDetail(  string overrideControlPrefix = null)
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
            BackToPreviousPageTop = new WebElementWrapper( ByBackToPreviousPageTop);
            Status = new WebElementWrapper( ByStatus);
            ExcludeLocations = new WebElementWrapper( ByExcludeLocations);
            CompletionStatisticGrid = new WebElementWrapper( ByCompletionStatisticGrid);
            CompletionStatisticRows = new WebElementWrapper( ByCompletionStatisticRows);
            LocationColumn = new WebElementWrapper( ByLocationColumn);
            ViewDetailsLink = new ViewDetailsLink( PageNames.TrackTestStatus, this.ControlPrefix);
            PreviousPageBottomLink = new PreviousPageBottomLink( PageNames.TrackTestStatus, this.ControlPrefix);
            //generates a list on the page load
            SetCompletionStatisticList();
        }

        private string ControlPrefix2 = "SelectedTestDisplayControl_";
        private string ControlPrefix3 = "TrackTestDetail_DataCollectionGridView1_";
        private By ByBackToPreviousPageTop { get { return By.Id(ControlPrefix + "BackToPreviousPageControl1_" + "HyperLinkBackText"); } }
        private WebElementWrapper BackToPreviousPageTop { get; set; }
        private By ByStatus { get { return By.Id(ControlPrefix + ControlPrefix2 + "ProgressBarControl_" + "HyperLinkDataCollectionReport"); } }
        private WebElementWrapper Status { get; set; }
        private By ByExcludeLocations { get { return By.Id(ControlPrefix + ControlPrefix3 + "CheckBoxTestedOnly"); } }
        private WebElementWrapper ExcludeLocations { get; set; }
        private By ByCompletionStatisticGrid { get { return By.Id(ControlPrefix + ControlPrefix3 + "gridInstitutionView"); } }
        private WebElementWrapper CompletionStatisticGrid { get; set; }
        private By ByCompletionStatisticRows { get { return By.CssSelector("tr.DataGridAltRow, tr.DataGridRow"); } }
        private WebElementWrapper CompletionStatisticRows { get; set; }
        private By ByLocationColumn { get { return By.CssSelector("a[href*='key=']"); } }
        private WebElementWrapper LocationColumn { get; set; }
        private By ByCollectionStatusColumn { get { return By.CssSelector("a.aspNetDisabled"); } }
        private ReadOnlyCollection<IWebElement> CompletionStatisticWebElementList { get; set; }
        private List<CompletionStatisticLineItem> CompletionStatisticList { get; set; }
        private CompletionStatisticConfiguration ColumnConfig { get; set; }
        private ViewDetailsLink ViewDetailsLink { get; set; }
        private PreviousPageBottomLink PreviousPageBottomLink { get; set; }

        /// <summary>
        /// Generate a list of item for the component on the grid
        /// </summary>
        private void SetCompletionStatisticList()
        {
            CompletionStatisticList = new List<CompletionStatisticLineItem>();
            CompletionStatisticGrid.Wait(3);
            CompletionStatisticWebElementList = CompletionStatisticRows.WaitForElements(5);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy1 = new DummyWebElement();
                dummy1.TagName = "tr";
                dummy1.FakeAttributeClass = "DataGridAltRow";
                DummyWebElement dummy2 = new DummyWebElement();
                dummy2.TagName = "tr";
                dummy2.FakeAttributeClass = "DataGridAltRow";
                List<IWebElement> list = new List<IWebElement> { dummy1, dummy2 };
                CompletionStatisticWebElementList = new ReadOnlyCollection<IWebElement>(list);
            }

            int index = 0;

            ColumnConfig = new CompletionStatisticConfiguration();
            ColumnConfig.Location = true;
            ColumnConfig.NumEligibleTesting = true;
            ColumnConfig.NumDataCollected = true;
            ColumnConfig.PercentDataCollected = true;
            ColumnConfig.CompletedOnline = true;
            ColumnConfig.CollectionStatus = true;

            foreach (var webElement in CompletionStatisticWebElementList)
            {
                Report.Write("Grid Row: " + webElement.Text);
                WebElementWrapper rowElementWrapper = new WebElementWrapper( ByCompletionStatisticRows);
                rowElementWrapper.WrappedElement = webElement;

                string locationLinkRefValue = GetLinkRefValue(rowElementWrapper, ByLocationColumn);
                string key = GetRowKey(locationLinkRefValue);
                string uniqueId = GetUniqueId(rowElementWrapper, ByCollectionStatusColumn);

                CompletionStatisticLineItem lineItem = new CompletionStatisticLineItem( rowElementWrapper, key, index, uniqueId, ColumnConfig);
                CompletionStatisticList.Add(lineItem);
                index++;
            }
        }

        /// <summary>
        /// get the completion statistic grid list
        /// </summary>
        /// <returns>List of CompletionStatisticLineItem</returns>
        public List<CompletionStatisticLineItem> GetCompletionStatGridList()
        {
            return CompletionStatisticList;
        }

        /// <summary>
        /// gets an item from the completion statistic grid list
        /// </summary>
        /// <param name="index">the index of the item</param>
        /// <returns>CompletionStatisticLineItem</returns>
        public CompletionStatisticLineItem GetItemFromCompletionStatGrid(int index)
        {
            return CompletionStatisticList[index];
        }

        private string GetRowKey(string rowLinkReference)
        {
            //TrackTestResults.aspx?id=19504&key=1295&section=False&student=False&testedonly=True&......
            int from = rowLinkReference.IndexOf("key=") + "key=".Length;
            int to = rowLinkReference.IndexOf("&section");
            string key = rowLinkReference.Substring(from, to - from);
            Report.Write("Got the key from the link ref key value: " + key);
            return key;
        }
        /// <summary>
        /// Inside each row for CompletionStatistic grid, there is the Location link. 
        /// This function return the location link value.
        /// tr.td.a href="TrackTestResults.aspx?id=19504&key=789&section=False..."
        /// </summary>
        /// <param name="rowElement"></param>
        /// <returns></returns>
        private string GetLinkRefValue(WebElementWrapper rowElement, By by)
        {
            IWebElement linkElement = rowElement.FindElement(by);
            WebElementWrapper linkElementWrapper = new WebElementWrapper( by);
            linkElementWrapper.WrappedElement = linkElement;
            linkElementWrapper.FakeAttributeHref = "TrackTestResults.aspx?id=19504&key=789&section=False";

            string linkReference = linkElementWrapper.GetAttribute("href");
            Report.Write("Got link reference: " + linkReference);
            return linkReference;

        }

        private string GetUniqueId(WebElementWrapper webElement, By by)
        {
            IWebElement statusColumn = webElement.FindElement(by);
            WebElementWrapper statusColumnWrapper = new WebElementWrapper( by);
            statusColumnWrapper.WrappedElement = statusColumn;
            statusColumnWrapper.FakeAttributeId = "ctl00_MainContent_TrackTestDetail_DataCollectionGridView1_gridInstitutionView_ctl03_ctl01_HyperLinkDataCollectionReport";

            string id = statusColumnWrapper.GetAttribute("id");
            Report.Write("Got the attribute: 'id' = '" + id + "' of this element by: '" + by.ToString() + "'.");
            int from = id.IndexOf("_ctl") + "_ctl".Length;
            int to = id.LastIndexOf("_");
            string index = id.Substring(from, to - from);
            string uniqueId = "ctl" + index;
            Report.Write("uniqueId is " + uniqueId); // ctl03_ctl01
            return uniqueId;
        }

        /// <summary>
        /// click on the back to previous page link on top 
        /// </summary>
        public void BackToPreviousPageOnTop()
        {
            BackToPreviousPageTop.Wait(3).Click();
        }

        /// <summary>
        /// click on the back to previous page link on bottom 
        /// </summary>
        public void BackToPreviousPageOnBottom()
        {
            PreviousPageBottomLink.Control.Wait(3).Click();
        }

        /// <summary>
        /// click on view detail link
        /// </summary>
        /// <returns></returns>
        public ViewTestDetailsPage ClickViewDetailsLink()
        {
            ViewDetailsLink.Control.Wait(3).Click();
            return new ViewTestDetailsPage();
        }

        /// <summary>
        /// click on status link
        /// </summary>
        /// <returns></returns>
        public TrackTestStatusPage ClickStatusLink()
        {
            Status.Click();
            return new TrackTestStatusPage();
        }

        /// <summary>
        /// check on exclude location checkbox
        /// </summary>
        /// <returns></returns>
        public TrackTestStatusPage CheckExcludeLocation()
        {
            ExcludeLocations.Click();
            return new TrackTestStatusPage();
        }

        /// <summary>
        /// get collection status data
        /// </summary>
        /// <returns>text</returns>
        public string GetCollectionStatusData()
        {
            return Status.Text;
        }

    }
}
