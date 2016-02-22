using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Core.Data;

namespace UITests.Pages.SchoolAndDistrict.Student.StudentDetail.BenchmarkTests.OneTest
{
    /// <summary>
    /// create benchmark tests tab data
    /// </summary>
    public class BenchmarkTestsTabOneTestViewData : TestData
    {
        /// <summary>
        /// constructor
        /// </summary>
        public BenchmarkTestsTabOneTestViewData()
            : base(typeof(BenchmarkTestsTabOneTestViewData).Assembly) { }
        public string ItemNumber { get; set; }
        public string StandardMappedTo { get; set; }
        public string StandardsDocument { get; set; }
        public string CorrectAnswer { get; set; }
        public string StudentAnswer { get; set; }
        public string TotalScore { get; set; }

        public override void GetTestDataFromResxResource(string url, string testAttribute, int row)
        {
            base.GetTestDataFromResxResource(url, testAttribute, row);
            this.ItemNumber = base.GetParameterFromResxResource("ItemNumber", testAttribute, row);
            this.StandardMappedTo = base.GetParameterFromResxResource("StandardMappedTo", testAttribute, row);
            this.StandardsDocument = base.GetParameterFromResxResource("StandardsDocument", testAttribute, row);
            this.CorrectAnswer = base.GetParameterFromResxResource("CorrectAnswer", testAttribute, row);
            this.StudentAnswer = base.GetParameterFromResxResource("StudentAnswer", testAttribute, row);
            this.TotalScore = base.GetParameterFromResxResource("TotalScore", testAttribute, row);
        }
    }
}
