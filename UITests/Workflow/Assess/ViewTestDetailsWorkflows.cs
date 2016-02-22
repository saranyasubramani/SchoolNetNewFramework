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
using UITests.Pages.Assess.TestDetail.ViewTestDetails;
using UITests.Pages.Assess.TestTunnel;
using UITests.Pages.Assess.TestWindow;
using UITests.Pages.Assess.Track;
using UITests.Pages.Home;
using UITests.Workflow;

namespace UITests.Workflow.Assess
{
    /// <summary>
    /// the view test details workflows
    /// </summary>
    public class ViewTestDetailsWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public ViewTestDetailsWorkflows(AssessWorkflows workflows)
            : base()
        {
            AssessWorkflows = workflows;
        }

        //workflows
        public AssessWorkflows AssessWorkflows { get; set; }

        /// <summary>
        /// view test details page make public
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPageMakePublic()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception(
                    "The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ViewTestDetailsPage = AssessWorkflows.ViewTestDetailsPage.MakePublic();
            return this;
        }
        /// <summary>
        /// view test details page ready to schedule
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPageReadyToSchedule()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception(
                    "The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ViewTestDetailsPage = AssessWorkflows.ViewTestDetailsPage.ReadyToSchedule();
            return this;
        }
        /// <summary>
        /// view test details page schedule
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPageSchedule()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception(
                    "The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditSchedulePage = AssessWorkflows.ViewTestDetailsPage.Schedule();
            return this;
        }
        /// <summary>
        /// view test details page add an item
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPageAddItem()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception("The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditQuestionChooseNewItemPage = AssessWorkflows.ViewTestDetailsPage.Form.AddItem();
            return this;
        }
        /// <summary>
        /// view test details page add an instruction
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPageAddInstruction()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception("The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ViewTestDetailsPage.Form.AddInstructions();
            return this;
        }
        /// <summary>
        /// view test details page edit an item
        /// Index start at 0, 1, 2 ..
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPageEditItem(int Index)
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception("The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            List<TestContentLineItem> itemList = AssessWorkflows.ViewTestDetailsPage.Form.GetResultsList();
            itemList[Index].SelectEdit();
            return this;
        }
        /// <summary>
        /// verify the view test details page is in the test stage: not specified
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPageVerifyIsNotSpecified()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception("The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            Assert.IsTrue(AssessWorkflows.ViewTestDetailsPage.IsStageNotSpecified(), "The ViewTestDetailsPage is not in the not specified stage."); ;
            return this;
        }
        /// <summary>
        /// verify the view test details page is in the test stage: private draft
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPageVerifyIsPrivateDraft()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception("The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            Assert.IsTrue(AssessWorkflows.ViewTestDetailsPage.IsStagePrivateDraft(), "The ViewTestDetailsPage is not in the private draft stage."); ;
            return this;
        }
        /// <summary>
        /// verify the view test details page is in the test stage: public draft
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPageVerifyIsPublicDraft()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception("The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            Assert.IsTrue(AssessWorkflows.ViewTestDetailsPage.IsStagePublicDraft(), "The ViewTestDetailsPage is not in the public draft stage."); ;
            return this;
        }
        /// <summary>
        /// verify the view test details page is in the test stage: ready to schedule
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPageVerifyIsReadyToSchedule()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception(
                    "The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            Assert.IsTrue(AssessWorkflows.ViewTestDetailsPage.IsStageReadyToSchedule(), "The ViewTestDetailsPage is not in the ready to schedule stage."); ;
            return this;
        }
        /// <summary>
        /// verify the view test details page is in the test stage: scheduled
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPageVerifyIsScheduled()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception("The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            Assert.IsTrue(AssessWorkflows.ViewTestDetailsPage.IsStageScheduled(), "The ViewTestDetailsPage is not in the scheduled stage."); ;
            return this;
        }
        /// <summary>
        /// verify the view test details page is in the test stage: in progress
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPageVerifyIsInProgress()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception("The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            Assert.IsTrue(AssessWorkflows.ViewTestDetailsPage.IsStageInProgress(), "The ViewTestDetailsPage is not in the in progress stage."); ;
            return this;
        }
        /// <summary>
        /// verify the view test details page is in the test stage: completed
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPageVerifyIsCompleted()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception("The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            Assert.IsTrue(AssessWorkflows.ViewTestDetailsPage.IsStageCompletedDraft(), "The ViewTestDetailsPage is not in the completed stage."); ;
            return this;
        }
        /// <summary>
        /// copy a test
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPageCopyTest()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception(
                    "The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ViewTestDetailsPage.Side.TestActions.ExpandLink();
            AssessWorkflows.CreateTestManualPage = AssessWorkflows.ViewTestDetailsPage.Side.TestActions.CopyTest();
            return this;
        }
        /// <summary>
        /// delete a test
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPageDeleteTest()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception(
                    "The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ViewTestDetailsPage.Side.TestActions.ExpandLink();
            AssessWorkflows.ViewTestDetailsPage.Side.TestActions.DeleteTest();
            return this;
        }
        /// <summary>
        /// preview the online test
        /// </summary>
        /// <returns>Workflows</returns>
        public ViewTestDetailsWorkflows ViewTestDetailsPagePreviewOnlineTest()
        {
            if (AssessWorkflows.ViewTestDetailsPage == null)
            {
                throw new Exception("The ViewTestDetailsPage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.ViewTestDetailsPage.Side.TestActions.ExpandLink();
            AssessWorkflows.TestTunnelPage = AssessWorkflows.ViewTestDetailsPage.Side.TestActions.PreviewOnlineTest();
            return this;
        }
    }
}
