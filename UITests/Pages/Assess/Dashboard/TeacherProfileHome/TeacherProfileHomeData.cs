using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;
using UITests.Pages.Assess.Dashboard.ProfileHome;

namespace UITests.Pages.Assess.Dashboard.TeacherProfileHome
{
    public class TeacherProfileHomeData : ProfileHomeData
    {
        public TeacherProfileHomeData() : base() { }
        public string Testname { get; set; }
        public string TestCategory { get; set; }
        public string Assigned { get; set; }
        public string Startdate { get; set; }
        public string Grade { get; set; }
        public string CollectionStatus { get; set; }
        public string StudentPerformance { get; set; }
        public string Actions { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.Testname = base.GetParameterFromResxResource("Testname", testAttribute, row);
            this.TestCategory = base.GetParameterFromResxResource("TestCategory", testAttribute, row);
            this.Assigned = base.GetParameterFromResxResource("Assigned", testAttribute, row);
            this.Startdate = base.GetParameterFromResxResource("Startdate", testAttribute, row);
            this.Grade = base.GetParameterFromResxResource("Grade", testAttribute, row);
            this.CollectionStatus = base.GetParameterFromResxResource("CollectionStatus", testAttribute, row);
            this.StudentPerformance = base.GetParameterFromResxResource("StudentPerformance", testAttribute, row);
            this.Actions = base.GetParameterFromResxResource("Actions", testAttribute, row);
        }
    }
}
