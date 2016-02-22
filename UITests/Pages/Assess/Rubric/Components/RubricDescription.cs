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
    /// rubric description
    /// </summary>
    public class RubricDescription : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="groupId">the rubric group control id</param>
        /// <param name="rowId">the rubric row control id</param>
        /// <param name="columnIndex">the column id. Use for getting column control id</param>
        public RubricDescription(string groupId, string rowId, int columnIndex)
            : base()
        {
            GroupControlId = groupId;
            RowControlId = rowId;
            IndexColumn = columnIndex;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            DescriptionLabel = new WebElementWrapper(ByDescriptionLabel);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new RubricDescriptionData Data
        {
            get
            {
                return (RubricDescriptionData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// the rubric row control id
        /// </summary>
        public string RowControlId { get; set; }
        /// <summary>
        /// the rubric group control id
        /// </summary>
        public string GroupControlId { get; set; }
        /// <summary>
        /// the rubric column index, use to generate control id
        /// </summary>
        public int IndexColumn { get; set; }
        private string ControlPrefix2 = "ctl00_EditRubricStandardControl_rptRubricStandardHeader_";
        //ctl00_MainContent_ctl00_EditRubricStandardControl_rptRubricStandardHeader_ctl00_rptRubricStandard_ctl00_rptStandardLevelDescription_ctl00_tbxDescription
        private By ByDescriptionLabel
        {
            get
            {
                return By.Id(ControlPrefix + ControlPrefix2 + GroupControlId +
                    "_rptRubricStandard_" + RowControlId + "_rptStandardLevelDescription_" + GetColumnControlId() + "_tbxDescription");
            }
        }
        private WebElementWrapper DescriptionLabel { get; set; }

        private string GetColumnControlId()
        {
            string controlId = "";

            if (IndexColumn >= 0 && IndexColumn <= 9)
                controlId = "ctl0" + IndexColumn.ToString();
            if (IndexColumn >= 10 && IndexColumn <= 99)
                controlId = "ctl" + IndexColumn.ToString();

            return controlId;
        }

        //implemented methods
        public override void InputFormFields()
        {
            DescriptionLabel.SendKeys(Data.Description);
        }
    }
}
