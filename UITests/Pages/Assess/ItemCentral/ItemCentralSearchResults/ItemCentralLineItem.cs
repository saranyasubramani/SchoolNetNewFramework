using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;

namespace UITests.Pages.Assess.ItemCentral.ItemCentralSearchResults
{
    /// <summary>
    /// represents the item central - search results line item row.
    /// </summary>
    public class ItemCentralLineItem : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="webElement">IWebElement</param>
        /// <param name="itemid">the item ID</param>
        /// <param name="index">the index</param>
        /// <param name="uniqueId">the unique ID</param>
        public ItemCentralLineItem(IWebElement webElement, ItemCentralType itemCentralType, int itemid, int index, string uniqueId)
            : base()
        {
            Element = webElement;
            ItemCentralType = itemCentralType;
            ItemId = itemid;
            Index = index;
            UniqueId = uniqueId;
            switch (ItemCentralType)
            {
                case ItemCentralType.Item:
                    idattribute = "itemid";
                    testidattribute = "test_item_id";
                    idValue = ItemId;
                    break;
                case ItemCentralType.Passage:
                    idattribute = "passageid";
                    testidattribute = "test_passage_id";
                    idValue = ItemId;
                    break;
                case ItemCentralType.Rubric:
                    idattribute = "";
                    testidattribute = "rubric_id";
                    idValue = ItemId;
                    break;
            }
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Name = new WebElementWrapper(ByName);
            Keyword = new WebElementWrapper(ByKeyword);
            Publisher = new WebElementWrapper(ByPublisher);
            ItemSubjectText = new WebElementWrapper(ByItemSubjectText);
            ItemGradeLevelText = new WebElementWrapper(ByItemGradeLevelText);
            ItemCheck = new WebElementWrapper(ByItemCheck);
            ItemContent = new WebElementWrapper(ByItemContent);
            MoreLessLink = new WebElementWrapper(ByMoreLessLink);
            ViewLink = new WebElementWrapper(ByViewLink);
            EditLink = new WebElementWrapper(ByEditLink);
            ShareLink = new WebElementWrapper(ByShareLink);
            StopShareLink = new WebElementWrapper(ByStopShareLink);
            CopyLink = new WebElementWrapper(ByCopyLink);
            DeleteLink = new WebElementWrapper(ByDeleteLink);
            ItemText = new WebElementWrapper(ByItemText);
            PassageNumberOfItems = new WebElementWrapper(ByPassageNumberOfItems);
            PassageType = new WebElementWrapper(ByPassageType);
            ItemSubjectText = new WebElementWrapper(ByItemSubjectText);
            ItemGradeLevelText = new WebElementWrapper(ByItemGradeLevelText);
            ItemQuestionLanguageText = new WebElementWrapper(ByItemQuestionLanguageText);
            ItemStandardText = new WebElementWrapper(ByItemGradeLevelText);
            ItemEligibleForExportText = new WebElementWrapper(ByItemEligibleForExportText);
            PropertiesLink = new WebElementWrapper(ByPropertiesLink);
            PropertiesText = new WebElementWrapper(ByPropertiesText);
            ItemStatisticsLink = new WebElementWrapper(ByItemStatisticsLink);
            ItemStatisticsText = new WebElementWrapper(ByItemStatisticsText);
            ItemTypeText = new WebElementWrapper(ByItemTypeText);
        }

        /// <summary>
        /// the data
        /// </summary>
        public ItemTypeData Data
        {
            get
            {
                return (ItemTypeData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// the item central type
        /// </summary>
        public ItemCentralType ItemCentralType { get; set; }
        /// <summary>
        /// IWebElement
        /// </summary>
        public IWebElement Element { get; private set; }
        private ItemType ItemType { get; set; }
        private string CurrentWindow;
        /// <summary>
        /// the line's item ID
        /// </summary>
        public int ItemId { get; set; }
        ///// <summary>
        ///// the line's passage ID
        ///// </summary>
        //public int PassageId { get; private set; }
        /// <summary>
        /// the line item's index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// the line item's unique ID
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        /// the item name control Id
        /// </summary>
        public string NameCtl { get; set; }
        /// <summary>
        /// the keyword control Id
        /// </summary>
        public string KeywordCtl { get; set; }
        /// <summary>
        /// the publisher control Id
        /// </summary>
        public string PublisherCtl { get; set; }
        private int idValue { get; set; }
        private string idattribute = "";
        private string testidattribute = "";
        /// <summary>
        /// fake text
        /// </summary>
        public string FakeText { get; set; }
        private By ByItemCheck { get { return By.CssSelector("span.checkbox.inline.item[" + idattribute + "='" + idValue + "'] > input"); } }
        private WebElementWrapper ItemCheck { get; set; }
        //private By ByItemContent { get { return By.Id("contentDiv_" + Index); } }
        //private By ByItemContent { get { return By.CssSelector("tr.DataGridAltRow, tr.DataGridRow"); } }
        private By ByItemContent { get { return ByItemContentLocator(); } }
        private WebElementWrapper ItemContent { get; set; }
        private By ByMoreLessLink { get { return By.CssSelector("a[onclick*='javascript:ShowAll(this, " + Index + ");']"); } }
        private WebElementWrapper MoreLessLink { get; set; }
        private By ByViewLink { get { return By.CssSelector("a[" + testidattribute + "='" + idValue + "'][id*='_ButtonDetails']"); } }
        private WebElementWrapper ViewLink { get; set; }
        private By ByEditLink { get { return By.CssSelector("a[" + testidattribute + "='" + idValue + "'][id*='_ButtonEdit']"); } }
        //private By ByEditLink { get { return ByEditLinkLocator(); } }
        private WebElementWrapper EditLink { get; set; }
        private By ByShareLink { get { return By.CssSelector("a[onclick=confirmShare('" + idValue + "');]"); } }
        private WebElementWrapper ShareLink { get; set; }
        private By ByStopShareLink { get { return By.CssSelector("a[onclick=confirmUnshare('" + idValue + "');]"); } }
        private WebElementWrapper StopShareLink { get; set; }
        private By ByCopyLink { get { return By.CssSelector("a[" + testidattribute + "='" + idValue + "'][id*='_ButtonCopy']"); } }
        private WebElementWrapper CopyLink { get; set; }
        private By ByDeleteLink { get { return By.CssSelector("a[" + testidattribute + "='" + idValue + "'][id*='_ButtonDelete']"); } }
        private WebElementWrapper DeleteLink { get; set; }
        //private By ByItemText { get { return By.CssSelector("#prop_" + Index + " > ul:first-child"); } }
        private By ByItemText { get { return By.CssSelector("#prop_" + Index); } }
        private WebElementWrapper ItemText { get; set; }
        private By ByPassageNumberOfItems { get { return By.CssSelector("#ctl00_MainContent_ItemFinder1_PassageFinderResults1_gridResults > tbody > tr:nth-of-type(" + (Index + 2) + ") > td.last-child > div:nth-of-type(6)"); } }
        private WebElementWrapper PassageNumberOfItems { get; set; }
        private By ByPassageType { get { return By.CssSelector("#ctl00_MainContent_ItemFinder1_PassageFinderResults1_gridResults > tbody > tr:nth-of-type(" + (Index + 2) + ") > td.last-child > div:nth-of-type(6)"); } }
        private WebElementWrapper PassageType { get; set; }
        //private By ByItemSubjectText { get { return By.CssSelector("#prop_" + Index + " #ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults_" + UniqueId + "_lblSubjectData"); } }
        private By ByItemSubjectText { get { return BySubjectLocator(); } }
        private WebElementWrapper ItemSubjectText { get; set; }
        //private By ByItemGradeLevelText { get { return By.CssSelector("#prop_" + Index + " #ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults_" + UniqueId + "_lblGradeData"); } }
        private By ByItemGradeLevelText { get { return ByGradeLocator(); } }
        private WebElementWrapper ItemGradeLevelText { get; set; }
        private By ByItemQuestionLanguageText { get { return By.CssSelector("#prop_" + Index + " #ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults_" + UniqueId + "_lblQuestionData"); } }
        private WebElementWrapper ItemQuestionLanguageText { get; set; }
        private By ByItemStandardText { get { return By.CssSelector("#prop_" + Index + " #ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults_" + UniqueId + "_lblStandardData"); } }
        private WebElementWrapper ItemStandardText { get; set; }
        private By ByItemEligibleForExportText { get { return By.CssSelector("#prop_" + Index + " #ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults_" + UniqueId + "_lblEligigleForExportData"); } }
        private WebElementWrapper ItemEligibleForExportText { get; set; }
        private By ByPropertiesLink { get { return By.Id("linkPropertiesToggle_" + idValue); } }
        private WebElementWrapper PropertiesLink { get; set; }
        private By ByPropertiesText { get { return By.Id("conProperties_" + idValue); } }
        private WebElementWrapper PropertiesText { get; set; }
        private By ByName { get { return By.Id(ControlPrefix + "ItemFinder1_ItemFinderResults1_gridResults_" + UniqueId + "_rptTestItemProperties_" + NameCtl + "_lblPropertiesValue"); } }
        private WebElementWrapper Name { get; set; }
        private By ByKeyword { get { return By.Id(ControlPrefix + "ItemFinder1_ItemFinderResults1_gridResults_" + UniqueId + "_rptTestItemProperties_" + KeywordCtl + "_lblPropertiesValue"); } }
        private WebElementWrapper Keyword { get; set; }
        //private By ByPublisher { get { return By.Id(ControlPrefix + "ItemFinder1_ItemFinderResults1_gridResults_" + UniqueId + "_rptTestItemProperties_" + PublisherCtl +"_lblPropertiesValue"); } }
        private By ByPublisher { get { return ByPublisherLocator(); } }
        private WebElementWrapper Publisher { get; set; }
        //private By ByItemStatisticsLink { get { return By.Id("linkStatsToggle_" + idValue); } }
        private By ByItemStatisticsLink { get { return By.CssSelector("div[headerindex='" + Index + "h']"); } }
        private WebElementWrapper ItemStatisticsLink { get; set; }
        //private By ByItemStatisticsText { get { return By.Id("conStats_" + idValue); } }
        private By ByItemStatisticsText { get { return By.CssSelector("div[contentindex='" + Index + "c'] > div > div:nth-of-type(2)"); } }
        private WebElementWrapper ItemStatisticsText { get; set; }
        private By ByItemTypeText { get { return By.CssSelector("#ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults > tbody > tr:nth-of-type(" + (Index + 2) + ") > td:nth-of-type(2) > div > h4"); } }
        private WebElementWrapper ItemTypeText { get; set; }

        private By ByItemContentLocator()
        {
            By locator = null;
            switch (ItemCentralType)
            {
                case ItemCentralType.Item:
                    locator = By.Id("contentDiv_" + Index);
                    break;
                case ItemCentralType.Passage:
                    locator = By.Id("contentDiv_" + Index);
                    break;
                case ItemCentralType.Rubric:
                    locator = By.CssSelector("tr.DataGridAltRow, tr.DataGridRow");
                    break;
            }
            return locator;
        }

        private By ByEditLinkLocator()
        {
            By locator = null;
            switch (ItemCentralType)
            {
                case ItemCentralType.Item:
                    locator = By.CssSelector("a[href*='" + idValue + "'][href*='EditTestItem']");
                    break;
                case ItemCentralType.Passage:
                    locator = By.CssSelector("a[href*='" + idValue + "'][href*='EditTestItem']");
                    break;
                case ItemCentralType.Rubric:
                    //ctl00_MainContent_RubricFinder1_RubricFinderResults1_gridResults_ctl04_ButtonEdit
                    locator = By.CssSelector("a[" + testidattribute + "='" + idValue + "'][id*='_ButtonEdit']");
                    break;
            }
            return locator;
        }

        private By BySubjectLocator()
        {
            By locator = null;
            switch (ItemCentralType)
            {
                case ItemCentralType.Item:
                    locator = By.CssSelector("#prop_" + Index + " #ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults_" + UniqueId + "_lblSubjectData");
                    break;
                case ItemCentralType.Passage:
                    //locator = By.CssSelector("#ctl00_MainContent_ItemFinder1_PassageFinderResults1_gridResults > tbody > tr:nth-of-type(" + (Index + 2) +") > td.last-child > div:nth-of-type(6) > br:nth-of-type(2)");
                    locator = By.CssSelector("#ctl00_MainContent_ItemFinder1_PassageFinderResults1_gridResults > tbody > tr:nth-of-type(" + (Index + 2) + ") > td.last-child > div:nth-of-type(6)");
                    break;
                case ItemCentralType.Rubric:
                    break;
            }
            return locator;
        }

        private By ByGradeLocator()
        {
            By locator = null;
            switch (ItemCentralType)
            {
                case ItemCentralType.Item:
                    locator = By.CssSelector("#prop_" + Index + " #ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults_" + UniqueId + "_lblGradeData");
                    break;
                case ItemCentralType.Passage:
                    locator = By.CssSelector("#ctl00_MainContent_ItemFinder1_PassageFinderResults1_gridResults > tbody > tr:nth-of-type(" + (Index + 2) + ") > td.last-child > div:nth-of-type(6)");
                    break;
                case ItemCentralType.Rubric:
                    break;
            }
            return locator;
        }

        private By ByPublisherLocator()
        {
            By locator = null;
            switch (ItemCentralType)
            {
                case ItemCentralType.Item:
                    locator = By.Id(ControlPrefix + "ItemFinder1_ItemFinderResults1_gridResults_" + UniqueId + "_rptTestItemProperties_" + PublisherCtl + "_lblPropertiesValue");
                    break;
                case ItemCentralType.Passage:
                    //locator = By.CssSelector("#ctl00_MainContent_ItemFinder1_PassageFinderResults1_gridResults > tbody > tr:nth-of-type(" + (Index + 2)+") > td.last-child > div:nth-of-type(6) > br:nth-of-type(5)");
                    locator = By.CssSelector("#ctl00_MainContent_ItemFinder1_PassageFinderResults1_gridResults > tbody > tr:nth-of-type(" + (Index + 2) + ") > td.last-child > div:nth-of-type(6)");
                    break;
                case ItemCentralType.Rubric:
                    break;
            }
            return locator;
        }

        private void NameKeywordPublisherLocator()
        {
            // the name, keyword and publisher fields sometimes exist and sometimes don't. when all 
            // 3 exists, the id for each is as follows: 
            // name: ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults_ctl03_rptTestItemProperties_ctl00_lblPropertiesValue
            // keyword: ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults_ctl03_rptTestItemProperties_ctl01_lblPropertiesValue
            // publisher: ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults_ctl03_rptTestItemProperties_ctl02_lblPropertiesValue 
            // 
            // if name or keyword doesn't exist, only publisher is there. control id for publisher become "ctl00"
            // publisher: ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults_ctl03_rptTestItemProperties_ctl00_lblPropertiesValue          

            //span[id^='ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults_ctl03'][id$='lblProperties']
            By ByPropLabels =
                By.CssSelector("span[id^='" + ControlPrefix + "ItemFinder1_ItemFinderResults1_gridResults_" +
                                UniqueId + "'][id$='lblProperties']");
            WebElementWrapper PropLabels = new WebElementWrapper(ByPropLabels);

            ReadOnlyCollection<IWebElement> allPropLabels = PropLabels.FindElements();
            int i = 0;
            foreach (var label in allPropLabels)
            {
                if (label.Text == "Name")
                {
                    NameCtl = "ctl0" + Convert.ToString(i);
                    i++;
                }
                if (label.Text == "Keyword")
                {
                    KeywordCtl = "ctl0" + Convert.ToString(i);
                    i++;
                }
                if (label.Text == "Publisher")
                {
                    PublisherCtl = "ctl0" + Convert.ToString(i);
                    i++;
                }
            }
        }

        /// <summary>
        /// check the line item
        /// </summary>
        public void CheckOnItem()
        {
            ItemCheck.Click();
        }

        /// <summary>
        /// click the view link
        /// </summary>
        public void SelectView()
        {
            ViewLink.Click();
            //on passage type, returns /Assess/Items/PassageDetail.aspx
            //on item type, returns /Assess/Items/ViewItemStatistics.aspx
        }

        /// <summary>
        /// click the edit link
        /// </summary>
        public void SelectEdit()
        {
            EditLink.Click();
            //on passage type, returns /Assess/Items/EditPassage.aspx
            //on item type, returns /Assess/Items/EditTestItem.aspx
        }

        /// <summary>
        /// click the copy link
        /// </summary>
        public void SelectCopy()
        {
            CopyLink.Click();
        }

        /// <summary>
        /// click the delete link
        /// </summary>
        public void SelectDelete()
        {
            CurrentWindow = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + CurrentWindow + "'.");

            DeleteLink.Wait(5).Click();
            IAlert alert = Driver.SwitchTo().Alert();
            string expected = "Are you sure you want to delete this rubric?";
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                ((DummyIAlert)alert).Text = expected;
            }
            string actual = alert.Text;
            Report.Write("The alert text: '" + actual + "'.");
            Assert.IsTrue(actual.Contains(expected), "The delete confirmation pop-up does not contain the expected text: '" + expected + "'; actual text: '" + actual + "'.");
            alert.Accept();

            //switch to window
            DriverCommands.WaitToSwitchWindow(CurrentWindow, 5);
            DriverCommands.WaitAndMeasurePageLoadTime(90, 30);
        }

        /// <summary>
        /// get the passage number of items. A passage search had been performed. 
        /// </summary>
        /// <returns>text content</returns>
        public string GetPassageNumberOfItems()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                PassageNumberOfItems.Text = FakeText;
            }
            return PassageNumberOfItems.Text;
        }
        /// <summary>
        /// get the passage type. A passage search had been performed. 
        /// </summary>
        /// <returns>text content</returns>
        public string GetPassageType()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                PassageType.Text = FakeText;
            }
            return PassageType.Text;
        }
        /// <summary>
        /// get the item type. For example, Multiple Choice, Click Stick Click Drop
        /// </summary>
        /// <returns>text content</returns>
        public string GetItemType()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                ItemTypeText.Text = FakeText;
            }
            return ItemTypeText.Text;
        }
        /// <summary>
        /// get the item's text content
        /// </summary>
        /// <returns>text content</returns>
        public string GetItemContentText()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                ItemContent.Text = "EnglishSpanishGermanFrenchChineseLatinItalian";
            }
            return ItemContent.Text;
        }
        /// <summary>
        /// get the subject text
        /// </summary>
        /// <returns>subject text</returns>
        public string GetSubject()
        {
            InitElements();
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                ItemSubjectText.Text = FakeText;
            }
            return ItemSubjectText.Text;
        }
        /// <summary>
        /// get the grade level text
        /// </summary>
        /// <returns>grade level text</returns>
        public string GetGradeLevel()
        {
            InitElements();
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                ItemGradeLevelText.Text = FakeText;
            }
            return ItemGradeLevelText.Text;
        }
        /// <summary>
        /// get the question language text
        /// </summary>
        /// <returns>question language text</returns>
        public string GetQuestionLanguage()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                ItemQuestionLanguageText.Text = FakeText;
            }
            return ItemQuestionLanguageText.Text;
        }
        /// <summary>
        /// get the standard's text
        /// </summary>
        /// <returns>standard text</returns>
        public string GetStandard()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                ItemStandardText.Text = FakeText;
            }
            return ItemStandardText.Text;
        }
        /// <summary>
        /// get the eligible for export text
        /// </summary>
        /// <returns>eligible for export text</returns>
        public string GetEligibleForExport()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                ItemEligibleForExportText.Text = FakeText;
            }
            return ItemEligibleForExportText.Text;
        }

        /// <summary>
        /// expand item statistics
        /// </summary>
        public void ExpandItemStatistics()
        {
            ItemStatisticsLink.Click();
        }
        /// <summary>
        /// get the exposure text
        /// </summary>
        /// <returns>exposure text</returns>
        public string GetExposures()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                ItemStatisticsText.Text = FakeText;
            }
            return ItemStatisticsText.Text;
        }

        /// <summary>
        /// expand properties
        /// </summary>
        public void ExpandProperties()
        {
            PropertiesLink.Click();
            NameKeywordPublisherLocator();
            InitElements();
        }
        /// <summary>
        /// get the item name
        /// </summary>
        /// <returns>item name</returns>
        public string GetName()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                Name.Text = FakeText;
            }
            return Name.Text;
        }
        /// <summary>
        /// get the publisher value
        /// for passage search, the this return "Publisher:abc" 
        /// for item search, to be implement
        /// </summary>
        /// <returns>item name</returns>
        public string GetPublisher()
        {
            InitElements();
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                Publisher.Text = FakeText;
            }

            Regex regex = new Regex("Publisher:(.*)Orientation");
            var match = regex.Match(Publisher.Text);
            string publisherValue = match.Groups[1].ToString();
            return publisherValue;
            //return Publisher.Text;
        }

        //implemented methods

        public bool VerifyFieldsExist(ItemCentralLineItemFields includeFields)
        {
            //if the field exist
            if (includeFields.Equals(ItemCentralLineItemFields.Publisher))
            {
                if (String.IsNullOrEmpty(PublisherCtl) == false)
                {
                    return true;
                }
            }
            //if the field exist
            if (includeFields.Equals(ItemCentralLineItemFields.Keyword))
            {
                if (String.IsNullOrEmpty(KeywordCtl) == false)
                {
                    return true;
                }
            }
            //if the field exist
            if (includeFields.Equals(ItemCentralLineItemFields.Name))
            {
                if (String.IsNullOrEmpty(NameCtl) == false)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
