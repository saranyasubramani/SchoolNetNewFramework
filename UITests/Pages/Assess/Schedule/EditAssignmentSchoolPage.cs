using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestDetail.Components;
using UITests.Pages.Assess.Schedule.EditAssignmentSchool;

namespace UITests.Pages.Assess.Schedule
{
    /// <summary>
    /// Select School: Edit Assignment School page
    /// </summary>
    public class EditAssignmentSchoolPage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public EditAssignmentSchoolPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/EditAssignmentSchool.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new EditAssignmentSchoolPageForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new EditAssignmentSchoolPageForm Form { get; set; }

        /// <summary>
        /// the data
        /// </summary>
        public new EditAssignmentSchoolData Data
        {
            get
            {
                return (EditAssignmentSchoolData)base.Data;
            }
            set
            {
                base.Data = value;
                this.Form.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new EditAssignmentSchoolData InitData()
        {
            base.InitData(new EditAssignmentSchoolData());
            return (EditAssignmentSchoolData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public EditAssignmentSchoolData InitData(object data)
        {
            base.InitData(data);
            return (EditAssignmentSchoolData)base.Data;
        }
    }
}
