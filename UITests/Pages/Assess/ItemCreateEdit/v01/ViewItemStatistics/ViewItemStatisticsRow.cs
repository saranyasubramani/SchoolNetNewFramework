using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.ItemCreateEdit.v01.ViewItemStatistics
{
    /// <summary>
    /// represents the ViewItemStatistics Grid Row
    /// </summary>
    public class ViewItemStatisticsRow : SNGridRow
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="type">type of the Row</param>
        /// <param name="columns">the list of columns</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewItemStatisticsRow(string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base(gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
        }

        public override void InitElements()
        {
            Report.Write("Row text: " + Element.Text);
            ItemsText = new WebElementWrapper(ByItemsText);
            ExpandCollapseImage = new WebElementWrapper(ByExpandCollapseImage);
            TitleLink = new WebElementWrapper(ByTitleLink);
            ContentText = new WebElementWrapper(ByContentText);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private By ByItemsText { get { return GetColumnLocator(ViewItemStatisticsColumnNames.Items); } }
        private WebElementWrapper ItemsText { get; set; }
        private By ByExpandCollapseImage { get { return GetColumnImageLocator(ViewItemStatisticsColumnNames.Items); } }
        private WebElementWrapper ExpandCollapseImage { get; set; }
        private By ByTitleLink { get { return this.GetColumnLinkLocator(ViewItemStatisticsColumnNames.Content); } }
        private WebElementWrapper TitleLink { get; set; }
        private By ByContentText { get { return GetColumnLocator(ViewItemStatisticsColumnNames.Content); } }
        private WebElementWrapper ContentText { get; set; }

        /// <summary>
        /// Gets the Items
        /// </summary>
        /// <returns>items</returns>
        public string GetItems()
        {
            ItemsText.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                ItemsText.Text = FakeText;
            }
            return ItemsText.Text.Trim();
        }

        /// <summary>
        /// Select the expand/collapse link
        /// </summary>
        public void SelectExpandCollapseIcon()
        {
            ExpandCollapseImage.Wait(3).Click();
        }

        /// <summary>
        /// Gets the Title
        /// </summary>
        /// <returns>title</returns>
        public string GetTitle()
        {
            TitleLink.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                TitleLink.Text = FakeText;
            }
            return TitleLink.Text.Trim();
        }

        /// <summary>
        /// Select the title link
        /// </summary>
        public void SelectTitle()
        {
            TitleLink.Wait(3).Click();
        }

        /// <summary>
        /// Gets the Content
        /// </summary>
        /// <returns>content</returns>
        public string GetContent()
        {
            ContentText.Wait(2);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                ContentText.Text = FakeText;
            }
            return ContentText.Text.Trim();
        }

        /// <summary>
        /// Sets the Content
        /// </summary>
        /// <param name="name">the content</param>
        public void SetContent(string content)
        {
            ContentText.Wait(2).Clear();
            ContentText.Wait(2).SendKeys(content);
        }
    }
}
