using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Controls;

namespace UITests.Pages.Assess.Schedule.EditAssignmentCourse
{
    /// <summary>
    /// Select courses: Edit Assignment Course form
    /// </summary>
    public class EditAssignmentCoursePageForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix"></param>
        public EditAssignmentCoursePageForm(string overrideControlPrefix = null)
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
            GradeLevelElement gradeLevel = new GradeLevelElement(PageNames.EditAssignmentCourse);
            GradeFromSelect = gradeLevel.FromSelectElement;
            GradeToSelect = gradeLevel.ToSelectElement;
            Course_textbox = new WebElementWrapper(ByCourse_textbox);
            Department_dropdown = new SelectElementWrapper(new WebElementWrapper(ByDepartment_dropdown));
            //Go_button = new WebElementWrapper(ByGo_button);
            //LimitBySchools_button = new WebElementWrapper(ByLimitBySchools_button);
            AssignedCourseName_chkbox = new WebElementWrapper(ByAssignedCourseName_chkbox);
            AvailableCourseName_chkbox = new WebElementWrapper(ByAvailableCourseName_chkbox);
            NextPage = new WebElementWrapper(ByNextPage);

            Report.Write("Attempting to initialize Choose Course Grid component.");
            if (IsChooseCourseGridDisplay())
            {
                ChooseCourseGrid = new EditAssignmentCourseGrid(ChooseGridLocator, false);
                Report.Write("Initialize Choose Course Grid component success.");
            }
            else
            {
                Report.Write("Initialize Choose Course Grid component failed.");
            }

            try
            {
                //Sometimes the page will not have Selected Course grid display. 
                //Sometimes the page display warning message, but not grid.
                //If the grid is not display, the test should continue to run. Not a failure for this page.

                //Check to see if the grid is display first before initializing the grid.
                By ByGrid = By.CssSelector(SelectedGridLocator);
                WebElementWrapper Grid = new WebElementWrapper(ByGrid);
                Grid.Wait(3);

                try
                {
                    //The grid was found. Check to see if warning message is display
                    SelectedCourseWarning = new WebElementWrapper(BySelectedCourseWarning);
                    SelectedCourseWarning.Wait(3);
                    Report.Write("The Selected Course Grid warning message: " + BySelectedCourseWarning.ToString() + " was found.");
                }
                catch (Exception)
                {   //The grid was found. ChooseCourseWarning message is not display. 
                    SelectedCourseGrid = new EditAssignmentCourseGrid(SelectedGridLocator, false);
                }
            }
            catch
            {
                Report.Write("The Selected Course Grid: ByCssSelector: " + SelectedGridLocator + " was not found.");
            }

            if (Driver.WrappedDriver.GetType() == typeof(DummyDriver))
            {
                ChooseCourseGrid = new EditAssignmentCourseGrid(ChooseGridLocator, true);
                SelectedCourseGrid = new EditAssignmentCourseGrid(SelectedGridLocator, true);
            }
        }

        /// <summary>
        /// the data
        /// </summary>
        public new EditAssignmentCourseData Data
        {
            get
            {
                return (EditAssignmentCourseData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        //Select Courses elements 
        public override By BySubmit { get { return By.Id(ControlPrefix + "ButtonDone"); } }
        //public WebElementWrapper Submit { get { return new WebElementWrapper(Driver, BySubmit); } }
        public SelectElementWrapper GradeFromSelect { get; private set; }
        public SelectElementWrapper GradeToSelect { get; private set; }
        public By ByCourse_textbox { get { return By.Id(ControlPrefix + "AutoCompleteCourseName"); } }
        public WebElementWrapper Course_textbox { get; private set; }
        public By ByDepartment_dropdown { get { return By.Id(ControlPrefix + "cbxDepartment"); } }
        public SelectElementWrapper Department_dropdown { get; private set; }
        public By ByGo_button { get { return By.Id(ControlPrefix + "ButtonGetCourses"); } }
        public WebElementWrapper Go_button { get { return new WebElementWrapper(ByGo_button); } }
        public By ByLimitBySchools_button { get { return By.Id(ControlPrefix + "ButtonAssignSchools"); } }
        public WebElementWrapper LimitBySchools_button { get { return new WebElementWrapper(ByLimitBySchools_button); } }
        //Choose courses elements
        public By ByAddSelected_button { get { return By.Id(ControlPrefix + "ButtonAdd"); } }
        public WebElementWrapper AddSelected_button { get { return new WebElementWrapper(ByAddSelected_button); } }
        public By ByRemoveSelected_button { get { return By.Id(ControlPrefix + "ButtonRemove"); } }
        public WebElementWrapper RemoveSelected_button { get { return new WebElementWrapper(ByRemoveSelected_button); } }
        private string ChooseGridLocator { get { return "#" + ControlPrefix + "GridAvailableCourses"; } }
        private string SelectedGridLocator { get { return "#" + ControlPrefix + "GridAssignedCourses"; } }
        public EditAssignmentCourseGrid ChooseCourseGrid { get; set; }
        public EditAssignmentCourseGrid SelectedCourseGrid { get; set; }
        By ByChooseCourseWarning { get { return By.CssSelector(ChooseGridLocator + " .ChooseCourseWarning"); } }
        public WebElementWrapper ChooseCourseWarning { get; set; }
        By BySelectedCourseWarning { get { return By.CssSelector(SelectedGridLocator + " .ChooseCourseWarning"); } }
        WebElementWrapper SelectedCourseWarning { get; set; }
        //The grid component had the following checkbox and next page element. But to optimize
        //loading grid component and reduce loading wait time, the elements below is called
        //directly rather than using the grid component to call them. 
        private By ByAssignedCourseName_chkbox { get { return By.Id("chkSelectAllAssignedCourse"); } }
        private WebElementWrapper AssignedCourseName_chkbox { get; set; }
        private By ByAvailableCourseName_chkbox { get { return By.Id("chkSelectAllAvailableCourse"); } }
        private WebElementWrapper AvailableCourseName_chkbox { get; set; }
        private By ByNextPage { get { return By.CssSelector("a[href*='Page'][ href*='Next']"); } }
        private WebElementWrapper NextPage { get; set; }

        #region Choose Course
        /// <summary>
        /// Select all courses by checking on checkbox beside Course Name for "Choose courses" section. 
        /// </summary>
        public void SelectAllChooseCourse()
        {
            AvailableCourseName_chkbox.Wait(2).Check();
        }

        /// <summary>
        /// Check on checkbox for a course by looking up course Id in the choose course section 
        /// </summary>
        public void SelectChooseCourseByCourseId()
        {
            string courseToFind = Data.CourseId;
            if (ChooseCourseGrid == null)
            {
                InitElements();
                ChooseCourseGrid.SetGridLists();
            }

            List<EditAssignmentCourseRow> courseFound =
                ChooseCourseGrid.GetsRowsContainingTextToFindFromList(EditAssignmentCourseColumnNames.CourseId,
                    courseToFind);

            foreach (var row in courseFound)
            {
                Report.Write("Found course id " + courseToFind + ". Row Index: " + row.Index + ". Attempting to select this course.");
                row.Check();
                break;
            }

        }

        /// <summary>
        /// Check on checkbox for a course by looking up course Id in the choose course section 
        /// </summary>
        public void SelectChooseCourseByRow()
        {
            int rowIndex = Data.RowNumber;
            if (rowIndex > 0)
            {
                EditAssignmentCourseRow row = (EditAssignmentCourseRow)ChooseCourseGrid.GetRowFromList(rowIndex);
                row.Check();
            }
        }

        /// <summary>
        /// Select X results per page in the choose course section 
        /// </summary>
        public EditAssignmentCoursePage SelectChooseCourseResultsPerPage()
        {
            if (ChooseCourseGrid == null)
            {
                InitElements();
                ChooseCourseGrid.SetGridLists();
            }

            ChooseCourseGrid.SelectResultsPerPage(Data.ResultsPerPage);
            //page postback
            return new EditAssignmentCoursePage();
        }


        /// <summary>
        /// Select next page in the choose course section 
        /// </summary>
        public EditAssignmentCoursePage SelectChooseCourseNextPage()
        {
            if (NextPage.Displayed && NextPage.Enabled)
            {
                NextPage.Wait(3).Click();
                //page postback
                return new EditAssignmentCoursePage();
            }
            return null;
        }

        /// <summary>
        /// Determine if the choose course grid is display. If grid with courses data are display, return true.
        /// </summary>
        public bool IsChooseCourseGridDisplay()
        {
            try
            {
                //Sometimes the page will not have Choose Course grid display. 
                //Sometimes the page display warning message, but not grid.
                //If the grid is not display, the test should continue to run. Not a failure for this page.

                //Check to see if the grid is display first 
                By ByGrid = By.CssSelector(ChooseGridLocator);
                WebElementWrapper Grid = new WebElementWrapper(ByGrid);
                Grid.Wait(3);

                try
                {
                    //The grid was found. Check to see if warning message is display                 
                    ChooseCourseWarning = new WebElementWrapper(ByChooseCourseWarning);
                    ChooseCourseWarning.Wait(3);
                    Report.Write("The Choose Course Grid warning message: " + ByChooseCourseWarning.ToString() + " was found.");
                }
                catch (Exception)
                {
                    //ChooseCourseWarning message is not display. 
                    //The grid is display with available courses data    
                    return true;
                }
            }
            catch
            {
                //The grid is not found
                Report.Write("The Choose Course Grid: ByCssSelector: " + ChooseGridLocator + " was not found.");
                return false;
            }


            return false;
        }

        #endregion

        #region Selected Course

        /// <summary>
        /// Select all courses by checking on checkbox beside Course Name for "Selected courses" section. 
        /// </summary>
        public void SelectAllSelectedCourse()
        {
            AssignedCourseName_chkbox.Wait(2).Check();
        }

        /// <summary>
        /// Check on checkbox for a course by looking up course Id in the selected course section 
        /// </summary>
        public void SelectSelectedCourseByCourseId()
        {
            string courseToFind = Data.CourseId;
            if (SelectedCourseGrid == null)
            {
                InitElements();
                SelectedCourseGrid.SetGridLists();
            }

            List<EditAssignmentCourseRow> courseFound =
                SelectedCourseGrid.GetsRowsContainingTextToFindFromList(EditAssignmentCourseColumnNames.CourseId,
                    courseToFind);

            foreach (var row in courseFound)
            {
                Report.Write("Found course id " + courseToFind + ". Row Index: " + row.Index + ". Attempting to select this course.");
                row.Check();
                break;
            }

        }

        #endregion

        #region Search Course

        /// <summary>
        /// Click Go button
        /// </summary>
        public EditAssignmentCoursePage ClickGo()
        {
            Report.Write("Clicked on Go button.");
            Go_button.Wait(3).Click();

            //page postback
            return new EditAssignmentCoursePage();
        }

        /// <summary>
        /// Select Department
        /// </summary>
        public void SelectDepartment(string selection)
        {
            Report.Write("Select from Department drop downdown.");
            Department_dropdown.SelectByText(selection);
        }

        #endregion

        /// <summary>
        /// Click Limit By Schools button
        /// </summary>
        public EditAssignmentSchoolPage ClickLimitBySchools()
        {
            Report.Write("Clicked on Limit by Schools button.");
            LimitBySchools_button.Wait(3).Click();

            return new EditAssignmentSchoolPage();
        }

        /// <summary>
        /// Click Add Selected button
        /// </summary>
        public EditAssignmentCoursePage ClickAddSelected()
        {
            Report.Write("Clicked on Add Selected button.");
            AddSelected_button.Wait(3).Click();

            //page postback
            return new EditAssignmentCoursePage();
        }

        /// <summary>
        /// Click Remove Selected button
        /// </summary>
        public EditAssignmentCoursePage ClickRemoveSelected()
        {
            Report.Write("Clicked on Remove Selected button.");
            RemoveSelected_button.Wait(3).Click();
            //page postback
            return new EditAssignmentCoursePage();
        }

        ///// <summary>
        ///// Check Assigned Course checkbox
        ///// </summary>
        //public void CheckBoxAssignedCourseName()
        //{
        //    SelectCourseName(AssignedCourseName_chkbox, true);
        //}

        ///// <summary>
        ///// Ccheck Avalabale Schools checkbox
        ///// </summary>
        //public void CheckBoxAvailableCourseName()
        //{
        //    SelectCourseName(AvailableCourseName_chkbox, true);
        //}

        //implemented methods

        public override void ClearForm()
        {
            throw new NotImplementedException();
        }

        public override void InputFormFields()
        {
            if (Data.Course != null)
            {
                Course_textbox.SendKeys(Data.Course);
            }
            if (Data.Department != null)
            {
                Department_dropdown.SelectByText(Data.Department);
            }
            if (Data.GradeLow != null)
            {
                GradeFromSelect.Wait(5);
                GradeFromSelect.Wait(5).SelectByText(Data.GradeLow);
            }
            if (Data.GradeHigh != null)
            {
                GradeToSelect.Wait(5);
                GradeToSelect.Wait(5).SelectByText(Data.GradeHigh);
            }
            if (Data.LimitBySchools != null)
            {
                if (Data.LimitBySchools == "1")
                {
                    ClickLimitBySchools();
                }
            }
            if (Data.AddSelected != null)
            {
                if (Data.AddSelected == "1")
                {
                    ClickAddSelected();
                }
            }
            if (Data.RemoveSelected != null)
            {
                if (Data.RemoveSelected == "1")
                {
                    ClickRemoveSelected();
                }
            }

            //if (Data.AssignedCourseName != null)
            //{
            //    if (Data.AssignedCourseName.Equals("1"))
            //    {
            //        SelectCourseName(AssignedCourseName_chkbox, true);
            //    }
            //}
            //if (Data.AvailableCourseName != null)
            //{
            //    if (Data.AvailableCourseName.Equals("1"))
            //    {
            //        SelectCourseName(AvailableCourseName_chkbox, true);
            //    }
            //}

            //if (Data.AssignedCourseName != null)
            //{
            //    if (Data.CourseName.Equals("1"))
            //    {
            //        SelectCourseName(AssignedCourseName_chkbox, true);
            //    }
            //}
        }



    }
}
