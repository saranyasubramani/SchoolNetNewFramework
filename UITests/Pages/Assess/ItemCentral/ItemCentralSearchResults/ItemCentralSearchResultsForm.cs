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
using UITests.Pages.Assess.ItemCentral.ItemCentral;

namespace UITests.Pages.Assess.ItemCentral.ItemCentralSearchResults
{
    /// <summary>
    /// the item central - search results form
    /// </summary>
    public class ItemCentralSearchResultsForm : ItemCentralForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="itemCentralType">item central type</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ItemCentralSearchResultsForm(ItemCentralType itemCentralType, string overrideControlPrefix = null)
            : base(itemCentralType, overrideControlPrefix)
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            InitElements();
        }

        public override void InitElements()
        {
            switch (ItemCentralType)
            {
                case ItemCentralType.Item:
                    //ctl00_MainContent_ItemFinder1_ItemFinderResults1_btnAddToTest1
                    //ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults
                    ControlMiddle = "ItemFinderResults1_";
                    break;
                case ItemCentralType.Passage:
                    //ctl00_MainContent_ItemFinder1_PassageFinderResults1_btnAddToTest1
                    //ctl00_MainContent_ItemFinder1_PassageFinderResults1_gridResults
                    ControlMiddle = "PassageFinderResults1_";
                    break;
                case ItemCentralType.Rubric:
                    //ctl00_MainContent_ItemFinder1_PassageFinderResults1_btnAddToTest1
                    //ctl00_MainContent_RubricFinder1_RubricFinderResults1_gridResults
                    ControlMiddle = "RubricFinderResults1_";
                    break;
            }
            ExportButton = new WebElementWrapper(ByExportButton);
            ExportSelectedItemsTopLink = new WebElementWrapper(ByExportSelectedItemsTopLink);
            ExportSelectedItemsBottomLink = new WebElementWrapper(ByExportSelectedItemsBottomLink);
            ExportAllSearchResultItemsTopLink = new WebElementWrapper(ByExportAllSearchResultItemsTopLink);
            ExportAllSearchResultItemsBottomLink = new WebElementWrapper(ByExportAllSearchResultItemsBottomLink);
            RequestApprovalSelectedItemsStateUseTopLink = new WebElementWrapper(ByRequestApprovalSelectedItemsStateUseTopLink);
            RequestApprovalSelectedItemsStateUseBottomLink = new WebElementWrapper(ByRequestApprovalSelectedItemsStateUseBottomLink);
            RequestApprovalAllSearchResultItemsStateUseTopLink = new WebElementWrapper(ByRequestApprovalAllSearchResultItemsStateUseTopLink);
            RequestApprovalAllSearchResultItemsStateUseBottomLink = new WebElementWrapper(ByRequestApprovalAllSearchResultItemsStateUseBottomLink);
            SelectAllLink = new WebElementWrapper(BySelectAllLink);
            ClearLink = new WebElementWrapper(ByClearLink);
            AddItemsToTestTopLink = new WebElementWrapper(ByAddItemsToTestTopLink);
            AddItemsToTestBottomLink = new WebElementWrapper(ByAddItemsToTestBottomLink);
            SearchResultsGrid = new WebElementWrapper(BySearchResultsGrid);
            SearchResultsRows = new WebElementWrapper(BySearchResultsRows);
            NoItemsFoundLabel = new WebElementWrapper(ByNoItemsFoundLabel);
            PreviousPage = new WebElementWrapper(ByPreviousPage);
            NextPage = new WebElementWrapper(ByNextPage);
            LastPage = new WebElementWrapper(ByLastPage);
            PageResultLabel = new WebElementWrapper(ByPageResultLabel);
            ResultPerPage = new SelectElementWrapper(new WebElementWrapper(ByResultPerPage));
            SortBy = new SelectElementWrapper(new WebElementWrapper(BySortBy));
            //generates a list on page load
            SetItemCentralResultList();
        }

        /// <summary>
        /// the data
        /// </summary>
        public ItemCentralSearchResultsData Data
        {
            get
            {
                return (ItemCentralSearchResultsData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// fake text
        /// </summary>
        public string FakeText;
        private string ControlMiddle = "";
        /// <summary>
        /// the submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ItemFinder1_" + ControlMiddle + "btnAddToTest"); } }
        //ctl00_MainContent_ItemFinder1_ItemFinderResults1_ddlSort
        //ctl00_MainContent_ItemFinder1_PassageFinderResults1_ddlSort
        private By BySortBy { get { return By.Id(ControlPrefix + "ItemFinder1_" + ControlMiddle + "ddlSort"); } }
        private SelectElementWrapper SortBy { get; set; }
        private By BySelectAllLink { get { return By.CssSelector(".btn-link.select-all"); } }
        private WebElementWrapper SelectAllLink { get; set; }
        private By ByClearLink { get { return By.CssSelector(".btn-link.clear-all"); } }
        private WebElementWrapper ClearLink { get; set; }
        private By ByAddItemsToTestTopLink { get { return By.Id(ControlPrefix + "ItemFinder1_" + ControlMiddle + "btnAddToTest1"); } }
        private WebElementWrapper AddItemsToTestTopLink { get; set; }
        private By ByAddItemsToTestBottomLink { get { return By.Id(ControlPrefix + "ItemFinder1_" + ControlMiddle + "btnAddToTest"); } }
        private WebElementWrapper AddItemsToTestBottomLink { get; set; }
        private By ByExportButton { get { return By.CssSelector(".export.dropdown-toggle"); } }
        private WebElementWrapper ExportButton { get; set; }
        private By ByExportSelectedItemsTopLink { get { return By.Id(ControlPrefix + "ItemFinder1_ItemFinderResults1_btnExportSelected1"); } }
        private WebElementWrapper ExportSelectedItemsTopLink { get; set; }
        private By ByExportSelectedItemsBottomLink { get { return By.Id(ControlPrefix + "ItemFinder1_ItemFinderResults1_btnExportSelected"); } }
        private WebElementWrapper ExportSelectedItemsBottomLink { get; set; }
        private By ByExportAllSearchResultItemsTopLink { get { return By.Id(ControlPrefix + "ItemFinder1_ItemFinderResults1_btnExportAll2"); } }
        private WebElementWrapper ExportAllSearchResultItemsTopLink { get; set; }
        private By ByExportAllSearchResultItemsBottomLink { get { return By.Id(ControlPrefix + "ItemFinder1_ItemFinderResults1_btnExportAll"); } }
        private WebElementWrapper ExportAllSearchResultItemsBottomLink { get; set; }
        private By ByRequestApprovalSelectedItemsStateUseTopLink { get { return By.Id(ControlPrefix + "ItemFinder1_ItemFinderResults1_btnSubmitToStateSelected1"); } }
        private WebElementWrapper RequestApprovalSelectedItemsStateUseTopLink { get; set; }
        private By ByRequestApprovalSelectedItemsStateUseBottomLink { get { return By.Id(ControlPrefix + "ItemFinder1_ItemFinderResults1_LinkButton1"); } }
        private WebElementWrapper RequestApprovalSelectedItemsStateUseBottomLink { get; set; }
        private By ByRequestApprovalAllSearchResultItemsStateUseTopLink { get { return By.Id(ControlPrefix + "ItemFinder1_ItemFinderResults1_btnSubmitToStateAll1"); } }
        private WebElementWrapper RequestApprovalAllSearchResultItemsStateUseTopLink { get; set; }
        private By ByRequestApprovalAllSearchResultItemsStateUseBottomLink { get { return By.Id(ControlPrefix + "ItemFinder1_ItemFinderResults1_LinkButton2"); } }
        private WebElementWrapper RequestApprovalAllSearchResultItemsStateUseBottomLink { get; set; }
        //private By BySearchResultsGrid { get { return By.Id(ControlPrefix + "ItemFinder1_" + ControlMiddle + "gridResults"); } }
        //private By BySearchResultsGrid { get { return By.Id("ctl00_MainContent_RubricFinder1_RubricFinderResults1_gridResults"); } }
        private By BySearchResultsGrid { get { return BySearchResultsGridLocator(); } }
        private WebElementWrapper SearchResultsGrid { get; set; }
        //#ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults > tbody > tr:nth-of-type(1) > td > div > table > tbody > tr > td:nth-of-type(2) a
        private By ByPreviousPage { get { return By.CssSelector("#ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults > tbody > tr:nth-of-type(1) > td > div > table > tbody > tr > td:nth-of-type(2) a"); } }
        private WebElementWrapper PreviousPage { get; set; }
        private By ByNextPage { get { return By.CssSelector("tr.DataGridPager > td > div > table > tbody> tr > td:nth-of-type(3) a"); } }
        private WebElementWrapper NextPage { get; set; }
        private By ByLastPage { get { return By.CssSelector("tr.DataGridPager > td > div > table > tbody> tr > td:nth-of-type(4) a"); } }
        private WebElementWrapper LastPage { get; set; }
        //private By ByPageResultLabel { get { return By.CssSelector("#ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults > tbody > tr:nth-of-type(1) > td:nth-of-type(1) > div:nth-of-type(2)"); } }
        private By ByPageResultLabel { get { return By.CssSelector("#" + ControlPrefix + "ItemFinder1_" + ControlMiddle + "gridResults > tbody > tr:nth-of-type(1) > td:nth-of-type(1) > div:nth-of-type(2)"); } }
        private WebElementWrapper PageResultLabel { get; set; }
        private By ByResultPerPage { get { return By.CssSelector("select[id$='ddlResultsPerPage']"); } }
        private SelectElementWrapper ResultPerPage { get; set; }
        //private By BySearchResultsRows { get { return By.CssSelector("tr.DataGridAltRow span.checkbox.inline.item, tr.DataGridRow span.checkbox.inline.item"); } }
        //private By BySearchResultsRows { get { return By.CssSelector("tr.DataGridAltRow, tr.DataGridRow"); } }
        private By BySearchResultsRows { get { return BySearchResultsRowsLocator(); } }
        private WebElementWrapper SearchResultsRows { get; set; }
        private WebElementWrapper ItemCheck { get; set; }
        private ReadOnlyCollection<IWebElement> ItemCentralResultsWebElementList { get; set; }
        private List<ItemCentralLineItem> ItemCentralResultsList { get; set; }
        private By ByNoItemsFoundLabel { get { return By.CssSelector(".Warning > td"); } }
        private WebElementWrapper NoItemsFoundLabel { get; set; }

        private string GetUniqueId(WebElementWrapper webElement, By by)
        {
            string id = webElement.GetAttribute("id");
            Report.Write("Got the attribute: 'id' = '" + id + "' of this element by: '" + by.ToString() + "'.");
            int from = id.IndexOf("_ctl") + "_ctl".Length;
            int to = id.LastIndexOf("_");
            string index = id.Substring(from, to - from);
            string uniqueId = "ctl" + index;
            return uniqueId;
        }

        private By ByCheckItemLocator(int id)
        {
            string idattribute = null;
            switch (ItemCentralType)
            {
                case ItemCentralType.Item:
                    //itemid, test_item_id
                    idattribute = "itemid";
                    break;
                case ItemCentralType.Passage:
                    //passageid, test_passage_id
                    idattribute = "passageid";
                    break;
            }
            return By.CssSelector("span[" + idattribute + "='" + id + "'] > input");
        }

        private By BySearchResultsGridLocator()
        {
            By locator = null;
            switch (ItemCentralType)
            {
                case ItemCentralType.Item:
                    locator = By.Id(ControlPrefix + "ItemFinder1_" + ControlMiddle + "gridResults");
                    break;
                case ItemCentralType.Passage:
                    locator = By.Id(ControlPrefix + "ItemFinder1_" + ControlMiddle + "gridResults");
                    break;
                case ItemCentralType.Rubric:
                    locator = By.Id(ControlPrefix + "RubricFinder1_" + ControlMiddle + "gridResults");
                    break;
            }
            return locator;
        }

        private By BySearchResultsRowsLocator()
        {
            By locator = null;
            switch (ItemCentralType)
            {
                case ItemCentralType.Item:
                    locator = By.CssSelector("tr.DataGridAltRow span.checkbox.inline.item, tr.DataGridRow span.checkbox.inline.item");
                    break;
                case ItemCentralType.Passage:
                    locator = By.CssSelector("tr.DataGridAltRow span.checkbox.inline.item, tr.DataGridRow span.checkbox.inline.item");
                    break;
                case ItemCentralType.Rubric:
                    locator = By.CssSelector("tr.DataGridAltRow, tr.DataGridRow");
                    break;
            }
            return locator;
        }


        private void SetItemCentralResultList()
        {
            ItemCentralResultsList = new List<ItemCentralLineItem>();
            SearchResultsGrid.Wait(3);
            ItemCentralResultsWebElementList = SearchResultsRows.WaitForElements(5);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy1 = new DummyWebElement();
                dummy1.FakeAttributeItemid = "231270";
                dummy1.FakeAttributePassageid = "35605";
                DummyWebElement dummy2 = new DummyWebElement();
                dummy2.FakeAttributeItemid = "231271";
                dummy2.FakeAttributePassageid = "35606";
                DummyWebElement dummy3 = new DummyWebElement();
                dummy3.FakeAttributeItemid = "231272";
                dummy3.FakeAttributePassageid = "35607";
                DummyWebElement dummy4 = new DummyWebElement();
                dummy4.FakeAttributeItemid = "231273";
                dummy4.FakeAttributePassageid = "35608";
                DummyWebElement dummy5 = new DummyWebElement();
                dummy5.FakeAttributeItemid = "231274";
                dummy5.FakeAttributePassageid = "35609";
                DummyWebElement dummy6 = new DummyWebElement();
                dummy6.FakeAttributeItemid = "231275";
                dummy6.FakeAttributePassageid = "35610";
                DummyWebElement dummy7 = new DummyWebElement();
                dummy7.FakeAttributeItemid = "231276";
                dummy7.FakeAttributePassageid = "35611";
                DummyWebElement dummy8 = new DummyWebElement();
                dummy8.FakeAttributeItemid = "231277";
                dummy8.FakeAttributePassageid = "35612";
                DummyWebElement dummy9 = new DummyWebElement();
                dummy9.FakeAttributeItemid = "231278";
                dummy9.FakeAttributePassageid = "35613";
                DummyWebElement dummy10 = new DummyWebElement();
                dummy10.FakeAttributeItemid = "231279";
                dummy10.FakeAttributePassageid = "35614";

                List<IWebElement> list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4, dummy5, dummy6, dummy7, dummy8, dummy9, dummy10 };
                ItemCentralResultsWebElementList = new ReadOnlyCollection<IWebElement>(list);
            }

            int index = 0;
            foreach (var webElement in ItemCentralResultsWebElementList)
            {
                int itemid = -1;
                int passageid = -1;
                string uniqueId = null;
                switch (ItemCentralType)
                {
                    case ItemCentralType.Item:
                        itemid = int.Parse(webElement.GetAttribute("itemid"));
                        ItemCheck = new WebElementWrapper(ByCheckItemLocator(itemid));
                        //ctl00_MainContent_ItemFinder1_ItemFinderResults1_gridResults_ctl03_chkItem
                        ItemCheck.FakeAttributeId = "ctl00_MainContent_ItemFinder1_" + ControlMiddle + "gridResults_ctl03_chkItem";
                        uniqueId = GetUniqueId(ItemCheck, ByCheckItemLocator(itemid));
                        break;
                    case ItemCentralType.Passage:
                        itemid = int.Parse(webElement.GetAttribute("passageid"));
                        ItemCheck = new WebElementWrapper(ByCheckItemLocator(itemid));
                        //ctl00_MainContent_ItemFinder1_PassageFinderResults1_gridResults_ctl03_chkPassage
                        ItemCheck.FakeAttributeId = "ctl00_MainContent_ItemFinder1_" + ControlMiddle + "gridResults_ctl03_chkItem";
                        uniqueId = GetUniqueId(ItemCheck, ByCheckItemLocator(itemid));
                        break;
                    case ItemCentralType.Rubric:
                        By ByAlink = By.CssSelector("a[id*='ButtonDetails']");
                        WebElementWrapper aLinkElement = new WebElementWrapper(ByAlink);
                        if (Driver.GetType() == typeof(DummyDriver))
                        {
                            aLinkElement.FakeAttributeRubricid = "8560";
                            //ctl00_MainContent_RubricFinder1_RubricFinderResults1_gridResults_ctl03_ButtonDetails
                            aLinkElement.FakeAttributeId = "ctl00_MainContent_RubricFinder1_" + ControlMiddle + "gridResults_ctl03_ButtonDetails";
                        }
                        itemid = int.Parse(aLinkElement.GetAttribute("rubric_id"));
                        uniqueId = GetUniqueId(aLinkElement, SearchResultsRows.By);
                        break;
                }
                Report.Write("ItemCentralLineItem by itemid: '" + itemid + "'; passageid: '{" + passageid + "'; index: '" + index + "'; uniqueId: '" + uniqueId);
                var lineItem = new ItemCentralLineItem(webElement, ItemCentralType, itemid, index, uniqueId);
                ItemCentralResultsList.Add(lineItem);
                index++;
            }
        }

        /// <summary>
        /// get the item central result list
        /// </summary>
        /// <returns>List of ItemCentralLineItem</returns>
        public List<ItemCentralLineItem> GetResultsList()
        {
            return ItemCentralResultsList;
        }

        /// <summary>
        /// gets an item from the item central results list
        /// </summary>
        /// <param name="index">the index of the item</param>
        /// <returns>ItemCentralLineItem</returns>
        public ItemCentralLineItem GetItemFromResultsList(int index)
        {
            if (ItemCentralResultsList.Count == 0)
            {
                Assert.Fail("No items were found in the results list.");
                return null;
            }
            else
            {
                return ItemCentralResultsList[index];
            }
        }

        /// <summary>
        /// verify No items found.  Please refine your query and try again.
        /// </summary>
        public void VerifyNoItemsFoundInResultsList()
        {
            Report.Write("Verifying the expected content is within the actual content.");
            string expected = "No items found.  Please refine your query and try again.";
            NoItemsFoundLabel.Wait(3);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                NoItemsFoundLabel.Text = expected;
            }
            string actual = NoItemsFoundLabel.Text;
            Assert.IsTrue(actual.Trim().Contains(expected), "The expected content: '" + expected + "' was not found within the actual content: '" + actual + "'.");
            Report.Write("Verified the expected content: '" + expected + "' was found within the actual content: '" + actual + "'.");
        }

        /// <summary>
        /// verify the item content in the results list by the index
        /// </summary>
        /// <param name="index">the item index</param>
        /// <param name="contents">the content</param>
        public void VerifyItemInResultsListByIndex(int index, List<string> contents)
        {
            Report.Write("Verifying the expected content is within the actual content.");
            var itemCentralLineItem = ItemCentralResultsList[index];
            string actual = null;
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                actual = "";
                foreach (var content in contents)
                {
                    actual = actual + " " + content;
                }
                //actual = "<p>This morning, I went to the <u> 1 - (A) blue  (B) purple  (C) yellow  <b>(D) orange</b>  </u>and bought some milk and eggs. I knew it was going to rain, but I forgot my <u> 2 - (A) blue  <b>(C) purple</b>  </u>and ended up getting <u> 3 - (A) blue  (B) purple  <b>(C) yellow</b>  </u>on the way.</p>";
            }
            else
            {
                actual = itemCentralLineItem.GetItemContentText();
            }
            foreach (var content in contents)
            {
                Assert.IsTrue(actual.Contains(content), "The expected content: '" + content + "' was not found within the actual content: '" + actual + "'.");
                Report.Write("Verified the expected content: '" + content + "' was found within the actual content: '" + actual + "'.");
            }
        }

        /// <summary>
        /// verify the item content in the results list by the ID
        /// </summary>
        /// <param name="itemId">the item ID</param>
        /// <param name="contents">the content</param>
        public void VerifyItemInResultsListById(int itemId, List<string> contents)
        {
            Report.Write("Verifying the expected content is within the actual content.");
            ItemCentralLineItem itemCentralLineItem = null;
            foreach (var item in ItemCentralResultsList)
            {
                if (item.ItemId == itemId)
                {
                    itemCentralLineItem = item;
                }
            }
            if (itemCentralLineItem != null)
            {
                string actual = null;
                if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                {
                    actual =
                        "<p>This morning, I went to the <u> 1 - (A) blue  (B) purple  (C) yellow  <b>(D) orange</b>  </u>and bought some milk and eggs. I knew it was going to rain, but I forgot my <u> 2 - (A) blue  <b>(C) purple</b>  </u>and ended up getting <u> 3 - (A) blue  (B) purple  <b>(C) yellow</b>  </u>on the way.</p>";
                }
                else
                {
                    actual = itemCentralLineItem.GetItemContentText();
                }
                foreach (var content in contents)
                {
                    Assert.IsTrue(actual.Contains(content),
                        "The expected content: '" + content + "' was not found within the actual content: '" + actual +
                        "'.");
                    Report.Write("Verified the expected content: '" + content +
                                    "' was found within the actual content: '" + actual + "'.");
                }
            }
            else
            {
                Assert.Fail("Could not find the Item ID: '" + itemId + "' within the Item Central Search Results list.");
            }
        }

        /// <summary>
        /// verify the item is NOT in the results list by the ID
        /// </summary>
        /// <param name="itemId">the item ID</param>
        public void VerifyItemIsNotInResultsListById(int itemId)
        {
            Report.Write("Verifying the Item ID: '" + itemId + "' is not in the Item Central Search Results list.");
            ItemCentralLineItem itemCentralLineItem = null;
            foreach (var item in ItemCentralResultsList)
            {
                if (item.ItemId == itemId)
                {
                    itemCentralLineItem = item;
                }
            }
            if (itemCentralLineItem == null)
            {
                Report.Write("Verified the Item ID: '" + itemId + "' is not in the Item Central Search Results list.");
            }
            else
            {
                Assert.Fail("Did not expect to find the Item ID: '" + itemId + "', but the item is in the Item Central Search Results list.");
            }
        }

        /// <summary>
        /// check the item in the results list by index
        /// </summary>
        /// <param name="index">the item index</param>
        public void SelectItemInResultsListByIndex(int index)
        {
            ItemCentralLineItem itemCentralLineItem = ItemCentralResultsList[index];
            if (itemCentralLineItem != null)
            {
                itemCentralLineItem.CheckOnItem();
            }
            else
            {
                Assert.Fail("Could not find the Index: '" + index + "' within the Item Central Search Results list.");
            }
        }

        /// <summary>
        /// check the item in the results list by ID
        /// </summary>
        /// <param name="itemId">the item ID</param>
        public void SelectItemInResultsListById(int itemId)
        {
            ItemCentralLineItem itemCentralLineItem = null;
            foreach (var item in ItemCentralResultsList)
            {
                if (item.ItemId == itemId)
                {
                    itemCentralLineItem = item;
                }
            }
            if (itemCentralLineItem != null)
            {
                itemCentralLineItem.CheckOnItem();
            }
            else
            {
                Assert.Fail("Could not find the Item ID: '" + itemId + "' within the Item Central Search Results list.");
            }
        }


        /// <summary>
        /// selects all results list item check boxes
        /// </summary>
        public void SelectAll()
        {
            SelectAllLink.Click();
        }

        /// <summary>
        /// add selected items to test
        /// </summary>
        public void AddItemsToTest()
        {
            AddItemsToTestBottomLink.Wait(15).Click();
            //AddItemsToTestBottomLink.Click();
        }

        /// <summary>
        /// export selected items
        /// </summary>
        public void ExportSelectedItems()
        {
            ExportButton.Click();
            ExportSelectedItemsTopLink.WaitUntilVisible(2).Click();
        }

        /// <summary>
        /// export all search result items
        /// </summary>
        public void ExportAllSearchResultItems()
        {
            ExportButton.Click();
            ExportAllSearchResultItemsTopLink.WaitUntilVisible(2).Click();
        }

        /// <summary>
        /// request approval for selected items for state use
        /// </summary>
        public void RequestApprovalSelectedItemsStateUse()
        {
            ExportButton.Click();
            RequestApprovalSelectedItemsStateUseTopLink.WaitUntilVisible(2).Click();
        }

        /// <summary>
        /// request approval for all search result items for state use
        /// </summary>
        public void RequestApprovalAllSearchResultItemsStateUse()
        {
            ExportButton.Click();
            RequestApprovalAllSearchResultItemsStateUseTopLink.WaitUntilVisible(2).Click();
        }

        /// <summary>
        /// next page
        /// </summary>
        public void SelectNextPage()
        {
            NextPage.Click();
        }
        /// <summary>
        /// previous page
        /// </summary>
        public void SelectPreviousPage()
        {
            PreviousPage.Click();
        }
        /// <summary>
        /// last page
        /// </summary>
        public void SelectLastPage()
        {
            LastPage.Click();
        }
        /// <summary>
        /// Get the result label
        /// For example, first page the result is "Results 1 - 25 of 41,631"
        /// </summary>
        public string GetResultLabel()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                return FakeText;
            }
            return PageResultLabel.Text;
        }

        //overriden methods
        /// <summary>
        /// clears the form
        /// </summary>
        public override void ClearForm()
        {
            ClearLink.Click();
        }

        public override void InputFormFields()
        {
            if (Data.ResultPerPage != null)
            {
                ResultPerPage.SelectByText(Data.ResultPerPage);
            }
            if (Data.SortBy != null)
            {
                SortBy.SelectByText(Data.SortBy);
            }
        }
    }
}
