using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestDetail.ViewTestDetails
{
    /// <summary>
    /// the test details: test actions side bar component
    /// </summary>
    public class TestDetailsStatusStudentCommentsSidebar : TestDetailsSideBar
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TestDetailsStatusStudentCommentsSidebar( )
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            StatusStudentCommentsLink = new WebElementWrapper(ByStatusStudentCommentsLink);
            DataCollectionReportLink = new WebElementWrapper(ByDataCollectionReportLink);
            StudentCommentsLink = new WebElementWrapper(ByStudentCommentsLink);
            StatusStudentCommentsContent = new WebElementWrapper(ByStatusStudentCommentsContent);
        }

        private By ByStatusStudentCommentsLink { get { return By.CssSelector(".well #" + ControlPrefix + "TestInfoSidebar1_PanelDataCollection .AccordianHeader"); } }
        private WebElementWrapper StatusStudentCommentsLink { get; set; }
        private By ByDataCollectionReportLink { get { return By.Id("HyperLinkDataCollectionReport"); } }
        private WebElementWrapper DataCollectionReportLink { get; set; }
        private By ByStudentCommentsLink { get { return By.Id("lnkBtnViewTestQuestionComments"); } }
        private WebElementWrapper StudentCommentsLink { get; set; }
        private By ByStatusStudentCommentsContent { get { return By.CssSelector(".well #" + ControlPrefix + "TestInfoSidebar1_PanelDataCollection .AccordianContent > div > div:nth-of-type(2) > div"); } }
        private WebElementWrapper StatusStudentCommentsContent { get; set; }

        /// <summary>
        /// expand status & student comments
        /// </summary>
        public override void ExpandLink()
        {
            StatusStudentCommentsLink.Wait(2);
            StatusStudentCommentsLink.FakeAttributeClass = "AccordianClosed";
            if (StatusStudentCommentsLink.GetAttribute("class").Trim().ToLower().Contains("accordianclosed"))
            {
                StatusStudentCommentsLink.Click();
                DataCollectionReportLink.Wait(10);
            }
        }

        /// <summary>
        /// collapse status & student comments
        /// </summary>
        public override void CollapseLink()
        {
            StatusStudentCommentsLink.Wait(2);
            StatusStudentCommentsLink.FakeAttributeClass = "AccordianOpen";
            if (StatusStudentCommentsLink.GetAttribute("class").Trim().ToLower().Contains("accordianopen"))
            {
                StatusStudentCommentsLink.Click();
            }
        }

        /// <summary>
        /// Click on data collection report link
        /// </summary>
        public TrackTestStatusPage SelectDataCollectionReport()
        {
            DataCollectionReportLink.Wait(2).Click();
            return new TrackTestStatusPage();
        }

        /// <summary>
        /// Click on student comments link
        /// </summary>
        public void SelectStudentComments()
        {
            StudentCommentsLink.Wait(2).Click();
        }

        /// <summary>
        /// get x of y students data 
        /// get threshold status data
        /// </summary>
        /// <returns>text</returns>
        public string GetStatusStudentCommentsLabelData()
        {
            string text = this.StatusStudentCommentsContent.Wait(2).Text;
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                text = FakeText;
            }
            return text;
        }

    }
}
