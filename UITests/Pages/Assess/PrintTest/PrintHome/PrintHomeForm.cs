using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.PrintTest.PrintHome
{
    /// <summary>
    /// Print Home form
    /// </summary>
    public class PrintHomeForm : SNForm
    {
        /// <summary>
        /// the Print home form constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public PrintHomeForm(string overrideControlPrefix = null)
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
            TestNameID = new WebElementWrapper(byTestNameID);
            Subject = new WebElementWrapper(bySubject);
            GradeLow = new WebElementWrapper(byGradeLow);
            GradeHigh = new WebElementWrapper(byGradeHigh);
            Go = new WebElementWrapper(byGo);
            AdvanceSearch = new WebElementWrapper(byAdvanceSearch);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new PrintHomeData Data
        {
            get
            {
                return (PrintHomeData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        public string ControlPrefix2 = "ctl00_MainContent_TestSearchResults1_TestFinderSearch1_";

        public By byTestNameID { get { return By.Id(ControlPrefix2 + "TextBoxTestName"); } }
        //id=ctl00_MainContent_TestSearchResults1_TestFinderSearch1_ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TextBoxTestName
        public WebElementWrapper TestNameID { get; set; }

        public By bySubject { get { return By.Id(ControlPrefix2 + "TestSubjectSelector1_DropDownListSubject"); } }
        //id=ctl00_MainContent_TestSearchResults1_TestFinderSearch1_ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TestSubjectSelector1_DropDownListSubject
        public WebElementWrapper Subject { get; set; }

        public By byGradeLow { get { return By.Id(ControlPrefix2 + "TestGradeRangeSelector1_GradeDropDownLow_DropDownGrade"); } }
        //id=ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TestGradeRangeSelector1_GradeDropDownLow_DropDownGrade
        public WebElementWrapper GradeLow { get; set; }

        public By byGradeHigh { get { return By.Id(ControlPrefix2 + "TestGradeRangeSelector1_GradeDropDownHigh_DropDownGrade"); } }
        //id=ctl00_MainContent_TestSearchResults1_TestFinderSearch1_TestGradeRangeSelector1_GradeDropDownHigh_DropDownGrade
        public WebElementWrapper GradeHigh { get; set; }

        public By byGo { get { return By.Id(ControlPrefix2 + "ButtonGo"); } }
        //id=ctl00_MainContent_TestSearchResults1_TestFinderSearch1_ButtonGo
        public WebElementWrapper Go { get; set; }

        public By byAdvanceSearch { get { return By.Id(ControlPrefix2 + "LinkFindType"); } }
        //id=ctl00_MainContent_TestSearchResults1_TestFinderSearch1_LinkFindType
        public WebElementWrapper AdvanceSearch { get; set; }

    }
}
