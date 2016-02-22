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
    /// the test details: customize test side bar component
    /// </summary>
    public class TestDetailsCustomizeTestSideBar : TestDetailsSideBar
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public TestDetailsCustomizeTestSideBar( )
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            TestPropertiesLink = new WebElementWrapper(ByTestPropertiesLink);
            DeleteMulipleQuestionsLink = new WebElementWrapper(ByDeleteMulipleQuestionsLink);
            ReorderQuestionsLink = new WebElementWrapper(ByReorderQuestionsLink);
            QuestionNumbersLink = new WebElementWrapper(ByQuestionNumbersLink);
            ScoreGroupsLink = new WebElementWrapper(ByScoreGroupsLink);
            AnswerChoicesPatternLink = new WebElementWrapper(ByAnswerChoicesPatternLink);
        }

        //the '4h' keeps changing based on conditions, we really need a unique ID added to the page
        //private By ByTestPropertiesLink { get { return By.CssSelector(".well .AccordianHeader[headerindex='4h']"); } }
        private By ByTestPropertiesLink { get { return By.CssSelector("//div[@class='well']/div[@class='PlainBox']/h5/div[@headerindex][contains(text(),'Customize Test')]"); } }
        private WebElementWrapper TestPropertiesLink { get; set; }
        private By ByDeleteMulipleQuestionsLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_LinkButtonDeleteMultipleQuestions"); } }
        private WebElementWrapper DeleteMulipleQuestionsLink { get; set; }
        private By ByReorderQuestionsLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_LinkButtonReorderQuestions"); } }
        private WebElementWrapper ReorderQuestionsLink { get; set; }
        private By ByQuestionNumbersLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_LinkButtonCustomizeQuestionNumbers"); } }
        private WebElementWrapper QuestionNumbersLink { get; set; }
        private By ByScoreGroupsLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_LinkButtonCustomizeScoreGroup"); } }
        private WebElementWrapper ScoreGroupsLink { get; set; }
        private By ByAnswerChoicesPatternLink { get { return By.Id(ControlPrefix + "TestInfoSidebar1_LinkButtonCustomizeAnswer"); } }
        private WebElementWrapper AnswerChoicesPatternLink { get; set; }

        /// <summary>
        /// expand test properties
        /// </summary>
        public override void ExpandLink()
        {
            TestPropertiesLink.Wait(2);
            TestPropertiesLink.FakeAttributeClass = "AccordianClosed";
            if (TestPropertiesLink.GetAttribute("class").Trim().ToLower().Contains("accordianclosed"))
            {
                TestPropertiesLink.Click();
            }
        }
        /// <summary>
        /// collapse test properties
        /// </summary>
        public override void CollapseLink()
        {
            TestPropertiesLink.Wait(2);
            TestPropertiesLink.FakeAttributeClass = "AccordianOpen";
            if (TestPropertiesLink.GetAttribute("class").Trim().ToLower().Contains("accordianopen"))
            {
                TestPropertiesLink.Click();
            }
        }
        /// <summary>
        /// delete multiple questions
        /// </summary>
        public void DeleteMulipleQuestions()
        {
            DeleteMulipleQuestionsLink.Wait(2).Click();
        }
        /// <summary>
        /// reorder questions
        /// </summary>
        public void ReorderQuestions()
        {
            ReorderQuestionsLink.Wait(2).Click();
        }
        /// <summary>
        /// question numbers
        /// </summary>
        public void QuestionNumbers()
        {
            QuestionNumbersLink.Wait(2).Click();
        }
        /// <summary>
        /// score groups
        /// </summary>
        public void ScoreGroups()
        {
            ScoreGroupsLink.Wait(2).Click();
        }
        /// <summary>
        /// answer choices patter
        /// </summary>
        public void AnswerChoicesPattern()
        {
            AnswerChoicesPatternLink.Wait(2).Click();
        }
    }
}
