using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;

namespace UITests.Pages.Assess.Schedule.ViewAssignmentSummary
{
    /// <summary>
    /// View Assignment Summary form
    /// </summary>
    public class ViewAssignmentSummaryForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override Control Prefix</param>
        /// <param name="assignmentType">assignment type</param>
        public ViewAssignmentSummaryForm(string overrideControlPrefix = null, string assignmentType = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            this.assignmentType = assignmentType;
            if (assignmentType == null)
            {
                assignmentType = ViewAssignmentSummaryType.AssignToStudents;
            }
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            Grid = new ViewAssignmentSummaryGrid( courseGrid);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new ViewAssignmentSummaryData Data
        {
            get
            {
                return (ViewAssignmentSummaryData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private string assignmentType;
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ButtonDone"); } }
        private string courseGrid { get { return "div.section_container > div:nth-of-type(" + assignmentType + ")"; } }
        public ViewAssignmentSummaryGrid Grid { get; set; }

    }
}
