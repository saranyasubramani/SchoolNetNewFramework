using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.Schedule.ScheduleHome
{
    /// <summary>
    /// Schedule Home Data
    /// </summary>
    public class ScheduleHomeData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ScheduleHomeData()
            : base(typeof(ScheduleHomeData).Assembly) { }
        public string TestNameID { get; set; }
        public string Subject { get; set; }
        public string GradeLow { get; set; }
        public string GradeHigh { get; set; }
        public string ResultsPerPage { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.TestNameID = base.GetParameterFromResxResource("TestNameID", testAttribute, row);
            this.Subject = base.GetParameterFromResxResource("Subject", testAttribute, row);
            this.GradeLow = base.GetParameterFromResxResource("GradeLow", testAttribute, row);
            this.GradeHigh = base.GetParameterFromResxResource("GradeHigh", testAttribute, row);
            this.ResultsPerPage = base.GetParameterFromResxResource("ResultsPerPage", testAttribute, row);
        }
    }
}
