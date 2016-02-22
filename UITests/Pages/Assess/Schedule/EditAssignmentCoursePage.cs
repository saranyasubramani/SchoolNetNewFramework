using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Views;
using UITests.Pages.Assess.TestDetail.Components;
using UITests.Pages.Assess.Schedule.EditAssignmentCourse;

namespace UITests.Pages.Assess.Schedule
{
    /// <summary>
    /// Select courses: Edit Assignment Course page
    /// </summary>
    public class EditAssignmentCoursePage : SNWebPage
    {
        /// <summary>
        /// constructor
        /// </summary>
        public EditAssignmentCoursePage()
            : base()
        {
            this.Name = MethodBase.GetCurrentMethod().DeclaringType.Name;
            this.PrintName();
            this.ExpectedUrl = "/Assess/EditAssignmentCourse.aspx";
            this.VerifyCurrentUrl();
            InitElements();
        }

        /// <summary>
        /// initialize elements
        /// </summary>
        public override void InitElements()
        {
            this.Form = new EditAssignmentCoursePageForm();
            this.Form.Parent = this;
        }
        /// <summary>
        /// the form
        /// </summary>
        public new EditAssignmentCoursePageForm Form { get; set; }

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
                this.Form.Data = value;
            }
        }
        /// <summary>
        /// intializes the data
        /// </summary>
        /// <returns>object data</returns>
        public new EditAssignmentCourseData InitData()
        {
            base.InitData(new EditAssignmentCourseData());
            return (EditAssignmentCourseData)base.Data;
        }
        /// <summary>
        /// initializes the data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>object data</returns>
        public EditAssignmentCourseData InitData(object data)
        {
            base.InitData(data);
            return (EditAssignmentCourseData)base.Data;
        }
    }
}
