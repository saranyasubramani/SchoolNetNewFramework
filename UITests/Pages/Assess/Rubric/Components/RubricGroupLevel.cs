using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Assess.Standards;

namespace UITests.Pages.Assess.Rubric.Components
{
    /// <summary>
    /// rubric group level
    /// </summary>
    public class RubricGroupLevel : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="index">the index</param>
        /// <param name="uniqueId">the unique ID is the control id for the rubric group</param>
        /// <param name="numberOfColumn">the initial number of columns when the group is created.</param>
        public RubricGroupLevel(RubricGroupType type, int index, string uniqueId, int numberOfColumn)
            : base()
        {
            GroupType = type;
            Index = index;
            UniqueId = uniqueId;
            _currentColumnIndex = numberOfColumn;
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            AddRowButton = new WebElementWrapper(ByAddRowButton);
            GroupLabel = new WebElementWrapper(ByGroupLabel);

            RubricRowsList = new List<RubricRow>();
            CreateARubricRow();
            CreateARubricRow();

            StandardLinkList = new List<StandardControlsForm>();
            StandardPickerList = new List<StandardPickerForm>();
            // If "GroupOfThese" type, default is one standard link per group, 
            // otherwise, default is one standard link per row. Default 2 rows
            CreateAStandardLink();
            if (GroupType != RubricGroupType.GroupOfThese)
            {
                // If not group, create another one for 2nd row
                CreateAStandardLink();
            }
        }

        /// <summary>
        /// the data
        /// </summary>
        public new RubricGroupData Data
        {
            get
            {
                return (RubricGroupData)base.Data;
            }
            set
            {
                base.Data = value;
                int i = 0;
                foreach (var row in RubricRowsList)
                {
                    row.Data = ((RubricGroupData)base.Data).Row[i];
                    i++;
                }
                i = 0;
                foreach (var standard in StandardPickerList)
                {
                    standard.Data = ((RubricGroupData)base.Data).Standard[i];
                    i++;
                }
            }
        }
        private List<RubricRow> RubricRowsList { get; set; }
        private List<StandardControlsForm> StandardLinkList { get; set; }
        private List<StandardPickerForm> StandardPickerList { get; set; }

        /// <summary>
        /// the rubric group type
        /// </summary>
        public RubricGroupType GroupType { get; set; }
        /// <summary>
        /// the group index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// the rubric group control ID
        /// </summary>
        public string UniqueId { get; set; }
        private string ControlPrefix2 = "ctl00_EditRubricStandardControl_rptRubricStandardHeader_";
        //ctl00_MainContent_ctl00_EditRubricStandardControl_rptRubricStandardHeader_ctl00_rptRubricStandard_ctl02_btnAddRow
        private By ByAddRowButton { get { return By.Id(ControlPrefix + ControlPrefix2 + UniqueId + "_rptRubricStandard_ctl02_btnAddRow"); } }
        private WebElementWrapper AddRowButton { get; set; }
        //ctl00_MainContent_ctl00_EditRubricStandardControl_rptRubricStandardHeader_ctl00_tbxCategoryName
        private By ByGroupLabel { get { return By.Id(ControlPrefix + ControlPrefix2 + UniqueId + "_tbxCategoryName"); } }
        private WebElementWrapper GroupLabel { get; set; }
        private int _currentRowIndex = -1;
        private int _currentColumnIndex = -1;
        private int _currentStandardLinkIndex = -1;

        private void CreateARubricRow()
        {
            _currentRowIndex++;
            RubricRow row = new RubricRow(_currentRowIndex, UniqueId, _currentColumnIndex);
            RubricRowsList.Add(row);
        }

        private void CreateAStandardLink()
        {
            _currentStandardLinkIndex++;
            string customControlPrefix = "ctl00_MainContent_ctl00_EditRubricStandardControl_rptRubricStandardHeader_" + UniqueId;
            //ctl00_MainContent_ctl00_EditRubricStandardControl_rptRubricStandardHeader_ctl00_rptRubricStandard_ctl00_RubricStandardPicker_btnStandards
            //ctl00_MainContent_ctl00_EditRubricStandardControl_rptRubricStandardHeader_ctl00_HeaderRubricStandardPicker_btnStandards
            if (GroupType == RubricGroupType.GroupOfThese)
            {
                customControlPrefix = customControlPrefix + "_HeaderRubricStandardPicker_btnStandards";
            }
            else
            {
                customControlPrefix = customControlPrefix + "_rptRubricStandard_" + GetStandardControlId() + "_RubricStandardPicker_btnStandards";
            }

            StandardControlsForm standardLink = new StandardControlsForm(PageNames.EditRubric, ControlPrefix, customControlPrefix);
            StandardLinkList.Add(standardLink);
            StandardPickerForm standardPicker = new StandardPickerForm(PageNames.EditRubric);
            StandardPickerList.Add(standardPicker);
        }

        private string GetRowControlId()
        {
            string controlId = "";

            if (_currentRowIndex >= 0 && _currentRowIndex <= 9)
                controlId = "ctl0" + _currentRowIndex.ToString();
            if (_currentRowIndex >= 10 && _currentRowIndex <= 99)
                controlId = "ctl" + _currentRowIndex.ToString();

            return controlId;
        }

        private string GetStandardControlId()
        {
            string controlId = "";

            if (_currentStandardLinkIndex >= 0 && _currentStandardLinkIndex <= 9)
                controlId = "ctl0" + _currentStandardLinkIndex.ToString();
            if (_currentStandardLinkIndex >= 10 && _currentStandardLinkIndex <= 99)
                controlId = "ctl" + _currentStandardLinkIndex.ToString();

            return controlId;
        }

        /// <summary>
        /// add new row
        /// </summary>
        public void ClickAddNewRow()
        {
            AddRowButton.Click();
            CreateARubricRow();
            if (Data != null)
            {
                RubricRowsList[_currentRowIndex].Data = Data.Row[_currentRowIndex];
            }

            if (GroupType != RubricGroupType.GroupOfThese)
            {
                CreateAStandardLink();
            }
            if (Data != null)
            {
                StandardPickerList[_currentStandardLinkIndex].Data = Data.Standard[_currentStandardLinkIndex];
            }
        }
        /// <summary>
        /// add new column of descriptions
        /// </summary>
        public void AddNewColumnOfDescriptions()
        {
            _currentColumnIndex++;
            int i = 0;
            foreach (var row in RubricRowsList)
            {
                row.CreateARubricDescription();
                row.Data = Data.Row[i];
                i++;
            }
        }
        /// <summary>
        /// input group label
        /// </summary>
        public void InputGroupLabel()
        {
            if (GroupLabel.Displayed) GroupLabel.SendKeys(Data.GroupLabel);
        }

        //implemented methods
        public override void InputFormFields()
        {
            foreach (var Row in RubricRowsList)
            {
                Row.InputFormFields();
            }

            for (int i = 0; i <= _currentStandardLinkIndex; i++)
            {
                StandardLinkList[i].EditStandard();
                StandardPickerList[i].InputAndSubmitForm();
            }
        }
    }
}
