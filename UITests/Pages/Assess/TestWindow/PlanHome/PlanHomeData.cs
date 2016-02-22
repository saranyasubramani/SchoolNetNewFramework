using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.Assess.TestWindow.PlanHome
{
    /// <summary>
    /// plan home data
    /// </summary>
    public class PlanHomeData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public PlanHomeData()
            : base(typeof(PlanHomeData).Assembly) { }
        public string TestWindowName { get; set; }
        public string Subject { get; set; }
        public string GradeLow { get; set; }
        public string GradeHigh { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string ResultsPerPage { get; set; }
        public string ColumnName { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.TestWindowName = base.GetParameterFromResxResource("TestWindowName", testAttribute, row);
            this.Subject = base.GetParameterFromResxResource("Subject", testAttribute, row);
            this.GradeLow = base.GetParameterFromResxResource("GradeLow", testAttribute, row);
            this.GradeHigh = base.GetParameterFromResxResource("GradeHigh", testAttribute, row);
            this.DateFrom = base.GetParameterFromResxResource("DateFrom", testAttribute, row);
            this.DateTo = base.GetParameterFromResxResource("DateTo", testAttribute, row);
            this.ResultsPerPage = base.GetParameterFromResxResource("ResultsPerPage", testAttribute, row);
            this.ColumnName = base.GetParameterFromResxResource("ColumnName", testAttribute, row);
        }
    }
}
