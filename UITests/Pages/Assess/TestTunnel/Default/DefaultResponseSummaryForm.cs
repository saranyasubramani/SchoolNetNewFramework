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
using UITests.Pages.Assess.TestTunnel.TestForms;

namespace UITests.Pages.Assess.TestTunnel.Default
{
    /// <summary>
    /// test response summary page within the test tunnel default page
    /// </summary>
    public class DefaultResponseSummaryForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public DefaultResponseSummaryForm(string overrideControlPrefix = null)
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
            TestResponseSummaryPageTitle = new WebElementWrapper( ByTestResponseSummaryPageTitle);
            TestResponseWarningMessage = new WebElementWrapper( ByTestResponseWarningMessage);
            TestResponseSummaryDetailTable = new WebElementWrapper( ByTestResponseSummaryDetailTable);
            AnswerSummaryDivs = new WebElementWrapper( ByAnswerSummaryDiv);
            AnswerDivs = new WebElementWrapper( ByAnswerDiv);
            UnAnsweredQuestionLinks = new WebElementWrapper( ByUnAnsweredQuestionLink);
            AnsweredQuestionLinks = new WebElementWrapper( ByAnsweredQuestionLink);
            QuestionNumberSpans = new WebElementWrapper( ByQuestionNumberSpan);
            QuestionLinkSpans = new WebElementWrapper( ByQuestionLinkSpan);
            CurrentQuestionInTestSpan = new WebElementWrapper( ByCurrentQuestionInTestSpan);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new DefaultData Data
        {
            get
            {
                return (DefaultData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// list of test form types
        /// </summary>
        public List<TestTypeForm> TestList { get; set; }
        /// <summary>
        /// get the item's list of IDs and indexes
        /// </summary>
        public ReadOnlyCollection<object> ItemIdToIndexList { get; set; }
        /// <summary>
        /// Question Index will be (Question Number - 1) - used for accessing the elements of the List
        /// </summary>
        private int QuestionIndex { get; set; }
        public By ByTestResponseSummaryPageTitle { get { return By.Id("testSummary"); } }
        public WebElementWrapper TestResponseSummaryPageTitle { get; private set; }

        public By ByTestResponseWarningMessage { get { return By.Id("divWarning"); } }
        public WebElementWrapper TestResponseWarningMessage { get; private set; }

        public By ByTestResponseSummaryDetailTable { get { return By.Id("DataList1"); } }
        public WebElementWrapper TestResponseSummaryDetailTable { get; private set; }

        public By ByAnswerSummaryDiv { get { return AnswerSummaryDivLocator(); } }
        public WebElementWrapper AnswerSummaryDivs { get; set; }
        private ReadOnlyCollection<IWebElement> AnswerSummaryDivWebElementList { get; set; }

        public By ByAnswerDiv { get { return AnswerDivLocator(); } }
        public WebElementWrapper AnswerDivs { get; set; }
        private ReadOnlyCollection<IWebElement> AnswerDivWebElementList { get; set; }

        public By ByUnAnsweredQuestionLink { get { return UnsweredQuestionLinkLocator(); } }
        public WebElementWrapper UnAnsweredQuestionLinks { get; set; }
        private ReadOnlyCollection<IWebElement> UnAnsweredQuestionLinkWebElementList { get; set; }

        public By ByAnsweredQuestionLink { get { return AnsweredQuestionLinkLocator(); } }
        public WebElementWrapper AnsweredQuestionLinks { get; set; }
        private ReadOnlyCollection<IWebElement> AnsweredQuestionLinkWebElementList { get; set; }

        public By ByQuestionNumberSpan { get { return QuestionNumberSpanLocator(); } }
        public WebElementWrapper QuestionNumberSpans { get; set; }
        private ReadOnlyCollection<IWebElement> QuestionNumberSpanWebElementList { get; set; }

        public By ByQuestionLinkSpan { get { return QuestionLinkSpanLocator(); } }
        public WebElementWrapper QuestionLinkSpans { get; set; }
        private ReadOnlyCollection<IWebElement> QuestionLinkSpanWebElementList { get; set; }

        public By ByCurrentQuestionInTestSpan { get { return CurrentQuestionInTestSpanLocator(); } }
        public WebElementWrapper CurrentQuestionInTestSpan { get; set; }
        //For Non Task Item Types
        private string QuestionNumberSpanIdBeginsWith = "qn_";
        private string QuestionLinkSpanIdBeginsWith = "sq_";
        //For Task Item Types (whole Task is considered to be one Question
        private string ActivityNumberSpanIdBeginsWith = "act__";
        private string ActivityLinkSpanIdBeginsWith = "aq_";
        public int NumberOfElementsToBeReturnedInTheDummyWebElementList;
        //private List<AnswerSummaryBox> AnswerSummaryBoxList { get; set; }

        private By AnswerSummaryDivLocator()
        {
            By by = null;

            by = By.ClassName("answerSummary");

            return by;
        }

        private By AnswerDivLocator()
        {
            By by = null;

            by = By.ClassName("answer");

            return by;
        }

        private By UnsweredQuestionLinkLocator()
        {
            By by = null;

            //by = By.ClassName(" unanswered");
            by = By.ClassName("unanswered");

            return by;
        }

        private By AnsweredQuestionLinkLocator()
        {
            By by = null;
            //by = By.CssSelector("a[aria-label*=\"Answered\"]");
            by = By.CssSelector("a[aria-label^='Question']");

            return by;
        }

        private By QuestionNumberSpanLocator()
        {
            By by = null;

            //by = By.ClassName("num ");
            by = By.ClassName("num");

            return by;
        }

        private By QuestionLinkSpanLocator()
        {
            By by = null;

            by = By.CssSelector("span[class*=\"status\"]");

            return by;
        }
        /// <summary>
        /// Selector By for the Current Question in Test. 
        /// This will be the question which will be displayed when you click on the "Return to Test" button
        /// </summary>
        /// <returns>By for the Current Question Link Span</returns>
        private By CurrentQuestionInTestSpanLocator()
        {
            By by = null;

            //by = By.ClassName("status current");
            by = By.ClassName("current");

            return by;
        }

        private ReadOnlyCollection<IWebElement> GetDummyIdentifiers(int numberOfElementsInListToBeReturned = 5)
        {
            ReadOnlyCollection<IWebElement> webElements = null;
            List<IWebElement> list = new List<IWebElement>();
            DummyWebElement dummy1 = new DummyWebElement();
            DummyWebElement dummy2 = new DummyWebElement();
            DummyWebElement dummy3 = new DummyWebElement();
            DummyWebElement dummy4 = new DummyWebElement();
            DummyWebElement dummy5 = new DummyWebElement();

            dummy1.FakeAttributeClass = "status";
            dummy2.FakeAttributeClass = "status";
            dummy3.FakeAttributeClass = "status";
            //dummy4.FakeAttributeClass = "status current";
            dummy4.FakeAttributeClass = "current";
            dummy5.FakeAttributeClass = "status";

            //dummy2.FakeAttributeClass = "num";
            //dummy3.FakeAttributeClass = "status";
            //dummy4.FakeAttributeClass = "status current";
            //dummy5.FakeAttributeClass = " unanswered";

            //this does not apply to IE, but does for Firefox and Chrome
            dummy1.FakeAttributeName = "aria-label";
            dummy1.FakeAttributeValue = "Answered";
            dummy2.FakeAttributeName = "aria-label";
            dummy2.FakeAttributeValue = "Answered";
            dummy3.FakeAttributeName = "aria-label";
            dummy3.FakeAttributeValue = "Answered";
            dummy4.FakeAttributeName = "aria-label";
            dummy4.FakeAttributeValue = "unanswered";
            dummy5.FakeAttributeName = "aria-label";
            dummy5.FakeAttributeValue = "unanswered";
            //applies to all browsers
            dummy1.Text = "Answered";
            dummy2.Text = "Answered";
            dummy3.Text = "Answered";
            dummy4.Text = "Answered";
            dummy5.Text = "Answered";

            dummy1.FakeAttributeId = "aq_0";
            dummy2.FakeAttributeId = "aq_1";
            dummy3.FakeAttributeId = "aq_2";
            dummy4.FakeAttributeId = "aq_3";
            dummy5.FakeAttributeId = "aq_4";

            list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4, dummy5 };
            
            webElements = new ReadOnlyCollection<IWebElement>(list.RandomSubset(numberOfElementsInListToBeReturned).ToList());

            return webElements;
        }
        /// <summary>
        /// Clicks the Question Link based on the Question number sent in
        /// </summary>
        /// <param name="questionNumber">Question number to click</param>
        public void GoToQuestion(int questionNumber)
        {
            QuestionLinkSpanWebElementList = QuestionLinkSpans.WaitForElements(3);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                QuestionLinkSpanWebElementList = GetDummyIdentifiers(NumberOfElementsToBeReturnedInTheDummyWebElementList);
            }

            QuestionIndex = (questionNumber - 1);
            QuestionLinkSpanWebElementList[QuestionIndex].Click();
        }
        /// <summary>
        /// verify all questions are answered
        /// </summary>
        /// <returns>true or false</returns>
        public bool VerifyAllQuestionsAreAnswered()
        {
            bool allQuestionAnswered = true;//false;

            UnAnsweredQuestionLinkWebElementList = UnAnsweredQuestionLinks.WaitForElements(3);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                UnAnsweredQuestionLinkWebElementList = GetDummyIdentifiers(NumberOfElementsToBeReturnedInTheDummyWebElementList);
            }

            /*if (!UnAnsweredQuestionLinkWebElementList.Any())
                allQuestionAnswered = true;*/
            //need to verify the text to work in all browsers (because of IE)
            foreach (var webElement in UnAnsweredQuestionLinkWebElementList)
            {
                string actual = webElement.Text;
                if (!actual.Equals("Answered"))
                {
                    allQuestionAnswered = false;
                }
            }
            return allQuestionAnswered;
        }
        /// <summary>
        /// Verified a specific Nth question is Answered
        /// </summary>
        /// <param name="index">Index start at 0, 1, 2. 0th is 1st question</param>
        /// <returns>true or false</returns>
        public bool VerifyQuestionIsAnswered(int index)
        {
            //AnsweredQuestionLinks return all answered and unanswered
            //In order to find out if a question was answered, check to see if it was in UNanswered list
            //If it is not there, check to see the question exist AnsweredQuestionLinks
            //If it is found in AnsweredQuestionLinks, we know the question exist and it is not UNanswered. 
            if (Driver.WrappedDriver.GetType() != typeof(DummyDriver)) //if not dummy
            {
                if (VerifyQuestionIsUnAnswered(index))
                {
                    return false;
                }
            }

            ReadOnlyCollection<IWebElement> AllQuestionsLinkWebElementList = AnsweredQuestionLinks.WaitForElements(3);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                List<IWebElement> dummyList = new List<IWebElement>();
                DummyWebElement dummy = new DummyWebElement();
                dummy.FakeAttributeAriaLabel = "Question " + Convert.ToString(index + 1);
                dummyList = new List<IWebElement> { dummy };

                AllQuestionsLinkWebElementList = new ReadOnlyCollection<IWebElement>(dummyList);
            }

            foreach (var webElement in AllQuestionsLinkWebElementList)
            {
                //<a aria-label="Question 2 Unanswered" role="link" class=" unanswered" tabindex="0">Unanswered</a>
                string actualLabel = webElement.GetAttribute("aria-label");
                string expectLabel = "Question " + Convert.ToString(index + 1);
                if (actualLabel.Contains(expectLabel))
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// verify all questions are unanswered
        /// </summary>
        /// <returns>true or false</returns>
        public bool VerifyAllQuestionsAreUnAnswered()
        {
            bool allQuestionsAreUnAnswered = true;//false;

            AnsweredQuestionLinkWebElementList = AnsweredQuestionLinks.WaitForElements(3);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                AnsweredQuestionLinkWebElementList = GetDummyIdentifiers(NumberOfElementsToBeReturnedInTheDummyWebElementList);
            }

            /*if (!AnsweredQuestionLinkWebElementList.Any())
                allQuestionsAreUnAnswered = true;*/
            //need to verify the text to work in all browsers (because of IE)
            foreach (var webElement in UnAnsweredQuestionLinkWebElementList)
            {
                string actual = webElement.Text;
                if (!actual.Equals("Unanswered"))
                {
                    allQuestionsAreUnAnswered = false;
                }
            }
            return allQuestionsAreUnAnswered;
        }
        /// <summary>
        /// Verified a specific Nth question is not Unanswered
        /// </summary>
        /// <param name="index">Index start at 0, 1, 2. 0th is 1st question</param>
        /// <returns>true or false</returns>
        public bool VerifyQuestionIsUnAnswered(int index)
        {
            UnAnsweredQuestionLinkWebElementList = UnAnsweredQuestionLinks.WaitForElements(3);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                List<IWebElement> dummyList = new List<IWebElement>();
                DummyWebElement dummy = new DummyWebElement();
                dummy.FakeAttributeAriaLabel = "Question " + Convert.ToString(index + 1);
                dummyList = new List<IWebElement> { dummy };

                UnAnsweredQuestionLinkWebElementList = new ReadOnlyCollection<IWebElement>(dummyList);
            }

            foreach (var webElement in UnAnsweredQuestionLinkWebElementList)
            {
                //<a aria-label="Question 2 Unanswered" role="link" class=" unanswered" tabindex="0">Unanswered</a>
                string actualLabel = webElement.GetAttribute("aria-label");
                string expectLabel = "Question " + Convert.ToString(index + 1);
                if (actualLabel.Contains(expectLabel))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// verify warning message
        /// </summary>
        public void VerifyWarningMessage()
        {
            UnAnsweredQuestionLinkWebElementList = UnAnsweredQuestionLinks.WaitForElements(3);
            var warning = TestResponseWarningMessage.Wait(2);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                UnAnsweredQuestionLinkWebElementList = GetDummyIdentifiers(NumberOfElementsToBeReturnedInTheDummyWebElementList);
                warning.Displayed = true;
                warning.Text = "Warning: You have " + UnAnsweredQuestionLinkWebElementList.Count + " unanswered questions";
            }

            if (UnAnsweredQuestionLinkWebElementList.Any())
            {
                Assert.AreEqual(true, warning.Displayed, "The warning message is invisible, but should be visible.");

                var countOfUnansweredQuestions = UnAnsweredQuestionLinkWebElementList.Count;

                Assert.IsTrue(warning.Text.Contains(countOfUnansweredQuestions.ToString()),
                    string.Format("Actual number of UnAnswered questions is {0} which is not the same as the displayed number of unanswered questions in the warning message.",
                    countOfUnansweredQuestions));
            }
        }
        /// <summary>
        /// get warning message
        /// </summary>
        /// <returns>warning message</returns>
        public string GetWarningMessage()
        {
            var warning = TestResponseWarningMessage.Wait(2);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                warning.Text = Data.ExpectedResult;
            }

            return warning.Text;
        }
        /// <summary>
        /// get number of answered questions
        /// </summary>
        /// <returns>count</returns>
        public int GetNumberOfAnsweredQuestions()
        {
            AnsweredQuestionLinkWebElementList = AnsweredQuestionLinks.WaitForElements(3);
            int count = 0;
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                AnsweredQuestionLinkWebElementList = GetDummyIdentifiers(NumberOfElementsToBeReturnedInTheDummyWebElementList);
            }
            //need to verify the text to work in all browsers (because of IE)
            foreach (var webElement in AnsweredQuestionLinkWebElementList)
            {
                string actual = webElement.Text;
                if (actual.Equals("Answered"))
                {
                    count++;
                }
            }
            //return AnsweredQuestionLinkWebElementList.Count;
            return count;
        }
        /// <summary>
        /// get number of unanswered questions
        /// </summary>
        /// <returns>count</returns>
        public int GetNumberOfUnAnsweredQuestions()
        {
            UnAnsweredQuestionLinkWebElementList = UnAnsweredQuestionLinks.WaitForElements(3);
            int count = 0;
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                UnAnsweredQuestionLinkWebElementList = GetDummyIdentifiers(NumberOfElementsToBeReturnedInTheDummyWebElementList);
            }
            //need to verify the text to work in all browsers (because of IE)
            foreach (var webElement in AnsweredQuestionLinkWebElementList)
            {
                string actual = webElement.Text;
                if (actual.Equals("Unanswered"))
                {
                    count++;
                }
            }
            //return UnAnsweredQuestionLinkWebElementList.Count;
            return count;
        }
        /// <summary>
        /// go to currently active question in test
        /// </summary>
        public void GoToCurrentlyActiveQuestionInTest()
        {
            CurrentQuestionInTestSpan.Wait(3).Click();
        }
        /// <summary>
        /// get index of currently active question in test
        /// </summary>
        /// <returns>index</returns>
        public int GetIndexOfCurrentlyActiveQuestionInTest()
        {
            var element = CurrentQuestionInTestSpan.Wait(3);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                element.FakeAttributeId = "sq_3";
            }

            //int indexOfCurrentlyActiveQuestionInTest = Int32.Parse(CurrentQuestionInTestSpan.Wait(3).GetAttribute("id").Split('_')[1]);
            int indexOfCurrentlyActiveQuestionInTest = Int32.Parse(element.GetAttribute("id").Split('_')[1]);

            return indexOfCurrentlyActiveQuestionInTest;
        }
    }
}
