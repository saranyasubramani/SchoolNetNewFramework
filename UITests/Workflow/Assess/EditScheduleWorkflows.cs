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
    /// the edit schedule workflows
    /// </summary>
    public class EditScheduleWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public EditScheduleWorkflows(AssessWorkflows workflows)
            : base()
        {
            AssessWorkflows = workflows;
        }

        //workflows
        public AssessWorkflows AssessWorkflows { get; set; }
        /// <summary>
        /// online pass code
        /// </summary>
        public string OnlinePassCode { get; private set; }

        /// <summary>
        /// edit schedule page, select time test and enter test timeout duration
        /// </summary>
        /// <remarks>requires the EditSchedulePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditScheduleWorkflows EditSchedulePageSelectTestTime()
        {
            if (AssessWorkflows.EditSchedulePage == null)
            {
                throw new Exception("The EditSchedulePage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditSchedulePage.Form.CheckTimeTest();
            //AssessWorkflows.EditSchedulePage.Form.InputFormFields();
            return this;
        }
        /// <summary>
        /// edit schedule page, select scramble answer choices
        /// </summary>
        /// <remarks>requires the EditSchedulePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditScheduleWorkflows EditSchedulePageSelectScrambleAnswerChoices()
        {
            if (AssessWorkflows.EditSchedulePage == null)
            {
                throw new Exception("The EditSchedulePage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditSchedulePage.Form.CheckScrambleAnswerChoices();
            return this;
        }
        /// <summary>
        /// edit schedule page, select scramble question order
        /// </summary>
        /// <remarks>requires the EditSchedulePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditScheduleWorkflows EditSchedulePageSelectScrambleQuestions()
        {
            if (AssessWorkflows.EditSchedulePage == null)
            {
                throw new Exception("The EditSchedulePage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditSchedulePage.Form.CheckScrambleQuestionOrder();
            return this;
        }
        /// <summary>
        /// edit schedule page input form fields
        /// </summary>
        /// <remarks>requires the EditSchedulePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditScheduleWorkflows EditSchedulePageInputFormFields()
        {
            if (AssessWorkflows.EditSchedulePage == null)
            {
                throw new Exception("The EditSchedulePage is null, please initialize it before trying to use it in a workflow.");
            }
            OnlinePassCode = AssessWorkflows.EditSchedulePage.Form.Get_Online_Passcode();
            AssessWorkflows.EditSchedulePage.Form.InputFormFields();
            return this;
        }
        /// <summary>
        /// submit edit schedule page
        /// </summary>
        /// <remarks>requires the EditSchedulePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditScheduleWorkflows EditSchedulePageSubmitForm()
        {
            if (AssessWorkflows.EditSchedulePage == null)
            {
                throw new Exception("The EditSchedulePage is null, please initialize it before trying to use it in a workflow.");
            }
            OnlinePassCode = AssessWorkflows.EditSchedulePage.Form.Get_Online_Passcode();
            AssessWorkflows.ViewTestDetailsPage = (ViewTestDetailsPage)AssessWorkflows.EditSchedulePage.Form.SubmitForm();
            return this;
        }
        /// <summary>
        /// cancel edit schedule page
        /// </summary>
        /// <remarks>requires the EditSchedulePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditScheduleWorkflows EditSchedulePageCancelForm()
        {
            if (AssessWorkflows.EditSchedulePage == null)
            {
                throw new Exception("The EditSchedulePage is null, please initialize it before trying to use it in a workflow.");
            }
            //AssessWorkflows.ViewTestDetailsPage = (ViewTestDetailsPage)AssessWorkflows.EditSchedulePage.Form.CancelForm();
            AssessWorkflows.EditSchedulePage.Form.CancelForm();
            AssessWorkflows.ViewTestDetailsPage = new ViewTestDetailsPage();
            return this;
        }
        /// <summary>
        /// edit schedule page input form fields and submit
        /// </summary>
        /// <remarks>requires the EditSchedulePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditScheduleWorkflows EditSchedulePageInputAndSubmitForm()
        {
            if (AssessWorkflows.EditSchedulePage == null)
            {
                throw new Exception("The EditSchedulePage is null, please initialize it before trying to use it in a workflow.");
            }
            OnlinePassCode = AssessWorkflows.EditSchedulePage.Form.Get_Online_Passcode();
            AssessWorkflows.EditSchedulePage.Form.InputAndSubmitForm();
            return this;
        }
        /// <summary>
        /// edit schedule page input form fields, accept quick assignment, and submit
        /// </summary>
        /// <remarks>requires the EditSchedulePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditScheduleWorkflows EditSchedulePageAcceptQuickAssignmentInputAndSubmitForm()
        {
            if (AssessWorkflows.EditSchedulePage == null)
            {
                throw new Exception(
                    "The EditSchedulePage is null, please initialize it before trying to use it in a workflow.");
            }
            OnlinePassCode = AssessWorkflows.EditSchedulePage.Form.Get_Online_Passcode();
            AssessWorkflows.EditSchedulePage.Form.InputFormFields();
            AssessWorkflows.EditSchedulePage.Form.Accept_Quick_Assignment();
            AssessWorkflows.ViewTestDetailsPage = (ViewTestDetailsPage)AssessWorkflows.EditSchedulePage.Form.SubmitForm();
            return this;
        }

        /// <summary>
        /// edit schedule page enable schoolnet browser test tunnel
        /// </summary>
        /// <remarks>requires the EditSchedulePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditScheduleWorkflows EditSchedulePageSchoolnetBrowserTestTunnel()
        {
            if (AssessWorkflows.EditSchedulePage == null)
            {
                throw new Exception("The EditSchedulePage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditSchedulePage.Form.Enable_Schoolnet_Browser_Test_Tunnel();
            return this;
        }
        /// <summary>
        /// edit schedule page enable schoolnet secure tester
        /// </summary>
        /// <remarks>requires the EditSchedulePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditScheduleWorkflows EditSchedulePageSchoolnetSecureTester()
        {
            if (AssessWorkflows.EditSchedulePage == null)
            {
                throw new Exception("The EditSchedulePage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditSchedulePage.Form.Enable_Schoolnet_Secure_Tester();
            return this;
        }
        /// <summary>
        /// edit schedule page assign to students
        /// </summary>
        /// <remarks>requires the EditSchedulePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditScheduleWorkflows EditSchedulePageAssignToStudents()
        {
            if (AssessWorkflows.EditSchedulePage == null)
            {
                throw new Exception("The EditSchedulePage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditSchedulePage.Form.SelectAssignToStudents();
            return this;
        }
        /// <summary>
        /// edit schedule page recommend to teachers
        /// </summary>
        /// <remarks>requires the EditSchedulePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditScheduleWorkflows EditSchedulePageRecommendToTeachers()
        {
            if (AssessWorkflows.EditSchedulePage == null)
            {
                throw new Exception("The EditSchedulePage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditSchedulePage.Form.Select_Recommend_To_Teachers();
            return this;
        }
        /// <summary>
        /// edit schedule page recommend to schools
        /// </summary>
        /// <remarks>requires the EditSchedulePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditScheduleWorkflows EditSchedulePageRecommendToSchools()
        {
            if (AssessWorkflows.EditSchedulePage == null)
            {
                throw new Exception("The EditSchedulePage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditSchedulePage.Form.Select_Recommend_To_Schools();
            return this;
        }
        /// <summary>
        /// edit schedule page accept quick assignment
        /// </summary>
        /// <remarks>requires the EditSchedulePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditScheduleWorkflows EditSchedulePageAcceptQuickAssignment()
        {
            if (AssessWorkflows.EditSchedulePage == null)
            {
                throw new Exception("The EditSchedulePage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditSchedulePage.Form.Accept_Quick_Assignment();
            return this;
        }
        /// <summary>
        /// edit schedule page edit assignment
        /// </summary>
        /// <remarks>requires the EditSchedulePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditScheduleWorkflows EditSchedulePageEditAssignment()
        {
            if (AssessWorkflows.EditSchedulePage == null)
            {
                throw new Exception("The EditSchedulePage is null, please initialize it before trying to use it in a workflow.");
            }
            AssessWorkflows.EditSchedulePage.Form.Edit_Assignment();

            if (this.AssessWorkflows.Workflows.IsTeacher)
            {
                AssessWorkflows.EditTeacherAssignmentPage = new EditTeacherAssignmentPage();
            }
            else
            {
                AssessWorkflows.EditAssignmentCoursePage = new EditAssignmentCoursePage();
            }
            return this;
        }


        private EditScheduleData getScheduleData()
        {
            EditScheduleData data = new EditScheduleData();
            data.StartDate = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");
            data.EndDate = DateTime.Now.ToString("MM/dd/yyyy");
            data.ScoreDate = DateTime.Now.ToString("MM/dd/yyyy");
            return data;
        }
    }
}
