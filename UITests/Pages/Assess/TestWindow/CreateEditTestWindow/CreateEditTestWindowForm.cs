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
using UITests.Pages.Controls;

namespace UITests.Pages.Assess.TestWindow.CreateEditTestWindow
{
    /// <summary>
    /// create edit test window form
    /// </summary>
    public class CreateEditTestWindowForm : SNForm
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override Control Prefix</param>
        public CreateEditTestWindowForm(string overrideControlPrefix = null)
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
            //Subject = new Subject(PageNames.TestWindowCreateEditTestWindow);
            //GradeLevel = new GradeLevel(PageNames.TestWindowCreateEditTestWindow, this.ControlPrefix);
            SubjectElement subject = new SubjectElement(PageNames.TestWindowCreateEditTestWindow);
            SubjectSelect = subject.SelectElement;
            GradeLevelElement gradeLevel = new GradeLevelElement(PageNames.TestWindowCreateEditTestWindow);
            GradeFromSelect = gradeLevel.FromSelectElement;
            GradeToSelect = gradeLevel.ToSelectElement;
            TestWindowName = new WebElementWrapper(ByTestWindowName);
            DateFrom = new WebElementWrapper(ByDateFrom);
            DateTo = new WebElementWrapper(ByDateTo);
            Description = new WebElementWrapper(ByDescription);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new CreateEditTestWindowData Data
        {
            get
            {
                return (CreateEditTestWindowData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        //ctl00_MainContent_ButtonCreate
        public override By BySubmit { get { return By.Id(ControlPrefix + "ButtonCreate"); } }
        //ctl00_MainContent_TextBoxName
        private By ByTestWindowName { get { return By.Id(ControlPrefix + "TextBoxName"); } }
        private WebElementWrapper TestWindowName { get; set; }
        //private Subject Subject { get; set; }
        //private GradeLevel GradeLevel { get; set; }
        public SelectElementWrapper SubjectSelect { get; private set; }
        public SelectElementWrapper GradeFromSelect { get; private set; }
        public SelectElementWrapper GradeToSelect { get; private set; }
        //ctl00_MainContent_TextBoxAdminStartDate
        private By ByDateFrom { get { return By.Id(ControlPrefix + "TextBoxAdminStartDate"); } }
        private WebElementWrapper DateFrom { get; set; }
        //ctl00_MainContent_TextBoxAdminEndDate
        private By ByDateTo { get { return By.Id(ControlPrefix + "TextBoxAdminEndDate"); } }
        private WebElementWrapper DateTo { get; set; }
        //ctl00_MainContent_TextBoxDescription
        private By ByDescription { get { return By.Id(ControlPrefix + "TextBoxDescription"); } }
        private WebElementWrapper Description { get; set; }

        //implemented methods
        public override void ClearForm()
        {
            TestWindowName.Clear();
            SubjectSelect.Wait(3).SelectByText("All subjects");
            GradeFromSelect.Wait(5).SelectByText("");
            GradeToSelect.Wait(5).SelectByText("");
            DateFrom.Clear();
            DateTo.Clear();
            Description.Clear();
        }

        public override void InputFormFields()
        {
            if (Data.TestWindowName != null)
            {
                TestWindowName.SendKeys(Data.TestWindowName);
            }
            if (Data.Subject != null)
            {
                SubjectSelect.Wait(3).SelectByText(Data.Subject);
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
            if (Data.DateFrom != null)
            {
                DateFrom.SendKeys(Data.DateFrom);
            }
            if (Data.DateTo != null)
            {
                DateTo.Clear();
                DateTo.SendKeys(Data.DateTo);
            }
            if (Data.Description != null)
            {
                Description.SendKeys(Data.Description);
            }
        }
    }
}
