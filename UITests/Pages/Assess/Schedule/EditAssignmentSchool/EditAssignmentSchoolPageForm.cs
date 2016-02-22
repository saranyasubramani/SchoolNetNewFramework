using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.Schedule.EditAssignmentSchool
{
    /// <summary>
    /// Select School: Edit Assignment School form
    /// </summary>
    public class EditAssignmentSchoolPageForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public EditAssignmentSchoolPageForm(string overrideControlPrefix = null)
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
            Region_dropdown = new SelectElementWrapper(new WebElementWrapper(ByRegion_dropdown));
            SchoolType_dropdown = new SelectElementWrapper(new WebElementWrapper(BySchoolType_dropdown));
            AssignedSchoolName_chkbox = new WebElementWrapper(ByAssignedSchoolName_chkbox);
            AvailableSchoolName_chkbox = new WebElementWrapper(ByAvailableSchoolName_chkbox);
            AvailableFirstSchoolName_chkbox = new WebElementWrapper(ByAvailableFirstSchoolName_chkbox);
            ResultsPerPage_dropdown = new SelectElementWrapper(new WebElementWrapper(ByResultsPerPage_dropdown));
        }

        /// <summary>
        /// the data
        /// </summary>
        public new EditAssignmentSchoolData Data
        {
            get
            {
                return (EditAssignmentSchoolData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        //Select School elements
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ButtonDone"); } }
        public By ByRegion_dropdown { get { return By.Id(ControlPrefix + "cbxRegion"); } }
        public SelectElementWrapper Region_dropdown { get; private set; }
        public By BySchoolType_dropdown { get { return By.Id(ControlPrefix + "bxSchoolType"); } }
        public SelectElementWrapper SchoolType_dropdown { get; private set; }
        public By ByGo_button { get { return By.Id(ControlPrefix + "ButtonGetSchools"); } }
        public WebElementWrapper Go_button { get { return new WebElementWrapper(ByGo_button); } }
        //Choose School elements
        public By ByAddSelected_button { get { return By.Id(ControlPrefix + "ButtonAdd"); } }
        public WebElementWrapper AddSelected_button { get { return new WebElementWrapper(ByAddSelected_button); } }
        public By ByRemoveSelected_button { get { return By.Id(ControlPrefix + "ButtonRemove"); } }
        public WebElementWrapper RemoveSelected_button { get { return new WebElementWrapper(ByRemoveSelected_button); } }
        public By ByAssignedSchoolName_chkbox { get { return By.Id("chkSelectAllAssignedSchool"); } }
        public WebElementWrapper AssignedSchoolName_chkbox { get; private set; }
        public By ByAvailableSchoolName_chkbox { get { return By.Id("chkSelectAllAvailableSchool"); } }
        public WebElementWrapper AvailableSchoolName_chkbox { get; private set; }
        //public By ByAvailableFirstSchoolName_chkbox { get { return By.Id(ControlPrefix + "GridAvailableSchools(3)"); } }
        public By ByAvailableFirstSchoolName_chkbox { get { return By.Id(ControlPrefix + "GridAvailableSchools_ctl03_CheckBoxAvailableSchool"); } }
        public WebElementWrapper AvailableFirstSchoolName_chkbox { get; private set; }
        public By ByResultsPerPage_dropdown { get { return By.Id(ControlPrefix + "GridAvailableSchools_ctl104_ddlResultsPerPage"); } }
        public SelectElementWrapper ResultsPerPage_dropdown { get; private set; }

        /// <summary>
        /// SelectCourseName method to check/uncheck checkbox 
        /// Parameters:
        /// WebElementWrapper checkBox 
        /// bool status = true  - check the checkbox
        /// bool status = false - uncheck the checkbox
        /// </summary>
        /// <param name="checkBox"></param>
        /// <param name="status"></param>
        public void CheckBoxClick(WebElementWrapper checkBox, bool status)
        {
            switch (status)
            {
                case true:
                    if (!checkBox.Selected) { checkBox.Click(); }
                    break;
                case false:
                    if (checkBox.Selected) { checkBox.Click(); }
                    break;
            }
        }

        /// <summary>
        /// Click Go button
        /// </summary>
        public void ClickGo()
        {
            Report.Write("Clicked on Go button.");
            Go_button.Wait(3).Click();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();
        }

        /// <summary>
        /// Click Add Selected button
        /// </summary>
        public void ClickAddSelected()
        {
            Report.Write("Clicked on Add Selected button.");
            AddSelected_button.Wait(3).Click();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();
        }

        /// <summary>
        /// Click Remove Selected button
        /// </summary>
        public void ClickRemoveSelected()
        {
            Report.Write("Clicked on Remove Selected button.");
            RemoveSelected_button.Wait(3).Click();
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();
        }

        /// <summary>
        /// Check Assigned Schools checkbox
        /// </summary>
        public void CheckBoxAssignedSchoolName()
        {
            CheckBoxClick(AssignedSchoolName_chkbox, true);
        }

        /// <summary>
        /// Check Avalabale Schools checkbox
        /// </summary>
        public void CheckBoxAvailableSchoolName()
        {
            CheckBoxClick(AvailableSchoolName_chkbox, true);
        }


        /// <summary>
        /// Check First Avalabale Schools checkbox (Aaron elementary)
        /// </summary>
        public void CheckBoxFirstAvailableSchoolName()
        {
            CheckBoxClick(AvailableFirstSchoolName_chkbox, true);
        }

        /// <summary>
        /// Select Region
        /// </summary>
        public void SelectRegion(string Region)
        {
            Region_dropdown.SelectByText(Region);
        }

        /// <summary>
        /// Select Results Per Page
        /// </summary>
        public void SelectResultsPerPage(string NumberOfResults)
        {
            ResultsPerPage_dropdown.SelectByText(NumberOfResults);
            this.DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();
        }


        //OVERRIDDEN FUNCTIONS

        public override void InputFormFields()
        {
            if (Data.RemoveSelected != null)
            {
                if (Data.RemoveSelected == "1")
                {
                    ClickRemoveSelected();
                }
            }
            if (Data.Region != null)
            {
                Region_dropdown.SelectByText(Data.Region);
            }
            if (Data.SchoolType != null)
            {
                SchoolType_dropdown.SelectByText(Data.SchoolType);
            }

            if (Data.AddSelected != null)
            {
                if (Data.AddSelected == "1")
                {
                    ClickAddSelected();
                }
            }
            if (Data.AssignedSchoolName != null)
            {
                if (Data.AssignedSchoolName.Equals("1"))
                {
                    CheckBoxClick(AssignedSchoolName_chkbox, true);
                }
            }
            if (Data.AvailableSchoolName != null)
            {
                if (Data.AvailableSchoolName.Equals("1"))
                {
                    CheckBoxClick(AvailableSchoolName_chkbox, true);
                }
            }
        }
    }
}
