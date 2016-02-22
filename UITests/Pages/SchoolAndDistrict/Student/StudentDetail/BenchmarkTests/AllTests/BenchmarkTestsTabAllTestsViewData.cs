using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.AllTests
{
    /// <summary>
    /// create benchmark tests tab data
    /// </summary>
    public class BenchmarkTestsTabAllTestsViewData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public BenchmarkTestsTabAllTestsViewData()
            : base(typeof(BenchmarkTestsTabAllTestsViewData).Assembly) { }
        public string SchoolYear { get; set; }
        public string TestCategory { get; set; }
        public string Show { get; set; }
        //grid data
        public string TestName { get; set; }
        public string TestDate { get; set; }
        public string TestScore { get; set; }
        public string ScoreGroup { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.SchoolYear = base.GetParameterFromResxResource("SchoolYear", testAttribute, row);
            this.TestCategory = base.GetParameterFromResxResource("TestCategory", testAttribute, row);
            this.Show = base.GetParameterFromResxResource("Show", testAttribute, row);
            this.TestName = base.GetParameterFromResxResource("TestName", testAttribute, row);
            this.TestDate = base.GetParameterFromResxResource("TestDate", testAttribute, row);
            this.TestScore = base.GetParameterFromResxResource("TestScore", testAttribute, row);
            this.ScoreGroup = base.GetParameterFromResxResource("ScoreGroup", testAttribute, row);
        }
    }
}
