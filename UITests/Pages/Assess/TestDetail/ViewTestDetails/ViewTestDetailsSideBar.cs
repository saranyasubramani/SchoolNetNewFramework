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

namespace UITests.Pages.Assess.TestDetail.ViewTestDetails
{
    /// <summary>
    /// the view test details side bar
    /// </summary>
    public class ViewTestDetailsSideBar : SNSide
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="testStage">the test stage, default to "Not Specified"</param>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public ViewTestDetailsSideBar(TestStage testStage, string overrideControlPrefix = null)
            : base()
        {
            if (overrideControlPrefix != null)
            {
                this.ControlPrefix = overrideControlPrefix;
            }
            TestStage = testStage;
            InitElements();
            
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            TestActions = new TestDetailsTestActionsSideBar();
            StatusStudentComments = new TestDetailsStatusStudentCommentsSidebar();
            ScheduleInformation = new TestDetailsScheduleInformationSideBar();
            AssociatedResources = new TestDetailsAssociatedResourcesSideBar();
            TestProperties = new TestDetailsTestPropertiesSideBar();
            CustomizeTest = new TestDetailsCustomizeTestSideBar();
        }

        /// <summary>
        /// the data
        /// </summary>
        public new ViewTestDetailsData Data
        {
            get
            {
                return (ViewTestDetailsData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        private TestStage TestStage { get; set; }
        /// <summary>
        /// test actions side bar
        /// </summary>
        public TestDetailsTestActionsSideBar TestActions { get; private set; }
        /// <summary>
        /// status student comments side bar
        /// </summary>
        public TestDetailsStatusStudentCommentsSidebar StatusStudentComments { get; private set; }
        /// <summary>
        /// schedule information side bar
        /// </summary>
        public TestDetailsScheduleInformationSideBar ScheduleInformation { get; private set; }
        /// <summary>
        /// associated resources side bar
        /// </summary>
        public TestDetailsAssociatedResourcesSideBar AssociatedResources { get; private set; }
        /// <summary>
        /// test properties side bar
        /// </summary>
        public TestDetailsTestPropertiesSideBar TestProperties { get; private set; }
        /// <summary>
        /// customize test side bar
        /// </summary>
        public TestDetailsCustomizeTestSideBar CustomizeTest { get; private set; }
    }
}
