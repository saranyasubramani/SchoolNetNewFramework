using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.Schedule.EditAssignmentCourse
{
    /// <summary>
    /// edit assignment course data
    /// </summary>
    public class EditAssignmentCourseData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public EditAssignmentCourseData()
            : base(typeof(EditAssignmentCourseData).Assembly) { }
        public string Course { get; set; }
        public string CourseId { get; set; }
        public string Department { get; set; }
        public string GradeLow { get; set; }
        public string GradeHigh { get; set; }
        public string AssignedCourseName { get; set; }
        public string AvailableCourseName { get; set; }
        public string LimitBySchools { get; set; }
        public string AddSelected { get; set; }
        public string RemoveSelected { get; set; }
        public string ResultsPerPage { get; set; }
        public int RowNumber { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.Course = base.GetParameterFromResxResource("Course", testAttribute, row);
            this.CourseId = base.GetParameterFromResxResource("CourseId", testAttribute, row);
            this.Department = base.GetParameterFromResxResource("Department", testAttribute, row);
            this.GradeLow = base.GetParameterFromResxResource("GradeLow", testAttribute, row);
            this.GradeHigh = base.GetParameterFromResxResource("GradeHigh", testAttribute, row);
            this.AssignedCourseName = base.GetParameterFromResxResource("AssignedCourseName", testAttribute, row);
            this.AvailableCourseName = base.GetParameterFromResxResource("AvailableCourseName", testAttribute, row);
            this.LimitBySchools = base.GetParameterFromResxResource("LimitBySchools", testAttribute, row);
            this.AddSelected = base.GetParameterFromResxResource("AddSelected", testAttribute, row);
            this.RemoveSelected = base.GetParameterFromResxResource("RemoveSelected", testAttribute, row);
            this.ResultsPerPage = base.GetParameterFromResxResource("ResultsPerPage", testAttribute, row);
            this.RowNumber = base.GetIntParameterFromResxResource("RowNumber", testAttribute, row);
        }
    }
}
