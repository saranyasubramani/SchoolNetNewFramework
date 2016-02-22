using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestTunnel.TestParts
{
    /// <summary>
    /// represents the question line item in the online test tunnel page
    /// </summary>
    public class QuestionLineItem : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="index">the index</param>
        /// <param name="stemContent">the question stem content</param>
        public QuestionLineItem(  int index, string stemContent)
            : base()
        {
            Index = index;
            StemContent = stemContent;
            StemSelect = new SelectElementWrapper(new WebElementWrapper( ByStemSelect));
        }

        /// <summary>
        /// the line item's index
        /// </summary>
        public int Index { get; private set; }
        /// <summary>
        /// the line item's question stem content
        /// </summary>
        public string StemContent { get; private set; }
        private By ByStemSelect { get { return By.CssSelector(".matchQuestions tr:nth-of-type(" + (Index + 1) + ") select.Stem"); } }
        /// <summary>
        /// the question stem select/dropdown
        /// </summary>
        public SelectElementWrapper StemSelect { get; private set; }
    }
}
