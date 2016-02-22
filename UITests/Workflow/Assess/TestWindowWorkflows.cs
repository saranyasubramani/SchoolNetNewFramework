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
using UITests.Pages.Assess.Schedule.EditSchedule;
using UITests.Pages.Assess.Schedule.EditAssignmentCourse;
using UITests.Pages.Assess.Standards;
using UITests.Pages.Assess.TestCentral;
using UITests.Pages.Assess.TestCreateEdit;
using UITests.Pages.Assess.TestCreateEdit.Components;
using UITests.Pages.Assess.TestCreateEdit.CreateTestBySelectingStandards;
using UITests.Pages.Assess.TestDetail;
using UITests.Pages.Assess.TestDetail.ViewTestDetails;
using UITests.Pages.Assess.TestTunnel;
using UITests.Pages.Assess.TestWindow;
using UITests.Pages.Assess.TestWindow.CreateEditTestWindow;
using UITests.Pages.Assess.TestWindow.PlanHome;
using UITests.Pages.Assess.TestWindow.ViewTestWindow;
using UITests.Pages.Assess.Track;
using UITests.Pages.Home;
using UITests.Workflow;

namespace UITests.Workflow.Assess
{
    /// <summary>
    /// the create test window workflows
    /// </summary>
    public class TestWindowWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public TestWindowWorkflows(AssessWorkflows workflows)
            : base()
        {
            AssessWorkflows = workflows;
        }

        //workflows
        public AssessWorkflows AssessWorkflows { get; set; }

        /// <summary>
        /// navigate to the create test window page
        /// </summary>
        /// <returns>Workflows</returns>
        public TestWindowWorkflows NavigateToCreateNewTestWindow()
        {

            if (AssessWorkflows.PlanHomePage == null)
            {
                throw new Exception("Navigate to the PlanHomePage before trying to use this workflow.");
            }
            AssessWorkflows.CreateEditTestWindowPage = AssessWorkflows.PlanHomePage.Detail.SelectCreateNewTestWindow();
            return this;
        }

        /// <summary>
        /// create edit test window page clear fields
        /// </summary>
        /// <returns>Workflows</returns>
        public TestWindowWorkflows CreateEditTestWindowPageClearFields()
        {
            if (AssessWorkflows.CreateEditTestWindowPage == null)
            {
                throw new Exception("Navigate to the CreateEditTestWindowPage before trying to use this workflow.");
            }
            AssessWorkflows.CreateEditTestWindowPage.Form.ClearForm();
            return this;
        }
        /// <summary>
        /// create edit test window page input form fields and submit
        /// </summary>
        /// <returns>Workflows</returns>
        public TestWindowWorkflows CreateEditTestWindowPageInputAndSubmitForm()
        {
            if (AssessWorkflows.CreateEditTestWindowPage == null)
            {
                throw new Exception("Navigate to the CreateEditTestWindowPage before trying to use this workflow.");
            }
            AssessWorkflows.CreateEditTestWindowPage.Form.InputAndSubmitForm();
            //next page could be different depending to the workflow
            return this;
        }

        /// <summary>
        /// plan home page clear all fields
        /// </summary>
        /// <returns>Workflows</returns>
        public TestWindowWorkflows PlanHomePageClearFields()
        {
            if (AssessWorkflows.PlanHomePage == null)
            {
                throw new Exception("Navigate to the PlanHomePage before trying to use this workflow.");
            }
            AssessWorkflows.PlanHomePage.Form.ClearForm();
            return this;
        }
        /// <summary>
        /// plan home page find a test window
        /// </summary>
        /// <returns>Workflows</returns>
        public TestWindowWorkflows PlanHomePageFindATestWindow()
        {
            if (AssessWorkflows.PlanHomePage == null)
            {
                throw new Exception("Navigate to the PlanHomePage before trying to use this workflow.");
            }
            AssessWorkflows.PlanHomePage.Form.InputAndSubmitForm();
            //next page
            PlanHomeData previousData = (PlanHomeData)AssessWorkflows.PlanHomePage.Data;
            AssessWorkflows.PlanHomePage = new PlanHomePage();
            AssessWorkflows.PlanHomePage.Data = previousData;
            return this;
        }
        /// <summary>
        /// plan home page select test window
        /// </summary>
        /// <returns>Workflows</returns>
        public TestWindowWorkflows PlanHomePageSelectTestWindowByName()
        {
            if (AssessWorkflows.PlanHomePage == null)
            {
                throw new Exception("Navigate to the PlanHomePage before trying to use this workflow.");
            }
            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                List<IWebElement> row = AssessWorkflows.PlanHomePage.Form.Grid.GetDummyElementsDataRows();
                ((DummyWebElement)row[0]).Text = ((PlanHomeData)AssessWorkflows.PlanHomePage.Data).TestWindowName;
            }
            AssessWorkflows.PlanHomePage.Form.SelectTestWindowName();
            //next page
            ViewTestWindowData previousData = null; //remember previous data
            if (AssessWorkflows.ViewTestWindowPage != null && AssessWorkflows.ViewTestWindowPage.Data != null)
            {
                //if previous page data exist
                previousData = (ViewTestWindowData)AssessWorkflows.ViewTestWindowPage.Data;
            }
            AssessWorkflows.ViewTestWindowPage = new ViewTestWindowPage();
            AssessWorkflows.ViewTestWindowPage.Data = previousData;
            return this;
        }


        /// <summary>
        /// view test window page edit test window
        /// </summary>
        /// <returns>Workflows</returns>
        public TestWindowWorkflows ViewTestWindowPageEditTestWindow()
        {
            if (AssessWorkflows.ViewTestWindowPage == null)
            {
                throw new Exception("Navigate to the ViewTestWindowPage before trying to use this workflow.");
            }
            AssessWorkflows.ViewTestWindowPage.Detail.SelectEditTestWindow();
            CreateEditTestWindowData previousData = null; //remember previous data
            if (AssessWorkflows.CreateEditTestWindowPage != null && AssessWorkflows.CreateEditTestWindowPage.Data != null)
            {
                //if previous page data exist
                previousData = (CreateEditTestWindowData)AssessWorkflows.CreateEditTestWindowPage.Data;
            }
            AssessWorkflows.CreateEditTestWindowPage = new CreateEditTestWindowPage();
            AssessWorkflows.CreateEditTestWindowPage.Data = previousData;
            return this;
        }
        /// <summary>
        /// view test window page delete test window
        /// </summary>
        /// <returns>Workflows</returns>
        public TestWindowWorkflows ViewTestWindowPageDeleteTestWindow()
        {
            if (AssessWorkflows.ViewTestWindowPage == null)
            {
                throw new Exception("Navigate to the ViewTestWindowPage before trying to use this workflow.");
            }
            AssessWorkflows.ViewTestWindowPage.Detail.SelectDeleteTestWindow();
            //next page
            PlanHomeData previousData = null; //remember previous data
            if (AssessWorkflows.PlanHomePage != null && AssessWorkflows.PlanHomePage.Data != null)
            {
                previousData = (PlanHomeData)AssessWorkflows.PlanHomePage.Data;
            }
            AssessWorkflows.PlanHomePage = new PlanHomePage();
            AssessWorkflows.PlanHomePage.Data = previousData;
            return this;
        }
        /// <summary>
        /// view test window page click on view details link
        /// </summary>
        /// <returns>Workflows</returns>
        public TestWindowWorkflows ViewTestWindowPageSelectViewDetails()
        {
            if (AssessWorkflows.ViewTestWindowPage == null)
            {
                throw new Exception("Navigate to the ViewTestWindowPage before trying to use this workflow.");
            }
            AssessWorkflows.ViewTestWindowPage.Detail.SelectViewDetails();
            ViewTestDetailsData previousData = null; //remember previous data
            if (AssessWorkflows.ViewTestDetailsPage != null && AssessWorkflows.ViewTestDetailsPage.Data != null)
            {
                //if previous page data exist
                previousData = (ViewTestDetailsData)AssessWorkflows.ViewTestDetailsPage.Data;
            }
            AssessWorkflows.ViewTestDetailsPage = new ViewTestDetailsPage();
            AssessWorkflows.ViewTestDetailsPage.Data = previousData;
            return this;
        }
        /// <summary>
        /// view test window page go back to previous page
        /// </summary>
        /// <returns>Workflows</returns>
        public TestWindowWorkflows ViewTestWindowPageBackToPreviousPage()
        {
            if (AssessWorkflows.ViewTestWindowPage == null)
            {
                throw new Exception("Navigate to the ViewTestWindowPage before trying to use this workflow.");
            }
            AssessWorkflows.ViewTestWindowPage.Detail.SelectBackToPreviousPage();
            return this;
        }
        /// <summary>
        /// view test window page find a manual test
        /// </summary>
        /// <returns>Workflows</returns>
        public TestWindowWorkflows ViewTestWindowPageFindATest()
        {
            if (AssessWorkflows.ViewTestWindowPage == null)
            {
                throw new Exception("Navigate to the ViewTestWindowPage before trying to use this workflow.");
            }
            AssessWorkflows.ViewTestWindowPage.Form.InputAndSubmitForm();
            ViewTestWindowData previousData = null; //remember previous data
            if (AssessWorkflows.ViewTestWindowPage != null && AssessWorkflows.ViewTestWindowPage.Data != null)
            {
                //if previous page data exist
                previousData = (ViewTestWindowData)AssessWorkflows.ViewTestWindowPage.Data;
            }
            AssessWorkflows.ViewTestWindowPage = new ViewTestWindowPage();
            AssessWorkflows.ViewTestWindowPage.Data = previousData;
            return this;
        }
        /// <summary>
        /// view test window page click on select link to link to a test window
        /// Index start 1, 2 ,3 ...
        /// </summary>
        /// <returns>Workflows</returns>
        public TestWindowWorkflows ViewTestWindowPageSelectATestToLinkTestWindow(int index)
        {
            if (AssessWorkflows.ViewTestWindowPage == null)
            {
                throw new Exception("Navigate to the ViewTestWindowPage before trying to use this workflow.");
            }
            AssessWorkflows.ViewTestWindowPage.Detail.SelectTestUsingSelectLink(index);
            ViewTestWindowData previousData = null; //remember previous data
            if (AssessWorkflows.ViewTestWindowPage != null && AssessWorkflows.ViewTestWindowPage.Data != null)
            {
                //if previous page data exist
                previousData = (ViewTestWindowData)AssessWorkflows.ViewTestWindowPage.Data;
            }
            AssessWorkflows.ViewTestWindowPage = new ViewTestWindowPage();
            AssessWorkflows.ViewTestWindowPage.Data = previousData;
            return this;
        }
        /// <summary>
        /// view test window page click on unlink button
        /// </summary>
        /// <returns>Workflows</returns>
        public TestWindowWorkflows ViewTestWindowPageUnlinkTest()
        {
            if (AssessWorkflows.ViewTestWindowPage == null)
            {
                throw new Exception("Navigate to the ViewTestWindowPage before trying to use this workflow.");
            }
            AssessWorkflows.ViewTestWindowPage.Detail.SelectUnlink();
            ViewTestWindowData previousData = null; //remember previous data
            if (AssessWorkflows.ViewTestWindowPage != null && AssessWorkflows.ViewTestWindowPage.Data != null)
            {
                //if previous page data exist
                previousData = (ViewTestWindowData)AssessWorkflows.ViewTestWindowPage.Data;
            }
            AssessWorkflows.ViewTestWindowPage = new ViewTestWindowPage();
            AssessWorkflows.ViewTestWindowPage.Data = previousData;
            return this;
        }
        /// <summary>
        /// view test window page click on test name link
        /// Index start 1, 2 ,3 ...
        /// </summary>
        /// <returns>Workflows</returns>
        public TestWindowWorkflows ViewTestWindowPageSelectTestByTestName(string testname)
        {
            if (AssessWorkflows.ViewTestWindowPage == null)
            {
                throw new Exception("Navigate to the ViewTestWindowPage before trying to use this workflow.");
            }
            AssessWorkflows.ViewTestWindowPage.Detail.SelectTestByTestname(testname);
            ViewTestDetailsData previousData = null; //remember previous data
            if (AssessWorkflows.ViewTestDetailsPage != null && AssessWorkflows.ViewTestDetailsPage.Data != null)
            {
                //if previous page data exist
                previousData = (ViewTestDetailsData)AssessWorkflows.ViewTestDetailsPage.Data;
            }
            AssessWorkflows.ViewTestDetailsPage = new ViewTestDetailsPage();
            AssessWorkflows.ViewTestDetailsPage.Data = previousData;
            return this;
        }

    }
}
