using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.Rubric.Components
{
    /// <summary>
    /// rubric column
    /// </summary>
    public class RubricColumn : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="index">the index</param>
        public RubricColumn(int index)
            : base()
        {
            Index = index;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            ColumnLabel = new WebElementWrapper(ByColumnLabel);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new RubricColumnData Data
        {
            get
            {
                return (RubricColumnData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// the rubric column index
        /// </summary>
        public int Index { get; set; }
        private string ControlPrefix2 = "ctl00_EditRubricStandardControl_rptRubricLevel_";
        //ctl00_MainContent_ctl00_EditRubricStandardControl_rptRubricLevel_ctl00_tbxLevelName
        private By ByColumnLabel { get { return By.Id(ControlPrefix + ControlPrefix2 + GetColumnControlId() + "_tbxLevelName"); } }
        private WebElementWrapper ColumnLabel { get; set; }

        private string GetColumnControlId()
        {
            string controlId = "";

            if (Index >= 0 && Index <= 9)
                controlId = "ctl0" + Index.ToString();
            if (Index >= 10 && Index <= 99)
                controlId = "ctl" + Index.ToString();

            return controlId;
        }

        //implemented methods
        public override void InputFormFields()
        {
            ColumnLabel.SendKeys(Data.ColumnLabel);
        }
    }
}
