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

namespace UITests.Pages.Assess.TestCentral.TestCentralHome
{
    /// <summary>
    /// the test central home detail
    /// </summary>
    public class TestCentralHomeDetail : SNDetail
    {
        /// <summary>
        /// the test central home detail constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public TestCentralHomeDetail(  string overrideControlPrefix = null)
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
            SearchResultRows = new WebElementWrapper( BySearchResultRows);
            Grid = new TestCentralHomeGrid( GridLocator);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new TestCentralHomeData Data
        {
            get
            {
                return (TestCentralHomeData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        //old grid, try not to used this
        private By BySearchResultRows { get { return By.CssSelector("tr.DataGridAltRow, tr.DataGridRow"); } }
        private WebElementWrapper SearchResultRows { get; set; }
        private List<SearchResultLineItem> SearchResultList { get; set; }
        private ReadOnlyCollection<IWebElement> SearchResultWebElementList { get; set; }
        //new grid
        private string GridLocator { get { return "#" + ControlPrefix + "TestSearchResults1_TestFinderResults1_gridResults"; } }
        public TestCentralHomeGrid Grid { get; set; }

        private void SetSearchResultList()
        {
            SearchResultList = new List<SearchResultLineItem>();
            SearchResultWebElementList = SearchResultRows.WaitForElements(5);
            if (Driver.GetType() == typeof(DummyDriver))
            {
                DummyWebElement dummy1 = new DummyWebElement();
                dummy1.TagName = "tr";
                dummy1.FakeAttributeClass = "DataGridAltRow";
                DummyWebElement dummy2 = new DummyWebElement();
                dummy2.TagName = "tr";
                dummy2.FakeAttributeClass = "DataGridAltRow";
                List<IWebElement> list = new List<IWebElement> { dummy1, dummy2 };
                SearchResultWebElementList = new ReadOnlyCollection<IWebElement>(list);
            }

            int index = 0;

            foreach (var webElement in SearchResultWebElementList)
            {
                Report.Write("Grid Row: " + webElement.Text);
                SearchResultLineItem lineItem = new SearchResultLineItem( index);
                SearchResultList.Add(lineItem);
                index++;
            }
        }

        /// <summary>
        /// gets an test from the search result grid list
        /// </summary>
        /// <param name="index">the index of the test</param>
        /// <returns>A row on the search result grid</returns>
        public SearchResultLineItem GetItemFromSearchResultGrid(int index)
        {
            //Using old grid.
            SetSearchResultList();
            return SearchResultList[index];
        }

        /// <summary>
        /// gets test from the search result grid list
        /// </summary>
        /// <param name="columnName">the name of column</param>
        /// <param name="textToFind">text to find</param>        
        /// <returns>A row on the search result grid</returns>
        public List<TestCentralHomeRow> GetItemFromSearchResultGrid(string columnName, string textToFind)
        {
            Grid.SetGridLists();
            if (Driver.GetType() == typeof(DummyDriver))
            {
                Grid.GetRowFromList(3).FakeText = textToFind;
            }
            return Grid.GetsRowsContainingTextToFindFromList(TestCentralHomeColumnNames.TestName, textToFind);
        }

        /// <summary>
        /// sort the grid descending
        /// </summary>
        /// <param name="columnName">the name of column</param>
        /// <param name="textToFind">text to find</param>        
        /// <returns>A row on the search result grid</returns>
        public void SortColumnDescending(string columnName)
        {
            Grid.SetGridLists();
            if (columnName == TestCentralHomeColumnNames.TestName)
            {
                Grid.SortDescending(TestCentralHomeColumnNames.TestName);
            }
            else if (columnName == TestCentralHomeColumnNames.TestCategory)
            {
                Grid.SortDescending(TestCentralHomeColumnNames.TestCategory);
            }
            else if (columnName == TestCentralHomeColumnNames.Subject)
            {
                Grid.SortDescending(TestCentralHomeColumnNames.Subject);
            }
            else if (columnName == TestCentralHomeColumnNames.GradeLevel)
            {
                Grid.SortDescending(TestCentralHomeColumnNames.GradeLevel);
            }
            else if (columnName == TestCentralHomeColumnNames.TestStage)
            {
                Grid.SortDescending(TestCentralHomeColumnNames.TestStage);
            }
            else if (columnName == TestCentralHomeColumnNames.StartDate)
            {
                Grid.SortDescending(TestCentralHomeColumnNames.StartDate);
            }
            else if (columnName == TestCentralHomeColumnNames.EndDate)
            {
                Grid.SortDescending(TestCentralHomeColumnNames.EndDate);
            }
        }

        /// <summary>
        /// sort the grid ascending
        /// </summary>
        /// <param name="columnName">the name of column</param>
        /// <param name="textToFind">text to find</param>        
        /// <returns>A row on the search result grid</returns>
        public void SortColumnAscending(string columnName)
        {
            Grid.SetGridLists();
            if (columnName == TestCentralHomeColumnNames.TestName)
            {
                Grid.SortAscending(TestCentralHomeColumnNames.TestName);
            }
            else if (columnName == TestCentralHomeColumnNames.TestCategory)
            {
                Grid.SortAscending(TestCentralHomeColumnNames.TestCategory);
            }
            else if (columnName == TestCentralHomeColumnNames.Subject)
            {
                Grid.SortAscending(TestCentralHomeColumnNames.Subject);
            }
            else if (columnName == TestCentralHomeColumnNames.GradeLevel)
            {
                Grid.SortAscending(TestCentralHomeColumnNames.GradeLevel);
            }
            else if (columnName == TestCentralHomeColumnNames.TestStage)
            {
                Grid.SortAscending(TestCentralHomeColumnNames.TestStage);
            }
            else if (columnName == TestCentralHomeColumnNames.StartDate)
            {
                Grid.SortAscending(TestCentralHomeColumnNames.StartDate);
            }
            else if (columnName == TestCentralHomeColumnNames.EndDate)
            {
                Grid.SortAscending(TestCentralHomeColumnNames.EndDate);
            }
        }

        /// <summary>
        /// verify content exists for grid result
        /// </summary>
        /// <param name="fields">list of test central home fields</param>
        public void VerifyContentExistsForGridResult(List<TestCentralHomeFields> fields)
        {
            foreach (var field in fields)
            {
                if (field.Equals(TestCentralHomeFields.ResultTestName))
                {
                    Assert.IsTrue(findTextOnGridResult(Data.TestName),
                        "The expected testname '" + Data.TestName + "' was not found in the actual search result");

                    Report.Write("Found the testname on the search grid: " + Data.TestName);
                }
                if (field.Equals(TestCentralHomeFields.ResultSubject))
                {
                    Assert.IsTrue(findTextOnGridResult(Data.Subject),
                        "The expected subject '" + Data.Subject + "' was not found in the actual search result");

                    Report.Write("Found the subject on the search grid: " + Data.Subject);
                }
                if (field.Equals(TestCentralHomeFields.ResultGradeLevel))
                {
                    Assert.IsTrue(findTextOnGridResult("Gr 1 -Gr 12"),
                        "The expected grade from " + Data.FromGrade + " to " + Data.ToGrade + "was not found in the actual search result");

                    Report.Write("Found the grade range on the search grid. ");
                }
                if (field.Equals(TestCentralHomeFields.ResultTestCategory))
                {
                    Assert.IsTrue(findTextOnGridResult(Data.TestCategory),
                        "The expected test category '" + Data.TestCategory + "' was not found in the actual search result");

                    Report.Write("Found the test category on the search grid: " + Data.TestCategory);
                }
            }
        }

        /// <summary>
        /// verify content does not exist for grid result
        /// </summary>
        /// <param name="textShouldNotExist">text should not exist</param>
        public void VerifyContentDoesNotExistsForGridResult(string textShouldNotExist)
        {
            Assert.IsTrue(!(findTextOnGridResult(textShouldNotExist)),
                        "The text '" + textShouldNotExist + "' should not be found in the actual search result");

            Report.Write("Did not find the text " + textShouldNotExist + " on the search grid.");
        }

        private bool findTextOnGridResult(string expectedText)
        {
            int i = 0;
            SetSearchResultList();
            //SearchResultWebElementList = SearchResultRows.WaitForElements(5);
            //if (Driver.GetType() == typeof(DummyDriver))
            //{
            //    DummyWebElement dummy1 = new DummyWebElement();
            //    dummy1.Text = "TestCase24185, 1461 Mathematics Gr 1 -Gr 12 District Benchmark";
            //    DummyWebElement dummy2 = new DummyWebElement();
            //    dummy2.Text = "TestCase24185, 1461 Mathematics Gr 1 -Gr 12 District Benchmark";

            //    List<IWebElement> list = new List<IWebElement> { dummy1, dummy2 };
            //    SearchResultWebElementList = new ReadOnlyCollection<IWebElement>(list);
            //}

            foreach (var webElement in SearchResultWebElementList)
            {
                Report.Write("Attempted to find the expected text '" + expectedText + "' on the search result");
                Report.Write("The actual search result data for row" + i.ToString() + " is " + webElement.Text);

                if (webElement.Text.Contains(expectedText))
                {
                    return true;
                }
                i++;
            }
            return false;
        }
    }
}
