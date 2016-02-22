using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Admin.GeneralSettings.StudentProfile
{
    /// <summary>
    /// StudentProfile form
    /// </summary>
    public class StudentProfileForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix">the override control prefix</param>
        public StudentProfileForm( string overrideControlPrefix = null)
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
            DisplayScoreGroupsCheck = new WebElementWrapper( ByDisplayScoreGroupsCheck);
            ShowGPACheck = new WebElementWrapper( ByShowGPACheck);
            ShowCreditsEarnedCheck = new WebElementWrapper( ByShowCreditsEarnedCheck);
            ShowCreditsAttemptedCheck = new WebElementWrapper( ByShowCreditsAttemptedCheck);
            ShowStudentAttendanceCheck = new WebElementWrapper( ByShowStudentAttendanceCheck);
            DisplaySchoolsStudentIsEnrolledCheck = new WebElementWrapper( ByDisplaySchoolsStudentIsEnrolledCheck);
            ShowAttendanceGroupCheck = new WebElementWrapper( ByShowAttendanceGroupCheck);
            ShowSecondaryStudentIDSelect = new SelectElementWrapper(new WebElementWrapper( ByShowSecondaryStudentIDSelect));
        }

        /// <summary>
        /// the data
        /// </summary>
        public new StudentProfileData Data
        {
            get
            {
                return (StudentProfileData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private string gridCssSelector { get { return "#" + ControlPrefix + "ctl00_AdminControl_ctrlConfigureStudAttendanceGrp_DataGridMastery"; } }
        /// <summary>
        /// the grid
        /// </summary>
        public AttendanceGroupGrid AttendanceGroupGrid { get; private set; }
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.CssSelector(".btn.btn-primary"); } }
        /// <summary>
        /// cancel by
        /// </summary>
        public override By ByCancel { get { return By.Id(ControlPrefix + "ctl00_AdminControl_Linkbutton2"); } }
        public By ByDisplayScoreGroupsCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_CheckBoxDisplayScoreGroups"); } }
        public WebElementWrapper DisplayScoreGroupsCheck { get; private set; }
        public By ByShowGPACheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_chkShowGPA"); } }
        public WebElementWrapper ShowGPACheck { get; private set; }
        public By ByShowCreditsEarnedCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_chkShowCreditsEarned"); } }
        public WebElementWrapper ShowCreditsEarnedCheck { get; private set; }
        public By ByShowCreditsAttemptedCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_chkShowCreditsAttempted"); } }
        public WebElementWrapper ShowCreditsAttemptedCheck { get; private set; }
        public By ByShowStudentAttendanceCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_chkShowAttendance"); } }
        public WebElementWrapper ShowStudentAttendanceCheck { get; private set; }
        public By ByDisplaySchoolsStudentIsEnrolledCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_chkShowSchools"); } }
        public WebElementWrapper DisplaySchoolsStudentIsEnrolledCheck { get; private set; }
        public By ByShowAttendanceGroupCheck { get { return By.Id(ControlPrefix + "ctl00_AdminControl_ctrlConfigureStudAttendanceGrp_chkShowAttendanceGrp"); } }
        public WebElementWrapper ShowAttendanceGroupCheck { get; private set; }
        public By ByShowSecondaryStudentIDSelect { get { return By.Id(ControlPrefix + "ctl00_AdminControl_ddlSecondaryID"); } }
        public SelectElementWrapper ShowSecondaryStudentIDSelect { get; private set; }

        /// <summary>
        /// check display score groups
        /// </summary>
        public void CheckDisplayScoreGroups()
        {
            DisplayScoreGroupsCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck display score groups
        /// </summary>
        public void UnCheckDisplayScoreGroups()
        {
            DisplayScoreGroupsCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// check show GPA
        /// </summary>
        public void CheckShowGPA()
        {
            ShowGPACheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck show GPA
        /// </summary>
        public void UnCheckShowGPA()
        {
            ShowGPACheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// check show credits earned
        /// </summary>
        public void CheckShowCreditsEarned()
        {
            ShowCreditsEarnedCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck show credits earned
        /// </summary>
        public void UnCheckShowCreditsEarned()
        {
            ShowCreditsEarnedCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// check show credits attempted
        /// </summary>
        public void CheckShowCreditsAttempted()
        {
            ShowCreditsAttemptedCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck show credits attempted
        /// </summary>
        public void UnCheckShowCreditsAttempted()
        {
            ShowCreditsAttemptedCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// check show student attendance
        /// </summary>
        public void CheckShowStudentAttendance()
        {
            ShowStudentAttendanceCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck show student attendance
        /// </summary>
        public void UnCheckShowStudentAttendance()
        {
            ShowStudentAttendanceCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// check display school student is enrolled
        /// </summary>
        public void CheckDisplaySchoolsStudentIsEnrolled()
        {
            DisplaySchoolsStudentIsEnrolledCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck display school student is enrolled
        /// </summary>
        public void UnCheckDisplaySchoolsStudentIsEnrolled()
        {
            DisplaySchoolsStudentIsEnrolledCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// check show attendance group
        /// </summary>
        public void CheckShowAttendanceGroup()
        {
            ShowAttendanceGroupCheck.Wait(3).Check();
            AttendanceGroupGrid = new AttendanceGroupGrid(gridCssSelector, true, this.ControlPrefix);
            AttendanceGroupGrid.SetGridLists();

        }
        /// <summary>
        /// uncheck show attendance group
        /// </summary>
        public void UnCheckShowAttendanceGroup()
        {
            ShowAttendanceGroupCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// show secondary student ID
        /// </summary>
        public void SelectShowSecondaryStudentID()
        {
            ShowSecondaryStudentIDSelect.Wait(3).SelectByText(Data.SecondaryStudentID);
        }
        /// <summary>
        /// find row
        /// </summary>
        /// <returns>AttendanceGroupRow</returns>
        public AttendanceGroupRow FindRow()
        {
            //Report.Write("martin data: " + Data.AttendanceGroupName);
            return AttendanceGroupGrid.GetsFirstRowContainingTextToFindFromList(
                    AttendanceGroupColumnNames.AttendanceGroupName, Data.AttendanceGroupName);
        }
        /// <summary>
        /// verify min range
        /// </summary>
        public void VerifyMinRange()
        {
            AttendanceGroupRow attendanceGroupRow = FindRow();
            string minRangeStr = attendanceGroupRow.GetMinRange();
            int minRange = Convert.ToInt32(minRangeStr.Trim());
            Assert.AreEqual(minRange, Data.MinRange,
                "The expected minimum range: '" + Data.MinRange + "' does not match the actual minimum range: '" + minRange + "'.");
        }
        /// <summary>
        /// verify max range
        /// </summary>
        public void VerifyMaxRange()
        {
            AttendanceGroupRow attendanceGroupRow = FindRow();
            string maxRange = attendanceGroupRow.GetMaxRange();
            Assert.IsTrue(maxRange.Trim().Contains(Convert.ToString(Data.MaxRange)),
                "The expected maximum range: '" + Data.MaxRange + "' does not match the actual maximum range: '" + maxRange + "'.");
        }
        /// <summary>
        /// edit row attendance group name
        /// </summary>
        public void EditRowAttendanceGroupName()
        {
            AttendanceGroupRow attendanceGroupRow = FindRow();
            attendanceGroupRow.SetAttendanceGroupName(Data.AttendanceGroupName);
        }
        /// <summary>
        /// edit row max range
        /// </summary>
        public void EditRowMaxRange()
        {
            AttendanceGroupRow attendanceGroupRow = FindRow();
            attendanceGroupRow.SetMaxRange(Data.MaxRange);
        }
    }
}
