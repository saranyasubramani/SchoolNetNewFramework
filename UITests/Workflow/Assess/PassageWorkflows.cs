using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages;
using UITests.Pages.Components;
using UITests.Pages.Assess;
using UITests.Pages.Assess.Dashboard;
using UITests.Pages.Assess.ItemCentral;
using UITests.Pages.Assess.ItemCentral.ItemCentral;
using UITests.Pages.Assess.ItemCentral.ItemCentralHome;
using UITests.Pages.Assess.ItemCentral.ItemCentralSearchResults;
using UITests.Pages.Assess.ItemCentral.ItemCentralStandardPicker;
using UITests.Pages.Assess.ItemCreateEdit.v01;
using UITests.Pages.Assess.ItemCreateEdit.v01.Components;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditItemAvailability;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditQuestion;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTask;
using UITests.Pages.Assess.ItemCreateEdit.v01.EditTestItem;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemForms;
using UITests.Pages.Assess.ItemCreateEdit.v01.ItemParts;
using UITests.Pages.Assess.ItemCreateEdit.v01.ViewItemStatistics;
using UITests.Pages.Assess.Passage;
using UITests.Pages.Assess.Passage.EditPassage;
using UITests.Pages.Assess.Passage.PassageDetail;
using UITests.Pages.Assess.PrintTest;
using UITests.Pages.Assess.Rubric;
using UITests.Pages.Assess.Scantron;
using UITests.Pages.Assess.Schedule;
using UITests.Pages.Assess.Standards;
using UITests.Pages.Assess.TestCentral;
using UITests.Pages.Assess.TestCreateEdit;
using UITests.Pages.Assess.TestCreateEdit.Components;
using UITests.Pages.Assess.TestCreateEdit.CreateTestBySelectingStandards;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestTunnel;
using UITests.Pages.Assess.TestWindow;
using UITests.Pages.Assess.Track;
using UITests.Pages.Home;
using UITests.Workflow;

namespace UITests.Workflow.Assess
{
    /// <summary>
    /// the passage workflows
    /// </summary>
    public class PassageWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public PassageWorkflows( AssessWorkflows workflows)
            : base()
        {
            AssessWorkflows = workflows;
        }

        //workflows
        public AssessWorkflows AssessWorkflows { get; set; }

        /// <summary>
        /// navigate to the create passage page
        /// </summary>
        /// <returns>Workflows</returns>
        public PassageWorkflows NavigateToCreatePassagePage()
        {
            AssessWorkflows.NavigateToAssessDashboardPage();
            AssessWorkflows.CreateTestPortalPage = null;
            if ((AssessWorkflows.Workflows.IsDistrictAdmin)
                || (AssessWorkflows.Workflows.IsLeadership)
                || (AssessWorkflows.Workflows.IsStudent)
                || (AssessWorkflows.Workflows.IsSystemSetup))
            {
                AssessWorkflows.CreateTestPortalPage = AssessWorkflows.ProfileHomePage.CreateATest();
            }
            if (AssessWorkflows.Workflows.IsTeacher)
            {
                AssessWorkflows.CreateTestPortalPage = AssessWorkflows.TeacherProfileHomePage.CreateATest();
            }
            if (AssessWorkflows.CreateTestPortalPage == null)
            {
                throw new Exception("Navigate to the AssessDashboardPage before trying to use this workflow.");
            }
            AssessWorkflows.EditPassagePage = AssessWorkflows.CreateTestPortalPage.Detail.CreateAPassage();
            if (AssessWorkflows.EditPassagePage.Data == null)
            {//use default data
                AssessWorkflows.EditPassagePage.InitData();
                AssessWorkflows.EditPassagePage.Data.GetTestDataFromResxResource(
                    "UITests.Data.Assess.Passage.PassageResource",
                    "default_" + this.TestConfiguration.ApplicationName, 0);
            }
            return this;
        }

        // <summary>
        /// Navigate to Test Item
        /// </summary>
        /// <returns>Workflows</returns>
        public PassageWorkflows AddNewItem()
        {
            if (AssessWorkflows.PassageDetailPage == null)
            {
                throw new Exception(
                    "The PassageDetailPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.PassageDetailPage.Detail.AddNewItemToPassage();
            return this;
        }
        /// <summary>
        /// navigate to the passage detail page
        /// </summary>
        /// <remarks>requires the CreatePassagePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public PassageWorkflows CreatePassagePageInputFormFields()
        {
            if (AssessWorkflows.EditPassagePage == null)
            {
                throw new Exception(
                    "The EditPassagePage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditPassagePage.Form.InputAndSubmitForm();
            AssessWorkflows.PassageDetailPage = new PassageDetailPage();
            return this;
        }
        /// <summary>
        /// navigate to the passage detail page
        /// </summary>
        /// <remarks>requires the EditPassagePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public PassageWorkflows EditPassagePageInputFormFields()
        {
            if (AssessWorkflows.EditPassagePage == null)
            {
                throw new Exception(
                    "The EditPassagePage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditPassagePage.Form.InputAndSubmitForm();
            AssessWorkflows.PassageDetailPage = new PassageDetailPage();
            return this;
        }

        /// <summary>
        /// passage detail page: click edit
        /// </summary>
        /// <remarks>requires the PassageDetailPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public PassageWorkflows PassageDetailPageEdit()
        {
            if (AssessWorkflows.PassageDetailPage == null)
            {
                throw new Exception(
                    "The PassageDetailPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditPassagePage = AssessWorkflows.PassageDetailPage.Detail.ClickEditLink();
            return this;
        }
    }
}
