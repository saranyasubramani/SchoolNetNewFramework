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
using UITests.Pages.Assess.Track;
using UITests.Pages.Home;
using UITests.Workflow;

namespace UITests.Workflow.Assess
{
    /// <summary>
    /// the edit assignment course workflows
    /// </summary>
    public class EditAssignmentCourseWorkflows : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="workflows">workflows</param>
        public EditAssignmentCourseWorkflows(AssessWorkflows workflows)
            : base()
        {
            AssessWorkflows = workflows;
        }

        //workflows
        public AssessWorkflows AssessWorkflows { get; set; }

        /// <summary>
        /// User search for available courses
        /// </summary>
        /// <remarks>requires the EditAssignmentCoursePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditAssignmentCourseWorkflows EditAssignmentCoursePageSearchForCourses(EditAssignmentCourseData editAssignmentCourseData)
        {
            if (AssessWorkflows.EditAssignmentCoursePage == null)
            {
                throw new Exception("The EditAssignmentCoursePage is null, please initialize it before trying to use it in a workflow.");
            }
            if (editAssignmentCourseData == null)
            {//use default data
                AssessWorkflows.EditAssignmentCoursePage.InitData();
                AssessWorkflows.EditAssignmentCoursePage.Data.GetTestDataFromResxResource("UITests.Data.Assess.Schedule.EditAssignmentCourseResource",
                    "default_" + this.TestConfiguration.ApplicationName, 0);
            }
            else
            {
                AssessWorkflows.EditAssignmentCoursePage.InitData(editAssignmentCourseData);
            }
            AssessWorkflows.EditAssignmentCoursePage.Form.InputFormFields();

            //Postback after clicking button. EditAssignmentCoursePage is initialized again. 
            AssessWorkflows.EditAssignmentCoursePage = AssessWorkflows.EditAssignmentCoursePage.Form.ClickGo();

            return this;
        }

        /// <summary>
        /// User selects and adds all available courses including next pages
        /// </summary>
        /// <remarks>requires the EditAssignmentCoursePage to be initialized in this class</remarks>
        /// <returns>Workflows</returns>
        public EditAssignmentCourseWorkflows EditAssignmentCoursePageAddAllAvailableCourses()
        {
            if (AssessWorkflows.EditAssignmentCoursePage == null)
            {
                throw new Exception("The EditAssignmentCoursePage is null, please initialize it before trying to use it in a workflow.");
            }
            //bool IsGridDisplay = AssessWorkflows.EditAssignmentCoursePage.Form.IsChooseCourseGridDisplay();
            try
            {
                //To optimize this, a while loop is used. This assume the grid exists and the checkbox
                //to select all courses exists. At the end of this page, after all courses had been selected, 
                //the grid will NOT exists. Exception is throw. The code catch it and continue execution. 
                while (true) //while (IsGridDisplay)
                {
                    //User going through each pages and and select all courses
                    AssessWorkflows.EditAssignmentCoursePage.Form.SelectAllChooseCourse();
                    //Postback after clicking button. EditAssignmentCoursePage is initialized again.
                    AssessWorkflows.EditAssignmentCoursePage = AssessWorkflows.EditAssignmentCoursePage.Form.ClickAddSelected();

                    //IsGridDisplay = EditAssignmentCoursePage.Form.IsChooseCourseGridDisplay();
                    if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
                    {
                        break;
                    }
                }
            }
            catch (Exception)
            {
                //Grid no longer exist. Resume execution.
            }
            return this;
        }


        /// <summary>
        /// User removes all selected courses
        /// </summary>
        /// <remarks>requires the EditAssignmentCoursePage to be initialized in this class. 
        /// requires courses had been selected
        /// </remarks>
        /// <returns>Workflows</returns>
        public EditAssignmentCourseWorkflows EditAssignmentCoursePageRemoveAllSelectedCourses()
        {
            if (AssessWorkflows.EditAssignmentCoursePage == null)
            {
                throw new Exception("The EditAssignmentCoursePage is null, please initialize it before trying to use it in a workflow.");
            }
            //GIVEN user had selected courses from available courses
            //WHEN user selects all selected courses
            //AND user removes all selected courses
            AssessWorkflows.EditAssignmentCoursePage.Form.SelectAllSelectedCourse();
            //Postback after clicking button. EditAssignmentCoursePage is initialized again.
            AssessWorkflows.EditAssignmentCoursePage = AssessWorkflows.EditAssignmentCoursePage.Form.ClickRemoveSelected();
            return this;
        }
    }
}
