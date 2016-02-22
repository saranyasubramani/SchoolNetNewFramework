using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.Schedule.EditTeacherAssignment
{
    /// <summary>
    /// Edit Teacher Assignment data
    /// </summary>
    public class EditTeacherAssignmentData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public EditTeacherAssignmentData()
            : base(typeof(EditTeacherAssignmentData).Assembly) { }
        public string SectionName { get; set; }
        public string StudentName { get; set; }
        public string Grade { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.SectionName = base.GetParameterFromResxResource("SectionName", testAttribute, row);
            this.StudentName = base.GetParameterFromResxResource("StudentName", testAttribute, row);
            this.Grade = base.GetParameterFromResxResource("Grade", testAttribute, row);
        }
    }
}
