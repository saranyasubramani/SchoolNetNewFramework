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
    /// the question's gap
    /// </summary>
    public class QuestionGap : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="index">the index</param>
        /// <param name="gapContent">the question gap content</param>
        public QuestionGap(  int index)
            : base()
        {
            Index = index;
            GapSelect = new SelectElementWrapper(new WebElementWrapper( ByGapSelect));
        }

        /// <summary>
        /// the question gap's index
        /// </summary>
        public int Index { get; set; }
        private By ByGapSelect { get { return By.CssSelector("#divRight select.Gap:nth-of-type(" + (Index + 1) + ")"); } }
        /// <summary>
        /// the question gap select/dropdown
        /// </summary>
        public SelectElementWrapper GapSelect { get; private set; }
    }
}
