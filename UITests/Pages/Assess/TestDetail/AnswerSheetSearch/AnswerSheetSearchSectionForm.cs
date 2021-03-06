﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.TestDetail.AnswerSheetSearch
{
    /// <summary>
    /// answer sheet generation form, section tab
    /// </summary>
    public class AnswerSheetSearchSectionForm : SNForm
    {
        /// <summary>
        /// the answer sheet section tab (form) constructor
        /// </summary>        
        public AnswerSheetSearchSectionForm(  string overrideControlPrefix = null)
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
            DepartmentDropdown = new SelectElementWrapper(new WebElementWrapper( ByDepartmentDropdown));
            CourseDropdown = new SelectElementWrapper(new WebElementWrapper(ByCourseDropdown));
            TeacherDropdown = new SelectElementWrapper(new WebElementWrapper( ByTeacherDropdown));
            SearchCriteria = new AnswerSheetSearchCriteria();
        }

        /// <summary>
        /// the data
        /// </summary>
        public new AnswerSheetSearchData Data
        {
            get
            {
                return (AnswerSheetSearchData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private string ControlPrefix2 = "SectionFinderControl_";
        // LOCATORS
        private AnswerSheetSearchCriteria SearchCriteria { get; set; }
        //ctl00_MainContent_SectionFinderControl_cbxDepartment
        private By ByDepartmentDropdown { get { return By.Id(ControlPrefix + ControlPrefix2 + "cbxDepartment"); } }
        private SelectElementWrapper DepartmentDropdown { get; set; }
        //ctl00_MainContent_SectionFinderControl_cbxCourse
        private By ByCourseDropdown { get { return By.Id(ControlPrefix + ControlPrefix2 + "cbxCourse"); } }
        private SelectElementWrapper CourseDropdown { get; set; }
        //ctl00_MainContent_SectionFinderControl_cbxTeacher
        private By ByTeacherDropdown { get { return By.Id(ControlPrefix + ControlPrefix2 + "cbxTeacher"); } }
        private SelectElementWrapper TeacherDropdown { get; set; }
        //ctl00_MainContent_SectionFinderControl_ButtonGo
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + ControlPrefix2 + "ButtonGo"); } }

        /// <summary>
        /// check include section checkbox
        /// </summary>
        public void ClickIncludeSection()
        {
            SearchCriteria.ClickIncludeSection();
        }

        /// <summary>
        /// input search criteria and submit search
        /// </summary>
        public override void InputFormFields()
        {
            SearchCriteria.Data = this.Data;
            SearchCriteria.InputFormFields();

            if (Data.Department != null)
            {
                DepartmentDropdown.Wait(3).SelectByText(Data.Department);
            }
            if (Data.Course != null)
            {
                CourseDropdown.Wait(3).SelectByText(Data.Course);
            }
            if (Data.Teacher != null)
            {
                TeacherDropdown.Wait(3).SelectByText(Data.Teacher);
            }
        }
    }
}
