using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Admin.GeneralSettings.StudentProfile
{
    /// <summary>
    /// StudentProfile data
    /// </summary>
    public class StudentProfileData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public StudentProfileData()
            : base(typeof(StudentProfileData).Assembly) { }
        public string SecondaryStudentID { get; set; }
        public string AttendanceGroupName { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.SecondaryStudentID = base.GetParameterFromResxResource("SecondaryStudentID", testAttribute, row);
            this.AttendanceGroupName = base.GetParameterFromResxResource("AttendanceGroupName", testAttribute, row);
            this.MinRange = base.GetIntParameterFromResxResource("MinRange", testAttribute, row);
            this.MaxRange = base.GetIntParameterFromResxResource("MaxRange", testAttribute, row);
        }
    }
}
