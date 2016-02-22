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

namespace UITests.Pages.Assess.TestTunnel.TestParts
{
    /// <summary>
    /// represents the answer choices in the online test tunnel page
    /// </summary>
    public class AnswerGrids : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        public AnswerGrids()
            : base()
        {
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            AnswerChoiceGrid = new WebElementWrapper( ByAnswerChoiceGrid());
            AnswerContentColumns = new WebElementWrapper( ByAnswerContentColumns());
            SetAnswerChoiceList();
        }

        /// <summary>
        /// the current status of the test item
        /// </summary>
        public TestItemStatus TestItemStatus { get; set; }
        private WebElementWrapper AnswerChoiceGrid { get; set; }
        private WebElementWrapper AnswerContentColumns { get; set; }
        private ReadOnlyCollection<IWebElement> AnswerContentWebElementList { get; set; }
        private List<AnswerGridColumn> AnswerChoiceList { get; set; }

        private By ByAnswerChoiceGrid()
        {
            By by = null;
            by = By.Id("divResponseGrid");
            return by;
        }

        private By ByAnswerContentColumns()
        {
            By by = null;
            by = By.CssSelector("input.GriddedInput");
            return by;
        }

        private ReadOnlyCollection<IWebElement> GetDummyIdentifiers()
        {
            ReadOnlyCollection<IWebElement> webElements = null;
            List<IWebElement> list = new List<IWebElement>();
            DummyWebElement dummy1 = new DummyWebElement();
            DummyWebElement dummy2 = new DummyWebElement();
            DummyWebElement dummy3 = new DummyWebElement();
            DummyWebElement dummy4 = new DummyWebElement();
            DummyWebElement dummy5 = new DummyWebElement();
            DummyWebElement dummy6 = new DummyWebElement();
            DummyWebElement dummy7 = new DummyWebElement();
            DummyWebElement dummy8 = new DummyWebElement();
            DummyWebElement dummy9 = new DummyWebElement();

            dummy1.FakeAttributeId = "grid_0";
            dummy2.FakeAttributeId = "grid_1";
            dummy3.FakeAttributeId = "grid_2";
            dummy4.FakeAttributeId = "grid_3";
            dummy5.FakeAttributeId = "grid_4";
            dummy6.FakeAttributeId = "grid_5";
            dummy7.FakeAttributeId = "grid_6";
            dummy8.FakeAttributeId = "grid_7";
            dummy9.FakeAttributeId = "grid_8";

            list = new List<IWebElement> { dummy1, dummy2, dummy3, dummy4, dummy5, dummy6, dummy7, dummy8, dummy9 };
            webElements = new ReadOnlyCollection<IWebElement>(list);
            return webElements;
        }

        /// <summary>
        /// sets the answer choice list
        /// </summary>
        public void SetAnswerChoiceList()
        {
            AnswerChoiceList = new List<AnswerGridColumn>();
            AnswerChoiceGrid.Wait(3);
            AnswerContentWebElementList = AnswerContentColumns.WaitForElements(5);

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                AnswerContentWebElementList = GetDummyIdentifiers();
            }

            int index = 0;
            foreach (var webElement in AnswerContentWebElementList)
            {
                Report.Write("AnswerGridColumn index: '" + index);
                var answerLineItem = new AnswerGridColumn( index);
                AnswerChoiceList.Add(answerLineItem);
                index++;
            }
        }

        /// <summary>
        /// gets the answer choice list
        /// </summary>
        /// <returns>list of answer line item</returns>
        public List<AnswerGridColumn> GetAnswerChoiceList()
        {
            return AnswerChoiceList;
        }

        /// <summary>
        /// count the answered grids
        /// </summary>
        /// <returns>the count</returns>
        public int CountAnsweredGrids()
        {
            return CountGridTestItemStatus(TestItemStatus.Answered);
        }
        /// <summary>
        /// count the unanswered grids
        /// </summary>
        /// <returns>the count</returns>
        public int CountUnansweredGrids()
        {
            return CountGridTestItemStatus(TestItemStatus.Unanswered);
        }

        private int CountGridTestItemStatus(TestItemStatus testItemStatus)
        {
            //Report.Write("testItemStatus passed in: " + testItemStatus.ToString());
            int answerCount = 0;
            foreach (var answerChoice in AnswerChoiceList)
            {
                //Report.Write("answerChoice TestItemStatus: " + answerChoice.TestItemStatus.ToString());
                if (answerChoice.TestItemStatus == testItemStatus)
                {
                    answerCount++;
                }
            }
            return answerCount;
        }

        /// <summary>
        /// are all of the grids answered?
        /// </summary>
        /// <returns>true of false</returns>
        public bool AreAllGridsAnswered()
        {
            return AreAllGridTestItemStatusTheSame(CountAnsweredGrids());
        }
        /// <summary>
        /// are all of the grids unanswered?
        /// </summary>
        /// <returns>true of false</returns>
        public bool AreAllGridsUnanswered()
        {
            return AreAllGridTestItemStatusTheSame(CountUnansweredGrids());
        }

        private bool AreAllGridTestItemStatusTheSame(int answerCount)
        {
            bool status = false;
            if (answerCount == AnswerChoiceList.Count)
            {
                status = true;
            }
            return status;
        }

        /// <summary>
        /// clear the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void ClearAnswer(int index)
        {
            AnswerChoiceList[index].Answer.Clear();
            AnswerChoiceList[index].TestItemStatus = TestItemStatus.Unanswered;
        }

        /// <summary>
        /// input/type the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        /// <param name="answer">the answer</param>
        public void InputAnswer(int index, string answer)
        {
            AnswerChoiceList[index].Answer.Clear();
            AnswerChoiceList[index].Answer.SendKeys(answer);
            AnswerChoiceList[index].Data = answer;
            AnswerChoiceList[index].TestItemStatus = TestItemStatus.Answered;
        }

        /// <summary>
        /// get the answer's value
        /// </summary>
        /// <param name="index">the answer's index</param>
        /// <returns>the answer</returns>
        public string GetAnswerValue(int index)
        {
            AnswerChoiceList[index].AnswerBubbledIn.Text = "0";
            return AnswerChoiceList[index].AnswerBubbledIn.Text;
        }

        /// <summary>
        /// get the expected data for answer
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetExpectedAnswerData(int index)
        {
            return AnswerChoiceList[index].Data;
        }

        /// <summary>
        /// select the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void SelectAnswer0(int index)
        {
            AnswerChoiceList[index].Answer0.Click();
            AnswerChoiceList[index].Data = "0";
            AnswerChoiceList[index].TestItemStatus = TestItemStatus.Answered;
        }
        /// <summary>
        /// select the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void SelectAnswer1(int index)
        {
            AnswerChoiceList[index].Answer1.Click();
            AnswerChoiceList[index].Data = "1";
            AnswerChoiceList[index].TestItemStatus = TestItemStatus.Answered;
        }
        /// <summary>
        /// select the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void SelectAnswer2(int index)
        {
            AnswerChoiceList[index].Answer2.Click();
            AnswerChoiceList[index].Data = "2";
            AnswerChoiceList[index].TestItemStatus = TestItemStatus.Answered;
        }
        /// <summary>
        /// select the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void SelectAnswer3(int index)
        {
            AnswerChoiceList[index].Answer3.Click();
            AnswerChoiceList[index].Data = "3";
            AnswerChoiceList[index].TestItemStatus = TestItemStatus.Answered;
        }
        /// <summary>
        /// select the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void SelectAnswer4(int index)
        {
            AnswerChoiceList[index].Answer4.Click();
            AnswerChoiceList[index].Data = "4";
            AnswerChoiceList[index].TestItemStatus = TestItemStatus.Answered;
        }
        /// <summary>
        /// select the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void SelectAnswer5(int index)
        {
            AnswerChoiceList[index].Answer5.Click();
            AnswerChoiceList[index].Data = "5";
            AnswerChoiceList[index].TestItemStatus = TestItemStatus.Answered;
        }
        /// <summary>
        /// select the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void SelectAnswer6(int index)
        {
            AnswerChoiceList[index].Answer6.Click();
            AnswerChoiceList[index].Data = "6";
            AnswerChoiceList[index].TestItemStatus = TestItemStatus.Answered;
        }
        /// <summary>
        /// select the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void SelectAnswer7(int index)
        {
            AnswerChoiceList[index].Answer7.Click();
            AnswerChoiceList[index].Data = "7";
            AnswerChoiceList[index].TestItemStatus = TestItemStatus.Answered;
        }
        /// <summary>
        /// select the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void SelectAnswer8(int index)
        {
            AnswerChoiceList[index].Answer8.Click();
            AnswerChoiceList[index].Data = "8";
            AnswerChoiceList[index].TestItemStatus = TestItemStatus.Answered;
        }
        /// <summary>
        /// select the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void SelectAnswer9(int index)
        {
            AnswerChoiceList[index].Answer9.Click();
            AnswerChoiceList[index].Data = "9";
            AnswerChoiceList[index].TestItemStatus = TestItemStatus.Answered;
        }
        /// <summary>
        /// select the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void SelectAnswerPeriod(int index)
        {
            AnswerChoiceList[index].AnswerPeriod.Click();
            AnswerChoiceList[index].Data = ".";
            AnswerChoiceList[index].TestItemStatus = TestItemStatus.Answered;
        }
        /// <summary>
        /// select the answer
        /// </summary>
        /// <param name="index">the answer's index</param>
        public void SelectAnswerSlash(int index)
        {
            AnswerChoiceList[index].AnswerSlash.Click();
            AnswerChoiceList[index].Data = "/";
            AnswerChoiceList[index].TestItemStatus = TestItemStatus.Answered;
        }
    }
}
