using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Schedule.EditTeacherAssignment
{
    /// <summary>
    /// The edit teacher assignment form
    /// </summary>
    public class EditTeacherAssignmentForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public EditTeacherAssignmentForm(string overrideControlPrefix = null)
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
            Grid = new EditTeacherAssignmentGrid(assignToSectionsGrid, true, ControlPrefix);
            AssignToSectionsRadio = new WebElementWrapper(ByAssignToSectionsRadio);
            AssignToIndividualStudentsRadio = new WebElementWrapper(ByAssignToIndividualStudentsRadio);
            SectionCheck = new WebElementWrapper(BySectionCheck);
            StudentCheck = new WebElementWrapper(ByStudentCheck);
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

        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ButtonSave"); } }
        /// <summary>
        /// cancel by
        /// </summary>
        public override By ByCancel { get { return By.Id(ControlPrefix + "ButtonCancel"); } }
        private string assignToSectionsGrid { get { return "#" + ControlPrefix + "GridAvailableSections"; } }
        private string assignToIndividualStudentsGrid { get { return "#" + ControlPrefix + "GridAvailableStudents"; } }
        public EditTeacherAssignmentGrid Grid { get; set; }
        private By ByAssignToSectionsRadio { get { return By.Id(ControlPrefix + "RadioButtonListAssignmentMethod_0"); } }
        private WebElementWrapper AssignToSectionsRadio { get; set; }
        private By ByAssignToIndividualStudentsRadio { get { return By.Id(ControlPrefix + "RadioButtonListAssignmentMethod_1"); } }
        private WebElementWrapper AssignToIndividualStudentsRadio { get; set; }
        private By BySectionCheck { get { return By.Id("chkSelectAllAvailableSection"); } }
        private WebElementWrapper SectionCheck { get; set; }
        private By ByStudentCheck { get { return By.Id("chkSelectAllAvailableStudent"); } }
        private WebElementWrapper StudentCheck { get; set; }

        /// <summary>
        /// select assign to sections
        /// </summary>
        public void SelectAssignToSections()
        {
            AssignToSectionsRadio.Wait(3);
            AssignToSectionsRadio.Selected = true;
            if (AssignToSectionsRadio.Selected == false)
            {
                this.Parent.CurrentWindowHandle = Driver.CurrentWindowHandle;
                Report.Write("The current window is: '" + this.Parent.CurrentWindowHandle + "'.");

                AssignToSectionsRadio.Wait(3).Click();

                AlertHandler alert = new AlertHandler();
                alert.VerifyText("You will lose your selection if you change to a different assignment method?");
                alert.Accept();

                //switch to window
                DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 5);

                DriverCommands.WaitAndMeasurePageLoadTime();
                this.Parent.InitElements();
                Grid = new EditTeacherAssignmentGrid(assignToSectionsGrid, true, ControlPrefix);
            }
        }
        /// <summary>
        /// select assign to individual students
        /// </summary>
        public void SelectAssignToIndividualStudents()
        {
            AssignToIndividualStudentsRadio.Wait(3);
            AssignToIndividualStudentsRadio.Selected = true;
            if (AssignToIndividualStudentsRadio.Selected == false)
            {
                this.Parent.CurrentWindowHandle = Driver.CurrentWindowHandle;
                Report.Write("The current window is: '" + this.Parent.CurrentWindowHandle + "'.");

                AssignToIndividualStudentsRadio.Wait(3).Click();

                AlertHandler alert = new AlertHandler();
                alert.VerifyText("You will lose your selection if you change to a different assignment method?");
                alert.Accept();

                //switch to window
                DriverCommands.WaitToSwitchWindow(this.Parent.CurrentWindowHandle, 5);

                DriverCommands.WaitAndMeasurePageLoadTime();
                this.Parent.InitElements();
                Grid = new EditTeacherAssignmentGrid(assignToIndividualStudentsGrid, true, ControlPrefix);
            }
        }
        /// <summary>
        /// check all section
        /// </summary>
        public void CheckAllSection()
        {
            SectionCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck all section
        /// </summary>
        public void UnCheckAllSection()
        {
            SectionCheck.Wait(3).UnCheck();
        }
        /// <summary>
        /// check a section
        /// </summary>
        public void CheckASection()
        {
            List<EditTeacherAssignmentRow> rowFound = 
                Grid.GetsRowsContainingTextToFindFromList(EditTeacherAssignmentColumnNames.Section, Data.SectionName);
            rowFound[0].Check();
        }
        /// <summary>
        /// check student
        /// </summary>
        public void CheckStudent()
        {
            StudentCheck.Wait(3).Check();
        }
        /// <summary>
        /// uncheck student
        /// </summary>
        public void UnCheckStudent()
        {
            StudentCheck.Wait(3).UnCheck();
        }
    }
}
