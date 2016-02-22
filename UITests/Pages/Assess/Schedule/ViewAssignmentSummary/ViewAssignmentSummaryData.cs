using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.Schedule.ViewAssignmentSummary
{
    /// <summary>
    /// view  assignment summary data
    /// </summary>
    public class ViewAssignmentSummaryData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public ViewAssignmentSummaryData()
            : base(typeof(ViewAssignmentSummaryData).Assembly) { }
        public string AssignedSchoolName { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.AssignedSchoolName = base.GetParameterFromResxResource("AssignedSchoolName", testAttribute, row);
        }
    }
}
