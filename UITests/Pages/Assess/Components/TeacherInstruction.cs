using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Tools.WebDriver;
using OpenQA.Selenium;
using UITests.Pages.Components;

namespace UITests.Pages.Assess.Components
{
    /// <summary>
    /// teacher instruction component
    /// </summary>
    public class TeacherInstruction : SNComponent
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="overrideControlPrefix"></param>
        public TeacherInstruction(PageNames pageName, string overrideControlPrefix = null)
            : base()
        {
            switch (pageName)
            {
                case PageNames.EditTestItem:
                    Id = "TeacherInstructionsLabel";
                    break;
                case PageNames.EditQuestion:
                    Id = "TeacherInstructionsLabel";
                    break;
                case PageNames.CreatePassage:
                    Id = "TeacherInstructionsLabel";
                    break;
                case PageNames.EditTask:
                    Id = "lblTaskItemTeacherInstructions";
                    break;
            }
            Control = new WebElementWrapper(ByTeacherInstruction);
        }

        private string Id = "TeacherInstructionsLabel";
        /// <summary>
        /// the teacher instruction by
        /// </summary>
        public By ByTeacherInstruction { get { return By.Id(Id); } }
        /// <summary>
        /// the teacher instruction contrl (element)
        /// </summary>
        public WebElementWrapper Control { get; private set; }
    }
}
