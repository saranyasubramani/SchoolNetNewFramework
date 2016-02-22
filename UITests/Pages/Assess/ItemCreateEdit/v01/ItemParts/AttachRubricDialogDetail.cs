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

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts
{
    /// <summary>
    /// attach rubric dialog detail
    /// </summary>
    public class AttachRubricDialogDetail : SNDetail
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public AttachRubricDialogDetail(string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }
        /// <summary>
        /// intialize elements
        /// </summary>
        public override void InitElements()
        {
            SearchResultsGrid = new WebElementWrapper(BySearchResultsGrid);
            SearchResultsRows = new WebElementWrapper(BySearchResultsRows);
            IFrame = new WebElementWrapper(ByIFrame);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new AttachRubricDialogData Data
        {
            get
            {
                return (AttachRubricDialogData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        List<AttachRubricLineItem> AttachRubricResultsList;
        private ReadOnlyCollection<IWebElement> AttachRubricResultsWebElementList { get; set; }

        private By BySearchResultsGrid { get { return By.Id(ControlPrefix + "GridRubrics"); } }
        private WebElementWrapper SearchResultsGrid { get; set; }
        private By BySearchResultsRows { get { return By.CssSelector("td.last-child > input"); } }
        private WebElementWrapper SearchResultsRows { get; set; }
        private By ByIFrame { get { return By.Id("lightBoxFrame"); } }
        private WebElementWrapper IFrame { get; set; }

        private void WaitForIFrameToDisplay()
        {
            this.Parent.CurrentWindowHandle = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + this.Parent.CurrentWindowHandle + "'.");

            IFrame.WaitUntilExists(5);
            this.DriverCommands.WaitToSwitchFrame(IFrame, 3);
        }

        private string GetUniqueId(string id)
        {
            int from = id.IndexOf("_ctl") + "_ctl".Length;
            int to = id.LastIndexOf("_");
            string index = id.Substring(from, to - from);
            string uniqueId = "ctl" + index;
            return uniqueId;
        }

        private void SetAttachRubricResultList()
        {
            WaitForIFrameToDisplay();

            AttachRubricResultsList = new List<AttachRubricLineItem>();
            SearchResultsGrid.Wait(3);
            AttachRubricResultsWebElementList = SearchResultsRows.WaitForElements(5);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy1 = new DummyWebElement();
                dummy1.FakeAttributeId = "ctl00_MainContent_GridRubrics_ctl03_AddButton";
                dummy1.FakeAttributeRid = "8789";
                DummyWebElement dummy2 = new DummyWebElement();
                dummy2.FakeAttributeId = "ctl00_MainContent_GridRubrics_ctl04_AddButton";
                dummy2.FakeAttributeRid = "8790";

                List<IWebElement> list = new List<IWebElement> { dummy1, dummy2 };
                AttachRubricResultsWebElementList = new ReadOnlyCollection<IWebElement>(list);
            }

            int index = 0;
            foreach (var webElement in AttachRubricResultsWebElementList)
            {
                int itemid = -1;
                string attachButtonId = null;
                string uniqueId = null;

                itemid = int.Parse(webElement.GetAttribute("rid"));
                attachButtonId = webElement.GetAttribute("id");
                Report.Write("Got the attribute: 'id' = '" + attachButtonId + "' of attach button [" + index + "].");
                uniqueId = GetUniqueId(attachButtonId);

                Report.Write("AttachRubricLineItem by itemid: '" + itemid + "'; index: '" + index + "'; uniqueId: '" + uniqueId);
                var lineItem = new AttachRubricLineItem(itemid, index, uniqueId, this.Parent.CurrentWindowHandle);
                AttachRubricResultsList.Add(lineItem);
                index++;
            }
        }

        /// <summary>
        /// get the attach rubric result list
        /// </summary>
        /// <returns>List of AttachRubricLineItem</returns>
        public List<AttachRubricLineItem> GetResultsList()
        {
            SetAttachRubricResultList();
            return AttachRubricResultsList;
        }

        /// <summary>
        /// gets an item from the attach rubric results list
        /// </summary>
        /// <param name="index">the index of the item</param>
        /// <returns>AttachRubricLineItem</returns>
        public AttachRubricLineItem GetItemFromResultsList(int index)
        {
            SetAttachRubricResultList();
            return AttachRubricResultsList[index];
        }
    }
}
