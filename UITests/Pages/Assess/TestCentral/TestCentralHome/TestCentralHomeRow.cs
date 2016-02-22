using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Tools.WebDriver;
using Core.Views.Grids;

namespace UITests.Pages.Assess.TestCentral.TestCentralHome
{
    /// <summary>
    /// represents the test central home - search results grid row.
    /// </summary>
    public class TestCentralHomeRow : SNGridRow
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="gridCssSelector">the grid CSS Selector</param>
        /// <param name="webElement">IWebElement</param>
        /// <param name="index">the index</param>
        /// <param name="columns">the list of columns</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public TestCentralHomeRow(  string gridCssSelector, IWebElement webElement, int index, GridRowType type, List<SNGridColumn> columns, string overrideControlPrefix = null)
            : base( gridCssSelector, webElement, index, type, columns, overrideControlPrefix)
        {
            //Assign to sections 
            //ctl00_MainContent_GridAvailableSections
            //Assign to individual students
            //ctl00_MainContent_GridAvailableStudents
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Report.Write("Row text: " + Element.Text);
            TestName = new WebElementWrapper( ByTestName);
            TestCategory = new WebElementWrapper( ByTestCategory);
            Subject = new WebElementWrapper( BySubject);
            GradeLevel = new WebElementWrapper( ByGradeLevel);
            TestStage = new WebElementWrapper( ByTestStage);
            StartDate = new WebElementWrapper( ByStartDate);
            EndDate = new WebElementWrapper( ByEndDate);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                //set the fake text for the row
                this.FakeText = this.Element.Text;
            }
        }

        private By ByTestName { get { return GetColumnLinkLocator(TestCentralHomeColumnNames.TestName); } }
        private WebElementWrapper TestName { get; set; }
        private By ByTestCategory { get { return GetColumnLocator(TestCentralHomeColumnNames.TestCategory); } }
        private WebElementWrapper TestCategory { get; set; }
        private By BySubject { get { return GetColumnLocator(TestCentralHomeColumnNames.Subject); } }
        private WebElementWrapper Subject { get; set; }
        private By ByGradeLevel { get { return GetColumnLocator(TestCentralHomeColumnNames.GradeLevel); } }
        private WebElementWrapper GradeLevel { get; set; }
        private By ByTestStage { get { return GetColumnLocator(TestCentralHomeColumnNames.TestStage); } }
        private WebElementWrapper TestStage { get; set; }
        private By ByStartDate { get { return GetColumnLocator(TestCentralHomeColumnNames.StartDate); } }
        private WebElementWrapper StartDate { get; set; }
        private By ByEndDate { get { return GetColumnLocator(TestCentralHomeColumnNames.EndDate); } }
        private WebElementWrapper EndDate { get; set; }

        /// <summary>
        /// click on test name
        /// </summary>
        public void SelectTestName()
        {
            TestName.Click();
        }

        /// <summary>
        /// get the test name
        /// </summary>
        /// <returns>text</returns>
        public string GetTestName()
        {
            //TestName.Wait(2);
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                TestName.Text = FakeText;
            }
            return TestName.Text;
        }
        /// <summary>
        /// get test category
        /// </summary>
        /// <returns>text</returns>
        internal string GetTestCategory()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                TestCategory.Text = FakeText;
            }
            return TestCategory.Text;
        }
        /// <summary>
        /// get subject
        /// </summary>
        /// <returns>text</returns>
        internal string GetSubject()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                Subject.Text = FakeText;
            }
            return Subject.Text;
        }
        /// <summary>
        /// get grade level
        /// </summary>
        /// <returns>text</returns>
        internal string GetGradeLevel()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                GradeLevel.Text = FakeText;
            }
            return GradeLevel.Text;
        }
        /// <summary>
        /// get test stage
        /// </summary>
        /// <returns>text</returns>
        internal string GetTestStage()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                TestStage.Text = FakeText;
            }
            return TestStage.Text;
        }
        /// <summary>
        /// get start date
        /// </summary>
        /// <returns>text</returns>
        internal string GetStartDate()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                StartDate.Text = FakeText;
            }
            return StartDate.Text;
        }
        /// <summary>
        /// get end date
        /// </summary>
        /// <returns>text</returns>
        internal string GetEndDate()
        {
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                EndDate.Text = FakeText;
            }
            return EndDate.Text;
        }
    }
}
