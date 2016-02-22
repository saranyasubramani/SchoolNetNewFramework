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
    /// the create express test workflows
    /// </summary>
    public class CreateExpressTestWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public CreateExpressTestWorkflows( AssessWorkflows workflows)
            : base()
        {
            AssessWorkflows = workflows;
        }

        //workflows
        public AssessWorkflows AssessWorkflows { get; set; }

        /// <summary>
        /// navigate to the create express test page
        /// </summary>
        /// <returns>Workflows</returns>
        public CreateExpressTestWorkflows NavigateToCreateExpressTestPage()
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
            AssessWorkflows.CreateTestExpressPage = AssessWorkflows.CreateTestPortalPage.Detail.CreateExpressTest();
            if (AssessWorkflows.CreateTestExpressPage.Data == null)
            {//use default data
                AssessWorkflows.CreateTestExpressPage.InitData();
                AssessWorkflows.CreateTestExpressPage.Data.GetTestDataFromResxResource(
                    "UITests.Data.Assess.TestCreateEdit.CreateTestResource",
                    "default_" + this.TestConfiguration.ApplicationName, 0);
            }
            return this;
        }

        /// <summary>
        /// create express test page, select answer key only, "yes" radio button
        /// </summary>
        /// <remarks>requires the CreateTestExpressPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateExpressTestWorkflows CreateExpressTestSelectAnswerKeyOnlyYes()
        {
            if (AssessWorkflows.CreateTestExpressPage == null)
            {
                throw new Exception("The CreateTestExpressPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestExpressPage.Form.SelectAnswerKeyOnlyYes();
            return this;
        }
        /// <summary>
        /// create express test page input form fields
        /// </summary>
        /// <remarks>requires the CreateTestExpressPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateExpressTestWorkflows CreateExpressTestPageInputFormFields()
        {
            if (AssessWorkflows.CreateTestExpressPage == null)
            {
                throw new Exception("The CreateTestExpressPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestExpressPage.Form.InputFormFields();
            return this;
        }

        /// <summary>
        /// submit create express test page
        /// </summary>
        /// <remarks>requires the CreateTestExpressPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateExpressTestWorkflows CreateExpressTestPageSubmitForm()
        {
            if (AssessWorkflows.CreateTestExpressPage == null)
            {
                throw new Exception("The CreateTestExpressPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.CreateTestBySelectingStandardsPage = (CreateTestBySelectingStandardsPage)AssessWorkflows.CreateTestExpressPage.Form.SubmitForm();
            return this;
        }

        /// <summary>
        /// express test page, select a standard
        /// </summary>
        /// <remarks>requires the CreateTestBySelectingStandardsPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateExpressTestWorkflows CreateTestBySelectingStandardsPage_SelectStandard(string standardName)
        {
            if (AssessWorkflows.CreateTestBySelectingStandardsPage == null)
            {
                throw new Exception("The CreateTestBySelectingStandardsPage is null, please initialize it before trying to use it in a workflow.");
            }
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                AssessWorkflows.CreateTestBySelectingStandardsPage.Form.StandardPickerForm.FakeText = standardName;
            }
            AssessWorkflows.CreateTestBySelectingStandardsPage.Form.StandardPickerForm.SelectStandardDocument();
            AssessWorkflows.CreateTestBySelectingStandardsPage.Form.StandardPickerForm.SelectStandardInGroupByName(standardName);
            AssessWorkflows.CreateTestBySelectingStandardsPage.Form.StandardPickerForm.SubmitForm();
            //Handle postback
            CreateTestBySelectingStandardsData data =
                (CreateTestBySelectingStandardsData)AssessWorkflows.CreateTestBySelectingStandardsPage.Data;
            AssessWorkflows.CreateTestBySelectingStandardsPage = new CreateTestBySelectingStandardsPage();
            AssessWorkflows.CreateTestBySelectingStandardsPage.Data = data;
            return this;
        }

        /// <summary>
        /// express test page, enter item number
        /// </summary>
        /// <remarks>requires the CreateTestBySelectingStandardsPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateExpressTestWorkflows CreateTestBySelectingStandardsPage_InputItem(int standardId)
        {
            if (AssessWorkflows.CreateTestBySelectingStandardsPage == null)
            {
                throw new Exception("The CreateTestBySelectingStandardsPage is null, please initialize it before trying to use it in a workflow.");
            }
            int numberOfItem =
                ((CreateTestBySelectingStandardsData)AssessWorkflows.CreateTestBySelectingStandardsPage.Data).NumberOfItem;
            AssessWorkflows.CreateTestBySelectingStandardsPage.Form.SetAvailableStandardItemQuantity(standardId, numberOfItem);
            AssessWorkflows.ViewTestDetailsPage = (ViewTestDetailsPage)AssessWorkflows.CreateTestBySelectingStandardsPage.Form.SubmitForm();

            return this;
        }

        /// <summary>
        /// view test detail page, make test public
        /// </summary>
        /// <remarks>requires the ViewTestDetailsPage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public CreateExpressTestWorkflows ViewTestDetailsPage_MakePublic()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception("The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ViewTestDetailsPage = AssessWorkflows.ViewTestDetailsPage.MakePublic();

            return this;
        }
    }
}
