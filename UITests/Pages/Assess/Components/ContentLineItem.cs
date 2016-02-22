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
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Components
{
    /// <summary>
    /// represents the base content line item row.
    /// </summary>
    public class ContentLineItem : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="webElement">IWebElement</param>
        /// <param name="itemid">the item ID</param>
        /// <param name="index">the index</param>
        /// <param name="uniqueId">the unique ID</param>
        /// <param name="label">the label</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ContentLineItem(IWebElement webElement, int itemid, int index, string uniqueId, string label, string overrideControlPrefix = null)
            : base()
        {
            this.Element = webElement;
            //item type is unknown
            //this.ItemType = itemType;
            ItemId = itemid;
            Index = index;
            UniqueId = uniqueId;
            Label = label;

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
            ItemContent = new WebElementWrapper(ByItemContent);
            MoreLessLink = new WebElementWrapper(ByMoreLessLink);
            ActionsLink = new WebElementWrapper(ByActionsLink);
            ViewLink = new WebElementWrapper(ByViewLink);
            EditLink = new WebElementWrapper(ByEditLink);
            DeleteLink = new WebElementWrapper(ByDeleteLink);
            ReplaceLink = new WebElementWrapper(ByReplaceLink);
            RemoveFromTestLink = new WebElementWrapper(ByRemoveFromTestLink);
            TimerOffLink = new WebElementWrapper(ByTimerOffLink);
            CorrectAnswerLabel = new WebElementWrapper(ByCorrectAnswerLabel);
            PointValueLabel = new WebElementWrapper(ByPointValueLabel);
            StandardIdLabel = new WebElementWrapper(ByStandardIdLabel);
            StepsToCompleteLabels = new WebElementWrapper(ByStepsToCompleteLabels);

            expectedRequiredErrorsList = new List<string>()
            {
                "Align to a standard",
                "Add question content for question container 1,2,3",
                "Add content for answer choice A,B,C,D",
                "Select correct answer for question container 1,2,3",
                "Not worth any points"
            };
        }

        private ItemType ItemType { get; set; }
        /// <summary>
        /// IWebElement
        /// </summary>
        public IWebElement Element { get; private set; }
        /// <summary>
        /// the line's item ID
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// the line item's index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// the line item's unique ID
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        /// the line item's label
        /// </summary>
        public string Label { get; private set; }
        /// <summary>
        /// expected required errors list
        /// </summary>
        protected List<string> expectedRequiredErrorsList { get; set; }
        protected virtual By ByItemContent { get { return By.Id("contentDiv_" + ItemId); } }
        protected virtual WebElementWrapper ItemContent { get; set; }
        protected virtual By ByMoreLessLink { get { return By.CssSelector("a[onclick*='ShowHideAll(this, '" + Index + "']"); } }
        protected virtual WebElementWrapper MoreLessLink { get; set; }
        protected virtual By ByActionsLink { get { return By.XPath("//tr[@class='DataGridRow'][" + (Index + 1) + "]/td/div[@class='btn-group']/a[@class='btn dropdown-toggle']"); } }
        protected virtual WebElementWrapper ActionsLink { get; set; }
        protected virtual By ByViewLink { get { return By.Id(ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_ButtonItemDetails"); } }
        protected virtual WebElementWrapper ViewLink { get; set; }
        protected virtual By ByEditLink { get { return By.Id(ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_ButtonEditItem"); } }
        protected virtual WebElementWrapper EditLink { get; set; }
        protected virtual By ByDeleteLink { get { return By.Id(ControlPrefix + "EditTestItemControl_EditTaskItemControl1_ViewTaskItemControl_RepeaterTaskItems_" + UniqueId + "_ButtonDeleteItem"); } }
        protected virtual WebElementWrapper DeleteLink { get; set; }
        protected virtual By ByReplaceLink { get { return By.Id(ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_ButtonReplaceItem"); } }
        protected virtual WebElementWrapper ReplaceLink { get; set; }
        protected virtual By ByRemoveFromTestLink { get { return By.Id(ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_ButtonDeleteItem"); } }
        protected virtual WebElementWrapper RemoveFromTestLink { get; set; }
        protected virtual By ByTimerOffLink { get { return By.Id(ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_ButtonItemDetails"); } }
        protected virtual WebElementWrapper TimerOffLink { get; set; }
        protected virtual By ByCorrectAnswerLabel { get { return By.CssSelector("tr#" + ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_MetadaInfo_Tr1 + tr > td.itemmetadata"); } }
        protected virtual WebElementWrapper CorrectAnswerLabel { get; set; }
        protected virtual By ByPointValueLabel { get { return By.CssSelector("tr#" + ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_MetadaInfo_Tr1 + tr + tr + tr > td.itemmetadata"); } }
        protected virtual WebElementWrapper PointValueLabel { get; set; }
        protected virtual By ByStandardIdLabel { get { return By.CssSelector("tr#" + ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_MetadaInfo_Tr2 + tr > td.itemmetadata"); } }
        protected virtual WebElementWrapper StandardIdLabel { get; set; }
        //protected virtual By ByStepsToCompleteLabels { get { return By.CssSelector("tr#" + ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_MetadaInfo_Tr2 + tr + tr + tr + tr > td > table > tbody > tr > td.itemmetadata"); } }
        //changed for release 16.3
        protected virtual By ByStepsToCompleteLabels { get { return By.CssSelector("tr#" + ControlPrefix + "RepeaterTestItems_" + UniqueId + "_ViewTestItems1_MetadaInfo_Tr2 + tr + tr + tr + tr + tr + tr > td > table > tbody > tr > td.itemmetadata"); } }
        protected virtual WebElementWrapper StepsToCompleteLabels { get; set; }

        protected ReadOnlyCollection<IWebElement> GetDummyStepsToCompleteLabels()
        {
            ReadOnlyCollection<IWebElement> webElements = null;
            List<IWebElement> list = new List<IWebElement>();
            DummyWebElement dummy1 = new DummyWebElement();
            DummyWebElement dummy2 = new DummyWebElement();
            DummyWebElement dummy3 = new DummyWebElement();
            DummyWebElement dummy4 = new DummyWebElement();
            DummyWebElement dummy5 = new DummyWebElement();
            dummy1.Text = expectedRequiredErrorsList[0];
            dummy1.Displayed = true;
            dummy2.Text = expectedRequiredErrorsList[1];
            dummy2.Displayed = true;
            dummy3.Text = expectedRequiredErrorsList[2];
            dummy3.Displayed = true;
            dummy4.Text = expectedRequiredErrorsList[3];
            dummy4.Displayed = true;
            dummy5.Text = expectedRequiredErrorsList[4];
            dummy5.Displayed = true;

            list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4, dummy5 };
            webElements = new ReadOnlyCollection<IWebElement>(list);
            return webElements;
        }

        /// <summary>
        /// get the steps to complete list
        /// </summary>
        /// <returns>list of steps to complete</returns>
        public List<string> GetStepsToCompleteList()
        {
            List<string> actualRequiredErrorsList = new List<string>();
            //get the error message element list
            ReadOnlyCollection<IWebElement> messageElements = StepsToCompleteLabels.WaitForElements(5);

            if (Driver.GetType() == typeof(DummyDriver))
            {
                messageElements = GetDummyStepsToCompleteLabels();
            }

            //for each element in the list
            foreach (var messageElement in messageElements)
            {
                //if the error message element is displayed
                if (messageElement.Displayed)
                {
                    string actualMessage = messageElement.Text;
                    //get the error message text and add it to the actual error message list
                    actualRequiredErrorsList.Add(actualMessage);
                    Report.Write("Actual required message: " + actualMessage);
                }
            }

            return actualRequiredErrorsList;
        }

        /// <summary>
        /// select actions
        /// </summary>
        public void SelectActions()
        {
            ActionsLink.Wait(3).Click();
            //pause the script for a second to let the pop-up display
            System.Threading.Thread.Sleep(1000);
        }
        /// <summary>
        /// select actions, then select view
        /// </summary>
        public void SelectView()
        {
            SelectActions();
            ViewLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
        }
        /// <summary>
        /// select actions, then select edit
        /// </summary>
        public void SelectEdit()
        {
            SelectActions();
            EditLink.Wait(3).Click();
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
        }
        /// <summary>
        /// select actions, then select delete
        /// </summary>
        public void SelectDelete()
        {
            SelectActions();
            DeleteLink.Wait(3).Click();
        }
        /// <summary>
        /// select actions, then select replace
        /// </summary>
        public void SelectReplace()
        {
            SelectActions();
            ReplaceLink.Wait(3).Click();
        }
        /// <summary>
        /// select actions, then select remove from test
        /// </summary>
        public void SelectRemoveFromTest()
        {
            SelectActions();
            RemoveFromTestLink.Wait(3).Click();
        }
        /// <summary>
        /// select actions, then select timer off
        /// </summary>
        public void SelectTimerOff()
        {
            SelectActions();
            TimerOffLink.Wait(3).Click();
        }

        /// <summary>
        /// get the item's text content
        /// </summary>
        /// <returns>text content</returns>
        public string GetItemContentText()
        {
            return ItemContent.Text;
        }

        /// <summary>
        /// get the correnct answer text content
        /// </summary>
        /// <returns>text content</returns>
        public string GetCorrectAnswerText()
        {
            return CorrectAnswerLabel.Text;
        }

        /// <summary>
        /// get the point value text content
        /// </summary>
        /// <returns>text content</returns>
        public string GetPointValueText()
        {
            return PointValueLabel.Text;
        }

        /// <summary>
        /// get the standard ID text content
        /// </summary>
        /// <returns>text content</returns>
        public string GetStandardIdText()
        {
            return StandardIdLabel.Text;
        }
    }
}
