using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestDetail.Components;
using UITests.Pages.Assess.Schedule.EditTeacherAssignment;

namespace UITests.Pages.Assess.Schedule
{
    /// <summary>
    /// The edit teacher assignment page
    /// </summary>
    public class EditTeacherAssignmentPage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public EditTeacherAssignmentPage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/EditTeacherAssignment.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new EditTeacherAssignmentForm();
            this.Form.Parent = this;
            this.Detail = new EditTeacherAssignmentDetail();
            this.Detail.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new EditTeacherAssignmentForm Form { get; set; }
        /// <summary>
        /// the form
        /// </summary>
        public new EditTeacherAssignmentDetail Detail { get; set; }

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
                this.Form.Data = value;
                this.Detail.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new EditTeacherAssignmentData InitData()
        {
            base.InitData(new EditTeacherAssignmentData());
            return (EditTeacherAssignmentData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public EditTeacherAssignmentData InitData(object data)
        {
            base.InitData(data);
            return (EditTeacherAssignmentData)base.Data;
        }
    }
}
