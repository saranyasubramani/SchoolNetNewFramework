using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.TestTunnel.TestParts
{
    /// <summary>
    /// represents the answer grid column in the online test tunnel page
    /// </summary>
    public class AnswerGridColumn : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="index">the index</param>
        public AnswerGridColumn(  int index)
            : base()
        {
            Index = index;
            Answer = new WebElementWrapper( ByAnswerInput());
            Answer0 = new WebElementWrapper( ByAnswer(2));
            Answer1 = new WebElementWrapper( ByAnswer(3));
            Answer2 = new WebElementWrapper( ByAnswer(4));
            Answer3 = new WebElementWrapper( ByAnswer(5));
            Answer4 = new WebElementWrapper( ByAnswer(6));
            Answer5 = new WebElementWrapper( ByAnswer(7));
            Answer6 = new WebElementWrapper( ByAnswer(8));
            Answer7 = new WebElementWrapper( ByAnswer(9));
            Answer8 = new WebElementWrapper( ByAnswer(10));
            Answer9 = new WebElementWrapper( ByAnswer(11));
            AnswerPeriod = new WebElementWrapper( ByAnswer(12));
            AnswerSlash = new WebElementWrapper( ByAnswer(13));
            AnswerBubbledIn = new WebElementWrapper( ByAnswerBubbledIn());
            TestItemStatus = TestItemStatus.Unanswered;
            Data = "";
        }

        /// <summary>
        /// the current status of the test item
        /// </summary>
        public TestItemStatus TestItemStatus { get; set; }
        /// <summary>
        /// is this the correct answer?
        /// </summary>
        public bool IsCorrectAnswer { get; set; }
        /// <summary>
        /// the line item's index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// the line item's grid data
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// the answer
        /// </summary>
        public WebElementWrapper Answer { get; private set; }
        /// <summary>
        /// the answer
        /// </summary>
        public WebElementWrapper AnswerBubbledIn { get; private set; }
        /// <summary>
        /// the answer 0
        /// </summary>
        public WebElementWrapper Answer0 { get; private set; }
        /// <summary>
        /// the answer 1
        /// </summary>
        public WebElementWrapper Answer1 { get; private set; }
        /// <summary>
        /// the answer 2
        /// </summary>
        public WebElementWrapper Answer2 { get; private set; }
        /// <summary>
        /// the answer 3
        /// </summary>
        public WebElementWrapper Answer3 { get; private set; }
        /// <summary>
        /// the answer 4
        /// </summary>
        public WebElementWrapper Answer4 { get; private set; }
        /// <summary>
        /// the answer 5
        /// </summary>
        public WebElementWrapper Answer5 { get; private set; }
        /// <summary>
        /// the answer 6
        /// </summary>
        public WebElementWrapper Answer6 { get; private set; }
        /// <summary>
        /// the answer 7
        /// </summary>
        public WebElementWrapper Answer7 { get; private set; }
        /// <summary>
        /// the answer 8
        /// </summary>
        public WebElementWrapper Answer8 { get; private set; }
        /// <summary>
        /// the answer 9
        /// </summary>
        public WebElementWrapper Answer9 { get; private set; }
        /// <summary>
        /// the answer "."
        /// </summary>
        public WebElementWrapper AnswerPeriod { get; private set; }
        /// <summary>
        /// the answer "/"
        /// </summary>
        public WebElementWrapper AnswerSlash { get; private set; }

        private By ByAnswerInput()
        {
            By by = null;
            by = By.CssSelector("#divResponseGrid > tbody > tr:nth-of-type(1) > td > input[id^='grid_" + Index + "']");
            return by;
        }
        private By ByAnswer(int row)
        {
            By by = null;
            by = By.CssSelector("#divResponseGrid > tbody > tr:nth-of-type(" + row + ") > td[id^='grid_" + Index + "']");
            return by;
        }
        private By ByAnswerBubbledIn()
        {
            By by = null;
            by = By.CssSelector("#divResponseGrid > tbody > tr > td.BubbledIn[id^='grid_" + Index + "']");
            return by;
        }
    }
}
