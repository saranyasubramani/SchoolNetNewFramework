using System;
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
    /// answer sheet search criteria
    /// </summary>
    public class AnswerSheetSearchCriteria : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override Control Prefix</param>
        public AnswerSheetSearchCriteria(string overrideControlPrefix = null)
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
            RegionDropdown = new SelectElementWrapper(new WebElementWrapper(ByRegionDropdown));
            SchoolTypeDropdown = new SelectElementWrapper(new WebElementWrapper(BySchoolTypeDropdown));
            SchoolDropdown = new SelectElementWrapper(new WebElementWrapper(BySchoolDropdown));
            GradeDropdown = new SelectElementWrapper(new WebElementWrapper(ByGradeDropdown));
            IncludeSectionCheckbox = new WebElementWrapper(ByIncludeSectionCheckbox);
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
        //ctl00_MainContent_SectionFinderControl_cbxRegion
        private By ByRegionDropdown { get { return By.Id(ControlPrefix + ControlPrefix2 + "cbxRegion"); } }
        private SelectElementWrapper RegionDropdown { get; set; }
        //ctl00_MainContent_SectionFinderControl_cbxSchoolType
        private By BySchoolTypeDropdown { get { return By.Id(ControlPrefix + ControlPrefix2 + "cbxSchoolType"); } }
        private SelectElementWrapper SchoolTypeDropdown { get; set; }
        //ctl00_MainContent_SectionFinderControl_cbxSchool
        private By BySchoolDropdown { get { return By.Id(ControlPrefix + ControlPrefix2 + "cbxSchool"); } }
        private SelectElementWrapper SchoolDropdown { get; set; }
        //ctl00_MainContent_SectionFinderControl_cbxGradeLevel
        private By ByGradeDropdown { get { return By.Id(ControlPrefix + ControlPrefix2 + "cbxGradeLevel"); } }
        private SelectElementWrapper GradeDropdown { get; set; }
        //ctl00_MainContent_SectionFinderControl_CheckBoxIncludeUnassigned
        private By ByIncludeSectionCheckbox { get { return By.Id(ControlPrefix + ControlPrefix2 + "CheckBoxIncludeUnassigned"); } }
        private WebElementWrapper IncludeSectionCheckbox { get; set; }

        /// <summary>
        /// include section
        /// </summary>
        public void ClickIncludeSection()
        {
            IncludeSectionCheckbox.Wait(3).Click();
        }

        //implemented methods
        public override void InputFormFields()
        {
            if (Data.Region != null)
            {
                RegionDropdown.Wait(3).SelectByText(Data.Region);
            }
            if (Data.SchoolType != null)
            {
                SchoolTypeDropdown.Wait(3).SelectByText(Data.SchoolType);
            }
            if (Data.School != null)
            {
                SchoolDropdown.Wait(3).SelectByText(Data.School);
            }
            if (Data.Grade != null)
            {
                GradeDropdown.Wait(3).SelectByText(Data.Grade);
            }
        }
    }
}
