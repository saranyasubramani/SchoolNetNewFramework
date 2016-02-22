using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Tools.WebDriver;
using Core.Views;
using OpenQA.Selenium;
using UITests.Pages.Assess.Components;

namespace UITests.Pages.Assess.Rubric.EditRubricAvailability
{
    /// <summary>
    /// The edit rubric availability form
    /// </summary>
    public class EditRubricAvailabilityForm : SNForm
    {
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="overrideControlPrefix">override control prefix</param>
        public EditRubricAvailabilityForm(string overrideControlPrefix = null)
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
            SharingRubric = new ShareWithOtherUser(PageNames.EditRubricAvailability);
        }

        /// <summary>
        /// the data
        /// </summary>
        public new EditRubricAvailabilityData Data
        {
            get
            {
                return (EditRubricAvailabilityData)base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// cancel by
        /// </summary>
        public override By ByCancel { get { return By.Id(ControlPrefix + "ButtonCancel"); } }
        /// <summary>
        /// submit by
        /// </summary>
        public override By BySubmit { get { return By.Id(ControlPrefix + "ButtonSave"); } }
        /// <summary>
        /// share rubric with other users component
        /// </summary>
        public ShareWithOtherUser SharingRubric { get; set; }

        //implemented methods
        public override void InputFormFields()
        {
            SharingRubric.InputFormFields();
            DriverCommands.WaitAndMeasurePageLoadTime();
            InitElements();
        }
    }
}
