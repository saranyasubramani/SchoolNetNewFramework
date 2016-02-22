using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.TestWindow.PlanHome
{
    /// <summary>
    /// represents the plan home - search results grid row.
    /// </summary>
    public class PlanHomeRow : SNGridRow
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="columns">the list of columns</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public PlanHomeRow(string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base(gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
            //ctl00_MainContent_TestWindowSearchResults1_TestWindowFinderResults1_gridResults
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Row text: " + Element.Text);
            TestWindowName = new WebElementWrapper(ByTestWindowName);
            Subject = new WebElementWrapper(BySubject);
            Grade = new WebElementWrapper(ByGrade);
            TestStage = new WebElementWrapper(ByTestStage);
            StartDate = new WebElementWrapper(ByStartDate);
            EndDate = new WebElementWrapper(ByEndDate);
            LinkTest = new WebElementWrapper(ByLinkTest);
            CreateTest = new WebElementWrapper(ByCreateTest);
            Select = new WebElementWrapper(BySelect);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private By ByTestWindowName { get { return GetColumnLocator(PlanHomeColumnNames.TestWindowName); } }
        private WebElementWrapper TestWindowName { get; set; }
        private By BySubject { get { return GetColumnLocator(PlanHomeColumnNames.Subject); } }
        private WebElementWrapper Subject { get; set; }
        private By ByGrade { get { return GetColumnLocator(PlanHomeColumnNames.Grade); } }
        private WebElementWrapper Grade { get; set; }
        private By ByTestStage { get { return GetColumnLocator(PlanHomeColumnNames.TestStage); } }
        private WebElementWrapper TestStage { get; set; }
        private By ByStartDate { get { return GetColumnLocator(PlanHomeColumnNames.StartDate); } }
        private WebElementWrapper StartDate { get; set; }
        private By ByEndDate { get { return GetColumnLocator(PlanHomeColumnNames.EndDate); } }
        private WebElementWrapper EndDate { get; set; }
        //ctl00_MainContent_TestWindowSearchResults1_TestWindowFinderResults1_gridResults_ctl03_ButtonLink
        private By ByLinkTest { get { return By.Id(ControlPrefix + "TestWindowSearchResults1_TestWindowFinderResults1_gridResults_" + GetRowControlId() + "_ButtonLink"); } }
        private WebElementWrapper LinkTest { get; set; }
        //ctl00_MainContent_TestWindowSearchResults1_TestWindowFinderResults1_gridResults_ctl03_ButtonCreateTest
        private By ByCreateTest { get { return By.Id(ControlPrefix + "TestWindowSearchResults1_TestWindowFinderResults1_gridResults_" + GetRowControlId() + "_ButtonCreateTest"); } }
        private WebElementWrapper CreateTest { get; set; }
        //ctl00_MainContent_TestSearchResults1_TestFinderResults1_gridResults_ctl03_ButtonSelect
        private By BySelect { get { return By.Id(ControlPrefix + "TestSearchResults1_TestFinderResults1_gridResults_" + GetRowControlId() + "_ButtonSelect"); } }
        private WebElementWrapper Select { get; set; }

        private string GetRowControlId()
        {
            string controlId = "";
            int rowIndex = Index;
            rowIndex++;
            if (rowIndex >= 0 && rowIndex <= 9)
                controlId = "ctl0" + rowIndex;
            if (rowIndex >= 10 && rowIndex <= 99)
                controlId = "ctl" + rowIndex;

            return controlId;
        }

        /// <summary>
        /// get the test window name text
        /// </summary>
        /// <returns>text</returns>
        public string GetTestWindowName()
        {
            TestWindowName.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                TestWindowName.Text = FakeText;
            }
            return TestWindowName.Text;
        }
        /// <summary>
        /// get the subject text
        /// </summary>
        /// <returns>text</returns>
        public string GetSubject()
        {
            Subject.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                Subject.Text = FakeText;
            }
            return Subject.Text;
        }
        /// <summary>
        /// get the grade text
        /// </summary>
        /// <returns>text</returns>
        public string GetGrade()
        {
            Grade.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                Grade.Text = FakeText;
            }
            return Grade.Text;
        }
        /// <summary>
        /// get the test stage text
        /// </summary>
        /// <returns>text</returns>
        public string GetTestStage()
        {
            TestStage.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                TestStage.Text = FakeText;
            }
            return TestStage.Text;
        }
        /// <summary>
        /// get the start date text
        /// </summary>
        /// <returns>text</returns>
        public string GetStartDate()
        {
            StartDate.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                StartDate.Text = FakeText;
            }
            return StartDate.Text;
        }
        /// <summary>
        /// get the end date text
        /// </summary>
        /// <returns>text</returns>
        public string GetEndDate()
        {
            EndDate.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                EndDate.Text = FakeText;
            }
            return EndDate.Text;
        }

        /// <summary>
        /// click on link test icon
        /// </summary>
        /// <returns></returns>
        public void SelectLinkTest()
        {
            LinkTest.Wait(2).Click();
        }
        /// <summary>
        /// click on create test icon
        /// </summary>
        /// <returns></returns>
        public void SelectCreateTest()
        {
            CreateTest.Wait(2).Click();
        }
        /// <summary>
        /// click on select link
        /// </summary>
        /// <returns></returns>
        public void SelectTest()
        {
            Select.Wait(2).Click();
        }
    }
}
