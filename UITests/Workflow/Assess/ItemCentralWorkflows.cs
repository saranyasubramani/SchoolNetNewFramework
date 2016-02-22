using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages;
using UITests.Pages.Components;
using UITests.Pages.Assess;
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.Dashboard;
using UITests.Pages.Assess.ItemCentral;
using UITests.Pages.Assess.ItemCentral.ItemCentral;
using UITests.Pages.Assess.ItemCentral.ItemCentralHome;
using UITests.Pages.Assess.ItemCentral.ItemCentralSearchResults;
using UITests.Pages.Assess.ItemCentral.ItemCentralStandardPicker;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditItemAvailability;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditQuestion;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTask;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTestItem;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;
using UITests.Pages.Assess.ItemCreateEdit.v01.ViewItemStatistics;
using UITests.Pages.Assess.Passage;
using UITests.Pages.Assess.PrintTest;
using UITests.Pages.Assess.Rubric;
using UITests.Pages.Assess.Scantron;
using UITests.Pages.Assess.Schedule;
using UITests.Pages.Assess.Standards;
using UITests.Pages.Assess.TestCentral;
using UITests.Pages.Assess.TestCreateEdit;
using UITests.Pages.Assess.TestCreateEdit.Components;
using UITests.Pages.Assess.TestCreateEdit.CreateTestBySelectingStandards;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestTunnel;
using UITests.Pages.Assess.TestWindow;
using UITests.Pages.Assess.Track;
using UITests.Pages.Home;
using UITests.Workflow;

namespace UITests.Workflow.Assess
{
    /// <summary>
    /// the item central workflows
    /// </summary>
    public class ItemCentralWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public ItemCentralWorkflows( AssessWorkflows workflows)
            : base()
        {
            AssessWorkflows = workflows;
        }

        public ItemCentralType ItemSearchType;

        //workflows
        public AssessWorkflows AssessWorkflows { get; set; }

        /// <summary>
        /// Click on rubric tab and search using text
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows SelectRubricTabAndEnterSearchText(string textToSearch)
        {
            if (AssessWorkflows.ItemCentralHomePage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralHomePage before trying to use this workflow.");
            }
            //AND the user enter search text
            if (AssessWorkflows.ItemCentralHomePage.Data == null)
            {
                AssessWorkflows.ItemCentralHomePage.InitData();
            }
            AssessWorkflows.ItemCentralHomePage.Data.SearchData = textToSearch;
            AssessWorkflows.ItemCentralHomePage.Form.InputFormFields();
            //AND the user click on Rubric Tab
            AssessWorkflows.ItemCentralHomePage.Detail.SelectRubricsTab();
            //AND the user click submit to perform the search
            AssessWorkflows.ItemCentralHomePage.Form.SubmitForm();
            ItemSearchType = ItemCentralType.Rubric;
            return this;
        }

        /// <summary>
        /// Click on search after entering text in the ItemCentral page
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows EnterSearchTextinItemCentral(string textToSearch, bool isPassage)
        {
            if (AssessWorkflows.ItemCentralHomePage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralHomePage before trying to use this workflow.");
            }
            //AND the user enter search text
            if (AssessWorkflows.ItemCentralHomePage.Data == null)
            {
                AssessWorkflows.ItemCentralHomePage.InitData();
            }
            AssessWorkflows.ItemCentralHomePage.Data.SearchData = textToSearch;
            AssessWorkflows.ItemCentralHomePage.Form.InputFormFields();
            //AND the user click submit to perform the search
            AssessWorkflows.ItemCentralHomePage.Form.SubmitForm();

            if (isPassage)
            {
                ItemSearchType = ItemCentralType.Passage;
            }
            else
            {
                ItemSearchType = ItemCentralType.Item;
            }
            return this;
        }

        /// <summary>
        /// Click on passage tab
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows SelectPassageTab()
        {
            if (AssessWorkflows.ItemCentralHomePage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralHomePage before trying to use this workflow.");
            }
            //AND the user click on Passage Tab
            AssessWorkflows.ItemCentralHomePage.Detail.SelectPassagesTab();
            ItemSearchType = ItemCentralType.Passage;
            return this;
        }

        /// <summary>
        /// Enter search fields. By default, it search for item. 
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows ItemCentralHomePageInputAndSubmitForm()
        {
            if (AssessWorkflows.ItemCentralHomePage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralHomePage before trying to use this workflow.");
            }

            //AND the user enter search text
            AssessWorkflows.ItemCentralHomePage.Form.InputAndSubmitForm();

            //Default to item search. If user select passage or rubric, need to add the code to 
            //assigned ItemSearchType.
            if (ItemSearchType == null)
            {
                ItemSearchType = ItemCentralType.Item;
            }

            return this;
        }

        /// <summary>
        /// Click on advance search link 
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows SelectAdvanceSearch()
        {
            if (AssessWorkflows.ItemCentralHomePage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralHomePage before trying to use this workflow.");
            }

            AssessWorkflows.ItemCentralPage = AssessWorkflows.ItemCentralHomePage.Detail.AdvancedSearch();
            return this;
        }

        ///// <summary>
        ///// At ItemCentral.aspx page, select sort by dropdown
        ///// </summary>
        ///// <returns>Workflows</returns>
        //public ItemCentralWorkflows ItemCentralPageInputAndSubmitForm()
        //{
        //    if (AssessWorkflows.ItemCentralPage == null)
        //    {
        //        throw new Exception("Navigate to the AssessWorkflows.ItemCentralPage before trying to use this workflow.");
        //    }

        //    //AND the user use advance search
        //    //AND the user enter fields in the item properties section
        //    AssessWorkflows.ItemCentralPage.Form.InputAndSubmitForm();

        //    return this;
        //}


        /// <summary>
        /// At ItemCentral.aspx, user sort by dropdown
        /// </summary>
        /// <param name="delayInMilliSec"></param>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows ItemCentralPageSelectSortByDropdown()
        {
            if (AssessWorkflows.ItemCentralSearchResultsPage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralSearchResultsPage before trying to use this workflow.");
            }

            //AND the user enter sort by dropdown by putting sortby value in the ItemCentralPage Data object
            AssessWorkflows.ItemCentralSearchResultsPage.Form.InputFormFields();
            try
            {
                AssessWorkflows.ItemCentralSearchResultsPage = new ItemCentralSearchResultsPage( ItemSearchType);
            }
            catch (Exception)
            {
                //retry. sometimes takes longer to return the page. 
                AssessWorkflows.ItemCentralSearchResultsPage = new ItemCentralSearchResultsPage( ItemSearchType);
            }

            return this;
        }
        /// <summary>
        /// At ItemCentral.aspx, user click on next page
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows ItemCentralPageNextPage()
        {
            if (AssessWorkflows.ItemCentralSearchResultsPage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralSearchResultsPage before trying to use this workflow.");
            }

            AssessWorkflows.ItemCentralSearchResultsPage.Form.SelectNextPage();
            AssessWorkflows.ItemCentralSearchResultsPage = new ItemCentralSearchResultsPage( ItemSearchType);

            return this;
        }
        /// <summary>
        /// At ItemCentral.aspx, user click on previous page
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows ItemCentralPagePreviousPage()
        {
            if (AssessWorkflows.ItemCentralSearchResultsPage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralSearchResultsPage before trying to use this workflow.");
            }

            AssessWorkflows.ItemCentralSearchResultsPage.Form.SelectPreviousPage();
            AssessWorkflows.ItemCentralSearchResultsPage = new ItemCentralSearchResultsPage( ItemSearchType);

            return this;
        }
        /// <summary>
        /// At ItemCentral.aspx, user click on last page
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows ItemCentralPageLastPage()
        {
            if (AssessWorkflows.ItemCentralSearchResultsPage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralSearchResultsPage before trying to use this workflow.");
            }

            AssessWorkflows.ItemCentralSearchResultsPage.Form.SelectLastPage();
            AssessWorkflows.ItemCentralSearchResultsPage = new ItemCentralSearchResultsPage( ItemSearchType);

            return this;
        }
        /// <summary>
        /// At ItemCentral.aspx, user select X result per page to display
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows ItemCentralPageResultPerPage()
        {
            if (AssessWorkflows.ItemCentralSearchResultsPage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralSearchResultsPage before trying to use this workflow.");
            }

            AssessWorkflows.ItemCentralSearchResultsPage.Form.InputFormFields();
            try
            {
                AssessWorkflows.ItemCentralSearchResultsPage = new ItemCentralSearchResultsPage( ItemSearchType);
            }
            catch (Exception)
            {
                //retry if slow page response
                AssessWorkflows.ItemCentralSearchResultsPage = new ItemCentralSearchResultsPage( ItemSearchType);
            }

            return this;
        }

        /// <summary>
        /// Advance search, user enter fields in the item properties section
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows ItemCentralPageInputAndSubmitForm_ItemProperties()
        {
            if (AssessWorkflows.ItemCentralPage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralPage before trying to use this workflow.");
            }

            //AND the user use advance search
            //AND the user enter fields in the item properties section
            AssessWorkflows.ItemCentralPage.Form.InputAndSubmitForm();

            return this;
        }

        /// <summary>
        /// Advance search, user enter fields in the passage properties section
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows ItemCentralPageInputAndSubmitForm_PassageProperties()
        {
            if (AssessWorkflows.ItemCentralPage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralPage before trying to use this workflow.");
            }

            //AND the user use advance search
            //AND the user enter fields in the passage properties section
            AssessWorkflows.ItemCentralPage.Form.PassageProperties.InputAndSubmitForm();

            return this;
        }

        /// <summary>
        /// Advance search, user clicks the Search Items button
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows ItemCentralPageSubmitForm()
        {
            if (AssessWorkflows.ItemCentralPage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralPage before trying to use this workflow.");
            }
            AssessWorkflows.ItemCentralSearchResultsPage = (ItemCentralSearchResultsPage)AssessWorkflows.ItemCentralPage.Form.SubmitForm();
            return this;
        }

        /// <summary>
        /// Advance search, user checks the item in the results list by index
        /// </summary>
        /// <param name="index">the item index</param>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows ItemCentralSearchResultsPageSelectItemInResultsListByIndex(int index)
        {
            if (AssessWorkflows.ItemCentralSearchResultsPage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralPage before trying to use this workflow.");
            }
            AssessWorkflows.ItemCentralSearchResultsPage.Form.SelectItemInResultsListByIndex(index);
            return this;
        }

        /// <summary>
        /// Advance search, user checks the item in the results list by ID
        /// </summary>
        /// <param name="itemId">the item ID</param>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows ItemCentralSearchResultsPageSelectItemInResultsListById(int itemId)
        {
            if (AssessWorkflows.ItemCentralSearchResultsPage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralPage before trying to use this workflow.");
            }
            AssessWorkflows.ItemCentralSearchResultsPage.Form.SelectItemInResultsListById(itemId);
            return this;
        }

        /// <summary>
        /// A search had been performed. Click View for the first item of the result list 
        /// For rubric, no View link. Click on the rubric link
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows ItemCentralSearchResultsPageViewFirstItem()
        {
            if (ItemSearchType == null)
            {
                throw new Exception("A search must be performed before trying to use this workflow.");
            }

            AssessWorkflows.ItemCentralSearchResultsPage = new ItemCentralSearchResultsPage( ItemSearchType);
            AssessWorkflows.ItemCentralSearchResultsPage.Form.GetItemFromResultsList(0).SelectView();

            if (ItemSearchType == ItemCentralType.Passage)
            {
                AssessWorkflows.PassageDetailPage = new PassageDetailPage();
            }
            if (ItemSearchType == ItemCentralType.Item)
            {
                AssessWorkflows.ViewItemStatisticsPage = new ViewItemStatisticsPage();
            }
            return this;
        }

        /// <summary>
        /// A search had been performed. Click Edit for the first item of the result list 
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows ItemCentralSearchResultsPageEditFirstItem()
        {
            if (ItemSearchType == null)
            {
                throw new Exception("A search must be performed before trying to use this workflow.");
            }

            AssessWorkflows.ItemCentralSearchResultsPage = new ItemCentralSearchResultsPage(ItemSearchType);
            AssessWorkflows.ItemCentralSearchResultsPage.Form.GetItemFromResultsList(0).SelectEdit();
            return this;
        }

        /// <summary>
        /// Advance search, user adds selected items to test
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows ItemCentralSearchResultsPageAddItemsToViewTestDetailsPage()
        {
            if (AssessWorkflows.ItemCentralSearchResultsPage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ItemCentralPage before trying to use this workflow.");
            }
            AssessWorkflows.ItemCentralSearchResultsPage.Form.AddItemsToTest();
            AssessWorkflows.ViewTestDetailsPage = new ViewTestDetailsPage(TestStage.PrivateDraft);
            return this;
        }

        /// <summary>
        /// A rubric search had been performed. Click Delete for the first item of the result list 
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows RubricCentralPageDeleteFirstItem()
        {
            if (ItemSearchType == null)
            {
                throw new Exception("A search must be performed before trying to use this workflow.");
            }

            AssessWorkflows.ItemCentralSearchResultsPage = new ItemCentralSearchResultsPage( ItemSearchType);
            AssessWorkflows.ItemCentralSearchResultsPage.Form.GetItemFromResultsList(0).SelectDelete();

            return this;
        }

        /// <summary>
        /// User had click view a passage to arrive at Passage Detail Page. Now user click delete to delete passage. 
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows PassageDetailPageDeletePassage(bool isItemLinked)
        {
            if (AssessWorkflows.PassageDetailPage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.PassageDetailPage before trying to use this workflow.");
            }

            //ItemCentralSearchResultsPage = new ItemCentralSearchResultsPage(Driver, ItemSearchType);
            //ItemCentralSearchResultsPage.Form.GetItemFromResultsList(0).SelectDelete();

            AssessWorkflows.PassageDetailPage.Detail.ClickDeleteLink(isItemLinked);

            return this;
        }

        /// <summary>
        /// User had click view an item to arrive at View Item Statistics Page. Now user click delete to delete item. 
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows ViewItemStatisticsPageDeleteItem()
        {
            if (AssessWorkflows.ViewItemStatisticsPage == null)
            {
                throw new Exception("Navigate to the AssessWorkflows.ViewItemStatisticsPage before trying to use this workflow.");
            }

            AssessWorkflows.ViewItemStatisticsPage.Detail.DeleteItem();

            return this;
        }

        /// <summary>
        /// Verify result per page label 
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows VerifyResultPerPage(string expectResultLabel)
        {
            if (ItemSearchType == null)
            {
                throw new Exception("A search must be performed before trying to use this workflow.");
            }

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                AssessWorkflows.ItemCentralSearchResultsPage.Form.FakeText = expectResultLabel;
            }
            string actualResultLabel = AssessWorkflows.ItemCentralSearchResultsPage.Form.GetResultLabel();
            Assert.IsTrue(actualResultLabel.Contains(expectResultLabel),
                "The expect result label should be " + expectResultLabel + ". The actual is " + actualResultLabel);

            return this;
        }

        /// <summary>
        /// Verify grade value for an item 
        /// Index start at 0, 1, 2 ... 0 is the first item
        /// </summary>
        /// <returns>Workflows</returns>
        public ItemCentralWorkflows VerifyGradeForAnItem(int index, string expectGrade)
        {
            if (ItemSearchType == null)
            {
                throw new Exception("A search must be performed before trying to use this workflow.");
            }

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                AssessWorkflows.ItemCentralSearchResultsPage.Form.GetItemFromResultsList(index).FakeText = expectGrade;
            }
            string actualGrade = AssessWorkflows.ItemCentralSearchResultsPage.Form.GetItemFromResultsList(index).GetGradeLevel();
            Assert.IsTrue(actualGrade.Contains(expectGrade),
                "The expect grade should be " + expectGrade + ". The actual is " + actualGrade);
            return this;
        }
    }
}
