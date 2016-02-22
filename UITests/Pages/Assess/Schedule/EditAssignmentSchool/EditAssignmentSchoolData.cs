using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.Schedule.EditAssignmentSchool
{
    /// <summary>
    /// edit assignment School data
    /// </summary>
    public class EditAssignmentSchoolData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public EditAssignmentSchoolData()
            : base(typeof(EditAssignmentSchoolData).Assembly) { }
        public string Region { get; set; }
        public string SchoolType { get; set; }
        public string AssignedSchoolName { get; set; }
        public string AvailableSchoolName { get; set; }
        public string AddSelected { get; set; }
        public string RemoveSelected { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.Region = base.GetParameterFromResxResource("Region", testAttribute, row);
            this.SchoolType = base.GetParameterFromResxResource("SchoolType", testAttribute, row);
            this.AssignedSchoolName = base.GetParameterFromResxResource("AssignedSchoolName", testAttribute, row);
            this.AvailableSchoolName = base.GetParameterFromResxResource("AvailableSchoolName", testAttribute, row);
            this.AddSelected = base.GetParameterFromResxResource("AddSelected", testAttribute, row);
            this.RemoveSelected = base.GetParameterFromResxResource("RemoveSelected", testAttribute, row);
        }
    }
}
