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
    /// rubric row
    /// </summary>
    public class RubricRow : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="index">the index is row id</param>
        /// <param name="groupCtrlId">the group control id for the rubric group that the row belongs to</param>
        /// <param name="defaultNumOfColumn">the initial number of columns when the row is created. This is use 
        /// to create rubric descriptions initially</param>
        public RubricRow(int index, string groupCtrlId, int defaultNumOfColumn)
            : base()
        {
            Index = index;
            GroupControlId = groupCtrlId;
            DefaultNumOfColumn = defaultNumOfColumn;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            RowLabel = new WebElementWrapper(ByRowLabel);
            RubricDescriptionList = new List<RubricDescription>();

            for (int i = 0; i <= DefaultNumOfColumn; i++) CreateARubricDescription();
        }

        /// <summary>
        /// the data
        /// </summary>
        public new RubricRowData Data
        {
            get
            {
                return (RubricRowData)base.Data;
            }
            set
            {
                base.Data = value;
                int i = 0;
                foreach (var desc in RubricDescriptionList)
                {
                    desc.Data = ((RubricRowData)base.Data).Descriptions[i];
                    i++;
                }
            }
        }
        private List<RubricDescription> RubricDescriptionList { get; set; }

        /// <summary>
        /// the rubric group control id
        /// </summary>
        public string GroupControlId { get; set; }
        /// <summary>
        /// the rubric row index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// the initial number of columns when the row is created
        /// </summary>
        public int DefaultNumOfColumn;
        private string ControlPrefix2 = "ctl00_EditRubricStandardControl_rptRubricStandardHeader_";
        //ctl00_MainContent_ctl00_EditRubricStandardControl_rptRubricStandardHeader_ctl00_rptRubricStandard_ctl00_tbxCategoryName
        //ctl00_MainContent_ctl00_EditRubricStandardControl_rptRubricStandardHeader_ctl00_rptRubricStandard_ctl01_tbxCategoryName
        private By ByRowLabel { get { return By.Id(ControlPrefix + ControlPrefix2 + GroupControlId + "_rptRubricStandard_" + GetRowControlId() + "_tbxCategoryName"); } }
        private WebElementWrapper RowLabel { get; set; }
        private int _currentDescriptionIndex = -1;

        private string GetRowControlId()
        {
            string controlId = "";

            if (Index >= 0 && Index <= 9)
                controlId = "ctl0" + Index.ToString();
            if (Index >= 10 && Index <= 99)
                controlId = "ctl" + Index.ToString();

            return controlId;
        }

        /// <summary>
        /// create rubric description
        /// </summary>
        public void CreateARubricDescription()
        {
            _currentDescriptionIndex++;
            RubricDescription desc = new RubricDescription(GroupControlId, GetRowControlId(), _currentDescriptionIndex);
            RubricDescriptionList.Add(desc);
        }

        //implement method
        public override void InputFormFields()
        {
            RowLabel.SendKeys(Data.RowLabel);

            foreach (var Desc in RubricDescriptionList)
            {
                Desc.InputFormFields();
            }
        }
    }
}
