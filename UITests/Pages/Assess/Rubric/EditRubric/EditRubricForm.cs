using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.Rubric.Components;

namespace UITests.Pages.Assess.Rubric.EditRubric
{
    /// <summary>
    /// edit rubric form
    /// </summary>
    public class EditRubricForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="groupType">group type</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public EditRubricForm(RubricGroupType groupType, string overrideControlPrefix = null)
            : base()
        {
            GroupType = groupType;
            InitElements();
        }

        public override void InitElements()
        {
            RubricColumnList = new List<RubricColumn>();
            CreateAColumn();
            CreateAColumn();
            CreateAColumn();

            RubricGroupList = new List<RubricGroupLevel>();
            CreateARubricGroup();

            ItemPropertiesForm = new ItemPropertiesForm(PageNames.EditRubric);
            Scale = new SelectElementWrapper(new WebElementWrapper(ByScaleDropdown));
            AddColumnButton = new WebElementWrapper(ByAddColumnButton);
            AddGroupButton = new WebElementWrapper(ByAddGroupButton);
            Delete = new WebElementWrapper(ByDelete);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new EditRubricData Data
        {
            get
            {
                return (EditRubricData)base.Data;
            }
            set
            {
                base.Data = value;
                ItemPropertiesForm.Data = ((EditRubricData)base.Data).RubricProperties;
                int i = 0;
                foreach (var group in RubricGroupList)
                {
                    group.Data = ((EditRubricData)base.Data).RubricLevels[i];
                    i++;
                }
                i = 0;
                foreach (var column in RubricColumnList)
                {
                    column.Data = ((EditRubricData)base.Data).RubricColumns[i];
                    i++;
                }
            }
        }
        List<RubricGroupLevel> RubricGroupList { get; set; }
        private int _currentGroupIndex = -1;
        List<RubricColumn> RubricColumnList { get; set; }
        private int _currentColumnIndex = -1;

        /// <summary>
        /// the rubric group type
        /// </summary>
        public RubricGroupType GroupType { get; set; }
        public ItemPropertiesForm ItemPropertiesForm { get; set; }
        private By ByScaleDropdown { get { return By.Id(ControlPrefix + "ctl00_ddlScaleType"); } }
        private SelectElementWrapper Scale { get; set; }
        private By ByAddColumnButton { get { return By.Id(ControlPrefix + "ctl00_EditRubricStandardControl_btnAddLevel"); } }
        private WebElementWrapper AddColumnButton { get; set; }
        //ctl00_MainContent_ctl00_EditRubricStandardControl_rptRubricStandardHeader_ctl03_btnAddGroup
        private By ByAddGroupButton { get { return By.Id(ControlPrefix + "ctl00_EditRubricStandardControl_rptRubricStandardHeader_" + GetAddGroupButtonControlId() + "_btnAddGroup"); } }
        private WebElementWrapper AddGroupButton { get; set; }
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ctl00_ButtonSubmit"); } }
        /// <summary>
        /// cancel by
        /// </summary>
        public override By ByCancel { get { return By.Id(ControlPrefix + "ctl00_ButtonCancel"); } }
        public By ByDelete { get { return By.Id(ControlPrefix + "ctl00_ButtonDelete"); } }
        private WebElementWrapper Delete { get; set; }

        private string GetGroupControlId()
        {
            string controlId = "";

            if (_currentGroupIndex >= 0 && _currentGroupIndex <= 9)
                controlId = "ctl0" + _currentGroupIndex.ToString();
            if (_currentGroupIndex >= 10 && _currentGroupIndex <= 99)
                controlId = "ctl" + _currentGroupIndex.ToString();

            return controlId;
        }

        private string GetAddGroupButtonControlId()
        {
            string controlId = "";
            int addGroupButtonId = _currentGroupIndex + 1;

            if (addGroupButtonId >= 0 && addGroupButtonId <= 9)
                controlId = "ctl0" + addGroupButtonId.ToString();
            if (_currentGroupIndex >= 10 && addGroupButtonId <= 99)
                controlId = "ctl" + addGroupButtonId.ToString();

            return controlId;
        }

        private void CreateARubricGroup()
        {
            _currentGroupIndex++;
            RubricGroupLevel group = new RubricGroupLevel(GroupType, _currentGroupIndex, GetGroupControlId(), _currentColumnIndex);
            RubricGroupList.Add(group);
        }

        private void CreateAColumn()
        {
            _currentColumnIndex++;
            RubricColumn col = new RubricColumn(_currentColumnIndex);
            RubricColumnList.Add(col);
        }

        /// <summary>
        /// gets an item from the rubric group list
        /// </summary>
        /// <param name="index">the index of the item</param>
        /// <returns>RubricGroupLineItem</returns>
        public RubricGroupLevel GetItemFromRubricGroup(int index)
        {
            return RubricGroupList[index];
        }
        /// <summary>
        /// add column
        /// </summary>
        public void ClickAddColumn()
        {
            AddColumnButton.Wait(3).Click();
            CreateAColumn();
            if (Data != null)
            {
                RubricColumnList[_currentColumnIndex].Data = Data.RubricColumns[_currentColumnIndex];
            }
            foreach (var group in RubricGroupList) group.AddNewColumnOfDescriptions();
        }
        /// <summary>
        /// add group
        /// </summary>
        public void ClickAddGroup()
        {
            AddGroupButton.Click();
            CreateARubricGroup();
            if (Data != null)
            {
                RubricGroupList[_currentGroupIndex].Data = Data.RubricLevels[_currentGroupIndex];
            }
        }
        /// <summary>
        /// delete form
        /// </summary>
        public void DeleteForm()
        {
            string currentWindow = Driver.CurrentWindowHandle;
            Report.Write("The current window is: '" + currentWindow + "'.");
            Delete.Click();

            AlertHandler alert = new AlertHandler();
            alert.VerifyText("Are you sure you want to delete this rubric? All associations to this rubric will be permanently deleted.");
            alert.Accept();

            //switch to window
            DriverCommands.WaitToSwitchWindow(currentWindow, 5);
        }

        //implemented methods
        public override void InputFormFields()
        {
            ItemPropertiesForm.InputFormFields();
            Scale.SelectByText(Data.Scale);

            foreach (var Group in RubricGroupList)
            {
                Group.InputFormFields();
                Group.InputGroupLabel();
            }

            foreach (var Column in RubricColumnList)
            {
                Column.InputFormFields();
            }
        }

        public override IBaseScreenView ReturnSubmitPage()
        {
            return new EditRubricAvailabilityPage();
        }
    }
}
