using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Assess.Components;
using UITests.Pages.Assess.TestDetail;

namespace UITests.Pages.Assess.Schedule.EditTeacherAssignment
{
    /// <summary>
    /// The edit teacher assignment detail
    /// </summary>
    public class EditTeacherAssignmentDetail : SNDetail
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public EditTeacherAssignmentDetail(string overrideControlPrefix = null)
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
            TestStages = new TestStages(PageNames.EditTeacherAssignment);
            ViewDetailsLink = new WebElementWrapper(ByViewDetailsLink);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new EditTeacherAssignmentData Data
        {
            get
            {
                return (EditTeacherAssignmentData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private TestStages TestStages { get; set; }
        private By ByViewDetailsLink { get { return By.Id(ControlPrefix + "SelectedTestDisplayControl_HyperLinkViewDetails"); } }
        private WebElementWrapper ViewDetailsLink { get; set; }

        /// <summary>
        /// select view details
        /// </summary>
        /// <returns>ViewTestDetailsPage</returns>
        public ViewTestDetailsPage SelectViewDetails()
        {
            ViewDetailsLink.Wait(3).Click();
            return new ViewTestDetailsPage();
        }
    }
}
